Imports System.IO
Imports AjaxControlToolkit

Public Class cambiestilo
    Inherits System.Web.UI.Page
    Public objeto As New clsInventario
    Dim FechaActual As String
    Dim Objeto_Gestion_Datos As New Cls_Gestion_Datos
    Private Sesion_Local As New Dictionary(Of String, Object)
    Private Obj_Session As New Cls_Session
    Private Obj_G_D As New Cls_Gestion_Datos
    Dim ObjSdatos As New clscrmdatos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            Pnl_Message.CssClass = Nothing
            lblmsg.Text = Nothing
            If Not IsPostBack Then

                Session("Formulario") = "Registro Inventario Activos"
                cargardrl()
                Sesion_Local = Obj_Session.CrearValidar_SesionLocal("regcrm2", ViewState("Session"))
                'ObjDesarrollo.IdUsuario = CType(Session("permisos"), clsusuario).usuario
                'ViewState("Consulta.Registro") = ObjDesarrollo.Consulta_Desarrollos()
                'Dtg_Desarrollos.DataSource = ViewState("Consulta.Registro")
                'Dtg_Desarrollos.DataBind()
                'If ObjDesarrollo.Cantidad > 0 Then
                '    LblC.Text = "Numero de Tickets: " & ObjDesarrollo.Cantidad
                'Else
                '    LblC.Text = Nothing
                'End If
                'Cargar_Drls()
            End If
            Try
                FechaActual = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                objeto.FcReg_Invent = FechaActual
            Catch ex As Exception
                lblmsg.Text = "Se produjo error " & ex.Message
            End Try
        Catch ex As Exception
            Objeto_Gestion_Datos.Val_Ex(ex)
        End Try
    End Sub
    Protected Sub cargardrl()
        With drlresponsable
            .DataSource = objeto.consultaresponsable()
            .DataTextField = "nombreu"
            .DataValueField = "Idusuario"
            .DataBind()
        End With

        With drlsub_responsable
            .DataSource = objeto.consultarUsuario()
            .DataTextField = "nombreu"
            .DataValueField = "Idusuario"
            .DataBind()
        End With
        With drlsubResponsable
            .DataSource = objeto.consultarUsuario()
            .DataTextField = "nombreu"
            .DataValueField = "Idusuario"
            .DataBind()
        End With

        With drlresponsable
            .DataSource = objeto.consultaresponsable()
            .DataTextField = "nombreu"
            .DataValueField = "Idusuario"
            .DataBind()
        End With
        With drlresponsable0
            .DataSource = objeto.consultaresponsable()
            .DataTextField = "nombreu"
            .DataValueField = "Idusuario"
            .DataBind()
        End With
        With drlcodresponsable
            .DataSource = objeto.consultaresponsable()
            .DataTextField = "Codnom"
            .DataValueField = "Idusuario"
            .DataBind()
        End With

        With drlSedeActivo
            .DataSource = objeto.consultasdrl()
            .DataTextField = "Nombre"
            .DataValueField = "Nombre"
            .DataBind()
        End With
        objeto.Validacion = 1
        If objeto.Validacion = 1 Then
            With drlEstadoActivo
                .DataSource = objeto.consultasdrl()
                .DataTextField = "Nombre"
                .DataValueField = "Nombre"
                .DataBind()
            End With
            objeto.Validacion = 2
        End If
        If objeto.Validacion = 2 Then
            With drlZonaActivo
                .DataSource = objeto.consultasdrl()
                .DataTextField = "Nombre"
                .DataValueField = "Nombre"
                .DataBind()
            End With
            With drlZona
                .DataSource = objeto.consultasdrl()
                .DataTextField = "Nombre"
                .DataValueField = "Nombre"
                .DataBind()
            End With
            objeto.Validacion = 3
        End If
        If objeto.Validacion = 3 Then
            With drlclasificacion
                .DataSource = objeto.consultasdrl()
                .DataTextField = "pertenece"
                .DataValueField = "pertenece"
                .DataBind()
            End With
            With drlclasificacionconsulta
                .DataSource = objeto.consultasdrl()
                .DataTextField = "pertenece"
                .DataValueField = "pertenece"
                .DataBind()
            End With
            With drlclasificacion0
                .DataSource = objeto.consultasdrl()
                .DataTextField = "Pertenece"
                .DataValueField = "Pertenece"
                .DataBind()
            End With
            objeto.Validacion = 4
        End If
        If objeto.Validacion = 4 Then
            With drlMarcaActivo
                .DataSource = objeto.consultasdrl()
                .DataTextField = "Nombre"
                .DataValueField = "Nombre"
                .DataBind()
            End With
            With drlMarca
                .DataSource = objeto.consultasdrl()
                .DataTextField = "Nombre"
                .DataValueField = "Nombre"
                .DataBind()
            End With
            objeto.Validacion = 5
        End If

        If objeto.Validacion = 5 Then
            With drlReferencia
                .DataSource = objeto.consultasdrl()
                .DataTextField = "Referencia"
                .DataValueField = "Referencia"
                .DataBind()
            End With
            objeto.Validacion = 6
        End If
        If objeto.Validacion = 6 Then
            With drlPertenece
                .DataSource = objeto.consultasdrl()
                .DataTextField = "Pertenece"
                .DataValueField = "Pertenece"
                .DataBind()
            End With
            objeto.Validacion = 7
        End If
        If objeto.Validacion = 7 Then
            With drlNombreActivo0
                .DataSource = objeto.consultasdrl()
                .DataTextField = "Nombre"
                .DataValueField = "Nombre"
                .DataBind()
            End With
        End If
        With drlNombreActivo
            objeto._Pertenece = drlclasificacion.SelectedItem.Value
            .DataSource = objeto.consultaActivo
            .DataTextField = "Nombre"
            .DataValueField = "Nombre"
            .DataBind()
        End With
    End Sub

    'Registro de activo
    Protected Sub btnRegistrarActivo_Click(sender As Object, e As EventArgs) Handles btnRegistrarActivo.Click
        Try
            If drlclasificacion.SelectedItem.Value = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe seleccionar clasificacion"
                drlclasificacion.Focus()
                Exit Sub
            End If
            If drlNombreActivo.SelectedItem.Value = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe seleccionar un activo"
                drlNombreActivo.Focus()
                Exit Sub
            End If
            TxtSerialActivo.Text = Trim(Replace(TxtSerialActivo.Text, " ", " "))
            If TxtSerialActivo.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe llenar el campo serial activo"
                TxtSerialActivo.Focus()
                Exit Sub
            End If
            If drlSedeActivo.SelectedValue = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe seleccionar una sede"
                drlSedeActivo.Focus()
                Exit Sub
            End If
            If drlZonaActivo.SelectedValue = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe seleccionar una zona"
                drlZonaActivo.Focus()
                Exit Sub
            End If
            If drlMarcaActivo.SelectedValue = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe seleccionar la marca del activo"
                drlMarcaActivo.Focus()
                Exit Sub
            End If
            TxtReferenciaActivo.Text = Trim(Replace(TxtReferenciaActivo.Text, " ", " "))
            If TxtReferenciaActivo.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe llenar el campo referencia"
                TxtReferenciaActivo.Focus()
                Exit Sub
            End If
            TxtDescripcionActivo.Text = Trim(Replace(TxtDescripcionActivo.Text, " ", " "))
            If TxtDescripcionActivo.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe llenar el campo descripcion"
                TxtDescripcionActivo.Focus()
                Exit Sub
            End If
            If drlresponsable.SelectedItem.Text = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe seleccionar un responsable"
                drlresponsable.Focus()
                Exit Sub
            End If
            If drlsubResponsable.SelectedItem.Text = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe seleccionar un USUARIO"
                drlsubResponsable.Focus()
                Exit Sub
            End If
            If drlEstadoActivo.SelectedValue = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe seleccionar el estado del activo"
                drlEstadoActivo.Focus()
                Exit Sub
            End If
            If drlEstadoActivo.SelectedItem.Text <> "Baja" Then
                TxtN_Acta.Text = ""
            End If
            If drlEstadoActivo.SelectedItem.Text = "Baja" And TxtN_Acta.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe ingresar el numero de acta de baja"
                TxtN_Acta.Focus()
                Exit Sub
            End If
            TxtReferenciaActivo.Text = Trim(Replace(TxtReferenciaActivo.Text, " ", " "))
            Dim sigla As String = Mid(TxtSerialActivo.Text, 7, 2)
            objeto.Id_Usuario = CType(Session("Permisos"), clsusuario).usuario
            objeto.Nombre_Activo = drlNombreActivo.SelectedValue
            objeto.Serial = TxtSerialActivo.Text
            TxtSerialConsulta.Text = UCase(TxtSerialConsulta.Text)
            objeto._Sigla = sigla
            objeto.Estado = drlEstadoActivo.SelectedValue
            objeto.Marca = drlMarcaActivo.SelectedValue
            objeto.Sede = drlSedeActivo.SelectedValue
            objeto.Zona = drlZonaActivo.SelectedValue
            objeto.Responsable = drlresponsable.SelectedValue
            objeto.Modelo = TxtReferenciaActivo.Text
            objeto.Descripcion = TxtDescripcionActivo.Text
            objeto.subResponsable = drlsubResponsable.SelectedValue
            objeto.No_Acta = TxtN_Acta.Text
            objeto.registrarActivo()
            If objeto.valida = 1 Then
                lblmsg.Text = "Ya hay un registro con el serial " & TxtSerialActivo.Text & "  verifique"
            Else
                lblmsg.Text = " Registro Exitoso"
                drlclasificacion.SelectedIndex = 0
                drlSedeActivo.SelectedIndex = 0
                drlZonaActivo.SelectedIndex = 0
                drlMarcaActivo.SelectedIndex = 0
                drlresponsable.SelectedIndex = 0
                drlsubResponsable.SelectedIndex = 0
                drlEstadoActivo.SelectedIndex = 0
                drlNombreActivo.SelectedIndex = 0
                TxtReferenciaActivo.Text = ""
                TxtDescripcionActivo.Text = ""
                TxtSerialActivo.Text = ""
            End If
        Catch ex As Exception
            lblmsg.Text = "Error Verifique"
        End Try
        Exit Sub
    End Sub
    'Con este metodo se realiza el registros de marcas,activos,estados,sedes y zonas que no se encuentren registradas en la base de datos 
    Protected Sub btnRegistrarNuevo_Click(sender As Object, e As EventArgs) Handles btnRegistrarNuevo.Click
        Try
            TxtNombre.Text = Trim(Replace(TxtNombre.Text, " ", " "))
            If TxtNombre.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe llenar el campo Nombre"
                TxtNombre.Focus()
                Exit Sub
            End If
            If drlPertenece.SelectedValue = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe asignar pertenencia"
                drlPertenece.Focus()
                Exit Sub
            End If
            If drlPertenece.SelectedItem.Text = "Activo" Then
                If drlclasificacion0.SelectedValue = "- Seleccione -" Then
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Debe clasificar el activo"
                    drlclasificacion0.Focus()
                    Exit Sub
                End If
                objeto._Nombre = TxtNombre.Text
                objeto._Pertenece = drlclasificacion0.SelectedValue
                objeto.Registrar()

                If objeto.valida = 0 Then
                    lblmsg.Text = "Registro Exitoso"
                    objeto.Validacion = 7
                    With drlNombreActivo0
                        .DataSource = objeto.consultasdrl()
                        .DataTextField = "Nombre"
                        .DataValueField = "Nombre"
                        .DataBind()
                    End With
                    TxtNombre.Text = ""
                    drlPertenece.SelectedIndex = 0
                    drlclasificacion0.SelectedIndex = 0
                Else
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Ya existe un registro '" & TxtNombre.Text & "' en la base de datos, ingrese  datos validos"
                End If
                Exit Sub
            End If

            If drlPertenece.SelectedValue <> "Activo" Then
                objeto._Nombre = TxtNombre.Text
                objeto._Pertenece = drlPertenece.SelectedValue
                objeto.Registrar()

                If objeto.valida = 1 Then
                    lblmsg.Text = "Ya existe un registro '" & TxtNombre.Text & "' en la base de datos, ingrese  datos validos"
                Else
                    Pnl_Message.CssClass = "alert alert-warning"
                    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Registro Exitoso"

                    If drlPertenece.SelectedValue = "Marca" Then
                        objeto.Validacion = 4
                        With drlMarcaActivo
                            .DataSource = objeto.consultasdrl()
                            .DataTextField = "Nombre"
                            .DataValueField = "Nombre"
                            .DataBind()
                        End With
                    End If

                    If drlPertenece.SelectedValue = "Estado" Then
                        objeto.Validacion = 1
                        With drlEstadoActivo
                            .DataSource = objeto.consultasdrl()
                            .DataTextField = "Nombre"
                            .DataValueField = "Nombre"
                            .DataBind()
                        End With
                    End If

                    If drlPertenece.SelectedValue = "Zona" Then
                        objeto.Validacion = 2
                        With drlZona
                            .DataSource = objeto.consultasdrl
                            .DataTextField = "Nombre"
                            .DataValueField = "Nombre"
                            .DataBind()
                        End With
                    End If
                    If drlPertenece.SelectedValue = "Sede" Then
                        With drlSedeActivo
                            .DataSource = objeto.consultasdrl()
                            .DataTextField = "Nombre"
                            .DataValueField = "Nombre"
                            .DataBind()
                        End With
                        TxtNombre.Text = ""
                        drlPertenece.SelectedIndex = 0
                    End If
                End If
                TxtNombre.Text = ""
                drlPertenece.SelectedIndex = 0
                drlclasificacion0.SelectedIndex = 0
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-warning"
            lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Ya existe un registro '" & TxtNombre.Text & "' en la base de datos, ingrese  datos validos"
        End Try

    End Sub


    'realiza los diferente filtros de busqueda
    Protected Sub btnConsultarActivo_Click(sender As Object, e As EventArgs) Handles btnConsultarActivo.Click
        Try
            lblmsg.Text = ""
            If RdbSeriall.SelectedItem.Value = False And Rdbresponsable.SelectedItem.Value = False And RdbZona.SelectedItem.Value = False And RdbActivo.SelectedItem.Value = False And RdbClasificacion.SelectedItem.Value = False And Rdbmarca.SelectedItem.Value = False And Rdbcodres.SelectedItem.Value = False And RdbN_ActaC.SelectedItem.Value = False And Rdbsub_responsable.SelectedItem.Value = False Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Selecccione un criterio de busqueda"
                Exit Sub
            End If

            If RdbSeriall.SelectedItem.Value = True And TxtSerialConsulta.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Especifique el serial"
                Exit Sub
            End If

            If Rdbresponsable.SelectedItem.Value = True And drlresponsable0.SelectedItem.Text = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Especifique El Responsable"
                Exit Sub
            End If

            If RdbZona.SelectedItem.Value = True And drlZona.SelectedItem.Text = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Especifique la zona"
                Exit Sub
            End If

            If RdbActivo.SelectedItem.Value = True And drlNombreActivo0.SelectedItem.Text = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Especifique el activo"
                Exit Sub
            End If

            If RdbClasificacion.SelectedItem.Value = True And drlclasificacionconsulta.SelectedItem.Text = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Especifique una clasificacion"
                Exit Sub
            End If

            If Rdbmarca.SelectedItem.Value = True And drlMarca.SelectedItem.Text = "- Seleccione -" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Especifique una marca"
                Exit Sub
            End If

            If Rdbcodres.SelectedItem.Value = True And drlcodresponsable.SelectedItem.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Especifique un codigo"
                Exit Sub
            End If

            If Rdbsub_responsable.SelectedItem.Value = True And drlsub_responsable.SelectedItem.Text = "- Seleccione -" And drlsub_responsable.SelectedItem.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Especifique el usuario"
                Exit Sub
            End If
            If RdbN_ActaC.SelectedItem.Value = True And TxtN_ActaC.Text = "" Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Especifique N° de Acta"
                Exit Sub
            End If
            If TxtSerialConsulta.Text <> Nothing And RdbSeriall.SelectedItem.Value = True Then
                objeto.Serial = TxtSerialConsulta.Text
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If

            If drlresponsable0.SelectedItem.Value <> "- Seleccione -" And Rdbresponsable.SelectedItem.Value = True Then
                objeto.Responsable = drlresponsable0.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If

            If drlZona.SelectedItem.Value <> "- Seleccione -" And RdbZona.SelectedItem.Value = True Then
                objeto.Zona = drlZona.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If

            If drlNombreActivo0.SelectedItem.Value <> "- Seleccione -" And RdbActivo.SelectedItem.Value = True And drlReferencia.SelectedItem.Value <> "- Seleccione -" Then
                objeto.Nombre_Activo = drlNombreActivo0.SelectedItem.Value
                objeto.Modelo = drlReferencia.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If

            If drlNombreActivo0.SelectedItem.Value <> "- Seleccione -" And RdbActivo.SelectedItem.Value = True Then
                objeto.Nombre_Activo = drlNombreActivo0.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If

            If drlclasificacionconsulta.SelectedItem.Value <> "- Seleccione -" And RdbClasificacion.SelectedItem.Value = True Then
                objeto._clasificacion = drlclasificacionconsulta.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If

            If drlMarca.SelectedItem.Value <> "- Seleccione -" And Rdbmarca.SelectedItem.Value = True Then
                objeto.Marca = drlMarca.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If

            If drlcodresponsable.SelectedItem.Value <> "- Seleccione -" And Rdbcodres.SelectedItem.Value = True Then
                objeto.Responsable = drlcodresponsable.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If

            If drlsub_responsable.SelectedItem.Value <> "- Seleccione -" And drlsub_responsable.SelectedItem.Value <> "" And Rdbsub_responsable.SelectedItem.Value = True Then
                objeto.subResponsable = drlsub_responsable.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If

            If TxtN_ActaC.Text <> "" And RdbN_ActaC.SelectedItem.Value = True Then
                objeto.No_Acta = TxtN_ActaC.Text
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If

            LblCantidad.Visible = True
            LblCantidad.Text = objeto.Cantidad
            If objeto.Cantidad = 0 Then
                Pnl_Message.CssClass = "alert alert-warning"
                lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> No se encontraron registros con el criterio de busqueda especificado"
                btnExportarActivo.Visible = False
                dtgInvt.Visible = False
                LblCantidad.Visible = False
            Else
                btnExportarActivo.Visible = True
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>Se presento error: " & ex.Message
        End Try
    End Sub

    Protected Sub btnExportarActivo_Click(sender As Object, e As EventArgs) Handles btnExportarActivo.Click
        Try
            crearexcel2()
            btnExportarActivo.Visible = True
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            lblmsg.Text = "<span class='glyphicon glyphicon-remove-sign'></span>Se produjo error " & ex.Message
            lblmsg.ForeColor = Drawing.Color.Red
        End Try
    End Sub
    Protected Sub crearexcel2() 'crea el excel a exportar
        Dim sb As New StringBuilder
        Dim sw As New StringWriter(sb)
        Dim htw As New HtmlTextWriter(sw)
        Dim pagina As Page = New Page
        Dim form = New HtmlForm
        Dim r As New clsInventario
        Dim objdtsconsultaxls As New DataSet
        Dim strStyle As String = "<style>.text { mso-number-format:\@; } </style>"
        Dim Validar As Boolean

        If TxtSerialConsulta.Text <> "" And RdbSeriall.SelectedItem.Value = True Then
            objeto.Serial = TxtSerialConsulta.Text
            Validar = True
        End If
        If drlresponsable0.SelectedItem.Text <> "- Seleccione -" And Rdbresponsable.SelectedItem.Value = True Then
            objeto.Responsable = drlresponsable.SelectedItem.Value
            Validar = True
        End If
        If drlZona.SelectedItem.Text <> "- Seleccione -" And RdbZona.SelectedItem.Value = True Then
            objeto.Zona = drlZona.SelectedItem.Value
            Validar = True
        End If
        If drlNombreActivo0.SelectedItem.Text <> "- Seleccione -" And RdbActivo.SelectedItem.Value = True Then
            objeto.Nombre_Activo = drlNombreActivo0.SelectedItem.Value
            Validar = True
        End If
        If drlMarca.SelectedItem.Text <> "- Seleccione -" And Rdbmarca.SelectedItem.Value = True Then
            objeto.Marca = drlMarca.SelectedItem.Value
            Validar = True
        End If
        If drlclasificacionconsulta.SelectedItem.Text <> "- Seleccione -" And RdbClasificacion.SelectedItem.Value = True Then
            objeto._clasificacion = drlclasificacionconsulta.SelectedItem.Value
            Validar = True
        End If
        If drlcodresponsable.SelectedItem.Text <> "- Seleccione -" And Rdbcodres.SelectedItem.Value = True Then
            objeto.Responsable = drlcodresponsable.SelectedItem.Value
            Validar = True
        End If
        If Validar = True Then
            dtgxls.DataSource = objeto.consultaAcTodo()
            dtgxls.DataBind()
            dtgxls.Visible = True
            dtgxls.EnableViewState = False
            pagina.EnableEventValidation = False
            pagina.DesignerInitialize()
            pagina.Controls.Add(form)
            form.Controls.Add(dtgxls)
            pagina.RenderControl(htw)
            Response.Clear()
            Response.Buffer = True
            Response.ContentType = "application/vnd.ms-excel"
            Response.ContentEncoding = System.Text.ASCIIEncoding.UTF8
            Response.AddHeader("Content-Disposition", "attachment;filename=Inventario_Activos.xls")
            Response.Charset = "UTF-8"
            Response.Write(strStyle)
            Response.Write(sb.ToString())
            Response.End()
        Else
            Pnl_Message.CssClass = "alert alert-warning"
            lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Porfavor verifique que el tipo de consuta selecionada, no este en blanco, o tenga una opcion"
        End If
    End Sub


    Private Sub FileDocumento_UploadedComplete(sender As Object, e As AsyncFileUploadEventArgs) Handles AsF_Archivo.UploadedComplete
        Try
            Dim File As New Dictionary(Of String, Object)
            File.Add("FileBytes", AsF_Archivo.FileBytes)
            File.Add("FileName", AsF_Archivo.FileName)
            If Not Sesion_Local.ContainsKey("AsF_Archivo") Then
                Sesion_Local.Add("AsF_Archivo", File)
            Else
                Sesion_Local("AsF_Archivo") = File
            End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "a", "alert('" & ex.Message & "');", True)
        End Try
    End Sub
    Private Sub FileDocumento_UploadedFileError(sender As Object, e As AsyncFileUploadEventArgs) Handles AsF_Archivo.UploadedFileError
        ScriptManager.RegisterStartupScript(Page, GetType(Page), "a", "alert('Error al cargar el archivo en el servidor');", True)
    End Sub

    'realiza el carge del archivo excel con formato .xlsx con el cual se realiza el registro masivo de activos 
    'Protected Sub btnRegistrarActivo0_Click(sender As Object, e As EventArgs) Handles btnRegistrarActivo0.Click


    '    Try

    '    Catch ex As Exception



    '        If Sesion_Local.ContainsKey("AsF_Archivo") Then
    '            Dim Extencion As String = System.IO.Path.GetExtension(Sesion_Local("AsF_Archivo")("FileName")).ToLower
    '            If Extencion <> ".xlsx" Or Extencion <> ".xls" Then
    '                Throw New Exception("el archivo adjuntado no corresponde a una imagen")
    '            End If
    '            Dim Ruta As String = Server.MapPath("data_Doc") & "\"
    '            Dim Nombre As String = "Ri" & Extencion
    '            Obj_G_D.Guardar_Fichero(Ruta, Nombre, Sesion_Local("AsF_Archivo")("FileBytes"))
    '            ObjSdatos.archivo = Nombre
    '        Else
    '            Throw New Exception("Adjunte un archivo de excel")
    '        End If


    '    End Try

    '    'If Path.GetExtension(FileUpload1.FileName).ToLower() = "" Then

    '    '    Pnl_Message.CssClass = "alert alert-warning"
    '    '    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Seleccione un archivo del equipo"
    '    '    Exit Sub
    '    'End If
    '    'If Path.GetExtension(FileUpload1.FileName).ToLower() <> ".xlsx" Then

    '    '    Pnl_Message.CssClass = "alert alert-warning"
    '    '    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> El formato no es correcto"
    '    '    Exit Sub
    '    'End If
    '    'FileUpload1.SaveAs(Server.MapPath("~/Usuarios/" & Path.GetFileName(FileUpload1.FileName)))
    '    'Server.MapPath("~/Usuarios/" & Path.GetFileName(FileUpload1.FileName))
    '    'objeto._Ruta_Excel = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("~/Usuarios/" & Path.GetFileName(FileUpload1.FileName)) & ";Extended Properties=Excel 12.0;"
    '    'objeto.Id_Usuario = CType(Session("Permisos"), clsusuario).usuario
    '    'objeto.Validacion = 2
    '    'objeto.AExcel()
    '    'If objeto.Cantidad = 0 Then

    '    '    Pnl_Message.CssClass = "alert alert-warning"
    '    '    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> La informacion que intenta ingresar ya existe "
    '    '    Exit Sub
    '    'Else

    '    '    Pnl_Message.CssClass = "alert alert-warning"
    '    '    lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span>  Se realizaron " & objeto.Cantidad & " registros efectivos"
    '    'End If

    'End Sub
    Protected Sub dtgInvt_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgInvt.PageIndexChanging
        Try
            dtgInvt.PageIndex = e.NewPageIndex 'asigna la consulta a la grilla por paginas
            cambioindicedtgasig()
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-warning"
            lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Se presento error: " + ex.Message
        End Try
    End Sub
    Sub cambioindicedtgasig()
        Try
            If TxtSerialConsulta.Text <> " " And RdbSeriall.SelectedItem.Value = True Then
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
                If drlresponsable.Text <> " " And Rdbresponsable.SelectedItem.Value = True Then
                    objeto.Responsable = drlresponsable.SelectedItem.Value
                    dtgInvt.Visible = True
                    dtgInvt.DataSource = objeto.consultaAcTodo()
                    dtgInvt.DataBind()
                End If
            End If
            If drlZona.SelectedItem.Value <> "0" And RdbZona.SelectedItem.Value = True Then
                objeto.Zona = drlZona.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If
            If drlNombreActivo0.SelectedItem.Value <> "0" And RdbActivo.SelectedItem.Value = True Then
                objeto.Nombre_Activo = drlNombreActivo0.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If
            If drlresponsable0.SelectedItem.Value <> "- Seleccione -" And Rdbresponsable.SelectedItem.Value = True Then
                objeto.Responsable = drlresponsable0.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If

            If drlclasificacionconsulta.SelectedItem.Value <> "- Seleccione -" And RdbClasificacion.SelectedItem.Value = True Then
                objeto._clasificacion = drlclasificacionconsulta.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If
            If drlMarca.SelectedItem.Value <> "- Seleccione -" And Rdbmarca.SelectedItem.Value = True Then
                objeto.Marca = drlMarca.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If
            If drlcodresponsable.SelectedItem.Value <> "- Seleccione -" And Rdbcodres.SelectedItem.Value = True Then
                objeto.Responsable = drlcodresponsable.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If
            If drlsub_responsable.SelectedItem.Value <> "- Seleccione -" And Rdbsub_responsable.SelectedItem.Value = True Then
                objeto.subResponsable = drlsub_responsable.SelectedItem.Value
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If
            If TxtN_ActaC.Text <> "" And RdbN_ActaC.SelectedItem.Value = True Then
                objeto.No_Acta = TxtN_ActaC.Text
                dtgInvt.Visible = True
                dtgInvt.DataSource = objeto.consultaAcTodo()
                dtgInvt.DataBind()
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-warning"
            lblmsg.Text = "<span class='glyphicon glyphicon-warning-sign'></span> Se produjo error " & ex.Message
        End Try
    End Sub
    'carga la lista drlNombreActivo segun lo seleccionado en la lista de clasificacion
    Protected Sub drlclasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drlclasificacion.SelectedIndexChanged
        With drlNombreActivo
            objeto._Pertenece = drlclasificacion.SelectedItem.Value
            .DataSource = objeto.consultaActivo
            .DataTextField = "Nombre"
            .DataValueField = "Nombre"
            .DataBind()
        End With
    End Sub
    Protected Sub drlPertenece_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drlPertenece.SelectedIndexChanged
        If drlPertenece.SelectedItem.Value = "Activo" Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
        End If
    End Sub

    Protected Sub TxtSerialActivo_TextChanged(sender As Object, e As EventArgs) Handles TxtSerialActivo.TextChanged
        Me.TxtSerialActivo.Text = Trim(Replace(Me.TxtSerialActivo.Text, " ", " ")) 'evita el ingreso de espacios y espacios duros
        TxtSerialActivo.Text = UCase(TxtSerialActivo.Text) 'las letras que se encuentren en el serial siempre iran en mayuscula
    End Sub

    Protected Sub drlEstadoActivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drlEstadoActivo.SelectedIndexChanged
        If drlEstadoActivo.SelectedItem.Value = "Baja" Then
            Panel3.Visible = True
        Else
            Panel3.Visible = False
        End If
    End Sub
End Class