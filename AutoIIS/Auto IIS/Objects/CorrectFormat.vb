Public Class CorrectFormat

    Public Shared NumArray() As Byte = {
        "48", "49", "50", "51", "52", "53", "54", "55", "56", "57"
    }

    Public Shared MinusLetterArray() As Byte = {
        "97", "98", "99", "100", "101", "102", "103", "104", "105",
        "106", "107", "108", "109", "110", "111", "112", "113", "114",
        "115", "116", "117", "118", "119", "120", "121", "122"
    }

    Public Shared MayusLetterArray() As Byte = {
        "65", "66", "67", "68", "69", "70", "71", "72", "73",
        "74", "75", "76", "77", "78", "79", "80", "81", "82",
        "83", "84", "85", "86", "87", "88", "89", "90"
    }

    Public Shared SpecialCharAsAscii() As Byte = {
        "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42",
        "43", "44", "45", "47", "58", "59", "60", "61", "62", "63", "64",
        "91", "92", "93", "94", "96", "123", "124", "125", "126"
    }

    Public Shared NumArrayMinusLetterArray() As Byte = {
        "48", "49", "50", "51", "52", "53", "54", "55", "56", "57",
        "97", "98", "99", "100", "101", "102", "103", "104", "105",
        "106", "107", "108", "109", "110", "111", "112", "113", "114",
        "115", "116", "117", "118", "119", "120", "121", "122"
    }


    Public Shared Function DomainFormat(Text As String, MinPointNumber As Integer) As Boolean
        Text = Text.ToLower()
        If MinPointNumber = 0 Then
            MinPointNumber = 2
        End If
        Dim Valid As Boolean = False
        Dim PointNumber = 0
        Try
            Dim DomainAsChar As Char() = Text.ToCharArray
            For i = 0 To DomainAsChar.Length - 1
                'Si hay un punto
                If Asc(DomainAsChar(i)) = "46" Then
                    PointNumber += 1
                    'Comprueba que el carácter anterior y posterior al punto sean letras o numeros
                    Try
                        Dim ByteArray() As Byte = {Asc(DomainAsChar(i - 1)), Asc(DomainAsChar(i + 1))}
                        Valid = CompareBytes(ByteArray, NumArrayMinusLetterArray)
                        If Valid.Equals(False) Then
                            GeneralUtils.ErrorConsole("El nombre de la web debe tener texto entre los puntos CorrectFormat.DomainFormat().")
                            AlertType.StringMessage("Error", "El nombre de la web debe" & vbNewLine & "tener texto entre los puntos.")
                            Return Valid
                        Else
                            'Comprueba que el carácter anterior y posterior al punto sean válidos (que no sean " . , ' *)
                            Try
                                Valid = CorrectFormat.DenySpecialCaracters(DomainAsChar(i - 1))
                                Valid = CorrectFormat.DenySpecialCaracters(DomainAsChar(i + 1))
                                If Valid.Equals(False) Then
                                    AlertType.StringMessage("Error", "El nombre de la web contiene" & vbNewLine & "caracteres inválidos.")
                                    Return Valid
                                End If
                            Catch ex As Exception
                                GeneralUtils.ErrorConsole("Error en CorrectFormat.DomainFormat().")
                            End Try
                        End If
                    Catch ex As Exception
                        GeneralUtils.ErrorConsole("El nombre de la web no es valido CorrectFormat.DomainFormat(). " + ex.Message)
                        AlertType.StringMessage("Error", "El nombre de la web" & vbNewLine & "no es valido.")
                        Valid = False
                        Return Valid
                    End Try
                End If
            Next
            'Que haya cómo mínimo "MinPointNumber" puntos (2 por defecto)
            If PointNumber >= MinPointNumber Then
                Valid = True
            Else
                Valid = False
                AlertType.StringMessage("Error", "El nombre de la web debe" & vbNewLine & "tener almenos 2 puntos.")
            End If
        Catch ex As Exception
            GeneralUtils.ErrorConsole("Error en la comprobación de los caracteres CorrectFormat.DomainFormat(). " + ex.Message)
            AlertType.StringMessage("Error", "Error en la comprobación" & vbNewLine & "de los caracteres" & vbNewLine & "(CorrectFormat.DomainFormat).")
        End Try
        Return Valid
    End Function

    Public Shared Function DenySpecialCaracters(Text As String) As Boolean
        Dim ByteArray() As Byte = System.Text.Encoding.ASCII.GetBytes(Text.ToCharArray)
        Dim Valid As Boolean = CompareBytes(ByteArray, SpecialCharAsAscii)
        'Lo invierto porque CompareChar devuelve true si un char coincide
        Valid = Not Valid
        Return Valid
    End Function


    Public Shared Function CompareBytes(ByteArray1 As Byte(), ByteArray2 As Byte()) As Boolean
        'Compara dos char(), si un byte(comparar caracteres en ASCII) equivale a uno del otro, devuelve true
        Dim Match As Boolean = False
        Dim i As Integer = 0
        While i < ByteArray1.Length And Match.Equals(False)
                Dim j As Integer = 0
                While j < ByteArray2.Length And Match.Equals(False)
                    If ByteArray1(i).Equals(ByteArray2(j)) Then
                        Match = True
                    End If
                    j += 1
                End While
                i += 1
            End While
            Return Match
    End Function


    Public Shared Function CompareStringComplete(SearchWithinThis As String, SearchForThis As String) As Boolean
        If SearchWithinThis.Contains(SearchForThis) Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Shared Function PasswordValid(Password As String) As Boolean
        'Si un String es: > 8 & < 32, tiene 1 mayúscula y 1 número
        Dim Valid = False
        If Password.Length >= 8 And Password.Length <= 32 Then
            Dim PasswordArray() As Byte = System.Text.Encoding.ASCII.GetBytes(Password.ToCharArray)
            Valid = CompareBytes(PasswordArray, NumArray)
            If Valid.Equals(False) Then
                AlertType.StringMessage("Error", "La contraseña debe tener" & vbNewLine & "almenos un número.")
            Else
                Valid = CompareBytes(PasswordArray, MayusLetterArray)
                If Valid.Equals(False) Then
                    AlertType.StringMessage("Error", "La contraseña debe tener" & vbNewLine & "almenos una mayúscula.")
                End If
            End If
        Else
            If Password.Length > 32 Then
                AlertType.StringMessage("Error", "La contraseña no puede ser" & vbNewLine & "mayor a 32 caracteres.")
            Else
                AlertType.StringMessage("Error", "La contraseña debe ser" & vbNewLine & "mayor a 8 caracteres.")
            End If
        End If
        Return Valid
    End Function

End Class