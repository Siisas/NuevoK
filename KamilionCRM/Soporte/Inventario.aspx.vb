
Public Class Inventario
    Inherits System.Web.UI.Page
    Dim Obj_Inv As New clsInventario
    Dim Obj_HelpDesk As New clsHelpDesk
    Dim Obj_G_D As New Cls_Gestion_Datos
#Region "Métodos"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Inventario"
                Btn_Limpiar_RegMod_Click(1, Nothing)
                Btn_Limpiar_RegDisp_Click(1, Nothing)
                Btn_Limpiar_Cons_Click(1, Nothing)
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
                Dtg_ConsInv.DataSource = ViewState("Dtg_ConsInv")
                Dtg_ConsInv.DataBind()
                Lbl_ConsInv.Text = ViewState("Dtg_ConsInv").Rows.Count
                If ViewState("Dtg_ConsInv").Rows.Count > 0 Then
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
#Region "Dtt.PageIndexChanging"
    Protected Sub Dtg_ConsInv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Dtg_ConsInv.PageIndexChanging
        Try
            Dtg_ConsInv.DataSource = ViewState("Dtg_ConsInv")
            Dtg_ConsInv.PageIndex = e.NewPageIndex
            Dtg_ConsInv.DataBind()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
#End Region
#Region "Btn.Click"
    Protected Sub Btn_RegDisp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_RegDisp.Click
        Try
            Obj_G_D.Validar_Herramientas(Drl_Dispositivo_RegDisp, "Dispositivo")
            Obj_G_D.Validar_Herramientas(Drl_Marca_RegDisp, "Marca")
            Obj_G_D.Validar_Herramientas(Drl_Empresa_RegDisp, "Empresa")
            Obj_G_D.Validar_Herramientas(Txt_Serial_RegDisp, "Serial")
            Obj_G_D.Validar_Herramientas(Txt_FechAdqui_RegDisp, "Fecha de adquisición", "Date",, Now)
            If Drl_Marca_RegDisp.Text = "Otro" Then
                Obj_G_D.Validar_Herramientas(Txt_Marca_RegDisp, "Marca")
            End If
            If Drl_Empresa_RegDisp.Text = "Otro" Then
                Obj_G_D.Validar_Herramientas(Txt_Empresa_RegDisp, "Empresa")
            End If
            If Pnl_Txt_SerialK_RegDisp.Visible = True Then
                Obj_G_D.Validar_Herramientas(Txt_SerialK_RegDisp, "Serial Kamilion")
            End If
            If Txt_Marca_RegDisp.Visible = True Then
                Obj_Inv.Marca = Txt_Marca_RegDisp.Text
            Else
                Obj_Inv.Marca = Drl_Marca_RegDisp.Text()
            End If
            If Txt_Empresa_RegDisp.Visible = True Then
                Obj_Inv.Empresa = Txt_Empresa_RegDisp.Text
            Else
                Obj_Inv.Empresa = Drl_Empresa_RegDisp.Text
            End If
            If Txt_Modelo_RegDisp.Text = Nothing Then
                Obj_Inv.Modelo = ""
            Else
                Obj_Inv.Modelo = Txt_Modelo_RegDisp.Text
            End If
            If Txt_SerialK_RegDisp.Text = Nothing Then
                Obj_Inv.Serial_Kamilion = ""
            Else
                Obj_Inv.Serial_Kamilion = Txt_SerialK_RegDisp.Text
            End If
            Obj_Inv.Serial = Txt_Serial_RegDisp.Text
            Obj_Inv.ID_Modulo = Drl_Moulo_RegDisp.SelectedItem.Text
            Obj_Inv.FK_Cod_Invent_Dispositivo = Drl_Dispositivo_RegDisp.Text
            Obj_Inv.Fk_ID_Modulo = Drl_Moulo_RegDisp.Text
            Obj_Inv.Id_Usuario = CType(Session("permisos"), clsusuario).usuario
            Obj_Inv.Fecha_Adquisicion = Txt_FechAdqui_RegDisp.Text
            Obj_Inv.Cod_Inventario  =  Obj_Inv.Registrar_Dispositivo()
            Obj_Inv.Registrar_Gestion_Dispositivo(True)
            If Drl_Moulo_RegDisp.SelectedIndex > 0 Then
                Obj_Inv.Asignar_Dispositivo(True)
            End If
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Dispositivo ingresado"
            Btn_Limpiar_RegDisp_Click(1, Nothing)
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        Finally
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "P", "Pleg_Loading();", True)
        End Try
    End Sub
    Protected Sub Btn_RegMod_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_RegMod.Click
        Try
            Obj_G_D.Validar_Herramientas(TxtLetra, "Letra")
            Obj_G_D.Validar_Herramientas(TxtNumero, "Número", "Numeric")
            Obj_G_D.Validar_Herramientas(Txt_Fc_Adq, "Fecha de adquisición", "Date",, Now)
            Obj_Inv.ID_Modulo = UCase(TxtLetra.Text) + TxtNumero.Text
            Obj_Inv.Letra = UCase(TxtLetra.Text)
            Obj_Inv.Numero = TxtNumero.Text
            Obj_Inv.Id_Usuario = CType(Session("permisos"), clsusuario).usuario
            Obj_Inv._area = Drl_Area_Modulo.SelectedItem.Value
            Obj_Inv.Observacion = "Asignación de registro inicial"
            Obj_Inv.FcReg_Invent = Txt_Fc_Adq.Text
            Obj_Inv.Registrar_Modulo()
            If Not Drl_Area_Modulo.SelectedIndex <= 0 Then
                Obj_Inv.Asignar_Modulo()
            End If
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Modulo registrado exitosamente"
            Btn_Limpiar_RegMod_Click(1, Nothing)
            Btn_Limpiar_RegDisp_Click(1, Nothing)
            Btn_Limpiar_Cons_Click(1, Nothing)
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        Finally
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "P", "Pleg_Loading();", True)
        End Try
    End Sub
    Protected Sub Btn_Consultar_Inventario_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Consultar_Inventario.Click
        Try
            If TxtMarcaConsulta.Visible = True Then
                Obj_Inv.Marca = TxtMarcaConsulta.Text
            ElseIf Drl_Marca_Cons.SelectedIndex > 0 Then
                Obj_Inv.Marca = Drl_Marca_Cons.Text
            End If
            If Txt_Empresa_Cons.Visible = True Then
                Obj_Inv.Empresa = Txt_Empresa_Cons.Text
            ElseIf Drl_Empresa_Cons.SelectedIndex > 0 Then
                Obj_Inv.Empresa = Drl_Empresa_Cons.Text
            End If
            If Drl_Area_Cons.SelectedIndex > 0 Then
                Obj_Inv._area = Drl_Area_Cons.SelectedItem.Value
            End If

            If drlModuloConsultas.SelectedIndex > 0 Then
                Obj_Inv.ID_Modulo = drlModuloConsultas.Text
            End If
            Obj_Inv.Modelo = TxtModeloConsulta.Text
            Obj_Inv.Serial = TxtSerialConsulta.Text
            Obj_Inv.Serial_Kamilion = TxtSerialKamilionConsulta.Text
            Obj_Inv.Fc_ruta = Txt_Consuta_Adquisicion.Text
            ViewState("Filtro_Cons") = Obj_Inv.Propertys
            If Consultar() Then
                Pnl_Message.CssClass = "alert alert-success"
                lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Busqueda exitosa"
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
    Protected Sub Btn_Limpiar_RegMod_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Limpiar_RegMod.Click
        Try
            Txt_Fc_Adq.Text = Nothing
            TxtLetra.Text = Nothing
            TxtNumero.Text = Nothing
            'Drls
            With Drl_Area_Modulo
                .DataSource = Obj_HelpDesk.Consulta_Area
                .DataTextField = "Nombre"
                .DataValueField = "Cod_HelpDesk_Complemento"
                .DataBind()
                Drl_Area_Modulo = Obj_G_D.Gest_Drl(Drl_Area_Modulo)
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
    Protected Sub Btn_Limpiar_RegDisp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Limpiar_RegDisp.Click
        Try
            With Drl_Dispositivo_RegDisp
                .DataSource = Obj_Inv.Consulta_Dispositivos
                .DataTextField = "Nombre_Dispositivo"
                .DataValueField = "Cod_Invent_Dispositivo"
                .DataBind()
                Drl_Dispositivo_RegDisp = Obj_G_D.Gest_Drl(Drl_Dispositivo_RegDisp)
            End With
            With Drl_Moulo_RegDisp
                .DataSource = Obj_Inv.Cons_Modulos
                .DataTextField = "ID_Modulo"
                .DataValueField = "ID_Modulo"
                .DataBind()
                Drl_Moulo_RegDisp = Obj_G_D.Gest_Drl(Drl_Moulo_RegDisp)
            End With
            Drl_Marca_RegDisp = Obj_G_D.Gest_Drl(Drl_Marca_RegDisp)
            Drl_Empresa_RegDisp = Obj_G_D.Gest_Drl(Drl_Empresa_RegDisp)
            Drl_Marca_RegDisp_SelectedIndexChanged(1, Nothing)
            Drl_Empresa_RegDisp_SelectedIndexChanged(1, Nothing)
            Txt_Marca_RegDisp.Text = Nothing
            Txt_Empresa_RegDisp.Text = Nothing
            Txt_SerialK_RegDisp.Text = Nothing
            Txt_Modelo_RegDisp.Text = Nothing
            Txt_Serial_RegDisp.Text = Nothing
            Txt_FechAdqui_RegDisp.Text = Nothing
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
            'Tboxs
            Txt_Empresa_Cons.Text = Nothing
            Txt_Consuta_Adquisicion.Text = Nothing
            TxtMarcaConsulta.Text = Nothing
            TxtModeloConsulta.Text = Nothing
            TxtSerialConsulta.Text = Nothing
            TxtSerialKamilionConsulta.Text = Nothing
            'Drls
            With drlModuloConsultas
                .DataSource = Obj_Inv.Cons_Modulos
                .DataTextField = "ID_Modulo"
                .DataValueField = "ID_Modulo"
                .DataBind()
                .Items.Add("BODEGA")
                drlModuloConsultas = Obj_G_D.Gest_Drl(drlModuloConsultas)
            End With
            With Drl_Area_Cons
                .DataSource = Obj_HelpDesk.Consulta_Area
                .DataTextField = "Nombre"
                .DataValueField = "Cod_HelpDesk_Complemento"
                .DataBind()
                .Items.Add("BODEGA")
                Drl_Area_Cons = Obj_G_D.Gest_Drl(Drl_Area_Cons)
            End With
            Drl_Marca_Cons = Obj_G_D.Gest_Drl(Drl_Marca_Cons)
            Drl_Empresa_Cons = Obj_G_D.Gest_Drl(Drl_Empresa_Cons)
            Drl_Empresa_Cons_SelectedIndexChanged(1, Nothing)
            Drl_Marca_Cons_SelectedIndexChanged(1, Nothing)
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
#Region "drl.SelectedIndexChanged"
    Protected Sub Drl_Marca_RegDisp_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Drl_Marca_RegDisp.SelectedIndexChanged
        Try
            If Drl_Marca_RegDisp.SelectedItem.Text = "Otro" Then
                Drl_Marca_RegDisp.Width = Unit.Percentage(50)
                Txt_Marca_RegDisp.Visible = True
            Else
                Drl_Marca_RegDisp.Width = Unit.Percentage(100)
                Txt_Marca_RegDisp.Visible = False
            End If
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
    Protected Sub Drl_Empresa_RegDisp_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Drl_Empresa_RegDisp.SelectedIndexChanged
        Try
            If Drl_Empresa_RegDisp.Text = "Otro" Then
                Drl_Empresa_RegDisp.Width = Unit.Percentage(50)
                Txt_Empresa_RegDisp.Visible = True
            Else
                Drl_Empresa_RegDisp.Width = Unit.Percentage(100)
                Txt_Empresa_RegDisp.Visible = False
            End If
            If Drl_Empresa_RegDisp.SelectedItem.Text = "KAMILION" Then
                Pnl_Txt_SerialK_RegDisp.Visible = True
            Else
                Pnl_Txt_SerialK_RegDisp.Visible = False
            End If
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
    Protected Sub Drl_Empresa_Cons_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Drl_Empresa_Cons.SelectedIndexChanged
        Try
            If Drl_Empresa_Cons.SelectedItem.Text = "Otro" Then
                Drl_Empresa_Cons.Width = Unit.Percentage(50)
                Txt_Empresa_Cons.Visible = True
            Else
                Drl_Empresa_Cons.Width = Unit.Percentage(100)
                Txt_Empresa_Cons.Visible = False
            End If
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
    Protected Sub Drl_Marca_Cons_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Drl_Marca_Cons.SelectedIndexChanged
        Try
            If Drl_Marca_Cons.SelectedItem.Text = "Otro" Then
                Drl_Marca_Cons.Width = Unit.Percentage(50)
                TxtMarcaConsulta.Visible = True
            Else
                Drl_Marca_Cons.Width = Unit.Percentage(100)
                TxtMarcaConsulta.Visible = False
            End If
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



End Class