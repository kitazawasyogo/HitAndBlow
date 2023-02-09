Imports HitAndBlow
Imports NUnit.Framework

Public Class HitAndBlowGameTest

    Private gameTest As New HitAndBlowGame

    <Test()> Public Sub 正解の値の桁数()

        Dim actual As Char() = gameTest.MakeCorrectValue()

        Assert.That(actual.Count, [Is].EqualTo(4))

    End Sub

    <Test()> Public Sub 正解の値が数字であるか()

        Dim actual As Char() = gameTest.MakeCorrectValue()

        Assert.IsTrue(IsNumeric(String.Join(",", actual)))

    End Sub

    <Test()> Public Sub 正解の値に重複がないか()

        Dim actualArray As Char() = gameTest.MakeCorrectValue()

        Dim actualList As IEnumerable(Of Char) = actualArray.Distinct()
        Dim actual As List(Of Char) = actualList.ToList()

        Assert.That(actual.Count, [Is].EqualTo(4))

    End Sub

    <Test()> Public Sub ヒット数を返すメソッドが正しい値を返すか()

        Dim correct As Char() = {"0", "1", "2", "3"}
        Dim input As Char() = {"0", "1", "5", "3"}


        Dim actual As Integer = gameTest.CountHitValue(correct, input)

        Assert.That(actual, [Is].EqualTo(3))

    End Sub

    <Test()> Public Sub ヒットした値を除外した配列をかえす()

        Dim correct As Char() = {"0", "1", "2", "3"}
        Dim input As Char() = {"0", "5", "5", "3"}


        Dim actual As Char() = gameTest.MakeHitOtherValue(correct, input)

        Assert.That(actual.Length, [Is].EqualTo(2))

    End Sub

    <Test()> Public Sub ブロー数を返すメソッドが正しい値を返すか()

        Dim correct As Char() = {"0", "1", "2", "3"}
        Dim input As Char() = {"6", "3", "5", "1"}


        Dim actual As Integer = gameTest.CountBlowValue(correct, input)

        Assert.That(actual, [Is].EqualTo(2))

    End Sub

    <Test()> Public Sub 入力値の桁数が範囲外の場合例外を投げる()

        Dim inputTestValue As String = "123456789"

        Try

            gameTest.ValidateInputValue(inputTestValue)
            Assert.Fail()

        Catch ex As ArgumentException
            Assert.That(ex.Message, [Is].EqualTo("入力値が4桁の数字ではありません"))
        End Try

    End Sub

    <Test()> Public Sub 入力値が数字でない場合例外を投げる()

        Dim inputTestValue As String = "あいうえ"

        Try

            gameTest.ValidateInputValue(inputTestValue)
            Assert.Fail()

        Catch ex As ArgumentException
            Assert.That(ex.Message, [Is].EqualTo("入力値が4桁の数字ではありません"))
        End Try

    End Sub

    <Test()> Public Sub 入力値に小数点が含まれる場合例外を投げる()

        Dim inputTestValue As String = "1.45"

        Try

            gameTest.ValidateInputValue(inputTestValue)
            Assert.Fail()

        Catch ex As ArgumentException
            Assert.That(ex.Message, [Is].EqualTo("入力値が4桁の数字ではありません"))
        End Try

    End Sub

    <Test()> Public Sub 入力値に負符号が含まれる場合例外を投げる()

        Dim inputTestValue As String = "-123"

        Try

            gameTest.ValidateInputValue(inputTestValue)
            Assert.Fail()

        Catch ex As ArgumentException
            Assert.That(ex.Message, [Is].EqualTo("入力値が4桁の数字ではありません"))
        End Try

    End Sub

End Class

