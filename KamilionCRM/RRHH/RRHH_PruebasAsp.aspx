<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RRHH_PruebasAsp.aspx.vb" Inherits="digitacion.RRHH_PruebasAsp" %>
<%@ Register Src="~/Controles/Header.ascx" TagName="Header" TagPrefix="Control" %>
<!DOCTYPE html>
<%--	Ricar	--%>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ERP Kamilion </title>
    <link rel="icon" href="~/favicon.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon" />
    <script type="text/javascript" src="../Css2/jquery.min.js"></script>
    <script type="text/javascript" src="../Css2/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../Css2/jquery-ui-timepiker.js"></script>
    <script type="text/javascript" src="../Css2/scripts.js"></script>
    <!--#########Estilos############-->
    <link type="text/css" rel="Stylesheet" href="~/Css2/Boot/css/bootstrap.min.css" />
    <link type="text/css" rel="Stylesheet" href="~/Css2/jquery-ui.css" />
    <link type="text/css" rel="Stylesheet" href="~/Css2/Kamilion.css" />
    <script src="../Css2/jquery-2.0.3.js"></script>
<%--    <script src="../Css2/jquery.countdownTimer.js"></script>
    <script src="../Css2/jquery.countdownTimer.min.js"></script>
    <link href="../Css2/jquery.countdownTimer.css" rel="stylesheet" />--%>
    <%--otro CountDown--%>
    <%--ok--%>
   <script src="../Css2/jquery.time-to.js"></script>
    <script src="../Css2/jquery.time-to.min.js"></script>
    <link href="../Css2/timeTo.css" rel="stylesheet" />
    <script>
        $(document).ready(function () {
            $("#btn_Back").hide();
            $("#BtnComenzar").click(function() {
                var dato = $("#countdown").val()
                dato = ""
                if (dato == "Debe llenar los campos del Aspirante para iniciar la prueba") {
                }
                else {
                    $("#m_timer").show
                    $('#countdown').timeTo(360, function () {
                        $("#Pnl_Prueba1").hide();
                        $("#Pnl_Prueba2").hide();
                        $("#Pnl_Prueba3").hide();
                        $("#Pnl_Prueba4").hide();
                        $('#countdown').hide();
                    });
                    if ($("#m_timer").val() == 08) {
                        $("#m_timer").stop
                    }
                }
            });
        });
    </script>
</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <Control:Header ID="Header" runat="server" />
        <asp:Label runat="server" class="Leyendas" ID="LblDato"></asp:Label>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Panel ID="Pnl_Message" runat="server">
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                </asp:Panel>
                <article>
                    <asp:Panel ID="Pnl_DatosAspirante" Visible="false" runat="server">
                        <section>
                            <div id="Over" class="text-center Subtitulos">Datos del Aspirante</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Documento
                                        </div>
                                        <asp:TextBox ID="TxtDocAspActual" ReadOnly="true" TabIndex="1" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Label ID="Lbl_fkAspirante" ReadOnly="true" Visible="false" CssClass="form-control" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Nombres
                                        </div>
                                        <asp:TextBox ID="TxtNombresAspActual" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                    <asp:Panel ID="Pnl_IniciarPrueba" Visible="true" runat="server">
                        <section>
                            <div class="text-center Subtitulos">Seleccionar Aspirante</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <asp:RegularExpressionValidator Font-Size="10px" runat="server" ValidationGroup="Requerimientos" ControlToValidate="TxtConsultaDoc" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[0-9\s]{0,100}$">Solo Numeros</asp:RegularExpressionValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Documento
                                        </div>
                                        <asp:TextBox ID="TxtConsultaDoc" TabIndex="1" CssClass="form-control" runat="server" MaxLength="12"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <asp:LinkButton ID="BtnIniciarPrueba" TabIndex="2" ValidationGroup="Requerimientos" Font-Strikeout="false" CssClass="btn btn-crm Desplegar_Loading" runat="server">
                                    <span class="glyphicon glyphicon-star"></span> Ingresar Prueba
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                    <asp:Panel ID="Pnl_Prueba1" Visible="false" runat="server">
                        <section>
                            <asp:Label ID="Lbl_Registro_1" runat="server" Visible="false">1</asp:Label>
                            <div class="text-center Subtitulos">Prueba 1 </div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Código
                                        </div>
                                        <asp:TextBox ID="TxtCod_P1" TabIndex="1" Enabled="false" CssClass="form-control" runat="server" MaxLength="12"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Nombre</div>
                                        <asp:TextBox ID="TxtNombre_P1" TabIndex="3" Enabled="false" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Cedula</div>
                                        <asp:TextBox ID="TxtCedula_P1" TabIndex="5" Enabled="false" CssClass="form-control" runat="server" MaxLength="12" />
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Dirección</div>
                                        <asp:TextBox ID="TxtDireccion_P1" TabIndex="7" Enabled="false" CssClass="form-control" runat="server" MaxLength="12" />
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Correo Electrónico</div>
                                        <asp:TextBox ID="TxtEmail_P1" TabIndex="9" Enabled="false" CssClass="form-control" runat="server" MaxLength="60" />
                                    </div>
                                    <h4></h4>
                                    <h4></h4>
                                    <asp:LinkButton ID="Btn_Siguiente_P1" TabIndex="11" Enabled="false" Visible="false" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-chevron-right"></span> Siguiente
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="BtnComenzar" TabIndex="11" Visible="false" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-pencil"></span> Comenzar
                                    </asp:LinkButton>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Empresa
                                        </div>
                                        <asp:TextBox ID="TxtEmpresa_P1" TabIndex="2" Enabled="false" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Cargo
                                        </div>
                                        <asp:TextBox ID="TxtCargo_P1" TabIndex="4" Enabled="false" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Teléfono
                                        </div>
                                        <asp:TextBox ID="TxtTElefono_P1" TabIndex="6" Enabled="false" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Despacho
                                        </div>
                                        <asp:TextBox ID="TxtDespacho_P1" TabIndex="8" Enabled="false" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Nit
                                        </div>
                                        <asp:TextBox ID="TxtNit_P1" TabIndex="10" Enabled="false" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                    <asp:Panel ID="Pnl_Prueba2" Visible="false" runat="server">
                        <section>
                            <div class="text-center Subtitulos">Prueba 2</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Código
                                        </div>
                                        <asp:TextBox ID="TxtCod_P2" TabIndex="21" CssClass="form-control" runat="server" MaxLength="12"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Nombre</div>
                                        <asp:TextBox ID="TxtNombre_P2" TabIndex="23" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Cedula</div>
                                        <asp:TextBox ID="TxtCedula_P2" TabIndex="25" CssClass="form-control" runat="server" MaxLength="12" />
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Dirección</div>
                                        <asp:TextBox ID="TxtDireccion_P2" TabIndex="27" CssClass="form-control" runat="server" MaxLength="12" />
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Correo Electrónico</div>
                                        <asp:TextBox ID="TxtEmail_P2" TabIndex="29" CssClass="form-control" runat="server" MaxLength="60" />
                                    </div>
                                    <h4></h4>
                                    <asp:LinkButton ID="Btn_Siguiente_P2" TabIndex="31" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-chevron-right"></span> Prueba 3
                                    </asp:LinkButton>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Empresa
                                        </div>
                                        <asp:TextBox ID="TxtEmpresa_P2" TabIndex="22" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Cargo
                                        </div>
                                        <asp:TextBox ID="TxtCargo_P2" TabIndex="24" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Teléfono
                                        </div>
                                        <asp:TextBox ID="TxtTElefono_P2" TabIndex="26" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Despacho
                                        </div>
                                        <asp:TextBox ID="TxtDespacho_P2" TabIndex="28" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Nit
                                        </div>
                                        <asp:TextBox ID="TxtNit_P2" TabIndex="30" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                    <asp:Panel ID="Pnl_Prueba3" Visible="false" runat="server">
                        <section>
                            <div class="text-center Subtitulos">Prueba 3</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Código
                                        </div>
                                        <asp:TextBox ID="TxtCod_P3" TabIndex="39" CssClass="form-control" runat="server" MaxLength="12"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Nombre</div>
                                        <asp:TextBox ID="TxtNombre_P3" TabIndex="41" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Cedula</div>
                                        <asp:TextBox ID="TxtCedula_P3" TabIndex="43" CssClass="form-control" runat="server" MaxLength="12" />
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Dirección</div>
                                        <asp:TextBox ID="TxtDireccion_P3" TabIndex="45" CssClass="form-control" runat="server" MaxLength="12" />
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Correo Electrónico</div>
                                        <asp:TextBox ID="TxtEmail_P3" TabIndex="47" CssClass="form-control" runat="server" MaxLength="60" />
                                    </div>
                                    <h4></h4>
                                    <asp:LinkButton ID="Btn_Siguiente_P3" TabIndex="49" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-chevron-right"></span> Prueba 4
                                    </asp:LinkButton>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Empresa
                                        </div>
                                        <asp:TextBox ID="TxtEmpresa_P3" TabIndex="40" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Cargo
                                        </div>
                                        <asp:TextBox ID="TxtCargo_P3" TabIndex="42" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Teléfono
                                        </div>
                                        <asp:TextBox ID="TxtTElefono_P3" TabIndex="44" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Despacho
                                        </div>
                                        <asp:TextBox ID="TxtDespacho_P3" TabIndex="46" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Nit
                                        </div>
                                        <asp:TextBox ID="TxtNit_P3" TabIndex="48" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                    <asp:Panel ID="Pnl_Prueba4" Visible="false" runat="server">
                        <section>
                            <div class="text-center Subtitulos">Prueba 4</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Código
                                        </div>
                                        <asp:TextBox ID="TxtCod_P4" TabIndex="53" CssClass="form-control" runat="server" MaxLength="12"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Nombre</div>
                                        <asp:TextBox ID="TxtNombre_P4" TabIndex="55" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Cedula</div>
                                        <asp:TextBox ID="TxtCedula_P4" TabIndex="57" CssClass="form-control" runat="server" MaxLength="12" />
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Dirección</div>
                                        <asp:TextBox ID="TxtDireccion_P4" TabIndex="59" CssClass="form-control" runat="server" MaxLength="12" />
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Correo Electrónico</div>
                                        <asp:TextBox ID="TxtEmail_P4" TabIndex="61" CssClass="form-control" runat="server" MaxLength="60" />
                                    </div>
                                    <h4></h4>
                                    <asp:LinkButton ID="Btn_Siguiente_P4" TabIndex="63" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-chevron-right"></span> Prueba 5
                                    </asp:LinkButton>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Empresa
                                        </div>
                                        <asp:TextBox ID="TxtEmpresa_P4" TabIndex="54" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Cargo
                                        </div>
                                        <asp:TextBox ID="TxtCargo_P4" TabIndex="56" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Teléfono
                                        </div>
                                        <asp:TextBox ID="TxtTElefono_P4" TabIndex="58" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Despacho
                                        </div>
                                        <asp:TextBox ID="TxtDespacho_P4" TabIndex="60" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Nit
                                        </div>
                                        <asp:TextBox ID="TxtNit_P4" TabIndex="62" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                    <asp:Panel ID="Pnl_Prueba5" Visible="false" runat="server">
                        <section>
                            <div class="text-center Subtitulos">Prueba 5</div>
                            <div class="Form">
                                <div class="
                                    Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Código
                                        </div>
                                        <asp:TextBox ID="TxtCod_P5" TabIndex="71" CssClass="form-control" runat="server" MaxLength="12"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Nombre</div>
                                        <asp:TextBox ID="TxtNombre_P5" TabIndex="73" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Cedula</div>
                                        <asp:TextBox ID="TxtCedula_P5" TabIndex="75" CssClass="form-control" runat="server" MaxLength="12" />
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Dirección</div>
                                        <asp:TextBox ID="TxtDireccion_P5" TabIndex="77" CssClass="form-control" runat="server" MaxLength="12" />
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">Correo Electrónico</div>
                                        <asp:TextBox ID="TxtEmail_P5" TabIndex="79" CssClass="form-control" runat="server" MaxLength="60" />
                                    </div>
                                    <h4></h4>
                                    <asp:LinkButton ID="Btn_FinalizarPrueba" TabIndex="82" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-check"></span> Finalizar Prueba
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="Btn_Regresar" Visible="false" TabIndex="83" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-arrow-left"></span> Regresar
                                    </asp:LinkButton>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Empresa
                                        </div>
                                        <asp:TextBox ID="TxtEmpresa_P5" TabIndex="72" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Cargo
                                        </div>
                                        <asp:TextBox ID="TxtCargo_P5" TabIndex="74" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Teléfono
                                        </div>
                                        <asp:TextBox ID="TxtTElefono_P5" TabIndex="76" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Despacho
                                        </div>
                                        <asp:TextBox ID="TxtDespacho_P5" TabIndex="78" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                    <h4></h4>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            Nit
                                        </div>
                                        <asp:TextBox ID="TxtNit_P5" TabIndex="80" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                </article>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="BtnIniciarPrueba"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="Btn_FinalizarPrueba"></asp:PostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
        <asp:Label runat="server" ID="countdown"></asp:Label>
        <footer></footer>
    </form>
</body>
</html>
