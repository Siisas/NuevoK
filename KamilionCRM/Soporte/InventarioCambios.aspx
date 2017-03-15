<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InventarioCambios.aspx.vb" Inherits="digitacion.InventarioCambios" %>

<%@ Register Src="~/Controles/Header.ascx" TagName="Header" TagPrefix="Control" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Kamilion CRM</title>
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
        <div id="Desp_Form_Desp" class="Desplegable">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="Dialog-Confirm">
                        <div class="text-center Subtitulos">
                            <span class='glyphicon glyphicon-warning-sign'></span> ADVERTENCIA!
                        </div>
                        <asp:Label ID="Lbl_Enun_Desp" runat ="server" ></asp:Label>
                        <asp:Panel ID="Pnl_Msg_Desp" runat="server">
                            <asp:Label ID="Lbl_Msg_Desp" runat="server"></asp:Label>
                        </asp:Panel>
                        <asp:RequiredFieldValidator runat="server" ID="RFV_Txb_Observacion" ValidationGroup="VG_Desp" Display="Dynamic" ControlToValidate="Txt_Desp">¡Observación obligatoria!</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="REV_Txb_Obs_Asignacion" ValidationGroup="VG_Desp" Display="Dynamic" ControlToValidate="Txt_Desp" ValidationExpression="^.{5,300}$">¡De 5 a 300 Caracteres! </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator runat="server" ID="RFV_Drl_Desp" ValidationGroup="VG_Desp" Display="Dynamic" InitialValue="" ControlToValidate="Drl_Desp">¡No ha elegido ninguna opción!</asp:RequiredFieldValidator>
                        <asp:TextBox ID="Txt_Desp" runat="server" TextMode="MultiLine" placeholder="Por favor ingrese un observación" CssClass="form-control" ></asp:TextBox>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="Drl_Desp"></asp:DropDownList>
                        <div>
                            <asp:Button runat="server" id="Btn_Confimr_Desp" ValidationGroup="VG_Desp" cssclass="btn btn-primary Desplegar_Loading" Text="Confirmar"/>
                            <asp:Button runat="server" id="Btn_Back_Desp" cssclass="btn btn-primary" Text="Cancelar"/>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="Desp_Loading" class="Desplegable"></div>
        <Control:Header ID="Header" runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Panel ID="Pnl_Message" runat="server">
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                </asp:Panel>
                <article>
                    <section>
                        <div class="text-center Subtitulos">MODULO</div>
                        <div class="text-center Sub-Subtitulo">Asignar</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Módulo</div>
                                    <asp:DropDownList ID="Drl_Modulo_AsigMod" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Área</div>
                                    <asp:DropDownList ID="Drl_Area_AsigMod" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <asp:Button ID="Btn_Asignar_Mod" Text="Asignar" CssClass="btn btn-primary Desplegar_Loading" runat="server" />
                                <asp:Button ID="Btn_Limpiar_AsigMod" Text="Limpiar" CssClass="btn btn-primary" runat="server" />
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Observación</div>
                                    <asp:TextBox ID="Txt_Observacion_AsigMod" runat="server" MaxLength="100" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="text-center Sub-Subtitulo">Liberar</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Módulo</div>
                                    <asp:DropDownList ID="Drl_Modulo_LibMod" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <asp:Button ID="Btn_Liberar_Mod" Text="Liberar" CssClass="btn btn-primary Desplegar_Loading" runat="server" />
                                <asp:Button ID="Btn_Limpiar_LibMod" Text="Limpiar" CssClass="btn btn-primary" runat="server" />
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Observación</div>
                                    <asp:TextBox ID="Txt_Observacion_LibMod" runat="server" MaxLength="100" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </section>
                    <section>
                        <div class="text-center Subtitulos">CONSULTAR INVENTARIO</div>
                        <div class="Form">
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Modulo</div>
                                    <asp:DropDownList ID="Drl_Modulo_ConsInv" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Codigo Inventario</div>
                                    <asp:TextBox ID="Txt_CodInv_ConsInv" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Estado</div>
                                    <asp:DropDownList ID="Drl_Estado_ConsInv" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <asp:Button ID="Btn_Consultar_Inventario" Text="Consultar" CssClass="btn btn-primary Desplegar_Loading" runat="server" />
                                <asp:Button ID="Btn_Limpiar_Cons" Text="Limpiar" CssClass="btn btn-primary" runat="server" />
                            </div>
                            <div class="Space-Form"></div>
                            <div class="Cell-Form">
                                <div class="input-group">
                                    <div class="input-group-addon">Dispositivo</div>
                                    <asp:DropDownList ID="Drl_Dispositivo_ConsInv"  runat="server" CssClass="form-control" />
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Serial</div>
                                    <asp:TextBox ID="Txt_Serial_ConsInv" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <div class="input-group-addon">Serial Kamilion</div>
                                    <asp:TextBox ID="Txt_SerialKam_ConsInv" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </section>
                    <asp:Panel ID="Pnl_Dtg_ConsInv" Visible="false" runat="server">
                        <div class="Leyendas ">
                            Número de registros:<asp:Label ID="Lbl_ConsInv" runat="server">0</asp:Label>
                        </div>
                        <div class="bordes">
                            <asp:GridView ID="Dtg_ConsInv" runat="server" AllowPaging="True"
                                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                                GridLines="None" PageSize="40" Width="100%" Style="font-size: x-small; text-align: center;"
                                EnableModelValidation="True">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="Cod_Inventario" HeaderText="Código Inventario" />
                                    <asp:BoundField DataField="Dispositivo" HeaderText="Tipo" />
                                    <asp:BoundField DataField="Marca" HeaderText="Marca" />
                                    <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                                    <asp:BoundField DataField="Serial" HeaderText="Serial" />
                                    <asp:BoundField DataField="Serial_Kamilion" HeaderText="Serial Kamilion" />
                                    <asp:BoundField DataField="Empresa" HeaderText="Empresa" />
                                    <asp:BoundField DataField="Area" HeaderText="Área" />
                                    <asp:BoundField DataField="Modulo" HeaderText="Modulo" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                    <asp:BoundField DataField="Id_Usuario" HeaderText="Usuario Registra" />
                                    <asp:BoundField DataField="FcReg_Invent" HeaderText="Fecha Registro" />
                                    <asp:ButtonField ItemStyle-Width="6%" HeaderText="Asignar" ButtonType="Link" ControlStyle-CssClass="btn btn-primary glyphicon glyphicon-wrench Desplegar_Loading" ControlStyle-Font-Strikeout="false" ControlStyle-Height="25px" ControlStyle-Font-Size="12px" ControlStyle-ForeColor="White" CommandName="Asignar" />
                                    <asp:ButtonField ItemStyle-Width="6%" HeaderText="Liberar" ButtonType="Link" ControlStyle-CssClass="btn btn-primary glyphicon glyphicon-wrench Desplegar_Loading" ControlStyle-Font-Strikeout="false" ControlStyle-Height="25px" ControlStyle-Font-Size="12px" ControlStyle-ForeColor="White" CommandName="Liberar" />
                                    <asp:ButtonField ItemStyle-Width="6%" HeaderText="Registrar Gestión" ButtonType="Link" ControlStyle-CssClass="btn btn-primary glyphicon glyphicon-wrench Desplegar_Loading" ControlStyle-Font-Strikeout="false" ControlStyle-Height="25px" ControlStyle-Font-Size="12px" ControlStyle-ForeColor="White" CommandName="Registrar_Gestion" />
                                    <asp:ButtonField ItemStyle-Width="6%" HeaderText="Ver Gestiones y Movimientos" ButtonType="Link" ControlStyle-CssClass="btn btn-primary glyphicon glyphicon-eye-open Desplegar_Loading" ControlStyle-Font-Strikeout="false" ControlStyle-Height="25px" ControlStyle-Font-Size="12px" ControlStyle-ForeColor="White" CommandName="Ver_GestionesMovimientos" />
                                </Columns>
                                <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <asp:Panel ID="Pnl_Dtg_ConsGestMov" Visible="false" runat="server">
                            <div class="Leyendas ">
                                Cod Inventario:
                                <asp:Label ID="Lbl_ConsCodInv" runat="server"></asp:Label>
                            </div>
                            <div style="display: table; width: 100%">
                                <div style="display: table-cell; width: 49%;">
                                    <div class="Leyendas ">
                                        Número de Movimientos:<asp:Label ID="Lbl_ConsMov" runat="server">0</asp:Label>
                                    </div>
                                    <div class="bordes">
                                        <asp:GridView ID="Dtg_ConsMov" runat="server" AllowPaging="True"
                                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                                            GridLines="None" PageSize="20" Width="100%" Style="font-size: x-small; text-align: center;"
                                            EnableModelValidation="True">
                                            <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                            <Columns>
                                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                                <asp:BoundField DataField="Fk_Id_Modulo_Id_Inv_Mod" HeaderText="Módulo" />
                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                                <asp:BoundField DataField="Observacion" HeaderText="Observacion" />
                                            </Columns>
                                            <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#B3C556" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#B3C556" Font-Bold="False" ForeColor="White" Font-Size="Small" />
                                            <EditRowStyle BackColor="#999999" />
                                            <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div style="display: table-cell; width: 2%;"></div>
                                <div style="display: table-cell; width: 49%;">
                                    <div class="Leyendas ">
                                        Número de gestiones:<asp:Label ID="Lbl_ConsGest" runat="server">0</asp:Label>
                                    </div>
                                    <div class="bordes">
                                        <asp:GridView ID="Dtg_ConsGest" runat="server" AllowPaging="True"
                                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
                                            GridLines="None" PageSize="20" Width="100%" Style="font-size: x-small; text-align: center;"
                                            EnableModelValidation="True">
                                            <RowStyle BackColor="#EEF1D8" ForeColor="#333333" />
                                            <Columns>
                                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                <asp:BoundField DataField="Observacion" HeaderText="Observacion" />
                                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                            </Columns>
                                            <FooterStyle BackColor="#B3C556" Font-Bold="True" ForeColor="White" />
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
                    </asp:Panel>
                </article>
                <footer></footer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
