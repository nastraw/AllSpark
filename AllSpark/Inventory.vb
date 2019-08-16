Public Class Inventory
    Public Sub New(acquired As Boolean, itemname As String, itemdescription As String, ItemQuantity As Integer)
        Me.Acquired = acquired
        Me.ItemName = itemname
        Me.ItemDescription = itemdescription
        Me.ItemQuantity = ItemQuantity
    End Sub

    Public Acquired As Boolean
    Public ItemName As String
    Public ItemDescription As String
    Public ItemQuantity As Integer

End Class
