<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="PassGen.Password" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <table>
                <caption>Password Generator</caption>
                <thead>
                    <tr>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th>
                            <asp:Label runat="server" ID="lblUserID" Text="UserID: "></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox runat="server" ID="txtUserID"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label runat="server" ID="lblDateTime" Text="DateTime: "></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox runat="server" ID="txtDateTime"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <td>
                            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <td>
                            <asp:Button runat="server" ID="btnPickDate" Text="Pick Date" OnClick="btnPickDate_Click" />
                        </td>
                    </tr>
                    <tr>
                        <th></th>
                        <td>
                            <asp:Button runat="server" ID="btnGeneratePassword" OnClick="btnGeneratePassword_Click" OnClientClick="F2();" Text="Generate password" />
                            <asp:Label runat="server" ID="lblRFV" Text="Please fill in all the inputs" ForeColor="Red" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th><asp:Label runat="server" ID="lblpsw" Text="Password: "></asp:Label></th>
                        <td>
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="1000">
                            </asp:Timer>
                            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <asp:Label runat="server" ID="lblPassword"></asp:Label>
                                    <br />
                                    <asp:Literal ID="litmsg" runat="server"></asp:Literal>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
