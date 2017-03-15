Imports System.Web.Script.Serialization
Partial Public Class _default
    Inherits System.Web.UI.Page
    Private objdatos As New clsgeneral
    Private Obj_Gestion_Datos As New Cls_Gestion_Datos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("permisos") Is Nothing Then
                Response.Redirect("~/entrada.aspx?ReturnUrl=" & Request.RawUrl)
            End If
            If Not IsPostBack Then
                Session("Formulario") = "Default Kamilion ERP"
                Dim objdatos As New clsgeneral
                Dim dt As New DataSet
                Generar_Graficos()
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            Lbl_Message.Text = "<span class='glyphicon glyphicon-remove-sign'></span>" & ex.Message
        End Try
    End Sub
    Private Sub Generar_Graficos()
        Try
            If Session("Json_Graphics") = Nothing Then
                objdatos.idusuario = CType(Session("permisos"), clsusuario).usuario
                Dim MyDts As DataSet = objdatos.Cons_Productividad()
                Session("Json_Graphics") = Obj_Gestion_Datos.Object_To_JSON(Obj_Gestion_Datos.DataSet_To_Object(MyDts))
                Dim dt As String = Session("Json_Graphics")
            End If
            If Session("Json_Graphics") <> Nothing Then
                ScriptManager.RegisterStartupScript(Page, GetType(Page), "Ini_Graphics", "Order_Graphics_Date('" & Session("Json_Graphics") & "');", True)
            End If
        Catch ex As Exception
            Pnl_Message.CssClass = "alert alert-danger"
            Lbl_Message.Text = "<span class='glyphicon glyphicon-remove-sign'></span>" & ex.Message
        End Try
    End Sub

    '<System.Web.Services.WebMethod()>
    Public Shared Function Pop_Up_Cas_Prog()
        Dim Current As HttpContext = HttpContext.Current
        Try
            Dim Obj_Datos As New clsdatos
            Dim Obj_G_D As New Cls_Gestion_Datos
            Dim Id_Usuario As String = CType(Current.Session("permisos"), clsusuario).usuario
            Dim Ini_Turno As Date = CType(Current.Session("permisos"), clsusuario).Ini_Turno
            Dim Fin_Turno As Date = CType(Current.Session("permisos"), clsusuario).Fin_Turno
            Dim Dtt As DataTable
            Dim Obj = New Dictionary(Of String, Object)
            Obj = New Dictionary(Of String, Object)
            Obj.Add("Hora", Obj_G_D.Object_To_JSON(Now))
            Obj.Add("Id_Usuario", Id_Usuario)
            Dtt = Obj_Datos.Con_Cas_Prog_Agent(Id_Usuario, Ini_Turno, Fin_Turno)
            Dtt.Columns.Add("Check", Type.GetType("System.Boolean"))
            For I As Integer = 0 To Dtt.Rows.Count - 1
                Dtt.Rows(I).Item("Check") = False
            Next
            Obj.Add("Dtt", Obj_G_D.DataTable_To_Object(Dtt))
            Return Obj
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class