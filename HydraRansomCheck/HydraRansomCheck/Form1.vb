Imports System.Threading
Imports System.IO

Partial Class Form1
    Inherits Form

    Private selectedPath As String
    Private scanResults As New List(Of String)()
    Private scanThread As Thread
    Private isPaused As Boolean = False
    Private isStopped As Boolean = False
    Private pauseLock As New Object()
    Private pauseEvent As New ManualResetEvent(True)

    ' Counter for total files scanned
    Private totalFilesScanned As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblStatus.Text = "Status: Idle"
        btnSave.Enabled = False ' Initially disable the save button
    End Sub

    Private Sub BtnSelectFile_Click(sender As Object, e As EventArgs) Handles btnSelectFile.Click
        Using folderDialog As New FolderBrowserDialog()
            If folderDialog.ShowDialog() = DialogResult.OK Then
                selectedPath = folderDialog.SelectedPath
                lblStatus.Text = "Status: Ready to Scan"
            End If
        End Using
    End Sub

    Private Sub BtnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        If String.IsNullOrEmpty(selectedPath) Then
            MessageBox.Show("Please select a directory or file to scan.", "Error")
            Return
        End If

        isStopped = False
        isPaused = False
        btnPause.Enabled = True
        btnStop.Enabled = True
        btnScan.Enabled = False
        btnSave.Enabled = False ' Disable save button during scanning
        scanResults.Clear()
        lstResults.Items.Clear()
        lblStatus.Text = "Status: Scanning..."
        totalFilesScanned = 0 ' Reset the counter for each scan
        lblTotalFiles.Text = "Total Files Scanned: 0" ' Reset the label

        scanThread = New Thread(AddressOf ScanFiles)
        scanThread.Start(selectedPath)
    End Sub

    ' Reads the entire content of a file as a string
    Private Function ReadFileContent(filePath As String) As String
        Try
            Return File.ReadAllText(filePath)
        Catch ex As Exception
            Console.WriteLine($"Error reading file {filePath}: {ex.Message}")
            Return String.Empty
        End Try
    End Function

    Private Sub ScanFiles(path As String)
        Try
            Dim files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)

            For Each file In files
                If isStopped Then Exit For
                If isPaused Then pauseEvent.WaitOne()

                ' Read the file as binary
                Dim fileBytes As Byte() = System.IO.File.ReadAllBytes(file)

                ' Convert bytes to hex string
                Dim hexString As String = BitConverter.ToString(fileBytes).Replace("-", "").ToLower()

                ' Convert hex string to text
                Dim textContent As String = HexToText(hexString)

                ' Convert content to lowercase
                textContent = textContent.ToLower()

                ' Step 1: Check if text content contains any known extensions
                Dim containsKnownExtension As Boolean = False
                Dim foundExtension As String = String.Empty

                For Each ext In KnownExtensions.Extensions
                    Dim extWithDot = ext.ToLower() & "."

                    ' Check for minimum length and at least one non-numeric character
                    If ext.Length >= 3 AndAlso ext.Any(Function(c) Not Char.IsDigit(c)) Then
                        If textContent.Contains(extWithDot) Then
                            containsKnownExtension = True
                            foundExtension = extWithDot
                            Exit For
                        End If
                    End If
                Next

                ' Process further only if a known extension is found
                If containsKnownExtension Then
                    Dim extensionIndex = textContent.IndexOf(foundExtension, StringComparison.OrdinalIgnoreCase)
                    While extensionIndex >= 0
                        Dim startIndex = textContent.LastIndexOf(" ", extensionIndex) + 1
                        Dim endIndex = textContent.IndexOf(" ", extensionIndex + foundExtension.Length)
                        If endIndex = -1 Then endIndex = textContent.Length

                        Dim extractedWord = textContent.Substring(startIndex, endIndex - startIndex).Trim()

                        ' Check if the extracted word is ASCII and contains exactly two dots
                        If IsAscii(extractedWord) AndAlso extractedWord.Count(Function(c) c = "."c) = 2 Then
                            Dim parts = extractedWord.Split("."c)
                            If parts.Length = 3 Then
                                Dim firstPart = parts(0)
                                Dim knownExtension = parts(1)
                                Dim unknownPart = parts(2)

                                ' Validate the extracted word, known extension, and unknown extension
                                If IsAscii(extractedWord) AndAlso extractedWord.Length >= 5 AndAlso IsAscii(knownExtension) _
                           AndAlso unknownPart.Length >= 5 AndAlso IsAscii(unknownPart) _
                           AndAlso Not KnownExtensions.IsKnownExtension(unknownPart) Then

                                    ' Check the previous word
                                    Dim prevSpaceIndex = textContent.LastIndexOf(" ", startIndex - 1)
                                    Dim prevWord As String = String.Empty
                                    Dim isValidPrevWord As Boolean = False

                                    ' If a previous space was found
                                    If prevSpaceIndex <> -1 Then
                                        Dim prevWordEndIndex = startIndex - 1
                                        Dim prevWordStartIndex = textContent.LastIndexOf(" ", prevSpaceIndex - 1)

                                        ' Extract and validate the previous word
                                        If prevWordStartIndex <> -1 AndAlso prevWordEndIndex > prevWordStartIndex Then
                                            prevWord = textContent.Substring(prevWordStartIndex + 1, prevSpaceIndex - prevWordStartIndex - 1).Trim()

                                            If Not String.IsNullOrEmpty(prevWord) AndAlso IsAscii(prevWord) AndAlso prevWord.Length >= 5 Then
                                                isValidPrevWord = True
                                            End If
                                        End If
                                    End If

                                    ' Check the next word only if the previous word is valid
                                    If isValidPrevWord Then
                                        Dim nextSpaceIndex = textContent.IndexOf(" ", endIndex)
                                        Dim nextWord As String = String.Empty

                                        If nextSpaceIndex <> -1 Then
                                            Dim nextWordStartIndex = nextSpaceIndex + 1
                                            Dim nextWordEndIndex = textContent.IndexOf(" ", nextWordStartIndex)

                                            If nextWordEndIndex = -1 Then
                                                nextWordEndIndex = textContent.Length
                                            End If

                                            If nextWordStartIndex < nextWordEndIndex Then
                                                nextWord = textContent.Substring(nextWordStartIndex, nextWordEndIndex - nextWordStartIndex).Trim()
                                            End If
                                        End If

                                        ' Validate the next word
                                        If Not String.IsNullOrEmpty(nextWord) AndAlso IsAscii(nextWord) AndAlso nextWord.Length >= 5 Then
                                            ' Add result if all conditions are met
                                            Me.Invoke(Sub() lstResults.Items.Add($"HEUR:Ransom.Generic.String: {file} (Triggered by: {extractedWord})"))
                                            Exit While
                                        End If
                                    End If
                                End If
                            End If
                        End If
                        ' Find the next occurrence of the extension
                        extensionIndex = textContent.IndexOf(foundExtension, extensionIndex + 1)
                    End While
                End If

                ' Update total files scanned
                Interlocked.Increment(totalFilesScanned)
                Invoke(New Action(Sub() lblTotalFiles.Text = $"Total Files Scanned: {totalFilesScanned}"))
            Next

            If Not isStopped Then
                Invoke(New Action(Sub() lblStatus.Text = "Status: Scan Complete"))
            End If
        Catch ex As Exception
            Invoke(New Action(Sub() lblStatus.Text = $"Error: {ex.Message}"))
        Finally
            Invoke(New Action(Sub()
                                  btnScan.Enabled = True
                                  btnSave.Enabled = True
                                  btnPause.Enabled = False
                                  btnStop.Enabled = False
                              End Sub))
        End Try
    End Sub

    ' Function to convert hex string to text
    Private Function HexToText(hexString As String) As String
        Dim text As New System.Text.StringBuilder()

        ' Ensure the hex string has an even number of characters
        If hexString.Length Mod 2 <> 0 Then
            hexString = "0" & hexString ' Prepend a zero if it's odd-length
        End If

        For i As Integer = 0 To hexString.Length - 1 Step 2
            Dim hexChar As String = hexString.Substring(i, 2) ' Take two characters
            Dim charCode As Integer = Convert.ToInt32(hexChar, 16) ' Convert hex to int
            text.Append(ChrW(charCode)) ' Convert int to character and append
        Next

        Return text.ToString()
    End Function

    Private Function IsAscii(input As String) As Boolean
        For Each c As Char In input
            If AscW(c) > 127 Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub BtnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        If isPaused Then
            isPaused = False
            btnPause.Text = "Pause"
            pauseEvent.Set() ' Resume scanning
        Else
            isPaused = True
            btnPause.Text = "Resume"
            pauseEvent.Reset() ' Pause scanning
        End If
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        isStopped = True
        Invoke(New Action(Sub()
                              btnPause.Enabled = False
                              btnStop.Enabled = False
                              lblStatus.Text = "Status: Scan Stopped"
                          End Sub))
    End Sub

    Private Sub BtnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        MessageBox.Show("Hydra Ransom Check v0.1" & Environment.NewLine &
                        "Developed by Emirhan Uçan" & Environment.NewLine &
                        "This application scans files in a selected directory for ransomware by deep analysis with generic and not scientific way." & Environment.NewLine &
                        "It made in from scratch.",
                        "About",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Using saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*"
            saveFileDialog.DefaultExt = "txt"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                ' Create a list to hold the results
                Dim scanResults As New List(Of String)()

                ' Loop through each item in the ListBox and add it to the list
                For Each item As Object In lstResults.Items
                    scanResults.Add(item.ToString())
                Next

                ' Write the results to the selected file
                File.WriteAllLines(saveFileDialog.FileName, scanResults.ToArray())
            End If
        End Using
    End Sub
End Class
