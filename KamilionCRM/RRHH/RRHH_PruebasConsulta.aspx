<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RRHH_PruebasConsulta.aspx.vb" Inherits="digitacion.RRHH_PruebasConsulta" %>
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
                    <section>
                        <div class="text-center Subtitulos">Consultas</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationGroup="Requerimientos" ControlToValidate="TxtConsultaDoc" ErrorMessage="Solo Numeros"  SetFocusOnError="True" ValidationExpression="^[0-9\s]{0,100}$"></asp:RegularExpressionValidator>
                                 <div class="input-group">
                                    <div class="input-group-addon">
                                        Documento
                                    </div>
                                    <asp:TextBox ID="TxtConsultaDoc" TabIndex="1" CssClass="form-control" runat="server" MaxLength="12"></asp:TextBox>
                                </div>
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <asp:LinkButton ID="BtnConsultarAsp" ValidationGroup="Requerimientos" TabIndex="2" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-search"></span> Consultar
                                </asp:LinkButton>
                            </div>
                        </div>
                        <asp:Panel runat="server" ID="Pnl_ConsTk">
                            <div class="Leyendas">
                                <asp:Label runat="server" ID="Lbl_Cantidad"></asp:Label>
                            </div>
                            <div class="bordes">
                                <asp:GridView ID="Gtg_ConsultaResultados" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                    <Columns>
                                        <asp:BoundField DataField="Fecha de Prueba" HeaderText="Fecha de Prueba" />
                                        <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                        <asp:BoundField DataField="Puntaje Total" HeaderText="Puntaje Total" />
                                        <asp:ButtonField ButtonType="Link" runat="server" ControlStyle-CssClass="btn btn-primary  glyphicon glyphicon-user" ControlStyle-Height="25px" ControlStyle-Font-Size="12px" ControlStyle-ForeColor="White" CommandName="Seleccionar" />
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
                    </section>
                    <asp:Panel runat="server" ID="Pnl_ConsTk1">
                        <div class="Leyendas">
                            <asp:Label runat="server" ID="LblCantidad1"></asp:Label>
                        </div>
                        <div class="bordes" > <div class="bordes" style="overflow:auto; min-height:0px;max-height:180px; width:100%;">                             
                            <asp:GridView ID="Gtg_ConsultaPruebas"  runat="server" AllowPaging="false" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>
                                    <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                    <asp:BoundField DataField="Fecha y Hora" HeaderText="Fecha y Hora" />
                                    <asp:BoundField DataField="Numero de Prueba" HeaderText="Prueba" />                                                                     
                                    <asp:BoundField DataField="Puntaje" HeaderText="Puntaje" />
                                    <asp:BoundField DataField="Codigo" HeaderText="Código" />
                                    <asp:BoundField DataField="Empresa" HeaderText="Empresa" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                                    <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                                    <asp:BoundField DataField="Telefono" HeaderText="Télefono" />
                                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                                    <asp:BoundField DataField="Despacho" HeaderText="Despacho" />
                                    <asp:BoundField DataField="Email" HeaderText="Correo Electrónico" />
                                    <asp:BoundField DataField="Nit" HeaderText="Nit" />
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
                      <asp:Panel runat="server" ID="Pnl_ConsTk2">
                       <h4></h4>
                          <section>
                                <div class="Form">
                            <div class="Cell-Form">
                       <h4></h4>
                                        <asp:LinkButton ID="Comparar" ValidationGroup="Requerimientos" Visible="false" TabIndex="2" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                    <span class="glyphicon glyphicon-search"></span> Comparar
                                </asp:LinkButton>
                            </div>                                                 
                        </div>
                          </section>
                          <asp:Panel id="Pnl_Versus" Visible="false" runat="server">
                       <div class="Leyendas">
                            <asp:Label runat="server" ID="LblCantidad2"></asp:Label>
                        </div>
                              <div class="bordes">
                            <asp:GridView ID="Gtg_ConsultaPruebasADigitar"  PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                                <Columns>                            
                                    <asp:BoundField DataField="Numero de Prueba"  HeaderText="Prueba" />
                                    <asp:BoundField DataField="Codigo" HeaderText="Código" />
                                    <asp:BoundField DataField="Empresa" HeaderText="Empresa" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                                    <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                                    <asp:BoundField DataField="Telefono" HeaderText="Télefono" />
                                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                                    <asp:BoundField DataField="Despacho" HeaderText="Despacho" />
                                    <asp:BoundField DataField="Email" HeaderText="Correo Electrónico" />
                                    <asp:BoundField DataField="Nit" HeaderText="Nit" />
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
                    </asp:Panel>
                </article>
            </ContentTemplate>
        </asp:UpdatePanel>
        <footer></footer>
    </form>
</body>
</html>
