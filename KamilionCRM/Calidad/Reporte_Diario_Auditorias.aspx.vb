Imports System.IO
Public Class Reporte_Diario_Auditorias
    Inherits System.Web.UI.Page
    Dim objGeneral As New clsgeneral
    Dim ObjCalidad As New clscalidad
    Dim ObjDatos As New clscrmdatos
    Dim Obj_G_D As New Cls_Gestion_Datos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            Pnl_mensaje.CssClass = Nothing
            lbl_mensaje.Text = Nothing

            If Not IsPostBack Then
                Session("Formulario") = "Reporte Diario Auditorias"
                cargar_drl()
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub cargar_drl()
        Try
            'Campaña
            ObjCalidad.Validacion = "1"
            With drl_campaña
                .DataSource = ObjCalidad.Consulta_Calidad_Registro_Complemento
                .DataTextField = "Nombre"
                .DataValueField = "Nombre"
                .DataBind()
            End With

            ObjDatos.Validacion = "1"
            With Drl_Supervisor
                .DataSource = ObjDatos.Consultar_Jefes_Productividad()
                .DataTextField = "Jefe_Inmediato"
                .DataValueField = "Jefe_Inmediato"
                .DataBind()
                .Items.Insert(0, "- Seleccione -")
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Try

            dtgconceptos.DataSource = Nothing
            dtgconceptos.DataBind()
            dtggeneral.DataSource = Nothing
            dtggeneral.DataBind()

            If txt_cod_agente.Text <> "" Or Drl_Supervisor.SelectedIndex <> 0 Or drl_campaña.SelectedIndex <> 0 Or Txt_Fc_Ini.Text <> "" Or Txt_Fc_Fin.Text <> "" Or txt_auditoria.Text <> "" Then
                If txt_auditoria.Text <> "" Then
                    ObjCalidad.caso = txt_auditoria.Text
                Else
                    ObjCalidad.caso = ""
                End If
                'CODIGO
                If txt_cod_agente.Text <> "" Then
                    ObjCalidad.agente = txt_cod_agente.Text
                Else
                    ObjCalidad.agente = ""
                End If
                'SUPERVISOR
                If Drl_Supervisor.SelectedIndex <> 0 Then
                    ObjCalidad.Supervisor = Drl_Supervisor.SelectedItem.Text
                Else
                    ObjCalidad.Supervisor = ""
                End If
                'PROCESO
                If drl_campaña.SelectedIndex <> 0 Then
                    ObjCalidad.Proceso = drl_campaña.SelectedItem.Text
                Else
                    ObjCalidad.Proceso = ""
                End If

                'Filtros de fecha
                If (Txt_Fc_Ini.Text = "" And Txt_Fc_Fin.Text <> "") Or (Txt_Fc_Ini.Text <> "" And Txt_Fc_Fin.Text = "") Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Seleccione los dos rangos de fecha"
                    dtggeneral.DataSource = Nothing
                    dtggeneral.DataBind()
                    btn_exportar.Visible = False
                    Lbl_seguimiento.Text = ""
                    Exit Sub
                End If
                If Txt_Fc_Ini.Text <> "" And Txt_Fc_Fin.Text <> "" Then
                    If Date.Parse(Txt_Fc_Ini.Text) > Date.Parse(Txt_Fc_Fin.Text) Then
                        Pnl_Message.CssClass = "alert alert-warning"
                        lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Fecha inicio debe ser menor a fecha fin"
                        dtggeneral.DataSource = Nothing
                        dtggeneral.DataBind()
                        btn_exportar.Visible = False
                        Lbl_seguimiento.Text = ""
                        Exit Sub
                    End If
                End If
                If Txt_Fc_Ini.Text <> "" Then
                    ObjCalidad.fcini = Txt_Fc_Ini.Text
                End If
                If Txt_Fc_Fin.Text <> "" Then
                    ObjCalidad.fcfin = Txt_Fc_Fin.Text
                End If
                Session("Reporte_Diario_Auditorias") = ObjCalidad.Consulta_REporte_diario_auditoria()
                dtggeneral.DataSource = Session("Reporte_Diario_Auditorias")
                dtggeneral.DataBind()
                If ObjCalidad.cantidad = 0 Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> No se encontraron registros"
                    Lbl_seguimiento.Text = "No se encontraron registros"
                    btn_exportar.Visible = False
                Else
                    Lbl_seguimiento.Text = "Auditorias: " + ObjCalidad.cantidad
                    btn_exportar.Visible = True
                End If
            Else
                ObjCalidad.Validacion = "Diario"
                Session("Reporte_Diario_Auditorias") = ObjCalidad.Consulta_REporte_diario_auditoria()
                dtggeneral.DataSource = Session("Reporte_Diario_Auditorias")
                dtggeneral.DataBind()
                If ObjCalidad.cantidad = 0 Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> No se encontraron registros"
                    Lbl_seguimiento.Text = "No se encontraron registros"
                    btn_exportar.Visible = False
                Else
                    Lbl_seguimiento.Text = "Auditorias: " + ObjCalidad.cantidad
                    btn_exportar.Visible = True
                End If
            End If

        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub btn_exportar_Click(sender As Object, e As EventArgs) Handles btn_exportar.Click
        Try
            Dim dtgg As New GridView
            dtgg.DataSource = Nothing
            If dtggeneral.Rows.Count > 0 Then
                dtggeneral.PageSize = 20000
                dtgg.DataSource = Session("Reporte_Diario_Auditorias")
                dtgg.DataBind()
                exportar(dtgg)
                dtggeneral.PageSize = 100
            ElseIf dtgconceptos.Rows.Count > 0 Then
                dtgconceptos.PageSize = 20000
                dtgg.DataSource = Session("Reporte_diario_auditorias_conceptos")
                dtgg.DataBind()
                exportar(dtgg)
                dtgconceptos.PageSize = 100
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Sub exportar(dtg As GridView)
        Try
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim tabla As New Table()
            Dim tr1 As New TableRow()
            Dim cell1 As New TableCell()
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            If dtg.Rows.Count() > 0 Then
                cell1.Controls.Add(dtg)
                tr1.Cells.Add(cell1)
                tabla.Rows.Add(tr1)
                tabla.RenderControl(hw)
                Response.Clear()
                Response.Buffer = True
                Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_diario_Auditoria.xls")
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
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
    Private Sub dtggeneral_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtggeneral.PageIndexChanging
        Try
            dtggeneral.PageIndex = e.NewPageIndex 'asigna la consulta a la grilla por paginas
            dtggeneral.DataSource = Session("Reporte_Diario_Auditorias")
            dtggeneral.DataBind()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
    Private Sub dtggeneral_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles dtggeneral.RowDataBound
        Try
            If (e.Row.RowType = DataControlRowType.DataRow) Then
                Dim segundo As String = e.Row.Cells(13).Text
                If segundo = "-" Then
                    e.Row.Cells(0).Enabled = False
                Else
                    e.Row.Cells(0).Enabled = True
                End If
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
    Private Sub dtggeneral_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles dtggeneral.RowCommand
        Try
            Dim Index As Integer
            txt_obs.Text = ""
            drl_razon.SelectedIndex = 0
            drl_asistio.SelectedIndex = 0
            Select Case e.CommandName
                Case "Solicitar"
                    Index = Convert.ToInt32(e.CommandArgument)
                    ObjCalidad.CodigoAgente = dtggeneral.Rows(Index).Cells(1).Text
                    Dim solicitud = ObjCalidad.segundoconceptocaso.Tables(0)
                    If ObjCalidad.cantidad > 0 Then
                        Pnl_Message.CssClass = "alert alert-info"
                        lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span> Ya se ha registrado una solicitud de segundo concepto con el id " + solicitud.Rows(0).Item("Codigo_Reg").ToString
                        txt_auditoria.Focus()
                        'Throw New Exception("Ya se ha registrado una solicitud de segundo concepto con el id " + solicitud.Rows(0).Item("Codigo_Reg").ToString)
                    Else
                        lbl_id_auditoria.Text = dtggeneral.Rows(Index).Cells(1).Text
                        lbl_proceso.Text = dtggeneral.Rows(Index).Cells(7).Text
                        ScriptManager.RegisterStartupScript(Page, GetType(Page), "Plegar", "PlegDes_Dinamico('#Solicitudes', 'slide', '', '', '');", True)
                    End If
            End Select
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub btn_solicitar_Click(sender As Object, e As EventArgs) Handles btn_solicitar.Click
        Try
            Obj_G_D.Validar_Herramientas(drl_razon, "razon")
            Obj_G_D.Validar_Herramientas(drl_asistio, "líder asistió a la retroalimentación")
            Obj_G_D.Validar_Herramientas(txt_obs, "observacion")


            ObjCalidad.Id_Usuario = CType(Session("permisos"), clsusuario).usuario
            ObjCalidad.asistio = drl_asistio.SelectedItem.Text
            ObjCalidad.razon = drl_razon.SelectedItem.Text
            ObjCalidad.Observacion = txt_obs.Text
            ObjCalidad.Auditoria = lbl_id_auditoria.Text
            ObjCalidad.Proceso = lbl_proceso.Text
            ObjCalidad.Estado = "Pendiente"
            ObjCalidad.registrosegundoconcepto()
            If ObjCalidad.cantidad = 1 Then
                Pnl_Message.CssClass = "alert alert-success"
                lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Se solicito segundo contacto correctamente"
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "Plegar", "PlegDes_Dinamico('#Solicitudes', 'slide', '', '', '');", True)
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_mensaje.CssClass = Obj_G_D.Ex("Alert")
            lbl_mensaje.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Try
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "Plegar", "PlegDes_Dinamico('#Solicitudes', 'slide', '', '', '');", True)
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub btn_segundo_concepto_Click(sender As Object, e As EventArgs) Handles btn_segundo_concepto.Click
        Try
            ObjCalidad.Id_Usuario = CType(Session("permisos"), clsusuario).usuario
            Session("Reporte_diario_auditorias_conceptos") = ObjCalidad.segundoconceptocaso
            dtgconceptos.DataSource = Session("Reporte_diario_auditorias_conceptos")
            dtgconceptos.DataBind()
            If ObjCalidad.cantidad > 0 Then
                Lbl_seguimiento.Text = "Conceptos solicitados: " + ObjCalidad.cantidad
                dtggeneral.DataSource = Nothing
                dtggeneral.DataBind()
            Else
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> No se encontraron registros"
                Lbl_seguimiento.Text = ""
                dtggeneral.DataSource = Nothing
                dtggeneral.DataBind()
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub dtgconceptos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles dtgconceptos.RowDataBound
        Try
            If (e.Row.RowType = DataControlRowType.DataRow) Then
                Dim estado As String = e.Row.Cells(6).Text
                If estado = "Pendiente" Then
                    e.Row.Cells(6).BackColor = Drawing.Color.FromName("#81BEF7")
                ElseIf estado = "Ratifica" Then
                    e.Row.Cells(6).BackColor = Drawing.Color.FromName("#ff6666")
                ElseIf estado = "No Ratifica" Then
                    e.Row.Cells(6).BackColor = Drawing.Color.FromName("#B3C556")
                ElseIf estado = "No Aplica" Then
                    e.Row.Cells(6).BackColor = Drawing.Color.FromName("#ff6666")
                Else

                End If
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
End Class
