<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Header.ascx.vb" Inherits="digitacion.Header" %>
<%--IMPORTAR ICONO--%>
<script type="text/javascript">
    $_$(document).ready(function () {
        var Header_Ico = document.createElement('link');
        Header_Ico.type = "image/x-icon";
        Header_Ico.rel="shortcut icon" 
        Header_Ico.href = Raiz + "favicon.ico";
        document.getElementsByTagName('head')[0].appendChild(Header_Ico);
    });
</script>
<%--####### Copyrigth © 2016 Area de Desarrollo, Crisitan Duarte C1477, Gerson Sanchez C1555 #######--%>
<header>
    <div class="Big-Title">Kamilion Comunicaciones ERP</div>    
    <asp:Menu ID="menugest" runat="server" StaticPopOutImageUrl="~/Css2/Imagenes/flecha.png" DynamicPopOutImageUrl="~/Css2/Imagenes/flecha.png" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="Small" Orientation="Horizontal" StaticSubMenuIndent="10px" StaticMenuStyle-CssClass ="Menu" StaticMenuItemStyle-CssClass="Celdas" StaticHoverStyle-CssClass="Celdas-Hover" DynamicMenuItemStyle-CssClass="Celdas" DynamicMenuStyle-CssClass="Fondo_Trans_Hover" DynamicHoverStyle-CssClass="Celdas-Hover" DynamicSelectedStyle-CssClass="Fondo_Trans_Hover" SkipLinkText="">
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicMenuStyle BackColor="transparent"/>
    </asp:Menu>
    <div class="Small-Title"><asp:Label runat="server" ID="Titulo_Formulario"></asp:Label></div>
    <div class="Credenciales">
        <asp:Label ID="Lbl_Usuario" runat="server"></asp:Label>
        <asp:Label ID="Lbl_Cod" runat="server"></asp:Label>
        <asp:Label ID="Lbl_Nombre" runat="server"></asp:Label>
        <asp:Label ID="Lbl_Perfil" runat="server"></asp:Label>
        <span>
            <asp:Label ID="Lbl_SuperVisor_Titulo" runat="server">Supervisor: </asp:Label>
            <asp:Label ID="Lbl_Supervisor" runat="server"></asp:Label>
        </span>
        <span>
            <asp:Label ID="Lbl_Jefe_Inmediato" runat="server"></asp:Label>
        </span>
        <span>
            <asp:Label ID="Lbl_Segmento" runat="server"></asp:Label>
        </span>
    </div>
</header>
<div id="DBtn_Show_Pop_Up"></div>
<div id="Pop_Up_Cas_Prog">
    <div>
        <div class="text-center Subtitulos">
            Tienes un caso programado
        </div>
        <div class="Form">
            <div class="input-group alert alert-danger" id="Ex_Pop_Up">
            </div>
            <div class="input-group">
                <div class="input-group-addon">
    	            Bandeja
                </div>
                <span id="Txt_Bandeja" class="form-control"></span>
            </div>
            <div class="input-group">
                <div class="input-group-addon">
    	            Código
                </div>
                <span id="Txt_Codigo" class="form-control"></span>
            </div>
            <div class="input-group">
                <div class="input-group-addon">
    	            Hora
                </div>
                <span id="Txt_Hora" class="form-control"></span>
            </div>
            <%--<div class="input-group">
                <div class="input-group-addon">
    	            Nombre Cliente
                </div>
                <span id="Txt_Cliente" class="form-control"></span>
            </div>--%>
            <button type="button" class="btn btn-primary" id="Btn_Ok">Resuelto</button>
            <button type="button" class="btn btn-primary" id="Btn_Hiden">Ocultar</button>
        </div>
    </div>
</div>
<div id="Desp_Loading" class="Desplegable"></div>
<%--####### Copyrigth © 2016 Area de Desarrollo, Crisitan Duarte C1477, Gerson Sanchez C1555 #######--%>