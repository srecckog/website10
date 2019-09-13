<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    
       <link href="DigStyle0.css" rel="stylesheet" type="text/css" /> 
</head>
 <body style="background-color:#000000">

    <form id="form1" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server">

        </asp:ScriptManager>
        <asp:Timer ID="TimerTime" runat="server" Interval="1000">
        </asp:Timer>
     
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
 
            <ContentTemplate>                
          <link href="DigStyle0.css" rel="stylesheet" type="text/css" /> 
                <body style="background-color:#000000">
                <div id="clockdate">
            <div class="clockdate-wrapper">
                
                <div id="date"><asp:Label ID="lblDateToday" runat="server" ></asp:Label></div>
                <div id="clock"><asp:Label ID="lblTime"  runat="server" CssClass="clock"></asp:Label></div>
               <%-- <asp:Image ID="Image1" runat="server" src="Img/images2.jpg" alt="slikabozic" height="600"  width="1200" />              
                <div id="tdole">     
                                            
                      <asp:Literal ID="tdolet" runat="server" Text=''/>                       
                </div>	--%>
                
		        <div id="tdole2">
                    
    <asp:Panel ID="myPanel" runat="server" >
        <!-- Other markup here like client and server controls/elements -->
    
                <%--<div id="tdole211">--%>
                           <font size="7"  >
                          <%-- <br /><br />--%>
                                   <%--<br /><br />--%>
                                   <%--<br><br />--%>

                                      <table width="100%" align="center" cellpadding="2" cellspacing="2" border="2"  bgcolor="#004080" >
        
                                        <tr align="center" style="background-color:#004080;color:White; font-size: 1.95em;">
                                           <th align="center" colspan="3" >Realizacija Feroimpex</th>
                                        </tr>
                                        <tr align="center" style="background-color:#004080;color:White; font-size: 1.25em;">
                                            <%--<tr align="center" style="background-color:#0094ff;color:White; font-size: 1.25em;">--%>
                                             <td text-align: center;  vertical-align: middle; &:last-child { font-size: 0.95em; line-height: 1.4;text-align: left; width="40%"> PERIOD </td>                        
                                             <td width="30%"> CILJ </td>            
                                             <td width="30%">OSTVARENO</td> 
       <%-- <td width="15%">CILJ ZA SMJENU</td> 
        <td width="15%">SMJENA 1</td> 
        <td width="15%">SMJENA 2</td> 
        <td width="15%">SMJENA 3</td> --%>
                                            </tr>
                                                     <%=wogrid()%>        
                                       
                                          </table>
                      <%--</div>--%>
                               </asp:Panel>
                      <asp:Literal ID="tdole2t" runat="server" Text=''/>             
		        
                
             </div>


            </div>
                    

                
            </ContentTemplate>
            
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerTime" EventName="Tick" />
            </Triggers>

        </asp:UpdatePanel>
       
        <br />

    
    
       
    
    </form>
</body>
</html>
