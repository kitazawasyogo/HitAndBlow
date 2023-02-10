Module Main

    Public Sub Main()

        Console.WriteLine("HitAndBlowゲームを開始します。")

        While True

            DisplayHitAndBlowGame()
            Console.Write("もう一度遊びますか？(Y/N)")

            Dim input As String = Console.ReadLine()

            If input.Equals("Y") Then

                Continue While

            ElseIf input.Equals("N") Then

                Exit Sub

            End If

        End While

        Console.ReadKey()

    End Sub


    ''' <summary>
    ''' ゲームの結果表示
    ''' </summary>
    Private Sub DisplayHitAndBlowGame()

        Dim game As New HitAndBlowGame
        Dim correctValue As Char() = game.MakeCorrectValue()

        Const GAME_CLEAR_COUNT As Integer = 4

        While True

            Dim inputValue As Char() = game.GetInputValue(correctValue)

            Dim hitOtherList As Char() = game.MakeHitOtherValue(inputValue, correctValue)

            Dim hitNumber As Integer = game.CountHitValue(inputValue, correctValue)
            Dim blowNumber As Integer = game.CountBlowValue(inputValue, hitOtherList)

            If hitNumber.Equals(GAME_CLEAR_COUNT) Then

                Console.WriteLine($"ヒット数：{hitNumber}！ゲームクリア！")
                Exit While

            Else

                Console.WriteLine($"ヒット数:{hitNumber}ブロー数：{blowNumber}")

            End If

        End While

    End Sub

End Module
