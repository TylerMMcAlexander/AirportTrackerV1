Airport:
ID
Name
City
State
Terminal Terminal
Flight Flight


Flight:
ID
Cost
StartingLocation(Airport Location)
EndingLocation(Airport Location)
Take Off
Passenger Count
Passenger Total
Employee ID List
Aircraft Aircraft

Terminal:
ID
Name

Aircraft:
ID
Name
Type
Capacity

Users: 
admin
Admin123!


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimeSelector.aspx.cs" Inherits="TimeSelector" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Time Selector</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="timePicker">Select Time:</label>
            <input type="time" id="timePicker" runat="server" />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>

using System;

public partial class TimeSelector : System.Web.UI.Page
{
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Access the selected time
        var selectedTime = Request.Form["timePicker"];
        if (TimeSpan.TryParse(selectedTime, out TimeSpan time))
        {
            // Process the time (for example, save it to a database or use it in a datetime)
            DateTime dateTime = DateTime.Today.Add(time);
            // Do something with dateTime
        }
        else
        {
            // Handle invalid time format
        }
    }
}

