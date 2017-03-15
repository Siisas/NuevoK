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


Partial Public Class Cambio_Horarios_Solicitud
    
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
    '''Control Pnl_Consulta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Consulta As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control TxtCod_Agente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtCod_Agente As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Btn_Buscar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Buscar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control CompareValidator9.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents CompareValidator9 As Global.System.Web.UI.WebControls.CompareValidator
    
    '''<summary>
    '''Control TxtFecha_Turno.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents TxtFecha_Turno As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Pnl_Registro.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Registro As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Pnl_Turno.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Turno As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control LblCod_Agente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents LblCod_Agente As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control LblFec_Turno.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents LblFec_Turno As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control DrlHora_Ingreso.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents DrlHora_Ingreso As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control DrlSegmento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents DrlSegmento As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control LblCod_Horario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents LblCod_Horario As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control drlTipoHorario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents drlTipoHorario As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control DrlHora_Salida.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents DrlHora_Salida As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control DrlJefeInmediato.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents DrlJefeInmediato As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control PnlAlmuerzo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents PnlAlmuerzo As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control DrlHora_Almuerzo_1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents DrlHora_Almuerzo_1 As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control DrlHora_Almuerzo_2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents DrlHora_Almuerzo_2 As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control PnlBreaks.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents PnlBreaks As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Drl_Hora_Break1_1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Hora_Break1_1 As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Drl_Hora_Break1_2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Hora_Break1_2 As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Drl_Hora_Break2_1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Hora_Break2_1 As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Drl_Hora_Break2_2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Drl_Hora_Break2_2 As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control PnlCapacitacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents PnlCapacitacion As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Txt_Hora_Capacitacion_1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Hora_Capacitacion_1 As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Hora_Capacitacion_2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Hora_Capacitacion_2 As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control PnlPreTurno.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents PnlPreTurno As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Txt_Pre_Turno_1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Pre_Turno_1 As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Txt_Pre_Turno_2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Txt_Pre_Turno_2 As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Btn_Solicitar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Solicitar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control Pnl_Dtg_Solicitudes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Dtg_Solicitudes As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control LblCuenta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents LblCuenta As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Dtg_Solicitudes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Dtg_Solicitudes As Global.System.Web.UI.WebControls.GridView
End Class
