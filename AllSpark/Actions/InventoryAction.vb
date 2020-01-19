Imports AllSpark

Public Class InventoryAction
	Inherits Action
	Private strItemList As String

	Public Sub New()
		Name = "inventory"
	End Sub

    Public Overrides Sub DoAction(ByRef currentRoom As Room, inventoryList() As Inventory, doorwayList() As Doorway, encounterlist() As Encounters)
        strItemList = "You currently possess: "
        For inti = 0 To inventoryList.Length - 1

            Dim currentItem = inventoryList(inti)
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
End Class
