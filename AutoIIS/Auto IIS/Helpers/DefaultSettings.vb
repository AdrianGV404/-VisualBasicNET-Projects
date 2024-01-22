
Imports System.IO
Public Class DefaultSettings

    'Variables default para los inputs
    Public Shared Property AppPath As String = My.Application.Info.DirectoryPath
    Public Shared ReadOnly Property FixedDomainDB As String = "DOMAIN"
    Public Shared ReadOnly Property ServiceDomainDB As String = "SERVICE"
    Public Shared ReadOnly Property FixedDomain As String = ".DOMAIN.es"
    Public Shared ReadOnly Property ServiceDomain As String = ".DOMAIN.service"
    Public Shared Property EnterpriseName As String = "Nombre de la empresa"
    Public Shared Property DBmdf As String = "DBBusiness"
    Public Shared Property DBldf As String = "DBBusiness_log"
    'Host = EnterpriseName + FixedDomain
    'DB = Host
    'UserName = EnterpriseName + ServiceDomain
    'FilePath += UserName
    Public Shared Property DatabaseName As String = ""
    Public Shared Property UserName As String = ""
    Public Shared Property WebName As String = ""
    'FilePathHelper sirve en AutoIIS.TextBox_Enterprise_LostFocus para no editarlo constantemente
    Public Shared Property FilePathHelper As String = ""
    Public Shared ReadOnly Property IISApplicationPool As String = "T3"
    Public Shared ReadOnly Property IISProtocol As String = "http"
    Public Shared ReadOnly Property IISLink As String = "*:80:"
    'Ruta archivo logs
    Public Shared ReadOnly Property LogsFile As String = "logs.txt"

End Class