Public Class ClsRRHHGestion
#Region "Declaración y Encapsulamiento Variables"

    Protected _documento As String
    Protected _nombre As String
    Protected _apellido As String
    Protected _email As String
    Protected _celular As String
    Protected _idRegistrarAsp As Integer
    Protected _codigo1 As String
    Protected _nombre1 As String
    Protected _cedula1 As String
    Protected _direccion1 As String
    Protected _email1 As String
    Protected _empresa1 As String
    Protected _cargo1 As String
    Protected _telefono1 As String
    Protected _despacho1 As String
    Protected _nit1 As String
    Protected _idDatosDigitar As Integer
    Protected _numeroRegistro As Integer
    Protected _codigo As String
    Protected _empresa As String
    Protected _cargo As String
    Protected _cedula As String
    Protected _telefono As String
    Protected _direccion As String
    Protected _despacho As String
    Protected _nit As String
    Protected _idPrueba As Integer
    Protected _fk_IdRegistrarAsp As Integer
    Protected _fk_DatosDigitar As Integer
    Protected _puntaje As Integer
    Protected _intentos As Integer
    Protected _idTicket As Integer
    Protected _codigoTicket As String
    Protected _tema As String

    Protected _idArea As Integer
    Protected _cantidad As Integer
    Protected _fk_Area As Integer
    Protected _area As String
    Protected _rh_Sector As Integer
    Protected _fk_Sector As Integer
    Protected _idSector As Integer
    Protected _sector As String
    Protected _idLocalizacion As Integer
    Protected _fk_Localizacion As Integer
    Protected _localizacion As String
    Protected _idElemento As Integer
    Protected _elemento As String
    Protected _fk_Elemento As Integer
    Protected _idPrioridad As Integer
    Protected _fk_Prioridad As Integer
    Protected _prioridad As String
    Protected _fk_CodigoUsuario As Integer
    Protected _nombreUsuario As String
    Protected _requerimientos As String
    Protected _fechaIngreso As Date
    Protected _idSatisfaccion As Integer
    Protected _fk_Satisfaccion As Integer
    Protected _fk_Calificacion As Integer
    Protected _satisfaccion As String
    Protected _fechaInicioGestion As Date
    Protected _fechaCierreGestion As Date
    Protected _fk_Estado As Integer
    Protected _observacionEstado As String
    Protected _Estado As String
    Protected _usuarioAsignado As String
    Public Property Intentos As Integer
        Get
            Return _intentos
        End Get
        Set(value As Integer)
            _intentos = value
        End Set
    End Property
    Public Property Puntaje As Integer
        Get
            Return _puntaje
        End Get
        Set(value As Integer)
            _puntaje = value
        End Set
    End Property
    Public Property Fk_DatosDigitar As Integer
        Get
            Return _fk_DatosDigitar
        End Get
        Set(value As Integer)
            _fk_DatosDigitar = value
        End Set
    End Property
    Public Property Fk_IdRegistrarAsp As Integer
        Get
            Return _fk_IdRegistrarAsp
        End Get
        Set(value As Integer)
            _fk_IdRegistrarAsp = value
        End Set
    End Property
    Public Property IdPrueba As Integer
        Get
            Return _idPrueba
        End Get
        Set(value As Integer)
            _idPrueba = value
        End Set
    End Property
    Public Property Codigo1 As String
        Get
            Return _codigo1
        End Get
        Set(value As String)
            _codigo1 = value
        End Set
    End Property
    Public Property Nombre1 As String
        Get
            Return _nombre1
        End Get
        Set(value As String)
            _nombre1 = value
        End Set
    End Property
    Public Property Cedula1 As String
        Get
            Return _cedula1
        End Get
        Set(value As String)
            _cedula1 = value
        End Set
    End Property
    Public Property Direccion1 As String
        Get
            Return _direccion1
        End Get
        Set(value As String)
            _direccion1 = value
        End Set
    End Property
    Public Property Email1 As String
        Get
            Return _email1
        End Get
        Set(value As String)
            _email1 = value
        End Set
    End Property
    Public Property Empresa1 As String
        Get
            Return _empresa1
        End Get
        Set(value As String)
            _empresa1 = value
        End Set
    End Property
    Public Property Telefono1 As String
        Get
            Return _telefono1
        End Get
        Set(value As String)
            _telefono1 = value
        End Set
    End Property
    Public Property Cargo1 As String
        Get
            Return _cargo1
        End Get
        Set(value As String)
            _cargo1 = value
        End Set
    End Property
    Public Property Despacho1 As String
        Get
            Return _despacho1
        End Get
        Set(value As String)
            _despacho1 = value
        End Set
    End Property
    Public Property Nit1 As String
        Get
            Return _nit1
        End Get
        Set(value As String)
            _nit1 = value
        End Set
    End Property
    Public Property Nit As String
        Get
            Return _nit
        End Get
        Set(value As String)
            _nit = value
        End Set
    End Property
    Public Property Despacho As String
        Get
            Return _despacho
        End Get
        Set(value As String)
            _despacho = value
        End Set
    End Property
    Public Property Direccion As String
        Get
            Return _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property
    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property
    Public Property Cedula As String
        Get
            Return _cedula
        End Get
        Set(value As String)
            _cedula = value
        End Set
    End Property
    Public Property Cargo As String
        Get
            Return _cargo
        End Get
        Set(value As String)
            _cargo = value
        End Set
    End Property
    Public Property Empresa As String
        Get
            Return _empresa
        End Get
        Set(value As String)
            _empresa = value
        End Set
    End Property
    Public Property Codigo As String
        Get
            Return _codigo
        End Get
        Set(value As String)
            _codigo = value
        End Set
    End Property
    Public Property NumeroRegistro As Integer
        Get
            Return _numeroRegistro
        End Get
        Set(value As Integer)
            _numeroRegistro = value
        End Set
    End Property
    Public Property IdDatosDigitar As Integer
        Get
            Return _idDatosDigitar
        End Get
        Set(value As Integer)
            _idDatosDigitar = value
        End Set
    End Property
    Public Property Documento As String
        Get
            Return _documento
        End Get
        Set(value As String)
            _documento = value
        End Set
    End Property
    Public Property Celular As String
        Get
            Return _celular
        End Get
        Set(value As String)
            _celular = value
        End Set
    End Property
    Public Property Apellido As String
        Get
            Return _apellido
        End Get
        Set(value As String)
            _apellido = value
        End Set
    End Property
    Public Property IdRegistrarAsp As Integer
        Get
            Return _idRegistrarAsp
        End Get
        Set(value As Integer)
            _idRegistrarAsp = value
        End Set
    End Property
    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property UsuarioAsignado As String
        Get
            Return _usuarioAsignado
        End Get
        Set(value As String)
            _usuarioAsignado = value
        End Set
    End Property
    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property
    Public Property ObservacionEstado As String
        Get
            Return _observacionEstado
        End Get
        Set(value As String)
            _observacionEstado = value
        End Set
    End Property
    Public Property Fk_Calificacion As Integer
        Get
            Return _fk_Calificacion
        End Get
        Set(value As Integer)
            _fk_Calificacion = value
        End Set
    End Property
    Public Property Cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(value As Integer)
            _cantidad = value
        End Set
    End Property


    Public Property Fk_Estado As Integer
        Get
            Return _fk_Estado
        End Get
        Set(value As Integer)
            _fk_Estado = value
        End Set
    End Property
    Public Property IdTicket As Integer
        Get
            Return _idTicket
        End Get
        Set(value As Integer)
            _idTicket = value
        End Set
    End Property
    Public Property CodigoTicket As String
        Get
            Return _codigoTicket
        End Get
        Set(value As String)
            _codigoTicket = value
        End Set
    End Property
    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
    Public Property IdArea As Integer
        Get
            Return _idArea
        End Get
        Set(value As Integer)
            _idArea = value
        End Set
    End Property
    Public Property Fk_Area As Integer
        Get
            Return _fk_Area
        End Get
        Set(value As Integer)
            _fk_Area = value
        End Set
    End Property
    Public Property Area As String
        Get
            Return _area
        End Get
        Set(value As String)
            _area = value
        End Set
    End Property
    Public Property Rh_Sector As Integer
        Get
            Return _rh_Sector
        End Get
        Set(value As Integer)
            _rh_Sector = value
        End Set
    End Property
    Public Property Fk_Sector As Integer
        Get
            Return _fk_Sector
        End Get
        Set(value As Integer)
            _fk_Sector = value
        End Set
    End Property
    Public Property Sector As String
        Get
            Return _sector
        End Get
        Set(value As String)
            _sector = value
        End Set
    End Property
    Public Property IdLocalizacion As Integer
        Get
            Return _idLocalizacion
        End Get
        Set(value As Integer)
            _idLocalizacion = value
        End Set
    End Property
    Public Property Fk_Localizacion As Integer
        Get
            Return _fk_Localizacion
        End Get
        Set(value As Integer)
            _fk_Localizacion = value
        End Set
    End Property
    Public Property Localizacion As String
        Get
            Return _localizacion
        End Get
        Set(value As String)
            _localizacion = value
        End Set
    End Property
    Public Property IdElemento As Integer
        Get
            Return _idElemento
        End Get
        Set(value As Integer)
            _idElemento = value
        End Set
    End Property
    Public Property Elemento As String
        Get
            Return _elemento
        End Get
        Set(value As String)
            _elemento = value
        End Set
    End Property
    Public Property Fk_Elemento As Integer
        Get
            Return _fk_Elemento
        End Get
        Set(value As Integer)
            _fk_Elemento = value
        End Set
    End Property
    Public Property IdPrioridad As Integer
        Get
            Return _idPrioridad
        End Get
        Set(value As Integer)
            _idPrioridad = value
        End Set
    End Property
    Public Property Fk_Prioridad As Integer
        Get
            Return _fk_Prioridad
        End Get
        Set(value As Integer)
            _fk_Prioridad = value
        End Set
    End Property
    Public Property Prioridad As String
        Get
            Return _prioridad
        End Get
        Set(value As String)
            _prioridad = value
        End Set
    End Property
    Public Property Fk_CodigoUsuario As Integer
        Get
            Return _fk_CodigoUsuario
        End Get
        Set(value As Integer)
            _fk_CodigoUsuario = value
        End Set
    End Property
    Public Property NombreUsuario As String
        Get
            Return _nombreUsuario
        End Get
        Set(value As String)
            _nombreUsuario = value
        End Set
    End Property
    Public Property Requerimientos As String
        Get
            Return _requerimientos
        End Get
        Set(value As String)
            _requerimientos = value
        End Set
    End Property
    Public Property FechaIngreso As Date
        Get
            Return _fechaIngreso
        End Get
        Set(value As Date)
            _fechaIngreso = value
        End Set
    End Property
    Public Property IdSatisfaccion As Integer
        Get
            Return _idSatisfaccion
        End Get
        Set(value As Integer)
            _idSatisfaccion = value
        End Set
    End Property
    Public Property Fk_Satisfaccion As Integer
        Get
            Return _fk_Satisfaccion
        End Get
        Set(value As Integer)
            _fk_Satisfaccion = value
        End Set
    End Property
    Public Property Satisfaccion As String
        Get
            Return _satisfaccion
        End Get
        Set(value As String)
            _satisfaccion = value
        End Set
    End Property
    Public Property FechaInicioGestion As Date
        Get
            Return _fechaInicioGestion
        End Get
        Set(value As Date)
            _fechaInicioGestion = value
        End Set
    End Property
    Public Property FechaCierreGestion As Date
        Get
            Return _fechaCierreGestion
        End Get
        Set(value As Date)
            _fechaCierreGestion = value
        End Set
    End Property
    Public Property Tema As String
        Get
            Return _tema
        End Get
        Set(value As String)
            _tema = value
        End Set
    End Property
    Public Property IdSector As Integer
        Get
            Return _idSector
        End Get
        Set(value As Integer)
            _idSector = value
        End Set
    End Property
#End Region
    Public Sub RegTicketRh()
        Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conexion2").ConnectionString) ' Conexion con la base 
        Try
            Dim cms As New SqlClient.SqlCommand("insert into RRHH_RegistroTicket (Tema,UsuarioSolicita,Fk_Area,Fk_Sector,Fk_Localizacion,Fk_Elemento,Fk_Estado,Fk_Prioridad,Fk_Satisfaccion,Fk_Calificacion,UsuarioAsignado,Requerimientos,FechaInicio) values (@Tema,@UsuarioSolicita,@Fk_Area,@Fk_Sector,@Fk_Localizacion,@Fk_Elemento,@Fk_Estado,@Fk_Prioridad,@Fk_Satisfaccion,@Fk_Calificacion,@UsuarioAsignado,@Requerimientos,@FechaInicio) ", cn)
            cn.Open()
            cms.Parameters.AddWithValue("@Tema", Tema)
            cms.Parameters.AddWithValue("@UsuarioSolicita", NombreUsuario)
            cms.Parameters.AddWithValue("@Fk_Area", Fk_Area)
            cms.Parameters.AddWithValue("@Fk_Sector", Fk_Sector)
            cms.Parameters.AddWithValue("@Fk_Localizacion", Fk_Localizacion)
            cms.Parameters.AddWithValue("@Fk_Elemento", Fk_Elemento)
            cms.Parameters.AddWithValue("@Fk_Estado", 1)
            cms.Parameters.AddWithValue("@Fk_Prioridad", Fk_Prioridad)
            cms.Parameters.AddWithValue("@Fk_Satisfaccion", 1)
            cms.Parameters.AddWithValue("@Fk_Calificacion", 1)
            cms.Parameters.AddWithValue("@UsuarioAsignado", "Pendiente")
            cms.Parameters.AddWithValue("@Requerimientos", Requerimientos)
            cms.Parameters.AddWithValue("@FechaInicio", Now)
            cms.Connection = cn
            cms.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub
    Public Function CargarDatosDrl_Area()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand("select * from RRHHArea", cx)
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function

    Public Function CargarIdticket()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand("select IdTicket from RRHH_RegistroTicket where CodigoTicket = @CodigoTicket", cx)
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)

            If datos.Tables(0).Rows(0).Item("IdTicket") Is System.DBNull.Value Then
                IdTicket = " "
            Else
                IdTicket = datos.Tables(0).Rows(0).Item("IdTicket")
            End If
            Return IdTicket
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function

    Public Function CargarDatosReadOnlyGestionUsuarioGestiona()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexioncontroldatos").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand(
                "select U.nombreu as UsuarioSolicita
                From RRHH_RegistroTicket RT 
                join RRHHArea RArea on Rt.Fk_Area = RArea.IdArea 
                join datosclaro.dbo.usuarios U on U.idusuario = UsuarioSolicita
                where Fk_Estado  != 4 and  CodigoTicket = @CodigoTicket", cx)
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            If datos.Tables(0).Rows(0).Item("UsuarioSolicita") Is System.DBNull.Value Then
                NombreUsuario = " "
            Else
                NombreUsuario = datos.Tables(0).Rows(0).Item("UsuarioSolicita")
            End If
            Return NombreUsuario
            cmd.ExecuteReader()
            Return datos

        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function

    Public Function CargarDatosReadOnlyGestionUsuarioAsignado()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand(
                "select UsuarioAsignado From RRHH_RegistroTicket RT
					join   RRHHArea RArea
				 on Rt.Fk_Area = RArea.IdArea and  CodigoTicket = @CodigoTicket", cx)
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            If datos.Tables(0).Rows(0).Item("UsuarioAsignado") Is System.DBNull.Value Then
                UsuarioAsignado = " "
            Else
                UsuarioAsignado = datos.Tables(0).Rows(0).Item("UsuarioAsignado")
            End If
            Return UsuarioAsignado
            cmd.ExecuteReader()
            Return datos

        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function

    Public Function CargarDatosReadOnlyGestionEstado()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand(
                "select Estado From RRHH_RegistroTicket RT
					join  RRHHEstado Estado
				 on Rt.Fk_Estado = IdEstado and  CodigoTicket = @CodigoTicket", cx)
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            If datos.Tables(0).Rows(0).Item("Estado") Is System.DBNull.Value Then
                Estado = " "
            Else
                Estado = datos.Tables(0).Rows(0).Item("Estado")
            End If
            Return Estado
            cmd.ExecuteReader()
            Return datos

        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function
    Public Function CargarDatosReadOnlyGestionFechaInicioGes()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand(
                "select FechaInicio
					    From RRHH_RegistroTicket RT
				    	join   RRHHArea RArea
					    on Rt.Fk_Area = RArea.IdArea
				 where Fk_Estado  != 4 and  CodigoTicket =  @CodigoTicket", cx)
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            If datos.Tables(0).Rows(0).Item("FechaInicio") Is System.DBNull.Value Then
                FechaIngreso = " "
            Else
                FechaIngreso = datos.Tables(0).Rows(0).Item("FechaInicio")
            End If
            Return FechaIngreso
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function

    Public Function CargarDatosReadOnlyGestionAreaGes()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand(
                "select Area
				     From RRHH_RegistroTicket RT
					 join  RRHHArea RArea
					 on Rt.Fk_Area = RArea.IdArea
				 where Fk_Estado  != 4 and  CodigoTicket = @CodigoTicket", cx)
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            If datos.Tables(0).Rows(0).Item("Area") Is System.DBNull.Value Then
                Area = " "
            Else
                Area = datos.Tables(0).Rows(0).Item("Area")
            End If
            Return Area
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function

    Public Function CargarDatosReadOnlyRequerimientosGes()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand(
                "select Requerimientos
				    From RRHH_RegistroTicket RT
					join   RRHHArea RArea
					on Rt.Fk_Area = RArea.IdArea
				 where Fk_Estado  != 4 and  CodigoTicket = @CodigoTicket", cx)
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            If datos.Tables(0).Rows(0).Item("Requerimientos") Is System.DBNull.Value Then
                Requerimientos = " "
            Else
                Requerimientos = datos.Tables(0).Rows(0).Item("Requerimientos")
            End If
            Return Requerimientos
            cmd.ExecuteReader()
            Return datos

        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function

    Public Function CargarDatosReadOnlyPrioridadGes()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand(
                "select Prioridad
					From RRHH_RegistroTicket RT
				   	join   RRHHArea RArea
					on Rt.Fk_Area = RArea.IdArea						 
					join RRHH_Prioridad Prio 
					on Rt.Fk_Prioridad = Prio.IdPrioridad
				  where Fk_Estado  != 4 and  CodigoTicket =  @CodigoTicket", cx)
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            If datos.Tables(0).Rows(0).Item("Prioridad") Is System.DBNull.Value Then
                Prioridad = " "
            Else
                Prioridad = datos.Tables(0).Rows(0).Item("Prioridad")
            End If
            Return Prioridad
            cmd.ExecuteReader()
            Return datos

        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function


    Public Function CargarDatosReadOnlyLocalizacionGes()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand(
                "select Localizacion
					 From RRHH_RegistroTicket RT
					 join RRHHLocalizacion Localiza
					 on Rt.Fk_Localizacion = Localiza.IdLocalizacion
				  where Fk_Estado  != 4 and  CodigoTicket = @CodigoTicket", cx)
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            If datos.Tables(0).Rows(0).Item("Localizacion") Is System.DBNull.Value Then
                Localizacion = " "
            Else
                Localizacion = datos.Tables(0).Rows(0).Item("Localizacion")
            End If
            Return Localizacion
            cmd.ExecuteReader()
            Return datos

        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function

    Public Function CargarDatosReadOnlyElemetoGes()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand(
                "select Elemento
				 From RRHH_RegistroTicket RT
				 join RRHHElemento Eleme
				 on Rt.Fk_Elemento = Eleme.IdElemento
				  where Fk_Estado  != 4 and  CodigoTicket =  @CodigoTicket", cx)
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            If datos.Tables(0).Rows(0).Item("Elemento") Is System.DBNull.Value Then
                Elemento = " "
            Else
                Elemento = datos.Tables(0).Rows(0).Item("Elemento")
            End If
            Return Elemento
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function
    Public Function CargarDatosReadOnlySectorGes()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand("select Sector From RRHH_RegistroTicket RT join RRHHSector Secto on Rt.Fk_Sector = Secto.Rh_Sector where Fk_Estado != 4  and  CodigoTicket = @CodigoTicket", cx)
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            If datos.Tables(0).Rows(0).Item("Sector") Is System.DBNull.Value Then
                Sector = " "
            Else
                Sector = datos.Tables(0).Rows(0).Item("Sector")
            End If
            Return Sector
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function

    Public Function CargarDatosReadOnlyTemaGes()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand(
                " select Tema
				     From RRHH_RegistroTicket RT
				      join RRHHElemento Eleme
				      on Rt.Fk_Localizacion = Eleme.IdElemento
				  where Fk_Estado  != 4 and  CodigoTicket = @CodigoTicket", cx)
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            If datos.Tables(0).Rows(0).Item("Tema") Is System.DBNull.Value Then
                Tema = " "
            Else
                Tema = datos.Tables(0).Rows(0).Item("Tema")
            End If
            Return Tema
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function
    Public Function CargarDatosReadOnlyUsuarioAsignadoGes()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand(" select UsuarioAsignado
						 From RRHH_RegistroTicket RT
						join   RRHHArea RArea
						 on Rt.Fk_Area = RArea.IdArea				
						 where Fk_Estado  != 4 and  CodigoTicket =  @CodigoTicket", cx)
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            If datos.Tables(0).Rows(0).Item("UsuarioAsignado") Is System.DBNull.Value Then
                UsuarioAsignado = " "
            Else
                UsuarioAsignado = datos.Tables(0).Rows(0).Item("UsuarioAsignado")
            End If
            Return UsuarioAsignado
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function



    Public Function CargarUltimoticketCreado()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand("  SELECT TOP 1  CodigoTicket FROM RRHH_RegistroTicket ORDER BY CodigoTicket DESC", cx)

            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)

            If datos.Tables(0).Rows(0).Item("CodigoTicket") Is System.DBNull.Value Then
                CodigoTicket = " "
            Else
                CodigoTicket = datos.Tables(0).Rows(0).Item("CodigoTicket")
            End If
            Return CodigoTicket
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function


    Public Function CargarDatosDrl_Prioridad()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand("select * from RRHH_Prioridad", cx)
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function
    Public Function CargarDatosDrl_Estado()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand("select * from  RRHHEstado where IdEstado != 4 and IdEstado != 1 ", cx)
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function

    Public Function CargarDatosDrl_EstadoTodosEstados()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand("select * from  RRHHEstado", cx)
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function

    Public Function CargarDatosDrl_Calificacion()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand("select * from RRHHCalificacion where IdCalificacion !=1", cx)
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function
    Public Function CargarDatosDrl_Satisfaccion()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand("select * from RRHHSatisfaccion where IdSatisfaccion !=1", cx)
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function

#Region "Aqui se carga el usuario de mantenimiento"
    Public Function CargarDatosDrl_Usuarios()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexioncontroldatos").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand("SELECT DC.Nombre As Idusuario , U.nombreu  as Nombre from BD_Admin_Complemento DC INNER JOIN datosclaro.dbo.usuarios U ON U.idusuario = DC.Nombre WHERE Pertenece = 'Usuario_Mantenimiento'", cx)
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function
#End Region

    Public Sub RegGestionEscalar()
        Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conexion2").ConnectionString) ' Conexion con la base 
        Try

            Dim cms As New SqlClient.SqlCommand("update RRHHGestionTicket set ObservacionEstado = @ObservacionEstado where IdGestion = @IdGestion", cn)
            cn.Open()
            cms.Parameters.AddWithValue("@IdGestion", 3)
            cms.Parameters.AddWithValue("@ObservacionEstado", ObservacionEstado)
            cms.Connection = cn
            cms.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Sub RegCalificacion()
        Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conexion2").ConnectionString) ' Conexion con la base 
        Try
            Dim cms As New SqlClient.SqlCommand("update RRHH_RegistroTicket set Fk_Estado = @Fk_Estado,Fk_Satisfaccion = @Fk_Satisfaccion, Fk_Calificacion = @Fk_Calificacion, FechaFin = @FechaFin where CodigoTicket = @CodigoTicket", cn)
            cn.Open()
            cms.Parameters.AddWithValue("@CodigoTicket", CodigoTicket)
            cms.Parameters.AddWithValue("@Fk_Calificacion", Fk_Calificacion)
            cms.Parameters.AddWithValue("@Fk_Satisfaccion", Fk_Satisfaccion)
            cms.Parameters.AddWithValue("@Fk_Estado", 4)
            cms.Parameters.AddWithValue("@FechaFin", Now)
            cms.Connection = cn
            cms.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub
    Public Sub RegGestionHistorial()
        Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conexion2").ConnectionString) ' Conexion con la base 
        Try
            cn.Open()
            Dim cms As New SqlClient.SqlCommand("insert into RRHHGestionTicket values (@Fk_IdTicket,@ObservacionEstado,@FechaGestion,@UsuarioRegistra,@UsuarioAsignado,@Fk_idEstado) ", cn)
            cms.Parameters.AddWithValue("@Fk_IdTicket", IdTicket)
            cms.Parameters.AddWithValue("@ObservacionEstado", ObservacionEstado)
            cms.Parameters.AddWithValue("@FechaGestion", FechaInicioGestion)
            cms.Parameters.AddWithValue("@UsuarioRegistra", NombreUsuario)
            cms.Parameters.AddWithValue("@UsuarioAsignado", UsuarioAsignado)
            cms.Parameters.AddWithValue("@Fk_idEstado", Fk_Estado)
            cms.Connection = cn
            cms.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub
    Public Sub RegGestionHistorialCierre()
        Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conexion2").ConnectionString) ' Conexion con la base 
        Try
            cn.Open()
            Dim cms As New SqlClient.SqlCommand("insert into RRHHGestionTicket values (@Fk_IdTicket,@ObservacionEstado,@FechaGestion,@UsuarioRegistra,@UsuarioAsignado,@Fk_idEstado) ", cn)
            cms.Parameters.AddWithValue("@Fk_IdTicket", IdTicket)
            cms.Parameters.AddWithValue("@ObservacionEstado", ObservacionEstado)
            cms.Parameters.AddWithValue("@FechaGestion", FechaInicioGestion)
            cms.Parameters.AddWithValue("@UsuarioRegistra", NombreUsuario)
            cms.Parameters.AddWithValue("@UsuarioAsignado", UsuarioAsignado)
            cms.Parameters.AddWithValue("@Fk_idEstado", 4)

            cms.Connection = cn
            cms.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Public Sub RegGestion()
        Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conexion2").ConnectionString) ' Conexion con la base 
        Try
            Dim cms As New SqlClient.SqlCommand("update RRHH_RegistroTicket set Fk_Estado = @Fk_Estado,UsuarioAsignado = @UsuarioAsignado where IdTicket = @IdTicket", cn)
            cn.Open()
            cms.Parameters.AddWithValue("@IdTicket", IdTicket)
            cms.Parameters.AddWithValue("@Fk_Estado", Fk_Estado)
            cms.Parameters.AddWithValue("@UsuarioAsignado", UsuarioAsignado)
            cms.Connection = cn
            cms.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub
    Public Function CargarDatosDrl_AreaGestion()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand("select * from RRHHLocalizacion", cx)
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function
    Public Function CargarDatosDrl_Sector()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand("select * from RRHHSector", cx)
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function
    Public Function CargarDatosDrl_ElementoGestion()
        Dim cx As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cx.Open()
            Dim cmd As New SqlClient.SqlCommand("select * from RRHHElemento order by Elemento asc", cx)
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            cmd.ExecuteReader()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cx.State = ConnectionState.Open Then
                cx.Close()
            End If
        End Try
    End Function

    Public Function CargarGestionReadOnly()
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeDatos As SqlClient.SqlDataAdapter
        Try
            Dim cmd As New SqlClient.SqlCommand
            cmd.CommandText = " 
            select UsuarioSolicita from RRHH_RegistroTicket Registro
            join RRHHArea Area on Registro.IdTicket = Area.IdArea
            join RRHHSector Sector on Registro.IdTicket = Sector.Rh_Sector            
            join RRHHLocalizacion Localizacion on Registro.IdTicket = Localizacion.IdLocalizacion            
            join RRHHElemento Elemento on Registro.IdTicket = Elemento.IdElemento            
            join RRHHEstado Estado on Registro.Fk_Estado = Estado.IdEstado            
            join RRHH_Prioridad Prioridad on Registro.IdTicket = Prioridad.IdPrioridad             
            where CodigoTicket =  @CodigoTicket"
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeDatos = New SqlClient.SqlDataAdapter(cmd)
            cmd.Connection = cn
            RecibeDatos.Fill(datos)
            Return datos
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CargarFiltroCodigoTicketRh() As DataTable
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeDatos As SqlClient.SqlDataAdapter
        Try
            Dim cmd As New SqlClient.SqlCommand
            cmd.CommandText = " 
  select CodigoTicket,Tema,UsuarioSolicita ,Area,Sector,Localizacion,Elemento,Estado,Prioridad,UsuarioAsignado,Requerimientos,FechaInicio
						 From RRHH_RegistroTicket RT
						join   RRHHArea RArea
						 on Rt.Fk_Area = RArea.IdArea
						 join RRHHSector Secto
						 on Rt.Fk_Sector = Secto.Rh_Sector
						 join RRHHLocalizacion Localiza
						 on Rt.Fk_Sector = Localiza.IdLocalizacion
						 join RRHHElemento Eleme
						 on Rt.Fk_Localizacion = Eleme.IdElemento
						 join RRHH_Prioridad Prio 
						 on Rt.Fk_Prioridad = Prio.IdPrioridad
						 join RRHHSatisfaccion Satis
						 on Rt.Fk_Satisfaccion = Satis.IdSatisfaccion
						 join RRHHCalificacion Cali
						 on Rt.Fk_Calificacion = Cali.IdCalificacion
						 join RRHHEstado Estado
						 on RT.Fk_Estado = Estado.IdEstado
						 where Fk_Estado != 4 and CodigoTicket = @CodigoTicket"
            cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
            RecibeDatos = New SqlClient.SqlDataAdapter(cmd)
            cmd.Connection = cn
            RecibeDatos.Fill(datos)
            Return datos.Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarFiltroGrillaGestion() As DataTable
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet

        Dim RecibeDatos As SqlClient.SqlDataAdapter
        Try
            Dim cmd As New SqlClient.SqlCommand
            cmd.CommandText =
                " select CodigoTicket,FechaInicio as [Fecha Registro],UsuarioSolicita as [Usuario Solicita] ,Area,Tema,Sector,Localizacion as Localización,Elemento,Estado,Prioridad,UsuarioAsignado as [Usuario Asignado] ,Requerimientos
						 From RRHH_RegistroTicket RT
						join   RRHHArea RArea
						 on Rt.Fk_Area = RArea.IdArea
						 join RRHHSector Secto
						 on Rt.Fk_Sector = Secto.Rh_Sector
						 join RRHHLocalizacion Localiza
						 on Rt.Fk_Sector = Localiza.IdLocalizacion
						 join RRHHElemento Eleme
						 on Rt.Fk_Localizacion = Eleme.IdElemento
						 join RRHH_Prioridad Prio 
						 on Rt.Fk_Prioridad = Prio.IdPrioridad
						 join RRHHSatisfaccion Satis
						 on Rt.Fk_Satisfaccion = Satis.IdSatisfaccion
						 join RRHHCalificacion Cali
						 on Rt.Fk_Calificacion = Cali.IdCalificacion
						 join RRHHEstado Estado
						 on RT.Fk_Estado = Estado.IdEstado
					where Fk_Estado != 4 order by CodigoTicket desc"
            cmd.Connection = cn
            RecibeDatos = New SqlClient.SqlDataAdapter(cmd)
            RecibeDatos.Fill(datos)
            Cantidad = datos.Tables(0).Rows.Count
            Return datos.Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CargarFiltroGestion()
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim WHERE As String = ""
        Dim RecibeDatos As SqlClient.SqlDataAdapter
        Try
            Dim cmd As New SqlClient.SqlCommand
            If CodigoTicket <> Nothing Then
                WHERE = WHERE & " and  CodigoTicket = @CodigoTicket "
                cmd.Parameters.AddWithValue("@CodigoTicket", CodigoTicket)

            End If
            If Fk_Prioridad <> Nothing Then
                WHERE = WHERE & " and Fk_Prioridad = @Fk_Prioridad"
                cmd.Parameters.AddWithValue("@FK_Prioridad", Fk_Prioridad)
            End If
            If FechaIngreso <> Nothing Then
                WHERE = WHERE & " and  convert(date,FechaInicio)  BETWEEN  @FechaInicio  AND @FechaFin  "
                cmd.Parameters.AddWithValue("@FechaInicio", FechaIngreso)
                cmd.Parameters.AddWithValue("@FechaFin", FechaCierreGestion)
            End If
            'If FechaCierreGestion <> Nothing Then
            '    WHERE = WHERE & " and  convert(date,FechaInicio) = @FechaInicios"
            '    cmd.Parameters.AddWithValue("@FechaInicios", FechaCierreGestion)
            'End If

            cmd.CommandText =
                "select CodigoTicket,Tema,UsuarioSolicita ,Area,Sector,Localizacion,Elemento,Estado,Prioridad,UsuarioAsignado as [Usuario Asignado] ,Requerimientos,FechaInicio
						 From RRHH_RegistroTicket RT
						join   RRHHArea RArea
						 on Rt.Fk_Area = RArea.IdArea
						 join RRHHSector Secto
						 on Rt.Fk_Sector = Secto.Rh_Sector
						 join RRHHLocalizacion Localiza
						 on Rt.Fk_Sector = Localiza.IdLocalizacion
						 join RRHHElemento Eleme
						 on Rt.Fk_Localizacion = Eleme.IdElemento
						 join RRHH_Prioridad Prio 
						 on Rt.Fk_Prioridad = Prio.IdPrioridad
						 join RRHHSatisfaccion Satis
						 on Rt.Fk_Satisfaccion = Satis.IdSatisfaccion
						 join RRHHCalificacion Cali
						 on Rt.Fk_Calificacion = Cali.IdCalificacion
						 join RRHHEstado Estado
						 on RT.Fk_Estado = Estado.IdEstado					
				  where Fk_Estado != 4 " & WHERE & ""

            RecibeDatos = New SqlClient.SqlDataAdapter(cmd)
            cmd.Connection = cn
            RecibeDatos.Fill(datos)
            Return datos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarConsultaTickets() As DataTable
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeDatos As SqlClient.SqlDataAdapter
        Dim cmd As New SqlClient.SqlCommand
        Dim WHERE As String = ""
        Try
            cn.Open()
            If CodigoTicket <> Nothing Then
                cmd.Parameters.Add("@CodigoTicket", SqlDbType.VarChar).Value = CodigoTicket
                WHERE = WHERE & "and  CodigoTicket = @CodigoTicket "
            Else
                If Fk_Prioridad <> Nothing Then
                    cmd.Parameters.Add("@Fk_Prioridad", SqlDbType.BigInt).Value = Fk_Prioridad
                    WHERE = WHERE & "and  Fk_Prioridad = @Fk_Prioridad "
                End If

                If Fk_Satisfaccion <> Nothing Then
                    cmd.Parameters.Add("@Fk_Satisfaccion", SqlDbType.BigInt).Value = Fk_Satisfaccion
                    WHERE = WHERE & " and  Fk_Satisfaccion = @Fk_Satisfaccion "
                End If
                If Fk_Calificacion <> Nothing Then
                    cmd.Parameters.Add("@Fk_Calificacion", SqlDbType.BigInt).Value = Fk_Calificacion
                    WHERE = WHERE & " and Fk_Calificacion = @Fk_Calificacion "
                End If
                If Fk_Estado <> Nothing Then
                    cmd.Parameters.Add("@Fk_Estado", SqlDbType.BigInt).Value = Fk_Estado
                    WHERE = WHERE & " and Fk_Estado = @Fk_Estado "
                End If
                If UsuarioAsignado <> Nothing Then
                    cmd.Parameters.AddWithValue("@UsuarioAsignado", UsuarioAsignado)
                    WHERE = WHERE & " and UsuarioAsignado = @UsuarioAsignado "
                End If
                If FechaIngreso <> Nothing And FechaCierreGestion <> Nothing Then
                    cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = Convert.ToDateTime(FechaIngreso)
                    cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = Convert.ToDateTime(FechaCierreGestion)
                    WHERE = WHERE & " and convert(date,FechaInicio) >= @FechaInicio AND convert(date,FechaFin) <= @FechaFin "
                ElseIf FechaIngreso <> Nothing Then
                    cmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = Convert.ToDateTime(FechaIngreso)
                    WHERE = WHERE & " and convert(date,FechaInicio) = @FechaInicio "
                ElseIf FechaCierreGestion <> Nothing Then
                    cmd.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = Convert.ToDateTime(FechaCierreGestion)
                    WHERE = WHERE & " and convert(date,FechaFin) = @FechaFin "
                End If



            End If
            cmd.CommandText =
                "select CodigoTicket,FechaInicio as [Fecha Registro], UsuarioSolicita as [Usuario Solicita],Estado,Prioridad, UsuarioAsignado as [Usuario Asignado],Calificacion ,GradoSatisfaccion as [Nivel Satisfacción], FechaFin as [Fecha Cierre]
                        From RRHH_RegistroTicket RT
                        join   RRHHArea RArea
                        on Rt.Fk_Area = RArea.IdArea
                        join RRHHSector Secto
                        on Rt.Fk_Sector = Secto.Rh_Sector
                        join RRHHLocalizacion Localiza
                        on Rt.Fk_Sector = Localiza.IdLocalizacion
                        join RRHHElemento Eleme
                        on Rt.Fk_Localizacion = Eleme.IdElemento
                        join RRHH_Prioridad Prio 
                        on Rt.Fk_Prioridad = Prio.IdPrioridad
                        join RRHHSatisfaccion Satis
                        on Rt.Fk_Satisfaccion = Satis.IdSatisfaccion
                        join RRHHCalificacion Cali
                        on Rt.Fk_Calificacion = Cali.IdCalificacion
                        join RRHHEstado Estado
                        on RT.Fk_Estado = Estado.IdEstado
                   where 1=1 " & WHERE & "order by CodigoTicket desc"
            RecibeDatos = New SqlClient.SqlDataAdapter(cmd)
            cmd.Connection = cn
            RecibeDatos.Fill(datos)
            Cantidad = datos.Tables(0).Rows.Count
            Return datos.Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarConsultaTicketsCamposVacios() As DataTable
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeDatos As SqlClient.SqlDataAdapter
        Dim cmd As New SqlClient.SqlCommand
        Dim WHERE As String = ""
        Try
            cn.Open()
            cmd.CommandText = "          
			  select CodigoTicket,FechaInicio as [Fecha Registro], UsuarioSolicita as [Usuario Solicita],Estado,Prioridad, UsuarioAsignado as [Usuario Asignado],Calificacion ,GradoSatisfaccion as [Nivel Satisfacción], FechaFin as [Fecha Cierre]
                From RRHH_RegistroTicket RT
                join   RRHHArea RArea
                on Rt.Fk_Area = RArea.IdArea
                join RRHHSector Secto
                on Rt.Fk_Sector = Secto.Rh_Sector
                join RRHHLocalizacion Localiza
                on Rt.Fk_Sector = Localiza.IdLocalizacion
                join RRHHElemento Eleme
                on Rt.Fk_Localizacion = Eleme.IdElemento
                join RRHH_Prioridad Prio 
                on Rt.Fk_Prioridad = Prio.IdPrioridad
                join RRHHSatisfaccion Satis
                on Rt.Fk_Satisfaccion = Satis.IdSatisfaccion
                join RRHHCalificacion Cali
                on Rt.Fk_Calificacion = Cali.IdCalificacion
                join RRHHEstado Estado
            on RT.Fk_Estado = Estado.IdEstado order by CodigoTicket desc"
            RecibeDatos = New SqlClient.SqlDataAdapter(cmd)
            cmd.Connection = cn
            RecibeDatos.Fill(datos)
            Cantidad = datos.Tables(0).Rows.Count
            Return datos.Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarFiltroGestionTicketRh() As DataSet
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim WHERE As String = ""
        Dim RecibeDatos As SqlClient.SqlDataAdapter
        Try

            Dim cmd As New SqlClient.SqlCommand
            If CodigoTicket <> Nothing Then
                cmd.Parameters.AddWithValue("@CodigoTicket", CodigoTicket)
                WHERE = WHERE & " where CodigoTicket = @CodigoTicket"
            End If
            If IdTicket <> Nothing Then
                cmd.Parameters.Add("@Fk_IdTicket", SqlDbType.BigInt).Value = IdTicket
                WHERE = WHERE & " and Fk_IdTicket = @Fk_IdTicket    "
            End If

            cmd.CommandText =
                "SELECT CodigoTicket,G.FechaGestion as  [Fecha Gestion],UsuarioRegistra as [Usuario Registra] ,ObservacionEstado as Observación,E.Estado,R.UsuarioAsignado as [Usuario Asignado]
                     FROM  RRHHGestionTicket G 
                     join RRHH_RegistroTicket R on G.Fk_IdTicket = R.IdTicket  
                     join RRHHEstado E on G.Fk_idEstado = E.IdEstado
	            " & WHERE & "  order by CodigoTicket"


            RecibeDatos = New SqlClient.SqlDataAdapter(cmd)
            cmd.Connection = cn
            RecibeDatos.Fill(datos)
            Cantidad = datos.Tables(0).Rows.Count
            Return datos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarFiltroTicketRh1()
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeDatos As SqlClient.SqlDataAdapter
        Try
            Dim cmd As New SqlClient.SqlCommand
            cmd.CommandText =
                " select CodigoTicket,FechaInicio as [Fecha Registro],Tema,[Usuario Solicita],Area,Sector,Localizacion,Elemento,Estado,Prioridad,UsuarioAsignado as [Usuario Asignado] ,Requerimientos
						 From RRHH_RegistroTicket RT
						join   RRHHArea RArea
						 on Rt.Fk_Area = RArea.IdArea
						 join RRHHSector Secto
						 on Rt.Fk_Sector = Secto.Rh_Sector
						 join RRHHLocalizacion Localiza
						 on Rt.Fk_Sector = Localiza.IdLocalizacion
						 join RRHHElemento Eleme
						 on Rt.Fk_Localizacion = Eleme.IdElemento
						 join RRHH_Prioridad Prio 
						 on Rt.Fk_Prioridad = Prio.IdPrioridad
						 join RRHHSatisfaccion Satis
						 on Rt.Fk_Satisfaccion = Satis.IdSatisfaccion
						 join RRHHCalificacion Cali
						 on Rt.Fk_Calificacion = Cali.IdCalificacion
						 join RRHHEstado Estado
						 on RT.Fk_Estado = Estado.IdEstado
						 where Fk_Estado != 4					 

  "
            RecibeDatos = New SqlClient.SqlDataAdapter(cmd)
            cmd.Connection = cn
            RecibeDatos.Fill(datos)
            Return datos
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CargarFiltroTicketRh() As DataTable
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeDatos As SqlClient.SqlDataAdapter
        Try
            Dim cmd As New SqlClient.SqlCommand
            cmd.CommandText =
                "  select CodigoTicket,FechaInicio as [Fecha Registro],UsuarioSolicita,Area,Prioridad,Tema,Estado,Sector,Localizacion,Elemento,Requerimientos
						 From RRHH_RegistroTicket RT
						join   RRHHArea RArea
						 on Rt.Fk_Area = RArea.IdArea
						 join RRHHSector Secto
						 on Rt.Fk_Sector = Secto.Rh_Sector
						 join RRHHLocalizacion Localiza
						 on Rt.Fk_Localizacion = Localiza.IdLocalizacion
						 join RRHHElemento Eleme
						 on Rt.Fk_Elemento = Eleme.IdElemento
						 join RRHH_Prioridad Prio 
						 on Rt.Fk_Prioridad = Prio.IdPrioridad
						 join RRHHSatisfaccion Satis
						 on Rt.Fk_Satisfaccion = Satis.IdSatisfaccion
						 join RRHHCalificacion Cali
						 on Rt.Fk_Calificacion = Cali.IdCalificacion
						 join RRHHEstado Estado
						 on RT.Fk_Estado = Estado.IdEstado
						 where Fk_Estado != 4 order by IdTicket desc "
            RecibeDatos = New SqlClient.SqlDataAdapter(cmd)
            cmd.Connection = cn
            RecibeDatos.Fill(datos)
            Cantidad = datos.Tables(0).Rows.Count
            Return datos.Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "Para Formulario Pruebas Digitación"

    Public Sub RegAspirante()
        Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conexion2").ConnectionString) ' Conexion con la base 
        Try
            Dim cms As New SqlClient.SqlCommand("insert into [RRHH_RegistrarAsp] (Documento,Nombre,Apellido,Email,Celular,FechaRegistro) values (@Documento,@Nombre,@Apellido,@Email,@Celular,@FechaRegistro) ", cn)
            cn.Open()
            cms.Parameters.AddWithValue("@Documento", Documento)
            cms.Parameters.AddWithValue("@Nombre", Nombre)
            cms.Parameters.AddWithValue("@Apellido", Apellido)
            cms.Parameters.AddWithValue("@Email", Email)
            cms.Parameters.AddWithValue("@Celular", Celular)
            cms.Parameters.AddWithValue("@FechaRegistro", Now)
            cms.Connection = cn
            cms.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub
    Public Function ConsultarAspirante() As DataTable
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeDatos As SqlClient.SqlDataAdapter
        Try
            Dim cmd As New SqlClient.SqlCommand
            cmd.CommandText = "select Documento,Nombre,Apellido,Email as [Correo Electronico], Celular as [Número de Celular], FechaRegistro as [Fecha de Registro] from RRHH_RegistrarAsp where Documento = @Documento"
            cmd.Parameters.AddWithValue("@Documento", Documento)
            RecibeDatos = New SqlClient.SqlDataAdapter(cmd)
            cmd.Connection = cn
            RecibeDatos.Fill(datos)
            'Cantidad = datos.Tables(0).Rows.Count
            Return datos.Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsulResultAsp() As DataTable
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeDatos As SqlClient.SqlDataAdapter
        Try
            Dim cmd As New SqlClient.SqlCommand
            cmd.CommandText = "select convert(date,FechaPrueba) as [Fecha de Prueba],Documento,Reg.Nombre,Apellido,sum(Puntaje) as [Puntaje Total] from RRHH_RegistrarAsp Reg
                               join RRHH_PruebaAspirante Pru
                               on Reg.IdRegistrarAsp = Pru.Fk_IdRegistrarAsp
                               where Documento = @Documento Group by Documento,Reg.Nombre,Apellido,convert(date,FechaPrueba)"
            cmd.Parameters.AddWithValue("@Documento", Documento)
            RecibeDatos = New SqlClient.SqlDataAdapter(cmd)
            cmd.Connection = cn
            RecibeDatos.Fill(datos)
            Return datos.Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsulPrueADig() As DataTable
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeDatos As SqlClient.SqlDataAdapter
        Try
            Dim cmd As New SqlClient.SqlCommand
            cmd.CommandText = "select NumeroRegistro as [Numero de Prueba],  Codigo,Empresa,Nombre,Cargo,Cedula,Telefono,Direccion,Despacho,Email,Nit   from RRHH_DatosDigitar order by NumeroRegistro asc"
            RecibeDatos = New SqlClient.SqlDataAdapter(cmd)
            cmd.Connection = cn
            RecibeDatos.Fill(datos)

            Return datos.Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarResultados() As DataTable
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeDatos As SqlClient.SqlDataAdapter
        Try
            Dim cmd As New SqlClient.SqlCommand
            cmd.CommandText = "select Documento,FechaPrueba as [Fecha y Hora] ,Fk_DatosDigitar as [Numero de Prueba],Puntaje, Codigo,Empresa,PA.Nombre,Cargo,Cedula,Telefono,Direccion,Despacho,PA.Email,Nit  from RRHH_PruebaAspirante PA
                               join  RRHH_RegistrarAsp Re 
                               on PA.Fk_IdRegistrarAsp = Re.IdRegistrarAsp where Documento = @Documento"
            cmd.Parameters.AddWithValue("@Documento", Documento)
            RecibeDatos = New SqlClient.SqlDataAdapter(cmd)
            cmd.Connection = cn
            RecibeDatos.Fill(datos)
            Return datos.Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarDatosAspirante()
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cn.Open()
            Dim cmd As New SqlClient.SqlCommand(
                "select * from RRHH_RegistrarAsp where Documento = @Documento", cn)
            cmd.Parameters.Add("@Documento", SqlDbType.VarChar).Value = Documento
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            _cantidad = datos.Tables(0).Rows.Count
            If _cantidad > 0 Then
                Documento = datos.Tables(0).Rows(0).Item("Documento")
                Nombre = datos.Tables(0).Rows(0).Item("Nombre")
                Apellido = datos.Tables(0).Rows(0).Item("Apellido")
                IdRegistrarAsp = datos.Tables(0).Rows(0).Item("IdRegistrarAsp")
            Else
                Documento = ""
            End If
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function
    Public Function CargarRespuestasAspirante()
        Dim cn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("conexion2").ConnectionString)
        Dim datos As New DataSet
        Dim RecibeData As SqlClient.SqlDataAdapter
        Try
            cn.Open()
            Dim cmd As New SqlClient.SqlCommand(
                "select * from RRHH_DatosDigitar where IdDatosDigitar = @IdDatosDigitar", cn)
            cmd.Parameters.Add("@IdDatosDigitar", SqlDbType.VarChar).Value = Fk_DatosDigitar
            'datos DIgitar es el numero de la pregunta q se esta haciendo en el momento
            RecibeData = New SqlClient.SqlDataAdapter(cmd)
            RecibeData.Fill(datos)
            _cantidad = datos.Tables(0).Rows.Count
            If _cantidad > 0 Then
                Codigo1 = datos.Tables(0).Rows(0).Item("Codigo")
                Empresa1 = datos.Tables(0).Rows(0).Item("Empresa")
                Nombre1 = datos.Tables(0).Rows(0).Item("Nombre")
                Cargo1 = datos.Tables(0).Rows(0).Item("Cargo")
                Cedula1 = datos.Tables(0).Rows(0).Item("Cedula")
                Telefono1 = datos.Tables(0).Rows(0).Item("Telefono")
                Direccion1 = datos.Tables(0).Rows(0).Item("Direccion")
                Despacho1 = datos.Tables(0).Rows(0).Item("Despacho")
                Email1 = datos.Tables(0).Rows(0).Item("Email")
                Nit1 = datos.Tables(0).Rows(0).Item("Nit")
            End If
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function


    Public Sub RegPrueba()
        Dim cn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conexion2").ConnectionString) ' Conexion con la base 
        Try
            Dim cms As New SqlClient.SqlCommand("insert into [RRHH_PruebaAspirante] (Fk_IdRegistrarAsp,Fk_DatosDigitar,Puntaje,Intentos,Codigo,Empresa,Nombre,Cargo,Cedula,Telefono,Direccion,Despacho,Email,Nit,FechaPrueba) values (@Fk_IdRegistrarAsp,@Fk_DatosDigitar,@Puntaje,@Intentos,@Codigo,@Empresa,@Nombre,@Cargo,@Cedula,@Telefono,@Direccion,@Despacho,@Email,@Nit,@FechaPrueba) ", cn)
            cn.Open()

            cms.Parameters.AddWithValue("@Fk_IdRegistrarAsp", Fk_IdRegistrarAsp)
            cms.Parameters.AddWithValue("@Fk_DatosDigitar", Fk_DatosDigitar)
            cms.Parameters.AddWithValue("@Puntaje", Puntaje)
            cms.Parameters.AddWithValue("@Intentos", Intentos)
            If Codigo = Nothing Then
                Codigo = "No Respondio"
                cms.Parameters.AddWithValue("@Codigo", Codigo)
            Else
                cms.Parameters.AddWithValue("@Codigo", Codigo)
            End If
            If Empresa = Nothing Then
                Empresa = "No Respondio"
                cms.Parameters.AddWithValue("@Empresa", Empresa)
            Else
                cms.Parameters.AddWithValue("@Empresa", Empresa)
            End If
            If Nombre = Nothing Then
                Nombre = "No Respondio"
                cms.Parameters.AddWithValue("@Nombre", Nombre)
            Else
                cms.Parameters.AddWithValue("@Nombre", Nombre)
            End If
            If Cargo = Nothing Then
                Cargo = "No Respondio"
                cms.Parameters.AddWithValue("@Cargo", Cargo)
            Else
                cms.Parameters.AddWithValue("@Cargo", Cargo)
            End If
            If Cedula = Nothing Then
                Cedula = "No Respondio"
                cms.Parameters.AddWithValue("@Cedula", Cedula)
            Else
                cms.Parameters.AddWithValue("@Cedula", Cedula)
            End If
            If Telefono = Nothing Then
                Telefono = "No Respondio"
                cms.Parameters.AddWithValue("@Telefono", Telefono)
            Else
                cms.Parameters.AddWithValue("@Telefono", Telefono)
            End If
            If Direccion = Nothing Then
                Direccion = "No Respondio"
                cms.Parameters.AddWithValue("@Direccion", Direccion)
            Else
                cms.Parameters.AddWithValue("@Direccion", Direccion)
            End If
            If Despacho = Nothing Then
                Despacho = "No Respondio"
                cms.Parameters.AddWithValue("@Despacho", Despacho)
            Else
                cms.Parameters.AddWithValue("@Despacho", Despacho)
            End If
            If Email = Nothing Then
                Email = "No Respondio"
                cms.Parameters.AddWithValue("@Email", Email)
            Else
                cms.Parameters.AddWithValue("@Email", Email)
            End If
            If Nit = Nothing Then
                Nit = "No Respondio"
                cms.Parameters.AddWithValue("@Nit", Nit)
            Else
                cms.Parameters.AddWithValue("@Nit", Nit)
            End If
            cms.Parameters.AddWithValue("@FechaPrueba", Now)
            cms.Connection = cn
            cms.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub
#End Region
End Class
