Public Class Cambio_Horarios_Aprobacion
    Inherits System.Web.UI.Page
    Dim ObjAdmin As New clsrrhh
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Aprobacion y Desaprobacion de Cambios de Horario"
                Cargar_Solicitudes()
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Private Sub Cargar_Solicitudes()
        Try
            ObjAdmin.Validacion = "Cambio_Horarios_Aprobacion"
            Session("Dtg_solicitudes.Cambio_Horarios_Aprobacion") = ObjAdmin.Consulta_Solicitudes_Cambio_Horario()
            Dtg_Solicitudes.DataSource = Session("Dtg_solicitudes.Cambio_Horarios_Aprobacion")
            Dtg_Solicitudes.DataBind()
            LblCuenta.Text = "Solicitudes Pendientes: " & ObjAdmin.cantidad
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub Dtg_Solicitudes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Dtg_Solicitudes.RowCommand
        Try
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Dt As DataTable
            If e.CommandName = "Seleccione" Then
                ObjAdmin.codigo = Dtg_Solicitudes.Rows(index).Cells(0).Text
                Dt = ObjAdmin.Consulta_General_Solicitudes_Cambio_Horario()
                Lbl_Codigo_Ingeniero.Text = Dtg_Solicitudes.Rows(index).Cells(2).Text
                Lbl_Fecha_Turno.Text = Dtg_Solicitudes.Rows(index).Cells(5).Text.Substring(0, 10)
                Lbl_Codigo_Horario.Text = Dtg_Solicitudes.Rows(index).Cells(1).Text
                Lbl_Codigo_Solicitud.Text = Dtg_Solicitudes.Rows(index).Cells(0).Text
                Lbl_Tipo_Horario_Ant.Text = Dt.Rows(0).Item("Tip_Hor_Ant").ToString
                Lbl_Cod_Tipo_Horario_Ant.Text = Dt.Rows(0).Item("Cod_Tip_Hor_Ant").ToString
                Lbl_Hora_Ingreso_Ant.Text = obtenerHoraMinuto(Dt.Rows(0).Item("Fc_Ing_Ant")).ToString
                Lbl_Hora_Salida_Ant.Text = obtenerHoraMinuto(Dt.Rows(0).Item("Fc_Sal_Ant")).ToString
                Lbl_Segmento_Ant.Text = Dt.Rows(0).Item("Segmento_Ant").ToString
                Lbl_Jefe_Inmediato_Ant.Text = Dt.Rows(0).Item("Jef_Inm_Ant").ToString

                Lbl_Hora_Ingreso_A_Ant.Text = Validar_Hora(Dt.Rows(0).Item("H_ING_A_Ant").ToString).Substring(0, 5)
                Lbl_Hora_Salida_A_Ant.Text = Validar_Hora(Dt.Rows(0).Item("H_SAL_A_Ant").ToString).Substring(0, 5)
                Lbl_Hora_Ingreso_B1_Ant.Text = Validar_Hora(Dt.Rows(0).Item("H_ING_B1_Ant").ToString).Substring(0, 5)
                Lbl_Hora_Salida_B1_Ant.Text = Validar_Hora(Dt.Rows(0).Item("H_SAL_B1_Ant").ToString).Substring(0, 5)
                Lbl_Hora_Ingreso_B2_Ant.Text = Validar_Hora(Dt.Rows(0).Item("H_ING_B2_Ant").ToString).Substring(0, 5)
                Lbl_Hora_Salida_B2_Ant.Text = Validar_Hora(Dt.Rows(0).Item("H_SAL_B2_Ant").ToString).Substring(0, 5)
                Lbl_Hora_Ingreso_C_Ant.Text = Validar_Hora(Dt.Rows(0).Item("H_ING_C_Ant").ToString).Substring(0, 5)
                Lbl_Hora_Salida_C_Ant.Text = Validar_Hora(Dt.Rows(0).Item("H_SAL_C_Ant").ToString).Substring(0, 5)
                Lbl_Hora_Ingreso_P_Ant.Text = Validar_Hora(Dt.Rows(0).Item("H_ING_P_Ant").ToString).Substring(0, 5)
                Lbl_Hora_Salida_P_Ant.Text = Validar_Hora(Dt.Rows(0).Item("H_SAL_P_Ant").ToString).Substring(0, 5)

                Lbl_Tipo_Horario_New.Text = Dt.Rows(0).Item("Tip_Hor_New").ToString
                Lbl_Cod_Tipo_Horario_New.Text = Dt.Rows(0).Item("Cod_Tip_Hor_New").ToString
                Lbl_Hora_Ingreso_New.Text = obtenerHoraMinuto(Dt.Rows(0).Item("Fc_Ing_New")).ToString
                Lbl_Hora_Salida_New.Text = obtenerHoraMinuto(Dt.Rows(0).Item("Fc_Sal_New")).ToString
                Lbl_Segmento_New.Text = Dt.Rows(0).Item("Segmento_New").ToString
                Lbl_Jefe_Inmediato_New.Text = Dt.Rows(0).Item("Jef_Inm_New").ToString

                Lbl_Hora_Ingreso_A_New.Text = Validar_Hora(Dt.Rows(0).Item("H_ING_A_New").ToString).Substring(0, 5)
                Lbl_Hora_Salida_A_New.Text = Validar_Hora(Dt.Rows(0).Item("H_SAL_A_New").ToString).Substring(0, 5)
                Lbl_Hora_Ingreso_B1_New.Text = Validar_Hora(Dt.Rows(0).Item("H_ING_B1_New").ToString).Substring(0, 5)
                Lbl_Hora_Salida_B1_New.Text = Validar_Hora(Dt.Rows(0).Item("H_SAL_B1_New").ToString).Substring(0, 5)
                Lbl_Hora_Ingreso_B2_New.Text = Validar_Hora(Dt.Rows(0).Item("H_ING_B2_New").ToString).Substring(0, 5)
                Lbl_Hora_Salida_B2_New.Text = Validar_Hora(Dt.Rows(0).Item("H_SAL_B2_New").ToString).Substring(0, 5)
                Lbl_Hora_Ingreso_C_New.Text = Validar_Hora(Dt.Rows(0).Item("H_ING_C_New").ToString).Substring(0, 5)
                Lbl_Hora_Salida_C_New.Text = Validar_Hora(Dt.Rows(0).Item("H_SAL_C_New").ToString).Substring(0, 5)
                Lbl_Hora_Ingreso_P_New.Text = Validar_Hora(Dt.Rows(0).Item("H_ING_P_New").ToString).Substring(0, 5)
                Lbl_Hora_Salida_P_New.Text = Validar_Hora(Dt.Rows(0).Item("H_SAL_P_New").ToString).Substring(0, 5)

                Pnl_Registro.Visible = True
                Pnl_Dtg_Solicitudes.Visible = False
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Protected Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Try
            Limpiar()
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Protected Sub Btn_Aprobar_Click(sender As Object, e As EventArgs) Handles Btn_Aprobar.Click
        Try
            ObjAdmin.Validacion = "Aprobar"
            ObjAdmin.idusuario = CType(Session("permisos"), clsusuario).usuario
            ObjAdmin.codigo = Lbl_Codigo_Solicitud.Text
            ObjAdmin.Cod_Archivo = Lbl_Codigo_Horario.Text
            ObjAdmin.Tipo_Horario = Lbl_Cod_Tipo_Horario_New.Text
            ObjAdmin.fcini = Lbl_Fecha_Turno.Text & " " & Lbl_Hora_Ingreso_New.Text
            ObjAdmin.fcfin = Lbl_Fecha_Turno.Text & " " & Lbl_Hora_Salida_New.Text
            ObjAdmin.Segmento = Lbl_Segmento_New.Text
            ObjAdmin.Jefe_Inmediato = Lbl_Jefe_Inmediato_New.Text
            Dim Horas(10) As String
            Horas(1) = Lbl_Hora_Ingreso_A_New.Text
            Horas(2) = Lbl_Hora_Salida_A_New.Text
            Horas(3) = Lbl_Hora_Ingreso_B1_New.Text
            Horas(4) = Lbl_Hora_Salida_B1_New.Text
            Horas(5) = Lbl_Hora_Ingreso_B2_New.Text
            Horas(6) = Lbl_Hora_Salida_B2_New.Text
            Horas(7) = Lbl_Hora_Ingreso_C_New.Text
            Horas(8) = Lbl_Hora_Salida_C_New.Text
            Horas(9) = Lbl_Hora_Ingreso_P_New.Text
            Horas(10) = Lbl_Hora_Salida_P_New.Text
            ObjAdmin.Horas = Horas
            ObjAdmin.Aprobar_Rechazar_Solicitud_Cambio_Horario()
            Limpiar()
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Ha sido aprobado el cambio de turno!"
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Protected Sub Btn_Rechazar_Click(sender As Object, e As EventArgs) Handles Btn_Rechazar.Click
        Try
            ObjAdmin.Validacion = "Rechazar"
            ObjAdmin.codigo = Lbl_Codigo_Solicitud.Text
            ObjAdmin.idusuario = CType(Session("permisos"), clsusuario).usuario
            ObjAdmin.Aprobar_Rechazar_Solicitud_Cambio_Horario()
            Limpiar()
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Ha sido rechazado el cambio de turno!"
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Private Function Validar_Hora(Hora As String)
        If Hora = Nothing Then
            Hora = "00:00"
        End If
        Return Hora
    End Function
    Function obtenerHoraMinuto(ByVal fecha As Date) As String
        Dim horaMinuto As String = "00:00"
        Dim hora As String = "00"
        Dim minuto As String = "00"
        If Len(Trim(Str(fecha.Hour))) = 1 Then
            hora = "0" & fecha.Hour
        Else
            hora = fecha.Hour
        End If
        If Len(Trim(Str(fecha.Minute))) = 1 Then
            minuto = "0" & fecha.Minute
        Else
            minuto = fecha.Minute
        End If
        horaMinuto = hora & ":" & minuto
        obtenerHoraMinuto = horaMinuto
    End Function
    Private Sub Limpiar()
        Cargar_Solicitudes()
        Pnl_Registro.Visible = False
        Pnl_Dtg_Solicitudes.Visible = True
        Lbl_Codigo_Ingeniero.Text = Nothing
        Lbl_Fecha_Turno.Text = Nothing
        Lbl_Codigo_Horario.Text = Nothing
        Lbl_Codigo_Solicitud.Text = Nothing
        Lbl_Tipo_Horario_Ant.Text = Nothing
        Lbl_Hora_Ingreso_Ant.Text = Nothing
        Lbl_Hora_Salida_Ant.Text = Nothing
        Lbl_Segmento_Ant.Text = Nothing
        Lbl_Jefe_Inmediato_Ant.Text = Nothing
        Lbl_Hora_Ingreso_A_Ant.Text = Nothing
        Lbl_Hora_Salida_A_Ant.Text = Nothing
        Lbl_Hora_Ingreso_B1_Ant.Text = Nothing
        Lbl_Hora_Salida_B1_Ant.Text = Nothing
        Lbl_Hora_Ingreso_B2_Ant.Text = Nothing
        Lbl_Hora_Salida_B2_Ant.Text = Nothing
        Lbl_Hora_Ingreso_C_Ant.Text = Nothing
        Lbl_Hora_Salida_C_Ant.Text = Nothing
        Lbl_Hora_Ingreso_P_Ant.Text = Nothing
        Lbl_Hora_Salida_P_Ant.Text = Nothing
        Lbl_Tipo_Horario_New.Text = Nothing
        Lbl_Hora_Ingreso_New.Text = Nothing
        Lbl_Hora_Salida_New.Text = Nothing
        Lbl_Segmento_New.Text = Nothing
        Lbl_Jefe_Inmediato_New.Text = Nothing
        Lbl_Hora_Ingreso_A_New.Text = Nothing
        Lbl_Hora_Salida_A_New.Text = Nothing
        Lbl_Hora_Ingreso_B1_New.Text = Nothing
        Lbl_Hora_Salida_B1_New.Text = Nothing
        Lbl_Hora_Ingreso_B2_New.Text = Nothing
        Lbl_Hora_Salida_B2_New.Text = Nothing
        Lbl_Hora_Ingreso_C_New.Text = Nothing
        Lbl_Hora_Salida_C_New.Text = Nothing
        Lbl_Hora_Ingreso_P_New.Text = Nothing
        Lbl_Hora_Salida_P_New.Text = Nothing
    End Sub
End Class