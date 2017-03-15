Imports System.IO
Public Class escalamiento
    Inherits System.Web.UI.Page
    Dim Obj_General As New clsgeneral
    Dim Obj_Voz As New clsvoz
    Dim Obj_G_D As New Cls_Gestion_Datos
#Region "Page"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Lbl_Mensage.Text = Nothing
            Pnl_Message.CssClass = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Asignación Escalamiento Voz"
                Obj_General.idusuario = CType(Session("permisos"), clsusuario).usuario
                Limpiar_ConsDev()
                Limpiar_ConsGestDev()
                Obj_General.consultared()
                Cargar_Drls()
                Consultar_Agentes_Asignados()
                Contar_CasosDevueltos()
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            Lbl_Mensage.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Try
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "P", "Pleg_Loading();", True)
            If TypeOf ViewState("Dtg_ConsCasDev") Is DataTable Then
                If Dtg_ConsCasDev.Rows.Count > 0 And ViewState("Dtg_ConsCasDev").Rows.Count > 0 Then
                    'recorrer filas
                    Dim Top As Integer = Nothing
                    For Row As Integer = 0 To Dtg_ConsCasDev.Rows.Count - 1
                        For I As Integer = 0 To Dtg_ConsCasDev.Columns.Count - 1
                            If Dtg_ConsCasDev.Columns(I).HeaderText = "Id Caso" Then
                                For Each DttRow As DataRow In ViewState("Dtg_ConsCasDev").Rows
                                    If DttRow.Item("IdCaso") = Integer.Parse(Dtg_ConsCasDev.Rows(Row).Cells(I).Text) Then
                                        DttRow.Item("Check") = DirectCast(Dtg_ConsCasDev.Rows(Row).FindControl("Check"), CheckBox).Checked
                                        Exit For
                                    End If
                                Next
                                Exit For
                            End If
                        Next
                        If DirectCast(Dtg_ConsCasDev.Rows(Row).FindControl("Check"), CheckBox).Checked Then
                            Top += 1
                        Else
                            Top -= 1
                        End If
                    Next
                    If Top = Dtg_ConsCasDev.Rows.Count Then
                        Check_All.Checked = True
                    Else
                        Check_All.Checked = False
                    End If
                End If
            End If
            If Not IsNothing(Obj_G_D.Ex) Then
                Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
                Lbl_Mensage.Text = Obj_G_D.Ex("Message")
            End If
        Catch ex As Exception
            Dim Msg As String = Nothing
            If Not IsNothing(Obj_G_D.Ex) Then
                Msg = Obj_G_D.Ex("Message")
            End If
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            Lbl_Mensage.Text = Msg & "; " & Obj_G_D.Ex("Message")
        End Try
    End Sub
#End Region
#Region "Métodos"
    Private Sub Cargar_Drls()
        With Drl_Agent
            .DataSource = Obj_General.consultaagenteescala()
            .DataTextField = "nombreu"
            .DataValueField = "idusuario"
            .DataBind()
            Obj_G_D.Gest_Drl(Drl_Agent)
        End With
        With Drl_Camp
            .DataSource = Obj_Voz.Consulta_Campaña_Report_Falla()
            .DataTextField = "Campaña"
            .DataValueField = "Campaña"
            .DataBind()
            Obj_G_D.Gest_Drl(Drl_Camp)
        End With
        With Drl_Agent_Dev
            .DataSource = Obj_General.consultaagenteescala()
            .DataTextField = "nombreu"
            .DataValueField = "idusuario"
            .DataBind()
            Obj_G_D.Gest_Drl(Drl_Agent_Dev)
        End With
        With Drl_Camp_Dev
            .DataSource = Obj_Voz.Consulta_Campaña_Report_Falla()
            .DataTextField = "Campaña"
            .DataValueField = "Campaña"
            .DataBind()
            Obj_G_D.Gest_Drl(Drl_Camp_Dev)
        End With
    End Sub
    Private Sub Consultar_Agentes_Asignados()
        ViewState("Dtg_ConsAgentAsig") = Obj_Voz.Consultar_Agentes_En_Escalamiento()
        Dtg_ConsAgentAsig.DataSource = ViewState("Dtg_ConsAgentAsig")
        Dtg_ConsAgentAsig.DataBind()
        Obj_Voz.consultapteasignartotal()
        lblcantidadtot.Text = Obj_Voz.cantidad
    End Sub
    Private Sub Limpiar_ConsDev()
        Pnl_ConsCasDev.Visible = False
        ViewState("Dtg_ConsCasDev") = Nothing
        Lbl_CountConsCasDev.Text = Nothing
        Limpiar_ConsGestDev()
    End Sub
    Private Sub Limpiar_ConsGestDev()
        Pnl_ConsGestDev.Visible = False
        ViewState("Dtg_ConsGestDev") = Nothing
        Lbl_CountConsGestDev.Text = Nothing
        Lbl_ConsGestDevId.Text = Nothing
    End Sub
    Private Sub Contar_CasosDevueltos()
        Lbl_Cas_Dev.Text = Obj_Voz.Consultar_Casos_Tecnica_Devueltos().Rows.Count
    End Sub
#End Region
#Region "Btn's"
    Protected Sub Btn_Cons_Cas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Cons_Cas.Click
        Try
            Obj_G_D.Validar_Herramientas(txtcaso, "Asignar Caso", "Numeric", 1, , False)
            If txtcaso.Text = Nothing Then
                Obj_G_D.Validar_Herramientas(Txb_Num_Cas, "Casos a Asignar", "Numeric", 1, 1000, True)
            Else
                Obj_G_D.Validar_Herramientas(Txb_Num_Cas, "Casos a Asignar", "Numeric", 1, 1000, False)
            End If
            Obj_G_D.Validar_Herramientas(Txb_Fech_Ini, "Rango de Fecha Inicial", "Date", "01/01/1900", Txb_Fech_Fin.Text, False)
            Obj_G_D.Validar_Herramientas(Txb_Fech_Fin, "Rango de Fechas Final", "Date", Txb_Fech_Ini.Text, Now, False)
            Obj_Voz.caso = txtcaso.Text
            Obj_Voz.cantidad = Txb_Num_Cas.Text
            Obj_Voz.fcfin = Txb_Fech_Fin.Text
            Obj_Voz.fcini = Txb_Fech_Ini.Text
            Obj_Voz.campana = Drl_Camp.SelectedItem.Value
            ViewState("Dtg_ConsCas") = Obj_Voz.Consultar_Casos_Sin_Asignar()
            If ViewState("Dtg_ConsCas").Rows.Count > 0 Then
                Pnl_Grid_Cas.Visible = True
                Dtg_ConsCas.DataSource = ViewState("Dtg_ConsCas")
                Dtg_ConsCas.DataBind()
                lblcantidad.Text = ViewState("Dtg_ConsCas").Rows.Count
            Else
                Pnl_Message.CssClass = "alert alert-info"
                Lbl_Mensage.Text = "<span class='glyphicon glyphicon-info-sign'></span> No se encontraron registros que coinsidan con su criterio de búsqueda"
                Pnl_Grid_Cas.Visible = False
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_Asig_Cas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Asig_Cas.Click
        Try
            Obj_Voz.idusuario = CType(Session("permisos"), clsusuario).usuario
            Obj_Voz.idusuarioasignado = Drl_Agent.SelectedItem.Value
            If txtcaso.Text <> Nothing Then
                Obj_Voz.caso = txtcaso.Text
                If Obj_Voz.Asignar_Caso() <= 0 Then
                    Throw New Exception("La asignación individual no se pudo realizar")
                End If
                Pnl_Message.CssClass = "alert alert-success"
                Lbl_Mensage.Text = "<span class='glyphicon glyphicon-ok-circle'></span> Asignación individual realizada con éxito"
            Else
                Dim Warning As String = Nothing
                For Each row As GridViewRow In Dtg_ConsCas.Rows
                    Obj_Voz.caso = row.Cells(1).Text
                    If Obj_Voz.Asignar_Caso() <= 0 Then
                        If Warning = Nothing Then
                            Warning = "No han podido asignar los caso: " & row.Cells(1).Text
                        Else
                            Warning = Warning & ", " & row.Cells(1).Text
                        End If
                    End If
                Next
                If Warning <> Nothing Then
                    Throw New Exception(Warning)
                End If
                Pnl_Message.CssClass = "alert alert-success"
                Lbl_Mensage.Text = "<span class='glyphicon glyphicon-ok-circle'></span> Asignación masiva realizada con éxito"
            End If
            Dtg_ConsCas.DataSource = Nothing
            Dtg_ConsCas.DataBind()
            lblcantidad.Text = Nothing
            Pnl_Grid_Cas.Visible = False
            Consultar_Agentes_Asignados()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        Try
            txtcaso.Text = Nothing
            Txb_Num_Cas.Text = Nothing
            Txb_Fech_Fin.Text = Nothing
            Txb_Fech_Ini.Text = Nothing
            Obj_G_D.Gest_Drl(Drl_Camp)
            Obj_G_D.Gest_Drl(Drl_Agent)
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_Export_Cas_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Export_Cas.Click
        Try
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim tabla As New Table()
            Dim tr1 As New TableRow()
            Dim cell1 As New TableCell()
            Dim Val As Boolean = False
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            If Dtg_ConsCas.Rows.Count <= 0 Then
                Throw New Exception("¡No se encontraron registros para realizar la exportacion!")
            End If
            Dtg_ConsCas.AllowPaging = False
            Dtg_ConsCas.DataSource = ViewState("Dtg_ConsCas")
            Dtg_ConsCas.DataBind()
            cell1.Controls.Add(Dtg_ConsCas)
            tr1.Cells.Add(cell1)
            tabla.Rows.Add(tr1)
            tabla.RenderControl(hw)
            Dtg_ConsCas.AllowPaging = True
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("Content-Disposition", "attachment;filename=Reporte de casos.xls")
            Response.Charset = "UTF-8"
            Response.ContentType = "application/vnd.ms-excel"
            Response.ContentEncoding = System.Text.ASCIIEncoding.UTF8
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.End()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_Consultar_Casos_Devueltos_Click(sender As Object, e As EventArgs) Handles Btn_Consultar_Casos_Devueltos.Click
        Try
            Obj_G_D.Validar_Herramientas(Txb_Cod_Cas_Dev, "Cod Caso", "Numeric", 1, , False)
            If Txb_Cod_Cas_Dev.Text = Nothing Then
                Obj_G_D.Validar_Herramientas(Txb_Num_Cas_Dev, "Número de casos", "Numeric", 1, 1000, True)
            Else
                Obj_G_D.Validar_Herramientas(Txb_Num_Cas_Dev, "Número de casos", "Numeric", 1, 1000, False)
            End If
            Obj_G_D.Validar_Herramientas(Txb_Fech_Ini_Dev, "Rango de fecha inicial", "Date", "01/01/1900", Txb_Fech_Fin_Dev.Text, False)
            Obj_G_D.Validar_Herramientas(Txb_Fech_Fin_Dev, "Rango de fecha final", "Date", Txb_Fech_Ini_Dev.Text, Now.Date, False)

            Obj_Voz.caso = Txb_Cod_Cas_Dev.Text
            Obj_Voz.cantidad = Txb_Num_Cas_Dev.Text
            Obj_Voz.campana = Drl_Camp_Dev.SelectedValue
            Obj_Voz.fcini = Txb_Fech_Ini_Dev.Text
            Obj_Voz.fcfin = Txb_Fech_Fin_Dev.Text
            ViewState("Dtg_ConsCasDev") = Obj_Voz.Consultar_Casos_Tecnica_Devueltos()
            ViewState("Dtg_ConsCasDev").Columns.Add("Check", GetType(Boolean))
            For Each Row As DataRow In ViewState("Dtg_ConsCasDev").Rows
                Row.Item("Check") = False
            Next
            Lbl_CountConsCasDev.Text = ViewState("Dtg_ConsCasDev").Rows.Count
            If ViewState("Dtg_ConsCasDev").Rows.Count > 0 Then
                Dtg_ConsCasDev.DataSource = ViewState("Dtg_ConsCasDev")
                Dtg_ConsCasDev.DataBind()
                Pnl_ConsCasDev.Visible = True
            Else
                Pnl_ConsCasDev.Visible = False
                Pnl_Message.CssClass = "alert alert-info"
                Lbl_Mensage.Text = "<span class='glyphicon glyphicon-info-sign'></span> No se  encontraron registros que coincidan con su criterio de búsqueda"
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Private Sub Btn_Asignar_Casos_Devueltos_Click(sender As Object, e As EventArgs) Handles Btn_Asignar_Casos_Devueltos.Click
        Try
            For Each Row As DataRow In ViewState("Dtg_ConsCasDev").Rows
                If Not Row.Item("Check") Then
                    Throw New Exception("No ha chekeado casos para asignar")
                End If
            Next
            Obj_Voz.idusuarioasignado = Drl_Agent_Dev.SelectedItem.Value
            Obj_Voz.idusuario = CType(Session("permisos"), clsusuario).usuario
            Dim Warning As String = Nothing
            If TypeOf ViewState("Dtg_ConsCasDev") Is DataTable Then
                For Each Row As DataRow In ViewState("Dtg_ConsCasDev").Rows
                    If Row.Item("Check") Then
                        Obj_Voz.caso = Row.Item("IdCaso")
                        If Obj_Voz.Asignar_Caso_Devuelto() <= 0 Then
                            If Warning = Nothing Then
                                Warning = "No han podido asignar los caso: " & Row.Item("IdCaso")
                            Else
                                Warning = ", " & Row.Item("IdCaso")
                            End If
                        End If
                    End If
                Next
                Contar_CasosDevueltos()
                Limpiar_ConsDev()
                Pnl_Message.CssClass = "alert alert-success"
                Lbl_Mensage.Text = "<span class='glyphicon glyphicon-ok-sign'></span> la asignación ha sido exitosa"
                If Warning <> Nothing Then
                    Throw New Exception(Warning)
                End If
            Else
                Pnl_Message.CssClass = "alert alert-info"
                Lbl_Mensage.Text = "<span class='glyphicon glyphicon-info-sign'></span> Primero debe realizar un filtro de consulta para poder asignar casos"
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Private Sub Btn_Limpiar_Filtro_Develtos_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar_Filtro_Develtos.Click
        Try
            Txb_Cod_Cas_Dev.Text = Nothing
            Txb_Num_Cas_Dev.Text = Nothing
            Txb_Fech_Fin_Dev.Text = Nothing
            Txb_Fech_Ini_Dev.Text = Nothing
            Obj_G_D.Gest_Drl(Drl_Camp_Dev)
            Obj_G_D.Gest_Drl(Drl_Agent_Dev)
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
#End Region
#Region "Dtg's"
    'Paginado de datagrids
    Private Sub dtgestad_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Dtg_ConsAgentAsig.PageIndexChanging
        Try
            Dtg_ConsAgentAsig.PageIndex = e.NewPageIndex 'asigna la consulta a la grilla por paginas
            Dtg_ConsAgentAsig.DataSource = ViewState("Dtg_ConsAgentAsig")
            Dtg_ConsAgentAsig.DataBind()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Private Sub dtggeneral_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Dtg_ConsCas.PageIndexChanging
        Try
            Dtg_ConsCas.PageIndex = e.NewPageIndex 'asigna la consulta a la grilla por paginas
            Dtg_ConsCas.DataSource = ViewState("Dtg_ConsCas")
            Dtg_ConsCas.DataBind()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Private Sub Dtg_ConsCasDev_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles Dtg_ConsCasDev.PageIndexChanging
        Try
            Dtg_ConsCasDev.PageIndex = e.NewPageIndex
            Dtg_ConsCasDev.DataSource = ViewState("Dtg_ConsCasDev")
            Dtg_ConsCasDev.DataBind()
            If Dtg_ConsCasDev.Rows.Count > 0 And ViewState("Dtg_ConsCasDev").Rows.Count > 0 Then

                For Row As Integer = 0 To Dtg_ConsCasDev.Rows.Count - 1
                    For I As Integer = 0 To Dtg_ConsCasDev.Columns.Count - 1
                        If Dtg_ConsCasDev.Columns(I).HeaderText = "Id Caso" Then
                            For Each DttRow As DataRow In ViewState("Dtg_ConsCasDev").Rows
                                If DttRow.Item("IdCaso") = Integer.Parse(Dtg_ConsCasDev.Rows(Row).Cells(I).Text) Then
                                    DirectCast(Dtg_ConsCasDev.Rows(Row).FindControl("Check"), CheckBox).Checked = DttRow.Item("Check")
                                    Exit For
                                End If
                            Next
                            Exit For
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Private Sub Dtg_ConsGestDev_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles Dtg_ConsGestDev.PageIndexChanging
        Try
            Dtg_ConsGestDev.PageIndex = e.NewPageIndex
            Dtg_ConsGestDev.DataSource = ViewState("Dtg_ConsGestDev")
            Dtg_ConsGestDev.DataBind()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
#End Region
#Region "Dtg.RowCommand"
    Protected Sub Dtg_ConsCasDev_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Dtg_ConsCasDev.RowCommand
        Try
            Dim Index As Integer = Convert.ToInt32(e.CommandArgument)
            Select Case e.CommandName
                Case "Ver_Gestiones"
                    For I As Integer = 0 To Dtg_ConsCasDev.Columns.Count - 1
                        If Dtg_ConsCasDev.Columns(I).HeaderText = "Id Caso" Then
                            Obj_Voz.caso = Int64.Parse(Dtg_ConsCasDev.Rows(Index).Cells(I).Text)
                            Lbl_ConsGestDevId.Text = Obj_Voz.caso
                            Exit For
                        End If
                    Next
                    ViewState("Dtg_ConsGestDev") = Obj_Voz.Consultar_Gestiones_Casos_Tecnica_Devueltos()
                    Lbl_CountConsGestDev.Text = ViewState("Dtg_ConsGestDev").rows.count
                    If ViewState("Dtg_ConsGestDev").rows.count > 0 Then
                        Dtg_ConsGestDev.DataSource = ViewState("Dtg_ConsGestDev")
                        Dtg_ConsGestDev.DataBind()
                        Pnl_ConsGestDev.Visible = True
                    Else
                        Pnl_ConsGestDev.Visible = False
                        Pnl_Message.CssClass = "alert alert-info"
                        Lbl_Mensage.Text = "<span class='glyphicon glyphicon-info-sign'></span> No se encontraron gestiones del caso"
                    End If
            End Select
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
#End Region
#Region "Check.'s"
    Private Sub Check_All_CheckedChanged(sender As Object, e As EventArgs) Handles Check_All.CheckedChanged
        Try
            For Each row As GridViewRow In Dtg_ConsCasDev.Rows
                Dim Ch As CheckBox = DirectCast(row.FindControl("Check"), CheckBox)
                If Ch IsNot Nothing Then
                    Ch.Checked = Check_All.Checked
                End If
            Next
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
#End Region
End Class