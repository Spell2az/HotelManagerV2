<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GuestDetails.aspx.cs" Inherits="GuestDetails" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI.DataVisualization.Charting" Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div>
            
            
            
            <asp:Chart ID="Chart1" runat="server" Height="296px" Width="412px" BorderDashStyle="Solid"
                       BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2px" BackColor="211, 223, 240"
                       BorderColor="#1A3B69">
                <Titles>
                    <asp:Title Text="Title of the Graph comes here" />
                </Titles>
                <Series>
                    <asp:Series Name="Series1" BorderColor="180, 26, 59, 105">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                   BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                                   BackGradientStyle="TopBottom">
                        <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                     WallWidth="0" IsClustered="False"></Area3DStyle>
                        <AxisY LineColor="64, 64, 64, 64">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisY>
                        <AxisX LineColor="64, 64, 64, 64">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>  
        
        
    </div>
   
</asp:Content>

