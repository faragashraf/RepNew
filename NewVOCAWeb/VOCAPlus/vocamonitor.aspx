<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="vocamonitor.aspx.vb" Inherits="VOCAPlus.vocamonitor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VOCA+ - Monitor</title>
        <style type="text/css">
.post-style {
            width: 300px;
            height: 100px;  
            margin-top:20px;
            margin-left:10px
            
        }
    .voca-style {
            width: 150px;
            height: 100px;  
            margin-top:20px;
            margin-right:10px
        }
         ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color:floralwhite;
            position: fixed;
            top: 0;
            width: 80%;
            margin-left:10%;
            margin-right:10%    
        }
          .main {
            margin-top: 270px;
            /*height: 1500px; /* Used in this example to enable scrolling */
            direction:rtl;
            width:80%;
            margin-left:10%;
            margin-right:10%;
            background-color:floralwhite;
            }
           .Live-Chat
{
     color :green;
     font-size:30px;
     font-family:'Calibri';
     /*padding:10px 20px;*/
     padding-top:80px;
     display:inline-block;
     /*margin:10px;*/
     text-decoration:none;
     	   }
	   .Blink-me{
		   animation-name: blinker;
           text-align:center;
           direction:rtl;
		   animation-duration:4s;
		   animation-timing-function:linear;
		   animation-iteration-count:infinite;
	   }
	   @keyframes blinker
	   {
		   0%{opacity: 1.0}
		   50%{opacity: 0.2}
		   100%{opacity: 1.0}
	   }
    </style>
     <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!--<link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">-->

    <link rel="stylesheet" href="css/animate.css"/>

    <link rel="stylesheet" href="css/owl.carousel.min.css"/>
    <link rel="stylesheet" href="css/owl.theme.default.min.css"/>
    <link rel="stylesheet" href="css/magnific-popup.css"/>

    <link rel="stylesheet" href="css/flaticon.css"/>
    <link rel="stylesheet" href="css/style.css"/>

</head>
      <body style="background-color:papayawhip">
  
    <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate >
     <div style="text-align:center;margin-top:30px; width: 100%;direction:ltr">
            <ul>
         <asp:Table ID="ChoseTabl" runat="server" VerticalAlign="top" HorizontalAlign="center"  Width="100%" Height="250px" BorderStyle="Solid" BorderWidth="7px" >

             <asp:TableRow VerticalAlign="top"   >
                    <asp:TableCell HorizontalAlign="LEFT" Width="33%"   Wrap="false" >
                        <img alt="" class="post-style"  src="images/post2.png" />        
                    </asp:TableCell>
                                     <asp:TableCell HorizontalAlign="center" Width="34%"   Wrap="false" >
                                                 <h1> <a class="Live-Chat" ><span class="Blink-me">The Last 100 Events Of VOCA Application</a></h1> 
                    </asp:TableCell>
                       <asp:TableCell HorizontalAlign="right" VerticalAlign="top" Width="30%"  Wrap="false" >
                        <img alt="" class="voca-style" src="images/VocaIcon2.ico"  />
             </asp:TableCell>

         </asp:TableRow>
            <asp:TableRow VerticalAlign="top" HorizontalAlign="center"  Height="30px">
                     <asp:TableCell HorizontalAlign="right" VerticalAlign="Top"  Wrap="false" Font-Size="X-Large">
                       <asp:Label ID="Label5" runat="server" word-wrap="normal"  ViewStateMode="Enabled" Width="200px" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" ForeColor="Black"></asp:Label>
                                                             
                    </asp:TableCell>
                      <asp:TableCell HorizontalAlign="center" VerticalAlign="Top"  Wrap="false"  Font-Size="X-Large" ColumnSpan="3" >
                     <asp:Label ID="Label1" runat="server" ViewStateMode="Enabled" Width="457px" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" ForeColor="Black">Retriving Duration:</asp:Label>          
                                                              
                    </asp:TableCell>
            </asp:TableRow>
                    </asp:Table>
                   </ul>
 </div>

<div class="main">
      <asp:Table ID="Table1" runat="server" VerticalAlign="top" HorizontalAlign="center" direction="ltr" Width="100%" Height="250px" BorderStyle="Solid"  >
             <asp:TableRow VerticalAlign="top" HorizontalAlign="center"  >
       <asp:TableCell HorizontalAlign="right" VerticalAlign="Top"  Width="90%" Wrap="true" Font-Size="X-Large">
         <asp:GridView ID="GridView1" runat="server" Font-Names="Times New Roman"  Font-Size="14pt" OnRowDataBound="OnRowDataBound" ForeColor="Black" BackColor="White" BorderColor="Black" BorderStyle="Solid" Height="12px" >
            <HeaderStyle Font-Bold="True" Font-Names="Times New Roman" Font-Size="16pt" Height="12px" HorizontalAlign="Center" />
            <RowStyle  HorizontalAlign="right" VerticalAlign="Middle" />
        </asp:GridView>                                               
                    </asp:TableCell>
                      <asp:TableCell HorizontalAlign="left" VerticalAlign="Top"  Wrap="true" Width="10%"  Font-Size="X-Large" >
                    <asp:Label ID="Label3" runat="server"  Font-Names="Times New Roman" Font-Size="X-Large" ForeColor="Black" direction="ltr" text-align="left" ></asp:Label>  
                                                              
                    </asp:TableCell>
            </asp:TableRow>
      </asp:Table>

    <div style =" width : 70%">

                </div>
        <div style="width:5%;">
          
       </div> 

    <asp:Label ID="Label2" runat="server" ViewStateMode="Enabled" Width="457px" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" ForeColor="#006600">
        ---------------------------------------------------------------------------------------------------
    </asp:Label>
</div>



 <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick"></asp:Timer>

 <%--<asp:Timer ID="Timer2" runat="server" Interval="5000" Enabled="False" OnTick="Timer2_Tick"></asp:Timer>--%>

                     </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                     <%--<asp:AsyncPostBackTrigger ControlID="GridView1" EventName="OnRowDataBound" />--%>
                </Triggers>
         </asp:UpdatePanel>

    </form>


 </body>
</html>
