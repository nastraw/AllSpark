Imports AllSpark

Public Class ExploreAction
	Inherits Action

	Public Sub New()
		Name = "explore"
	End Sub

	Public Overrides Sub DoAction(ByRef currentRoom As Room, inventoryList() As Inventory, doorwayList() As Doorway)
		Dim inventoryCount = inventoryList.Length - 1
		If currentRoom.hiddenitem <> "None" Then
			Console.WriteLine(currentRoom.ExploreText & currentRoom.hiddenitem)
			If currentRoom.hiddenitem = "a secret passage" Then
				If currentRoom.Name = "The Kitchen" Then
					Console.WriteLine("This passage leads to the Study")
					ReDim currentRoom.Doorways(2)
					currentRoom.Doorways(0) = doorwayList(1)
					currentRoom.Doorways(1) = doorwayList(2)
					currentRoom.Doorways(2) = doorwayList(12)
				ElseIf currentRoom.Name = "The Conservatory" Then
					Console.WriteLine("This passage leads to the Lounge")
					ReDim currentRoom.Doorways(2)
					currentRoom.Doorways(0) = doorwayList(3)
					currentRoom.Doorways(1) = doorwayList(4)
					currentRoom.Doorways(2) = doorwayList(11)
				End If
			Else
				For intj = 0 To inventoryCount
					Dim currentItem = inventoryList(intj)
					If currentRoom.hiddenitem = currentItem.ItemName Then
						currentItem.Acquired = True
						Console.WriteLine(currentItem.ItemDescription)
						currentRoom.ExploreText = ""
						currentRoom.hiddenitem = "None"
					End If
				Next
			End If
		Else
			Console.WriteLine("There is nothing to be found")
		End If

		If currentRoom.hiddenitem = "the CONFESSION! Gasp. Colonel Mustard, Study and Lead Pipe all along, the jerk." Then
			currentRoom = Nothing
		End If
	End Sub
End Class
