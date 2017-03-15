<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Productividad.aspx.vb" Inherits="digitacion.Productividad" %>
<%@ Register src="~/Controles/Header.ascx" tagname="Header" tagprefix="Control" %>

<!DOCTYPE html>
<%--	© 2016 Crisitan Duarte C1477	--%>
<html>
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Productividad | Kamilion ERP</title>
        <link rel="icon" href="~/favicon.ico" type="image/x-icon"/>              
        <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon"/>     
        <script type="text/javascript" src="../Css2/jquery.min.js"></script>
        <script type="text/javascript" src="../Css2/jquery-ui.min.js"></script>
        <script type="text/javascript" src="../Css2/jquery-ui-timepiker.js"></script>
        <script type="text/javascript" src="../Css2/scripts.js"></script>
        <!--#########Estilos############-->
        <link type="text/css" rel="Stylesheet" href="~/Css2/Boot/css/bootstrap.min.css"/>   
        <link type="text/css" rel="Stylesheet" href="~/Css2/jquery-ui.css"/>   
        <link type="text/css" rel="Stylesheet" href="~/Css2/Kamilion.css"/>
        <style>
            .bordes ::-webkit-scrollbar {
                width: 8px;
            }
        </style>
    </head>
    <body>
        <form runat="server">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <Control:Header ID="Header" runat="server"/>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Panel id="Pnl_Message" runat="server">
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <article>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                    <asp:Panel ID="Pnl_Filtros" Visible="true" runat="server">
                        <section>
                            <div class="text-center Subtitulos">Filtrar Consulta</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Fecha</div>
                                        <asp:TextBox ID="Txt_Fecha" CssClass="form-control Fecha" Placeholder="DD/MM/YYYY" MaxLength="10" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Campaña</div>
                                        <asp:DropDownList ID="Drl_Campaña" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Turno</div>
                                        <asp:DropDownList ID="Drl_Turno" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <asp:Button ID="Btn_Filtrar" Text="Filtrar" CssClass="btn btn-primary Desplegar_Loading" runat="server" />&nbsp;
                                    <asp:Button ID="Btn_Exportar1" Text="Exportar" CssClass="btn btn-primary" runat="server" />
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Jefe Inmediato</div>
                                        <asp:DropDownList ID="Drl_JefeInmediato" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Codigo Agente</div>
                                        <asp:TextBox ID="Txt_Cod_Agente" MaxLength="5" CssClass="form-control" runat="server" />
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Contar Asignados</div>
                                        <asp:CheckBox ID="Chk_Asig" Text="SI" Checked="true" AutoPostBack="true" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </section>
                    </asp:Panel>
                    <asp:Panel ID="Pnl_Info" Visible="false" runat="server">
                        <section>
                            <div class="text-center Subtitulos">Informacion del Agente</div>
                            <div class="Form">
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Codigo</div>
                                        <asp:Label ID="Lbl_Cod" CssClass="form-control" style="background-color:inherit" runat="server"></asp:Label>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Turno</div>
                                        <asp:Label ID="Lbl_Turno" CssClass="form-control" style="background-color:inherit" runat="server"></asp:Label>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Campaña</div>
                                        <asp:Label ID="Lbl_Campaña" CssClass="form-control" style="background-color:inherit" runat="server"></asp:Label>
                                    </div>
                                    <asp:Button ID="Btn_Volver" Text="Volver" CssClass="btn btn-primary Desplegar_Loading" runat="server" />&nbsp;
                                    <asp:Button ID="Btn_Exportar2" Text="Exportar" CssClass="btn btn-primary" runat="server" />
                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Nombre</div>
                                        <asp:Label ID="Lbl_Nombre" CssClass="form-control" style="background-color:inherit" runat="server"></asp:Label>
                                    </div>
                                    <div class="input-group">
                                        <div class="input-group-addon">Jefe Inmediato</div>
                                        <asp:Label ID="Lbl_Jefe" CssClass="form-control" style="background-color:inherit" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div><br />
                            <div class="bordes">
                                <asp:GridView ID="Dtg_Campañas" runat="server" CellPadding="4" AllowPaging="false" ForeColor="#333333" AutoGenerateColumns="True" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                    <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                </asp:GridView>
                            </div>
                            <br />
                            <div class="bordes">
                                <asp:GridView ID="Dtg_Detalle" runat="server" CellPadding="4" AllowPaging="false" ForeColor="#333333" AutoGenerateColumns="True" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="True">
                                    <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                    <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                </asp:GridView>
                            </div>
                        </section>
                    </asp:Panel>
                    <asp:Panel ID="Pnl_Dtg_Productividad" Visible="false" runat="server">
                        <div class="Leyendas">
                            <asp:Label ID="Lbl_Cantidad" runat="server" />
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="Dtg_Total_Horas" runat="server" AllowPaging="False"
                                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                                GridLines="None" Width="100%" Style="font-size: x-small;"
                                EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="0" HeaderText="0" />
                                    <asp:BoundField DataField="1" HeaderText="1" />
                                    <asp:BoundField DataField="2" HeaderText="2" />
                                    <asp:BoundField DataField="3" HeaderText="3" />
                                    <asp:BoundField DataField="4" HeaderText="4" />
                                    <asp:BoundField DataField="5" HeaderText="5" />
                                    <asp:BoundField DataField="6" HeaderText="6" />
                                    <asp:BoundField DataField="7" HeaderText="7" />
                                    <asp:BoundField DataField="8" HeaderText="8" />
                                    <asp:BoundField DataField="9" HeaderText="9" />
                                    <asp:BoundField DataField="10" HeaderText="10" />
                                    <asp:BoundField DataField="11" HeaderText="11" />
                                    <asp:BoundField DataField="12" HeaderText="12" />
                                    <asp:BoundField DataField="13" HeaderText="13" />
                                    <asp:BoundField DataField="14" HeaderText="14" />
                                    <asp:BoundField DataField="15" HeaderText="15" />
                                    <asp:BoundField DataField="16" HeaderText="16" />
                                    <asp:BoundField DataField="17" HeaderText="17" />
                                    <asp:BoundField DataField="18" HeaderText="18" />
                                    <asp:BoundField DataField="19" HeaderText="19" />
                                    <asp:BoundField DataField="20" HeaderText="20" />
                                    <asp:BoundField DataField="21" HeaderText="21" />
                                    <asp:BoundField DataField="22" HeaderText="22" />
                                    <asp:BoundField DataField="23" HeaderText="23" />
                                    <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Size="10px" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div><br />
                        <div class="bordes">
                            <div class="input-group" style="width:100%">
                                <div style="background-color: #B3C556; height: 37px; width: 99.5%; margin: 0; padding: 0;">
                                    <table id="tblHeader" runat="server" style="background-color: #B3C556; color: White; font-size: 11px; width: 100%; height: 100%;">
                                        <tr>
                                            <td style="width: 4%; text-align: left;">Turno</td>
                                            <td style="width: 4%; text-align: left;">Codigo</td>
                                            <td style="width: 13%; text-align: center;">Agente</td>
                                            <td style="width: 10%; text-align: left;">Campaña</td>
                                            <td style="width: 2%; text-align: left;">0</td>
                                            <td style="width: 2%; text-align: left;">1</td>
                                            <td style="width: 2%; text-align: left;">2</td>
                                            <td style="width: 2%; text-align: left;">3</td>
                                            <td style="width: 2%; text-align: left;">4</td>
                                            <td style="width: 2%; text-align: left;">5</td>
                                            <td style="width: 2%; text-align: left;">6</td>
                                            <td style="width: 2%; text-align: left;">7</td>
                                            <td style="width: 2%; text-align: left;">8</td>
                                            <td style="width: 2%; text-align: left;">9</td>
                                            <td style="width: 2.5%; text-align: left;">11</td>
                                            <td style="width: 2.5%; text-align: left;">12</td>
                                            <td style="width: 2.5%; text-align: left;">13</td>
                                            <td style="width: 2.5%; text-align: left;">14</td>
                                            <td style="width: 2.5%; text-align: left;">10</td>
                                            <td style="width: 2.5%; text-align: left;">15</td>
                                            <td style="width: 2.5%; text-align: left;">16</td>
                                            <td style="width: 2.5%; text-align: left;">17</td>
                                            <td style="width: 2.5%; text-align: left;">18</td>
                                            <td style="width: 2.5%; text-align: left;">19</td>
                                            <td style="width: 2.5%; text-align: left;">20</td>
                                            <td style="width: 2.5%; text-align: left;">21</td>
                                            <td style="width: 2.5%; text-align: left;">22</td>
                                            <td style="width: 2.5%; text-align: left;">23</td>
                                            <td style="width: 4%; text-align: left;">TOTAL</td>
                                            <td style="width: 6%; text-align: left;">NO EFEC</td>
                                            <td style="width: 25px; text-align: left;"></td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="overflow: auto; width: 100%; min-height: 0px; max-height: 400px;">
                                    <asp:GridView ID="Dtg_Productividad" runat="server" AllowPaging="False"
                                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                                        GridLines="none" Width="100%" Style="font-size: x-small"
                                        EnableModelValidation="True" ShowHeader="false" ShowFooter="false">
                                        <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="4%" DataField="Horario" HeaderText="Turno" />
                                            <asp:BoundField ItemStyle-Width="4%" DataField="Codigo" HeaderText="Codigo" />
                                            <asp:BoundField ItemStyle-Width="13%" DataField="Nombre" HeaderText="Agente" />
                                            <asp:BoundField ItemStyle-Width="10%" DataField="Campaña" HeaderText="Campaña" />
                                            <asp:BoundField ItemStyle-Width="2%" DataField="0" HeaderText="0" />
                                            <asp:BoundField ItemStyle-Width="2%" DataField="1" HeaderText="1" />
                                            <asp:BoundField ItemStyle-Width="2%" DataField="2" HeaderText="2" />
                                            <asp:BoundField ItemStyle-Width="2%" DataField="3" HeaderText="3" />
                                            <asp:BoundField ItemStyle-Width="2%" DataField="4" HeaderText="4" />
                                            <asp:BoundField ItemStyle-Width="2%" DataField="5" HeaderText="5" />
                                            <asp:BoundField ItemStyle-Width="2%" DataField="6" HeaderText="6" />
                                            <asp:BoundField ItemStyle-Width="2%" DataField="7" HeaderText="7" />
                                            <asp:BoundField ItemStyle-Width="2%" DataField="8" HeaderText="8" />
                                            <asp:BoundField ItemStyle-Width="2%" DataField="9" HeaderText="9" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="10" HeaderText="10" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="11" HeaderText="11" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="12" HeaderText="12" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="13" HeaderText="13" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="14" HeaderText="14" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="15" HeaderText="15" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="16" HeaderText="16" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="17" HeaderText="17" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="18" HeaderText="18" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="19" HeaderText="19" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="20" HeaderText="20" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="21" HeaderText="21" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="22" HeaderText="22" />
                                            <asp:BoundField ItemStyle-Width="2.5%" DataField="23" HeaderText="23" />
                                            <asp:BoundField ItemStyle-Width="4%" DataField="TOTAL" HeaderText="TOTAL" />
                                            <asp:BoundField ItemStyle-Width="6%" DataField="NO EFECTIVOS" HeaderText="NO EFEC" />
                                            <asp:ButtonField ItemStyle-Width="25px" ButtonType="Link" ControlStyle-CssClass="btn btn-primary  glyphicon glyphicon-eye-open Desplegar_Loading" ControlStyle-Height="25px" ControlStyle-Font-Size="12px" ControlStyle-ForeColor="White" CommandName="Seleccionar" />
                                        </Columns>
                                        <FooterStyle BackColor="#B3C556" Font-Size="10px" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Btn_Exportar1" />
                        <asp:PostBackTrigger ControlID="Btn_Exportar2" />
                    </Triggers>
                </asp:UpdatePanel>
            </article>
            <footer></footer>
        </form>
    </body>
</html>
<%--	© 2016 Crisitan Duarte C1477	--%>