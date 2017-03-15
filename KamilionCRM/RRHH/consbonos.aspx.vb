Public Class consbonos
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
                Session("Formulario") = "Bonos por usuario"
                consulta()
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Private Sub consulta()
        Try
            Dim objdatos As New clsrrhh
            If CType(Session("permisos"), clsusuario).cargo <> "" Then
                objdatos.codigo = CType(Session("permisos"), clsusuario).Codnom
                dtggeneral.DataSource = objdatos.consultabonos
                dtggeneral.DataBind()
                If objdatos.cantidad > 0 Then
                    LblCantidad.Text = "Bonos Reportados: " & objdatos.cantidad
                Else
                    LblCantidad.Text = Nothing
                End If

            End If
            lblmsg.Text = ""
        Catch ex As Exception
            lblmsg.Text = "Se produjo error " & ex.Message
        End Try
    End Sub

End Class