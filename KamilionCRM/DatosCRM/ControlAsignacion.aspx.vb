Imports System.IO
Public Class ControlAsignacion
    Inherits System.Web.UI.Page
    Dim objDatos As New clscrmdatos
    Dim Objeto_Gestion_Datos As New Cls_Gestion_Datos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Consulta Géneral de Desarrollos"
                cargar()
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    '----------CARGAR LISTA------------'
    Sub cargar()
        objDatos.Validacion = "Control"
        With DrlEstado
            .DataSource = objDatos.Consulta_drlestado
            .DataTextField = "Nombre"
            .DataValueField = "Nombre"
            .DataBind()
        End With
    End Sub
    Protected Sub BtnBusca_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnBusca.Click
        Try
            objDatos.Validacion = "Control"
            If DrlEstado.SelectedItem.Text <> "- Seleccione -" Then
                objDatos.estadoinc = DrlEstado.SelectedItem.Text
                If DrlEstado.SelectedItem.Text = "Programado" Then
                    If DrlProgramado.SelectedItem.Text <> "- Seleccione -" Then
                        objDatos.tipificacion = DrlProgramado.SelectedItem.Text
                        objDatos.Validacion = "Programado"
                    End If
                End If
                Lblcampaña.Text = DrlEstado.SelectedItem.Text
            Else
                Lblcampaña.Text = "General"
            End If
            Session("Control") = objDatos.Consulta_Control_Operacion
            DtgControl.DataSource = Session("Control")
            DtgControl.DataBind()
            If objDatos.cantidad = 0 Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> No se encontraron registros"
                DtgControl.DataSource = Nothing
                lblcuenta.Text = Nothing
                dtggeneral.DataSource = Nothing
                dtggeneral.DataBind()
                BtnExportar2.Visible = False
                Exit Sub
            Else
                dtggeneral.DataSource = Nothing
                dtggeneral.DataBind()
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>Se produjo error " & ex.Message
        End Try
        BtnExportar2.Visible = False
        lblcuenta.Text = Nothing
    End Sub
    Protected Sub DrlEstado_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DrlEstado.SelectedIndexChanged
        Try
            If DrlEstado.SelectedItem.Text = "Programado" Then
                PnlProgramado.Visible = True
                DrlProgramado.SelectedIndex = 0
            Else
                PnlProgramado.Visible = False
                DrlProgramado.SelectedIndex = 0
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>Se produjo error " & ex.Message
        End Try
    End Sub
    Dim ingeniero, campaña As String
    Protected Sub DtgControl_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles DtgControl.RowCommand
        Try
            ingeniero = DtgControl.Rows(e.CommandArgument).Cells(0).Text
            campaña = e.CommandName.ToString
            objDatos.idusuario = ingeniero
            objDatos.Bandeja = campaña
            If DrlEstado.SelectedItem.Text <> "- Seleccione -" Then
                objDatos.estadoinc = DrlEstado.SelectedItem.Text
                If DrlEstado.SelectedItem.Text = "Programado" Then
                    If DrlProgramado.SelectedItem.Text <> "- Seleccione -" Then
                        objDatos.tipificacion = DrlProgramado.SelectedItem.Text
                    End If
                End If
            End If
            objDatos.Validacion = "Individual"
            Session("Individual") = objDatos.Consulta_Control_Operacion
            dtggeneral.DataSource = Session("Individual")
            dtggeneral.DataBind()
            If objDatos.cantidad > 0 Then
                lblcuenta.Text = "Registros: " & objDatos.cantidad
                BtnExportar2.Visible = True
            Else
                lblcuenta.Text = Nothing
                BtnExportar2.Visible = False
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>Se produjo error " & ex.Message
        End Try
    End Sub
    Protected Sub Btnexportar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btnexportar.Click
        Try
            If DtgControl.Rows.Count = 0 Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Realice una consulta primero"
                Exit Sub
            Else
                dtggeneral.DataSource = Session("Control")
                dtggeneral.DataBind()
                crearexcel(dtggeneral)
                dtggeneral.DataSource = Session("Individual")
                dtggeneral.DataBind()
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>Se produjo error " & ex.Message
        End Try
    End Sub
    Protected Sub BtnExportar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnExportar2.Click
        Try
            If dtggeneral.Rows.Count = 0 Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Control Operacion"
                Exit Sub
            End If
            crearexcel(dtggeneral)
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>Se produjo error " & ex.Message
        End Try
    End Sub
    Sub crearexcel(ByVal dtg As GridView)
        Try
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim tabla As New Table()
            Dim tr1 As New TableRow()
            Dim cell1 As New TableCell()
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            cell1.Controls.Add(dtg)
            tr1.Cells.Add(cell1)
            tabla.Rows.Add(tr1)
            tabla.RenderControl(hw)
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("Content-Disposition", "attachment;filename=Control Operacion.xls")
            Response.Charset = "UTF-8"
            Response.ContentType = "application/vnd.ms-excel"
            Response.ContentEncoding = System.Text.ASCIIEncoding.UTF8
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.End()
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>Se produjo error " & ex.Message
        End Try
    End Sub
End Class