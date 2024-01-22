Imports System.Data.SqlClient
Public Class InputValidate
    Public Shared Function Input() As Boolean
        'Si ServerOrigen o DataBaseOrigen, no se editan o estan en blanco, se asignaran valores por defecto (local)
        'Si idEmpresa o los campos destino no se asigna valor, no es un número, o se deja en blanco acabará el proceso y dará error.

        If MainForm.serverOrigen.Text.Trim.Equals("Servidor") Or MainForm.serverOrigen.Text.Trim Is "" Then
            MainForm.serverOrigen.Text = DefaultSettings.serverOr
            MainForm.serverOrigen.ForeColor = Color.FromArgb(105, 105, 105)
        End If
        If MainForm.dataBaseOrigen.Text.Trim.Equals("DataBase") Or MainForm.dataBaseOrigen.Text.Trim Is "" Then
            MainForm.dataBaseOrigen.Text = DefaultSettings.dataBaseOr
            MainForm.dataBaseOrigen.ForeColor = Color.FromArgb(105, 105, 105)
        End If

        If MainForm.serverDestino.Text.Trim.Equals("Servidor") Or MainForm.serverDestino.Text.Trim Is "" Then
            MsgBox("El campo: Server Destino, NO puede estar vacío o es inválido.", MessageBoxIcon.Error)
            Return False
        End If
        If MainForm.dataBaseDestino.Text.Trim.Equals("DataBase") Or MainForm.dataBaseDestino.Text.Trim Is "" Then
            MsgBox("El campo: DataBase Destino, NO puede estar vacío o es inválido.", MessageBoxIcon.Error)
            Return False
        End If
        If MainForm.dataBaseOrigen.Text.Trim.Equals(MainForm.dataBaseDestino.Text.Trim) Then
            MsgBox("No se puede migrar a la misma base de datos.", MessageBoxIcon.Error)
            Return False
        End If

        If MainForm.idEmpresaOrigen.Text.Trim.Equals("idEmpresa") Or MainForm.idEmpresaOrigen.Text.Trim Is "" Or
            MainForm.idEmpresaDestino.Text.Trim.Equals("idEmpresa") Or MainForm.idEmpresaDestino.Text.Trim Is "" Then
            MsgBox("El campo: idEmpresa, NO puede estar vacío o es inválido.", MessageBoxIcon.Error)
            Return False
        End If
        If IsNumeric(MainForm.idEmpresaOrigen.Text) <> True Or
                IsNumeric(MainForm.idEmpresaDestino.Text) <> True Then
            MsgBox("El campo: idEmpresa, debe ser un número.", MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    Public Shared Function Settings() As Boolean
        Using serverConnectionOrigen As New SqlConnection($"Server = {MainForm.serverOrigen.Text.Replace("'", "''")};Integrated Security = True;")
            'Abre la conexión y seleciona la base de datos indicada
            Try
                serverConnectionOrigen.Open()
                Dim UseDatabaseOrigen As New SqlCommand($"use {MainForm.dataBaseOrigen.Text.Replace("'", "''")}", serverConnectionOrigen)
                UseDatabaseOrigen.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("El campo: dataBase Origen es inválido.", MessageBoxIcon.Error)
                Return False
            End Try

            'Comprueba que la tabla tblEmpresas tiene una empresa con la id escogida (en la base de datos origen)
            Try
                Dim selectTableOrigen As New SqlCommand($"select * from dbo.tblEmpresas where idEmpresa = {MainForm.idEmpresaOrigen.Text.Replace("'", "''")}", serverConnectionOrigen)
                Dim readerOrigen As SqlDataReader = selectTableOrigen.ExecuteReader()
                If readerOrigen.Read() Then
                    readerOrigen.Close()
                    'Una vez comprobado que el contenido Origen existe, se comprueba que se puede conectar a destino
                    Return ValidateQuey(serverConnectionOrigen)
                Else
                    'No existe el contenido Origen
                    MsgBox("No existe el contenido Origen", MessageBoxIcon.Error)
                    Return False
                End If
                serverConnectionOrigen.Close()
            Catch ex As Exception
                MsgBox("No existe el contenido Origen", MessageBoxIcon.Error)
                serverConnectionOrigen.Close()
                Return False
            End Try
        End Using
        Return True
    End Function

    Public Shared Function ValidateQuey(serverConnectionOrigen As SqlConnection) As Boolean
        'Una vez comprobado que el contenido Origen existe, se comprueba que se puede conectar a destino
        Dim serverConnectionDestino As SqlConnection = New SqlConnection("Server = " + MainForm.serverDestino.Text.Replace("'", "''") + ";Integrated Security = True;")
        Try
            Try
                'Abre la conexión y usa la base de datos destino
                serverConnectionDestino.Open()
                Dim UseDatabaseOrigen As New SqlCommand($"use {MainForm.dataBaseDestino.Text.Replace("'", "''")}", serverConnectionDestino)
                UseDatabaseOrigen.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("El campo: dataBaseDestino no es válido.", MessageBoxIcon.Error)
                Return False
            End Try


            'Selecciona todo el contenido de la tabla Empresas Destino, para comprobar que existe
            Dim selectTable As New SqlCommand("SELECT * FROM dbo.tblEmpresas ", serverConnectionDestino)
            Dim var As Boolean = False
            Try
                selectTable.ExecuteNonQuery()
                var = True
            Catch ex As Exception
                MsgBox("No se ha encontrado dbo.tblEmpresas en el servidor destino.", MessageBoxIcon.Error)
                Return False
            End Try
            If var Then
                'El campo existe, ahora se comprueba que la idEmpresaDestino este libre
                selectTable = New SqlCommand($"select * from dbo.tblEmpresas where idEmpresa={MainForm.idEmpresaDestino.Text.Replace("'", "''")}", serverConnectionDestino)
                Dim reader As SqlDataReader = selectTable.ExecuteReader()
                Try
                    If reader.Read() Then
                        reader.Close()
                        MsgBox("El valor de idEmpresaDestino ya existe", MessageBoxIcon.Error)
                        Return False
                    Else
                        reader.Close()
                        '------------------------------------------------------------------------
                        'Seleciona los nombres de las tablas de la BD Origen y los guarda en una lista de Strings, para su posterior uso
                        Dim listOrigen As New List(Of String)
                        Dim listReader As SqlDataReader
                        Dim sqlGetTableNamesOrigen As New SqlCommand(
                            "select table_name from INFORMATION_SCHEMA.COLUMNS
                            where COLUMN_NAME ='idEmpresa' order
                            by TABLE_NAME asc", serverConnectionOrigen)

                        listReader = sqlGetTableNamesOrigen.ExecuteReader()
                        While listReader.Read()
                            listOrigen.Add(listReader.GetString(listReader.GetOrdinal("table_name")))
                        End While
                        listReader.Close()

                        'Seleciona los nombres de las tablas de la BD Destino y los guarda en una lista de Strings
                        Dim listDestino As New List(Of String)
                        Dim sqlGetTableNamesDestino As New SqlCommand(
                            "select table_name from INFORMATION_SCHEMA.COLUMNS
                            where COLUMN_NAME ='idEmpresa' order
                            by TABLE_NAME asc", serverConnectionDestino)

                        listReader = sqlGetTableNamesDestino.ExecuteReader()
                        While listReader.Read()
                            listDestino.Add(listReader.GetString(listReader.GetOrdinal("table_name")))
                        End While
                        listReader.Close()

                        'Comprueba si las listas de Strings son iguales
                        Dim i As Integer = 0
                        While i < listOrigen.Count
                            If listOrigen(i).Equals(listDestino(i)) Then
                            Else
                                i = listOrigen.Count
                                MsgBox("Las tablas de las bases de datos origen y destino no son iguales (no tienen las mismas tablas con idEmpresa).", MessageBoxIcon.Error)
                                Return False
                            End If
                            i += 1
                        End While
                        i = 0

                        '------------------------------------------------------------------------

                        While i < listOrigen.Count

                            'Se guardan los metadatos en datatables que se comparan para comprobar su contenido'

                            selectTable = New SqlCommand($"use {MainForm.dataBaseOrigen.Text.Replace("'", "''")} 
                            select sys.objects.name, sys.columns.name, sys.columns.user_type_id, sys.columns.max_length
                            from sys.objects left join sys.columns
                            on sys.objects.object_id = sys.columns.object_id
                            where sys.objects.type='U' and sys.objects.name like '{listOrigen(i)}'", serverConnectionOrigen)

                            Dim dtOrigen As DataTable = New DataTable
                            Dim daOrigen As SqlDataAdapter = New SqlDataAdapter(selectTable)
                            daOrigen.Fill(dtOrigen)
                            daOrigen.Dispose()

                            selectTable = New SqlCommand($"use {MainForm.dataBaseDestino.Text.Replace("'", "''")} 
                            select sys.objects.name, sys.columns.name, sys.columns.user_type_id, sys.columns.max_length
                            from sys.objects left join sys.columns
                            on sys.objects.object_id = sys.columns.object_id
                            where sys.objects.type='U' and sys.objects.name like '{listDestino(i)}'", serverConnectionDestino)

                            Dim dtDestino As DataTable = New DataTable
                            Dim daDestino As SqlDataAdapter = New SqlDataAdapter(selectTable)
                            daDestino.Fill(dtOrigen)
                            daDestino.Dispose()

                            'Si los metadatos de ambas tablas son iguales, el programa sigue sin errores
                            If dtOrigen.Equals(dtDestino) Then
                                i += 1
                            Else
                                MsgBox($"La Tabla {listOrigen(i)} no contiene los mismos metadatos en destino.", MessageBoxIcon.Error)
                                i = listOrigen.Count
                                serverConnectionOrigen.Close()
                                serverConnectionDestino.Close()
                                Return False
                            End If
                        End While

                        serverConnectionOrigen.Close()
                        serverConnectionDestino.Close()

                        'Si llega aquí significa que las tablas Origen y Destino són iguales, así que empieza la migración

                        Return StartMigration()

                        '------------------------------------------------------------------------

                    End If
                Finally
                    reader.Close()
                End Try
            Else
                MsgBox("La base de datos indicada no tiene la tabla dbo.tblEmpresas necesaria para la migración.", MessageBoxIcon.Error)
                Return False
            End If
            serverConnectionDestino.Close()
        Catch ex As Exception
            'Error al conectarse al servidorDestino/dataBaseDestino o al leer datos de la dataBaseDestino
            MsgBox("Error en: InputValidate.ValidateQuey." & vbCrLf & vbCrLf + ex.ToString, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function


    Public Shared Function StartMigration() As Boolean
        'Query para migrar datos, si falla que sea en modo transact
        Try
            'Se conecta a Origen y seleciona la DB
            Dim serverConnectionOrigen As New SqlConnection($"Server = {MainForm.serverOrigen.Text.Replace("'", "''")};Integrated Security = True;")
            serverConnectionOrigen.Open()


            'Abre la conexión al server destino
            Dim serverConnectionDestino As New SqlConnection($"Server = {MainForm.serverDestino.Text.Replace("'", "''")};Integrated Security = True;")
            serverConnectionDestino.Open()
            '_________________________________________
            'Specific tables removed
            Dim sqlstring As String = $"begin try
	begin transaction
		use  {MainForm.dataBaseOrigen.Text.Replace("'", "''")} 
		INSERT INTO {(MainForm.dataBaseDestino.Text & ".dbo.tblEmpresas").Replace("'", "''")}(

		Id

		select 

		{MainForm.idEmpresaDestino.Text.Replace("'", "''")},
        Id,

		FROM tblEmpresas
		where IdEmpresa = {MainForm.idEmpresaOrigen.Text.Replace("'", "''")}
	    commit transaction
        end try
        begin catch
	    rollback transaction
        end catch"
            Dim queryCopia As New SqlCommand(sqlstring, serverConnectionDestino)

            'Dim sqlstring2 As String = "select * from @db"
            'Dim queryCopia As New SqlCommand(sqlstring2, serverConnectionDestino)
            'queryCopia.Parameters.Add("@db", SqlDbType.VarChar, 50).Value = MainForm.dataBaseOrigen.Text + ".dbo.tblEmpresas"

            'Parametros Sql para evitar Inject SQL
            'queryCopia.Parameters.Add("@dbo", SqlDbType.VarChar, 50).Value = MainForm.dataBaseOrigen.Text
            'queryCopia.Parameters.Add("@dbd", SqlDbType.VarChar, 50).Value = MainForm.dataBaseDestino.Text & ".dbo.tblEmpresas"
            'queryCopia.Parameters.Add("@ieo", SqlDbType.Int).Value = MainForm.idEmpresaOrigen.Text
            'queryCopia.Parameters.Add("@ied", SqlDbType.Int).Value = MainForm.idEmpresaDestino.Text
            queryCopia.ExecuteNonQuery()

            '-----------------------------------------------------------------------------------------
            'Query de copiar todas las tablas de una bd a otra


            While 1 = 1

            End While

            '-----------------------------------------------------------------------------------------
            'Si la checkbox esta marcada eliminar la Empresa Origen
            If MainForm.eeoBolean Then
                'Si durante la eliminación da algún error, la query deshace los cambios
                Using queryDelete As New SqlCommand(
                    $"begin try
                    begin transaction
                       use {MainForm.dataBaseOrigen.Text.Replace("'", "''")} delete from {MainForm.dataBaseOrigen.Text.Replace("'", "''")}.dbo.tblEmpresas 
                       where idEmpresa={MainForm.idEmpresaOrigen.Text.Replace("'", "''")} commit transaction
                       end try
                       begin catch
                    rollback transaction
                       end catch", serverConnectionOrigen)
                    Try
                        queryDelete.ExecuteNonQuery()
                        MsgBox("Empresa Origen eliminada con éxito.", MessageBoxIcon.Information)
                    Catch ex As Exception
                        MsgBox(ex.ToString, MessageBoxIcon.Error)
                    End Try
                End Using
            End If
            Return True



            '___________________________________________________________________________________


        Catch ex As Exception
            MsgBox(ex.ToString, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    'Public Shared Function fetchValue() As DataTable
    '    Dim dap As SqlDataAdapter = New SqlDataAdapter("Select * from tblEmpresas where idEmpresa=" + MainForm.idEmpresaOrigen.Text + ";", serverConnectionOrigen)
    '    Dim ds As DataSet = New DataSet()
    '    dap.Fill(ds)
    '    Return ds.Tables
    'End Function

End Class
