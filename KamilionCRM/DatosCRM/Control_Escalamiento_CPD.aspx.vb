Imports System.IO
Public Class Control_Escalamiento_CPD
    Inherits System.Web.UI.Page
    Dim objGeneral As New clsgeneral
    Dim Objdatos As New clscrmdatos
    Dim Obj_G_D As New Cls_Gestion_Datos
#Region "Page"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Control Escalamiento CPD"
                Cargar_DRLS()
                Consultar_Asignados()
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "P", "Pleg_Loading();", True)
        If Not IsNothing(Obj_G_D.Ex) Then
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End If
    End Sub
#End Region
#Region "Métoddos"
    Protected Sub Cargar_DRLS()
        Objdatos.Validacion = "Agentes"
        With Drl_Agente
            .DataSource = Objdatos.Cargar_DRLS_Control()
            .DataTextField = "nombreu"
            .DataValueField = "idusuario"
            .DataBind()
            Obj_G_D.Gest_Drl(Drl_Agente)
        End With
        Objdatos.Validacion = "Estado_Caso"
        With Drl_EstadoCPD
            .DataSource = Objdatos.Cargar_DRLS_Control()
            .DataTextField = "Nombre"
            .DataValueField = "Codigo"
            .DataBind()
            Obj_G_D.Gest_Drl(Drl_EstadoCPD)
        End With
        Objdatos.Validacion = "Estado_Remedy"
        With Drl_EstadoRemedy
            .DataSource = Objdatos.Cargar_DRLS_Control()
            .DataTextField = "Nombre"
            .DataValueField = "Codigo"
            .DataBind()
            Obj_G_D.Gest_Drl(Drl_EstadoRemedy)
        End With
        Objdatos.Validacion = "Bandejas"
        With Drl_Bandeja
            .DataSource = Objdatos.Cargar_DRLS_Control()
            .DataTextField = "Nombre"
            .DataValueField = "Codigo"
            .DataBind()
            Obj_G_D.Gest_Drl(Drl_Bandeja)
        End With
    End Sub
    Private Sub Consultar_Asignados()
        ViewState("Dtg_Estad") = Objdatos.Cons_Asignacion_Control_CPD()
        Dtg_Estad.DataSource = ViewState("Dtg_Estad")
        Dtg_Estad.DataBind()
    End Sub
#End Region
#Region "Btn's"
    Protected Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click
        Try
            Dim Filtro As New Dictionary(Of String, Object)
            If Txt_Top.Text <> Nothing Then
                Filtro.Add("Top", Txt_Top.Text)
            End If
            If Txt_Caso.Text <> Nothing Then
                Filtro.Add("Caso", Txt_Caso.Text)
            End If
            If Drl_EstadoCPD.SelectedIndex > 0 Then
                Filtro.Add("EstadoCPD", Drl_EstadoCPD.SelectedItem.Text)
            End If
            If Drl_EstadoRemedy.SelectedIndex > 0 Then
                Filtro.Add("EstadoRemedy", Drl_EstadoRemedy.SelectedItem.Text)
            End If
            If Drl_Bandeja.SelectedIndex > 0 Then
                Filtro.Add("Bandeja", Drl_Bandeja.SelectedItem.Text)
            End If
            If Drl_Respuesta.SelectedIndex > 0 Then
                Filtro.Add("Respuesta", Drl_Respuesta.SelectedItem.Text)
            End If
            If Txt_FRegBandejaIni.Text <> "" Then
                Filtro.Add("FRegBandejaIni", Txt_FRegBandejaIni.Text)
            End If
            If Txt_FRegBandejaFin.Text <> "" Then
                Filtro.Add("FRegBandejaFin", Txt_FRegBandejaFin.Text)
            End If
            If Txt_FRegCpdIni.Text <> Nothing Then
                Filtro.Add("FRegCpdIni", Txt_FRegCpdIni.Text)
            End If
            If Txt_FRegCpdFin.Text <> Nothing Then
                Filtro.Add("FRegCpdFin", Txt_FRegCpdFin.Text)
            End If
            If Filtro.Count <= 0 Then
                Throw New Exception("Seleccione algun filtro de consulta!")
            End If
            Session("Dtg_General") = Objdatos.Cons_Escalamiento_CPD(Filtro)
            Dtg_General.DataSource = Session("Dtg_General")
            Dtg_General.DataBind()
            Lbl_Cuenta.Text = Session("Dtg_General").Rows.Count
            If Session("Dtg_General").Rows.Count <= 0 Then
                Pnl_Message.CssClass = "alert alert-info"
                lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span>No se encontraron registros!"
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_Asignar_Click(sender As Object, e As EventArgs) Handles Btn_Asignar.Click
        Try
            If Drl_Agente.SelectedIndex <= 0 Then
                Throw New Exception("Seleccione un ingeniero para realizar la asignación!")
            End If
            If Dtg_General.Rows.Count() <= 0 Then
                Throw New Exception("Debe realizar una consulta con minimo 1 resultado para realizar la asignación!")
            End If
            Objdatos.idusuarioasignado = Drl_Agente.SelectedItem.Value
            Objdatos.idusuario = CType(Session("permisos"), clsusuario).usuario
            Dim num As Integer = 0
            Dtg_General.AllowPaging = False
            Dtg_General.DataSource = Session("Dtg_General")
            Dtg_General.DataBind()
            For Each Row As GridViewRow In Dtg_General.Rows
                For I As Integer = 0 To Dtg_General.Columns.Count - 1
                    If Dtg_General.Columns(I).HeaderText = "Caso" Then
                        Objdatos.caso = Int64.Parse(Row.Cells(I).Text)
                    End If
                    If Dtg_General.Columns(I).HeaderText = "Bandeja" Then
                        Objdatos.CampanaLogin = Row.Cells(I).Text
                    End If
                Next
                Objdatos.Asignacion_Control("CPD")
                num += 1
            Next
            Dtg_General.AllowPaging = True
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span Class='glyphicon glyphicon-ok-sign'></span> Se asignaron " & num & " casos al ingeniero " & Drl_Agente.SelectedItem.Text & "!"
            Session("Dtg_General") = Nothing
            Dtg_General.DataSource = Session("Dtg_General")
            Dtg_General.DataBind()
            Lbl_Cuenta.Text = 0
            Consultar_Asignados()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_Liberar_Click(sender As Object, e As EventArgs) Handles Btn_Liberar.Click
        Try
            If Drl_Agente.SelectedIndex <= 0 Then
                Throw New Exception("Por favor seleccione un ingeniero para realizar la liberacion!")
            End If
            Dim num As Integer = 0
            Objdatos.Validacion = "AGENTE_CPD"
            Objdatos.idusuarioasignado = Drl_Agente.SelectedItem.Value
            num = Objdatos.Liberacion_Control()
            If num < 1 Then
                Pnl_Message.CssClass = "alert alert-info"
                lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span> El ingeniero " & Drl_Agente.SelectedItem.Text & " no tiene casos para liberar!"
            Else
                Pnl_Message.CssClass = "alert alert-success"
                lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Se liberaron " & num & " casos del ingeniero " & Drl_Agente.SelectedItem.Text & "!"
                Consultar_Asignados()
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_Lib_Mas_Click(sender As Object, e As EventArgs) Handles Btn_Lib_Mas.Click
        Try
            Dim num As Integer = 0
            Objdatos.Validacion = "TODO_CPD"
            num = Objdatos.Liberacion_Control()
            If num < 1 Then
                Pnl_Message.CssClass = "alert alert-info"
                lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span> No hay casos para liberar!"
            Else
                Pnl_Message.CssClass = "alert alert-success"
                lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Se liberaron " & num & " casos!"
            End If
            Consultar_Asignados()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_Exportar_Click(sender As Object, e As EventArgs) Handles Btn_Exportar.Click
        Try
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim tabla As New Table()
            Dim tr1 As New TableRow()
            Dim cell1 As New TableCell()
            Dim Val As Boolean = False
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            If Dtg_General.Rows.Count > 0 And Dtg_General.Rows.Count < 8101 Then
                Val = True
                Dtg_General.AllowPaging = False
                Dtg_General.DataSource = Session("Dtg_General")
                Dtg_General.DataBind()
                cell1.Controls.Add(Dtg_General)
                tr1.Cells.Add(cell1)
                tabla.Rows.Add(tr1)
                tabla.RenderControl(hw)
                Dtg_General.AllowPaging = True
            ElseIf Dtg_General.Rows.Count > 8100 Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> ¡Se denego el permiso de exportacion debido a que exede el limite de registros; Realice otro filtro y reintente exportar! "
            Else
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span Class='glyphicon glyphicon-warning-sign'></span> ¡No se encontraron registros para realizar la exportacion! "
            End If
            If Val = True Then
                Response.Clear()
                Response.Buffer = True
                Response.AddHeader("Content-Disposition", "attachment;filename=Data.xls")
                Response.Charset = "UTF-8"
                Response.ContentType = "application/vnd.ms-excel"
                Response.ContentEncoding = System.Text.ASCIIEncoding.UTF8
                Response.Write(style)
                Response.Output.Write(sw.ToString())
                Response.End()
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        Try
            Drl_EstadoCPD.SelectedIndex = 0
            Drl_Bandeja.SelectedIndex = 0
            Drl_Respuesta.SelectedIndex = 0
            Txt_Top.Text = Nothing
            Txt_Caso.Text = Nothing
            Txt_FRegBandejaIni.Text = Nothing
            Txt_FRegBandejaFin.Text = Nothing
            Txt_FRegCpdIni.Text = Nothing
            Txt_FRegCpdFin.Text = Nothing
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
#End Region
#Region "Dtg's"
    Protected Sub Dtg_General_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Dtg_General.PageIndexChanging
        Try
            Dtg_General.PageIndex = e.NewPageIndex
            Dtg_General.DataSource = Session("Dtg_General")
            Dtg_General.DataBind()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Dtg_Estad_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Dtg_Estad.PageIndexChanging
        Try
            Dtg_Estad.PageIndex = e.NewPageIndex
            Dtg_Estad.DataSource = ViewState("Dtg_Estad")
            Dtg_Estad.DataBind()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
        End Try
    End Sub
#End Region
End Class