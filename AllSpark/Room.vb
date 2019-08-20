Public Class Room
    Public Sub New(name As String, strRoomDesc As String, exploreText As String, HiddenItem As String)
        Me.Name = name
        Me.Description = strRoomDesc
        Me.ExploreText = exploreText
        Me.hiddenitem = HiddenItem
    End Sub

    Public ReadOnly Name As String
	Public Description As String
	Public Locked As Boolean
    Public ExploreText As String
    Public hiddenitem As String
    Public Doorways() As Doorway


End Class
