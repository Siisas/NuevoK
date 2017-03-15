Public Class liberarasigservdatos
    Inherits System.Web.UI.Page
    Dim Objeto_Gestion_Datos As New Cls_Gestion_Datos
    Dim objdatos As New clsgeneral
    Dim objdatosCrm As New clscrmdatos
    Dim actualizar As New clscrmdatos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Liberar Asignación Escalamiento Service Datos"
                With drlusuario
                    .DataSource = objdatos.consultaagenteescala
                    .DataTextField = "nombreu"
                    .DataValueField = "idusuario"
                    .DataBind()
                    Objeto_Gestion_Datos.Gest_Drl(drlusuario)
                End With
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnguardar.Click
        Try
            If drlusuario.SelectedItem.Text = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Seleccione el ingeniero al cual desea liberar casos"
                Exit Sub
            End If
            For Each row As GridViewRow In dtggeneral.Rows
                actualizar.caso = CStr(row.Cells(0).Text)
                actualizar.liberaasigescalamservicedatos()
            Next
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Liberación realizada con éxito"
            lblcantidad.Text = Nothing
            dtggeneral.DataSource = Nothing
            dtggeneral.DataBind()
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> se ha producido un error:" & ex.Message
        End Try
    End Sub

    Protected Sub btnliberar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnliberar.Click
        Try
            If drlusuario.SelectedItem.Text = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Seleccione primero el ingeniero para continuar"
                Exit Sub
            End If
            busca()
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> Se produjo error " & ex.Message
        End Try
    End Sub
    Private Sub busca()
        Try

            objdatosCrm.idusuario = drlusuario.SelectedItem.Value
            dtggeneral.DataSource = objdatosCrm.consultaasignadoservicedatos
            dtggeneral.DataBind()
            If objdatosCrm.cantidad > 0 Then
                lblcantidad.Text = "Casos Asignados Sin Proceso: " & objdatosCrm.cantidad
            Else
                lblcantidad.Text = Nothing
            End If

        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> Se produjo error " & ex.Message
        End Try
    End Sub

End Class