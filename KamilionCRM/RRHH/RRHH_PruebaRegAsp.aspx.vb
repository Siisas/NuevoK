Public Class RRHH_PruebaRegAsp
    Inherits System.Web.UI.Page
    Dim Objeto_Gestion_Datos As New Cls_Gestion_Datos
    Dim Objeto_Rh As New ClsRRHHGestion
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Registrar Aspirante"
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_GuardarRegistro_Click(sender As Object, e As EventArgs) Handles Btn_GuardarRegistro.Click
        Try
            LimpiarGrilla()
            Objeto_Gestion_Datos.Validar_Herramientas(TxtDocumento, "Documento", "Numeric", 10,)
            Objeto_Gestion_Datos.Validar_Herramientas(TxtNombre, "Nombre", , 0, 60)
            Objeto_Gestion_Datos.Validar_Herramientas(TxtApellido, "Apellido", "", 0, 60)
            Objeto_Gestion_Datos.Validar_Herramientas(TxtEmail, "Correo Electrónico", "", 0, 100)
            Objeto_Gestion_Datos.Validar_Herramientas(TxtNumCelular, "Número Celular", "Numeric", 10,)
            Objeto_Rh.Documento = TxtDocumento.Text
            Objeto_Rh.Nombre = TxtNombre.Text
            Objeto_Rh.Apellido = TxtApellido.Text
            Objeto_Rh.Email = TxtEmail.Text
            Objeto_Rh.Celular = TxtNumCelular.Text
            Objeto_Rh.ConsultarAspirante()
            Dim Count As Integer = Objeto_Rh.ConsultarAspirante().Rows.Count
            If Count > 0 Then
                Throw New Exception("Aspirante el Documento: " & TxtDocumento.Text & " Ya se encuentra registrado")
                LimpiarGrilla()
            Else
                Objeto_Rh.RegAspirante()
                Pnl_Message.CssClass = "alert alert-success"
                lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Aspirante Con Documento: " & TxtDocumento.Text & " Ha Sido Registrado Con Éxito"
                Limpiar()
                LimpiarGrilla()
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
            'Pnl_Message.CssClass = Objeto_Gestion_Datos.Ex("Alert")
            'lblmsg.Text = Objeto_Gestion_Datos.Ex("Message")
        End Try
    End Sub
    Protected Sub BtnConsultarAsp_Click(sender As Object, e As EventArgs) Handles BtnConsultarAsp.Click
        'Aqui puedo hacer un Join q me muestre el numero de intentos
        Try
            If TxtConsultaDoc.Text = "" Then
                LimpiarGrilla()
                Throw New Exception("Por favor digite el documento del Aspirante")
            Else
                Objeto_Rh.Documento = TxtConsultaDoc.Text
                Objeto_Rh.ConsultarAspirante()
                Gtg_ConsultaAspirantes.DataSource = Objeto_Rh.ConsultarAspirante()
                Gtg_ConsultaAspirantes.DataBind()
                If Gtg_ConsultaAspirantes.Rows.Count > 0 Then
                    Lbl_Cantidad.Text = "Aspirante Identificado :" & Gtg_ConsultaAspirantes.Rows.Count
                Else
                    LimpiarGrilla()
                    Throw New Exception("Aspirante no existe en la base de datos verifique")
                End If
                TxtConsultaDoc.Text = ""
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
            'Pnl_Message.CssClass = Objeto_Gestion_Datos.Ex("Alert")
            'lblmsg.Text = Objeto_Gestion_Datos.Ex("Message")
        End Try
    End Sub
    Public Sub Limpiar()
        TxtDocumento.Text = ""
        TxtNombre.Text = ""
        TxtApellido.Text = ""
        TxtEmail.Text = ""
        TxtNumCelular.Text = ""
    End Sub
    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        If Not IsNothing(Objeto_Gestion_Datos.Ex) Then
            Pnl_Message.CssClass = Objeto_Gestion_Datos.Ex("Alert")
            lblmsg.Text = Objeto_Gestion_Datos.Ex("Message")
        End If
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "P", "Pleg_Loading();", True)
    End Sub
    Public Sub LimpiarGrilla()
        Gtg_ConsultaAspirantes.DataSource = Nothing
        Gtg_ConsultaAspirantes.DataBind()
        Lbl_Cantidad.Text = ""
    End Sub

    Protected Sub Btn_GuardarRegistro_Click(sender As Object, e As ImageClickEventArgs)

    End Sub
End Class