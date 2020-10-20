Module Module1

    Dim myProduct As ProductStructureTypeLib.Product

    Sub Main()

        Dim myCATIA As INFITF.Application
        Try
            myCATIA = GetObject(, "CATIA.Application")
        Catch ex As Exception
            Console.WriteLine("Catia no está arrancado")
            Exit Sub
        End Try

        Dim myActiveDoc As ProductStructureTypeLib.ProductDocument = myCATIA.ActiveDocument
        Dim myproduct As ProductStructureTypeLib.Product = myActiveDoc.Product

        getHijos(myProduct.ReferenceProduct)

        Console.ReadKey()

    End Sub

    Sub getHijos(ByVal product As ProductStructureTypeLib.Product)
        For Each hijo As ProductStructureTypeLib.Product In product.Products
            Console.WriteLine(hijo.PartNumber)
            If hijo.PartNumber.Contains("ABS") Then
                StandardName(hijo)
            End If
            getHijos(hijo)
        Next
    End Sub

    Sub StandardName(ByVal pieza As ProductStructureTypeLib.Product)
        Console.WriteLine(pieza.PartNumber)
    End Sub

End Module
