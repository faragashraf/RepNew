<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VOCAULTIMATE.aspx.cs" Inherits="testvoca.WebForm1" %>

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

    <form id="form1" runat="server" class="container">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel class="container" ID="up1" runat="server">
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

                <div class="header">
                    <h1 class="overlay"></h1>
                </div>

                <!-- End Header -->

                <div id="log1" runat="server" class="login">
                    <div class="container">

                        <div style="text-align: center; font-size: larger" id="login" runat="server">
                            <div>
                                <asp:TextBox ID="TxtUsrNm" runat="server" Height="30px" Width="200px"></asp:TextBox>
                            </div>
                            <div>
                                <asp:TextBox ID="TxtUsrPass" runat="server" Height="30px" Width="200px" TextMode="Password"></asp:TextBox>
                                <br />
                                <asp:Button ID="LogInBtn" runat="server" OnClick="LogInBtn_Click" Text="Login" />
                                <asp:Button ID="Button2" runat="server" Text="Logiefen" />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
                <div runat="server" id="dvtree" class="login" style="direction: rtl; align-content: flex-start">
                    <asp:Label ID="LblLogin" runat="server" Font-Size="16pt"></asp:Label>
                    <asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="All" Visible="False" OnTreeNodeCollapsed="TreeView2_TreeNodeCheckChanged">
                        <SelectedNodeStyle ForeColor="Lime" />
                    </asp:TreeView>
                    <asp:TreeView ID="TreeView2" runat="server" ShowCheckBoxes="All"></asp:TreeView>

                    <div>
                        <asp:TextBox ID="txt1" runat="server" Font-Size="16pt"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                        <br />
                        <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                    </div>

                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="LogInBtn" EventName="click" />
                <asp:AsyncPostBackTrigger ControlID="Button2" EventName="click" />
            </Triggers>
        </asp:UpdatePanel>
    </form>

    <!-- End Login -->
    <script src="js/jquery-3.6.0.min.js"></script>
    <script src="js/jquery.nicescroll.min.js"></script>
    <script src="js/custom.js"></script>
</body>
</html>
