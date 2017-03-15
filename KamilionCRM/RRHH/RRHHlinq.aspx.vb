
Public Class RRHHlinq
    Inherits System.Web.UI.Page
    Dim ObjetoClsGestionRh As New ClsRRHHGestion
    Dim Objeto_Gestion_Datos As New Cls_Gestion_Datos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, Drl_Estado.SelectedIndexChanged
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing

            If Not IsPostBack Then
                Session("Formulario") = "Gestión Ticket"
                'LlenatDDL()
                Dim Grilla As GridView

                Dim Datacontext As New Sample1DataContext
                Grilla = Gtg_ConsultaTickets
                Grilla.DataSource = From RRHHGestionTicket In Datacontext.RRHHGestionTicket
                                    Where RRHHGestionTicket.IdGestion = 19
                                    Select RRHHGestionTicket
                Grilla.DataBind()


                'LlenatGrilla()
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub




    Public Sub LlenatDDL()
        Drl_PrioridadGestion.DataSource = ObjetoClsGestionRh.CargarDatosDrl_Prioridad()
        Drl_PrioridadGestion.DataTextField = "Prioridad"
        Drl_PrioridadGestion.DataValueField = "IdPrioridad"
        Drl_PrioridadGestion.DataBind()
        Objeto_Gestion_Datos.Gest_Drl(Drl_PrioridadGestion)
        Drl_Estado.DataSource = ObjetoClsGestionRh.CargarDatosDrl_Estado()
        Drl_Estado.DataTextField = "Estado"
        Drl_Estado.DataValueField = "IdEstado"
        Drl_Estado.DataBind()
        Objeto_Gestion_Datos.Gest_Drl(Drl_Estado)
        Drl_Calificacion.DataSource = ObjetoClsGestionRh.CargarDatosDrl_Calificacion()
        Drl_Calificacion.DataTextField = "Calificacion"
        Drl_Calificacion.DataValueField = "IdCalificacion"
        Drl_Calificacion.DataBind()
        Objeto_Gestion_Datos.Gest_Drl(Drl_Calificacion)
        Drl_NivelS.DataSource = ObjetoClsGestionRh.CargarDatosDrl_Satisfaccion()
        Drl_NivelS.DataTextField = "GradoSatisfaccion"
        Drl_NivelS.DataValueField = "IdSatisfaccion"
        Drl_NivelS.DataBind()
        Objeto_Gestion_Datos.Gest_Drl(Drl_NivelS)
        Drl_Usuarios.DataSource = ObjetoClsGestionRh.CargarDatosDrl_Usuarios()
        Drl_Usuarios.DataTextField = "Nombre"
        Drl_Usuarios.DataValueField = "IdUsuario"
        Drl_Usuarios.DataBind()
        Drl_Usuarios.Items.Insert(0, "- Seleccione -")
    End Sub
    Protected Sub Btn_Filtrar_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar.Click

        If TxtCodigoFiltro.Text = "" And TxtFechaInicio.Text = "" And TxtFechaFiltroFinal.Text = "" And Drl_PrioridadGestion.SelectedIndex = 0 Then
            LlenatGrilla()
        Else
            If TxtFechaInicio.Text <> "" And TxtFechaFiltroFinal.Text = "" Then

                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Para filtrar por rango es obligatorio llenar fecha inicio - fecha fin"

            ElseIf TxtFechaInicio.Text = "" And TxtFechaFiltroFinal.Text <> "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Para filtrar por rango es obligatorio llenar fecha inicio - fecha fin"
            Else
                If TxtFechaInicio.Text <> "" Then
                    ObjetoClsGestionRh.FechaIngreso = TxtFechaInicio.Text
                End If
                If TxtFechaFiltroFinal.Text <> "" Then
                    ObjetoClsGestionRh.FechaCierreGestion = TxtFechaFiltroFinal.Text
                End If

            End If

            If TxtCodigoFiltro.Text <> Nothing Then
                ObjetoClsGestionRh.CodigoTicket = TxtCodigoFiltro.Text
            End If

            If Drl_PrioridadGestion.SelectedIndex Then
                ObjetoClsGestionRh.Fk_Prioridad = Drl_PrioridadGestion.SelectedValue
            End If



            Gtg_ConsultaTickets.DataSource = ObjetoClsGestionRh.CargarFiltroGestion()
            Gtg_ConsultaTickets.DataBind()
            Lbl_Cantidad.Text = "Numero de Tickets: " & Gtg_ConsultaTickets.Rows.Count

        End If
    End Sub
    Public Sub LlenatGrilla()

        ViewState("Gtg_ConsultaTickets") = ObjetoClsGestionRh.CargarFiltroGrillaGestion()
        Gtg_ConsultaTickets.DataSource = ViewState("Gtg_ConsultaTickets")
        Gtg_ConsultaTickets.DataBind()

        'Gtg_ConsultaTickets.DataSource = ObjetoClsGestionRh.CargarFiltroGrillaGestion()
        'Gtg_ConsultaTickets.DataBind()
        If ViewState("Gtg_ConsultaTickets").Rows.Count > 0 Then
            Lbl_Cantidad.Text = "Numero de Tickets: " & ObjetoClsGestionRh.Cantidad
        Else
            Lbl_Cantidad.Text = Nothing
        End If

        Gtg_ConsultaGestiones.DataSource = ObjetoClsGestionRh.CargarFiltroGrillaGestion()
        Gtg_ConsultaGestiones.DataBind()
        If ObjetoClsGestionRh.Cantidad > 0 Then
            Lbl_Cantidad.Text = "Numero de Tickets: " & ObjetoClsGestionRh.Cantidad
        Else
            Lbl_Cantidad.Text = Nothing
        End If

    End Sub

    Private Sub Gtg_ConsultaTickets_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles Gtg_ConsultaTickets.PageIndexChanging
        'Try
        Gtg_ConsultaTickets.PageIndex = e.NewPageIndex 'asigna la consulta a la grilla por paginas
        Gtg_ConsultaTickets.DataSource = ViewState("Gtg_ConsultaTickets")
        Gtg_ConsultaTickets.DataBind()

    End Sub
    Protected Sub Btn_GuardarGestion_Click(sender As Object, e As EventArgs) Handles Btn_GuardarGestion.Click
        If TxtObservacion.Text = Nothing Or Drl_Usuarios.SelectedIndex = 0 Or Drl_Estado.SelectedIndex = 0 Then
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<strong><span class='glyphicon glyphicon-ok-circle'></span></strong> ¡Por favor seleccione todos los campos! "
        Else
            ObjetoClsGestionRh.IdTicket = TxtIdTicket.Text
            ObjetoClsGestionRh.CodigoTicket = TxtCodigoGestion.Text
            ObjetoClsGestionRh.Fk_Estado = Drl_Estado.SelectedValue
            ObjetoClsGestionRh.FechaInicioGestion = Now
            ObjetoClsGestionRh.UsuarioAsignado = Drl_Usuarios.SelectedValue
            ObjetoClsGestionRh.NombreUsuario = CType(Session("permisos"), clsusuario).usuario
            ObjetoClsGestionRh.ObservacionEstado = TxtObservacion.Text

            Try
                ObjetoClsGestionRh.RegGestion()
                ObjetoClsGestionRh.RegGestionHistorial()
                LimpiarPanelGestion()
                Pnl_Message.CssClass = "alert alert-success"
                lblmsg.Text = "<strong><span class='glyphicon glyphicon-ok-circle'></span></strong> ¡Se gestiono exitosamente Ticket codigo " & TxtCodigoGestion.Text & "!"
            Catch ex As Exception
                Pnl_Message.CssClass = "alert alert-danger"
                lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
            End Try
            Gtg_ConsultaGestiones.DataSource = ObjetoClsGestionRh.CargarFiltroGestionTicketRh()
            Gtg_ConsultaGestiones.DataBind()
            Lbl_CatidadGestiones.Text = "Numero de Gestiones: " & Gtg_ConsultaGestiones.Rows.Count
            TxtEstado.Text = ObjetoClsGestionRh.CargarDatosReadOnlyGestionEstado()
            If TxtEstado.Text = "Gestionado" Or TxtEstado.Text = "Escalado" Then
                Btn_CerrarTicket.Visible = True
            Else
                Btn_CerrarTicket.Visible = False
            End If
            TxtEstadoCierre.Text = ObjetoClsGestionRh.CargarDatosReadOnlyGestionEstado()
            TxtUsuarioAsignado.Text = ObjetoClsGestionRh.CargarDatosReadOnlyGestionUsuarioAsignado()
        End If
    End Sub
    Protected Sub Btn_VolverGestion_Click(sender As Object, e As EventArgs) Handles Btn_VolverGestion.Click
        Pnl_Gestion.Visible = False
        Pnl_Filtros.Visible = True
        LlenatGrilla()
        LimpiarPanelGestion()
    End Sub
    Protected Sub Gtg_ConsultaTickets_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Gtg_ConsultaTickets.RowCommand
        Dim Index As Integer
        If e.CommandName = "Gestionar" Then
            Index = Convert.ToInt32(e.CommandArgument)
#Region "Cargar TxtBox ReadOnly_Gestion_Ticket"
            TxtCodigoGestion.Text = HttpUtility.HtmlDecode(Gtg_ConsultaTickets.Rows(Index).Cells(1).Text)
            ObjetoClsGestionRh.CodigoTicket = TxtCodigoGestion.Text
            ObjetoClsGestionRh.CargarIdticket()
            TxtIdTicket.Text = ObjetoClsGestionRh.CargarIdticket()
            Gtg_ConsultaGestiones.DataSource = ObjetoClsGestionRh.CargarFiltroGestionTicketRh()
            Gtg_ConsultaGestiones.DataBind()
            Lbl_CatidadGestiones.Text = Gtg_ConsultaGestiones.Rows.Count
            'Cargar los Txt ReadOnly de el Panel Gestion
            TxtPersonaSolicita.Text = ObjetoClsGestionRh.CargarDatosReadOnlyGestionUsuarioGestiona()
            TxtFechaTktGestion.Text = ObjetoClsGestionRh.CargarDatosReadOnlyGestionFechaInicioGes()
            TxtArea.Text = ObjetoClsGestionRh.CargarDatosReadOnlyGestionAreaGes()
            Txt_Requerimientos.Text = ObjetoClsGestionRh.CargarDatosReadOnlyRequerimientosGes()
            TxtPrioridad.Text = ObjetoClsGestionRh.CargarDatosReadOnlyPrioridadGes()
            TxtAreaLocalizacion.Text = ObjetoClsGestionRh.CargarDatosReadOnlyLocalizacionGes()
            TxtElementoG.Text = ObjetoClsGestionRh.CargarDatosReadOnlyElemetoGes()
            TxtTemaG.Text = ObjetoClsGestionRh.CargarDatosReadOnlyTemaGes()
            TxtUsuarioAsignado.Text = ObjetoClsGestionRh.CargarDatosReadOnlyGestionUsuarioAsignado()
            TxtEstadoCierre.Text = ObjetoClsGestionRh.CargarDatosReadOnlyGestionEstado()
            TxtEstado.Text = ObjetoClsGestionRh.CargarDatosReadOnlyGestionEstado()

            If TxtEstado.Text = "Pendiente" Then
                Btn_CerrarTicket.Visible = False
            Else
                Btn_CerrarTicket.Visible = True
            End If
            If ObjetoClsGestionRh.Cantidad > 0 Then
                Lbl_CatidadGestiones.Text = "Numero de Tickets: " & ObjetoClsGestionRh.Cantidad
            Else
                Lbl_CatidadGestiones.Text = Nothing
            End If


#End Region
#Region "Cargar TxtBox ReadOnly PAnel_Cierre_Ticket"
            TxtCodigoaa.Text = HttpUtility.HtmlDecode(Gtg_ConsultaTickets.Rows(Index).Cells(1).Text)
            TxtPersonaSolicita.Text = ObjetoClsGestionRh.CargarDatosReadOnlyGestionUsuarioGestiona()
            TxtAreaCierre.Text = ObjetoClsGestionRh.CargarDatosReadOnlyGestionAreaGes()
            TxtRequerimientosCierre.Text = ObjetoClsGestionRh.CargarDatosReadOnlyRequerimientosGes()
            TxtPrioridadCierre.Text = ObjetoClsGestionRh.CargarDatosReadOnlyPrioridadGes()
            TxtLocalizacionCierre.Text = ObjetoClsGestionRh.CargarDatosReadOnlyLocalizacionGes()
            TxtElementoCierre.Text = ObjetoClsGestionRh.CargarDatosReadOnlyElemetoGes()
            TxtTemaCierre.Text = ObjetoClsGestionRh.CargarDatosReadOnlyTemaGes()
            TxtUsuarioGestionaCierre.Text = ObjetoClsGestionRh.CargarDatosReadOnlyUsuarioAsignadoGes()
            TxtPersona.Text = ObjetoClsGestionRh.CargarDatosReadOnlyGestionUsuarioGestiona
            'TxtEstadoCierre.Text = ObjetoClsGestionRh.CargarDatosReadOnlyGestionEstado()
            Pnl_Filtros.Visible = False
            Pnl_Gestion.Visible = True
            If ObjetoClsGestionRh.Cantidad > 0 Then
                Lbl_CatidadGestiones.Text = "Numero de Tickets: " & ObjetoClsGestionRh.Cantidad
            Else
                Lbl_CatidadGestiones.Text = Nothing
            End If
#End Region
        End If
        Try
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub Btn_VolverCierreCalificacion_Click(sender As Object, e As EventArgs) Handles Btn_VolverCierreCalificacion.Click
        Pnl_Filtros.Visible = True
        Pnl_CerrarGestion.Visible = False
        LimpiarPanelCierre()
        Gtg_ConsultaGestiones.DataSource = ObjetoClsGestionRh.CargarFiltroGestionTicketRh()
        Gtg_ConsultaGestiones.DataBind()
        If ObjetoClsGestionRh.Cantidad > 0 Then
            Lbl_CatidadGestiones.Text = "Numero de Tickets: " & ObjetoClsGestionRh.Cantidad
        Else
            Lbl_CatidadGestiones.Text = Nothing
        End If
    End Sub
    Public Sub LimpiarPanelGestion()
        TxtObservacion.Text = Nothing
        Drl_Estado.SelectedIndex = 0
        Drl_Usuarios.SelectedIndex = 0
    End Sub
    Protected Sub Btn_GuardarCalificacion_Click(sender As Object, e As EventArgs) Handles Btn_GuardarCalificacion.Click
        If TxtObservacionCierre.Text = Nothing Or Drl_NivelS.SelectedIndex = 0 Or Drl_Calificacion.SelectedIndex = 0 Then
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<strong><span class='glyphicon glyphicon-ok-circle'></span></strong> ¡Por favor seleccione todos los campos! "
        Else
            ObjetoClsGestionRh.CodigoTicket = TxtCodigoaa.Text
            ObjetoClsGestionRh.Fk_Satisfaccion = Drl_NivelS.SelectedValue
            ObjetoClsGestionRh.Fk_Calificacion = Drl_Calificacion.SelectedValue
            ObjetoClsGestionRh.ObservacionEstado = TxtObservacionCierre.Text
            ObjetoClsGestionRh.UsuarioAsignado = TxtUsuarioGestionaCierre.Text
            ObjetoClsGestionRh.RegCalificacion()
            ObjetoClsGestionRh.IdTicket = TxtIdTicket.Text
            ObjetoClsGestionRh.CodigoTicket = TxtCodigoGestion.Text
            ObjetoClsGestionRh.FechaInicioGestion = Now
            ObjetoClsGestionRh.UsuarioAsignado = TxtUsuarioGestionaCierre.Text
            ObjetoClsGestionRh.NombreUsuario = CType(Session("permisos"), clsusuario).usuario
            ObjetoClsGestionRh.ObservacionEstado = TxtObservacionCierre.Text
            ObjetoClsGestionRh.RegGestionHistorialCierre()
            LimpiarPanelCierre()
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<strong><span class='glyphicon glyphicon-ok-circle'></span></strong> ¡Se cerrro exitosamente Ticket codigo " & TxtCodigoaa.Text & "!"
            Pnl_CerrarGestion.Visible = False
            Pnl_Filtros.Visible = True
            Gtg_ConsultaTickets.DataSource = ObjetoClsGestionRh.CargarFiltroGrillaGestion()
            Gtg_ConsultaTickets.DataBind()
            Lbl_Cantidad.Text = Gtg_ConsultaTickets.Rows.Count
        End If
        Gtg_ConsultaTickets.DataSource = ObjetoClsGestionRh.CargarFiltroGrillaGestion()
        Gtg_ConsultaTickets.DataBind()
        If ObjetoClsGestionRh.Cantidad > 0 Then
            Lbl_Cantidad.Text = "Numero de Tickets: " & ObjetoClsGestionRh.Cantidad
        Else
            Lbl_Cantidad.Text = Nothing
        End If
    End Sub
    Public Sub LimpiarPanelCierre()
        TxtObservacionCierre.Text = Nothing
        Drl_Calificacion.SelectedIndex = 0
        Drl_NivelS.SelectedIndex = 0
        Drl_Calificacion.SelectedIndex = 0
    End Sub
    Protected Sub Btn_CerrarTicket_Click(sender As Object, e As EventArgs) Handles Btn_CerrarTicket.Click
        Lbl_Msgdesp.Text = "¿Esta seguro de que desea cerrar el Ticket?"
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "desplegar", "PlegDes_Dinamico('#Desp_General', 'slide', '', '', '');", True)
    End Sub
    Protected Sub Btn_Si_Click(sender As Object, e As EventArgs) Handles Btn_Si.Click
        Pnl_Gestion.Visible = False
        Pnl_CerrarGestion.Visible = True
        Lbl_Cantidad.Text = "Numero de Tickets: " & Gtg_ConsultaTickets.Rows.Count
    End Sub
End Class
