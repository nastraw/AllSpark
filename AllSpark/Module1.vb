Module Module1

	Sub Main()

		Dim currentRoom As Room
		Dim input As Integer

		Dim strMasterRoom(3, 9) As String
		Dim rooms(3) As Room
		rooms(0) = New Room("The Study", "This is where procrastinating is done.", False, "You explore and find nothing of use.", New String() {1, 2})
		rooms(1) = New Room("The Library", "Where wild books make their nest.", False, "You discovered the Wrench.", New String() {0, 2})
		rooms(2) = New Room("The Billiards Room", "This has a pool table, not to be confused with a table inside of a pool.", False, "You explore and find a secret exit.", New String() {0, 1, 3})
		rooms(3) = New Room("The Ballroom", "Sadly, not a ballpit.", False, "You reached the exit.", New String() {0, 2})

		Dim strRoomMotion As String
		Dim nextRoom As Integer

		currentRoom = rooms(0)

		Do While currentRoom IsNot Nothing

			'introductions to the room

			Console.WriteLine("You are in the " & currentRoom.Name)
			Console.WriteLine(currentRoom.Description)
			Console.WriteLine()

			'player choice

			Console.WriteLine("what do you want to do: 0-move 1-inventory 2-explore")
			input = Console.ReadLine

			If input = 0 Then

				'this block will customize the room options. the user will always type sequentially starting from 0. the text will be as long as it needs to be for all options to appear
				strRoomMotion = "would you like to go to the " & rooms(currentRoom.Exits(0)).Name & "(Option 0)"
				For inti = 1 To (currentRoom.Exits.Count - 1)
					strRoomMotion = strRoomMotion & " or the " & rooms(currentRoom.Exits(inti)).Name & "(Option " & inti & ")"
				Next

				'outputs the text of the room options
				Console.WriteLine(strRoomMotion)

				'reads response and moves to correct room
				'in future consider better error trapping if there are secret rooms, locked rooms, and rooms with more exit possibilities
				nextRoom = Console.ReadLine
				If nextRoom = 0 Then
					currentRoom = rooms(currentRoom.Exits(nextRoom))
				ElseIf nextRoom = 1 Then
					currentRoom = rooms(currentRoom.Exits(nextRoom))
				ElseIf currentRoom.Exits.Length = 3 And nextRoom = 2 Then
					currentRoom = rooms(currentRoom.Exits(nextRoom))
				Else

					Console.WriteLine("Invalid Input")
				End If

			ElseIf input = 1 Then
				'inventory
			Else
				'explore
				Console.WriteLine(currentRoom.ExploreText)

				'in future consider how this step changes other parts. does this add something to your inventory? open up another room option and if so how does it get added to list

			End If

		Loop

		Console.WriteLine("Bye for now!")
		Console.ReadKey()

	End Sub


End Module
