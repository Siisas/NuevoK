Public Class RRHH_PruebasConsulta
    Inherits System.Web.UI.Page
    Dim Objeto_Gestion_Datos As New Cls_Gestion_Datos
    Dim Objeto_Rh As New ClsRRHHGestion
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Consultar Resultados"
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub BtnConsultarAsp_Click(sender As Object, e As EventArgs) Handles BtnConsultarAsp.Click
        Try
            If TxtConsultaDoc.Text.Trim = "" Then
                LimpiarGrillas()
                Objeto_Gestion_Datos.Validar_Herramientas(TxtConsultaDoc, "Documento", "Numeric", 10,)
            Else
                LimpiarGrillas()
                Comparar.Visible = False
                Dim CountT As Integer = Gtg_ConsultaPruebas.Rows.Count
                If CountT > 0 Then
                    LblCantidad1.Text = "Pruebas Presentadas: " & CountT
                Else
                    LblCantidad1.Text = ""
                End If
                Gtg_ConsultaPruebasADigitar.DataSource = Nothing
                Gtg_ConsultaPruebasADigitar.DataBind()
                Dim Count2 As Integer = Gtg_ConsultaPruebasADigitar.Rows.Count
                If Count2 > 0 Then
                    LblCantidad2.Text = "Vs Pruebas a Presentar: " & Count2
                Else
                    LblCantidad2.Text = ""
                End If
                Objeto_Rh.Documento = TxtConsultaDoc.Text
                Objeto_Rh.ConsulResultAsp()
                Gtg_ConsultaResultados.DataSource = Objeto_Rh.ConsulResultAsp()
                Gtg_ConsultaResultados.DataBind()
                Dim Count As Integer = Gtg_ConsultaResultados.Rows.Count
                If Count > 0 Then
                    Lbl_Cantidad.Text = "Resultados Encontrados: " & Count
                Else
                    Lbl_Cantidad.Text = ""
                    Throw New Exception("Número de documento no ha sido creado o no ha presentado pruebas.")
                End If
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Private Sub Gtg_ConsultaResultados_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles Gtg_ConsultaResultados.RowCommand
        Dim Dt As DataTable = New DataTable()
        Dim Index As Integer
        Try
            Select Case e.CommandName
                Case "Seleccionar"
                    Gtg_ConsultaPruebas.DataSource = Nothing
                    Gtg_ConsultaPruebas.DataBind()
                    LblCantidad1.Text = ""
                    Lbl_Cantidad.Text = ""
                    Gtg_ConsultaPruebasADigitar.DataSource = Nothing
                    Gtg_ConsultaPruebasADigitar.DataBind()
                    LblCantidad2.Text = ""
                    Gtg_ConsultaPruebas.DataSource = Nothing
                    Gtg_ConsultaPruebas.DataBind()
                    Gtg_ConsultaPruebas.DataSource = Nothing
                    Gtg_ConsultaPruebas.DataBind()
                    Index = Convert.ToInt32(e.CommandArgument)
                    Objeto_Rh.Documento = Gtg_ConsultaResultados.Rows(Index).Cells(1).Text
                    Gtg_ConsultaPruebas.DataSource = Objeto_Rh.ConsultarResultados()
                    Gtg_ConsultaPruebas.DataBind()

                    Dim Count As Integer = Gtg_ConsultaPruebas.Rows.Count
                    If Count > 0 Then
                        LblCantidad1.Text = "Pruebas Presentadas: " & Count
                    Else
                        LblCantidad1.Text = ""
                    End If
                    Gtg_ConsultaPruebasADigitar.DataSource = Objeto_Rh.ConsulPrueADig()
                    Gtg_ConsultaPruebasADigitar.DataBind()
                    Dim Count2 As Integer = Gtg_ConsultaPruebasADigitar.Rows.Count
                    If Count2 > 0 Then
                        LblCantidad2.Text = "Vs Pruebas a Presentar: " & Count2
                    Else
                        LblCantidad2.Text = ""
                    End If
                    Comparar.Visible = True
                    Pnl_Versus.Visible = False
            End Select
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Public Sub LimpiarGrillas()
        Gtg_ConsultaPruebas.DataSource = Nothing
        Gtg_ConsultaPruebas.DataBind()
        LblCantidad1.Text = ""
        Lbl_Cantidad.Text = ""
        Gtg_ConsultaPruebasADigitar.DataSource = Nothing
        Gtg_ConsultaPruebasADigitar.DataBind()
        LblCantidad2.Text = ""
        Gtg_ConsultaPruebas.DataSource = Nothing
        Gtg_ConsultaPruebas.DataBind()
        Gtg_ConsultaResultados.DataSource = Nothing
        Gtg_ConsultaResultados.DataBind()
    End Sub
    Protected Sub Comparar_Click(sender As Object, e As EventArgs) Handles Comparar.Click
        Pnl_Versus.Visible = True
        Comparar.Visible = False
    End Sub
    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        If Not IsNothing(Objeto_Gestion_Datos.Ex) Then
            Pnl_Message.CssClass = Objeto_Gestion_Datos.Ex("Alert")
            lblmsg.Text = Objeto_Gestion_Datos.Ex("Message")
        End If
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "P", "Pleg_Loading();", True)
    End Sub

End Class