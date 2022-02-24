Public Class Form1
    'reading input from  buttons'
    Private Sub button_click(sender As Object, e As EventArgs) Handles subt.Click, numdecimal.Click, num9.Click, num8.Click, num7.Click, num6.Click, num5.Click, num4.Click, num3.Click, num2.Click, num1.Click, num0.Click, mult.Click, modulas.Click, div.Click, clear.Click, calc.Click, backspace.Click, addd.Click
        Dim button As Button = CType(sender, Button)
        If (display.Text.Length < 20) Then
            If button.Name = "num1" Then
                display.Text = display.Text + "1"
            End If
            If button.Name = "num2" Then
                display.Text = display.Text + "2"
            End If
            If button.Name = "num3" Then
                display.Text = display.Text + "3"
            End If
            If button.Name = "num4" Then
                display.Text = display.Text + "4"
            End If
            If button.Name = "num5" Then
                display.Text = display.Text + "5"
            End If
            If button.Name = "num6" Then
                display.Text = display.Text + "6"
            End If
            If button.Name = "num7" Then
                display.Text = display.Text + "7"
            End If
            If button.Name = "num8" Then
                display.Text = display.Text + "8"
            End If
            If button.Name = "num9" Then
                display.Text = display.Text + "9"
            End If
            If button.Name = "num0" Then
                display.Text = display.Text + "0"
            End If
            If button.Name = "numdecimal" Then
                display.Text = display.Text + "."
            End If
        End If

        If button.Name = "addd" Then
            display.Text = display.Text + "+"
        End If
        If button.Name = "subt" Then
            display.Text = display.Text + "-"
        End If
        If button.Name = "mult" Then
            display.Text = display.Text + "*"
        End If
        If button.Name = "div" Then
            display.Text = display.Text + "/"
        End If
        If button.Name = "modulas" Then
            display.Text = display.Text + "%"
        End If
        If button.Name = "clear" Then
            display.Text = ""
        End If
        If button.Name = "backspace" Then
            If display.Text.Length > 0 Then
                display.Text = display.Text.Remove(display.Text.Length - 1, 1)
            End If
            If display.Text = "" Then
                display.Text = "0"
            End If
        End If
        If button.Name = "calc" Then
            Dim equation As String = display.Text
            Try
                Dim result = New DataTable().Compute(equation, Nothing)
                If Double.IsInfinity(result) Or Double.IsNaN(result) Then
                    display.Text = "Divide by zero error "
                ElseIf display.Text.Length > 20 Then
                    display.Text = "Too long to calculate"
                Else
                    display.Text = result.ToString.TrimEnd("0").TrimEnd(".")
                End If
            Catch ex As Exception
                MsgBox("Invalid expression")
            End Try
        End If
    End Sub

    'To take only numbers and operators as input'
    Private Sub display_keypress(sender As Object, e As KeyPressEventArgs) Handles display.KeyPress
        number_only(e)
    End Sub
    Private Sub number_only(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 43 Or Asc(e.KeyChar) = 45 Or Asc(e.KeyChar) = 42 Or Asc(e.KeyChar) = 47 Then
            '(Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 //allow numbers
            'Asc(e.KeyChar) = 46 //allow dot operator
            'Asc(e.KeyChar) = 43,45,42,47 //allow +-*/ respectively
            'Asc(e.KeyChar) = 8 //allow backspace
            'Asc(e.KeyChar) = 13 //allow enter'
        Else
            e.Handled = True
            MsgBox("Not a valid input type")
        End If
    End Sub

    Private Sub display_TextChanged(sender As Object, e As KeyPressEventArgs) Handles display.KeyPress
        If e.KeyChar = "=" Or e.KeyChar = Convert.ToChar(13) Then
            e.KeyChar = ""
            Try
                Dim equation As String = display.Text
                Dim result = New DataTable().Compute(equation, Nothing)
                If Double.IsInfinity(result) Or Double.IsNaN(result) Then
                    display.Text = "Divide by zero error "
                ElseIf display.Text.Length > 20 Then
                    display.Text = "Too long to calculate"
                Else
                    display.Text = result.ToString.TrimEnd("0").TrimEnd(".")
                End If
            Catch ex As Exception
                MsgBox("Invalid expression")
            End Try

        End If
    End Sub
End Class
