Imports System.IO

Public Class ConsultaGeneral
    Inherits System.Web.UI.Page

    Private objgd As New Cls_Gestion_Datos
    Private objdatos As New clscrmdatos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Consulta General por Min"
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Protected Sub DtgGeneral_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles DtgGeneral.PageIndexChanging
        Try
            DtgGeneral.PageIndex = e.NewPageIndex
            DtgGeneral.DataSource = Session("ConsultaEscalados.DtgGeneral")
            DtgGeneral.DataBind()
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub

    Protected Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click
        Try
            objgd.Validar_Herramientas(txt_min, "Min")
            objdatos.min = txt_min.Text

            Session("ConsultaEscalados.DtgGeneral") = objdatos.Consulta_General_Min
            DtgGeneral.DataSource = Session("ConsultaEscalados.DtgGeneral")
            DtgGeneral.DataBind()
            If objdatos.cantidad > 0 Then
                Lbl_Cuenta.Text = "Casos encontrados: " & objdatos.cantidad
            Else
                Lbl_Cuenta.Text = "Casos encontrados: 0"
            End If

        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span Class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
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
            If DtgGeneral.Rows.Count > 0 And DtgGeneral.Rows.Count < 8101 Then
                Val = True
                DtgGeneral.AllowPaging = False
                DtgGeneral.DataSource = Session("ConsultaEscalados.DtgGeneral")
                DtgGeneral.DataBind()
                cell1.Controls.Add(DtgGeneral)
                tr1.Cells.Add(cell1)
                tabla.Rows.Add(tr1)
                tabla.RenderControl(hw)
                DtgGeneral.AllowPaging = True
            ElseIf DtgGeneral.Rows.Count > 8100 Then
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
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub

End Class