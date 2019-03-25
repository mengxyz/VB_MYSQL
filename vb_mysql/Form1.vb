Imports System.Data
Imports MySql.Data.MySqlClient
Public Class Form1
    Dim conn As MySqlConnection = New MySqlConnection("Server=localhost;User Id=root; Password=; Database=mengx; Pooling=false")
    Sub Page_Load()
        conn.Open()
        Dim sql As String = "select * from `user`"
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(sql, conn)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds, "result")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "result"
        DataGridView1.ReadOnly = True
        conn.Close()
    End Sub
    Sub clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Page_Load()
    End Sub

    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        conn.Open()
        Dim sql As String = "insert into `user` values('" & CStr(TextBox1.Text) & "','" & CStr(TextBox2.Text) & "')"
        Dim sqlcmd As MySqlCommand = New MySqlCommand(sql, conn)
        sqlcmd.ExecuteNonQuery()
        conn.Close()
        Page_Load()
        clear()
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        conn.Open()
        Dim sql As String = "delete from `user` where id = '" & CStr(TextBox1.Text) & "'"
        Dim sqlcmd As MySqlCommand = New MySqlCommand(sql, conn)
        sqlcmd.ExecuteNonQuery()
        conn.Close()
        Page_Load()
        clear()
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString()
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
    End Sub
End Class
