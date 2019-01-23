' ReSharper disable InconsistentNaming

Public Class Form2

    Public Event OnWindowSizeChanged()

    Public Sub LogLicensing(message As String)

        If cbLicensing.Checked Then
            mmError.Text = mmError.Text + "LICENSING:" + Environment.NewLine + message + Environment.NewLine
        End If

    End Sub

    Public Sub Log(message As String)

        If cbLicensing.Checked Then
            mmError.Text = mmError.Text + message + Environment.NewLine
        End If

    End Sub

    Public ReadOnly Property Screen() As Control
	Get
	    Return pnScreen
	End Get
    End Property

    Private Sub Form2_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        RaiseEvent OnWindowSizeChanged
    End Sub
End Class

' ReSharper restore InconsistentNaming