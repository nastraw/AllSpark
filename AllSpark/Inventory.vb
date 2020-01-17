Public Class Inventory
	Public Sub New(acquired As Boolean, itemname As String, itemdescription As String, ItemQuantity As Integer, itemplaced As Boolean)
		Me.Acquired = acquired
		Me.ItemName = itemname
		Me.ItemDescription = itemdescription
		Me.ItemQuantity = ItemQuantity
		Me.ItemPlaced = itemplaced

	End Sub

	Function getItemName() As String

		Return ItemName

	End Function


	Public Acquired As Boolean
    Public ItemName As String
    Public ItemDescription As String
    Public ItemQuantity As Integer
	Public ItemPlaced As Boolean
End Class
