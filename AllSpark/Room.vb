Public Class Room
	Public Sub New(name As String, strRoomDesc As String, locked As Boolean, exploreText As String, exits() As String)
		Me.Name = name
		Me.Description = strRoomDesc
		Me.Locked = locked
		Me.ExploreText = exploreText
		Me.Exits = exits
	End Sub

	Public ReadOnly Name As String
	Public Description As String
	Public Locked As Boolean
	Public ExploreText As String
	Public Exits() As String
End Class
