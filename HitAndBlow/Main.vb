Module Main

    Public Sub Main()

        Console.WriteLine("HitAndBlowゲームを開始します。")

        While True

            DisplayHitAndBlowGame()

            Dim inputValue As String = IsJudgementReplayAnswer()

            If inputValue = True Then

                Continue While

            ElseIf inputValue = False Then

                Exit Sub

            End If

        End While


    End Sub


    ''' <summary>
    ''' もう一度ゲームを遊ぶか聞き入力値を返す
    ''' </summary>
    ''' <returns>もう一度ゲームを遊ぶか辞めるかの入力値</returns>
    Private Function IsJudgementReplayAnswer() As Boolean

        While True

            Console.Write("もう一度遊びますか？(Y/N)：")

            Dim inputAnswer As String = Console.ReadLine()

            If inputAnswer.Equals("Y") Then

                Return True

            ElseIf inputAnswer.Equals("N") Then

                Return False

            Else

                Console.WriteLine("入力内容が異なります。")

            End If


        End While

        Throw New InvalidOperationException

    End Function


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
