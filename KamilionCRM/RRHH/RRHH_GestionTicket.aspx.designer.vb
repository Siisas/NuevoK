'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class GestionTicketRH
    
    '''<summary>
    '''Control Header.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Header As Global.digitacion.Header
    
    '''<summary>
    '''Control Pnl_Message.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Message As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control lblmsg.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblmsg As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Pnl_Filtros1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Filtros1 As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Pnl_Filtros.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Filtros As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control TxtCodigoFiltro.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtCodigoFiltro As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtFechaInicio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtFechaInicio As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtFechaFiltroFinal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtFechaFiltroFinal As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Btn_Filtrar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Filtrar As Global.System.Web.UI.WebControls.LinkButton
    
    '''<summary>
    '''Control Drl_PrioridadGestion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_PrioridadGestion As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Lbl_Cantidad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Cantidad As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Gtg_ConsultaTickets.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Gtg_ConsultaTickets As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control Pnl_Gestion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Gestion As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control TxtCodigoGestion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtCodigoGestion As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtPersonaSolicita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtPersonaSolicita As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtTemaG.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtTemaG As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtArea.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtArea As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Requerimientos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Requerimientos As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtPrioridad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtPrioridad As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtAreaLocalizacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtAreaLocalizacion As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtElementoG.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtElementoG As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtFechaTktGestion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtFechaTktGestion As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtUsuarioAsignado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtUsuarioAsignado As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtEstado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtEstado As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Drl_Estado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Estado As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Drl_Usuarios.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Usuarios As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control TxtObservacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtObservacion As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtIdTicket.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtIdTicket As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Btn_GuardarGestion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_GuardarGestion As Global.System.Web.UI.WebControls.LinkButton
    
    '''<summary>
    '''Control Btn_CerrarTicket.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_CerrarTicket As Global.System.Web.UI.WebControls.LinkButton
    
    '''<summary>
    '''Control Btn_VolverGestion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_VolverGestion As Global.System.Web.UI.WebControls.LinkButton
    
    '''<summary>
    '''Control Lbl_CatidadGestiones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_CatidadGestiones As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Gtg_ConsultaGestiones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Gtg_ConsultaGestiones As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control Lbl_Msgdesp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Msgdesp As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Btn_Si.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Si As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control Pnl_CerrarGestion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_CerrarGestion As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control TxtCodigoaa.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtCodigoaa As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtPersona.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtPersona As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtTemaCierre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtTemaCierre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtAreaCierre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtAreaCierre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtRequerimientosCierre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtRequerimientosCierre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtPrioridadCierre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtPrioridadCierre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtLocalizacionCierre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtLocalizacionCierre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtElementoCierre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtElementoCierre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtUsuarioGestionaCierre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtUsuarioGestionaCierre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtEstadoCierre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtEstadoCierre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Drl_Calificacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Calificacion As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control TxtObservacionCierre.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtObservacionCierre As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Drl_NivelS.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_NivelS As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Btn_GuardarCalificacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_GuardarCalificacion As Global.System.Web.UI.WebControls.LinkButton
    
    '''<summary>
    '''Control Btn_VolverCierreCalificacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_VolverCierreCalificacion As Global.System.Web.UI.WebControls.LinkButton
End Class
