<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RRHH_RegistroTicket.aspx.vb" Inherits="digitacion.RegistroTicketRH" %>

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
                      <div id="Desp_General" class="Desplegable">
            <div class="Dialog-Confirm">
                <div class="text-center Subtitulos">
                    <strong>ADVERTENCIA</strong>
                </div>
                   <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Label ForeColor="White" ID="Lbl_Msgdesp" runat="server" />
                        <div>
                            <%--<asp:Button runat="server" ID="Btn_Si" Text="SI" CssClass=" btn btn-primary" />--%>
                            <input type="button" id="Btn_No" value="OK" onclick="PlegDes_Dinamico('#Desp_General', 'slide', '', '', '');" class="btn btn-primary" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
                    <section>
                        <div class="text-center Subtitulos">Registro Solicitud</div>
                        <div class="Form">
                            <div class="Cell-Form">

                                <div class="input-group">
                                    <div class="input-group-addon">
                                        Tema
                                    </div>
                                    <asp:TextBox ID="TxtTema" TabIndex="1" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Área</div>
                                    <asp:DropDownList ID="Drl_Area" TabIndex="3" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <asp:RegularExpressionValidator Font-Size="10px" runat="server" ValidationGroup="Requerimientos" ControlToValidate="Txt_Requerimientos" Display="Dynamic" SetFocusOnError="True" ValidationExpression="^[\s\S]{0,600}$">Maximo 600 caracteres</asp:RegularExpressionValidator>
                                <div class="input-group">
                                    <div class="input-group-addon">Requerimientos</div>                             
                                    <asp:TextBox ID="Txt_Requerimientos" TabIndex="5" CssClass="form-control" TextMode="MultiLine" runat="server" MaxLength="599" />
                                </div>
                                <asp:LinkButton ID="Btn_GuardarRegistro" TabIndex="8" ValidationGroup="Requerimientos" Font-Strikeout="false" CssClass="btn btn-primary Desplegar_Loading" runat="server">
                                    <span class="glyphicon glyphicon-floppy-disk"></span> Guardar
                                </asp:LinkButton>
                                <asp:LinkButton ID="Btn_Limpiar" TabIndex="9" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-refresh"></span> Limpiar
                                </asp:LinkButton>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">                                       
                                        Prioridad
                                    </div>
                                    <asp:DropDownList ID="Drl_Prioridad" TabIndex="2" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Sector Gestión</div>
                                    <asp:DropDownList ID="Drl_Sector" TabIndex="4" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <%--Localizacion de la solicitud--%>
                                    <div class="input-group-addon">Localización Gestión</div>
                                    <asp:DropDownList ID="Drl_AreaGestion" TabIndex="6" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <%--Elemento de la solicitud--%>
                                <div class="input-group">
                                    <div class="input-group-addon">Elemento Gestión</div>
                                    <asp:DropDownList ID="Drl_ZonaGestion" TabIndex="7" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <asp:TextBox ID="TxtCodigo" Visible="false" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </section>
                    <asp:Panel runat="server" ID="Pnl_ConsTk">
                        <div class="Leyendas">                          
                             <asp:Label runat="server" ID="Lbl_Cantidad"></asp:Label>
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="Gtg_ConsultaTicketsParaImprimir" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="true" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                      <Columns>
                                    <asp:ButtonField CommandName="Imprimir" ControlStyle-Font-Size="10px" ControlStyle-Width="67px" ControlStyle-CssClass="btn btn-primary glyphicon-barcode" Text="Imprimir" ButtonType="Button" />
                                </Columns>
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
            <Triggers>
                <asp:PostBackTrigger ControlID="Gtg_ConsultaTicketsParaImprimir" />
            </Triggers>
        </asp:UpdatePanel>
        <footer></footer>
    </form>
</body>
</html>




