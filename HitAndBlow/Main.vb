Module Main

    Public Sub Main()

        Dim game As New HitAndBlowGame
        Dim correctValue As Char() = game.MakeCorrectValue()

        Const GAME_CLEAR_COUNT As Integer = 4

        While True

            Console.Write("4桁の数字を入力して下さい：")

            Dim inputValue As Char() = game.GetInputValue()

            Dim hitNumber As Integer = game.CountHitValue(inputValue, correctValue)
            Dim blowNumber As Integer = game.CountBlowValue(inputValue, correctValue)

            If hitNumber.Equals(GAME_CLEAR_COUNT) Then

                Console.WriteLine($"ヒット数：{hitNumber}！ゲームクリア！")
                Exit While

            Else

                Console.WriteLine($"ヒット数:{hitNumber}ブロー数：{blowNumber}")

            End If

        End While

        Console.ReadKey()

    End Sub

End Module
