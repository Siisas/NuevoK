Imports System.Web.Script.Serialization
Imports System.Security.Cryptography
Imports System.IO
Public Class Cls_Gestion_Datos
    'Variables de la clase
    'Variables de la clase
    Private _Ex As Object
    Public Property Ex As Object
        Get
            Return _Ex
        End Get
        Set(ByVal value As Object)
            _Ex = value
        End Set
    End Property

    Private _DataSet As DataSet
    Public Property DataSet As DataSet
        Get
            Return _DataSet
        End Get
        Set(ByVal value As DataSet)
            _DataSet = value
        End Set
    End Property
    Private _Grid_Config As String
    Public Property Grid_Config As String
        Get
            Return _Grid_Config
        End Get
        Set(ByVal value As String)
            _Grid_Config = value
        End Set
    End Property
    Private _SubGrid_Config As String
    Public Property SubGrid_Config As String
        Get
            Return _SubGrid_Config
        End Get
        Set(ByVal value As String)
            _SubGrid_Config = value
        End Set
    End Property
    Private _Grid_Keys As String
    Public Property Grid_Keys As String
        Get
            Return _Grid_Keys
        End Get
        Set(ByVal value As String)
            _Grid_Keys = value
        End Set
    End Property
    Private _SubGrid_Keys As String
    Public Property SubGrid_Keys As String
        Get
            Return _SubGrid_Keys
        End Get
        Set(ByVal value As String)
            _SubGrid_Keys = value
        End Set
    End Property
    Private _Grid_Datafields As String
    Public Property Grid_Datafields As String
        Get
            Return _Grid_Datafields
        End Get
        Set(ByVal value As String)
            _Grid_Datafields = value
        End Set
    End Property
    Private _SubGrid_Datafields As String
    Public Property SubGrid_Datafields As String
        Get
            Return _SubGrid_Datafields
        End Get
        Set(ByVal value As String)
            _SubGrid_Datafields = value
        End Set
    End Property
    Private _Grid_Columns As String
    Public Property Grid_Columns As String
        Get
            Return _Grid_Columns
        End Get
        Set(ByVal value As String)
            _Grid_Columns = value
        End Set
    End Property
    Private _SubGrid_Columns As String
    Public Property SubGrid_Columns As String
        Get
            Return _SubGrid_Columns
        End Get
        Set(ByVal value As String)
            _SubGrid_Columns = value
        End Set
    End Property
    'Métodos y funciones
    Public Function Generate_Data_Grid()
        Try
            Dim Data = New Dictionary(Of String, Object)
            Data.Add("Grid", New Dictionary(Of String, Object))
            Data("Grid").Add("Config", JSON_To_Object(_Grid_Config))
            Data("Grid").Add("Data", DataTable_To_Object(_DataSet.Tables(0)))
            Data("Grid").Add("Format", New Dictionary(Of String, Object))
            Data("Grid")("Format").Add("Datafields", JSON_To_Object(_Grid_Datafields))
            Data("Grid")("Format").Add("Columns", JSON_To_Object(_Grid_Columns))
            Data("Grid")("Format").Add("Keys", JSON_To_Object(_Grid_Keys))
            If _DataSet.Tables.Count > 1 Then
                Data.Add("Sub_Grid", New Dictionary(Of String, Object))
                Data("Sub_Grid").Add("Config", JSON_To_Object(_SubGrid_Config))
                Data("Sub_Grid").Add("Data", DataTable_To_Object(_DataSet.Tables(1)))
                Data("Sub_Grid").Add("Format", New Dictionary(Of String, Object))
                Data("Sub_Grid")("Format").Add("Datafields", JSON_To_Object(_SubGrid_Datafields))
                Data("Sub_Grid")("Format").Add("Columns", JSON_To_Object(_SubGrid_Columns))
                Data("Sub_Grid")("Format").Add("Keys", JSON_To_Object(_SubGrid_Keys))
            End If
            Return Data
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function DataSet_To_Object(DataSet As DataSet)
        'declarar objeto de tablas
        Dim ArrayTables As New List(Of Object) 'New Dictionary(Of String, Object)
        'Extraer tablas
        For Each Table As DataTable In DataSet.Tables
            'declarar objeto de filas
            Dim ArrayRows As New List(Of Object)
            'Extraer filas
            For Each Row As DataRow In Table.Rows
                'declarar objeto de columnas
                Dim ArrayColumns = New Dictionary(Of String, Object)
                'Extraer Columnas y datos
                For Each Column As DataColumn In Table.Columns
                    ArrayColumns.Add(Column.ColumnName.Trim(), Row(Column))
                Next
                ArrayRows.Add(ArrayColumns)
            Next
            ArrayTables.Add(ArrayRows)
            'ArrayTables.Add(Table.TableName, ArrayRows)
        Next
        Return ArrayTables
    End Function
    Public Function DataTable_To_Object(Table As DataTable)
        'declarar objeto de filas
        Dim ArrayRows As New List(Of Object)
        'Extraer filas
        For Each Row As DataRow In Table.Rows
            'declarar objeto de columnas
            Dim ArrayColumns = New Dictionary(Of String, Object)
            'Extraer Columnas y datos
            For Each Column As DataColumn In Table.Columns
                ArrayColumns.Add(Column.ColumnName.Trim(), Row(Column))
            Next
            ArrayRows.Add(ArrayColumns)
        Next
        Return ArrayRows
    End Function
    Public Function Object_To_JSON(Input_Object As Object)
        Dim json As New JavaScriptSerializer
        Return Regex.Replace(json.Serialize(Input_Object), """\\/Date\((-?\d+)\)\\/""", "/Date($1)/")
    End Function
    Public Function JSON_To_Object(Input_String As String)
        Dim json As New JavaScriptSerializer
        Return json.DeserializeObject(Input_String)
    End Function
    Public Function String_To_MD5(ByVal Input As String)
        Dim Md5 As MD5 = MD5.Create()
        Dim Data As Byte() = Md5.ComputeHash(Encoding.Default.GetBytes(Input))
        Dim SB As New StringBuilder
        Dim i As Integer
        For i = 0 To Data.Length - 1
            SB.Append(Data(i).ToString("x2"))
        Next i
        Return SB.ToString()
    End Function
    Public Sub Validar_Herramientas(ByVal Obj As Object, ByVal Name As String, Optional ByVal Type As String = Nothing, Optional ByVal Min As Object = Nothing, Optional ByVal Max As Object = Nothing, Optional ByVal NotNull As Boolean = True)
        Try
            If TypeOf Obj Is TextBox Then
                If Obj.Text.ToString.Trim = Nothing And NotNull Then
                    Throw New Exception("Por favor llene el campo """ & Name & """")
                End If
                If Type = Nothing Then
                    If Max <> Nothing Then
                        If Obj.Text.ToString.Trim.Length > Max Then
                            Throw New Exception("El campo """ & Name & """ debe tener como máximo " & Max & " Caracteres")
                        End If
                    End If
                    If Min <> Nothing Then
                        If Obj.Text.ToString.Trim.Length < Min Then
                            Throw New Exception("El campo """ & Name & """ debe tener como minimo " & Min & " Caracteres")
                        End If
                    End If
                ElseIf Type <> Nothing And Obj.Text <> "" Then
                    If Type = "Date" Or Type = "DateTime" Then
                        If Type = "Date" And Not IsDate(Obj.Text) Then
                            Throw New Exception("El campo """ & Name & """ debe tener el formato de fecha DD/MM/YYYY")
                        ElseIf Type = "DateTime" And Not IsDate(Obj.Text) Then
                            Throw New Exception("El campo """ & Name & """ debe tener el formato de fecha y hora DD/MM/YYYY HH:mm:ss")
                        End If
                        If Max <> Nothing Then
                            If Date.Parse(Obj.Text) > Date.Parse(Max) Then
                                Throw New Exception("La fecha del campo """ & Name & """ debe ser menor o igual a " & Max)
                            End If
                        End If
                        If Min <> Nothing Then
                            If Date.Parse(Obj.Text) < Date.Parse(Min) Then
                                Throw New Exception("La fecha del campo """ & Name & """ debe ser mayor o igual a " & Min)
                            End If
                        End If
                    ElseIf Type = "Numeric" Then
                        If Not IsNumeric(Obj.Text) Then
                            Throw New Exception("El campo """ & Name & """ debe contener solo números sin espacios entre si")
                        End If
                        If Max <> Nothing Then
                            If Int64.Parse(Obj.Text) > Int64.Parse(Max) Then
                                Throw New Exception("El número del campo """ & Name & """ debe ser menor o igual a " & Max)
                            End If
                        End If
                        If Min <> Nothing Then
                            If Int64.Parse(Obj.Text) < Int64.Parse(Min) Then
                                Throw New Exception("El número del campo """ & Name & """ debe ser mayor o igual a " & Min)
                            End If
                        End If
                    End If
                End If
            End If
            If TypeOf Obj Is DropDownList Then
                If Obj.selectedindex <= 0 Then
                    Throw New Exception("Por favor seleccione una opcion de """ & Name & """")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Val_Ex(ByVal Obj_Ex As Exception)
        Try
            _Ex = JSON_To_Object("{Alert:'alert alert-danger',Message:'', System:true}")
            _Ex("Message") = "<span class=""glyphicon glyphicon-remove-sign""></span> " & Obj_Ex.Message & ""
            If Obj_Ex.Source = "digitacion" Then
                _Ex("Alert") = "alert alert-warning"
                _Ex("Message") = "<span class='glyphicon glyphicon-warning-sign'></span> " & Obj_Ex.Message & ""
                _Ex("System") = False
            ElseIf Obj_Ex.Source = ".Net SqlClient Data Provider" Then
                If DirectCast(Obj_Ex, System.Data.SqlClient.SqlException).[Class] = 11 Then
                    _Ex("Alert") = "alert alert-warning"
                    _Ex("Message") = "<span class='glyphicon glyphicon-warning-sign'></span> " & Obj_Ex.Message & ""
                    _Ex("System") = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Gest_Drl(ByRef Drl As DropDownList) As DropDownList
        Try
            '_____________________Gestionar Drl Recibido_______________________
            With Drl
                Dim Txt_Ini As String = "- Seleccione -"
                Dim New_Txt_Ini As String = "- Seleccione -"
                '__________validar la existencia del item inicial______________
                If .Items.Count <= 0 Then
                    .Items.Insert(0, New_Txt_Ini)
                ElseIf .Items(0).Text.ToUpper = (Txt_Ini).ToUpper Then
                    .Items(0).Text = New_Txt_Ini
                ElseIf .Items(0).Text.ToUpper <> (Txt_Ini).ToUpper Then
                    .Items.Insert(0, New_Txt_Ini)
                End If
                .Items(0).Text = New_Txt_Ini
                .Items(0).Value = ""
                .SelectedIndex = 0
                '______________________________________________________________
                '___________Validar Posicionamiento____________________________
                If .Items.Count <= 2 And .Items.Count > 1 Then
                    .SelectedIndex = 1
                End If
            End With
            Return Drl
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Guardar_Fichero(ByVal Ruta As String, ByVal Nombre As String, ByVal Codigo_Fichero As Byte())
        Dim Path As String = Ruta & Nombre
        Using Fichero As FileStream = File.Create(Path)
            Fichero.Write(Codigo_Fichero, 0, Codigo_Fichero.Length)
        End Using
    End Sub
End Class
