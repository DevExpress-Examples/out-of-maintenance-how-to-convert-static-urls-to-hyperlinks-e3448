Imports System
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.Model
Imports System.Collections.Generic

Namespace RichEditConvertStaticUrlsToHyperlinks
    Partial Public Class Form1
        Inherits Form

        Private Shared urlRegex As New Regex("((?:[a-z][\w-]+:(?:/{1,3}|[a-z0-9%])|www\d{0,3}[.]|ftp[.]|[a-z0-9.\-]+[.][a-z]{2,4}/)(?:[^\s()<>]+|\(([^\s()<>]+|(\([^\s()<>]+\)))*\))+(?:\(([^\s()<>]+|(\([^\s()<>]+\)))*\)|[^\s`!()\[\]{};:'"".,<>?«»“”‘’]))",
                                             RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            Dim path As String = System.IO.Directory.GetCurrentDirectory() & "\..\..\test.rtf"
            richEditControl1.LoadDocument(path)
        End Sub

        Private Sub richEditControl1_DocumentLoaded(ByVal sender As Object, ByVal e As EventArgs) Handles richEditControl1.DocumentLoaded
            CreateHyperlinks()
        End Sub

        Private Sub CreateHyperlink(ByVal range As DocumentRange)
            If RangeHasHyperlink(range) Then
                Return
            End If

            Dim doc As Document = richEditControl1.Document
            Dim hyperlink As Hyperlink = doc.Hyperlinks.Create(range)
            hyperlink.NavigateUri = doc.GetText(hyperlink.Range)
        End Sub
        Private Function IsValidUri(ByVal result As IRegexSearchResult) As Boolean
            Try
                Return result.FindNext()
            Catch e1 As RegexMatchTimeoutException
                Return False
            End Try
        End Function
        Private Sub CreateHyperlinks()
            Dim doc As Document = richEditControl1.Document

            doc.BeginUpdate()
            Dim result As IRegexSearchResult
            result = doc.StartSearch(urlRegex)
            Do While IsValidUri(result)
                Dim wordRange As DocumentRange = result.CurrentResult
                If (Not RangeHasHyperlink(wordRange)) Then
                    CreateHyperlink(wordRange)
                End If
            Loop

            doc.EndUpdate()
        End Sub



        Private Function RangeHasHyperlink(ByVal documentRange As DocumentRange) As Boolean
            For Each h As Hyperlink In richEditControl1.Document.Hyperlinks
                If documentRange.Contains(h.Range.Start) Then
                    Return True
                End If
            Next h

            Return False
        End Function
    End Class
End Namespace