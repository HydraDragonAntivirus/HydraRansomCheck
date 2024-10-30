<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnScan = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btnSelectFile = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblCurrentFile = New System.Windows.Forms.Label()
        Me.lblTotalFiles = New System.Windows.Forms.Label()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.scrollPanel = New System.Windows.Forms.Panel()
        Me.lstResults = New System.Windows.Forms.ListBox()
        Me.scrollPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnScan
        '
        Me.btnScan.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScan.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnScan.ForeColor = System.Drawing.Color.White
        Me.btnScan.Location = New System.Drawing.Point(340, 191)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(90, 36)
        Me.btnScan.TabIndex = 9
        Me.btnScan.Text = "Start Scan"
        Me.btnScan.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(226, 191)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(108, 36)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save Log"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnAbout
        '
        Me.btnAbout.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbout.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAbout.ForeColor = System.Drawing.Color.White
        Me.btnAbout.Location = New System.Drawing.Point(332, 10)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(103, 36)
        Me.btnAbout.TabIndex = 6
        Me.btnAbout.Text = "❔ About"
        Me.btnAbout.UseVisualStyleBackColor = False
        '
        'btnSelectFile
        '
        Me.btnSelectFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectFile.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSelectFile.ForeColor = System.Drawing.Color.White
        Me.btnSelectFile.Location = New System.Drawing.Point(186, 10)
        Me.btnSelectFile.Name = "btnSelectFile"
        Me.btnSelectFile.Size = New System.Drawing.Size(140, 59)
        Me.btnSelectFile.TabIndex = 5
        Me.btnSelectFile.Text = "📂 Select Directory"
        Me.btnSelectFile.UseVisualStyleBackColor = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(114, 230)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblStatus.Size = New System.Drawing.Size(76, 19)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.Text = "Status: Idle"
        '
        'lblCurrentFile
        '
        Me.lblCurrentFile.AutoSize = True
        Me.lblCurrentFile.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCurrentFile.ForeColor = System.Drawing.Color.White
        Me.lblCurrentFile.Location = New System.Drawing.Point(10, 50)
        Me.lblCurrentFile.Name = "lblCurrentFile"
        Me.lblCurrentFile.Size = New System.Drawing.Size(120, 19)
        Me.lblCurrentFile.TabIndex = 1
        Me.lblCurrentFile.Text = "Current File: None"
        '
        'lblTotalFiles
        '
        Me.lblTotalFiles.AutoSize = True
        Me.lblTotalFiles.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblTotalFiles.ForeColor = System.Drawing.Color.White
        Me.lblTotalFiles.Location = New System.Drawing.Point(10, 65)
        Me.lblTotalFiles.Name = "lblTotalFiles"
        Me.lblTotalFiles.Size = New System.Drawing.Size(138, 19)
        Me.lblTotalFiles.TabIndex = 0
        Me.lblTotalFiles.Text = "Total Files Scanned: 0"
        '
        'btnPause
        '
        Me.btnPause.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPause.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPause.Location = New System.Drawing.Point(12, 191)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(90, 36)
        Me.btnPause.TabIndex = 10
        Me.btnPause.Text = "Pause Scan"
        Me.btnPause.UseVisualStyleBackColor = False
        '
        'btnStop
        '
        Me.btnStop.BackColor = System.Drawing.Color.Red
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStop.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnStop.ForeColor = System.Drawing.Color.White
        Me.btnStop.Location = New System.Drawing.Point(120, 191)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(70, 36)
        Me.btnStop.TabIndex = 12
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'scrollPanel
        '
        Me.scrollPanel.AutoScroll = True
        Me.scrollPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.scrollPanel.Controls.Add(Me.lstResults)
        Me.scrollPanel.Location = New System.Drawing.Point(10, 89)
        Me.scrollPanel.Name = "scrollPanel"
        Me.scrollPanel.Size = New System.Drawing.Size(430, 95)
        Me.scrollPanel.TabIndex = 0
        '
        'lstResults
        '
        Me.lstResults.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.lstResults.ForeColor = System.Drawing.Color.White
        Me.lstResults.HorizontalScrollbar = True
        Me.lstResults.Location = New System.Drawing.Point(0, 0)
        Me.lstResults.Name = "lstResults"
        Me.lstResults.Size = New System.Drawing.Size(600, 95)
        Me.lstResults.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(450, 281)
        Me.Controls.Add(Me.scrollPanel)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnPause)
        Me.Controls.Add(Me.lblTotalFiles)
        Me.Controls.Add(Me.lblCurrentFile)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnSelectFile)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnScan)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hydra Ransom Check"
        Me.scrollPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnScan As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnSelectFile As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblCurrentFile As Label
    Friend WithEvents lblTotalFiles As Label
    Friend WithEvents btnPause As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents scrollPanel As Panel
    Friend WithEvents lstResults As ListBox

End Class
