Module Main

    Public Sub Main()

        Console.Write("4桁の数字を入力して下さい：")

        Dim game As New HitAndBlowGame

        Dim inputValue As Char() = game.GetInputValue()
        Dim correctValue As Char() = game.MakeCorrectValue()

        Dim hitNumber As Integer = game.CountHitValue(inputValue, correctValue)
        Dim blowNumber As Integer = game.CountBlowValue(inputValue, correctValue)

        Console.WriteLine("ヒット数:" & hitNumber & "ブロー数：" & blowNumber)


        Console.ReadKey()

    End Sub

End Module
