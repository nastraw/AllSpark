﻿Module Module1
	Dim currentRoom As Room
	Dim input As Integer
	Dim actions(2) As Action
	Dim doorways(12) As Doorway
	Dim rooms(11) As Room
	Dim strRoomMotion As String
	Dim nextRoom As Integer
	Dim INVENTORYMAX As Integer = 8
	Dim inventory(INVENTORYMAX) As Inventory
	Dim currentItem As Inventory
	Dim strItemList As String
	Sub Main()

		Creation()
		Do While currentRoom IsNot Nothing
			Console.ForegroundColor = ConsoleColor.Gray
			For inti = 0 To 2
				For intj = 0 To 100
					Console.Write("*")
				Next
				Console.WriteLine()
			Next
			Console.WriteLine()
			Console.ForegroundColor = ConsoleColor.Blue
			Console.WriteLine("You are in the " & currentRoom.Name)
			Console.WriteLine(currentRoom.Description)
			Console.WriteLine()
			Console.ForegroundColor = ConsoleColor.White

			Dim actionOptions = "What do you want to do: "
			For inti = 0 To (actions.Count - 1)
				actionOptions = actionOptions & " " & actions(inti).PrintActionOption(inti)
			Next
			Console.WriteLine("What do you want to do: 1-move 2-inventory 3-explore")
			input = Val(Console.ReadLine)
			If input > 0 And input <= actions.Length Then
				actions(input - 1).DoAction(currentRoom, inventory, doorways)
			ElseIf input = 99 Then
				QuitGame()
			Else
				Console.WriteLine("Invalid")
			End If

		Loop
		Console.WriteLine("Bye for now!")
		Console.ReadKey()
	End Sub

	Public Sub Creation()

		actions(0) = New MoveAction()
		actions(1) = New InventoryAction()
		actions(2) = New ExploreAction()

		'could remove "you explore and find parameter" but I suspect we'll want it for events later on. 

		rooms(0) = New Room("The Lounge", "No time for lounging - we've got a mystery afoot!", "You explore and find ", "The Candlestick")
		rooms(1) = New Room("The Dining Room", "How elegant.", "You explore and find  ", "The Bronze Key")
		rooms(2) = New Room("The Kitchen", "Help yourself to the fridge", "You explore and find ", "a secret passage")
		rooms(3) = New Room("The Ballroom", "Sadly, not a ballpit.", "You explore and find ", "The Silver Key")
		rooms(4) = New Room("The Conservatory", "Conserve your strength", "You explore and find", "a secret passage")
		rooms(5) = New Room("The Billiard Room", "This has a pool table, not to be confused with a table inside of a pool.", "You explore and find ", "The Wrench")
		rooms(6) = New Room("The Library", "Where wild books make their nest.", "You explore and find  ", "The Gold Key")
		rooms(7) = New Room("The Study", "Study up. There will be a quiz later", "You explore and find ", "Nothing")
		rooms(8) = New Room("The Hall", "Don't get stuffed in a locker", "You explore and find", "The Revolver")
		rooms(9) = New Room("The Stairs", "Up and up and up they go...", "You explore and find", "The Rope")
		rooms(10) = New Room("The Bedroom", "This feels like an invasion of your host's privacy", "You explore and find  ", "The Knife")
		rooms(11) = New Room("The Vault", "A secret vault. How mysterious.", "You explore and find ", "the CONFESSION! Gasp. Colonel Mustard, Study and Lead Pipe all along, the jerk.")

		doorways(0) = New Doorway(rooms(0), rooms(1), "A Door", Nothing, Nothing, False)
		doorways(1) = New Doorway(rooms(1), rooms(2), "A Door", Nothing, Nothing, False)
		doorways(2) = New Doorway(rooms(2), rooms(3), "A Door", Nothing, Nothing, False)
		doorways(3) = New Doorway(rooms(3), rooms(4), "A Door", Nothing, Nothing, False)
		doorways(4) = New Doorway(rooms(4), rooms(5), "A Door", Nothing, Nothing, False)
		doorways(5) = New Doorway(rooms(5), rooms(6), "A Door", Nothing, Nothing, False)
		doorways(6) = New Doorway(rooms(6), rooms(7), "A Door", Nothing, Nothing, False)
		doorways(7) = New Doorway(rooms(7), rooms(8), "A Door", Nothing, Nothing, False)
		doorways(8) = New Doorway(rooms(8), rooms(9), "A Bronze Door", "The Bronze Door is Locked", "The Bronze Key", True)
		doorways(9) = New Doorway(rooms(9), rooms(10), "A Silver Door", "The Silver Door is Locked", "The Silver Key", True)
		doorways(10) = New Doorway(rooms(10), rooms(11), "A Gold Vault", "The Gold Vault is Locked", "The Gold Key", True)
		doorways(11) = New Doorway(rooms(0), rooms(4), "A Secret Tunnel", Nothing, Nothing, False)
		doorways(12) = New Doorway(rooms(2), rooms(7), "A Secret Passage", Nothing, Nothing, False)

		ReDim rooms(0).Doorways(0)
		rooms(0).Doorways(0) = doorways(0)

		ReDim rooms(1).Doorways(1)
		rooms(1).Doorways(0) = doorways(0)
		rooms(1).Doorways(1) = doorways(1)

		ReDim rooms(2).Doorways(1)
		rooms(2).Doorways(0) = doorways(1)
		rooms(2).Doorways(1) = doorways(2)

		ReDim rooms(3).Doorways(1)
		rooms(3).Doorways(0) = doorways(2)
		rooms(3).Doorways(1) = doorways(3)

		ReDim rooms(4).Doorways(1)
		rooms(4).Doorways(0) = doorways(3)
		rooms(4).Doorways(1) = doorways(4)

		ReDim rooms(5).Doorways(1)
		rooms(5).Doorways(0) = doorways(4)
		rooms(5).Doorways(1) = doorways(5)

		ReDim rooms(6).Doorways(1)
		rooms(6).Doorways(0) = doorways(5)
		rooms(6).Doorways(1) = doorways(6)

		ReDim rooms(7).Doorways(1)
		rooms(7).Doorways(0) = doorways(6)
		rooms(7).Doorways(1) = doorways(7)

		ReDim rooms(8).Doorways(1)
		rooms(8).Doorways(0) = doorways(7)
		rooms(8).Doorways(1) = doorways(8)

		ReDim rooms(9).Doorways(1)
		rooms(9).Doorways(0) = doorways(8)
		rooms(9).Doorways(1) = doorways(9)

		ReDim rooms(10).Doorways(1)
		rooms(10).Doorways(0) = doorways(9)
		rooms(10).Doorways(1) = doorways(10)

		currentRoom = rooms(0)

		inventory(0) = New Inventory(False, "The Lead Pipe", "A blunt weapon", 1)
		inventory(1) = New Inventory(False, "The Wrench", "Handy for plumbing", 1)
		inventory(2) = New Inventory(False, "The Candlestick", "Good for mood lighting", 1)
		inventory(3) = New Inventory(False, "The Revolver", "Remember, guns don't kill people. People kill guns", 1)
		inventory(4) = New Inventory(False, "The Rope", "Could always use rope", 1)
		inventory(5) = New Inventory(False, "The Knife", "Stabby Stab", 1)
		inventory(6) = New Inventory(False, "The Bronze Key", "ooooooo shiny", 1)
		inventory(7) = New Inventory(False, "The Silver Key", "Silver! Your favorite color", 1)
		inventory(8) = New Inventory(False, "The Gold Key", "My precious...my precious....", 1)
	End Sub

	Public Sub Movement()
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
			For intj = 0 To INVENTORYMAX
				currentItem = inventory(intj)
				If currentRoom.Doorways(nextRoom - 1).UnlockCondition = currentItem.ItemName And currentItem.Acquired = True Then
					Console.WriteLine("You use your " & currentItem.ItemName & " to open the door")
					currentRoom = currentRoom.Doorways(nextRoom - 1).roomGetOtherRoom(currentRoom)
					intj = INVENTORYMAX
				End If
			Next
		Else
			If nextRoom >= 1 And nextRoom <= doorways.Length Then
				currentRoom = currentRoom.Doorways(nextRoom - 1).roomGetOtherRoom(currentRoom)
			Else
				Console.WriteLine("Invalid Input")
			End If
			Console.WriteLine()
		End If
	End Sub

	Public Sub Backpack()
		strItemList = "You currently possess: "
		For inti = 0 To 2
			currentItem = inventory(inti)
			If currentItem.Acquired = True Then
				strItemList = strItemList & currentItem.ItemName & ", "
			End If
		Next
		If strItemList = "You currently possess: " Then
			Console.WriteLine("You currently possess no items.")
		Else
			Console.WriteLine(Left(strItemList, (Len(strItemList) - 2)))
		End If
	End Sub

	Public Sub Exploration()
		If currentRoom.hiddenitem <> "None" Then
			Console.WriteLine(currentRoom.ExploreText & currentRoom.hiddenitem)
			If currentRoom.hiddenitem = "a secret passage" Then
				If currentRoom.Name = "The Kitchen" Then
					Console.WriteLine("This passage leads to the Study")
					ReDim rooms(2).Doorways(2)
					rooms(2).Doorways(0) = doorways(1)
					rooms(2).Doorways(1) = doorways(2)
					rooms(2).Doorways(2) = doorways(12)
				ElseIf currentRoom.Name = "The Conservatory" Then
					Console.WriteLine("This passage leads to the Lounge")
					ReDim rooms(4).Doorways(2)
					rooms(4).Doorways(0) = doorways(3)
					rooms(4).Doorways(1) = doorways(4)
					rooms(4).Doorways(2) = doorways(11)
				End If
			Else
				For intj = 0 To INVENTORYMAX
					currentItem = inventory(intj)
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

	Public Sub QuitGame()
		Console.WriteLine("Quitter!")
		System.Threading.Thread.Sleep(800)

		currentRoom = Nothing
	End Sub
End Module
