Module Module1

	Sub Main()

		Dim currentRoom As Room
		Dim input As Integer

        Dim rooms(3) As Room
        rooms(0) = New Room("The Study", "This is where procrastinating is done.", False, "You explore and find ", New String() {1, 2}, "The Candlestick")
        rooms(1) = New Room("The Library", "Where wild books make their nest.", False, "You explore and find  ", New String() {0, 2}, "The Wrench")
        rooms(2) = New Room("The Billiards Room", "This has a pool table, not to be confused with a table inside of a pool.", False, "You explore and find a secret exit.", New String() {0, 1, 3}, "None")
        rooms(3) = New Room("The Ballroom", "Sadly, not a ballpit.", False, "You reached the exit.", New String() {0, 2}, "None")

        Dim strRoomMotion As String
        Dim nextRoom As Integer
        Dim intScreenReset As Integer
        currentRoom = rooms(0)

        Dim inventory(2) As Inventory
        inventory(0) = New Inventory(False, "The Lead Pipe", "A blunt weapon", 1)
        inventory(1) = New Inventory(False, "The Wrench", "Handy for plumbing", 1)
        inventory(2) = New Inventory(False, "The Candlestick", "Good for mood lighting", 1)
        Dim currentItem As Inventory
        Dim strItemList As String

        Do While currentRoom IsNot Nothing

            intScreenReset += 1

            If intScreenReset = 4 Then
                Console.Clear()
                intScreenReset = 0
            End If

            Console.ForegroundColor = ConsoleColor.Gray

            For inti = 0 To 2
                For intj = 0 To 100
                    Console.Write("*")
                Next
                Console.WriteLine()
            Next

            Console.WriteLine()

            'introductions to the room

            Console.ForegroundColor = ConsoleColor.Blue

            Console.WriteLine("You are in the " & currentRoom.Name)
			Console.WriteLine(currentRoom.Description)
			Console.WriteLine()

            Console.ForegroundColor = ConsoleColor.White

            'player choice

            Console.WriteLine("what do you want to do: 0-move 1-inventory 2-explore")
			input = Console.ReadLine

            If input = 0 Then

                'this block will customize the room options. the user will always type sequentially starting from 0. the text will be as long as it needs to be for all options to appear
                strRoomMotion = "Move: Would you like to go to the " & rooms(currentRoom.Exits(0)).Name & "(Option 0)"
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
                Console.WriteLine()

            ElseIf input = 1 Then
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
                    Console.WriteLine(strItemList)
                    Console.WriteLine("Which would you like to use?")

                    'need to work on this part

                End If

                'inventory
            Else
                'explore
                Console.WriteLine(currentRoom.ExploreText & currentRoom.hiddenitem)
                If currentRoom.hiddenitem <> "None" Then
                    For intj = 0 To 2
                        currentItem = inventory(intj)
                        If currentRoom.hiddenitem = currentItem.ItemName Then
                            currentItem.Acquired = True
                            Console.WriteLine(currentItem.ItemDescription)
                        End If
                    Next
                End If
            End If

        Loop

		Console.WriteLine("Bye for now!")
		Console.ReadKey()

	End Sub


End Module
