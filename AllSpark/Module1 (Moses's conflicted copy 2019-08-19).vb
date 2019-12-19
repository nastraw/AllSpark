Module Module1

	Sub Main()

        'This was to check that we could have more than one component for a room and it works
        'Dim alphaRoom As RoomDraft = New RoomDraft("the study", 12)
        'Console.WriteLine(alphaRoom.RoomText)
        'Console.WriteLine(alphaRoom.RoomNum)

        Dim currentRoom As Integer = 0
        Dim input As Integer
        'Dim firstRoom As Room = New Room("first room")
        'Dim secondRoom As Room = New Room("the library")
        'Dim thirdRoom As Room = New Room("the billiards room")
        'Dim interror As Integer
        'Do While currentRoom >= 0

        '    Console.WriteLine("what do you want to do: 0-move 1-inventory 2-explore")
        '    input = Console.ReadLine

        '    If input = 0 Then
        '        Console.WriteLine("choose your path: 0-first room 1-library 2-billiards room")

        '        interror = currentRoom
        '        currentRoom = Console.ReadLine
        '        If currentRoom = 0 Then
        '            firstRoom.DisplayDescription()
        '        ElseIf currentRoom = 1 Then
        '            secondRoom.DisplayDescription()
        '        ElseIf currentRoom = 2 Then
        '            thirdRoom.DisplayDescription()
        '        ElseIf currentRoom < 0 Then
        '            Exit Do
        '        Else
        '            Console.WriteLine("Invalid input")
        '            currentRoom = interror
        '        End If
        '    ElseIf input = 1 Then
        '        'inventory
        '    Else
        '        'explore

        '    End If

        'Loop

        'Console.WriteLine("Bye for now!")

        Dim strMasterRoom(3, 9) As String

        strMasterRoom(0, 0) = "The Study"                                'Room Name
        strMasterRoom(0, 1) = "This is where procrastinating is done."   'Room Description Text
        strMasterRoom(0, 2) = 0                                          'Lock Status. 0 = Unlocked. 1 = Locked
        strMasterRoom(0, 3) = "You explore and find nothing of use"      'Explore Room Text
        strMasterRoom(0, 4) = 2                                          'Indicates # of exits
        strMasterRoom(0, 5) = 1                                          'Indicates Index of One Exit in Array - in this case the library
        strMasterRoom(0, 6) = 2                                          'Indicates Index of One Exit in Array - in this case the billiards room

        strMasterRoom(1, 0) = "The Library"                         'Room Name
        strMasterRoom(1, 1) = "Where wild books make their nest."   'Room Description Text
        strMasterRoom(1, 2) = 0                                     'Lock Status. 0 = Unlocked. 1 = Locked
        strMasterRoom(1, 3) = "You discovered the Wrench"           'Explore Room Text
        strMasterRoom(1, 4) = 2                                     'Indicates # of exits
        strMasterRoom(1, 5) = 0                                     'Indicates Index of One Exit in Array - in this case the study
        strMasterRoom(1, 6) = 2                                     'Indicates Index of One Exit in Array - in this case the billiards room

        strMasterRoom(2, 0) = "The Billiards Room"                           'Room Name
        strMasterRoom(2, 1) = "This has a pool table, not to be confused with a table inside of a pool."       'Room Description Text
        strMasterRoom(2, 2) = 0                                     'Lock Status. 0 = Unlocked. 1 = Locked
        strMasterRoom(2, 3) = "You explore and find a secret exit"  'Explore Room Text
        strMasterRoom(2, 4) = 3                                     'Indicates # of exits
        strMasterRoom(2, 5) = 0                                     'Indicates Index of One Exit in Array - in this case the study
        strMasterRoom(2, 6) = 1                                     'Indicates Index of One Exit in Array - in this case the library
        strMasterRoom(2, 7) = 3                                     'Indicates Index of One Exit in Array - in this case the ballroom

        strMasterRoom(3, 0) = "The Ballroom"                        'Room Name
        strMasterRoom(3, 1) = "Sadly, not a ballpit."               'Room Description Text
        strMasterRoom(3, 2) = 0                                     'Lock Status. 0 = Unlocked. 1 = Locked
        strMasterRoom(3, 3) = "You reached the exit"                'Explore Room Text
        strMasterRoom(3, 4) = 2                                     'Indicates # of exits
        strMasterRoom(3, 5) = 0                                     'Indicates Index of One Exit in Array
        strMasterRoom(3, 6) = 2                                     'Indicates Index of One Exit in Array

        Dim strRoomMotion As String
        Dim nextRoom As Integer

        currentRoom = 0
        Do While currentRoom >= 0

            'introductions to the room

            Console.WriteLine("You are in the " & strMasterRoom(currentRoom, 0))
            Console.WriteLine(strMasterRoom(currentRoom, 1))
            Console.WriteLine()

            'player choice

            Console.WriteLine("what do you want to do: 0-move 1-inventory 2-explore")
            input = Console.ReadLine

            If input = 0 Then

                'this block will customize the room options. the user will always type sequentially starting from 0. the text will be as long as it needs to be for all options to appear
                strRoomMotion = "would you like to go to the " & strMasterRoom(strMasterRoom(currentRoom, 5), 0) & "(Option 0)"
                For inti = 1 To (strMasterRoom(currentRoom, 4) - 1)
                    strRoomMotion = strRoomMotion & " or the " & strMasterRoom(strMasterRoom(currentRoom, inti + 5), 0) & "(Option " & inti & ")"
                Next

                'outputs the text of the room options
                Console.WriteLine(strRoomMotion)

                'reads response and moves to correct room
                'in future consider better error trapping if there are secret rooms, locked rooms, and rooms with more exit possibilities
                nextRoom = Console.ReadLine
                If nextRoom = 0 Then
                    currentRoom = strMasterRoom(currentRoom, 5)
                ElseIf nextRoom = 1 Then
                    currentRoom = strMasterRoom(currentRoom, 6)
                ElseIf currentRoom = 2 Then
                    currentRoom = strMasterRoom(currentRoom, 7)
                Else

                    Console.WriteLine("Invalid Input")
                End If

            ElseIf input = 1 Then
                'inventory
            Else
                'explore
                Console.WriteLine(strMasterRoom(currentRoom, 3))

                'in future consider how this step changes other parts. does this add something to your inventory? open up another room option and if so how does it get added to list

            End If

        Loop

        Console.WriteLine("Bye for now!")
        Console.ReadKey()

    End Sub


End Module
