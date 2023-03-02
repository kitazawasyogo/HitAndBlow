Imports System.Text.RegularExpressions

''' <summary>
''' HitAndBlowゲーム
''' </summary>
Public Class HitAndBlowGame

    Private isExitHitAndBlow As Boolean = False


    ''' <summary>
    ''' 一ゲームを終了するか判断する
    ''' </summary>
    ''' <returns>一ゲームを終了するか判断する値</returns>
    Public ReadOnly Property IsExitGame() As Boolean

        Get
            Return isExitHitAndBlow
        End Get

    End Property


    ''' <summary>
    ''' 何手かかったか数える
    ''' </summary>
    ''' <returns>何手かかったか数えた値</returns>
    Public ReadOnly Property CountInputNumber As Integer = 0


    ''' <summary>
    ''' 正解の数字を生成して返す
    ''' </summary>
    ''' <param name="inputDigitsValue">挑戦桁数</param>
    ''' <returns>正解の数字</returns>
    Public Function MakeCorrectValue(inputDigitsValue As String) As Char()

        Dim digitsNumber As Integer = Integer.Parse(inputDigitsValue)

        Dim correctArray As Char() = Enumerable.Range(3, digitsNumber).Select(Function(i) "A"c).ToArray

        Dim arrayIndex As Integer = 0

        Dim arrayMaxLength As Integer = digitsNumber - 1

        Dim random As New Random()

        While arrayIndex <= arrayMaxLength

            Dim randomValue As Integer = random.Next(10)

            Dim randomCorrectValie As String = randomValue.ToString

            If Not correctArray.Contains(Char.Parse(randomCorrectValie)) Then

                correctArray(arrayIndex) = Char.Parse(randomCorrectValie)
                arrayIndex += 1

            End If

        End While

        Return correctArray

    End Function

    ''' <summary>
    ''' 指定した条件を満たすまで入力を求める
    ''' </summary>
    ''' <param name="correctArray">>正解の値</param>
    ''' <param name="displayDigitsNumber">挑戦桁数</param>
    ''' <returns>入力値の配列</returns>
    Public Function GetInputValue(correctArray As Char(), displayDigitsNumber As String) As Char()

        Dim judgementInputValue As New InputValueValidator

        Dim count As Integer = 10

        Dim inputNumber As Char() = Enumerable.Range(3, count).Select(Function(i) "0"c).ToArray

        While True

            Try

                Console.Write($"{displayDigitsNumber}桁の数字を入力して下さい：")

                Dim input As String = Console.ReadLine()

                Dim isExit As Boolean = False

                isExit = IsGiveupHitAndBlowGame(input)

                If input.Equals("ShowAnswer") Then

                    ShowAnswer(correctArray)
                    Continue While

                ElseIf isExit = True Then

                    Console.Write($"正解の{displayDigitsNumber}桁の数字はこちらでした：")
                    ShowAnswer(correctArray)
                    isExitHitAndBlow = True
                    Exit While

                Else

                    judgementInputValue.ValidateInputValue(input, displayDigitsNumber)

                End If

                _CountInputNumber += 1

                inputNumber = input.ToCharArray

                Return inputNumber

            Catch ex As ArgumentException
                Console.WriteLine(ex.Message)
            End Try

        End While

        Return inputNumber

    End Function

    ''' <summary>
    ''' 入力値がギブアップであるか判定し返す
    ''' </summary>
    ''' <param name="inputValue">ギブアップの入力値</param>
    ''' <returns>入力値がギブアップであるか</returns>
    Public Function IsGiveupHitAndBlowGame(inputValue As String) As Boolean

        Return inputValue.ToLower().Equals("giveup")

    End Function


    ''' <summary>
    ''' 答えを表示
    ''' </summary>
    ''' <param name="correct">>正解の値</param>
    Private Sub ShowAnswer(correct As Char())

        Dim displayAnswer As String = String.Join(",", correct)

        Console.WriteLine(displayAnswer)

    End Sub


    ''' <summary>
    ''' ヒット数を返す
    ''' </summary>
    ''' <param name="inputValue">入力された値</param>
    ''' <param name="correctValue">正解の値</param>
    ''' <returns>桁と値が一致している件数</returns>
    Public Function CountHitValue(inputValue As Char(), correctValue As Char(), digitsNumber As String) As Integer

        Dim hit As Integer = 0

        Dim arrayMaxLength As Integer = Integer.Parse(digitsNumber) - 1

        For count As Integer = 0 To arrayMaxLength

            If inputValue(count).Equals(correctValue(count)) Then
                hit += 1
            End If
        Next

        Return hit

    End Function


    ''' <summary>
    ''' ヒットした値を除外した配列を返す
    ''' </summary>
    ''' <param name="inputValue">入力された値</param>
    ''' <param name="correctValue">正解の値</param>
    ''' <param name="digits">挑戦桁数</param>
    ''' <returns>ヒットした値を除外した配列</returns>
    Public Function MakeHitOtherValue(inputValue As Char(), correctValue As Char(), digits As String) As Char()

        Dim hitOtherList As New List(Of Char)

        Dim arrayMaxIndex As Integer = Integer.Parse(digits) - 1

        For arrayIndex As Integer = 0 To arrayMaxIndex

            If Not inputValue(arrayIndex).Equals(correctValue(arrayIndex)) Then
                hitOtherList.Add(correctValue(arrayIndex))
            End If
        Next

        Dim hitOtherArray As Char() = hitOtherList.ToArray

        Return hitOtherArray

    End Function


    ''' <summary>
    ''' ブロー数を返す
    ''' </summary>
    ''' <param name="inputValue">入力された値</param>
    ''' <param name="correctValue">正解の値</param>
    ''' <returns>値が一致している件数</returns>
    Public Function CountBlowValue(inputValue As Char(), correctValue As Char()) As Integer

        Dim blow As Integer = 0

        For arrayIndex As Integer = 0 To correctValue.Length - 1

            If inputValue.Contains(correctValue(arrayIndex)) Then

                blow += 1

            End If

        Next

        Return blow

    End Function

End Class