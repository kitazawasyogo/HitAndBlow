Imports HitAndBlow
Imports NUnit.Framework


Public Class InputValueValidatorTest

    Private judgementTest As New InputValueValidator

    <TestCase("123456789", "4")>
    <TestCase("123456789", "10")>
    Public Sub 入力値の桁数が範囲外の場合例外を投げる(inputTestValue As String, inputDigitsValue As String)

        Try

            judgementTest.ValidateInputValue(inputTestValue, inputDigitsValue)
            Assert.Fail()

        Catch ex As ArgumentException
            Assert.That(ex.Message, [Is].EqualTo($"入力値が{inputDigitsValue}桁の数字ではありません"))
        End Try

    End Sub

    <TestCase("あいうえ", "4")>
    <TestCase("かきくけ", "9")>
    Public Sub 入力値が数字でない場合例外を投げる(inputTestValue As String, inputDigitsValue As String)

        Try

            judgementTest.ValidateInputValue(inputTestValue, inputDigitsValue)
            Assert.Fail()

        Catch ex As ArgumentException
            Assert.That(ex.Message, [Is].EqualTo(＄"入力値が{inputDigitsValue}桁の数字ではありません"))
        End Try

    End Sub

    <TestCase("1.45", "4")>
    <TestCase("15.3", "8")>
    Public Sub 入力値に小数点が含まれる場合例外を投げる(inputTestValue As String, inputDigitsValue As String)

        Try

            judgementTest.ValidateInputValue(inputTestValue, inputDigitsValue)
            Assert.Fail()

        Catch ex As ArgumentException
            Assert.That(ex.Message, [Is].EqualTo($"入力値が{inputDigitsValue}桁の数字ではありません"))
        End Try

    End Sub

    <TestCase("-123", "4")>
    <TestCase("-567", "7")>
    Public Sub 入力値に負符号が含まれる場合例外を投げる(inputTestValue As String, inputDigitsValue As String)

        Try

            judgementTest.ValidateInputValue(inputTestValue, inputDigitsValue)
            Assert.Fail()

        Catch ex As ArgumentException
            Assert.That(ex.Message, [Is].EqualTo($"入力値が{inputDigitsValue}桁の数字ではありません"))
        End Try

    End Sub

    <TestCase("123456", "6")>
    <TestCase("0123456789", "10")>
    Public Sub 入力値が範囲内の場合Trueを返す(inputTestValue As String, inputDigitsValue As String)

        Dim actual As Boolean = judgementTest.ValidateInputValue(inputTestValue, inputDigitsValue)

        Assert.That(actual, [Is].EqualTo(True))

    End Sub

    <Test()> Public Sub 挑戦桁数の入力値が数字以外の場合例外を投げる()

        Dim inputTestValue As String = "A"

        Try

            judgementTest.ValidateInputDigitsValue(inputTestValue)
            Assert.Fail()

        Catch ex As ArgumentException
            Assert.That(ex.Message, [Is].EqualTo("数字以外が入力されています。"))
        End Try

    End Sub

    <Test()> Public Sub 挑戦桁数の入力値が範囲外の場合例外を投げる()

        Dim inputTestValue As String = "2"

        Try

            judgementTest.ValidateInputDigitsValue(inputTestValue)
            Assert.Fail()

        Catch ex As ArgumentException
            Assert.That(ex.Message, [Is].EqualTo("範囲外です。"))
        End Try

    End Sub

    <TestCase("6")>
    <TestCase("10")>
    Public Sub 挑戦桁数の入力値が範囲内の場合Trueを返す(inputTestValue As String)

        Dim actual As Boolean = judgementTest.ValidateInputDigitsValue(inputTestValue)

        Assert.That(actual, [Is].EqualTo(True))

    End Sub

End Class
