Module Main

    Public Sub Main()

        Console.Write("4桁の数字を入力して下さい：")

        Dim game As New HitAndBlowGame

        Dim inputValue As Char() = game.GetInputValue()
        Dim correctValue As Char() = game.MakeCorrectValue()

        Dim hitNumber As Integer = game.CountHitValue(inputValue, correctValue)

        Console.WriteLine("ヒット数:" & hitNumber)


        Console.ReadKey()

    End Sub

End Module
