<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BDTestForm.aspx.cs" Inherits="FogUM.BDTestForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    


    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=ABQIAAAARd_yq7NVSilogsFD8v87IBTwM0brOpm-All5BF6PoaKBxRWWERTSFbeNocJnrRoCOJd9KNoz-1kJ-g"
      type="text/javascript"></script>
    <script type="text/javascript">
    
    //<![CDATA[

    var map = null;
    var geocoder = null;


    function initialize() {
      if (GBrowserIsCompatible()) {
        map = new GMap2(document.getElementById("map_canvas"));
        map.setCenter(new GLatLng(41.554376,-8.421961), 12);
        map.setMapType(G_NORMAL_MAP);
        map.addControl(new GLargeMapControl());
        map.addControl(new GMapTypeControl());
        map.enableScrollWheelZoom();
        geocoder = new GClientGeocoder();

      }
    }

    function showAddress(address) {
      if (geocoder) {
        geocoder.getLatLng(
          address,
          function(point) {
            if (!point) {
              alert(address + "\nEndereÃ§o nÃ£o encontrado");
            } else {
              map.setCenter(point, 12);
              var marker = new GMarker(point);
              map.addOverlay(marker);
              marker.openInfoWindowHtml(address);
            }
          }
        );
      }
    }


    </script>

</head>
<body onload="initialize()" onunload="GUnload()">>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="teste2" />
        <asp:BulletedList ID="BulletedList1" runat="server" Height="90px" Width="261px">
        </asp:BulletedList>
    
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Button" />
    
    </div>
    <p>
    
        <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="Teste" />
    
     <form action="#" onsubmit="showAddress(this.address.value); return false">
      <p>
        <input type="text" size="60" name="address" value="" />
        <input type="submit" value="Ir para endereÃ§o!" />
      </p>
      <div id="map_canvas" style="width: 800px; height: 500px"></div>
    </form>

    </p>
    </form>
</body>
</html>
