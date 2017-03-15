Public Class regdotacion
    Inherits System.Web.UI.Page
    Dim objGeneral As New clsgeneral
    Dim objdatos As New clsrrhh
    Dim Objeto_Gestion_Datos As New Cls_Gestion_Datos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Actualización de Dotación"
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Sub buscarinf()
        Dim objdatos As New clsrrhh
        If txtcod.Text <> "" Then
            objdatos.codigo = txtcod.Text
            dtggeneral.DataSource = objdatos.consultapersonal
            dtggeneral.DataBind()
        End If
    End Sub
    Protected Sub Btn_Validar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Validar.Click
        Try
            Dim objdatos As New clsrrhh
            If txtcod.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'> Digite el código de usuario al que desea registrar la novedad </span> "
            Else
                objdatos.codigo = txtcod.Text
                objdatos.consultadotac()
                If objdatos.cantidad > 0 Then
                    lblnombre.Text = objdatos.nombres & " " & objdatos.apellidos
                    rdbcarne.SelectedValue = objdatos.carne
                    rdbdiadema.SelectedValue = objdatos.diadema
                    rdbchaleco.SelectedValue = objdatos.chaleco
                    rdbuniforme.SelectedValue = objdatos.uniforme
                    If objdatos.locker = "NA" Then
                        chklocker.Checked = True
                    Else
                        chklocker.Checked = False
                        TxtLocker.Text = objdatos.locker
                    End If
                    buscarinf()
                    If objdatos.cantidad > 0 Then
                        Lbl_Cantidad.Text = "Detalle Documentación: " & objdatos.cantidad
                    Else
                        Lbl_Cantidad.Text = ""
                    End If
                Else
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'> El código no se encuentran creado en la base de datos, revise la información </span> "
                    If objdatos.cantidad > 0 Then
                        Lbl_Cantidad.Text = "Detalle Documentación: " & objdatos.cantidad
                    Else
                        Lbl_Cantidad.Text = ""
                    End If
                    lblnombre.Text = ""
                    rdbcarne.SelectedValue = Nothing
                    rdbchaleco.SelectedValue = Nothing
                    rdbdiadema.SelectedValue = Nothing
                    rdbuniforme.SelectedValue = Nothing

                    chklocker.Checked = False

                    TxtLocker.Text = ""
                    dtggeneral.DataSource = Nothing
                    dtggeneral.DataBind()
                End If
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "Se produjo error " & ex.Message
        End Try
    End Sub

    Protected Sub Btn_Guardar_Click(sender As Object, e As EventArgs) Handles Btn_Guardar.Click
        Try
            If lblnombre.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Digite el código del empleado que desea consultar junto con el ID del registro que desea modificar"
            Else
                objdatos.codigo = txtcod.Text
                If rdbcarne.SelectedValue = Nothing Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Elija si cuenta con carné o no"
                    Exit Sub
                Else
                    objdatos.carne = rdbcarne.SelectedItem.Value
                End If
                If rdbchaleco.SelectedValue = Nothing Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Elija si cuenta con chaleco o no"
                    Exit Sub
                Else
                    objdatos.chaleco = rdbchaleco.SelectedItem.Value
                End If
                If rdbdiadema.SelectedValue = Nothing Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Elija si cuenta con diadema o no"
                    Exit Sub
                Else
                    objdatos.diadema = rdbdiadema.SelectedItem.Value
                End If
                If TxtLocker.Text = "" And chklocker.Checked = False Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Digite el número de locker asignado o elija la opción de no aplica"
                    Exit Sub
                Else
                    If chklocker.Checked = True Then
                        objdatos.locker = "NA"
                    Else

                        objdatos.locker = TxtLocker.Text
                    End If
                End If
                If rdbuniforme.SelectedValue = Nothing Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Elija si cuenta con uniforme o no"
                    Exit Sub
                Else
                    objdatos.uniforme = rdbuniforme.SelectedItem.Value
                End If
                objdatos.modificadotac()
                buscarinf()
                rdbuniforme.Enabled = True
                txtcod.Text = ""
                rdbuniforme.SelectedValue = Nothing
                rdbcarne.SelectedValue = Nothing
                rdbchaleco.SelectedValue = Nothing
                rdbdiadema.SelectedValue = Nothing
                TxtLocker.Text = ""
                chklocker.Checked = False
                lblnombre.Text = ""
                Pnl_Message.CssClass = "alert alert-success"
                lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Novedad ingresada con éxito"
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "Se produjo error " & ex.Message
        End Try
    End Sub

    Private Sub chklocker_CheckedChanged(sender As Object, e As EventArgs) Handles chklocker.CheckedChanged
        If chklocker.Checked = True Then
            PnlLocker.Visible = False
        Else
            PnlLocker.Visible = True
        End If
    End Sub
End Class