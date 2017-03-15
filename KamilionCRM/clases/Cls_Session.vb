Public Class Cls_Session
    Public Function CrearValidar_SesionLocal(ByVal Nombre_Form As String, ByRef ViewState As Object)
        'si en el objeto viewstate no existe el objeto session
        If IsNothing(ViewState) Then
            'crear nuevo ovjeto session dentro de viewstate
            ViewState = New Dictionary(Of String, Object)
            'agregar objeto form al objeto session del viewstate
            ViewState.add("Form", Nombre_Form)
            ViewState.add("Id_Session", Nothing)
        End If
        'referenciar Session global
        Dim Session = HttpContext.Current.Session()
        'si la session global que almacena las sessiones locales es nula
        If IsNothing(Session("Sesiones_Locales")) Then
            'Crear la session global
            Session("Sesiones_Locales") = New Dictionary(Of String, Object)
        End If
        If Not Session("Sesiones_Locales").ContainsKey(Nombre_Form) Then
            'añadir a la session global el objeto Form de tipo diccionario
            Session("Sesiones_Locales").add(Nombre_Form, New Dictionary(Of String, Object))
            'añadir al bojeto Form que se encuentra en la session global, un contador iniciado en 0
            Session("Sesiones_Locales")(Nombre_Form).add("Contador", 0)
            'añadir al bojeto Form que se encuentra en la session global, el objeto session de tipo diccionario
            Session("Sesiones_Locales")(Nombre_Form).add("Session", New Dictionary(Of Integer, Object))
        End If
        If ViewState("Id_Session") = Nothing Then
            'aumentar el contador de la session global del formulario en +1
            Session("Sesiones_Locales")(Nombre_Form)("Contador") = Session("Sesiones_Locales")(Nombre_Form)("Contador") + 1
            'añadir un nuevo objeto con el contador como index en el campo sesssion de la variable de session global del formulario
            Session("Sesiones_Locales")(Nombre_Form)("Session").add(Session("Sesiones_Locales")(Nombre_Form)("Contador"), New Dictionary(Of String, Object))
            'actualizar la key de la session local de acuerdo a la nueva key registrada en la variable global
            ViewState("Id_Session") = Session("Sesiones_Locales")(Nombre_Form)("Contador")
            'si la session local si contiene al objeto Id_Session PERO la variable global del formulario no contiene un objeto con el indice de la variable local
        ElseIf Not Session("Sesiones_Locales")(Nombre_Form)("Session").ContainsKey(ViewState("Id_Session")) Then
            'aumentar el contador de la session global del formulario en +1
            Session("Sesiones_Locales")(Nombre_Form)("Contador") = Session("Sesiones_Locales")(Nombre_Form)("Contador") + 1
            'actualizar el index de la session local con el contador de la variable global
            ViewState("Id_Session") = Session("Sesiones_Locales")(Nombre_Form)("Contador")
            'añadir nuevamente la session local con el nuevo index a la session global del formulario
            Session("Sesiones_Locales")(Nombre_Form)("Session").Add(ViewState("Id_Session"), ViewState)
        End If
        Return Session("Sesiones_Locales")(Nombre_Form)("Session")(ViewState("Id_Session"))
    End Function
End Class