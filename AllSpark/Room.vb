Public Class Room
    Public Sub New(strRoomDesc As String)
        Description = strRoomDesc

    End Sub

    Private Description As String = "room one"


    Sub DisplayDescription()
        Console.WriteLine(Description)

    End Sub

End Class
