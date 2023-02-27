Imports HitAndBlow
Imports NUnit.Framework


Public Class HitAndBlowGameTest

    Private gameTest As New HitAndBlowGame

    <TestCase("4")>
    <TestCase("8")>
    Public Sub 正解の値の桁数が入力された挑戦桁数になっているか(inputDigitsValue As String)

        Dim actual As Char() = gameTest.MakeCorrectValue(inputDigitsValue)

        Dim inputDigitsValueTest As Integer = Integer.Parse(inputDigitsValue)

        Assert.That(actual.Count, [Is].EqualTo(inputDigitsValueTest))

    End Sub

    <TestCase("4")>
    <TestCase("7")>
    Public Sub 正解の値が数字であるか(inputDigitsValue As String)

        Dim actual As Char() = gameTest.MakeCorrectValue(inputDigitsValue)

        Assert.IsTrue(IsNumeric(String.Join(",", actual)))

    End Sub

    <TestCase("4")>
    <TestCase("7")>
    Public Sub 正解の値に重複がないか(inputDigitsValue As String)

        Dim actualArray As Char() = gameTest.MakeCorrectValue(inputDigitsValue)

        Dim actualList As IEnumerable(Of Char) = actualArray.Distinct()
        Dim actual As List(Of Char) = actualList.ToList()

        Dim inputDigitsValueTest As Integer = Integer.Parse(inputDigitsValue)

        Assert.That(actual.Count, [Is].EqualTo(inputDigitsValueTest))

    End Sub

    <TestCase({"0"c, "1"c, "2"c, "3"c}, {"0"c, "1"c, "5"c, "3"c}, "4")>
    <TestCase({"0"c, "1"c, "2"c, "3"c, "6"c}, {"0"c, "1"c, "5"c, "3"c, "9"c}, "5")>
    Public Sub ヒット数を返すメソッドが正しい値を返すか(correct As Char(), input As Char(), inputDigitsValue As String)

        Dim actual As Integer = gameTest.CountHitValue(correct, input, inputDigitsValue)

        Assert.That(actual, [Is].EqualTo(3))

    End Sub

    <TestCase({"0"c, "1"c, "2"c, "3"c}, {"0"c, "5"c, "5"c, "3"c}, "4")>
    <TestCase({"0"c, "1"c, "2"c, "3"c, "6"c}, {"0"c, "1"c, "5"c, "3"c, "9"c}, "5")>
    Public Sub ヒットした値を除外した配列をかえす(correct As Char(), input As Char(), inputDigitsValue As String)


        Dim actual As Char() = gameTest.MakeHitOtherValue(correct, input, inputDigitsValue)

        Assert.That(actual.Length, [Is].EqualTo(2))

    End Sub

    <Test()> Public Sub ブロー数を返すメソッドが正しい値を返すか()

        Dim correct As Char() = {"0", "1", "2", "3"}
        Dim input As Char() = {"6", "3", "5", "1"}


        Dim actual As Integer = gameTest.CountBlowValue(correct, input)

        Assert.That(actual, [Is].EqualTo(2))

    End Sub

    <Test()> Public Sub ギブアップの入力値が文字列一致で全て大文字だった場合Trueを返す()

        Dim inputTestValue As String = "GIVEUP"

        Dim actual As Boolean = gameTest.IsGiveupHitAndBlowGame(inputTestValue)

        Assert.That(actual, [Is].EqualTo(True))

    End Sub

    <Test()> Public Sub ギブアップの入力値が文字列一致で全て小文字だった場合Trueを返す()

        Dim inputTestValue As String = "giveup"

        Dim actual As Boolean = gameTest.IsGiveupHitAndBlowGame(inputTestValue)

        Assert.That(actual, [Is].EqualTo(True))

    End Sub

    <Test()> Public Sub ギブアップの入力値が文字列一致で小文字大文字混在だった場合Trueを返す()

        Dim inputTestValue As String = "GiVeUp"

        Dim actual As Boolean = gameTest.IsGiveupHitAndBlowGame(inputTestValue)

        Assert.That(actual, [Is].EqualTo(True))

    End Sub

    <Test()> Public Sub ギブアップの入力値が文字列不一致だった場合Falseを返す()

        Dim inputTestValue As String = "Gibeuo"

        Dim actual As Boolean = gameTest.IsGiveupHitAndBlowGame(inputTestValue)

        Assert.That(actual, [Is].EqualTo(False))

    End Sub

End Class

