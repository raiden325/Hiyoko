Public Class Hiyoko
    Private Sub ChoseFile_Click(sender As Object, e As EventArgs) Handles ChoseFile.Click
        'ファイルを選択する
        OpenFileDialog1.Multiselect = True
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "WoTリプレイファイル|*.wotreplay"

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'ファイル選択
            For Each FilePath As String In OpenFileDialog1.FileNames
                TargetFileList.Items.Add(FilePath)
            Next
        Else
            'ファイル選択中止
        End If
    End Sub

    Private Sub ListBoxClear_Click(sender As Object, e As EventArgs) Handles ListBoxClear.Click
        'リストボックスをクリア
        TargetFileList.Items.Clear()
    End Sub

    Private Sub Analyze_Click(sender As Object, e As EventArgs) Handles Analyze.Click
        'ファイルを解析する
        UI_Module.AnalyeReplayFile()
    End Sub

    Private Sub Hiyoko_Load(sender As Object, e As EventArgs) Handles Me.Load
        'ロード時

    End Sub

    Private Sub TargetFileList_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles TargetFileList.DragEnter
        'リストボックにドラッグされたときに実行
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim FileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
            For Each FilePath As String In FileName
                If FilePath.IndexOf("wotreplay", StringComparison.OrdinalIgnoreCase) >= 0 Then
                    e.Effect = DragDropEffects.Copy
                Else
                    e.Effect = DragDropEffects.None
                End If
            Next
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub TargetFileList_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TargetFileList.DragDrop
        'リストボックスにドロップされたときに実行
        Dim FileNames As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        TargetFileList.Items.AddRange(FileNames)
    End Sub

    Private Sub SelectShowClan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SelectShowClan.SelectedIndexChanged
        '表示するクラン変更
        UI_Module.AdaptClanFilter()
    End Sub
End Class
