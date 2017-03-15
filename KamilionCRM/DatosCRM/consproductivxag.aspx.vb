Public Class consproductivxag

    Inherits System.Web.UI.Page
    Dim objdatos As New clsgeneral
        Dim Objeto_Gestion_Datos As New Cls_Gestion_Datos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Consulta Productividad Datos"
                LlenatDDL()
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<SPAN CLASS='GLYPHICON GLYPHICON-REMOVE-SIGN'></SPAN> " & ex.Message
        End Try
    End Sub

    Sub buscarinf()
        Try
            Dim objdatos As New clscrmdatos
            If drlestado.SelectedItem.Value <> "- Seleccione -" Then
                objdatos.tipificacion = drlestado.SelectedValue
            End If
            If txtfcdesden3.Text <> Nothing Then
                objdatos.fcini3 = txtfcdesden3.Text
                lblmsg.Text = ""
            Else

                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'> Debe seleccionar un rango de fechas para realizar la consulta </span> "
                Exit Sub
            End If
            If txtfchastan3.Text <> Nothing Then
                If Convert.ToDateTime(txtfcdesden3.Text) > Convert.ToDateTime(txtfchastan3.Text) Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'> La fecha desde no puede ser mayor que la fecha hasta </span> "
                    Exit Sub
                End If
                objdatos.fcfin3 = txtfchastan3.Text
            End If
            objdatos.idusuario = CType(Session("permisos"), clsusuario).usuario
            dtggeneral.DataSource = objdatos.consultaprodind
            dtggeneral.DataBind()
            If objdatos.cantidad > 0 Then
                Lbl_Cantidad.Text = "Consulta Nivel3: " & objdatos.cantidad
            Else
                Lbl_Cantidad.Text = ""
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-warning"
            lblmsg.Text = "Se produjo error " & ex.Message
        End Try
    End Sub
    Public Sub LlenatDDL()
        With drlestado
            objdatos.idtip = 1
            drlestado.DataSource = objdatos.consultatipificacion()
            .DataTextField = "tipificacion"
            .DataValueField = "idtipificacion"
            .DataBind()
            Objeto_Gestion_Datos.Gest_Drl(drlestado)
        End With
    End Sub

    Protected Sub Btn_Filtrar_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar.Click
        buscarinf()
    End Sub
End Class




