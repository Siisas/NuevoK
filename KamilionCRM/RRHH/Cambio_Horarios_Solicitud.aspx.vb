Public Class Cambio_Horarios_Solicitud
    Inherits System.Web.UI.Page
    Dim ObjAdmin As New clsrrhh
    Dim Jornada As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then
                Session("Formulario") = "Solicitud Cambio de Horarios"
                Cargar_DRLS_INICIAL()
                Cargar_Solicitudes()
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Private Sub Cargar_DRLS_INICIAL()
        Try
            ObjAdmin.Validacion = "Turno"
            Dim Dts As DataSet = ObjAdmin.Cargar_DRLS_Horarios()
            With DrlHora_Ingreso
                .DataSource = Dts.Tables(0)
                .DataTextField = "Hora"
                .DataValueField = "Hora"
                .DataBind()
                .Items.Insert(0, "- Seleccione -")
                .Items.Item(0).Value = "0"
            End With
            With DrlHora_Salida
                .DataSource = Dts.Tables(0)
                .DataTextField = "Hora"
                .DataValueField = "Hora"
                .DataBind()
                .Items.Insert(0, "- Seleccione -")
                .Items.Item(0).Value = "0"
            End With
            ObjAdmin.Validacion = "JEFE_&_SEGMENTO"
            Dts = ObjAdmin.Cargar_DRLS_Horarios()
            With DrlJefeInmediato
                .DataSource = Dts.Tables(0)
                .DataTextField = "Jefe_Inmediato"
                .DataValueField = "Jefe_Inmediato"
                .DataBind()
                .Items.Insert(0, "- Seleccione -")
                .Items.Item(0).Value = "0"
            End With
            With DrlSegmento
                .DataSource = Dts.Tables(1)
                .DataTextField = "Segmento"
                .DataValueField = "Segmento"
                .DataBind()
                .Items.Insert(0, "- Seleccione -")
                .Items.Item(0).Value = "0"
            End With
            With drlTipoHorario
                .DataSource = Dts.Tables(2)
                .DataTextField = "Nombre"
                .DataValueField = "Codigo"
                .DataBind()
                .Items.Item(0).Value = "0"
            End With
            'ALMUERZO
            ObjAdmin.Validacion = "Almuerzo"
            Dts = ObjAdmin.Cargar_DRLS_Horarios()
            With DrlHora_Almuerzo_1
                .DataSource = Dts.Tables(0)
                .DataTextField = "H_ING_A"
                .DataValueField = "H_ING_A"
                .DataBind()
                .Items.Insert(0, "00:00")
            End With
            With DrlHora_Almuerzo_2
                .DataSource = Dts.Tables(0)
                .DataTextField = "H_SAL_A"
                .DataValueField = "H_SAL_A"
                .DataBind()
                .Items.Insert(0, "00:00")
            End With
            ObjAdmin.Validacion = Nothing
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Private Sub Cargar_Solicitudes()
        Try

            Dim Perfil As String = CType(Session("permisos"), clsusuario).perfil
            Dim NomPerfil As String = CType(Session("permisos"), clsusuario).NomPerfil
            If Perfil <> 1 And Perfil <> 3 And NomPerfil <> "Datamarshall" And Not NomPerfil.Contains("Supervisor") And NomPerfil <> "Gerente" And NomPerfil <> "Coordinador Op Cl" And NomPerfil <> "Desarrollo Sn" And NomPerfil <> "Desarrollo Jn" Then
                ObjAdmin.Validacion = "Cambio_Horarios_Solicitud_NO"
                ObjAdmin.codigo = CType(Session("permisos"), clsusuario).Codnom
                Pnl_Consulta.Visible = False
            Else
                ObjAdmin.Validacion = "Cambio_Horarios_Solicitud"
                Pnl_Consulta.Visible = True
            End If
            Session("Dtg_solicitudes.Cambio_Horarios_Solicitud") = ObjAdmin.Consulta_Solicitudes_Cambio_Horario()
            Dtg_Solicitudes.DataSource = Session("Dtg_solicitudes.Cambio_Horarios_Solicitud")
            Dtg_Solicitudes.DataBind()
            LblCuenta.Text = "Solicitudes Pendientes: " & ObjAdmin.cantidad
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click
        Try
            If TxtCod_Agente.Text = Nothing Or TxtFecha_Turno.Text = Nothing Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Es necesario llenar los dos criterios de busqueda (CODIGO & FECHA)!"
                Exit Sub
            End If
            ObjAdmin.codigo = TxtCod_Agente.Text
            ObjAdmin.turno = TxtFecha_Turno.Text
            Dim Dt As DataTable = ObjAdmin.Consulta_Registro_Horarios().Tables(0)
            If ObjAdmin.cantidad < 1 Then
                Pnl_Message.CssClass = "alert alert-info"
                lblmsg.Text = "<span class='glyphicon glyphicon-info-sign'></span> El agente o ingeniero no cuenta con malla de turno para la fecha " & TxtFecha_Turno.Text
                Dt = Nothing
                Pnl_Registro.Visible = False
                Inhabilitar_Campos(False)
            Else
                LblCod_Horario.Text = Dt.Rows(0).Item("Cod_Validacion_Horario")
                LblCod_Agente.Text = Dt.Rows(0).Item("Cod_Agente")
                LblFec_Turno.Text = TxtFecha_Turno.Text
                drlTipoHorario.SelectedValue = Dt.Rows(0).Item("Tipo_Horario")
                DrlHora_Ingreso.SelectedValue = obtenerHoraMinuto(Dt.Rows(0).Item("Fc_Ingreso"))
                DrlHora_Salida.SelectedValue = obtenerHoraMinuto(Dt.Rows(0).Item("Fc_Salida"))
                DrlSegmento.SelectedValue = Dt.Rows(0).Item("Segmento").ToString.ToUpper
                DrlJefeInmediato.SelectedValue = Dt.Rows(0).Item("Jefe_Inmediato").ToString.ToUpper
                If drlTipoHorario.SelectedItem.Value = 2 Or drlTipoHorario.SelectedItem.Value = 10 Or drlTipoHorario.SelectedItem.Value = 11 Or drlTipoHorario.SelectedItem.Value = 12 Or drlTipoHorario.SelectedItem.Value = 14 Or drlTipoHorario.SelectedItem.Value = 15 Then
                    Jornada = "Descanso"
                    Cargar_DRLS("Descanso")
                    Inhabilitar_Campos(True)
                Else
                    Cargar_DRLS(drlTipoHorario.SelectedItem.Text)
                    Inhabilitar_Campos(False)
                End If
                Drl_Hora_Break1_1.SelectedValue = Validar_Hora(Dt.Rows(0).Item("H_ING_B1").ToString).ToString.Substring(0, 5)
                Drl_Hora_Break1_2.SelectedValue = Validar_Hora(Dt.Rows(0).Item("H_SAL_B1").ToString).ToString.Substring(0, 5)
                Drl_Hora_Break2_1.SelectedValue = Validar_Hora(Dt.Rows(0).Item("H_ING_B2").ToString).ToString.Substring(0, 5)
                Drl_Hora_Break2_2.SelectedValue = Validar_Hora(Dt.Rows(0).Item("H_SAL_B2").ToString).ToString.Substring(0, 5)
                DrlHora_Almuerzo_1.SelectedValue = Validar_Hora(Dt.Rows(0).Item("H_ING_A").ToString).ToString.Substring(0, 5)
                DrlHora_Almuerzo_2.SelectedValue = Validar_Hora(Dt.Rows(0).Item("H_SAL_A").ToString).ToString.Substring(0, 5)
                Txt_Pre_Turno_1.Text = Validar_Hora(Dt.Rows(0).Item("H_ING_P").ToString).ToString.Substring(0, 5)
                Txt_Pre_Turno_2.Text = Validar_Hora(Dt.Rows(0).Item("H_SAL_P").ToString).ToString.Substring(0, 5)
                Txt_Hora_Capacitacion_1.Text = Validar_Hora(Dt.Rows(0).Item("H_ING_C").ToString).ToString.Substring(0, 5)
                Txt_Hora_Capacitacion_2.Text = Validar_Hora(Dt.Rows(0).Item("H_SAL_C").ToString).ToString.Substring(0, 5)
                Pnl_Registro.Visible = True
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span Class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Private Sub Cargar_DRLS(Horario As String)
        Try
            If Horario = "Descanso" Then
                Txt_Hora_Capacitacion_1.Text = "00:00"
                Txt_Hora_Capacitacion_2.Text = "00:00"
                Txt_Pre_Turno_1.Text = "00:00"
                Txt_Pre_Turno_2.Text = "00:00"
            End If
            If Horario <> "Descanso" Then
                Verificar_jornada(DrlHora_Ingreso.SelectedItem.Text, DrlHora_Salida.SelectedItem.Text)
            End If
            ObjAdmin.Validacion = Jornada
            Dim Dts As DataSet = ObjAdmin.Cargar_DRLS_Horarios()
            'BREAK 1
            With Drl_Hora_Break1_1
                .DataSource = Dts.Tables(0)
                .DataTextField = "H_ING_B1"
                .DataValueField = "H_ING_B1"
                .DataBind()
                .Items.Insert(0, "00:00")
            End With
            With Drl_Hora_Break1_2
                .DataSource = Dts.Tables(0)
                .DataTextField = "H_SAL_B1"
                .DataValueField = "H_SAL_B1"
                .DataBind()
                .Items.Insert(0, "00:00")
            End With
            'BREAK 2
            With Drl_Hora_Break2_1
                .DataSource = Dts.Tables(1)
                .DataTextField = "H_ING_B2"
                .DataValueField = "H_ING_B2"
                .DataBind()
                .Items.Insert(0, "00:00")
            End With
            With Drl_Hora_Break2_2
                .DataSource = Dts.Tables(1)
                .DataTextField = "H_SAL_B2"
                .DataValueField = "H_SAL_B2"
                .DataBind()
                .Items.Insert(0, "00:00")
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Verificar_jornada(Ingreso As String, Salida As String)
        Try
            If (Ingreso = "06:00" And Salida = "14:00") Or (Ingreso = "07:00" And Salida = "15:00") Then
                Jornada = "Mañana"
                PnlAlmuerzo.Enabled = False
            ElseIf (Ingreso = "08:00" And Salida = "17:00") Then
                Jornada = "Oficina"
                PnlAlmuerzo.Enabled = True
            ElseIf (Ingreso = "14:00" And Salida = "22:00") Or (Ingreso = "13:00" And Salida = "21:00") Then
                Jornada = "Tarde"
                PnlAlmuerzo.Enabled = False
            ElseIf (Ingreso = "22:00" And Salida = "06:00") Then
                Jornada = "Noche"
                PnlAlmuerzo.Enabled = False
            Else
                Jornada = "Personalizada"
                PnlAlmuerzo.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
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
    Private Sub Inhabilitar_Campos(Val As Boolean)
        Try
            If Val = True Then
                DrlHora_Ingreso.Enabled = False
                DrlHora_Salida.Enabled = False
                DrlHora_Almuerzo_1.Enabled = False
                Drl_Hora_Break1_1.Enabled = False
                Drl_Hora_Break2_1.Enabled = False
                Txt_Hora_Capacitacion_1.Enabled = False
                Txt_Hora_Capacitacion_2.Enabled = False
            Else
                DrlHora_Ingreso.Enabled = True
                DrlHora_Salida.Enabled = True
                DrlHora_Almuerzo_1.Enabled = True
                Drl_Hora_Break1_1.Enabled = True
                Drl_Hora_Break2_1.Enabled = True
                Txt_Hora_Capacitacion_1.Enabled = True
                Txt_Hora_Capacitacion_2.Enabled = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub drlTipoHorario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drlTipoHorario.SelectedIndexChanged
        Try
            If drlTipoHorario.SelectedItem.Value <> 3 And drlTipoHorario.SelectedItem.Value <> 13 Then
                DrlHora_Ingreso.SelectedValue = "00:00"
                DrlHora_Salida.SelectedValue = "00:00"
                Jornada = "Descanso"
                Cargar_DRLS("Descanso")
                Drl_Hora_Break1_1.SelectedValue = "00:00"
                Drl_Hora_Break1_2.SelectedValue = "00:00"
                Drl_Hora_Break2_2.SelectedValue = "00:00"
                Drl_Hora_Break2_1.SelectedValue = "00:00"
                DrlHora_Almuerzo_1.SelectedValue = "00:00"
                DrlHora_Almuerzo_2.SelectedValue = "00:00"
                Txt_Hora_Capacitacion_1.Text = "00:00"
                Txt_Hora_Capacitacion_2.Text = "00:00"
                Txt_Pre_Turno_1.Text = "00:00"
                Txt_Pre_Turno_2.Text = "00:00"
                Inhabilitar_Campos(True)
            ElseIf drlTipoHorario.SelectedItem.Value = 3 Then
                Dim TH As Integer = drlTipoHorario.SelectedValue
                Btn_Buscar_Click(sender, e)
                drlTipoHorario.SelectedValue = TH
                Inhabilitar_Campos(False)
            ElseIf drlTipoHorario.SelectedItem.Value = 13 Then
                Jornada = "Personalizada"
                Cargar_DRLS("Descanso")
                Inhabilitar_Campos(False)
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span Class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Protected Sub DrlHora_Ingreso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DrlHora_Ingreso.SelectedIndexChanged
        Try
            If DrlHora_Ingreso.SelectedValue = "00:00" Then
                DrlHora_Salida.SelectedValue = "00:00"
                drlTipoHorario.SelectedValue = 2
                drlTipoHorario_SelectedIndexChanged(sender, e)
            ElseIf DrlHora_Ingreso.SelectedValue = "06:00" Then
                DrlHora_Salida.SelectedValue = "14:00"
            ElseIf DrlHora_Ingreso.SelectedValue = "07:00" Then
                DrlHora_Salida.SelectedValue = "15:00"
            ElseIf DrlHora_Ingreso.SelectedValue = "08:00" Then
                DrlHora_Salida.SelectedValue = "17:00"
            ElseIf DrlHora_Ingreso.SelectedValue = "13:00" Then
                DrlHora_Salida.SelectedValue = "21:00"
            ElseIf DrlHora_Ingreso.SelectedValue = "14:00" Then
                DrlHora_Salida.SelectedValue = "22:00"
            ElseIf DrlHora_Ingreso.SelectedValue = "22:00" Then
                DrlHora_Salida.SelectedValue = "06:00"
            Else
                DrlHora_Salida.SelectedValue = 0
            End If
            Cargar_DRLS(drlTipoHorario.SelectedItem.Text)
            If DrlHora_Ingreso.SelectedValue = "0" Then
                Txt_Pre_Turno_1.Text = "00:00"
                Txt_Pre_Turno_2.Text = "00:00"
            Else
                Txt_Pre_Turno_2.Text = DrlHora_Ingreso.SelectedValue
                Dim N1 As String
                Dim N2 As String
                N1 = DrlHora_Ingreso.SelectedValue.Substring(0, 2)
                N2 = DrlHora_Ingreso.SelectedValue.Substring(3, 2)
                If N2 = "00" Then
                    N1 = Int(N1 - 1)
                    If Len(Trim(Str(N1))) = 1 Then
                        N1 = "0" & N1
                    End If
                    N2 = "45"
                Else
                    N2 = Int(N2 - 15)
                    If Len(Trim(Str(N2))) = 1 Then
                        N2 = "0" & N2
                    End If
                End If
                Txt_Pre_Turno_1.Text = N1 & ":" & N2
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span Class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Protected Sub DrlHora_Salida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DrlHora_Salida.SelectedIndexChanged
        Try
            Cargar_DRLS(drlTipoHorario.SelectedItem.Text)
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span Class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Protected Sub DrlHora_Almuerzo_1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DrlHora_Almuerzo_1.SelectedIndexChanged
        Try
            If DrlHora_Almuerzo_1.SelectedValue = "00:00" Then
                DrlHora_Almuerzo_2.SelectedValue = "00:00"
            ElseIf DrlHora_Almuerzo_1.SelectedValue = "12:00" Then
                DrlHora_Almuerzo_2.SelectedValue = "13:00"
            Else
                DrlHora_Almuerzo_2.SelectedValue = "14:00"
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span Class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Protected Sub Drl_Hora_Break1_1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Drl_Hora_Break1_1.SelectedIndexChanged
        Try
            Dim N1 As String
            Dim N2 As String
            N1 = Drl_Hora_Break1_1.SelectedValue.Substring(0, 2)
            N2 = Drl_Hora_Break1_1.SelectedValue.Substring(3, 2)
            If N2 = "45" Then
                N1 = Int(N1 + 1)
                If Len(Trim(Str(N1))) = 1 Then
                    N1 = "0" & N1
                End If
                N2 = "00"
            Else
                N2 = Int(N2 + 15)
            End If
            If Drl_Hora_Break1_1.SelectedValue = "23:45" Then
                Drl_Hora_Break1_2.SelectedValue = "00:00"
            Else
                Drl_Hora_Break1_2.SelectedValue = N1 & ":" & N2
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span Class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Protected Sub Drl_Hora_Brea2_1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Drl_Hora_Break2_1.SelectedIndexChanged
        Try
            Dim N1 As String
            Dim N2 As String
            N1 = Drl_Hora_Break2_1.SelectedValue.Substring(0, 2)
            N2 = Drl_Hora_Break2_1.SelectedValue.Substring(3, 2)
            If N2 = "45" Then
                N1 = Int(N1 + 1)
                If Len(Trim(Str(N1))) = 1 Then
                    N1 = "0" & N1
                End If
                N2 = "00"
            Else
                N2 = Int(N2 + 15)
            End If
            If Drl_Hora_Break2_1.SelectedValue = "23:45" Then
                Drl_Hora_Break2_2.SelectedValue = "00:00"
            Else
                Drl_Hora_Break2_2.SelectedValue = N1 & ":" & N2
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span Class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Protected Sub Btn_Solicitar_Click(sender As Object, e As EventArgs) Handles Btn_Solicitar.Click
        Try
            If drlTipoHorario.SelectedItem.Value = "0" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Se requiere una seleccion en Tipo de Horario!"
                Exit Sub
            End If
            If DrlHora_Ingreso.SelectedItem.Value = "0" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Se requiere una seleccion en Hora Ingreso!"
                Exit Sub
            End If
            If DrlHora_Salida.SelectedItem.Value = "0" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Se requiere una seleccion en Hora Salida!"
                Exit Sub
            End If
            If DrlSegmento.SelectedItem.Value = "0" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Se requiere una seleccion en Segmento!"
                Exit Sub
            End If
            If DrlJefeInmediato.SelectedItem.Value = "0" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Se requiere una seleccion en Jefe Inmediato!"
                Exit Sub
            End If
            ObjAdmin.idusuario = CType(Session("permisos"), clsusuario).usuario
            ObjAdmin.codigo = LblCod_Agente.Text
            ObjAdmin.Cod_Archivo = LblCod_Horario.Text
            ObjAdmin.Tipo_Horario = drlTipoHorario.SelectedItem.Value
            ObjAdmin.fcini = LblFec_Turno.Text & " " & DrlHora_Ingreso.SelectedItem.Value
            ObjAdmin.fcfin = LblFec_Turno.Text & " " & DrlHora_Salida.SelectedItem.Value
            ObjAdmin.Segmento = DrlSegmento.SelectedItem.Text
            ObjAdmin.Jefe_Inmediato = DrlJefeInmediato.SelectedItem.Text
            Dim Horas(10) As String
            Horas(1) = DrlHora_Almuerzo_1.SelectedItem.Value
            Horas(2) = DrlHora_Almuerzo_2.SelectedItem.Value
            Horas(3) = Drl_Hora_Break1_1.SelectedItem.Value
            Horas(4) = Drl_Hora_Break1_2.SelectedItem.Value
            Horas(5) = Drl_Hora_Break2_1.SelectedItem.Value
            Horas(6) = Drl_Hora_Break2_2.SelectedItem.Value
            Horas(7) = Validar_Hora(Txt_Hora_Capacitacion_1.Text)
            Horas(8) = Validar_Hora(Txt_Hora_Capacitacion_2.Text)
            Horas(9) = Validar_Hora(Txt_Pre_Turno_1.Text)
            Horas(10) = Validar_Hora(Txt_Pre_Turno_2.Text)
            ObjAdmin.Horas = Horas
            ObjAdmin.Registro_Solicitud_Cambio_Horario()
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Registro exitoso!"
            Limpiar()
            Inhabilitar_Campos(False)
            Pnl_Registro.Visible = False
            Cargar_Solicitudes()
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span Class='glyphicon glyphicon-remove-sign'></span> " & ex.Message
        End Try
    End Sub
    Private Sub Limpiar()
        TxtFecha_Turno.Text = Nothing
        TxtCod_Agente.Text = Nothing
        LblCod_Agente.Text = Nothing
        LblCod_Horario.Text = Nothing
        LblFec_Turno.Text = Nothing
        drlTipoHorario.SelectedValue = 0
        DrlHora_Ingreso.SelectedValue = 0
        DrlHora_Salida.SelectedValue = 0
        DrlSegmento.SelectedValue = 0
        DrlJefeInmediato.SelectedValue = 0
        DrlHora_Almuerzo_1.SelectedIndex = 0
        DrlHora_Almuerzo_2.SelectedIndex = 0
        Drl_Hora_Break1_1.Items.Clear()
        Drl_Hora_Break1_1.DataSource = Nothing
        Drl_Hora_Break1_1.DataBind()
        Drl_Hora_Break1_2.Items.Clear()
        Drl_Hora_Break1_2.DataSource = Nothing
        Drl_Hora_Break1_2.DataBind()
        Drl_Hora_Break2_1.Items.Clear()
        Drl_Hora_Break2_1.DataSource = Nothing
        Drl_Hora_Break2_1.DataBind()
        Drl_Hora_Break2_2.Items.Clear()
        Drl_Hora_Break2_2.DataSource = Nothing
        Drl_Hora_Break2_2.DataBind()
        Txt_Hora_Capacitacion_1.Text = Nothing
        Txt_Hora_Capacitacion_2.Text = Nothing
        Txt_Pre_Turno_1.Text = Nothing
        Txt_Pre_Turno_2.Text = Nothing
    End Sub
    Private Function Validar_Hora(Hora As String)
        If Hora = Nothing Then
            Hora = "00:00"
        End If
        Return Hora
    End Function

    Private Sub DrlHora_Ingreso_DataBinding(sender As Object, e As EventArgs) Handles DrlHora_Ingreso.DataBinding

    End Sub
End Class