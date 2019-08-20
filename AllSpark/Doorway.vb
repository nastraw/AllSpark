Public Class Doorway
    Public Sub New(roomA As Room, roomB As Room, description As String, lockedDescription As String, unlockCondition As String, locked As Boolean)
        Me.RoomA = roomA
        Me.RoomB = roomB
        Me.Description = description
        Me.LockedDescription = lockedDescription
        Me.UnlockCondition = unlockCondition
        Me.Locked = locked
    End Sub

    Public Description As String
    Public LockedDescription As String
    Public UnlockCondition As String
    Public Locked As Boolean
    Public RoomA As Room
    Public RoomB As Room

    Public Function strGetOtherRoomName(currentRoom As Room) As String
        If (currentRoom.Name = RoomA.Name) Then
            Return RoomB.Name
        End If

        Return RoomA.Name
    End Function

    Public Function roomGetOtherRoom(currentRoom As Room) As Room
        If (currentRoom.Name = RoomA.Name) Then
            Return RoomB
        End If

        Return RoomA
    End Function

End Class
