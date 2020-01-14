Imports AllSpark

Public Class MoveAction
	Inherits Action

	Private strRoomMotion As String
	Private nextRoom As Integer
	Private currentItem As Inventory

	Public Sub New()
		Name = "move"
	End Sub

	Public Overrides Sub DoAction(ByRef currentRoom As Room, inventoryList() As Inventory, doorwayList() As Doorway)
		Dim inventoryCount = inventoryList.Length - 1
		strRoomMotion = "Move: Would you like to go to " & currentRoom.Doorways(0).strGetOtherRoomName(currentRoom) & "(Option 1)"
		For inti = 1 To (currentRoom.Doorways.Count - 1)
			strRoomMotion = strRoomMotion & " or " & currentRoom.Doorways(inti).strGetOtherRoomName(currentRoom) & "(Option " & (inti + 1) & ")"
		Next

		Console.WriteLine(strRoomMotion)
		nextRoom = Val(Console.ReadLine)

		If nextRoom = 0 Or (currentRoom.Doorways.Length < nextRoom) Then
			Console.WriteLine("Invalid")
		ElseIf currentRoom.Doorways(nextRoom - 1).Locked Then
			Console.WriteLine(currentRoom.Doorways(nextRoom - 1).LockedDescription)
			For intj = 0 To inventoryCount
				currentItem = inventoryList(intj)
				If currentRoom.Doorways(nextRoom - 1).UnlockCondition = currentItem.ItemName And currentItem.Acquired = True Then
					Console.WriteLine("You use your " & currentItem.ItemName & " to open the door")
					currentRoom = currentRoom.Doorways(nextRoom - 1).roomGetOtherRoom(currentRoom)
					intj = inventoryCount
				End If
			Next
		Else
			If nextRoom >= 1 And nextRoom < doorwayList.Length Then
				currentRoom = currentRoom.Doorways(nextRoom - 1).roomGetOtherRoom(currentRoom)
			Else
				Console.WriteLine("Invalid Input")
			End If
			Console.WriteLine()
		End If
	End Sub

End Class
