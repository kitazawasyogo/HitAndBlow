Imports System.Text.RegularExpressions

''' <summary>
''' 入力値を検証する
''' </summary>
Public Class InputValueValidator


    ''' <summary>
    ''' 挑戦桁数入力値チェック
    ''' </summary>
    ''' <param name="input">挑戦桁数入力値</param>
    ''' <returns>想定内の値かどうか</returns>
    Public Function ValidateInputDigitsValue(input As String) As Boolean

        If Not New Regex("^[0-9]+$").IsMatch(input) Then

            Throw New ArgumentException("数字以外が入力されています。")

        ElseIf Integer.Parse(input) < 3 OrElse 10 < Integer.Parse(input) Then

            Throw New ArgumentException("範囲外です。")

        End If

        Return True

    End Function


    ''' <summary>
    ''' 入力値チェック
    ''' </summary>
    ''' <param name="inputValue">入力値</param>
    ''' <returns>入力値判定の真偽</returns>
    Public Function ValidateInputValue(inputValue As String, digitsNumber As String) As Boolean

        Dim displayDigitsNumber As Integer = Integer.Parse(digitsNumber)

        If Not inputValue.Length.Equals(displayDigitsNumber) OrElse Not New Regex("^[0-9]+$").IsMatch(inputValue) Then

            Throw New ArgumentException($"入力値が{digitsNumber}桁の数字ではありません")

        End If

        Return True

    End Function
End Class
