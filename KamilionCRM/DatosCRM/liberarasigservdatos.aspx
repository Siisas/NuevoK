<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="liberarasigservdatos.aspx.vb"
    Inherits="digitacion.liberarasigservdatos" %>

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
                   
                        <section>
                            <div class="text-center Subtitulos">Filtros de Consulta</div>
                            <div class="Form">
                                <div class="Cell-Form">                                
                                 
                                    <div class="input-group">
                                        <div class="input-group-addon">Digitador Asignado</div>
                                        <asp:DropDownList ID="drlusuario" AutoPostBack="True" TabIndex="6" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <asp:LinkButton ID="btnliberar" TabIndex="8" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span> Buscar
                                    </asp:LinkButton>
                                    <asp:LinkButton  ID="btnguardar" TabIndex="9" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-check"></span> Liberar
                                    </asp:LinkButton>

                                </div>
                                <div class="Space-Form"></div>
                                <div class="Cell-Form">
                             
                                </div>
                            </div>
                        </section>            
                    <%-- Seccion de Grillas--%>                        

                        <div class="Leyendas">
                            <asp:Label runat="server" ID="lblcantidad"></asp:Label>
                        </div>
                        <div class="bordes" style="overflow: auto; min-height: 0px; max-height: 450px; width: 100%;">
                            <asp:GridView ID="dtggeneral" runat="server" AllowPaging="false" AutoGenerateColumns="false" CellPadding="5" ForeColor="#333333" GridLines="None" Width="100%" Style="font-size: x-small" EnableModelValidation="false">
                                <RowStyle BackColor="#EEF1D8" ForeColor="#333333" Font-Bold="true" />
                               <Columns>
                        <asp:BoundField DataField="idcaso" HeaderText="Caso" />
                        <asp:BoundField DataField="idusuarioasigna" HeaderText="Usuario Asigna" />
                        <asp:BoundField DataField="fcasignado" HeaderText="Fecha Asignado" />
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
