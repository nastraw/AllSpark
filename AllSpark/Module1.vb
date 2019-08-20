Module Module1

	Sub Main()

		Dim currentRoom As Room
		Dim input As Integer

        Dim rooms(3) As Room
        rooms(0) = New Room("The Study", "This is where procrastinating is done.", "You explore and find ", "The Candlestick") ' 1, 2, 3
        rooms(1) = New Room("The Library", "Where wild books make their nest.", "You explore and find  ", "The Wrench") ' 0, 2
        rooms(2) = New Room("The Billiards Room", "This has a pool table, not to be confused with a table inside of a pool.", "You explore and find a secret exit.", "") ' 0, 1, 3
        rooms(3) = New Room("The Ballroom", "Sadly, not a ballpit.", "You reached the exit.", "") ' 0, 2

        Dim doorways(4) As Doorway
        doorways(0) = New Doorway(rooms(0), rooms(1), "A door", Nothing, Nothing, False) ' study to library
        doorways(1) = New Doorway(rooms(0), rooms(2), "A door", Nothing, Nothing, False) ' study to billiards
        doorways(2) = New Doorway(rooms(0), rooms(3), "A door", "It is barricaded on one side", "Remove barricade", True) ' study to ballroom - secret passage
        doorways(3) = New Doorway(rooms(1), rooms(2), "A door", Nothing, Nothing, False) ' library to billiards
        doorways(4) = New Doorway(rooms(2), rooms(3), "A door", Nothing, Nothing, False) ' billiards to ballroom

        ReDim rooms(0).Doorways(2) ' study
        rooms(0).Doorways(0) = doorways(0)
        rooms(0).Doorways(1) = doorways(1)
        rooms(0).Doorways(2) = doorways(2)

        ReDim rooms(1).Doorways(1) ' library
        rooms(1).Doorways(0) = doorways(0)
        rooms(1).Doorways(1) = doorways(3)

        ReDim rooms(2).Doorways(2) ' billiards
        rooms(2).Doorways(0) = doorways(1)
        rooms(2).Doorways(1) = doorways(3)
        rooms(2).Doorways(2) = doorways(4)

        ReDim rooms(3).Doorways(1) ' ballroom
        rooms(3).Doorways(0) = doorways(2)
        rooms(3).Doorways(1) = doorways(4)

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
                strRoomMotion = "Move: Would you like to go to the " & currentRoom.Doorways(0).strGetOtherRoomName(currentRoom) & "(Option 0)"
                For inti = 1 To (currentRoom.Doorways.Count - 1)
                    strRoomMotion = strRoomMotion & " or the " & currentRoom.Doorways(inti).strGetOtherRoomName(currentRoom) & "(Option " & inti & ")"
                Next

                'outputs the text of the room options
                Console.WriteLine(strRoomMotion)

                'reads response and moves to correct room
                'in future consider better error trapping if there are secret rooms, locked rooms, and rooms with more exit possibilities
                nextRoom = Console.ReadLine

                If currentRoom.Doorways(nextRoom).Locked Then
                    Console.WriteLine(currentRoom.Doorways(nextRoom).LockedDescription)
                Else
                    If nextRoom = 0 Then
                        currentRoom = currentRoom.Doorways(nextRoom).roomGetOtherRoom(currentRoom)
                    ElseIf nextRoom = 1 Then
                        currentRoom = currentRoom.Doorways(nextRoom).roomGetOtherRoom(currentRoom)
                    ElseIf currentRoom.Doorways.Length = 3 And nextRoom = 2 Then
                        currentRoom = currentRoom.Doorways(nextRoom).roomGetOtherRoom(currentRoom)
                    Else

                        Console.WriteLine("Invalid Input")
                    End If
                    Console.WriteLine()
                End If

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
