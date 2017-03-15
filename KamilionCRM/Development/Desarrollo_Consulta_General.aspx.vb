Imports System.IO
Public Class Desarrollo_Consulta_General
    Inherits System.Web.UI.Page
    Dim ObjDesarrollo As New ClsDesarrollo
    Dim Objeto_Gestion_Datos As New Cls_Gestion_Datos
    Dim objdatos As New clsgeneral

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Consulta Géneral de Desarrollos"
                ObjDesarrollo.IdUsuario = CType(Session("permisos"), clsusuario).usuario
                ObjDesarrollo.Validacion = "Desarrollo_Registro"
                ViewState("Consulta.General") = ObjDesarrollo.Consulta_Desarrollos_General()
                Dtg_Desarrollos.DataSource = ViewState("Consulta.General")
                Dtg_Desarrollos.DataBind()
                If ObjDesarrollo.Cantidad > 0 Then
                    Lbl_Cantidad.Text = "Desarrollos: " & ObjDesarrollo.Cantidad
                Else
                    Lbl_Cantidad.Text = Nothing
                End If
                Cargar_Drls()
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Public Sub Cargar_Drls()
        With Drl_Cons_Pri
            ObjDesarrollo.Validacion = "Cargar_Prioridad"
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "Com_Nom"
            .DataValueField = "Com_Cod"
            .DataBind()
        End With
        With Drl_Cons_Est
            ObjDesarrollo.Validacion = "Cargar_Estado"
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "Com_Nom"
            .DataValueField = "Com_Cod"
            .DataBind()
        End With
        With Drl_Cons_Are
            ObjDesarrollo.Validacion = "Cargar_Area"
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "Com_Nom"
            .DataValueField = "Com_Cod"
            .DataBind()
        End With
        With Drl_Desarrollador
            ObjDesarrollo.Validacion = "Cargar_Desarrollador"
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "nombreu"
            .DataValueField = "Com_nom"
            .DataBind()
            .Items.Insert(0, "- Seleccione -")
        End With
    End Sub
    Public Sub Limpiar()
        Txt_Tema.Text = Nothing
        Txt_Requerimientos.Text = Nothing
        Txt_Codigo.Text = Nothing
        Txt_Area.Text = Nothing
        Txt_Fc_Reg.Text = Nothing
        Txt_Prioridad.Text = Nothing
        Txt_Cons_Cod.Text = Nothing
        Txt_Cons_FcFin.Text = Nothing
        Txt_Cons_FcIni.Text = Nothing
        Txt_Solicitante.Text = Nothing
        Txt_Tema.Text = Nothing
        Drl_Cons_Est.SelectedIndex = 0
        Drl_Cons_Pri.SelectedIndex = 0
    End Sub
    Protected Sub Btn_Volver_Click(sender As Object, e As EventArgs) Handles Btn_Volver.Click
        Try
            Pnl_Informacion.Visible = False
            Pnl_Filtros.Visible = True
            Limpiar()
            Dim ObjDesarrollo As New ClsDesarrollo
            ObjDesarrollo.IdUsuario = CType(Session("permisos"), clsusuario).usuario
            ObjDesarrollo.Codigo = Nothing
            ObjDesarrollo.Validacion = "Desarrollo_Registro"
            ViewState("Consulta.General") = ObjDesarrollo.Consulta_Desarrollos_General()
            Dtg_Desarrollos.DataSource = ViewState("Consulta.General")
            Dtg_Desarrollos.DataBind()
            Lbl_Cantidad.Text = "Desarrollos: " & ObjDesarrollo.Cantidad
            If ObjDesarrollo.Cantidad > 0 Then
                Pnl_Dtg_Desarrollos.Visible = True
            Else
                Pnl_Dtg_Desarrollos.Visible = False
            End If
            Dtg_Gestiones.DataSource = Nothing
            Dtg_Gestiones.DataBind()
            Pnl_Dtg_Gestiones.Visible = False
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> ¡Error! " & ex.Message
        End Try
    End Sub
    Protected Sub Dtg_Desarrollos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Dtg_Desarrollos.RowCommand
        Dim Dt As DataTable = New DataTable()
        Limpiar()
        Dim Index As Integer
        Try
            Select Case e.CommandName
                Case "Seleccionar"
                    Index = Convert.ToInt32(e.CommandArgument)
                    Txt_Codigo.Text = Dtg_Desarrollos.Rows(Index).Cells(0).Text
                    Txt_Fc_Reg.Text = Dtg_Desarrollos.Rows(Index).Cells(1).Text
                    Txt_Tema.Text = HttpUtility.HtmlDecode(Dtg_Desarrollos.Rows(Index).Cells(4).Text)
                    Txt_Prioridad.Text = Dtg_Desarrollos.Rows(Index).Cells(5).Text
                    Txt_Area.Text = HttpUtility.HtmlDecode(Dtg_Desarrollos.Rows(Index).Cells(6).Text)
                    Txt_Solicitante.Text = HttpUtility.HtmlDecode(Dtg_Desarrollos.Rows(Index).Cells(7).Text)
                    Txt_Requerimientos.Text = HttpUtility.HtmlDecode(Dtg_Desarrollos.Rows(Index).Cells(8).Text)
                    Dim ObjDesarrollo As New ClsDesarrollo
                    ObjDesarrollo.Validacion = "Desarrollo_Gestion"
                    ObjDesarrollo.Codigo = Dtg_Desarrollos.Rows(Index).Cells(0).Text
                    ViewState("Consulta2") = ObjDesarrollo.Consulta_Desarrollos_General
                    Dtg_Gestiones.DataSource = ViewState("Consulta2")
                    Dtg_Gestiones.DataBind()
                    Lbl_Cantidad2.Text = "Desarrollos: " & ObjDesarrollo.Cantidad
                    Pnl_Informacion.Visible = True
                    Pnl_Filtros.Visible = False
                    Pnl_Dtg_Desarrollos.Visible = False
                    If ObjDesarrollo.Cantidad > 0 Then
                        Pnl_Dtg_Gestiones.Visible = True
                    Else
                        Pnl_Dtg_Gestiones.Visible = True
                        Lbl_Cantidad2.Text = "No se encontro ninguna gestion de dicho Desarrollo"
                    End If
            End Select
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> ¡Error! " & ex.Message
        End Try
    End Sub

    Protected Sub Btn_Filtrar_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar.Click
        Try
            If Txt_Cons_Cod.Text = "" And Drl_Cons_Pri.SelectedIndex = 0 And Drl_Cons_Est.SelectedIndex = 0 And Drl_Desarrollador.SelectedIndex = 0 And Drl_Cons_Are.SelectedIndex = 0 And Txt_Cons_FcIni.Text = "" And Txt_Cons_FcFin.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> ¡Consulta sin filtro!"
            End If
            If Txt_Cons_Cod.Text <> "" Then
                ObjDesarrollo.Codigo = Txt_Cons_Cod.Text
            Else
                ObjDesarrollo.Codigo = ""
            End If
            If Drl_Cons_Pri.SelectedIndex <> 0 Then
                ObjDesarrollo.Prioridad = Drl_Cons_Pri.SelectedItem.Text
            Else
                ObjDesarrollo.Prioridad = ""
            End If
            If Drl_Cons_Est.SelectedIndex <> 0 Then
                ObjDesarrollo.Estado = Drl_Cons_Est.SelectedItem.Value
            Else
                ObjDesarrollo.Estado = ""
            End If
            If Drl_Cons_Are.SelectedIndex <> 0 Then
                ObjDesarrollo.Area = Drl_Cons_Are.SelectedItem.Value
            Else
                ObjDesarrollo.Area = ""
            End If
            If Drl_Desarrollador.SelectedIndex <> 0 Then
                ObjDesarrollo.Desarrollador = Drl_Desarrollador.SelectedItem.Value
            Else
                ObjDesarrollo.Desarrollador = ""
            End If
            If Txt_Cons_FcIni.Text <> "" Then
                ObjDesarrollo.Fecha_Inicio = Txt_Cons_FcIni.Text & " 00:00:00"
            Else
                ObjDesarrollo.Fecha_Inicio = ""
            End If
            If Txt_Cons_FcFin.Text <> "" Then
                ObjDesarrollo.Fecha_Fin = Txt_Cons_FcFin.Text & " 23:59:59"
            Else
                ObjDesarrollo.Fecha_Fin = ""
            End If
            ObjDesarrollo.Validacion = "Desarrollo_Registro"
            ViewState("Consulta.General") = ObjDesarrollo.Consulta_Desarrollos_General()
            Dtg_Desarrollos.DataSource = Session("Consulta.General")
            Dtg_Desarrollos.DataBind()
            If ObjDesarrollo.Cantidad > 0 Then
                Lbl_Cantidad.Text = "Desarrollos: " & ObjDesarrollo.Cantidad
            Else
                Lbl_Cantidad.Text = "¡No se encontraron coincidencias en la busqueda!"
            End If
            Pnl_Dtg_Desarrollos.Visible = True
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>  ¡Error! " & ex.Message
        End Try
    End Sub
    Protected Sub Exportar_Click(sender As Object, e As EventArgs) Handles Btn_Exportar_Solic.Click, Btn_Exportar_Gest.Click
        Try
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim tabla As New Table()
            Dim tr1 As New TableRow()
            Dim cell1 As New TableCell()
            Dim Val As Boolean = False
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            If Pnl_Informacion.Visible = True Then
                If Dtg_Gestiones.Rows.Count > 0 Then
                    Val = True
                    Dtg_Gestiones.AllowPaging = False
                    Dtg_Gestiones.DataSource = ViewState("Consulta2")
                    Dtg_Gestiones.DataBind()
                    cell1.Controls.Add(Dtg_Gestiones)
                    tr1.Cells.Add(cell1)
                    tabla.Rows.Add(tr1)
                    tabla.RenderControl(hw)
                    Dtg_Gestiones.AllowPaging = True
                Else
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> ¡No se encontraron registros para realizar la exportación! "

                End If
            Else
                If Dtg_Desarrollos.Rows.Count > 0 Then
                    Val = True
                    Dtg_Desarrollos.Columns(Dtg_Desarrollos.Columns.Count - 1).Visible = False
                    cell1.Controls.Add(Dtg_Desarrollos)
                    tr1.Cells.Add(cell1)
                    tabla.Rows.Add(tr1)
                    tabla.RenderControl(hw)
                    Dtg_Desarrollos.Columns(Dtg_Desarrollos.Columns.Count - 1).Visible = True
                Else
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> ¡No se encontraron registros para realizar la exportación! "
                End If
            End If
            If Val = True Then
                Response.Clear()
                Response.Buffer = True
                Response.AddHeader("Content-Disposition", "attachment;filename=Reporte Solicitudes de Desarrollo.xls")
                Response.Charset = "UTF-8"
                Response.ContentType = "application/vnd.ms-excel"
                Response.ContentEncoding = System.Text.ASCIIEncoding.UTF8
                Response.Write(style)
                Response.Output.Write(sw.ToString())
                Response.Flush()
                Response.End()
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>  ¡Error! " & ex.Message
        End Try
    End Sub

    Protected Sub Dtg_Gestiones_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Dtg_Gestiones.PageIndexChanging
        Try
            Dtg_Gestiones.DataSource = ViewState("Consulta2")
            Dtg_Gestiones.PageIndex = e.NewPageIndex
            Dtg_Gestiones.DataBind()
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>  ¡Error! " & ex.Message
        End Try
    End Sub
End Class