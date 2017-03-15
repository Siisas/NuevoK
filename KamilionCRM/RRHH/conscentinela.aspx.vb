Imports System.IO
Public Class conscentinela
    Inherits System.Web.UI.Page
    Private Obj_G_D As New Cls_Gestion_Datos
    Dim objRrhh As New clsrrhh
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Dim objdatos As New clsgeneral
                Session("Formulario") = "Consulta de Entrada y Salida"
                grupo()

            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub

    Protected Sub grupo()
        objRrhh.Validacion = "centinela"
        With drlcargo
            .DataSource = objRrhh.Consulta_grupo
            .DataTextField = "cargo_cliente"
            .DataValueField = "cargo_cliente"
            .DataBind()
            .Items.Insert(0, "- Seleccione -")
        End With

        objRrhh.Validacion = "centinela"
        With drlcargocontrol
            .DataSource = objRrhh.Consulta_grupo
            .DataTextField = "cargo_cliente"
            .DataValueField = "cargo_cliente"
            .DataBind()
            .Items.Insert(0, "- Seleccione -")
        End With

        objRrhh.Validacion = "Horario"
        With drlHorario
            .DataSource = objRrhh.Consulta_grupo
            .DataTextField = "Nombre"
            .DataValueField = "Cod_Validacion_Horario_Complemento"
            .DataBind()
        End With
    End Sub
    'Buscar Consulta centinela
    Protected Sub buscarinf()
        Try
            If txtcod.Text = "" And txtfcini.Text = "" And txtfcfin.Text = "" And drlcargo.SelectedItem.Text = "- Seleccione -" And drlHorario.SelectedItem.Text = "- Seleccione -" Then
                dtggeneral.DataSource = Nothing
                dtggeneral.DataBind()
                Throw New Exception("Digite un criterio de filtro antes de realizar la consulta")
            Else
                If txtcod.Text <> "" Then
                    objRrhh.codigo = txtcod.Text
                End If
                If txtfcini.Text = "" Or txtfcfin.Text = "" Then
                    Throw New Exception("Debe seleccionar un rango de fechas para realizar la consulta")
                Else
                    objRrhh.fcfin = txtfcfin.Text
                    objRrhh.fcini = txtfcini.Text
                End If
                If txtfcfin.Text <> "" And txtfcini.Text <> "" Then
                    If Date.Parse(txtfcini.Text) > Date.Parse(txtfcfin.Text) Then
                        Throw New Exception("Fecha Inicio debe ser menor a fecha fin")
                    End If
                End If
                If drlcargo.Text <> "- Seleccione -" Then
                    objRrhh.Cargo_Cliente = drlcargo.SelectedItem.Text
                End If

                If drlHorario.SelectedItem.Text <> "- Seleccione -" Then
                    objRrhh.Tipo_Horario = drlHorario.SelectedValue
                End If

                objRrhh.Validacion = "Individual"
                Session("Centinela") = objRrhh.consultacentinelatotal
                dtggeneral.DataSource = Session("Centinela")
                dtggeneral.DataBind()
                If dtggeneral.Rows.Count <= 0 Then
                    Throw New Exception("No se encontraron registros")
                End If
                lblcuenta.Text = objRrhh.cantidad
                lblmsg.Text = ""
            End If

        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
    'Buscar control
    Protected Sub BtnBusca_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnBusca.Click
        Try
            Obj_G_D.Validar_Herramientas(txtfechaini, "Fecha")
            objRrhh.fcini = txtfechaini.Text

            If drlcargocontrol.SelectedItem.Text <> "- Seleccione -" Then
                objRrhh.Cargo_Cliente = drlcargocontrol.SelectedItem.Text
            End If
            objRrhh.Validacion = "Control"
            Session("Control") = objRrhh.consultacentinelatotal
            DtgControl.DataSource = Session("Control")
            DtgControl.DataBind()
            If DtgControl.Rows.Count < 0 Then
                Throw New Exception("No se encontraron registros")
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        buscarinf()
    End Sub
    Private Sub Exportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnexportar.Click, btnxls.Click
        Try
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim tabla As New Table()
            Dim tr1 As New TableRow()
            Dim cell1 As New TableCell()
            Dim Val As Boolean = False
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            If DirectCast(sender, System.Web.UI.Control).ClientID = "Btnexportar" Then
                If DtgControl.Rows.Count > 0 And DtgControl.Rows.Count < 8101 Then
                    Val = True
                    dtggeneral.AllowPaging = False
                    dtggeneral.DataSource = Session("Control")
                    dtggeneral.DataBind()
                    cell1.Controls.Add(dtggeneral)
                    tr1.Cells.Add(cell1)
                    tabla.Rows.Add(tr1)
                    tabla.RenderControl(hw)
                    dtggeneral.AllowPaging = True
                    If lblcuenta.Text <> Nothing Then
                        dtggeneral.DataSource = Session("Centinela")
                        dtggeneral.DataBind()
                    End If
                ElseIf DtgControl.Rows.Count > 8100 Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> ¡Se denego el permiso de exportacion debido a que exede el limite de registros; Realice otro filtro y reintente exportar! "
                Else
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span Class='glyphicon glyphicon-warning-sign'></span> ¡No se encontraron registros para realizar la exportacion! "
                End If
            ElseIf DirectCast(sender, System.Web.UI.Control).ClientID = "btnxls" Then
                If dtggeneral.Rows.Count > 0 And dtggeneral.Rows.Count < 8101 Then
                    Val = True
                    dtggeneral.AllowPaging = False
                    dtggeneral.DataSource = Session("Centinela")
                    dtggeneral.DataBind()
                    cell1.Controls.Add(dtggeneral)
                    tr1.Cells.Add(cell1)
                    tabla.Rows.Add(tr1)
                    tabla.RenderControl(hw)
                    dtggeneral.AllowPaging = True
                ElseIf dtggeneral.Rows.Count > 8100 Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> ¡Se denego el permiso de exportacion debido a que exede el limite de registros; Realice otro filtro y reintente exportar! "
                Else
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span Class='glyphicon glyphicon-warning-sign'></span> ¡No se encontraron registros para realizar la exportacion! "
                End If
            End If
            If Val = True Then
                Response.Clear()
                Response.Buffer = True
                Response.AddHeader("Content-Disposition", "attachment;filename=Reporte de centinela.xls")
                Response.Charset = "UTF-8"
                Response.ContentType = "application/vnd.ms-excel"
                Response.ContentEncoding = System.Text.ASCIIEncoding.UTF8
                Response.Write(style)
                Response.Output.Write(sw.ToString())
                Response.End()
            End If
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
    Dim Hora, Tipo As String
    Dim Index As Integer
    Protected Sub DtgControl_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles DtgControl.RowCommand
        Try
            Hora = DtgControl.Rows(e.CommandArgument).Cells(0).Text
            Tipo = e.CommandName.ToString

            objRrhh.horanov = Hora
            objRrhh.turno = Tipo
            If Tipo = "Presentes" Or Tipo = "Retardos" Then
                objRrhh.Validacion = "Presentes"
            ElseIf Tipo = "Programados" Or Tipo = "Aus. Just" Or Tipo = "Vacaciones" Then
                objRrhh.Validacion = "Validacion"
            ElseIf Tipo = "Aus. Injus" Then
                objRrhh.Validacion = "Injus"
            ElseIf Tipo = "Total" Then
                objRrhh.Validacion = "Total"
            End If
            objRrhh.fcini = txtfechaini.Text
            If drlcargocontrol.SelectedItem.Text <> "- Seleccione -" Then
                objRrhh.Cargo_Cliente = drlcargocontrol.SelectedItem.Text
            End If
            Session("Centinela") = objRrhh.consultacentinelatotal
            dtggeneral.DataSource = Session("Centinela")
            dtggeneral.DataBind()
            lblcuenta.Text = objRrhh.cantidad
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Protected Sub dtggeneral_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles dtggeneral.PageIndexChanging
        Try
            dtggeneral.PageIndex = e.NewPageIndex
            dtggeneral.DataSource = Session("Centinela")
            dtggeneral.DataBind()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
    Protected Sub DtgControl_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles DtgControl.PageIndexChanging
        Try
            DtgControl.PageIndex = e.NewPageIndex
            DtgControl.DataSource = Session("Control")
            DtgControl.DataBind()
        Catch ex As Exception
            Obj_G_D.Val_Ex(ex)
            Pnl_Message.CssClass = Obj_G_D.Ex("Alert")
            lblmsg.Text = Obj_G_D.Ex("Message")
        End Try
    End Sub
End Class
