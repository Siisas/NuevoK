Public Class RRHH_PruebasAsp
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
                Session("Formulario") = "Inicio Pruebas"

            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub BtnIniciarPrueba_Click(sender As Object, e As EventArgs) Handles BtnIniciarPrueba.Click
        Try
            Objeto_Gestion_Datos.Validar_Herramientas(TxtConsultaDoc, "Documento", "Numeric", 10,)
            Objeto_Rh.Documento = TxtConsultaDoc.Text.Trim
            Objeto_Rh.CargarDatosAspirante()
            If Objeto_Rh.Documento = "" Then
                Throw New Exception("Aspirante no existe en la base de datos")
            Else
                If Objeto_Rh.Cantidad > 0 Then
                    BtnComenzar.Visible = True
                End If
                Btn_Siguiente_P1.Visible = True
                Pnl_IniciarPrueba.Visible = False
                Pnl_DatosAspirante.Visible = True
                Pnl_Prueba1.Visible = True
                TxtDocAspActual.Text = Objeto_Rh.Documento
                TxtNombresAspActual.Text = Objeto_Rh.Nombre & " " & Objeto_Rh.Apellido
                Lbl_fkAspirante.Text = Objeto_Rh.IdRegistrarAsp
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
            Pnl_Message.CssClass = Objeto_Gestion_Datos.Ex("Alert")
            lblmsg.Text = Objeto_Gestion_Datos.Ex("Message")
        End Try
    End Sub
    Protected Sub Btn_Siguiente_P1_Click(sender As Object, e As EventArgs) Handles Btn_Siguiente_P1.Click
        Try
            Objeto_Rh.Codigo = TxtCod_P1.Text
            Objeto_Rh.Nombre = TxtNombre_P1.Text
            Objeto_Rh.Cedula = TxtCedula_P1.Text
            Objeto_Rh.Direccion = TxtDireccion_P1.Text
            Objeto_Rh.Email = TxtEmail_P1.Text
            Objeto_Rh.Empresa = TxtEmpresa_P1.Text
            Objeto_Rh.Cargo = TxtCargo_P1.Text
            Objeto_Rh.Telefono = TxtTElefono_P1.Text
            Objeto_Rh.Despacho = TxtDespacho_P1.Text
            Objeto_Rh.Nit = TxtNit_P1.Text
            Objeto_Rh.NumeroRegistro = 1
            Objeto_Rh.Fk_IdRegistrarAsp = Lbl_fkAspirante.Text
            Objeto_Rh.Fk_DatosDigitar = 1
            Objeto_Rh.Intentos = 1
            'Comparo las respuestas con las preguntas para sacar el puntaje antes de guardar en la base de datos
            Objeto_Rh.CargarRespuestasAspirante()
            If TxtCod_P1.Text = Objeto_Rh.Codigo1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtEmpresa_P1.Text = Objeto_Rh.Empresa1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtNombre_P1.Text = Objeto_Rh.Nombre1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtCargo_P1.Text = Objeto_Rh.Cargo1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtCedula_P1.Text = Objeto_Rh.Cedula1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtTElefono_P1.Text = Objeto_Rh.Telefono1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtDireccion_P1.Text = Objeto_Rh.Direccion1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtDespacho_P1.Text = Objeto_Rh.Despacho1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtEmail_P1.Text = Objeto_Rh.Email1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtNit_P1.Text = Objeto_Rh.Nit1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            Objeto_Rh.RegPrueba()
            Pnl_Prueba1.Visible = False
            Pnl_Prueba2.Visible = True
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_Siguiente_P2_Click(sender As Object, e As EventArgs) Handles Btn_Siguiente_P2.Click
        Try
            Objeto_Rh.Codigo = TxtCod_P2.Text
            Objeto_Rh.Nombre = TxtNombre_P2.Text
            Objeto_Rh.Cedula = TxtCedula_P2.Text
            Objeto_Rh.Direccion = TxtDireccion_P2.Text
            Objeto_Rh.Email = TxtEmail_P2.Text
            Objeto_Rh.Empresa = TxtEmpresa_P2.Text
            Objeto_Rh.Cargo = TxtCargo_P2.Text
            Objeto_Rh.Telefono = TxtCargo_P2.Text
            Objeto_Rh.Despacho = TxtDespacho_P2.Text
            Objeto_Rh.Nit = TxtNit_P2.Text
            Objeto_Rh.NumeroRegistro = 2
            Objeto_Rh.Fk_IdRegistrarAsp = Lbl_fkAspirante.Text
            Objeto_Rh.Fk_DatosDigitar = 2
            Objeto_Rh.Intentos = 1
            Objeto_Rh.CargarRespuestasAspirante()
            If TxtCod_P2.Text = Objeto_Rh.Codigo1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtEmpresa_P2.Text = Objeto_Rh.Empresa1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtNombre_P2.Text = Objeto_Rh.Nombre1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtCargo_P2.Text = Objeto_Rh.Cargo1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtCedula_P2.Text = Objeto_Rh.Cedula1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtTElefono_P2.Text = Objeto_Rh.Telefono1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtDireccion_P2.Text = Objeto_Rh.Direccion1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtDespacho_P2.Text = Objeto_Rh.Despacho1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtEmail_P2.Text = Objeto_Rh.Email1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtNit_P2.Text = Objeto_Rh.Nit1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            Objeto_Rh.RegPrueba()
            Pnl_Prueba2.Visible = False
            Pnl_Prueba3.Visible = True
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_Siguiente_P3_Click(sender As Object, e As EventArgs) Handles Btn_Siguiente_P3.Click
        Try
            Objeto_Rh.Codigo = TxtCod_P3.Text
            Objeto_Rh.Nombre = TxtNombre_P3.Text
            Objeto_Rh.Cedula = TxtCedula_P3.Text
            Objeto_Rh.Direccion = TxtDireccion_P3.Text
            Objeto_Rh.Email = TxtEmail_P3.Text
            Objeto_Rh.Empresa = TxtEmpresa_P3.Text
            Objeto_Rh.Cargo = TxtCargo_P3.Text
            Objeto_Rh.Telefono = TxtCargo_P3.Text
            Objeto_Rh.Despacho = TxtDespacho_P3.Text
            Objeto_Rh.Nit = TxtNit_P3.Text
            Objeto_Rh.NumeroRegistro = 3
            Objeto_Rh.Fk_IdRegistrarAsp = Lbl_fkAspirante.Text
            Objeto_Rh.Fk_DatosDigitar = 3
            Objeto_Rh.Intentos = 1
            Objeto_Rh.CargarRespuestasAspirante()
            If TxtCod_P3.Text = Objeto_Rh.Codigo1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtEmpresa_P3.Text = Objeto_Rh.Empresa1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtNombre_P3.Text = Objeto_Rh.Nombre1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtCargo_P3.Text = Objeto_Rh.Cargo1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtCedula_P3.Text = Objeto_Rh.Cedula1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtTElefono_P3.Text = Objeto_Rh.Telefono1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtDireccion_P3.Text = Objeto_Rh.Direccion1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtDespacho_P3.Text = Objeto_Rh.Despacho1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtEmail_P3.Text = Objeto_Rh.Email1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtNit_P3.Text = Objeto_Rh.Nit1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            Objeto_Rh.RegPrueba()
            Pnl_Prueba3.Visible = False
            Pnl_Prueba4.Visible = True
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_Siguiente_P4_Click(sender As Object, e As EventArgs) Handles Btn_Siguiente_P4.Click
        Try
            Objeto_Rh.Codigo = TxtCod_P4.Text
            Objeto_Rh.Nombre = TxtNombre_P4.Text
            Objeto_Rh.Cedula = TxtCedula_P4.Text
            Objeto_Rh.Direccion = TxtDireccion_P4.Text
            Objeto_Rh.Email = TxtEmail_P4.Text
            Objeto_Rh.Empresa = TxtEmpresa_P4.Text
            Objeto_Rh.Cargo = TxtCargo_P4.Text
            Objeto_Rh.Telefono = TxtCargo_P4.Text
            Objeto_Rh.Despacho = TxtDespacho_P4.Text
            Objeto_Rh.Nit = TxtNit_P4.Text
            Objeto_Rh.NumeroRegistro = 4
            Objeto_Rh.Fk_IdRegistrarAsp = Lbl_fkAspirante.Text
            Objeto_Rh.Fk_DatosDigitar = 4
            Objeto_Rh.Intentos = 1
            Objeto_Rh.CargarRespuestasAspirante()
            If TxtCod_P4.Text = Objeto_Rh.Codigo1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtEmpresa_P4.Text = Objeto_Rh.Empresa1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtNombre_P4.Text = Objeto_Rh.Nombre1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtCargo_P4.Text = Objeto_Rh.Cargo1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtCedula_P4.Text = Objeto_Rh.Cedula1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtTElefono_P4.Text = Objeto_Rh.Telefono1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtDireccion_P4.Text = Objeto_Rh.Direccion1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtDespacho_P4.Text = Objeto_Rh.Despacho1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtEmail_P4.Text = Objeto_Rh.Email1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtNit_P4.Text = Objeto_Rh.Nit1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            Objeto_Rh.RegPrueba()
            Pnl_Prueba4.Visible = False
            Pnl_Prueba5.Visible = True
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub Btn_FinalizarPruebaClick(sender As Object, e As EventArgs) Handles Btn_FinalizarPrueba.Click
        Try
            Pnl_Prueba5.Visible = True
            Objeto_Rh.Codigo = TxtCod_P5.Text
            Objeto_Rh.Nombre = TxtNombre_P5.Text
            Objeto_Rh.Cedula = TxtCedula_P5.Text
            Objeto_Rh.Direccion = TxtDireccion_P5.Text
            Objeto_Rh.Email = TxtEmail_P5.Text
            Objeto_Rh.Empresa = TxtEmpresa_P5.Text
            Objeto_Rh.Cargo = TxtCargo_P5.Text
            Objeto_Rh.Telefono = TxtCargo_P5.Text
            Objeto_Rh.Despacho = TxtDespacho_P5.Text
            Objeto_Rh.Nit = TxtNit_P5.Text
            Objeto_Rh.NumeroRegistro = 5
            Objeto_Rh.Fk_IdRegistrarAsp = Lbl_fkAspirante.Text
            Objeto_Rh.Fk_DatosDigitar = 5
            Objeto_Rh.Intentos = 1
            Objeto_Rh.CargarRespuestasAspirante()
            If TxtCod_P5.Text = Objeto_Rh.Codigo1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtEmpresa_P5.Text = Objeto_Rh.Empresa1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtNombre_P5.Text = Objeto_Rh.Nombre1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtCargo_P5.Text = Objeto_Rh.Cargo1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtCedula_P5.Text = Objeto_Rh.Cedula1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtTElefono_P5.Text = Objeto_Rh.Telefono1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtDireccion_P5.Text = Objeto_Rh.Direccion1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtDespacho_P5.Text = Objeto_Rh.Despacho1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtEmail_P5.Text = Objeto_Rh.Email1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            If TxtNit_P5.Text = Objeto_Rh.Nit1 Then
                Objeto_Rh.Puntaje += 2
            Else
                Objeto_Rh.Puntaje += 0
            End If
            Objeto_Rh.RegPrueba()
            Pnl_Message.CssClass = "alert alert-success"
            lblmsg.Text = "<span class='glyphicon glyphicon-ok-sign'></span> Ha Terminado la Prueba"
            Finished()
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Public Sub Finished()
        TxtCod_P5.Enabled = False
        TxtNombre_P5.Enabled = False
        TxtCedula_P5.Enabled = False
        TxtDireccion_P5.Enabled = False
        TxtEmail_P5.Enabled = False
        TxtEmpresa_P5.Enabled = False
        TxtCargo_P5.Enabled = False
        TxtCargo_P5.Enabled = False
        TxtDespacho_P5.Enabled = False
        TxtNit_P5.Enabled = False
        TxtTElefono_P5.Enabled = False
        Btn_FinalizarPrueba.Enabled = False
        Btn_Regresar.Visible = True
        Btn_Siguiente_P1.Visible = False
        TxtCod_P1.Enabled = False
        TxtNombre_P1.Enabled = False
        TxtCedula_P1.Enabled = False
        TxtDireccion_P1.Enabled = False
        TxtEmail_P1.Enabled = False
        TxtEmpresa_P1.Enabled = False
        TxtCargo_P1.Enabled = False
        TxtTElefono_P1.Enabled = False
        TxtDespacho_P1.Enabled = False
        TxtNit_P1.Enabled = False
        BtnComenzar.Visible = True
    End Sub
    Private Sub Btn_Regresar_Click(sender As Object, e As EventArgs) Handles Btn_Regresar.Click
        Pnl_Prueba5.Visible = False
        Pnl_IniciarPrueba.Visible = True
        Pnl_DatosAspirante.Visible = False
        TxtDocAspActual.Text = ""
        Lbl_fkAspirante.Text = ""
        TxtNombresAspActual.Text = ""
        TxtConsultaDoc.Text = ""
        TxtCod_P5.Enabled = True
        TxtNombre_P5.Enabled = True
        TxtCedula_P5.Enabled = True
        TxtDireccion_P5.Enabled = True
        TxtEmail_P5.Enabled = True
        TxtEmpresa_P5.Enabled = True
        TxtCargo_P5.Enabled = True
        TxtCargo_P5.Enabled = True
        TxtDespacho_P5.Enabled = True
        TxtNit_P5.Enabled = True
        TxtTElefono_P5.Enabled = True
        Btn_FinalizarPrueba.Enabled = True
        Btn_Regresar.Visible = False
        TxtCod_P1.Text = ""
        TxtNombre_P1.Text = ""
        TxtCedula_P1.Text = ""
        TxtDireccion_P1.Text = ""
        TxtEmail_P1.Text = ""
        TxtEmpresa_P1.Text = ""
        TxtCargo_P1.Text = ""
        TxtTElefono_P1.Text = Nothing
        TxtDespacho_P1.Text = ""
        TxtNit_P1.Text = ""
        TxtCod_P2.Text = ""
        TxtNombre_P2.Text = ""
        TxtCedula_P2.Text = ""
        TxtDireccion_P2.Text = ""
        TxtEmail_P2.Text = ""
        TxtEmpresa_P2.Text = ""
        TxtCargo_P2.Text = ""
        TxtTElefono_P2.Text = Nothing
        TxtDespacho_P2.Text = ""
        TxtTElefono_P2 = Nothing
        TxtNit_P2.Text = ""
        TxtCod_P3.Text = ""
        TxtNombre_P3.Text = ""
        TxtCedula_P3.Text = ""
        TxtDireccion_P3.Text = ""
        TxtEmail_P3.Text = ""
        TxtEmpresa_P3.Text = ""
        TxtCargo_P3.Text = ""
        TxtTElefono_P3.Text = Nothing
        TxtDespacho_P3.Text = ""
        TxtNit_P3.Text = ""
        TxtCod_P4.Text = ""
        TxtNombre_P4.Text = ""
        TxtCedula_P4.Text = ""
        TxtDireccion_P4.Text = ""
        TxtEmail_P4.Text = ""
        TxtEmpresa_P4.Text = ""
        TxtCargo_P4.Text = ""
        TxtTElefono_P4.Text = Nothing
        TxtDespacho_P4.Text = ""
        TxtNit_P4.Text = ""
        TxtCod_P5.Text = ""
        TxtNombre_P5.Text = ""
        TxtCedula_P5.Text = ""
        TxtDireccion_P5.Text = ""
        TxtEmail_P5.Text = ""
        TxtEmpresa_P5.Text = ""
        TxtCargo_P5.Text = ""
        TxtTElefono_P5.Text = Nothing
        TxtDespacho_P5.Text = ""
        TxtNit_P5.Text = ""
        Lbl_fkAspirante.Text = ""
    End Sub
    Private Sub BtnComenzar_Click(sender As Object, e As EventArgs) Handles BtnComenzar.Click
        Try
            If TxtConsultaDoc.Text.Trim = "" Then
                Throw New Exception("Debe llenar los campos del Aspirante para iniciar la prueba")
                countdown.Text = Nothing
            Else
                Objeto_Rh.Documento = TxtConsultaDoc.Text
                Objeto_Rh.CargarDatosAspirante()
                If Objeto_Rh.Documento.Trim = "" Then
                    Throw New Exception("Aspirante no existe en la base de datos")
                    countdown.Text = Nothing
                Else
                    Pnl_IniciarPrueba.Visible = False
                    Pnl_DatosAspirante.Visible = True
                    Pnl_Prueba1.Visible = True
                    TxtDocAspActual.Text = Objeto_Rh.Documento
                    TxtNombresAspActual.Text = Objeto_Rh.Nombre & " " & Objeto_Rh.Apellido
                    Lbl_fkAspirante.Text = Objeto_Rh.IdRegistrarAsp
                    Btn_Siguiente_P1.Visible = True
                    TxtCod_P1.Enabled = True
                    TxtNombre_P1.Enabled = True
                    TxtCedula_P1.Enabled = True
                    TxtDireccion_P1.Enabled = True
                    TxtEmail_P1.Enabled = True
                    TxtEmpresa_P1.Enabled = True
                    TxtCargo_P1.Enabled = True
                    TxtTElefono_P1.Enabled = True
                    TxtDespacho_P1.Enabled = True
                    TxtNit_P1.Enabled = True
                    BtnComenzar.Visible = False
                    BtnComenzar.Visible = False
                    Btn_Siguiente_P1.Enabled = True
                End If
            End If
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        If Not IsNothing(Objeto_Gestion_Datos.Ex) Then
            Pnl_Message.CssClass = Objeto_Gestion_Datos.Ex("Alert")
            lblmsg.Text = Objeto_Gestion_Datos.Ex("Message")
        End If
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "P", "Pleg_Loading();", True)
    End Sub
End Class
