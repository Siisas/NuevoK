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


Partial Public Class Inventario
    
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
    '''Control TxtLetra.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtLetra As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Fc_Adq.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Fc_Adq As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Btn_RegMod.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_RegMod As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control Btn_Limpiar_RegMod.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Limpiar_RegMod As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control TxtNumero.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtNumero As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Drl_Area_Modulo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Area_Modulo As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Drl_Dispositivo_RegDisp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Dispositivo_RegDisp As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Txt_Modelo_RegDisp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Modelo_RegDisp As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Drl_Empresa_RegDisp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Empresa_RegDisp As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Txt_Empresa_RegDisp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Empresa_RegDisp As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Drl_Moulo_RegDisp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Moulo_RegDisp As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Btn_RegDisp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_RegDisp As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control Btn_Limpiar_RegDisp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Limpiar_RegDisp As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control Drl_Marca_RegDisp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Marca_RegDisp As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Txt_Marca_RegDisp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Marca_RegDisp As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Serial_RegDisp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Serial_RegDisp As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Pnl_Txt_SerialK_RegDisp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Txt_SerialK_RegDisp As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Txt_SerialK_RegDisp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_SerialK_RegDisp As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_FechAdqui_RegDisp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_FechAdqui_RegDisp As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control drlModuloConsultas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents drlModuloConsultas As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Drl_Marca_Cons.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Marca_Cons As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control TxtMarcaConsulta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtMarcaConsulta As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtModeloConsulta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtModeloConsulta As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Consuta_Adquisicion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Consuta_Adquisicion As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Btn_Consultar_Inventario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Consultar_Inventario As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control Btn_Limpiar_Cons.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Limpiar_Cons As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control TxtSerialConsulta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtSerialConsulta As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control TxtSerialKamilionConsulta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtSerialKamilionConsulta As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Drl_Empresa_Cons.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Empresa_Cons As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Txt_Empresa_Cons.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Empresa_Cons As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Drl_Area_Cons.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Area_Cons As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Pnl_Dtg_ConsInv.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Dtg_ConsInv As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Lbl_ConsInv.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_ConsInv As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Dtg_ConsInv.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Dtg_ConsInv As Global.System.Web.UI.WebControls.GridView
End Class
