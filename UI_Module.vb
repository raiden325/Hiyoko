Module UI_Module
    'ファイルから抽出したときのデータ型
    Structure ExtDataType
        Dim IGN As String
        Dim Clan As String
    End Structure
    '情報として格納するときのデータ型
    Structure StoreDataType
        Dim IGN As String
        Dim Clan As String
        Dim Times As Integer
        Dim FileIdx As Integer
    End Structure

    Const SearchIGNCode As String = """name"""
    Const SearchClanCode As String = "clanAbbrev"

    Private DispData() As StoreDataType
    Private NumDispData As Integer

    'wotreplayファイル解析
    Public Sub AnalyeReplayFile()
        Dim NumFiles As Integer = Hiyoko.TargetFileList.Items.Count
        NumDispData = 1
        If NumFiles > 0 Then
            ReDim DispData(NumFiles * 30)
            ' 1.解析対象ファイル数を取得
            For FileIdx As Integer = 0 To NumFiles - 1 Step 1
                ' 2.解析対象ファイルを開き、一行目を読み込む
                Dim FilePath As String = Hiyoko.TargetFileList.Items.Item(FileIdx)
                Dim reader As New System.IO.StreamReader(FilePath, System.Text.Encoding.GetEncoding("shift_jis"))
                Dim Buf As String = reader.ReadLine()
                ' 3."Name"(IGN),"ClanAbbrev"を抽出
                Dim Datas(30) As ExtDataType
                Dim Elem As Integer = 1
                While Elem > 0
                    Call ExtIGNandClan(Buf, Datas, Elem)
                    If Elem = 1 Then
                        'データなし -> 次の行を読み込み
                        Buf = reader.ReadLine
                    Else
                        Exit While
                    End If
                End While
                ' 4.すでに存在するか調べ、ない場合は追加
                Call StoreDispData(Datas, Elem, FileIdx)
                ' 5.次の解析対象ファイルへ
                reader.Close()
            Next FileIdx
            Call SetClanList(NumFiles * 30)
        Else
            '解析対象ファイルなし -> DispDataクリア
            Erase DispData
            NumDispData = 0
            Hiyoko.SelectShowClan.Items.Clear()
            Hiyoko.SelectShowClan.Items.Add("すべて")
        End If
        '表示
        Hiyoko.DataGridView1.Rows.Clear()

        If NumDispData <> 0 Then
            For row As Integer = 1 To NumDispData Step 1
                Hiyoko.DataGridView1.Rows.Add()
            Next row

            For row As Integer = 0 To NumDispData - 1 Step 1
                Hiyoko.DataGridView1.Rows(row).Cells(0).Value = DispData(row + 1).IGN
                Hiyoko.DataGridView1.Rows(row).Cells(1).Value = DispData(row + 1).Clan
                Hiyoko.DataGridView1.Rows(row).Cells(2).Value = DispData(row + 1).Times
            Next row
        End If
    End Sub

    Private Sub ExtIGNandClan(ByVal Buf As String, ByRef Datas() As ExtDataType, ByRef Elems As Integer)
        Dim posIGN As Integer = 1
        Dim posClan As Integer = 1
        Dim sIGN As Integer = 1
        Dim eIGN As Integer = 1
        Dim sClan As Integer = 1
        Dim eClan As Integer = 1

        For SearchCnt As Integer = 1 To 30
            posIGN = Buf.IndexOf(SearchIGNCode, posIGN + 1)
            If posIGN > 0 Then
                sIGN = Buf.IndexOf("""", posIGN + 7) + 1
                eIGN = Buf.IndexOf(",", posIGN + 8) - 1
                Datas(SearchCnt).IGN = Buf.Substring(sIGN, eIGN - sIGN)

                posClan = Buf.IndexOf(SearchClanCode, posIGN)
                If posClan > 0 Then
                    sClan = Buf.IndexOf("""", posClan + 13) + 1
                    eClan = Buf.IndexOf(",", posClan + 14) - 1
                    Datas(SearchCnt).Clan = Buf.Substring(sClan, eClan - sClan)
                End If
                Elems = SearchCnt
            Else
                'ループを抜ける
                Elems = SearchCnt
                Exit For
            End If
        Next SearchCnt
    End Sub

    Private Sub StoreDispData(ByVal Datas() As ExtDataType, ByVal Elems As Integer, ByVal FileIdx As Integer)
        Dim NoDataFlag As Boolean = False
        Dim InvalidIGN() As String = {"driver", "gunner", "commander", "radioman", "loader"}    '追加対象外
        Dim InvalidIGNFlag As Boolean = False

        For i As Integer = 1 To Elems Step 1
            For InvalidIGNIdx As Integer = 0 To 4 Step 1
                '追加対象外IGNか?
                If Datas(i).IGN = InvalidIGN(InvalidIGNIdx) Then
                    '追加対象外
                    InvalidIGNFlag = True
                    Exit For
                End If
            Next InvalidIGNIdx
            If InvalidIGNFlag = False Then
                For j As Integer = 1 To NumDispData Step 1
                    If (DispData(j).IGN = Datas(i).IGN) Then
                        If (DispData(j).FileIdx <> FileIdx) Then
                            DispData(j).Times += 1
                        End If
                        NoDataFlag = False
                        Exit For
                    Else
                        NoDataFlag = True
                    End If
                Next j
                If NoDataFlag = True Then
                    DispData(NumDispData).IGN = Datas(i).IGN
                    DispData(NumDispData).Clan = Datas(i).Clan
                    DispData(NumDispData).Times = 1
                    DispData(NumDispData).FileIdx = FileIdx
                    NumDispData += 1
                    NoDataFlag = False
                End If
            Else
                InvalidIGNFlag = False
            End If
        Next i
        '次の要素を指しているので-1
        NumDispData -= 1
    End Sub

    Private Sub SetClanList(ByVal NumDispData As Integer)
        Dim ClanList() As String
        ReDim ClanList(NumDispData)
        Dim ClanIdx As Integer
        Dim ExistClanFlag As Boolean = False

        For DispDataIdx As Integer = 1 To NumDispData Step 1
            For Idx As Integer = 0 To ClanIdx Step 1
                If (ClanList(Idx) = DispData(DispDataIdx).Clan) Then
                    ExistClanFlag = True
                    Exit For
                Else
                    ExistClanFlag = False
                End If
            Next Idx
            If ExistClanFlag = False Then
                ClanList(ClanIdx) = DispData(DispDataIdx).Clan
                ClanIdx += 1
            End If
        Next DispDataIdx

        '表示するクラン追加前にデータをクリア
        Hiyoko.SelectShowClan.Items.Clear()

        'すべて表示する用とクラン未所属を表示する用データ追加
        Hiyoko.SelectShowClan.Items.Add("すべて")
        Hiyoko.SelectShowClan.Items.Add("")

        For Idx As Integer = 0 To ClanIdx - 1 Step 1
            Hiyoko.SelectShowClan.Items.Add(ClanList(Idx))
        Next Idx
    End Sub

    Public Sub AdaptClanFilter()
        '表示するクランを変更(クランフィルターを適応)
        If NumDispData <> 0 Then
            Dim ShowClan As String = Hiyoko.SelectShowClan.SelectedItem

            If ShowClan <> "すべて" Then
                Dim ClanCnt As Integer
                'クラン数をカウント
                For IGNIdx As Integer = 1 To NumDispData Step 1
                    If (DispData(IGNIdx).Clan = ShowClan) Then
                        ClanCnt += 1
                    End If
                Next IGNIdx

                '表示領域クリア
                Hiyoko.DataGridView1.Rows.Clear()

                '表示行追加
                For row As Integer = 1 To ClanCnt Step 1
                    Hiyoko.DataGridView1.Rows.Add()
                Next row

                'データ追加
                Dim NextIGNIdx As Integer = 1
                For row As Integer = 0 To ClanCnt - 1 Step 1
                    For IGNIdx As Integer = NextIGNIdx To NumDispData Step 1
                        If DispData(IGNIdx).Clan = ShowClan Then
                            Hiyoko.DataGridView1.Rows(row).Cells(0).Value = DispData(IGNIdx).IGN
                            Hiyoko.DataGridView1.Rows(row).Cells(1).Value = DispData(IGNIdx).Clan
                            Hiyoko.DataGridView1.Rows(row).Cells(2).Value = DispData(IGNIdx).Times
                            NextIGNIdx = IGNIdx + 1
                            Exit For
                        End If
                    Next IGNIdx
                Next row
            Else
                '表示領域クリア
                Hiyoko.DataGridView1.Rows.Clear()

                For row As Integer = 1 To NumDispData Step 1
                    Hiyoko.DataGridView1.Rows.Add()
                Next row

                For row As Integer = 0 To NumDispData - 1 Step 1
                    Hiyoko.DataGridView1.Rows(row).Cells(0).Value = DispData(row + 1).IGN
                    Hiyoko.DataGridView1.Rows(row).Cells(1).Value = DispData(row + 1).Clan
                    Hiyoko.DataGridView1.Rows(row).Cells(2).Value = DispData(row + 1).Times
                Next row
            End If
        Else
            '何もしない
        End If
    End Sub
End Module
