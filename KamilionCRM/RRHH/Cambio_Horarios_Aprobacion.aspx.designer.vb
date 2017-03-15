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


Partial Public Class Cambio_Horarios_Aprobacion
    
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
    '''Control Pnl_Registro.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Pnl_Registro As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Lbl_Codigo_Ingeniero.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Codigo_Ingeniero As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Codigo_Horario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Codigo_Horario As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Tipo_Horario_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Tipo_Horario_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Cod_Tipo_Horario_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Cod_Tipo_Horario_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Ingreso_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Ingreso_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Salida_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Salida_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Segmento_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Segmento_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Jefe_Inmediato_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Jefe_Inmediato_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Ingreso_A_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Ingreso_A_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Salida_A_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Salida_A_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Ingreso_B1_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Ingreso_B1_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Salida_B1_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Salida_B1_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Ingreso_B2_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Ingreso_B2_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Salida_B2_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Salida_B2_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Ingreso_C_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Ingreso_C_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Salida_C_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Salida_C_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Ingreso_P_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Ingreso_P_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Salida_P_Ant.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Salida_P_Ant As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Btn_Aprobar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Aprobar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control Btn_Rechazar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Rechazar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control Btn_Cancelar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Btn_Cancelar As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control Lbl_Fecha_Turno.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Fecha_Turno As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Codigo_Solicitud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Codigo_Solicitud As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Tipo_Horario_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Tipo_Horario_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Cod_Tipo_Horario_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Cod_Tipo_Horario_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Ingreso_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Ingreso_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Salida_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Salida_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Segmento_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Segmento_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Jefe_Inmediato_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Jefe_Inmediato_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Ingreso_A_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Ingreso_A_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Salida_A_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Salida_A_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Ingreso_B1_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Ingreso_B1_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Salida_B1_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Salida_B1_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Ingreso_B2_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Ingreso_B2_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Salida_B2_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Salida_B2_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Ingreso_C_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Ingreso_C_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Salida_C_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Salida_C_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Ingreso_P_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Ingreso_P_New As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control Lbl_Hora_Salida_P_New.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Lbl_Hora_Salida_P_New As Global.System.Web.UI.WebControls.Label
    
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
