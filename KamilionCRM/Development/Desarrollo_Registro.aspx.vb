Public Class Desarrollo_Registro
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
                Session("Formulario") = "Registro Solicitud de Desarrollo"
                ObjDesarrollo.IdUsuario = CType(Session("permisos"), clsusuario).usuario
                ViewState("Consulta.Registro") = ObjDesarrollo.Consulta_Desarrollos()
                Dtg_Desarrollos.DataSource = ViewState("Consulta.Registro")
                Dtg_Desarrollos.DataBind()
                If ObjDesarrollo.Cantidad > 0 Then
                    LblC.Text = "Numero de Tickets: " & ObjDesarrollo.Cantidad
                Else
                    LblC.Text = Nothing
                End If
                Cargar_Drls()
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub

    Public Sub Cargar_Drls()
        With Drl_Area
            ObjDesarrollo.Validacion = "Cargar_Area"
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "Com_Nom"
            .DataValueField = "Com_Cod"
            .DataBind()
            Objeto_Gestion_Datos.Gest_Drl(Drl_Area)
        End With
        With Drl_Prioridad
            ObjDesarrollo.Validacion = "Cargar_Prioridad"
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "Com_Nom"
            .DataValueField = "Com_Cod"
            .DataBind()
            Objeto_Gestion_Datos.Gest_Drl(Drl_Prioridad)
        End With
        With Drl_Cons_Prioridad
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "Com_Nom"
            .DataValueField = "Com_Cod"
            .DataBind()
            Objeto_Gestion_Datos.Gest_Drl(Drl_Cons_Prioridad)
        End With
        With Drl_Solicitante
            ObjDesarrollo.Validacion = "Cargar_Solicitante"
            .DataSource = ObjDesarrollo.Consulta_Carga_Drls()
            .DataTextField = "nombreu"
            .DataValueField = "idusuario"
            .DataBind()
            Objeto_Gestion_Datos.Gest_Drl(Drl_Solicitante)
        End With
    End Sub
    Public Sub Limpiar()
        Txt_Tema.Text = Nothing
        Txt_Requerimientos.Text = Nothing
        Drl_Prioridad.SelectedIndex = 0
        Drl_Area.SelectedIndex = 0
        Drl_Solicitante.SelectedIndex = 0
    End Sub

    Protected Sub Btn_Guardar_Click(sender As Object, e As EventArgs) Handles Btn_Guardar.Click

        Try
            If Txt_Tema.Text = Nothing Or Txt_Tema.Text = "" Or Txt_Tema.Text = " " Or Txt_Tema.Text = "0" Then

                Pnl_Message.CssClass = "alert alert-info"
                lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span>  ¡El campo (Tema) debe ser diligenciado!"

                Exit Sub
            End If
            If Drl_Prioridad.SelectedItem.Value = "0" Then
                Pnl_Message.CssClass = "alert alert-info"
                lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span>  ¡El campo (Prioridad) es obligatorio!"

                Exit Sub
            End If
            If Drl_Area.SelectedItem.Value = "0" Then
                Pnl_Message.CssClass = "alert alert-info"
                lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span>  ¡El campo (Area) es obligatorio!"

                Exit Sub
            End If
            If Drl_Solicitante.SelectedItem.Value = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-info"
                lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span>  ¡El campo (Persona Solicita) es obligatorio!"

                Exit Sub
            End If
            If Txt_Requerimientos.Text = Nothing Or Txt_Requerimientos.Text = "" Or Txt_Requerimientos.Text = " " Or Txt_Requerimientos.Text = "0" Then
                Pnl_Message.CssClass = "alert alert-info"
                lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span>  ¡Para el campo (Requerimientos) debe diligenciar especificamente lo que se requiere en el desarrollo!"

                Exit Sub
            End If
            ObjDesarrollo.IdUsuario = CType(Session("permisos"), clsusuario).usuario
            ObjDesarrollo.Tema = Txt_Tema.Text
            ObjDesarrollo.Prioridad = Drl_Prioridad.SelectedItem.Text
            ObjDesarrollo.Area = Drl_Area.SelectedItem.Value
            ObjDesarrollo.Solicitante = Drl_Solicitante.SelectedItem.Value
            ObjDesarrollo.Requerimientos = Txt_Requerimientos.Text
            ObjDesarrollo.Reg_Solicitud_Desarrollo()
            ObjDesarrollo.Consultar_Codigo()

            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span>  ¡Se registro exitosamente la solicitud con el codigo " & ObjDesarrollo.Codigo & "!"
            Limpiar()

            Dtg_Desarrollos.DataSource = ObjDesarrollo.Consulta_Desarrollos()
            Dtg_Desarrollos.DataBind()
            If ObjDesarrollo.Cantidad > 0 Then
                LblC.Text = "Numero de Tickets: " & ObjDesarrollo.Cantidad
            Else
                LblC.Text = Nothing
            End If

        Catch ex As Exception

            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>  ¡Error!" & ex.Message

        End Try

    End Sub

    Protected Sub Btn_Filtrar_Click(sender As Object, e As EventArgs) Handles Btn_Filtrar.Click
        Try

            ObjDesarrollo.IdUsuario = CType(Session("permisos"), clsusuario).usuario
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
            ViewState("Consulta.Registro") = ObjDesarrollo.Consulta_Desarrollos()
            Dtg_Desarrollos.DataSource = ViewState("Consulta.Registro")
            Dtg_Desarrollos.DataBind()
            If ObjDesarrollo.Cantidad > 0 Then
                LblC.Text = "Numero de Tickets: " & ObjDesarrollo.Cantidad
            Else
                LblC.Text = Nothing
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>  & ex.Message ¡Error! " & ex.Message

        End Try
    End Sub

    Protected Sub Dtg_Desarrollos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Dtg_Desarrollos.PageIndexChanging
        Try
            Dtg_Desarrollos.DataSource = ViewState("Consulta.Registro")
            Dtg_Desarrollos.PageIndex = e.NewPageIndex
            Dtg_Desarrollos.DataBind()
            lblmsg.Text = ObjDesarrollo.Cantidad
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
End Class