Imports System.Text.RegularExpressions

Module Main

    Private challengeDigitsNumber As String = Nothing


    Public Sub Main()

        Dim game As New HitAndBlowGame

        Console.WriteLine("HitAndBlowゲームを開始します。")

        challengeDigitsNumber = AskChallengeDigits()

        While True

            game.DisplayHitAndBlowGame(challengeDigitsNumber)

            Dim isJudgementinputValue As Boolean = IsJudgementReplayAnswer()

            If isJudgementinputValue Then

                If IsJudgementDigitsChangeAnswer() Then
                    challengeDigitsNumber = AskChallengeDigits()
                End If

                Continue While

            ElseIf isJudgementinputValue = False Then

                Exit Sub

            End If

        End While

    End Sub


    ''' <summary>
    ''' 挑戦桁数を変更するか聞き入力値を返す
    ''' </summary>
    ''' <returns>そのままの挑戦桁数か変更するかの入力値</returns>
    Private Function IsJudgementDigitsChangeAnswer() As Boolean

        While True

            Console.Write("挑戦桁数変更しますか？（Y/N)：")

            Dim inputAnswer As String = Console.ReadLine()

            If inputAnswer.ToUpper().Equals("Y") Then

                Return True

            ElseIf inputAnswer.ToUpper().Equals("N") Then

                Return False

            Else

                Console.WriteLine("入力内容が異なります。")

            End If

        End While

        Throw New InvalidOperationException

    End Function


    ''' <summary>
    ''' 挑戦桁数を聞く
    ''' </summary>
    ''' <returns>挑戦桁数</returns>
    Private Function AskChallengeDigits() As String

        Dim judgementInputValue As New InputValueValidator

        Dim inputDigitsNumber As String = Nothing

        While True

            Try

                Console.Write("挑戦桁数を入力して下さい(3～10)：")

                inputDigitsNumber = Console.ReadLine()

                If judgementInputValue.ValidateInputDigitsValue(inputDigitsNumber) Then

                    Exit While

                End If

            Catch ex As ArgumentException
                Console.WriteLine(ex.Message)
            End Try

        End While

        Return inputDigitsNumber

    End Function


    ''' <summary>
    ''' もう一度ゲームを遊ぶか聞き入力値を返す
    ''' </summary>
    ''' <returns>もう一度ゲームを遊ぶか辞めるかの入力値</returns>
    Private Function IsJudgementReplayAnswer() As Boolean

        While True

            Console.Write("もう一度遊びますか？(Y/N)：")

            Dim inputAnswer As String = Console.ReadLine()

            If inputAnswer.ToUpper().Equals("Y") Then

                Return True

            ElseIf inputAnswer.ToUpper().Equals("N") Then

                Return False

            Else

                Console.WriteLine("入力内容が異なります。")

            End If


        End While

        Throw New InvalidOperationException

    End Function

End Module
