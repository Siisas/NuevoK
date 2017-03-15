Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Public Class RegistroTicketRH
    Inherits System.Web.UI.Page
    Dim ObjetoClsGestionRh As New ClsRRHHGestion
    Dim Message As New System.Net.Mail.MailMessage()
    Dim Seleccione As String = "- Seleccione -"
    Dim Objeto_Gestion_Datos As New Cls_Gestion_Datos
    Dim SMTP As New System.Net.Mail.SmtpClient
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Registro Ticket"
                LlenatDDL()
                LlenatGrilla()
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        If Not IsNothing(Objeto_Gestion_Datos.Ex) Then
            Pnl_Message.CssClass = Objeto_Gestion_Datos.Ex("Alert")
            lblmsg.Text = Objeto_Gestion_Datos.Ex("Message")
        End If
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "P", "Pleg_Loading();", True)
    End Sub
    Protected Sub Btn_GuardarRegistro_Click(sender As Object, e As EventArgs) Handles Btn_GuardarRegistro.Click
        If TxtTema.Text = Nothing And Drl_Prioridad.SelectedIndex = 0 And Drl_Area.SelectedIndex = 0 And Txt_Requerimientos.Text = Nothing And Drl_Sector.SelectedIndex = 0 And Drl_AreaGestion.SelectedIndex = 0 And Drl_ZonaGestion.SelectedIndex = 0 Then
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<strong><span class='glyphicon glyphicon-ok-circle'></span></strong> ¡ seleccione todos los campos!"
        Else

            If Drl_Prioridad.SelectedIndex = 0 Then
                lblmsg.Text = "<strong><span class='glyphicon glyphicon-warning-sign'></span></strong> ¡El campo (Prioridad) es obligatorio!"
                Pnl_Message.CssClass = "alert alert-success"
                Exit Sub
            End If
            If Drl_Area.SelectedIndex = 0 Then
                lblmsg.Text = "<strong><span class='glyphicon glyphicon-warning-sign'></span></strong> ¡El campo (Area) es obligatorio!"
                Pnl_Message.CssClass = "alert alert-success"
                Exit Sub
            End If
            If Drl_Sector.SelectedIndex = 0 Then
                lblmsg.Text = "<strong><span class='glyphicon glyphicon-warning-sign'></span></strong> ¡El campo (Sector gestión) es obligatorio!"
                Pnl_Message.CssClass = "alert alert-success"
                Exit Sub
            End If
            If Drl_AreaGestion.SelectedIndex = 0 Then
                lblmsg.Text = "<strong><span class='glyphicon glyphicon-warning-sign'></span></strong> ¡El campo  (Localización gestión) es obligatorio!"
                Pnl_Message.CssClass = "alert alert-success"
                Exit Sub
            End If
            If Drl_ZonaGestion.SelectedIndex = 0 Then
                lblmsg.Text = "<strong><span class='glyphicon glyphicon-warning-sign'></span></strong> ¡El campo (Elemento gestión) es obligatorio!"
                Pnl_Message.CssClass = "alert alert-success"
                Exit Sub
            End If
            If Txt_Requerimientos.Text = Nothing Or Txt_Requerimientos.Text = "" Or Txt_Requerimientos.Text = " " Or Txt_Requerimientos.Text = "0" Then
                lblmsg.Text = "<strong><span class='glyphicon glyphicon-warning-sign'></span></strong> ¡Para el campo (Requerimientos) debe diligenciar especificamente lo que se requiere en su solicitud!"
                Pnl_Message.CssClass = "alert alert-success"
                Exit Sub
            End If
        End If
        Try
            If TxtTema.Text = Nothing Or Drl_Prioridad.SelectedIndex = 0 Or Drl_Area.SelectedIndex = 0 Or Txt_Requerimientos.Text = Nothing Or Drl_Sector.SelectedIndex = 0 Or Drl_AreaGestion.SelectedIndex = 0 Or Drl_ZonaGestion.SelectedIndex = 0 Then
                Throw New Exception("¡Por favor seleccione todos los campos! ")
            Else
                ObjetoClsGestionRh.NombreUsuario = CType(Session("permisos"), clsusuario).usuario
                ObjetoClsGestionRh.Tema = TxtTema.Text
                ObjetoClsGestionRh.Fk_Area = Drl_Area.SelectedValue
                ObjetoClsGestionRh.Requerimientos = Txt_Requerimientos.Text
                ObjetoClsGestionRh.Fk_Prioridad = Drl_Prioridad.SelectedValue
                ObjetoClsGestionRh.Fk_Sector = Drl_Sector.SelectedValue
                ObjetoClsGestionRh.Fk_Localizacion = Drl_AreaGestion.SelectedValue
                ObjetoClsGestionRh.Fk_Elemento = Drl_ZonaGestion.SelectedValue
                ObjetoClsGestionRh.RegTicketRh()
                TxtCodigo.Text = ObjetoClsGestionRh.CargarUltimoticketCreado()
                'Desplegable informativo sobre la gestión del Ticket  
                Lbl_Msgdesp.Text = "Es importante gestionar el Ticket en el menú Recursos Humanos/Mto Preventivo y Correctivo/Gestion. Para darle el debido tramite a su Ticket "
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "desplegar", "PlegDes_Dinamico('#Desp_General', 'slide', '', '', '');", True)
                Try
                    'Envio correo a los respectivos implicados
                    SMTP.Credentials = New System.Net.NetworkCredential("erp-crm@kamilion.co", "Technokam17**")
                    SMTP.Host = "smtp.gmail.com"
                    SMTP.Port = 587
                    SMTP.EnableSsl = True
                    ' Acá se escribe la cuenta de correo al que se le quiere enviar el e-mail
                    Message.[To].Add("malorin.garcia@kamilion.co")
                    Message.[To].Add("alejandra.ayala@kamilion.co")
                    '----------------------------------------------"Quien lo envía","Nombre de quien lo envía" 
                    Message.From = New System.Net.Mail.MailAddress("erp-crm@kamilion.co", "Nueva Solicitud Mantenimiento", System.Text.Encoding.UTF8) 'Quien envía el e-mail
                    Message.Subject = "Ticket numero: " & TxtCodigo.Text 'Motivo o Asunto del e-mail
                    Message.SubjectEncoding = System.Text.Encoding.UTF8 'Codificacion
                    Message.Body = "Buen día," & vbCrLf & vbCrLf & "Se ha generado la solicitud " & TxtCodigo.Text & " por parte del Usuario:" & CType(Session("permisos"), clsusuario).nombre & " " & "Con las Siguientes Requisitos : " &
                    vbCrLf & vbCrLf & vbCrLf & "Tema: " & TxtTema.Text & vbCrLf & "Requerimientos: " & Txt_Requerimientos.Text & vbCrLf & vbCrLf & vbCrLf & "Por favor darle tramite lo mas pronto posible" & vbCrLf & vbCrLf & vbCrLf &
                    vbCrLf & vbCrLf & vbCrLf & "Evitar responder  este correo debido a que se ha generado automáticamente" & vbCrLf &
                    vbCrLf & vbCrLf & "Cordialmente," & vbCrLf & "ERP-CRM KAMILION COMUNICACIONES"
                    Message.Priority = System.Net.Mail.MailPriority.Normal
                    Message.IsBodyHtml = False
                    'ENVIO
                    SMTP.Send(Message)
                    Pnl_Message.CssClass = "alert alert-success"
                    lblmsg.Text = "<strong><span class='glyphicon glyphicon-ok-circle'></span></strong> ¡Se registro exitosamente la solicitud con el Ticket codigo " & TxtCodigo.Text & "!"
                    Limpiar()
                    LlenatGrilla()
                Catch ex As System.Net.Mail.SmtpException
                    Throw
                End Try
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Public Sub LlenatDDL()
        Drl_Area.DataSource = ObjetoClsGestionRh.CargarDatosDrl_Area()
        Drl_Area.DataTextField = "Area"
        Drl_Area.DataValueField = "IdArea"
        Drl_Area.DataBind()
        Objeto_Gestion_Datos.Gest_Drl(Drl_Area)
        Drl_Prioridad.DataSource = ObjetoClsGestionRh.CargarDatosDrl_Prioridad()
        Drl_Prioridad.DataTextField = "Prioridad"
        Drl_Prioridad.DataValueField = "IdPrioridad"
        Drl_Prioridad.DataBind()
        Objeto_Gestion_Datos.Gest_Drl(Drl_Prioridad)
        With Drl_AreaGestion
            .DataSource = ObjetoClsGestionRh.CargarDatosDrl_AreaGestion()
            .DataTextField = "Localizacion"
            .DataValueField = "IdLocalizacion"
            .DataBind()
            Objeto_Gestion_Datos.Gest_Drl(Drl_AreaGestion)
        End With
        Drl_Sector.DataSource = ObjetoClsGestionRh.CargarDatosDrl_Sector()
        Drl_Sector.DataTextField = "Sector"
        Drl_Sector.DataValueField = "Rh_Sector"
        Drl_Sector.DataBind()
        Objeto_Gestion_Datos.Gest_Drl(Drl_Sector)
        Drl_ZonaGestion.DataSource = ObjetoClsGestionRh.CargarDatosDrl_ElementoGestion()
        Drl_ZonaGestion.DataTextField = "Elemento"
        Drl_ZonaGestion.DataValueField = "IdElemento"
        Drl_ZonaGestion.DataBind()
        Objeto_Gestion_Datos.Gest_Drl(Drl_ZonaGestion)
    End Sub

    Public Sub LlenatGrilla()
        ViewState("Gtg_ConsultaTicketsParaImprimir") = ObjetoClsGestionRh.CargarFiltroTicketRh()
        Gtg_ConsultaTicketsParaImprimir.DataSource = ViewState("Gtg_ConsultaTicketsParaImprimir")
        Gtg_ConsultaTicketsParaImprimir.DataBind()
        If ViewState("Gtg_ConsultaTicketsParaImprimir").Rows.Count > 0 Then
            Lbl_Cantidad.Text = "Numero de Tickets: " & ObjetoClsGestionRh.Cantidad
        Else
            Lbl_Cantidad.Text = Nothing
        End If
    End Sub
    Private Sub Gtg_ConsultaTicketsParaImprimir_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles Gtg_ConsultaTicketsParaImprimir.PageIndexChanging
        'Try
        Gtg_ConsultaTicketsParaImprimir.PageIndex = e.NewPageIndex 'asigna la consulta a la grilla por paginas
        Gtg_ConsultaTicketsParaImprimir.DataSource = ViewState("Gtg_ConsultaTicketsParaImprimir")
        Gtg_ConsultaTicketsParaImprimir.DataBind()
    End Sub
    Public Sub Limpiar()
        TxtTema.Text = Nothing
        Txt_Requerimientos.Text = Nothing
        Drl_Prioridad.SelectedIndex = 0
        Drl_Area.SelectedIndex = 0
        Txt_Requerimientos.Text = Nothing
        Drl_Sector.SelectedIndex = 0
        Drl_AreaGestion.SelectedIndex = 0
        Drl_ZonaGestion.SelectedIndex = 0
    End Sub

    Protected Sub Gtg_ConsultaTicketsParaImprimir_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Gtg_ConsultaTicketsParaImprimir.RowCommand
        Dim Index As Integer
        Dim CodigoTicket As String
        Dim FechaGes As Date
        Dim USolicita As String
        Dim Area As String
        Dim Requerimientos As String
        Dim Prioridad As String
        Dim Localizacion As String
        Dim Elemento As String
        Dim Tema As String
        Dim Sector As String
        Try
            If e.CommandName = "Imprimir" Then
                Index = Convert.ToInt32(e.CommandArgument)
                CodigoTicket = HttpUtility.HtmlDecode(Gtg_ConsultaTicketsParaImprimir.Rows(Index).Cells(1).Text)
                ObjetoClsGestionRh.CodigoTicket = CodigoTicket
                USolicita = ObjetoClsGestionRh.CargarDatosReadOnlyGestionUsuarioGestiona()
                FechaGes = ObjetoClsGestionRh.CargarDatosReadOnlyGestionFechaInicioGes()
                Area = ObjetoClsGestionRh.CargarDatosReadOnlyGestionAreaGes()
                Requerimientos = ObjetoClsGestionRh.CargarDatosReadOnlyRequerimientosGes()
                Prioridad = ObjetoClsGestionRh.CargarDatosReadOnlyPrioridadGes()
                Localizacion = ObjetoClsGestionRh.CargarDatosReadOnlyLocalizacionGes()
                Elemento = ObjetoClsGestionRh.CargarDatosReadOnlyElemetoGes()
                Tema = ObjetoClsGestionRh.CargarDatosReadOnlyTemaGes()
                Sector = ObjetoClsGestionRh.CargarDatosReadOnlySectorGes()
                Using ms As New MemoryStream()
                    Dim logo As Image
                    Dim document As New Document(PageSize.A4, 30, 30, 35, 35)
                    Dim writer As PdfWriter = PdfWriter.GetInstance(document, ms)
                    logo = Image.GetInstance(Server.MapPath("~/Css2/Imagenes/Logo.png"))
                    logo.ScalePercent(7.0) 'tamaño de la imagen
                    logo.SetAbsolutePosition(50, 700) '50 de derecha a Izq y 700 de abajo hacia arriba
                    document.Open()
                    document.Add(logo)
                    document.Add(New Paragraph(""))
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(New Paragraph("Bogotá" & " " & "" & Date.Now))
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(New Paragraph("Se ha generado el Ticket Numero:  " & CodigoTicket))
                    document.Add(Chunk.TABBING)
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(New Paragraph("El tema Principal es: " & Tema))
                    document.Add(New Paragraph("La ubicación es: " & Area))
                    document.Add(New Paragraph("La localización es :" & Localizacion))
                    document.Add(New Paragraph("El elemento a verificar es: " & Elemento))
                    document.Add(New Paragraph(""))
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(New Paragraph("Los requerimientos son:"))
                    document.Add(New Paragraph(Requerimientos))
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(New Paragraph("Por favor presentarse lo mas pronto posible con el señor(a): " & USolicita))
                    document.Add(New Paragraph("Es importante darle el debido tramite al Ticket: " & CodigoTicket & " en el CRM pestaña Gestión"))
                    document.Add(Chunk.NEWLINE)
                    document.Add(Chunk.NEWLINE)
                    document.Add(New Paragraph(""))
                    document.Add(Chunk.NEWLINE)
                    document.Add(New Paragraph("Firma y Cedula"))
                    document.Close()
                    writer.Close()
                    Response.ContentType = "pdf/application"
                    Response.AddHeader("content-disposition", "attachment;filename=" & CodigoTicket & ".pdf")
                    Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length)
                End Using
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        TxtTema.Text = Nothing
        Txt_Requerimientos.Text = Nothing
        Drl_Prioridad.SelectedIndex = 0
        Drl_Area.SelectedIndex = 0
        Txt_Requerimientos.Text = Nothing
        Drl_Sector.SelectedIndex = 0
        Drl_AreaGestion.SelectedIndex = 0
        Drl_ZonaGestion.SelectedIndex = 0
    End Sub

    Private Sub Gtg_ConsultaTicketsParaImprimir_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles Gtg_ConsultaTicketsParaImprimir.SelectedIndexChanging
        Try
            Gtg_ConsultaTicketsParaImprimir.DataSource = ViewState("Gtg_ConsultaTicketsParaImprimir")
            Gtg_ConsultaTicketsParaImprimir.PageIndex = e.NewSelectedIndex
            Gtg_ConsultaTicketsParaImprimir.DataBind()
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
End Class