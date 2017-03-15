Imports System.Net
Public Class Desarrollo_Gestion
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
                Session("Formulario") = "Gestión de Desarrollos"
                ObjDesarrollo.IdUsuario = CType(Session("permisos"), clsusuario).usuario
                Session("Consulta") = ObjDesarrollo.Consulta_Desarrollos_Asignados()
                Dtg_Desarrollos.DataSource = Session("Consulta")
                Dtg_Desarrollos.DataBind()
                If Session("Consulta").Tables(0).Rows.Count > 0 Then
                    Lbl_Cantidad.Text = "Desarrollos Asignados: " & ObjDesarrollo.Cantidad
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
        With Drl_Complejidad
            ObjDesarrollo.Validacion = "Cargar_Complejidad"
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "Com_Nom"
            .DataValueField = "Com_Cod"
            .DataBind()
        End With
        With Drl_Operatividad
            ObjDesarrollo.Validacion = "Cargar_Operatividad"
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
            .Items.RemoveAt(2)
            .Items.RemoveAt(5)
            .Items.RemoveAt(5)
        End With
        With Drl_Usu_Asig
            ObjDesarrollo.Validacion = "Cargar_Desarrollador"
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "nombreu"
            .DataValueField = "Com_nom"
            .DataBind()
            .Items.Insert(0, "- Seleccione -")
        End With
        With Drl_Cons_Pri
            ObjDesarrollo.Validacion = "Cargar_Prioridad"
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "Com_Nom"
            .DataValueField = "Com_Cod"
            .DataBind()
        End With
        With Drl_Estado
            ObjDesarrollo.Validacion = "Cargar_Estado"
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "Com_Nom"
            .DataValueField = "Com_Cod"
            .DataBind()
            .Items.RemoveAt(1)
            .Items.RemoveAt(1)
        End With
    End Sub
    Public Sub Limpiar()
        Txt_Tema.Text = Nothing
        Txt_Requerimientos.Text = Nothing
        Txt_Codigo.Text = Nothing
        Txt_Area.Text = Nothing
        Txt_Fc_Reg.Text = Nothing
        Txt_Observacion.Text = Nothing
        Txt_Prioridad.Text = Nothing
        Txt_Cons_Cod.Text = Nothing
        Txt_Cons_FcFin.Text = Nothing
        Txt_Cons_FcIni.Text = Nothing
        Txt_Solicitante.Text = Nothing
        Txt_Tema.Text = Nothing
        Drl_Complejidad.SelectedIndex = 0
        Drl_Cons_Est.SelectedIndex = 0
        Drl_Cons_Pri.SelectedIndex = 0
        Drl_Estado.SelectedIndex = 0
        Drl_Operatividad.SelectedIndex = 0
        Drl_Usu_Asig.SelectedIndex = 0
        Pnl_Usu_Esc.Visible = False
        Drl_Complejidad.Enabled = True
        Drl_Operatividad.Enabled = True
    End Sub
    Protected Sub Drl_Estado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Drl_Estado.SelectedIndexChanged
        Drl_Usu_Asig.SelectedIndex = 0
        If Drl_Estado.SelectedItem.Text = "Escalado" Or Drl_Estado.SelectedItem.Text = "Devuelto" Or Drl_Estado.SelectedItem.Text = "Entregado" Then
            Pnl_Usu_Esc.Visible = True
            Drl_Complejidad.Enabled = False
            Drl_Complejidad.SelectedIndex = 0
            Drl_Operatividad.Enabled = False
            Drl_Operatividad.SelectedIndex = 0
        ElseIf Drl_Estado.SelectedItem.Text = "Rechazado" Or Drl_Estado.SelectedItem.Text = "Pendiente" Then
            Drl_Complejidad.Enabled = False
            Drl_Complejidad.SelectedIndex = 0
            Drl_Operatividad.Enabled = False
            Drl_Operatividad.SelectedIndex = 0
        Else
            Pnl_Usu_Esc.Visible = False
            Drl_Complejidad.Enabled = True
            Drl_Operatividad.Enabled = True
        End If
    End Sub
    Protected Sub Btn_Volver_Click(sender As Object, e As EventArgs) Handles Btn_Volver.Click
        Try
            Pnl_Gestion.Visible = False
            Pnl_Filtros.Visible = True
            Limpiar()
            ObjDesarrollo.IdUsuario = CType(Session("permisos"), clsusuario).usuario
            ObjDesarrollo.Codigo = Nothing
            Session("Consulta") = ObjDesarrollo.Consulta_Desarrollos_Asignados()
            Dtg_Desarrollos.DataSource = Session("Consulta")
            Dtg_Desarrollos.DataBind()
            If Session("Consulta").Tables(0).Rows.Count > 0 Then
                Lbl_Cantidad.Text = "Desarrollos Asignados: " & ObjDesarrollo.Cantidad
            Else
                Lbl_Cantidad.Text = Nothing
            End If
            Dtg_Gestiones.DataSource = Nothing
            Dtg_Gestiones.DataBind()
            Pnl_Dtg_Gestiones.Visible = False
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> ¡Error! " & ex.Message
        End Try
    End Sub
    Protected Sub Btn_Filtrar_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar.Click
        Try
            ObjDesarrollo.IdUsuario = CType(Session("permisos"), clsusuario).usuario
            If Txt_Cons_Cod.Text = "" And Txt_Cons_FcFin.Text = "" And Txt_Cons_FcIni.Text = "" And Drl_Cons_Est.SelectedIndex = 0 And Drl_Cons_Pri.SelectedIndex = 0 Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> ¡Consulta sin filtro!"
            End If
            ObjDesarrollo.Codigo = Txt_Cons_Cod.Text
            If Drl_Cons_Pri.SelectedIndex = 0 Then
                ObjDesarrollo.Prioridad = ""
            Else
                ObjDesarrollo.Prioridad = Drl_Cons_Pri.SelectedItem.Text
            End If
            If Drl_Cons_Est.SelectedIndex = 0 Then
                ObjDesarrollo.Estado = ""
            Else
                ObjDesarrollo.Estado = Drl_Cons_Est.SelectedItem.Value
            End If
            ObjDesarrollo.Fecha_Inicio = Txt_Cons_FcIni.Text
            If Txt_Cons_FcFin.Text = "" Then
                ObjDesarrollo.Fecha_Fin = ""
            Else
                ObjDesarrollo.Fecha_Fin = Txt_Cons_FcFin.Text & " 23:59:59"
            End If
            Session("Consulta") = ObjDesarrollo.Consulta_Desarrollos_Asignados()
            Dtg_Desarrollos.DataSource = Session("Consulta")
            Dtg_Desarrollos.DataBind()
            If Session("Consulta").Tables(0).Rows.Count > 0 Then
                Lbl_Cantidad.Text = "Desarrollos Asignados: " & ObjDesarrollo.Cantidad
            Else
                Lbl_Cantidad.Text = Nothing
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>  ¡Error! " & ex.Message
        End Try
    End Sub
    Protected Sub Btn_Guardar_Click(sender As Object, e As EventArgs) Handles Btn_Guardar.Click
        Try
            ObjDesarrollo.IdUsuario = CType(Session("permisos"), clsusuario).usuario
            ObjDesarrollo.Codigo = Right(Txt_Codigo.Text, 4)
            If Txt_Observacion.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> ¡Por favor llenar el campo Observación!"
                Exit Sub
            Else
                ObjDesarrollo.Gestion = Txt_Observacion.Text
            End If
            If Drl_Complejidad.SelectedIndex = 0 And Drl_Complejidad.Enabled = True Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span>  ¡Por favor seleccione una Complejidad!"
                Exit Sub
            ElseIf Drl_Complejidad.SelectedIndex = 0 And Drl_Complejidad.Enabled = False Then
                ObjDesarrollo.Complejidad = 0
            Else
                ObjDesarrollo.Complejidad = Drl_Complejidad.SelectedItem.Text
            End If
            If Drl_Operatividad.SelectedIndex = 0 And Drl_Operatividad.Enabled = True Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span>  ¡Por favor seleccione Operatividad!"

                Exit Sub
            ElseIf Drl_Operatividad.SelectedIndex = 0 And Drl_Operatividad.Enabled = False Then
                ObjDesarrollo.Operatividad = 0
            Else
                ObjDesarrollo.Operatividad = Drl_Operatividad.SelectedItem.Text
            End If
            If Drl_Estado.SelectedIndex = 0 Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span>  ¡Por favor seleccione un Estado!"
                Exit Sub
            Else
                ObjDesarrollo.Estado = Drl_Estado.SelectedItem.Value
            End If
            If Drl_Usu_Asig.SelectedItem.Value = CType(Session("permisos"), clsusuario).usuario Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> ¡Por favor seleccione otro Desarrollador!"
                Exit Sub
            End If
            If (Drl_Estado.SelectedItem.Text = "Escalado" Or Drl_Estado.SelectedItem.Text = "Devuelto" Or Drl_Estado.SelectedItem.Text = "Entregado") And Drl_Usu_Asig.SelectedIndex = 0 Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span>  ¡Por favor seleccione un Desarrollador a escalar!"
                Exit Sub
            ElseIf (Drl_Estado.SelectedItem.Text = "Escalado" Or Drl_Estado.SelectedItem.Text = "Devuelto" Or Drl_Estado.SelectedItem.Text = "Entregado") And Drl_Usu_Asig.SelectedIndex <> 0 Then
                ObjDesarrollo.Desarrollador = Drl_Usu_Asig.SelectedItem.Value
            End If
            ObjDesarrollo.Validacion = Drl_Estado.SelectedItem.Text
            ObjDesarrollo.Actualizar_Estado_Desarrollo()
            ObjDesarrollo.Reg_Gestion_Desarrollo()
            Limpiar()
            Btn_Volver_Click(sender, e)
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span>  ¡Gestion registrada con exito!"
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>  ¡Error! " & ex.Message
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
                    Txt_Solicitante.Text = Dtg_Desarrollos.Rows(Index).Cells(7).Text
                    Txt_Requerimientos.Text = HttpUtility.HtmlDecode(Dtg_Desarrollos.Rows(Index).Cells(8).Text)
                    Dim ObjDesarrollo As New ClsDesarrollo
                    ObjDesarrollo.Codigo = Dtg_Desarrollos.Rows(Index).Cells(0).Text
                    ObjDesarrollo.IdUsuario = CType(Session("permisos"), clsusuario).usuario
                    Session("Consulta") = ObjDesarrollo.Consulta_Desarrollos_Asignados()
                    Dtg_Desarrollos.DataSource = Session("Consulta")
                    Dtg_Desarrollos.DataBind()
                    If Session("Consulta").Tables(0).Rows.Count > 0 Then
                        Lbl_Cantidad.Text = "Desarrollos Asignados: " & ObjDesarrollo.Cantidad
                    Else
                        Lbl_Cantidad.Text = Nothing
                    End If
                    Session("Consulta2") = ObjDesarrollo.Consulta_Desarrollos_Gestion()
                    Dtg_Gestiones.DataSource = Session("Consulta2")
                    Dtg_Gestiones.DataBind()
                    If Session("Consulta2").Tables(0).Rows.Count > 0 Then
                        Lbl_Cantidad2.Text = "Gestiones Realizadas: " & ObjDesarrollo.Cantidad
                    Else
                        Lbl_Cantidad2.Text = Nothing
                    End If
                    Pnl_Gestion.Visible = True
                    Pnl_Filtros.Visible = False
                    If ObjDesarrollo.Cantidad > 0 Then
                        Pnl_Dtg_Gestiones.Visible = True
                    Else
                        Pnl_Dtg_Gestiones.Visible = True
                        Lbl_Cantidad2.Text = "No se encontro ninguna gestión de dicho Desarrollo"
                    End If
            End Select
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>  ¡Error! " & Index & ex.Message
        End Try
    End Sub
    Protected Sub Dtg_Gestiones_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Dtg_Gestiones.PageIndexChanging
        Try
            Dtg_Gestiones.DataSource = Session("Consulta2")
            Dtg_Gestiones.PageIndex = e.NewPageIndex
            Dtg_Gestiones.DataBind()
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>¡Error! " & ex.Message
        End Try
    End Sub
    Protected Sub Dtg_Desarrollos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Dtg_Desarrollos.PageIndexChanging
        Try
            Dtg_Desarrollos.DataSource = Session("Consulta")
            Dtg_Desarrollos.PageIndex = e.NewPageIndex
            Dtg_Desarrollos.DataBind()
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> ¡Error! " & ex.Message
        End Try
    End Sub
End Class