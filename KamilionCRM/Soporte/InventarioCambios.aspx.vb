Public Class InventarioCambios
    Inherits System.Web.UI.Page
    Dim Obj_Inv As New clsInventario
    Dim Obj_HelpDesk As New clsHelpDesk
    Dim Obj_G_D As New Cls_Gestion_Datos
#Region "Métodos"
    Protected Sub Consultar_Gestiones()
        Try
            Obj_Inv.Cod_Inventario = Lbl_ConsCodInv.Text
            ViewState("Dtg_ConsGest") = Obj_Inv.Cons_Gestiones_Dispositivo()
            Lbl_ConsGest.Text = ViewState("Dtg_ConsGest").Rows.Count
            With Dtg_ConsGest
                .DataSource = ViewState("Dtg_ConsGest")
                .DataBind()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub Consultar_Movimientos()
        Try
            Obj_Inv.Cod_Inventario = Lbl_ConsCodInv.Text
            ViewState("Dtg_ConsMov") = Obj_Inv.Cons_AsignacionesLiberaciones_Dispositivo()
            Lbl_ConsMov.Text = ViewState("Dtg_ConsMov").Rows.Count
            With Dtg_ConsMov
                .DataSource = ViewState("Dtg_ConsMov")
                .DataBind()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Msg_Desp.CssClass = Nothing
            Lbl_Msg_Desp.Text = Nothing
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Gestión Inventario"
                Btn_Limpiar_Cons_Click(1, Nothing)
                Btn_Limpiar_AsigMod_Click(1, Nothing)
                Btn_Limpiar_LibMod_Click(1, Nothing)
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
    Protected Function Consultar() As Boolean
        Try
            If Not IsNothing(ViewState("Filtro_Cons")) Then
                Obj_Inv.Propertys = ViewState("Filtro_Cons")
                ViewState("Dtg_ConsInv") = Obj_Inv.Cons_Dispositivos
                Lbl_ConsInv.Text = ViewState("Dtg_ConsInv").rows.count
                Dtg_ConsInv.DataSource = ViewState("Dtg_ConsInv")
                Dtg_ConsInv.DataBind()
                If ViewState("Dtg_ConsInv").rows.count > 0 Then
                    Pnl_Dtg_ConsInv.Visible = True
                    Return True
                Else
                    Pnl_Dtg_ConsInv.Visible = False
                    Return False
                End If
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "Btn.Click"
    Protected Sub Btn_Consultar_Inventario_Click(sender As Object, e As EventArgs) Handles Btn_Consultar_Inventario.Click
        Try
            Pnl_Dtg_ConsGestMov.Visible = False
            Lbl_ConsCodInv.Text = Nothing
            Obj_Inv.Serial = Txt_Serial_ConsInv.Text
            Obj_Inv.Serial_Kamilion = Txt_SerialKam_ConsInv.Text
            If Txt_CodInv_ConsInv.Text <> Nothing Then
                Obj_Inv.Cod_Inventario = Txt_CodInv_ConsInv.Text
            End If
            If Drl_Dispositivo_ConsInv.SelectedIndex > 0 Then
                Obj_Inv.Cod_Invent_Dispositivo = Drl_Dispositivo_ConsInv.SelectedValue
            End If
            If Drl_Modulo_ConsInv.SelectedIndex > 0 Then
                Obj_Inv.ID_Modulo = Drl_Modulo_ConsInv.Text
            End If
            If Drl_Estado_ConsInv.SelectedIndex > 0 Then
                Obj_Inv.Cod_Estado = Drl_Estado_ConsInv.Text
            End If
            ViewState("Filtro_Cons") = Obj_Inv.Propertys
            If Consultar() Then
                Pnl_Message.CssClass = "alert alert-success"
                lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Busqueda Exitosa"
            Else
                Pnl_Message.CssClass = "alert alert-info"
                lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span> No se encontraron registros"
            End If

        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        Finally
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "P", "Pleg_Loading();", True)
        End Try
    End Sub
    Protected Sub Btn_Asignar_Mod_Click(sender As Object, e As EventArgs) Handles Btn_Asignar_Mod.Click
        Try
            Obj_G_D.Validar_Herramientas(Drl_Modulo_AsigMod, "Módulo")
            Obj_G_D.Validar_Herramientas(Drl_Area_AsigMod, "Área")
            Obj_G_D.Validar_Herramientas(Txt_Observacion_AsigMod, "Observación",, 5, 300)
            Obj_Inv.ID_Modulo = Drl_Modulo_AsigMod.SelectedItem.Value
            Obj_Inv.Id_Usuario = CType(Session("permisos"), clsusuario).usuario
            Obj_Inv._area = Drl_Area_AsigMod.SelectedItem.Value
            Obj_Inv.Observacion = Txt_Observacion_AsigMod.Text
            Obj_Inv.Asignar_Modulo()
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> El módulo """ & Obj_Inv.ID_Modulo & """ se asignó exitosamente"
            Btn_Limpiar_AsigMod_Click(1, Nothing)
            Consultar()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        Finally
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "P", "Pleg_Loading();", True)
        End Try
    End Sub
    Protected Sub Btn_Liberar_Mod_Click(sender As Object, e As EventArgs) Handles Btn_Liberar_Mod.Click
        Try
            Obj_G_D.Validar_Herramientas(Drl_Modulo_LibMod, "Módulo")
            Obj_G_D.Validar_Herramientas(Txt_Observacion_LibMod, "Observación",, 5, 300)
            Obj_Inv.ID_Modulo = Drl_Modulo_LibMod.SelectedItem.Value
            Obj_Inv.Id_Usuario = CType(Session("permisos"), clsusuario).usuario
            Obj_Inv.Observacion = Txt_Observacion_LibMod.Text
            Obj_Inv.Liberar_Modulo()
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> El módulo """ & Obj_Inv.ID_Modulo & """ se liberó exitosamente"
            Btn_Limpiar_LibMod_Click(1, Nothing)
            Consultar()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        Finally
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "P", "Pleg_Loading();", True)
        End Try
    End Sub
    Protected Sub Btn_Confimr_Desp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Confimr_Desp.Click
        Try
            Obj_Inv.Cod_Inventario = ViewState("Cod_DispLib")
            If ViewState("Dtg_ConsInv.CommandName") = "Asignar" Then
                Obj_G_D.Validar_Herramientas(Txt_Desp, "Observación",, 5, 300)
                Obj_G_D.Validar_Herramientas(Drl_Desp, "Módulo")
                Obj_Inv.Id_Usuario = CType(Session("permisos"), clsusuario).usuario
                Obj_Inv.Observacion = Txt_Desp.Text
                Obj_Inv.ID_Modulo = Drl_Desp.SelectedItem.Value
                Obj_Inv.Asignar_Dispositivo()
                If Lbl_ConsCodInv.Text = Obj_Inv.Cod_Inventario Then
                    Consultar_Movimientos()
                End If
                Pnl_Message.CssClass = "alert alert-success"
                lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Dispositivo Asignado"
                Consultar()
            ElseIf ViewState("Dtg_ConsInv.CommandName") = "Liberar" Then
                Obj_G_D.Validar_Herramientas(Txt_Desp, "Observación",, 5, 300)
                Obj_Inv.Id_Usuario = CType(Session("permisos"), clsusuario).usuario
                Obj_Inv.Observacion = Txt_Desp.Text
                Obj_Inv.Liberar_Dispositivo()
                If Lbl_ConsCodInv.Text = Obj_Inv.Cod_Inventario Then
                    Consultar_Movimientos()
                End If
                Pnl_Message.CssClass = "alert alert-success"
                lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Dispositivo liberado"
                Consultar()
            ElseIf ViewState("Dtg_ConsInv.CommandName") = "Registrar_Gestion" Then
                Obj_G_D.Validar_Herramientas(Txt_Desp, "Observación",, 5, 300)
                Obj_G_D.Validar_Herramientas(Drl_Desp, "Estado")
                Obj_Inv.Id_Usuario = CType(Session("permisos"), clsusuario).usuario
                Obj_Inv.Observacion = Txt_Desp.Text
                Obj_Inv.Cod_Estado = Drl_Desp.SelectedItem.Value
                Obj_Inv.Registrar_Gestion_Dispositivo()
                If Lbl_ConsCodInv.Text = Obj_Inv.Cod_Inventario Then
                    Consultar_Gestiones()
                End If
                Pnl_Message.CssClass = "alert alert-success"
                lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Dispositivo Gestionado"
                Consultar()
            End If
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "Desp_Form_Desp", "PlegDespleg('#Desp_Form_Desp', 'Pleg', 'slide', '', '', '');", True)
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Msg_Desp.CssClass = Obj_G_D.Ex("Alert")
            Lbl_Msg_Desp.Text = Obj_G_D.Ex("Message")
        Finally
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "P", "Pleg_Loading();", True)
        End Try
    End Sub
    Protected Sub Btn_Back_Desp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Back_Desp.Click
        Try
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "Desp_Form_Desp", "PlegDespleg('#Desp_Form_Desp', 'Pleg', 'slide', '', '', '');", True)
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Msg_Desp.CssClass = Obj_G_D.Ex("Alert")
            Lbl_Msg_Desp.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
    Protected Sub Btn_Limpiar_AsigMod_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Limpiar_AsigMod.Click
        Try
            Txt_Observacion_AsigMod.Text = Nothing
            With Drl_Modulo_AsigMod
                .DataSource = Obj_Inv.Cons_Modulos
                .DataTextField = "ID_Modulo"
                .DataValueField = "ID_Modulo"
                .DataBind()
                Obj_G_D.Gest_Drl(Drl_Modulo_AsigMod)
            End With
            With Drl_Area_AsigMod
                .DataSource = Obj_HelpDesk.Consulta_Area
                .DataTextField = "Nombre"
                .DataValueField = "Cod_HelpDesk_Complemento"
                .DataBind()
                Obj_G_D.Gest_Drl(Drl_Area_AsigMod)
            End With
        Catch ex As Exception
            If TypeOf sender Is DropDownList Then
                Obj_G_D.Val_Ex(ex)
                Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
                lblmsg.Text = Obj_G_D.Ex("Message")
            Else
                Throw ex
            End If
        End Try
    End Sub
    Protected Sub Btn_Limpiar_LibMod_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Limpiar_LibMod.Click
        Try
            Txt_Observacion_LibMod.Text = Nothing
            With Drl_Modulo_LibMod
                .DataSource = Obj_Inv.Cons_Modulos
                .DataTextField = "ID_Modulo"
                .DataValueField = "ID_Modulo"
                .DataBind()
                Obj_G_D.Gest_Drl(Drl_Modulo_LibMod)
            End With
        Catch ex As Exception
            If TypeOf sender Is DropDownList Then
                Obj_G_D.Val_Ex(ex)
                Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
                lblmsg.Text = Obj_G_D.Ex("Message")
            Else
                Throw ex
            End If
        End Try
    End Sub
    Protected Sub Btn_Limpiar_Cons_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Limpiar_Cons.Click
        Try
            If Not IsPostBack Then
                Pnl_Dtg_ConsInv.Visible = False
            End If
            Txt_CodInv_ConsInv.Text = Nothing
            Txt_SerialKam_ConsInv.Text = Nothing
            Txt_Serial_ConsInv.Text = Nothing
            ViewState("Filtro_Cons") = Nothing
            With Drl_Dispositivo_ConsInv
                .DataSource = Obj_Inv.Consulta_Dispositivos
                .DataTextField = "Nombre_Dispositivo"
                .DataValueField = "Cod_Invent_Dispositivo"
                .DataBind()
                Obj_G_D.Gest_Drl(Drl_Dispositivo_ConsInv)
            End With
            With Drl_Estado_ConsInv
                .DataSource = Obj_Inv.Cons_Estados()
                .DataTextField = "Descripcion"
                .DataValueField = "Cod"
                .DataBind()
                Obj_G_D.Gest_Drl(Drl_Estado_ConsInv)
            End With
            With Drl_Modulo_ConsInv
                .DataSource = Obj_Inv.Cons_Modulos
                .DataTextField = "ID_Modulo"
                .DataValueField = "ID_Modulo"
                .DataBind()
                .Items.Add("BODEGA")
                Obj_G_D.Gest_Drl(Drl_Modulo_ConsInv)
            End With
        Catch ex As Exception
            If TypeOf sender Is DropDownList Then
                Obj_G_D.Val_Ex(ex)
                Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
                lblmsg.Text = Obj_G_D.Ex("Message")
            Else
                Throw ex
            End If
        End Try
    End Sub
#End Region
#Region "Dtg.RowCommand"
    Protected Sub Dtg_Productividad_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Dtg_ConsInv.RowCommand
        Try
            Txt_Desp.Text = Nothing
            Dim Index As Integer = Convert.ToInt32(e.CommandArgument)
            Select Case e.CommandName
                Case "Asignar"
                    With Drl_Desp
                        .DataSource = Obj_Inv.Cons_Modulos()
                        .DataTextField = "ID_Modulo"
                        .DataValueField = "ID_Modulo"
                        .DataBind()
                        Obj_G_D.Gest_Drl(Drl_Desp)
                    End With
                    ViewState("Dtg_ConsInv.CommandName") = e.CommandName
                    ViewState("Cod_DispLib") = Dtg_ConsInv.Rows(Index).Cells(0).Text
                    Txt_Desp.Visible = True
                    Drl_Desp.Visible = True
                    Lbl_Enun_Desp.Text = "Ingrese el motivo de la asignación y eliga el módulo al cual va a asgnar el dispositivo"
                    ScriptManager.RegisterStartupScript(Page, GetType(Page), "Desp_Form_Desp", "PlegDespleg('#Desp_Form_Desp', 'Despleg', 'slide', '', '', '');", True)
                Case "Liberar"
                    ViewState("Dtg_ConsInv.CommandName") = e.CommandName
                    ViewState("Cod_DispLib") = Dtg_ConsInv.Rows(Index).Cells(0).Text
                    Txt_Desp.Visible = True
                    Drl_Desp.Visible = False
                    Lbl_Enun_Desp.Text = "Ingrese el motivo de la liberación"
                    ScriptManager.RegisterStartupScript(Page, GetType(Page), "Desp_Form_Desp", "PlegDespleg('#Desp_Form_Desp', 'Despleg', 'slide', '', '', '');", True)
                Case "Registrar_Gestion"
                    With Drl_Desp
                        .DataSource = Obj_Inv.Cons_Estados()
                        .DataValueField = "Cod"
                        .DataTextField = "Descripcion"
                        .DataBind()
                        Obj_G_D.Gest_Drl(Drl_Desp)
                    End With
                    ViewState("Dtg_ConsInv.CommandName") = e.CommandName
                    ViewState("Cod_DispLib") = Dtg_ConsInv.Rows(Index).Cells(0).Text
                    Txt_Desp.Visible = True
                    Drl_Desp.Visible = True
                    Lbl_Enun_Desp.Text = "Ingrese el motivo del cambio de estado y elja el núevo estado"
                    ScriptManager.RegisterStartupScript(Page, GetType(Page), "Desp_Form_Desp", "PlegDespleg('#Desp_Form_Desp', 'Despleg', 'slide', '', '', '');", True)
                Case "Ver_GestionesMovimientos"
                    Lbl_ConsCodInv.Text = Dtg_ConsInv.Rows(Index).Cells(0).Text
                    Consultar_Gestiones()
                    Consultar_Movimientos()
                    If ViewState("Dtg_ConsGest").Rows.Count >= 0 Or ViewState("Dtg_ConsMov").Rows.Count >= 0 Then
                        Pnl_Dtg_ConsGestMov.Visible = True
                    Else
                        Pnl_Dtg_ConsGestMov.Visible = False
                        Pnl_Message.CssClass = "alert alert-info"
                        lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span> No se encontraron registros de gestiones ni movimientos"
                    End If
            End Select
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "Pleg_Form_Desp", "PlegDespleg('#Desp_Form_Desp', 'Pleg', 'slide', '', '', '');", True)
        Finally
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "P", "Pleg_Loading();", True)
        End Try
    End Sub
#End Region
#Region "Dtg.PageIndexChanging"
    Protected Sub Dtg_ConsGest_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles Dtg_ConsGest.PageIndexChanging
        Try
            Dtg_ConsGest.PageIndex = e.NewPageIndex 'asigna la consulta a la grilla por paginas
            Dtg_ConsGest.DataSource = ViewState("Dtg_ConsGest")
            Dtg_ConsGest.DataBind()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
    Protected Sub Dtg_ConsMov_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles Dtg_ConsMov.PageIndexChanging
        Try
            Dtg_ConsMov.PageIndex = e.NewPageIndex 'asigna la consulta a la grilla por paginas
            Dtg_ConsMov.DataSource = ViewState("Dtg_ConsMov")
            Dtg_ConsMov.DataBind()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
    Protected Sub dtggeneral1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles Dtg_ConsInv.PageIndexChanging
        Try

            Dtg_ConsInv.PageIndex = e.NewPageIndex 'asigna la consulta a la grilla por paginas
            Dtg_ConsInv.DataSource = ViewState("Dtg_ConsInv")
            Dtg_ConsInv.DataBind()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
#End Region
End Class