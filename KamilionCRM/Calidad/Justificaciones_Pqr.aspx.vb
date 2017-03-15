Imports System.IO
Public Class Prueba001
    Inherits System.Web.UI.Page
    Dim ObjArchivo As New clscalidad
    Dim Objeto_Gestion_Datos As New Cls_Gestion_Datos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Justificación PQR"
                cargar_drl() 'cargue de listas desplegables
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Sub cargar_drl() 'metodo para el cargue de las listas desplegables 
        ObjArchivo.Validacion = "tip_solicitud"
        With Drl_Tipo_Solicitud
            .DataSource = ObjArchivo.Consulta_Archivo_Tipo_Solicitud
            .DataTextField = "Nombre"
            .DataValueField = "Nombre"
            .DataBind()

        End With
        ObjArchivo.Validacion = "estado_registro"
        With Drl_estado_reg
            .DataSource = ObjArchivo.Consulta_Archivo_Tipo_Solicitud
            .DataTextField = "Nombre"
            .DataValueField = "Nombre"
            .DataBind()

        End With
        ObjArchivo.Validacion = "estado_consulta"
        With Drl_Estado_Busca
            .DataSource = ObjArchivo.Consulta_Archivo_Tipo_Solicitud
            .DataTextField = "Nombre"
            .DataValueField = "Nombre"
            .DataBind()
        End With
        Dim objdatos As New clsgeneral 'instancio otro objeto para poder cargar las siguientes listas
        With Drl_ing_busca
            .DataSource = objdatos.consultaing
            .DataTextField = "ingclaro"
            .DataValueField = "ingclaro"
            .DataBind()
            Objeto_Gestion_Datos.Gest_Drl(Drl_ing_busca)
        End With
        With drlingclaro
            .DataSource = objdatos.consultaing
            .DataTextField = "ingclaro"
            .DataValueField = "ingclaro"
            .DataBind()
        End With

        ObjArchivo.Validacion = "Respuesta"
        With Drl_Respuesta
            .DataSource = ObjArchivo.Consulta_Archivo_Tipo_Solicitud
            .DataTextField = "Nombre"
            .DataValueField = "Nombre"
            .DataBind()
        End With
    End Sub
    Protected Sub btn_crear_Click(sender As Object, e As EventArgs) Handles btn_crear.Click
        Try
            If txtfcingn3.Text <> "" Then
                If Date.Parse(txtfcingn3.Text) > Date.Parse(DateTime.Now.ToString("dd/MM/yyyy")) Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> La Fecha no puede ser mayor a La actual"
                    Exit Sub
                End If
                ObjArchivo.Fc_Llamada = txtfcingn3.Text
            Else
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Seleccione La Fecha de Ingreso "
                Exit Sub
            End If
            If Drl_Tipo_Solicitud.SelectedValue <> "- Seleccione -" Then
                ObjArchivo.tipo = Drl_Tipo_Solicitud.SelectedValue
            Else
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Seleccione el Tipo De Solicitud "
                Exit Sub
            End If
            If drlingclaro.SelectedValue <> "- Seleccione -" Then
                ObjArchivo.Nombre = drlingclaro.SelectedValue
            Else
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Seleccione A un Ingeniero "
                Exit Sub
            End If
            If Txt_Observacion.Text <> "" Then
                ObjArchivo.Obs_General = Txt_Observacion.Text
            Else
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Ingrese una Observación "
                Exit Sub
            End If
            ObjArchivo.asistio = CType(Session("permisos"), clsusuario).usuario
            ObjArchivo.registro_caso() 'aqui procedo a la realización del registro del caso 
            ObjArchivo.Validacion = "buscar_id"
            ObjArchivo.Consulta_Archivo_Tipo_Solicitud()
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Registro Exitoso, Con El Caso Numero " & ObjArchivo.Codigo_reg
            LimpiarGrillas()
            LimpiarFiltrosDeConsulta()
            Txt_Observacion.Text = ""
            drlingclaro.SelectedValue = "- Seleccione -"
            Drl_Tipo_Solicitud.SelectedValue = "- Seleccione -"
            txtfcingn3.Text = ""
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> Se produjo error " & ex.Message
        End Try
    End Sub
    Protected Sub dtgConsultas_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dtggeneral.PageIndexChanging
        Try
            ObjArchivo.Validacion = "buscar_todos"
            Session("dtsB") = ObjArchivo.Consulta_Archivo_Tipo_Solicitud()
            dtggeneral.PageIndex = e.NewPageIndex
            dtggeneral.DataSource = Session("dtsB")
            dtggeneral.DataBind()
            lblmsg.Text = ""
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> Se produjo error " + ex.Message
        End Try
    End Sub
    Protected Sub dtg_seguim_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dtg_seguim.PageIndexChanging
        Try
            ObjArchivo.Id_Caso = Lbl_Caso.Text
            ObjArchivo.Validacion = "consulta seguimiento"
            Session("dtsB2") = ObjArchivo.Consulta_Caso()
            dtg_seguim.PageIndex = e.NewPageIndex
            dtg_seguim.DataSource = Session("dtsB2")
            dtg_seguim.DataBind()
            lblmsg.Text = ""
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> Se produjo error " + ex.Message
        End Try
    End Sub
    Protected Sub dtgConsultas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles dtggeneral.RowCommand
        Try
            'Mediante este codigo envio la identificacion del aspirante, indicanto el Rows(Fila) y Cells(Celda)
            If e.CommandName = "Seleccion" Then
                dtggeneral.Visible = True
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                'aqui selecciono la columna y la muestro en una herramienta
                Lbl_Caso.Text = dtggeneral.Rows(index).Cells(0).Text
                Lbl_fc_ingreso.Text = dtggeneral.Rows(index).Cells(1).Text
                lbl_ing_r.Text = dtggeneral.Rows(index).Cells(4).Text
                lbl_estado.Text = dtggeneral.Rows(index).Cells(11).Text
                Btn_Guardar.Visible = True
                dtg_seguim.Visible = True
                ObjArchivo.Id_Caso = Lbl_Caso.Text
                ObjArchivo.Validacion = "consulta seguimiento"
                Session("dtsB2") = ObjArchivo.Consulta_Caso()
                dtg_seguim.DataSource = Session("dtsB2")
                dtg_seguim.DataBind()
                If ObjArchivo.Codigo_reg Then
                    lblcuenta2.Text = "	Consulta Seguimientos: " & ObjArchivo.Codigo_reg
                Else
                    lblcuenta2.Text = Nothing
                End If
                lblmsg.Text = ""
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> Se presento error " & ex.Message
        End Try
    End Sub
    Protected Sub Btn_Guardar_Click(sender As Object, e As EventArgs) Handles Btn_Guardar.Click
        Try
            If lbl_estado.Text = "Enviado" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> La presente solicitud ya fue enviada por lo cual no se puede realizar el registro"
                Exit Sub
            End If
            If lbl_estado.Text = "Entregado" And Drl_estado_reg.SelectedValue <> "Enviado" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> La presente solicitud ya fue entregada y solo podra realizar registro con el estado 'Enviado'"
                Exit Sub
            End If
            If Drl_estado_reg.SelectedValue <> "- Seleccione -" Then
                ObjArchivo.Estado = Drl_estado_reg.SelectedValue
            Else
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Seleccione Un Estado "
                Exit Sub
            End If
            If Txt_obs_reg.Text <> "" Then
                ObjArchivo.Obs_General = Txt_obs_reg.Text
            Else
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Ingrese una Observación "
                Exit Sub
            End If
            If lbl_estado.Text <> "Enviado" Then
                If txt_Numero_Solic.Text <> "" Then
                    ObjArchivo.Invita = txt_Numero_Solic.Text
                Else
                    ObjArchivo.Invita = 0
                End If
                If txt_Numero_grabaciones.Text <> "" Then
                    ObjArchivo.Invitado = txt_Numero_grabaciones.Text
                Else
                    ObjArchivo.Invitado = 0
                End If
            End If
            If Drl_estado_reg.SelectedValue = "Enviado" Or Drl_estado_reg.SelectedValue = "Entregado" Then
                If Drl_Respuesta.SelectedValue = "- Seleccione -" Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Seleccione una respuesta"
                    Exit Sub
                End If
            End If
            If Drl_Respuesta.SelectedValue <> "- Seleccione -" Then
                ObjArchivo.razon = Drl_Respuesta.SelectedValue
            Else
                ObjArchivo.razon = " "
            End If
            txt_Numero_Solic.Text = ""
            txt_Numero_grabaciones.Text = ""
            ObjArchivo.Fc_Llamada = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            ObjArchivo.Codigo_reg = Lbl_Caso.Text
            ObjArchivo.asistio = CType(Session("permisos"), clsusuario).usuario
            ObjArchivo.registro_historial()
            ObjArchivo.Validacion = "Actualiza"
            If Drl_estado_reg.SelectedValue = "Enviado" Then
                ObjArchivo.Validacion = "Actualiza1"
            End If
            If Drl_estado_reg.SelectedValue = "Entregado" Then
                ObjArchivo.Validacion = "Actualiza2"
            End If
            ObjArchivo.registro_historial()
            ObjArchivo.Id_Caso = Lbl_Caso.Text
            ObjArchivo.Validacion = "consulta seguimiento"
            Session("dtsB2") = ObjArchivo.Consulta_Caso()
            dtg_seguim.DataSource = Session("dtsB2")
            dtg_seguim.DataBind()
            If ObjArchivo.Codigo_reg > 0 Then
                lblcuenta2.Text = "Consulta Seguimientos: " & ObjArchivo.Codigo_reg
            Else
                lblcuenta2.Text = Nothing
            End If
            'ObjArchivo.Validacion = "buscar_todos"
            'Session("dtsB") = ObjArchivo.Consulta_Archivo_Tipo_Solicitud()
            dtggeneral.DataSource = Session("dtsB")
            dtggeneral.DataBind()
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Registro de Seguimiento Exitoso"
            limpiar_crear_caso()
            limpiar_reg_seg()
            Btn_Guardar.Visible = False
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> Se presento error " & ex.Message
        End Try
    End Sub
    Sub limpiar_reg_seg()
        Lbl_fc_ingreso.Text = ""
        'Lbl_Tipo_solicitud.Text = ""
        lbl_ing_r.Text = ""
        Lbl_Caso.Text = ""
        Txt_obs_reg.Text = ""
        Drl_estado_reg.SelectedValue = "- Seleccione -"
        Btn_Guardar.Visible = False
        Drl_Respuesta.SelectedValue = "- Seleccione -"
    End Sub
    Sub limpiar_crear_caso()
        txtfcingn3.Text = ""
        drlingclaro.SelectedValue = "- Seleccione -"
        Txt_Observacion.Text = ""
        Drl_Tipo_Solicitud.SelectedValue = "- Seleccione -"
        txt_Numero_Solic.Text = ""
        txt_Numero_grabaciones.Text = ""
    End Sub
    Protected Sub btn_Exportar_Click(sender As Object, e As EventArgs) Handles btn_Exportar.Click
        Try
            If dtggeneral.Visible = False Then
                lblmsg.Text = "Realice una consulta y luego intente exportarla"
                Exit Sub
            End If
            crearexcel()
        Catch ex As Exception
            lblmsg.Text = "Se produjo error " & ex.Message
            lblmsg.ForeColor = Drawing.Color.Red
        End Try
    End Sub
    Sub crearexcel()
        Try
            Dim sb As New StringBuilder
            Dim sw As New StringWriter(sb)
            Dim htw As New HtmlTextWriter(sw)
            Dim pagina As Page = New Page
            Dim form = New HtmlForm
            Dim r As New clscalidad
            Dim objdtsconsultaxls As New DataSet
            Dim strStyle As String = "<style>.text { mso-number-format:\@; } </style>"
            If Lbl_Exportar.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Realice una consulta y luego intente exportarla"
                Exit Sub
            End If
            If Lbl_Exportar.Text = "buscar" Then
                Btn_Buscar_Click(1, Nothing)
            ElseIf Lbl_Exportar.Text = "buscar_todos" Then
                Btn_buscar_todos_Click(1, Nothing)
            End If
            pagina.EnableEventValidation = False
            pagina.DesignerInitialize()
            pagina.Controls.Add(form)
            form.Controls.Add(dtg_exportar)
            form.Controls.Add(dtggeneral)
            pagina.RenderControl(htw)
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/vnd.ms-excel"
            Response.ContentEncoding = System.Text.ASCIIEncoding.UTF8
            Response.AddHeader("Content-Disposition", "attachment;filename=data.xls")
            Response.Charset = "UTF-8"
            Response.Write(strStyle)
            Response.Write(sb.ToString())
            Response.End()
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>Se produjo error " + ex.Message
        End Try
    End Sub
    Protected Sub Btn_buscar_todos_Click(sender As Object, e As EventArgs) Handles Btn_buscar_todos.Click
        Try
            dtggeneral.Visible = True
            ObjArchivo.Validacion = "buscar_todos"
            Session("dtsB") = ObjArchivo.Consulta_Archivo_Tipo_Solicitud()
            dtggeneral.DataSource = Session("dtsB")
            dtggeneral.DataBind()
            dtg_exportar.DataSource = Session("dtsB")
            dtg_exportar.DataBind()
            If ObjArchivo.Codigo_reg > 0 Then
                lblcuenta.Text = "Casos: " & ObjArchivo.Codigo_reg
            Else
                lblcuenta.Text = Nothing
            End If
            limpiar_crear_caso()
            limpiar_reg_seg()
            lblmsg.Text = ""
            LimpiarFiltrosDeConsulta()
            dtg_seguim.Visible = False
            lblcuenta2.Text = ""
            Lbl_Exportar.Text = "buscar_todos"
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>Se produjo error " & ex.Message
        End Try
    End Sub
    Protected Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click
        Try
            If txtcaso.Text <> Nothing Then
                If txtcaso.Text = "" Or txtcaso.Text = " " Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Ingrese un caso"
                    Exit Sub
                End If
                ObjArchivo.Id_Caso = txtcaso.Text
                ObjArchivo.Consulta_Caso()
                If ObjArchivo.Validacion = "No hay caso" Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> El caso numero " & txtcaso.Text & " No Existe"
                    Exit Sub
                End If
                Session("dtsB") = ObjArchivo.Consulta_Caso()
                dtggeneral.DataSource = Session("dtsB")
                dtggeneral.DataBind()
                lblmsg.Text = ""
                If ObjArchivo.Codigo_reg > 0 Then
                    lblcuenta.Text = "Casos: " & ObjArchivo.Codigo_reg
                    Lbl_Exportar.Text = "buscar"
                Else
                    lblcuenta.Text = Nothing
                End If
                lblcuenta2.Text = ""
                dtg_seguim.Visible = False
                dtggeneral.Visible = True
                limpiar_crear_caso()
                limpiar_reg_seg()
            Else
                If CheckBox_casos.Checked = True Then
                    ObjArchivo.Validacion = "mis_casos"
                    ObjArchivo.Nombre = CType(Session("permisos"), clsusuario).usuario
                Else
                    If Drl_Estado_Busca.SelectedValue = "- Seleccione -" And Txt_fc_inicio.Text = "" And Drl_ing_busca.SelectedValue = "" And Txt_fc_fin.Text = "" Then
                        Pnl_Message.CssClass = "alert alert-warning"
                        lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Ingrese alguna opcion para realizar la consulta"
                        Exit Sub
                    End If
                    ObjArchivo.Validacion = "filtros"
                    If Drl_Estado_Busca.SelectedValue <> "- Seleccione -" Then
                        ObjArchivo.Estado = Drl_Estado_Busca.SelectedValue
                    End If
                    If Txt_fc_inicio.Text <> Nothing Then
                        ObjArchivo.Fc_Creacion = Txt_fc_inicio.Text
                    End If
                    If Drl_ing_busca.SelectedValue <> "- Seleccione -" Then
                        ObjArchivo.Nombre = Drl_ing_busca.SelectedValue
                    End If
                    If Txt_fc_fin.Text <> Nothing Then
                        ObjArchivo.Fc_Cierre = Txt_fc_fin.Text
                    End If
                    If Txt_fc_inicio.Text <> "" And Txt_fc_fin.Text <> "" Then
                        If Date.Parse(Txt_fc_inicio.Text) > Date.Parse(Txt_fc_fin.Text) Then
                            Pnl_Message.CssClass = "alert alert-warning"
                            lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Verifique el rango de fechas ya que la fecha inicio no puede ser mayor a la fecha fin"
                            Exit Sub
                        End If
                    End If
                End If
                Session("dtsB") = ObjArchivo.Consulta_Archivo_Tipo_Solicitud()
                dtggeneral.DataSource = Session("dtsB")
                dtggeneral.DataBind()
                dtg_exportar.DataSource = Session("dtsB")
                dtg_exportar.DataBind()
                If ObjArchivo.Codigo_reg > 0 Then
                    lblcuenta.Text = "Casos: " & ObjArchivo.Codigo_reg
                Else
                    lblcuenta.Text = Nothing
                End If
                dtggeneral.Visible = True
                lblmsg.Text = ""
                If ObjArchivo.Validacion = "1" Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> No se Han Encontrado Registros Con Este Filtro"
                    dtggeneral.Visible = False
                End If
                dtg_seguim.Visible = False
                lblcuenta2.Text = ""
                limpiar_crear_caso()
                limpiar_reg_seg()
                Lbl_Exportar.Text = "buscar"
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> Se produjo error " & ex.Message
        End Try
    End Sub
    Protected Sub btn_nuevo_ing_Click(sender As Object, e As EventArgs) Handles btn_nuevo_ing.Click
        Try
            Dim objdatos As New clsgeneral
            Dim objdatos2 As New clscrmdatos
            If txt_nuevo_ing.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Digite el nuevo ingeniero a registrar"
                Exit Sub
            End If
            objdatos2.ingn3 = txt_nuevo_ing.Text
            objdatos2.registroingclaro()
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span>  Ingeniero ingresado con éxito"
            txt_nuevo_ing.Text = ""

            With drlingclaro
                .DataSource = objdatos.consultaing
                .DataTextField = "ingclaro"
                .DataValueField = "ingclaro"
                .DataBind()
            End With
            LimpiarGrillas()
            LimpiarFiltrosDeConsulta()
            limpiar_reg_seg()
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> Se produjo error " & ex.Message
        End Try
    End Sub
    Protected Sub Drl_estado_reg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Drl_estado_reg.SelectedIndexChanged
        Try
            If Drl_estado_reg.SelectedValue <> "Enviado" Or Drl_estado_reg.SelectedValue <> "- Seleccione -" Then
                txt_Numero_grabaciones.Enabled = True
                txt_Numero_Solic.Enabled = True
            Else
                txt_Numero_grabaciones.Enabled = False
                txt_Numero_Solic.Enabled = False
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> Se produjo error " & ex.Message
        End Try
    End Sub
    Public Sub LimpiarGrillas()
        dtggeneral.DataSource = Nothing
        dtggeneral.DataBind()
        dtg_seguim.DataSource = Nothing
        dtg_seguim.DataBind()
        lblcuenta.Text = Nothing
        lblcuenta2.Text = Nothing
    End Sub
    Public Sub LimpiarFiltrosDeConsulta()
        txtcaso.Text = Nothing

        Txt_fc_inicio.Text = ""
        Txt_fc_fin.Text = ""
        CheckBox_casos.Checked = False
        Drl_ing_busca.SelectedValue = ""

    End Sub


End Class
