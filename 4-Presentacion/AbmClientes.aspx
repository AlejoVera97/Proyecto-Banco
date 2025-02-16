﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="AbmClientes.aspx.cs" Inherits="AbmClientes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 9px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    <em><strong>CLIENTES<br />
    <br />
    </strong></em>
    <table align="center" border="1" style="width: 74%;">
        <tr>
            <td class="style8" colspan="1">
                Numero:</td>
            <td colspan="4">
                <asp:TextBox ID="TxtNumero" runat="server"></asp:TextBox>
            </td>
            <td class="style9" colspan="1">
                <asp:Button ID="BtnBusco" runat="server" onclick="BtnBusco_Click" 
                    Text="Buscar" />
            &nbsp;<br />
                Si se quiere realizar un ALTA ingrese 0</td>
        </tr>
        <tr>
            <td class="style8" colspan="1">
                Nombre:</td>
            <td colspan="4">
                <asp:TextBox ID="TxtNombre" runat="server" Width="186px"></asp:TextBox>
            </td>
            <td class="style9" colspan="1">
            </td>
        </tr>
        <tr>
            <td class="style8" colspan="1">
                Direccion:</td>
            <td colspan="4">
                <asp:TextBox ID="TxtDireccion" runat="server" Width="186px"></asp:TextBox>
            </td>
            <td class="style9" colspan="1">
            </td>
        </tr>
        <tr>
            <td class="style8" colspan="1">
                Usuario:</td>
            <td colspan="4">
                <asp:TextBox ID="TxtUsuario" runat="server" Width="132px"></asp:TextBox>
            </td>
            <td class="style9" colspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8" colspan="1">
                Password:</td>
            <td colspan="4">
                <asp:TextBox ID="TxtPassword" runat="server" Width="132px" TextMode="Password"></asp:TextBox>
            </td>
            <td class="style9" colspan="1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" colspan="3">

                <strong>
                <br />
                <asp:TextBox ID="TxtTelefono" runat="server" Width="89px"></asp:TextBox>
                <br />
                <asp:Button ID="BtnAgregarTel" runat="server" onclick="BtnAgregarTel_Click" Text="Agregar Tel" Width="80px" />
                </strong>&nbsp;</td>
            <td class="style3" colspan="3">

                <strong>TELEFONOS</strong><br />
                <asp:ListBox ID="LbTelefonos" runat="server" Width="151px"></asp:ListBox>
&nbsp;<asp:Button ID="BtnBorrarTel" runat="server" onclick="BtnBorrarTel_Click" Text="Borrar Tel" Width="80px" />

            </td>
        </tr>
        <tr>
            <td class="style3" colspan="6">
                <asp:Label ID="LblError" runat="server" ForeColor="#FF3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td class="style1">
                <asp:Button ID="BtnAlta" runat="server" Enabled="False" onclick="BtnAlta_Click" 
                    Text="Alta" />
            </td>
            <td class="style1" colspan="2">
                <asp:Button ID="BtnBaja" runat="server" Enabled="False" onclick="BtnBaja_Click" 
                    Text="Baja" />
            </td>
            <td>
                <asp:Button ID="BtnModificar" runat="server" Enabled="False" 
                    onclick="BtnModificar_Click" Text="Modificar" />
            </td>
            <td class="style9">
                <asp:Button ID="BtnRefresh" runat="server" onclick="BtnRefresh_Click" 
                    Text="Limpiar Pantalla" />
            </td>
        </tr>
    </table>
    <p style="text-align: center">
        &nbsp;</p>
</p>
<br />
</asp:Content>

