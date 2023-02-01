Public Class HitAndBlowGame


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


End Class