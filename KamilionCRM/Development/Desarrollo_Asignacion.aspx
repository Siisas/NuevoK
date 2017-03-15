<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Desarrollo_Asignacion.aspx.vb" Inherits="digitacion.Desarrollo_Asignacion" %>

<%@ Register Src="~/Controles/Header.ascx" TagName="Header" TagPrefix="Control" %>
<!DOCTYPE html>

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
                    <%--- Seccion de Consulta ---%>
                    <asp:Panel ID="PnlFiltros" Visible="true" runat="server">
                        <section>
                            <div class="text-center Subtitulos">Filtros de Consulta</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <asp:RegularExpressionValidator Font-Size="10px" runat="server" ControlToValidate="Txt_Cons_Codigo" Display="Dynamic" SetFocusOnError="True" ValidationExpression="((DES)?(DES)?)*([0-9]{4,4})*">Codigo mal escrito, Ejemplo(DES0000)</asp:RegularExpressionValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Código</div>
                                        <asp:TextBox ID="Txt_Cons_Codigo" TabIndex="1" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                    </div>
                                    <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="Txt_Fc_Inicio" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha inicio incorrecta, verifique!!</asp:RangeValidator>
                                    <asp:RangeValidator runat="server" Font-Size="10px" ControlToValidate="Txt_Fc_Fin" SetFocusOnError="True" Display="Dynamic" Type="Date" MinimumValue="01/01/2016" MaximumValue="31/12/3000">Fecha fin incorrecta, verifique!!</asp:RangeValidator>
                                    <div class="input-group">
                                        <div class="input-group-addon">Fecha Final</div>
                                        <asp:TextBox ID="Txt_Fc_Inicio" TabIndex="3" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                        <div class="input-group-addon">-</div>
                                        <asp:TextBox ID="Txt_Fc_Fin" TabIndex="4" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                    </div>
                                    <asp:LinkButton ID="Btn_Filtrar" TabIndex="5" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span> Filtrar
                                    </asp:LinkButton>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Prioridad</div>
                                        <asp:DropDownList ID="Drl_Cons_Prioridad" TabIndex="2" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                    <asp:Panel ID="PnlAsignar" Visible="false" runat="server">
                        <section>
                            <div class="text-center Subtitulos">Asignar Desarrollos</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    

                                    <div class="input-group">
                                        <div class="input-group-addon">Código</div>
                                        <asp:TextBox ID="Txt_Codigo" ReadOnly="true"  CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Requerimientos</div>
                                        <asp:TextBox ID="Txt_Requerimientos" ReadOnly="true" TextMode="MultiLine" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                    </div>

                                    <asp:LinkButton ID="Btn_Asignar" TabIndex="12" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-share"></span> Asignar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="Btn_Cancelar"  TabIndex="13" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-arrow-left"></span> Volver
                                    </asp:LinkButton>
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Tema</div>
                                        <asp:TextBox ID="Txt_Tema" ReadOnly="true" TabIndex="2" CssClass="form-control" runat="server" MaxLength="7"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Desarrollador</div>
                                        <asp:DropDownList ID="Drl_Desarrollador" TabIndex="11" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                    <div class="Leyendas">
                        <asp:Label runat="server" ID="Lbl_Cantidad"></asp:Label>
                    </div>
                    <div class="bordes">
                        <asp:GridView ID="Dtg_Desarrollos" PageSize="20" runat="server" AllowPaging="true" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                            <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                            <Columns>
                                <asp:BoundField DataField="Reg_Cod" HeaderText="Codigo" />
                                <asp:BoundField DataField="Reg_Fch" HeaderText="Fecha Registro" />
                                <asp:BoundField DataField="Reg_Usu_Reg" HeaderText="Usuario Registra" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                <asp:BoundField DataField="Reg_Tem" HeaderText="Tema" />
                                <asp:BoundField DataField="Reg_Pri" HeaderText="Prioridad" />
                                <asp:BoundField DataField="Area" HeaderText="Area" />
                                <asp:BoundField DataField="Reg_Req" HeaderText="Requerimientos" />
                                <asp:ButtonField ButtonType="Link" ControlStyle-CssClass="btn btn-primary  glyphicon glyphicon-eye-open" ControlStyle-Height="25px" ControlStyle-Font-Size="12px" ControlStyle-ForeColor="White" CommandName="Seleccionar" />
                            </Columns>
                            <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </article>
            </ContentTemplate>
        </asp:UpdatePanel>
        <footer></footer>
    </form>
</body>
</html>








