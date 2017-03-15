Imports System.Net
Public Class Desarrollo_Asignacion
    Inherits System.Web.UI.Page
    Dim ObjDesarrollo As New ClsDesarrollo
    Dim Objeto_Gestion_Datos As New Cls_Gestion_Datos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Asignación de Desarrollos"
                ObjDesarrollo.IdUsuario = CType(Session("permisos"), clsusuario).usuario
                ViewState("Consulta.Asignacion") = ObjDesarrollo.Consulta_Desarrollos_Sin_Asignar()
                Dtg_Desarrollos.DataSource = ViewState("Consulta.Asignacion")
                Dtg_Desarrollos.DataBind()
                If ObjDesarrollo.Cantidad > 0 Then
                    Lbl_Cantidad.Text = "Numero de Tickets: " & ObjDesarrollo.Cantidad
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
        With Drl_Cons_Prioridad
            ObjDesarrollo.Validacion = "Cargar_Prioridad"
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "Com_Nom"
            .DataValueField = "Com_Cod"
            .DataBind()
        End With
        With Drl_Desarrollador
            ObjDesarrollo.Validacion = "Cargar_Desarrollador"
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "nombreu"
            .DataValueField = "Com_Nom"
            .DataBind()
            .Items.Insert(0, "- Seleccione -")
        End With
    End Sub
    Protected Sub Btn_Filtrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Filtrar.Click
        ObjDesarrollo.Codigo = Txt_Cons_Codigo.Text
        If Drl_Cons_Prioridad.SelectedItem.Text = "- Seleccione -" Then
            ObjDesarrollo.Prioridad = ""
        Else
            ObjDesarrollo.Prioridad = Drl_Cons_Prioridad.SelectedItem.Text
        End If
        ObjDesarrollo.Fecha_Inicio = Txt_Fc_Inicio.Text
        If Txt_Fc_Fin.Text = "" Then
            ObjDesarrollo.Fecha_Fin = ""
        Else
            ObjDesarrollo.Fecha_Fin = Txt_Fc_Fin.Text & " 23:59:59"
        End If
        If ObjDesarrollo.Prioridad = "" And (ObjDesarrollo.Fecha_Fin = "" Or ObjDesarrollo.Fecha_Inicio = "") And ObjDesarrollo.Codigo = "" Then
            Pnl_Message.CssClass = "alert alert-warning"
            lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> ¡Consulta sin filtro!"
        Else
            'PnlFiltros.Visible = False
            'PnlAsignar.Visible = True

            ViewState("Consulta.Asignacion") = ObjDesarrollo.Consulta_Desarrollos_Sin_Asignar()
            Dtg_Desarrollos.DataSource = ViewState("Consulta.Asignacion")
            Dtg_Desarrollos.DataBind()
            Lbl_Cantidad.Text = ObjDesarrollo.Cantidad
            If ObjDesarrollo.Cantidad > 0 Then
                Lbl_Cantidad.Text = "Numero de Tickets: " & ObjDesarrollo.Cantidad
            Else
                Lbl_Cantidad.Text = Nothing
            End If
        End If

    End Sub
    Protected Sub Btn_Cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Cancelar.Click
        PnlAsignar.Visible = False
        PnlFiltros.Visible = True
        Drl_Desarrollador.SelectedIndex = 0
        Txt_Codigo.Text = ""
        Txt_Tema.Text = ""
        Txt_Requerimientos.Text = ""
        ViewState("Consulta.Asignacion") = ObjDesarrollo.Consulta_Desarrollos_Sin_Asignar()
        Dtg_Desarrollos.DataSource = ViewState("Consulta.Asignacion")
        Dtg_Desarrollos.DataBind()
        If ObjDesarrollo.Cantidad > 0 Then
            Lbl_Cantidad.Text = "Numero de Tickets: " & ObjDesarrollo.Cantidad
        Else
            Lbl_Cantidad.Text = Nothing
        End If
    End Sub
    Public Sub Limpiar()
        Txt_Tema.Text = Nothing
        Txt_Requerimientos.Text = Nothing
        Txt_Codigo.Text = Nothing
        Txt_Cons_Codigo.Text = Nothing
        Txt_Fc_Fin.Text = Nothing
        Txt_Fc_Inicio.Text = Nothing
        Drl_Cons_Prioridad.SelectedIndex = 0
        Drl_Desarrollador.SelectedIndex = 0
    End Sub
    Protected Sub Btn_Asignar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Asignar.Click
        Dim ObjDesarrollo As New ClsDesarrollo
        ObjDesarrollo.IdUsuario = CType(Session("permisos"), clsusuario).usuario
        If Txt_Codigo.Text = "" Then
            Txt_Codigo.Text = ""
            Pnl_Message.CssClass = "alert alert-warning"
            lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> ¡No se encontro ningun codigo de Desarrollo a asignar!"
            Exit Sub
        Else
            ObjDesarrollo.Codigo = Txt_Codigo.Text
        End If
        If Drl_Desarrollador.SelectedIndex = 0 Then
            ObjDesarrollo.Desarrollador = ""
            Pnl_Message.CssClass = "alert alert-warning"
            lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span>¡Debe seleccionar un Desarrollador a asignar!"
            Exit Sub
        Else
            ObjDesarrollo.Desarrollador = Drl_Desarrollador.SelectedItem.Value
        End If
        ObjDesarrollo.Actualizar_Estado_Desarrollo()
        Pnl_Message.CssClass = "alert alert-success"
        lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> ¡Asignacion realizada exitosamente!"
        Limpiar()
        ObjDesarrollo.Codigo = Nothing
        ObjDesarrollo.IdUsuario = Nothing
        ObjDesarrollo.Desarrollador = Nothing
        ViewState("Consulta.Asignacion") = ObjDesarrollo.Consulta_Desarrollos_Sin_Asignar()
        Dtg_Desarrollos.DataSource = ViewState("Consulta.Asignacion")
        Dtg_Desarrollos.DataBind()
        Lbl_Cantidad.Text = ObjDesarrollo.Cantidad
        If ObjDesarrollo.Cantidad > 0 Then
            PnlFiltros.Visible = True
        Else
            PnlFiltros.Visible = False
        End If
        Btn_Cancelar_Click(sender, e)
    End Sub
    Protected Sub Dtg_Desarrollos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Dtg_Desarrollos.RowCommand
        Dim Dt As DataTable = New DataTable()
        Dim Index As Integer
        Try
            Select Case e.CommandName
                Case "Seleccionar"
                    Index = Convert.ToInt32(e.CommandArgument)
                    Txt_Codigo.Text = HttpUtility.HtmlDecode(Dtg_Desarrollos.Rows(Index).Cells(0).Text)
                    Txt_Tema.Text = HttpUtility.HtmlDecode(Dtg_Desarrollos.Rows(Index).Cells(4).Text)
                    Txt_Requerimientos.Text = HttpUtility.HtmlDecode(Dtg_Desarrollos.Rows(Index).Cells(7).Text)
                    PnlAsignar.Visible = True
                    PnlFiltros.Visible = False
            End Select
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>  & ex.Message ¡Error! " & Index & ex.Message
        End Try
    End Sub
    Protected Sub Dtg_Desarrollos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Dtg_Desarrollos.PageIndexChanging
        Try
            Dtg_Desarrollos.DataSource = ViewState("Consulta.Asignacion")
            Dtg_Desarrollos.PageIndex = e.NewPageIndex
            Dtg_Desarrollos.DataBind()
            Lbl_Cantidad.Text = ObjDesarrollo.Cantidad
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>  & ex.Message ¡Error! " & ex.Message
        End Try
    End Sub

End Class