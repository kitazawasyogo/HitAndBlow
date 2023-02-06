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

End Class

