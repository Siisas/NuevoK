Public Class SegundoConcepto
    Inherits System.Web.UI.Page
    Dim ObjCalidad As New clscalidad
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
                Session("Formulario") = "Segundo Concepto"
                cargar_drl()
                If CType(Session("permisos"), clsusuario).perfil = "40" Then
                    ConsultaPendientesAuditor()
                    pnl_conceptos.Visible = False
                    'pnl_consulta.Visible = False
                Else
                    ConsultaPendientes()
                End If
                pnl_asignado.Visible = False
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub ConsultaPendientesAuditor()
        Try
            ObjCalidad.Auditor = CType(Session("permisos"), clsusuario).usuario
            ObjCalidad.Estado = "Asignado"
            Session("SegundoConcepto_dtgconceptos") = ObjCalidad.segundoconceptocaso
            dtgasignados.DataSource = Session("SegundoConcepto_dtgconceptos")
            dtgasignados.DataBind()
            If dtgasignados.Rows.Count = 0 Then
                Pnl_Message.CssClass = "alert alert-info"
                lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span> No tiene solicitudes asignadas"
            Else
                Lbl_cantidad.Text = "Solicitudes segundo contacto pendiente : " + dtgasignados.Rows.Count.ToString
            End If
            Lbl_cantidad.Text = "Solicitudes segundo contacto pendiente : " + ObjCalidad.cantidad
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ConsultaPendientes()
        Try
            ObjCalidad.Auditor = ""
            ObjCalidad.Estado = "Pendiente"
            Session("SegundoConcepto_dtgconceptos_2") = ObjCalidad.segundoconceptocaso
            dtgconceptos.DataSource = Session("SegundoConcepto_dtgconceptos_2")
            dtgconceptos.DataBind()
            If dtgconceptos.Rows.Count = 0 Then
                Pnl_Message.CssClass = "alert alert-info"
                lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span> No se encontraron registros"
            Else
                Lbl_cantidad.Text = "Solicitudes segundo contacto pendiente : " + dtgconceptos.Rows.Count.ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cargar_drl()
        Try
            With drl_auditor
                .DataSource = ObjCalidad.Consulta_auditor
                .DataTextField = "nombreu"
                .DataValueField = "idusuario"
                .DataBind()
                drl_auditor = Obj_G_D.Gest_Drl(drl_auditor)
            End With

            With drl_auditor_asig
                .DataSource = ObjCalidad.Consulta_auditor
                .DataTextField = "nombreu"
                .DataValueField = "idusuario"
                .DataBind()
                drl_auditor_asig = Obj_G_D.Gest_Drl(drl_auditor_asig)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dtgconceptos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles dtgconceptos.RowCommand
        Try
            Dim Index As Integer
            txt_obs.Text = ""
            Select Case e.CommandName
                Case "Asignar"
                    Index = Convert.ToInt32(e.CommandArgument)
                    lbl_solicitid.Text = dtgconceptos.Rows(Index).Cells(1).Text
                    pnl_asignado.Visible = True
            End Select
            dtgconceptos.DataSource = Session("SegundoConcepto_dtgconceptos_2")
            dtgconceptos.DataBind()
            Lbl_cantidad.Text = "Solicitudes segundo contacto pendiente : " + dtgconceptos.Rows.Count.ToString
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub dtgconceptos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles dtgconceptos.RowDataBound
        Try
            If (e.Row.RowType = DataControlRowType.DataRow) Then
                Dim estado As String = e.Row.Cells(7).Text
                If estado = "Pendiente" Then
                    e.Row.Cells(0).Enabled = True
                    e.Row.Cells(7).BackColor = Drawing.Color.FromName("#81BEF7")
                ElseIf estado = "Ratifica" Then
                    e.Row.Cells(7).BackColor = Drawing.Color.FromName("#ff6666")
                    e.Row.Cells(0).Enabled = False
                ElseIf estado = "No Ratifica" Then
                    e.Row.Cells(0).Enabled = False
                    e.Row.Cells(7).BackColor = Drawing.Color.FromName("#B3C556")
                ElseIf estado = "No Aplica" Then
                    e.Row.Cells(0).Enabled = False
                    e.Row.Cells(7).BackColor = Drawing.Color.FromName("#ff6666")
                ElseIf estado = "Asignado" Then
                    e.Row.Cells(0).Enabled = False
                End If
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub btn_asignar_Click(sender As Object, e As EventArgs) Handles btn_asignar.Click
        Try
            Obj_G_D.Validar_Herramientas(drl_auditor_asig, "auditor")
            ObjCalidad.Codigo_reg = lbl_solicitid.Text
            ObjCalidad.Auditor = drl_auditor_asig.SelectedValue
            ObjCalidad.Validacion = 3
            ObjCalidad.registrosegundoconcepto()
            ConsultaPendientes()
            drl_auditor_asig.SelectedIndex = 0
            pnl_asignado.Visible = False
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Try
            If txt_solicitud.Text <> Nothing Then
                ObjCalidad.caso = txt_solicitud.Text
            Else
                ObjCalidad.caso = ""
            End If

            If drl_auditor.SelectedIndex <> 0 Then
                ObjCalidad.Auditor = drl_auditor.SelectedValue
            Else
                ObjCalidad.Auditor = ""
            End If

            If Drl_estado.SelectedIndex <> 0 Then
                ObjCalidad.Estado = Drl_estado.SelectedItem.Text
            Else
                ObjCalidad.Estado = ""
            End If

            'Filtros de fecha
            If (Txt_Fc_Ini.Text = "" And Txt_Fc_Fin.Text <> "") Or (Txt_Fc_Ini.Text <> "" And Txt_Fc_Fin.Text = "") Then
                dtgconceptos.DataSource = Nothing
                dtgconceptos.DataBind()
                btn_exportar.Visible = False
                Lbl_cantidad.Text = ""
                Throw New Exception("Seleccione los dos rangos de fecha")
            End If
            If Txt_Fc_Ini.Text <> "" And Txt_Fc_Fin.Text <> "" Then
                If Date.Parse(Txt_Fc_Ini.Text) > Date.Parse(Txt_Fc_Fin.Text) Then
                    dtgconceptos.DataSource = Nothing
                    dtgconceptos.DataBind()
                    btn_exportar.Visible = False
                    Lbl_cantidad.Text = ""
                    Throw New Exception("Fecha inicio debe ser menor a fecha fin")
                End If
            End If
            If Txt_Fc_Ini.Text <> "" Then
                ObjCalidad.fcini = Txt_Fc_Ini.Text
            End If
            If Txt_Fc_Fin.Text <> "" Then
                ObjCalidad.fcfin = Txt_Fc_Fin.Text
            End If
            If CType(Session("permisos"), clsusuario).perfil = "40" Then
                Session("SegundoConcepto_dtgconceptos") = ObjCalidad.segundoconceptocaso
                dtgasignados.DataSource = Session("SegundoConcepto_dtgconceptos")
                dtgasignados.DataBind()
                If dtgasignados.Rows.Count = 0 Then
                    Pnl_Message.CssClass = "alert alert-info"
                    lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span> No se encontraron registros"
                Else
                    Lbl_cantidad.Text = "Solicitudes segundo contacto : " + ObjCalidad.cantidad
                End If
            Else
                Session("SegundoConcepto_dtgconceptos_2") = ObjCalidad.segundoconceptocaso
                dtgconceptos.DataSource = Session("SegundoConcepto_dtgconceptos_2")
                dtgconceptos.DataBind()
                If dtgconceptos.Rows.Count = 0 Then
                    Pnl_Message.CssClass = "alert alert-info"
                    lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span> No se encontraron registros"
                Else
                    Lbl_cantidad.Text = "Solicitudes segundo contacto : " + ObjCalidad.cantidad
                End If
            End If

            pnl_asignado.Visible = False

        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub dtgasignados_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles dtgasignados.RowCommand
        Try
            Dim Index As Integer
            txt_obs.Text = ""
            Select Case e.CommandName
                Case "Responder"
                    Index = Convert.ToInt32(e.CommandArgument)
                    lbl_id_auditoria.Text = dtgasignados.Rows(Index).Cells(1).Text
                    ScriptManager.RegisterStartupScript(Page, GetType(Page), "Plegar", "PlegDes_Dinamico('#Respuesta', 'slide', '', '', '');", True)
            End Select
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub btn_enviar_Click(sender As Object, e As EventArgs) Handles btn_enviar.Click
        Try
            Obj_G_D.Validar_Herramientas(drlestado_res, "estado")
            Obj_G_D.Validar_Herramientas(txt_obs, "Observacion")
            ObjCalidad.Observacion_Auditor = txt_obs.Text
            ObjCalidad.Estado = drlestado_res.SelectedItem.Text
            ObjCalidad.Codigo_reg = lbl_id_auditoria.Text
            ObjCalidad.Validacion = 6
            ObjCalidad.registrosegundoconcepto()
            If ObjCalidad.cantidad = 1 Then
                Pnl_Message.CssClass = "alert alert-success"
                lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Se solicito segundo contacto correctamente"
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "Plegar", "PlegDes_Dinamico('#Respuesta', 'slide', '', '', '');", True)
            End If
            ConsultaPendientesAuditor()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_mensaje.CssClass = Obj_G_D.Ex("Alert")
            lbl_mensaje.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Try
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "Plegar", "PlegDes_Dinamico('#Respuesta', 'slide', '', '', '');", True)
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub SegundoConcepto_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Try
            If CType(Session("permisos"), clsusuario).perfil = "40" Then
                dtgasignados.DataSource = Session("SegundoConcepto_dtgconceptos")
                dtgasignados.DataBind()
                Lbl_cantidad.Text = "Solicitudes segundo contacto pendiente : " + dtgasignados.Rows.Count.ToString
            Else
                dtgconceptos.DataSource = Session("SegundoConcepto_dtgconceptos_2")
                dtgconceptos.DataBind()
                Lbl_cantidad.Text = "Solicitudes segundo contacto pendiente : " + dtgconceptos.Rows.Count.ToString
            End If

        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Private Sub dtgasignados_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles dtgasignados.RowDataBound
        Try
            If (e.Row.RowType = DataControlRowType.DataRow) Then
                Dim estado As String = e.Row.Cells(7).Text
                Dim auditor As String = e.Row.Cells(8).Text
                If estado = "Pendiente" Then
                    e.Row.Cells(0).Enabled = False
                    e.Row.Cells(7).BackColor = Drawing.Color.FromName("#81BEF7")
                ElseIf estado = "Ratifica" Then
                    e.Row.Cells(0).Enabled = False
                    e.Row.Cells(7).BackColor = Drawing.Color.FromName("#ff6666")
                ElseIf estado = "No Ratifica" Then
                    e.Row.Cells(0).Enabled = False
                    e.Row.Cells(7).BackColor = Drawing.Color.FromName("#B3C556")
                ElseIf estado = "No Aplica" Then
                    e.Row.Cells(0).Enabled = False
                    e.Row.Cells(7).BackColor = Drawing.Color.FromName("#ff6666")
                ElseIf estado = "Asignado" Then
                    If auditor = CType(Session("Permisos"), clsusuario).usuario Then
                        e.Row.Cells(0).Enabled = True
                    Else
                        e.Row.Cells(0).Enabled = False
                    End If
                End If
            End If

        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

End Class