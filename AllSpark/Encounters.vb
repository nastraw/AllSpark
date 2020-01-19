Public Class Encounters
    Public Sub New(encounterDescription As String, encounterHappened As Boolean)
        Me.encounterDescription = encounterDescription
        Me.encounterHappened = encounterHappened
    End Sub

    Public encounterDescription As String
    Public encounterHappened As Boolean
End Class
