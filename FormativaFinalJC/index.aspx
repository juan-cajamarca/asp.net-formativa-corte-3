<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FormativaFinalJC.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Alquiler de Vehiculos<br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>Opción</asp:ListItem>
                <asp:ListItem>Vehiculos</asp:ListItem>
                <asp:ListItem>Alquiler</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:MultiView ID="MultiViewOptions" runat="server">
                <asp:View ID="ViewRental" runat="server">
                    <br />
                    Alquiler<br />
                    <br />
                    <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                        <asp:ListItem>Opciones</asp:ListItem>
                        <asp:ListItem>Alquilar</asp:ListItem>
                        <asp:ListItem>Mostrar</asp:ListItem>
                        <asp:ListItem>Eliminar</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:MultiView ID="MultiViewRental" runat="server">
                        <asp:View ID="ViewDeleteRental" runat="server">
                            <br />
                            Eliminar Alquiler<br />
                            <br />
                            <asp:DropDownList ID="DropDownList7" runat="server">
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:Button ID="ButtonDeleteRental" runat="server" OnClick="ButtonDeleteRental_Click" Text="Eliminar Alquiler" />
                            <br />
                        </asp:View>
                        <asp:View ID="ViewListRental" runat="server">
                            <br />
                            Lista de Alquiler<br />
                            <br />
                            <table class="auto-style1">
                                <tr>
                                    <td>Alquiler</td>
                                    <td>&nbsp;</td>
                                    <td>Vehiculos</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView2" runat="server">
                                        </asp:GridView>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:GridView ID="GridView3" runat="server">
                                        </asp:GridView>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="ViewCreateRental" runat="server">
                            <br />
                            Alquilar Vehiculo<br />
                            <br />
                            Cliente:
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            Vehiculo:
                            <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                            <br />
                            <br />
                            Precio:
                            <asp:TextBox ID="TextBox6" runat="server" TextMode="Number"></asp:TextBox>
                            <br />
                            <br />
                            Días:
                            <asp:TextBox ID="TextBox7" runat="server" TextMode="Number"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Alquilar" />
                        </asp:View>
                    </asp:MultiView>
                    <br />
                </asp:View>
                <asp:View ID="ViewCars" runat="server">
                    <br />
                    Vehiculos<br />
                    <br />
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        <asp:ListItem>Opciones</asp:ListItem>
                        <asp:ListItem>Registrar</asp:ListItem>
                        <asp:ListItem>Editar</asp:ListItem>
                        <asp:ListItem>Listar</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:MultiView ID="MultiViewCars" runat="server">
                        <asp:View ID="ViewListCars" runat="server">
                            <br />
                            Lista de Vehiculos<br />
                            <br />
                            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            </asp:GridView>
                            <br />
                        </asp:View>
                        <asp:View ID="ViewEditCars" runat="server">
                            <br />
                            Editar Vehiculos<br />
                            <br />
                            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />
                            <br />
                            Modelo:
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            Marca:
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="ButtonEditCar" runat="server" OnClick="ButtonEditCar_Click" Text="Editar Vehiculo" />
                            <br />
                            <br />
                        </asp:View>
                        <asp:View ID="ViewRegisterCars" runat="server">
                            <br />
                            Registrar Vehiculos<br />
                            <br />
                            Marca:
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            Modelo:
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="Number"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="ButtonCreate" runat="server" OnClick="ButtonCreate_Click1" Text="Crear" />
                            <br />
                        </asp:View>
                    </asp:MultiView>
                    <br />
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
