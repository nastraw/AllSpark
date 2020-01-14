Public MustInherit Class Action

	Public Name As String

	Public MustOverride Sub DoAction(ByRef currentRoom As Room, inventoryList() As Inventory, doorwayList() As Doorway)

	Public Function PrintActionOption(actionIndex As Integer) As String
		Return $"{actionIndex}-{Name}"
	End Function
End Class
