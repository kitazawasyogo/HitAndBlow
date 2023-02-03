Imports System.Text.RegularExpressions

Public Class HitAndBlowGame


    Private Const ARRAY_LENGTH_COUNT As Integer = 3


    ''' <summary>
    ''' 正解の4桁の数字を生成して返す
    ''' </summary>
    ''' <returns>正解の4桁の数字</returns>
    Public Function MakeCorrectValue() As Char()

        Const CORRECT_ARRAY_LENGTH As Integer = 4

        Dim random As New Random()

        Dim correctArray As Char() = {"0", "0", "0", "0"}

        Dim arrayIndex As Integer = 0

        While arrayIndex < CORRECT_ARRAY_LENGTH

            Dim randomValue As Integer = random.Next(0, 9)

            If Not correctArray.Contains(randomValue.ToString) Then

                correctArray(arrayIndex) = randomValue.ToString
                arrayIndex += 1

            End If

        End While

        Return correctArray

    End Function


    ''' <summary>
    ''' 指定した条件を満たすまで入力を求め入力値を配列に変換する
    ''' </summary>
    ''' <returns>入力値の配列</returns>
    Public Function GetInputValue() As Char()

        Dim inputNumber As Char() = {"0", "0", "0", "0"}

        While True

            Try

                Dim input As String = Console.ReadLine()
                ValidateInputValue(input)

                inputNumber = input.ToCharArray

                Return inputNumber

            Catch ex As ArgumentException
                Console.WriteLine(ex.Message)
                Console.Write("4桁の数字を入力して下さい：")
            End Try

        End While

        Return inputNumber

    End Function


    ''' <summary>
    ''' ヒット数を返す
    ''' </summary>
    ''' <param name="inputValue">入力された値</param>
    ''' <param name="correctValue">正解の値</param>
    ''' <returns>桁と値が一致している件数</returns>
    Public Function CountHitValue(inputValue As Char(), correctValue As Char()) As Integer

        Dim hit As Integer = 0

        For count As Integer = 0 To ARRAY_LENGTH_COUNT

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
    ''' <returns>ヒットした値を除外した配列</returns>
    Public Function MakeHitOtherValue(inputValue As Char(), correctValue As Char()) As Char()

        Dim hitOtherList As New List(Of Char)

        For arrayIndex As Integer = 0 To ARRAY_LENGTH_COUNT

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


    ''' <summary>
    ''' 入力値チェック
    ''' </summary>
    ''' <param name="inputValue">入力値</param>
    ''' <returns>入力値判定の真偽</returns>
    Public Function ValidateInputValue(inputValue As String) As Boolean


        If Not inputValue.Length.Equals(4) OrElse Not New Regex("^[0-9]{1,4}$").IsMatch(inputValue) Then

            Throw New ArgumentException("入力値が4桁の数字ではありません")

        End If

        Return True

    End Function

End Class