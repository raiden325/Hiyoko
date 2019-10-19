<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Hiyoko
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TargetFileList = New System.Windows.Forms.ListBox()
        Me.ChoseFile = New System.Windows.Forms.Button()
        Me.ListBoxClear = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.wotIGN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wotClan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BattleTimes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Analyze = New System.Windows.Forms.Button()
        Me.SelectShowClan = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TargetFileList
        '
        Me.TargetFileList.AllowDrop = True
        Me.TargetFileList.FormattingEnabled = True
        Me.TargetFileList.HorizontalScrollbar = True
        Me.TargetFileList.ItemHeight = 12
        Me.TargetFileList.Location = New System.Drawing.Point(12, 24)
        Me.TargetFileList.Name = "TargetFileList"
        Me.TargetFileList.Size = New System.Drawing.Size(360, 136)
        Me.TargetFileList.TabIndex = 0
        '
        'ChoseFile
        '
        Me.ChoseFile.Location = New System.Drawing.Point(12, 166)
        Me.ChoseFile.Name = "ChoseFile"
        Me.ChoseFile.Size = New System.Drawing.Size(90, 23)
        Me.ChoseFile.TabIndex = 1
        Me.ChoseFile.Text = "選択"
        Me.ChoseFile.UseVisualStyleBackColor = True
        '
        'ListBoxClear
        '
        Me.ListBoxClear.Location = New System.Drawing.Point(108, 166)
        Me.ListBoxClear.Name = "ListBoxClear"
        Me.ListBoxClear.Size = New System.Drawing.Size(90, 23)
        Me.ListBoxClear.TabIndex = 2
        Me.ListBoxClear.Text = "クリア"
        Me.ListBoxClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "解析するリプレイファイルを登録"
        '
        'DataGridView1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.wotIGN, Me.wotClan, Me.BattleTimes})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.Location = New System.Drawing.Point(12, 221)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(360, 428)
        Me.DataGridView1.TabIndex = 4
        '
        'wotIGN
        '
        Me.wotIGN.HeaderText = "IGN"
        Me.wotIGN.Name = "wotIGN"
        Me.wotIGN.ToolTipText = "ゲーム内の名前"
        '
        'wotClan
        '
        Me.wotClan.HeaderText = "クラン"
        Me.wotClan.Name = "wotClan"
        Me.wotClan.ToolTipText = "所属クラン"
        '
        'BattleTimes
        '
        Me.BattleTimes.HeaderText = "回数"
        Me.BattleTimes.Name = "BattleTimes"
        Me.BattleTimes.ToolTipText = "戦闘参加回数"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Analyze
        '
        Me.Analyze.Location = New System.Drawing.Point(282, 166)
        Me.Analyze.Name = "Analyze"
        Me.Analyze.Size = New System.Drawing.Size(90, 23)
        Me.Analyze.TabIndex = 5
        Me.Analyze.Text = "解析"
        Me.Analyze.UseVisualStyleBackColor = True
        '
        'SelectShowClan
        '
        Me.SelectShowClan.FormattingEnabled = True
        Me.SelectShowClan.Location = New System.Drawing.Point(124, 195)
        Me.SelectShowClan.Name = "SelectShowClan"
        Me.SelectShowClan.Size = New System.Drawing.Size(121, 20)
        Me.SelectShowClan.TabIndex = 6
        Me.SelectShowClan.Text = "すべて"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 198)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 12)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "表示するクランを選択"
        '
        'Hiyoko
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 661)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SelectShowClan)
        Me.Controls.Add(Me.Analyze)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBoxClear)
        Me.Controls.Add(Me.ChoseFile)
        Me.Controls.Add(Me.TargetFileList)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Hiyoko"
        Me.Text = "Hiyoko"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TargetFileList As ListBox
    Friend WithEvents ChoseFile As Button
    Friend WithEvents ListBoxClear As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents wotIGN As DataGridViewTextBoxColumn
    Friend WithEvents wotClan As DataGridViewTextBoxColumn
    Friend WithEvents BattleTimes As DataGridViewTextBoxColumn
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Analyze As Button
    Friend WithEvents SelectShowClan As ComboBox
    Friend WithEvents Label2 As Label
End Class
