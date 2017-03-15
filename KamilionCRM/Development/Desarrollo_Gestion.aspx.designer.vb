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


Partial Public Class Desarrollo_Gestion
    
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
    '''Control Pnl_Filtros.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Filtros As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Txt_Cons_Cod.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Cons_Cod As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Cons_FcIni.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Cons_FcIni As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Cons_FcFin.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Cons_FcFin As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Btn_Filtrar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Filtrar As Global.System.Web.UI.WebControls.LinkButton
    
    '''<summary>
    '''Control Drl_Cons_Pri.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Cons_Pri As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Drl_Cons_Est.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Cons_Est As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Pnl_Gestion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Gestion As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Txt_Codigo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Codigo As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Solicitante.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Solicitante As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Fc_Reg.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Fc_Reg As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Requerimientos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Requerimientos As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Prioridad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Prioridad As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Area.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Area As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Tema.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Tema As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Drl_Complejidad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Complejidad As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Txt_Observacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Observacion As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Pnl_Usu_Esc.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Usu_Esc As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Drl_Usu_Asig.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Usu_Asig As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Btn_Guardar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Guardar As Global.System.Web.UI.WebControls.LinkButton
    
    '''<summary>
    '''Control Btn_Volver.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Volver As Global.System.Web.UI.WebControls.LinkButton
    
    '''<summary>
    '''Control Drl_Operatividad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Operatividad As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Drl_Estado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Estado As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Pnl_Dtg_Desarrollos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Dtg_Desarrollos As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Lbl_Cantidad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Cantidad As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Dtg_Desarrollos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Dtg_Desarrollos As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control Pnl_Dtg_Gestiones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Dtg_Gestiones As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Lbl_Cantidad2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Cantidad2 As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Dtg_Gestiones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Dtg_Gestiones As Global.System.Web.UI.WebControls.GridView
End Class
