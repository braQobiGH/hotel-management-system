Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.IO
Public Class Helper
    Public con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Projects\Project backups\Hotel_Management_System\Hotel_Management_System\Hotel.mdf;Integrated Security=True")

    Public cmd As SqlCommand
    Public data As SqlDataReader
    Public da As SqlDataAdapter
    Public ds As DataSet


    'Insert into Login'
    Public Sub login(id As String, password As TextBox, userType As TextBox)
        Try
            con.Open()

            Dim dbq As String = "INSERT INTO Login (id,Password,User_type) values(@,id,@password,@userType)"

            Dim cmd As New SqlCommand(dbq, con)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.Parameters.AddWithValue("@password", password.Text)
            cmd.Parameters.AddWithValue("@userType", userType.Text)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    'insert into user
    Public Sub insertUser(username As TextBox, address As TextBox, contact As TextBox, pos As ComboBox, password As TextBox, image As PictureBox)
        'converting image
        Dim img As Byte()
        img = convertImage(image)
        Try
            con.Open()

            Dim dbq As String = "INSERT INTO login(User_Name,Address,Contact,Position,Password,Image) values(@userName,@address,@contact,@position,@password,@image)"

            Dim cmd As New SqlCommand(dbq, con)
            cmd.Parameters.AddWithValue("userName", username.Text)
            cmd.Parameters.AddWithValue("address", address.Text)
            cmd.Parameters.AddWithValue("contact", contact.Text)
            cmd.Parameters.AddWithValue("position", pos.Text)
            cmd.Parameters.AddWithValue("password", password.Text)
            cmd.Parameters.AddWithValue("image", SqlDbType.Image).Value = img
            cmd.ExecuteNonQuery()


        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        Finally
            con.Close()
        End Try
    End Sub

    'insert into customer
    Public Sub insertCustomer(id As String, customerName As TextBox, address As TextBox, contact As TextBox, remarks As TextBox, image As PictureBox)

        'converting image
        Dim img As Byte()
        img = convertImage(image)

        Try
            con.Open()

            Dim dbq As String = "INSERT INTO Customer (Id,Customer_Name,Address,Contact,Remarks,Image) values(@id,@customerName,@address,@contact,@Remarks,@image)"

            Dim cmd As New SqlCommand(dbq, con)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.Parameters.AddWithValue("@customerName", customerName.Text)
            cmd.Parameters.AddWithValue("@address", address.Text)
            cmd.Parameters.AddWithValue("@contact", contact.Text)
            cmd.Parameters.AddWithValue("@Remarks", remarks.Text)
            cmd.Parameters.AddWithValue("@image", SqlDbType.Image).Value = img
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    'insert into bookings'
    Public Sub bookings(id As String, cusName As TextBox, roomName As TextBox, roomType As TextBox, price As TextBox, nights As NumericUpDown, totalPrice As TextBox)
        Try
            con.Open()
            Dim dbq As String = "INSERT INTO Bookings (Id,User_name,Room_Name,Room_Type,Price,Nights,Total_Price) values(@id,@customerName,@room_name,@room_type,@price,@nights,@total_price)"
            Dim cmd As New SqlCommand(dbq, con)

            cmd.Parameters.AddWithValue("@id", id)
            cmd.Parameters.AddWithValue("@customerName", cusName.Text)
            cmd.Parameters.AddWithValue("@room_name", roomName.Text)
            cmd.Parameters.AddWithValue("@room_type", roomType.Text)
            cmd.Parameters.AddWithValue("@price", price.Text)
            cmd.Parameters.AddWithValue("@nights", nights.Value)
            cmd.Parameters.AddWithValue("@total_price", totalPrice.Text)

            cmd.ExecuteNonQuery()
        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            con.Close()

        End Try
    End Sub

    Public Sub insertRoom(id As String, user As TextBox, roomName As TextBox, roomType As TextBox, price As TextBox, night As TextBox, totalP As TextBox)
        Try
            con.Open()
            Dim dbq As String = "INSERT INTO Rooms (Id,User_name,Room_Name,Room_Type,Price,Nights,Total_Price) values(@id,@User_name,@roomName,@roomType,@Price,@Nights,@Total_Price)"
            Dim cmd As New SqlCommand(dbq, con)

            cmd.Parameters.AddWithValue("@id", id)
            cmd.Parameters.AddWithValue("@User_name", user.Text)
            cmd.Parameters.AddWithValue("@roomName", roomName.Text)
            cmd.Parameters.AddWithValue("@roomType", roomType.Text)
            cmd.Parameters.AddWithValue("@Price", price.Text)
            cmd.Parameters.AddWithValue("@Nights", night.Text)
            cmd.Parameters.AddWithValue("@Total_Price", totalP.Text)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()

        End Try
    End Sub

    'getting customers from database'
    Public Sub getCustomers(data As DataGridView)
        Try
            Dim query As String = "Select * from Customer"
            con.Open()
            cmd = New SqlCommand(query, con)
            da = New SqlDataAdapter(cmd)
            Dim table As New DataTable
            data.RowTemplate.Height = 20
            Dim img As New DataGridViewImageColumn
            da.Fill(table)
            data.DataSource = table
            img = data.Columns(5)
            img.ImageLayout = DataGridViewImageCellLayout.Stretch
           
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try



    End Sub

    'searching customers function'
    Public Sub search(value As String, datagridview As Object)
        Try
            Dim query As String = "select * from Customer where concat(Id,Customer_Name) LIKE '%" & value & "%'"
            Dim command As New SqlCommand(query, con)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            datagridview.datasource = table
            con.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()


        End Try

    End Sub

    'code for inserting , updating and deleting from database'
    Public Sub updateLogin(query As String)
        Try
            Dim cmd As New SqlCommand(query, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            If (con.State = ConnectionState.Open) Then
                con.Close()
            End If


        End Try
    End Sub

    'code to load rooms'
    Public Sub loadRooms(data As Object)
        Try
            Dim Available As String = "Available"
            Dim query As String = "Select Room_Name,Room_Type,Price,Status from Rooms where Status ='" & Available & "'"
            con.Open()
            cmd = New SqlCommand(query, con)
            da = New SqlDataAdapter(cmd)
            Dim table As New DataTable

            da.Fill(table)
            data.DataSource = table

            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()

        End Try
    End Sub
    Public Sub loadRooms2(data As Object, query As String)
        Try

            con.Open()
            cmd = New SqlCommand(query, con)
            da = New SqlDataAdapter(cmd)
            Dim table As New DataTable

            da.Fill(table)
            data.DataSource = table

            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()

        End Try
    End Sub
    'Convert image'
    Public Function convertImage(pic As PictureBox) As Byte()
        Dim ms As New MemoryStream

        pic.Image.Save(ms, pic.Image.RawFormat)
        Dim img As Byte() = ms.GetBuffer()

        Return img
    End Function
    Public Sub getBookings(data As DataGridView, msg As String, txt As TextBox)
        Try
            Dim query As String = "Select Room_Name,Room_Type,Price,Nights,Total_Price from bookings where id= '" & msg & "' "
            con.Open()
            cmd = New SqlCommand(query, con)
            da = New SqlDataAdapter(cmd)
            Dim table As New DataTable
            da.Fill(table)
            data.DataSource = table
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try



    End Sub

    Public Sub loadBookings(data As DataGridView, msg As String)
        Try
            Dim query As String = "Select Room_Name,Room_Type,Price,Nights,Total_Price from bookings where id= '" & msg & "' "
            con.Open()
            cmd = New SqlCommand(query, con)
            da = New SqlDataAdapter(cmd)
            Dim table As New DataTable
            da.Fill(table)
            data.DataSource = table
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try



    End Sub
    Public Sub booked(query As String)
        Try
            con.Open()



            Dim cmd As New SqlCommand(query, con)
         
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub
    Public Sub updateRoomStatus(query As String)
        Try
            con.Open()
            Dim cmd As New SqlCommand(query, con)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Public Sub checkrooms(txt1 As TextBox, txt2 As TextBox, txt3 As TextBox, txt4 As TextBox, query As String)
        Try
            con.Open()
            cmd = New SqlCommand(query, con)
            da = New SqlDataAdapter(cmd)
            Dim table As New DataTable
            da.Fill(table)
            txt1.Text = table.Rows(0)(5).ToString
            txt2.Text = table.Rows(0)(6).ToString
            txt3.Text = table.Rows(0)(1).ToString
            txt4.Text = table.Rows(0)(2).ToString


            con.Close()
        Catch ex As Exception
            MsgBox("This room is available")
            Exit Sub

        Finally
            con.Close()
        End Try
    End Sub

    Public Sub checkrooms2(query As String, dt As DateTimePicker)
        Try
            con.Open()
            cmd = New SqlCommand(query, con)
            da = New SqlDataAdapter(cmd)
            Dim table As New DataTable
            da.Fill(table)

            dt.Value = table.Rows(0)(0)



            con.Close()
        Catch ex As Exception
            MsgBox("This room is available")
            Exit Sub

        Finally
            con.Close()
        End Try
    End Sub



    'inserting pictures to the database'
    Public Sub insertImage(id As String, image As PictureBox, status As String)

        'converting image
        Dim img As Byte()
        img = convertImage(image)

        Try
            con.Open()

            Dim dbq As String = "INSERT INTO Images (Id,image,status) values(@id,@image,@status)"

            Dim cmd As New SqlCommand(dbq, con)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.Parameters.AddWithValue("@status", id)
           
            cmd.Parameters.AddWithValue("@image", SqlDbType.Image).Value = img
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    'getting users
    Public Sub getUsers(data As DataGridView)
        Try
            Dim query As String = "Select * from Login"
            con.Open()
            cmd = New SqlCommand(query, con)
            da = New SqlDataAdapter(cmd)
            Dim table As New DataTable
            data.RowTemplate.Height = 20
            Dim img As New DataGridViewImageColumn
            da.Fill(table)
            data.DataSource = table
            img = data.Columns(5)
            img.ImageLayout = DataGridViewImageCellLayout.Stretch
            con.Close()

        Catch e As Exception
            MsgBox(e.Message)
            con.Close()


        End Try


    End Sub
    Public Sub buttonImage(Avail As PictureBox, booked As PictureBox, checkIn As PictureBox, btn1 As String, btn As Button)

        Try


            Dim query As String = "select * from Rooms where Room_Name='" & btn1 & "' "
            con.Open()
            cmd = New SqlCommand(query, con)
            da = New SqlDataAdapter(cmd)
            Dim table As New DataTable
            da.Fill(table)
            Dim holder As String = table.Rows(0)(4).ToString
            If (holder.Equals("Available")) Then
                btn.BackgroundImageLayout = ImageLayout.Stretch
                btn.BackgroundImage = Avail.Image
            ElseIf (holder.Equals("Booked")) Then
                btn.BackgroundImageLayout = ImageLayout.Stretch
                btn.BackgroundImage = booked.Image
            Else
                btn.BackgroundImageLayout = ImageLayout.Stretch
                btn.BackgroundImage = checkIn.Image
                con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()








    End Sub
    Public Sub InsertMoney(desc As String, typ As String, datee As Date, Amount As String)
        Try
            con.Open()

            Dim query As String = "insert into Account (Description ,Type ,Amount,Date) values('" & desc & "','" & typ & "','" & Amount & "','" & datee & "')"

            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            con.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub getIncomes(data As DataGridView)
        Dim msg As String = "income"
        Try
            Dim query As String = "Select * from Account where Type = '" & msg & "' "


            con.Open()
            cmd = New SqlCommand(query, con)
            da = New SqlDataAdapter(cmd)
            Dim table As New DataTable
            da.Fill(table)
            data.DataSource = table
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try



    End Sub

    Public Sub getexpenses(data As DataGridView)
        Dim msg As String = "income"
        Dim msg2 As String = "expenses"
        Try
            Dim query As String = "Select * from Account where Type = '" & msg2 & "' "


            con.Open()
            cmd = New SqlCommand(query, con)
            da = New SqlDataAdapter(cmd)
            Dim table As New DataTable
            da.Fill(table)
            data.DataSource = table
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try



    End Sub
    Public Sub loadbooked(data As DataGridView)
        Try
            Dim query As String = "Select * from Booked  "
            con.Open()
            cmd = New SqlCommand(query, con)
            da = New SqlDataAdapter(cmd)
            Dim table As New DataTable
            da.Fill(table)
            data.DataSource = table
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try


    End Sub

    Public Sub loadspecific(data As Object, query As String)
        Try
            Dim Available As String = "Available"

            cmd = New SqlCommand(query, con)
            da = New SqlDataAdapter(cmd)
            Dim table As New DataTable

            da.Fill(table)
            data.DataSource = table

            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()

        End Try
    End Sub


End Class

