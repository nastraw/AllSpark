Module Module1

	Sub Main()

        Dim firstRoom As Room = New Room("first room")
        Dim secondRoom As Room = New Room("the library")
        Dim thirdRoom As Room = New Room("the billiards room")
        Dim interror As Integer
        Dim currentRoom As Integer = 0
        Dim input As Integer

        Do While currentRoom >= 0

            Console.WriteLine("what do you want to do: 0-move 1-inventory 2-explore")
            input = Console.ReadLine

            If input = 0 Then
                Console.WriteLine("choose your path: 0-first room 1-library 2-billiards room")

                interror = currentRoom
                currentRoom = Console.ReadLine
                If currentRoom = 0 Then
                    firstRoom.DisplayDescription()
                ElseIf currentRoom = 1 Then
                    secondRoom.DisplayDescription()
                ElseIf currentRoom = 2 Then
                    thirdRoom.DisplayDescription()
                ElseIf currentRoom < 0 Then
                    Exit Do
                Else
                    Console.WriteLine("Invalid input")
                    currentRoom = interror
                End If
            ElseIf input = 1 Then
                'inventory
            Else
                'explore

            End If

        Loop

        Console.WriteLine("Bye for now!")

        Console.ReadKey()

    End Sub


End Module
