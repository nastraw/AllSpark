Module Module1
    Dim currentRoom As Room
    Dim input As Integer
    Dim doorways(6) As Doorway
    Dim rooms(5) As Room
    Dim strRoomMotion As String
    Dim nextRoom As Integer
    Dim INVENTORYMAX As Integer = 4
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

            Console.WriteLine("What do you want to do: 1-move 2-inventory 3-explore")
            input = Val(Console.ReadLine)
            If input = 1 Then
                Movement()
            ElseIf input = 2 Then
                Backpack()
            ElseIf input = 3 Then
                Exploration()
            Else
                Console.WriteLine("Invalid")
            End If
        Loop
        Console.WriteLine("Bye for now!")
        Console.ReadKey()
    End Sub

    Public Sub Creation()
        rooms(0) = New Room("The Study", "This is where procrastinating is done.", "You explore and find ", "The Candlestick") ' 1, 2, 3
        rooms(1) = New Room("The Library", "Where wild books make their nest.", "You explore and find  ", "The Steel Key") ' 0, 2
        rooms(2) = New Room("The Billiards Room", "This has a pool table, not to be confused with a table inside of a pool.", "You explore and find ", "a Secret Exit") ' 0, 1, 3
        rooms(3) = New Room("The Ballroom", "Sadly, not a ballpit.", "You reached the exit.", "") ' 0, 2
        rooms(4) = New Room("The Kitchen", "Help yourself to the fridge", "You explore and find", "The Iron Key")
        rooms(5) = New Room("LOCKED EXIT", "This is the end", "You explore and find", "The Lead Pipe")

        doorways(0) = New Doorway(rooms(0), rooms(1), "A door", Nothing, Nothing, False) ' study to library
        doorways(1) = New Doorway(rooms(0), rooms(2), "A door", Nothing, Nothing, False) ' study to billiards
        doorways(2) = New Doorway(rooms(0), rooms(3), "A door", "The Steel Door is Locked", "The Steel Key", True) ' study to ballroom - secret passage
        doorways(3) = New Doorway(rooms(1), rooms(2), "A door", Nothing, Nothing, False) ' library to billiards
        doorways(4) = New Doorway(rooms(2), rooms(3), "A door", Nothing, Nothing, False) ' billiards to ballroom
        doorways(5) = New Doorway(rooms(0), rooms(4), "A cool door", Nothing, Nothing, False)
        doorways(6) = New Doorway(rooms(4), rooms(5), "A locked Door", "The Iron Door is Locked", "The Iron Key", True)

        ReDim rooms(0).Doorways(3) ' study
        rooms(0).Doorways(0) = doorways(0)
        rooms(0).Doorways(1) = doorways(1)
        rooms(0).Doorways(2) = doorways(2)
        rooms(0).Doorways(3) = doorways(5)

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

        ReDim rooms(4).Doorways(0)
        rooms(4).Doorways(0) = doorways(6)

        currentRoom = rooms(0)

        inventory(0) = New Inventory(False, "The Lead Pipe", "A blunt weapon", 1)
        inventory(1) = New Inventory(False, "The Wrench", "Handy for plumbing", 1)
        inventory(2) = New Inventory(False, "The Candlestick", "Good for mood lighting", 1)
        inventory(3) = New Inventory(False, "The Iron Key", "Are you the keymaster?", 1)
        inventory(4) = New Inventory(False, "The Steel Key", "Are you the keymaster?", 1)
    End Sub

    Public Sub Movement()
        strRoomMotion = "Move: Would you like to go to the " & currentRoom.Doorways(0).strGetOtherRoomName(currentRoom) & "(Option 1)"
        For inti = 1 To (currentRoom.Doorways.Count - 1)
            strRoomMotion = strRoomMotion & " or the " & currentRoom.Doorways(inti).strGetOtherRoomName(currentRoom) & "(Option " & (inti + 1) & ")"
        Next

        Console.WriteLine(strRoomMotion)
        nextRoom = Val(Console.ReadLine)

        If nextRoom = 0 Then
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

        If currentRoom.Name = "LOCKED EXIT" Then
            Console.WriteLine(currentRoom.Description)
            currentRoom = Nothing
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
            For intj = 0 To INVENTORYMAX
                currentItem = inventory(intj)
                If currentRoom.hiddenitem = currentItem.ItemName Then
                    currentItem.Acquired = True
                    Console.WriteLine(currentItem.ItemDescription)
                    currentRoom.ExploreText = ""
                    currentRoom.hiddenitem = "None"
                End If
            Next
        Else
            Console.WriteLine("There is nothing to be found")
        End If
    End Sub
End Module
