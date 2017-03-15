<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RRHH_PruebaRegAsp.aspx.vb" Inherits="digitacion.RRHH_PruebaRegAsp" %>
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
    <link type="text/css"  rel="Stylesheet" href="~/Css2/Kamilion.css" />
</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <Control:Header ID="Header" runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Panel ID="Pnl_Message" runat="server">
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                </asp:Panel>
                <article>
                    <section>
                        <div class="text-center Subtitulos">Registrar Aspirante</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                  <asp:RegularExpressionValidator  Font-Size="10px" runat="server" ValidationGroup="Requerimientos" ControlToValidate="TxtDocumento" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[0-9\s]{0,100}$">Solo Numeros</asp:RegularExpressionValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Documento
                                    </div>
                                    <asp:TextBox ID="TxtDocumento" TabIndex="1" CssClass="form-control" runat="server" MaxLength="12"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Apellido</div>
                                    <asp:TextBox ID="TxtApellido" TabIndex="3" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                </div>                              
                                 <asp:RegularExpressionValidator Font-Size="10px" runat="server" ValidationGroup="Requerimientos" ControlToValidate="TxtNumCelular" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[0-9\s]{0,100}$">Solo Numeros</asp:RegularExpressionValidator>
                                 <div class="input-group">
                                    <div class="input-group-addon">Número Celular</div>
                                    <asp:TextBox ID="TxtNumCelular" TabIndex="5" CssClass="form-control" runat="server" MaxLength="12" />
                                </div>
                                <h4></h4>
                                <h4></h4>
                            <%--    <asp:Button ID="Btn_GuardarRegistro" ValidationGroup="Requerimientos" TabIndex="8" Font-Strikeout="false" CssClass="btn btn-crm Desplegar_Loading" runat="server">
                                </button>--%>

                                <asp:Button ID="Btn_GuardarRegistro" ValidationGroup="Requerimientos" TabIndex="8" Font-Strikeout="false" CssClass="btn btn-crm Desplegar_Loading" runat="server" Text="Guardar" />
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Nombre
                                    </div>
                                    <asp:TextBox ID="TxtNombre" TabIndex="2" CssClass="form-control" runat="server" MaxLength="60"></asp:TextBox>
                                </div>
                                        <asp:RegularExpressionValidator ID="TxtEmails" runat="server" Display="Dynamic" ValidationGroup="Requerimientos" ControlToValidate="TxtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                             
                                 <%--  <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationGroup="Requerimientos" ControlToValidate="TxtEmail" ErrorMessage="E-mail incorrecto"  SetFocusOnError="True" ValidationExpression="([A-Za-z0-9\.\-\w]{0,30})@([A-Za-z0-9]{0,20}).([A-Za-z]{0,5})"></asp:RegularExpressionValidator>--%>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Correo Electrónico
                                    </div>
                                    <asp:TextBox ID="TxtEmail" TabIndex="4" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </section>                    
              <section>
                  <h4></h4>
                        <div class="text-center Subtitulos">Consultar Aspirante</div>
                  <h4></h4>     
                   <div class="Form">
                       <h4></h4>     
                            <div class="Cell-Form">
                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationGroup="Requerimientos1" ControlToValidate="TxtConsultaDoc" ErrorMessage="Solo Numeros"  SetFocusOnError="True" ValidationExpression="^[0-9\s]{0,100}$"></asp:RegularExpressionValidator>
                                     <div class="input-group">
                                    <div class="input-group-addon">
                                        Documento
                                    </div>
                                    <asp:TextBox ID="TxtConsultaDoc" TabIndex="1" CssClass="form-control" runat="server" MaxLength="12"></asp:TextBox>
                                </div>                                                             
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <asp:LinkButton ID="BtnConsultarAsp" TabIndex="2" ValidationGroup="Requerimientos1" Font-Strikeout="false" CssClass="btn btn-crm Desplegar_Loading" runat="server">
                                    <span class="glyphicon glyphicon-search"></span> Consultar
                                </asp:LinkButton>
                            </div>
                        </div>
                    </section>                   
                                <asp:Panel runat="server" ID="Pnl_ConsTk">
                        <div class="Leyendas">
                            <asp:Label runat="server" ID="Lbl_Cantidad"></asp:Label>
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="Gtg_ConsultaAspirantes" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="true" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />                               
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                </article>
            </ContentTemplate>            
        </asp:UpdatePanel>
        <footer></footer>
    </form>
</body>
</html>
