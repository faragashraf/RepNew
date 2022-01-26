<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="emam.aspx.cs" Inherits="testvoca.emam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <link rel="stylesheet" href="css/web.css" />
    <link rel="stylesheet" href="css/Normalize.css" />
</head>
<body>


    <!-- Start Login -->

    <form id="form1" runat="server" style="width: 90%; text-align: center; margin-left: 5%; margin-right: 5%">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>
                <!-- Start Navigation Bar-->
                <div class="navbar">
                    <div class="container">
                        <div class="brand">
                            <h2>VOCA Ultimate</h2>
                        </div>
                        <ul class="links">
                            <li><a href="#">Home</a></li>
                            <li><a href="#" data-value="log1">Login</a></li>
                        </ul>
                        <div class="usrlbl">
                            <asp:Label ID="lblusr" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>

                <!-- End Navigation Bar-->

                <!-- Start Header -->


                <!-- End Header -->


                <div id="login" style="text-align: center; font-size: larger;" runat="server">
                    <asp:TextBox ID="TxtUsrNm" runat="server" Height="30px" Width="200px"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="TxtUsrPass" runat="server" Height="30px" Width="200px" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="LogInBtn" runat="server" OnClick="LogInBtn_Click" Text="Login" />
                    <asp:Button ID="Button2" runat="server" Text="Logiefen" />
                    <br />
                </div>
                <div runat="server" id="dvtree" class="area">
                    <asp:Label ID="LblLogin" runat="server" Font-Size="16pt"></asp:Label>
                    <div class="area2">
                        <asp:TreeView ID="TreeView2" runat="server" ShowCheckBoxes="All"></asp:TreeView>
                        <asp:TextBox ID="txt1" runat="server" Font-Size="16pt"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                        <br />
                        <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>

                    </div>
                    <div class="area2">
                        <asp:GridView ID="GridTicket" runat="server" AllowPaging="True" ShowFooter="True" OnPreRender="GridTicket_PreRender" PageSize="3">
                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" PageButtonCount="3" />

                        </asp:GridView>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="LogInBtn" EventName="click" />
                <asp:AsyncPostBackTrigger ControlID="GridTicket" EventName ="PreRender" />
            </Triggers>
        </asp:UpdatePanel>
    </form>

    <!-- End Login -->
    <script src="js/jquery-3.6.0.min.js"></script>
    <script src="js/jquery.nicescroll.min.js"></script>
    <%--    <script src="js/custom.js"></script>--%>
</body>
</html>
