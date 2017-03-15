
Imports System.IO
Public Class ConsultaTicketsRh
    Inherits System.Web.UI.Page
    Dim ObjetoClsGestionRh As New ClsRRHHGestion
    Dim Objeto_Gestion_Datos As New Cls_Gestion_Datos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Consulta General de Tickets"
                LlenatDDL()
                LLenarGrilla()
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<SPAN CLASS='GLYPHICON GLYPHICON-REMOVE-SIGN'></SPAN> " & ex.Message
        End Try
    End Sub
    Public Sub LLenarGrilla()
        ViewState("Gtg_ConsultaTickets") = ObjetoClsGestionRh.CargarConsultaTicketsCamposVacios()
        Gtg_ConsultaTickets.DataSource = ViewState("Gtg_ConsultaTickets")
        Gtg_ConsultaTickets.DataBind()
        Gtg_ConsultaTicketsGestiones.DataSource = Nothing
        Gtg_ConsultaTicketsGestiones.DataBind()
        If ViewState("Gtg_ConsultaTickets").Rows.Count > 0 Then
            Lbl_Cantidad.Text = "Número de tickets: " & ObjetoClsGestionRh.Cantidad
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


    Public Sub LlenatDDL()
        With Drl_PrioridadGestion
            .DataSource = ObjetoClsGestionRh.CargarDatosDrl_Prioridad()
            .DataTextField = "Prioridad"
            .DataValueField = "IdPrioridad"
            .DataBind()
            Objeto_Gestion_Datos.Gest_Drl(Drl_PrioridadGestion)
        End With

        With Drl_Calificaciones
            .DataSource = ObjetoClsGestionRh.CargarDatosDrl_Calificacion()
            .DataTextField = "Calificacion"
            .DataValueField = "IdCalificacion"
            .DataBind()
            Objeto_Gestion_Datos.Gest_Drl(Drl_Calificaciones)
        End With
        With Drl_Satisfaccion
            .DataSource = ObjetoClsGestionRh.CargarDatosDrl_Satisfaccion()
            .DataTextField = "GradoSatisfaccion"
            .DataValueField = "IdSatisfaccion"
            .DataBind()
            Objeto_Gestion_Datos.Gest_Drl(Drl_Satisfaccion)
        End With
        With Drl_UsuarioAsignado
            .DataSource = ObjetoClsGestionRh.CargarDatosDrl_Usuarios()
            .DataTextField = "Nombre"
            .DataValueField = "Nombre"
            .DataBind()
            .Items.Insert(0, "- Seleccione -")
        End With
        With Drl_Estado
            .DataSource = ObjetoClsGestionRh.CargarDatosDrl_EstadoTodosEstados()
            .DataTextField = "Estado"
            .DataValueField = "IdEstado"
            .DataBind()
            Objeto_Gestion_Datos.Gest_Drl(Drl_Estado)
        End With
    End Sub
    Protected Sub Btn_Filtrar_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar.Click
        Try
            If TxtCodigoFiltro.Text = Nothing And Drl_PrioridadGestion.SelectedIndex = 0 And Drl_Estado.SelectedIndex = 0 And Drl_Satisfaccion.SelectedIndex = 0 And Drl_UsuarioAsignado.SelectedValue = "- Seleccione -" And Drl_Calificaciones.SelectedIndex = 0 And TxtFechaInicio.Text = Nothing And TxtFechaFin.Text = Nothing Then
                ObjetoClsGestionRh.CargarConsultaTicketsCamposVacios()
                Gtg_ConsultaTickets.DataSource = ObjetoClsGestionRh.CargarConsultaTicketsCamposVacios()
                Gtg_ConsultaTickets.DataBind()
                Gtg_ConsultaTicketsGestiones.DataSource = Nothing
                Gtg_ConsultaTicketsGestiones.DataBind()
                If ObjetoClsGestionRh.Cantidad > 0 Then
                    Lbl_Cantidad.Text = "Número de tickets: " & ObjetoClsGestionRh.Cantidad
                Else
                    Lbl_Cantidad.Text = Nothing
                End If
            Else
                LimpiarGrillas()
                If TxtCodigoFiltro.Text <> Nothing Then
                    ObjetoClsGestionRh.CodigoTicket = TxtCodigoFiltro.Text
                Else
                    ObjetoClsGestionRh.CodigoTicket = ""
                End If
                If Drl_PrioridadGestion.SelectedIndex <> 0 Then
                    ObjetoClsGestionRh.Fk_Prioridad = Drl_PrioridadGestion.SelectedValue
                End If
                If Drl_Satisfaccion.SelectedIndex <> 0 Then
                    ObjetoClsGestionRh.Fk_Satisfaccion = Drl_Satisfaccion.SelectedValue
                End If
                If Drl_Estado.SelectedIndex <> 0 Then
                    ObjetoClsGestionRh.Fk_Estado = Drl_Estado.SelectedValue
                End If
                If Drl_Calificaciones.SelectedIndex <> 0 Then
                    ObjetoClsGestionRh.Fk_Calificacion = Drl_Calificaciones.SelectedValue
                End If

                If Drl_UsuarioAsignado.SelectedValue <> "- Seleccione -" Then
                    ObjetoClsGestionRh.UsuarioAsignado = Drl_UsuarioAsignado.SelectedValue
                End If
                If TxtFechaInicio.Text <> "" Then
                    ObjetoClsGestionRh.FechaIngreso = TxtFechaInicio.Text
                End If
                If TxtFechaFin.Text <> "" Then
                    ObjetoClsGestionRh.FechaCierreGestion = TxtFechaFin.Text
                    Lbl_Cantidad.Text = Gtg_ConsultaTickets.Rows.Count
                End If
                ObjetoClsGestionRh.CargarConsultaTickets()
                Gtg_ConsultaTickets.DataSource = ObjetoClsGestionRh.CargarConsultaTickets()
                Gtg_ConsultaTickets.DataBind()

                If ObjetoClsGestionRh.Cantidad > 0 Then
                    Lbl_Cantidad.Text = "Número de tickets: " & ObjetoClsGestionRh.Cantidad
                Else
                    Lbl_Cantidad.Text = Nothing
                End If
                Limpiar()

            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span Class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
        Lbl_MensajeGes.Text = Nothing
    End Sub

    Protected Sub Btn_Exportar_Click(sender As Object, e As EventArgs) Handles Btn_Exportar.Click
        Exportar()
        LimpiarGrillas()
        Limpiar()
    End Sub
    Sub Exportar()
        If Gtg_ConsultaTickets.Visible Then
            Try
                Dim sw As New StringWriter()
                Dim hw As New HtmlTextWriter(sw)
                Dim tabla As New Table()
                Dim tr1 As New TableRow()
                Dim tr2 As New TableRow()
                Dim tr3 As New TableRow()
                Dim cell1 As New TableCell()
                Dim cell2 As New TableCell()
                Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
                If Gtg_ConsultaTickets.Rows.Count > 0 Then
                    Gtg_ConsultaTickets.Columns(Gtg_ConsultaTickets.Columns.Count - 1).Visible = False
                    cell1.Controls.Add(Gtg_ConsultaTickets)
                    cell2.Controls.Add(Gtg_ConsultaTicketsGestiones)
                    tr1.Cells.Add(cell1)
                    tr2.Cells.Add(cell2)
                    tabla.Rows.Add(tr1)
                    tabla.Rows.Add(tr3)
                    tabla.Rows.Add(tr2)
                    tabla.RenderControl(hw)
                    Gtg_ConsultaTickets.Columns(Gtg_ConsultaTickets.Columns.Count - 1).Visible = True
                    Response.Clear()
                    Response.Buffer = True
                    Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Gestiòn_Mantenimiento.xls")
                    Response.Charset = "UTF-8"
                    Response.ContentType = "application/vnd.ms-excel"
                    Response.ContentEncoding = System.Text.ASCIIEncoding.UTF8
                    Response.Write(style)
                    Response.Output.Write(sw.ToString())
                    Response.Flush()
                    Response.End()
                Else
                    Pnl_Message.CssClass = "alert alert-danger"
                    lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> Primero haga una consulta e intente Exportarla!"
                End If
            Catch ex As Exception
                Pnl_Message.CssClass = "alert alert-danger"
                lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
            End Try
        End If
    End Sub

    Protected Sub Gtg_ConsultaTickets_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Gtg_ConsultaTickets.RowCommand
        Dim Index As Integer
        If e.CommandName = "Gestionar" Then
            Index = Convert.ToInt32(e.CommandArgument)
            TxtCodigoFiltro.Text = HttpUtility.HtmlDecode(Gtg_ConsultaTickets.Rows(Index).Cells(1).Text)
            ObjetoClsGestionRh.CodigoTicket = TxtCodigoFiltro.Text
            ObjetoClsGestionRh.CargarConsultaTickets()
            Gtg_ConsultaTickets.DataSource = ObjetoClsGestionRh.CargarConsultaTickets()
            Gtg_ConsultaTickets.DataBind()
            If ObjetoClsGestionRh.Cantidad > 0 Then
                Lbl_Cantidad.Text = "Número de tickets: " & Gtg_ConsultaTickets.Rows.Count
            End If
            Gtg_ConsultaTicketsGestiones.DataSource = ObjetoClsGestionRh.CargarFiltroGestionTicketRh()
            Gtg_ConsultaTicketsGestiones.DataBind()
            If ObjetoClsGestionRh.Cantidad > 0 Then
                Lbl_MensajeGes.Text = "Número de gestiones: " & Gtg_ConsultaTicketsGestiones.Rows.Count
            ElseIf ObjetoClsGestionRh.Cantidad < 0 Then
                Lbl_MensajeGes.Text = ""
            End If
        End If
        Limpiar()
    End Sub

    Public Sub Limpiar()
        TxtCodigoFiltro.Text = Nothing
        TxtFechaInicio.Text = Nothing
        TxtFechaFin.Text = Nothing
        Drl_Satisfaccion.SelectedIndex = 0
        Drl_PrioridadGestion.SelectedIndex = 0
        Drl_Estado.SelectedIndex = 0
        Drl_Calificaciones.SelectedIndex = 0
        Drl_UsuarioAsignado.SelectedIndex = 0
        Drl_Calificaciones.SelectedIndex = 0
    End Sub
    Public Sub LimpiarGrillas()
        Gtg_ConsultaTickets.DataSource = Nothing
        Gtg_ConsultaTickets.DataBind()
        Gtg_ConsultaTicketsGestiones.DataSource = Nothing
        Gtg_ConsultaTicketsGestiones.DataBind()
        Lbl_MensajeGes.Text = Nothing
        Lbl_Cantidad.Text = Nothing
    End Sub

End Class
