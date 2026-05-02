<?xml version='1.0' encoding='UTF-8'?>
<Project Type="Project" LVVersion="25008000">
	<Property Name="NI.LV.All.SaveVersion" Type="Str">25.0</Property>
	<Property Name="NI.LV.All.SourceOnly" Type="Bool">true</Property>
	<Item Name="My Computer" Type="My Computer">
		<Property Name="server.app.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.control.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.tcp.enabled" Type="Bool">false</Property>
		<Property Name="server.tcp.port" Type="Int">0</Property>
		<Property Name="server.tcp.serviceName" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.tcp.serviceName.default" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.vi.callsEnabled" Type="Bool">true</Property>
		<Property Name="server.vi.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="specify.custom.address" Type="Bool">false</Property>
		<Item Name="SubVIs" Type="Folder">
			<Item Name="confirmShutdown.vi" Type="VI" URL="../confirmShutdown.vi"/>
			<Item Name="DBserverConnect.vi" Type="VI" URL="../../Task 2/DBserverConnect.vi"/>
			<Item Name="DBServerSettings.vi" Type="VI" URL="../DBServerSettings.vi"/>
			<Item Name="OPCServerConnect.vi" Type="VI" URL="../OPCServerConnect.vi"/>
			<Item Name="OPCServerSettings.vi" Type="VI" URL="../OPCServerSettings.vi"/>
			<Item Name="SensorSettings.vi" Type="VI" URL="../SensorSettings.vi"/>
		</Item>
		<Item Name="Muninn.rtm" Type="Document" URL="../Muninn.rtm"/>
		<Item Name="Muninn.vi" Type="VI" URL="../Muninn.vi"/>
		<Item Name="settings.ini" Type="Document" URL="../settings.ini"/>
		<Item Name="Dependencies" Type="Dependencies"/>
		<Item Name="Build Specifications" Type="Build"/>
	</Item>
</Project>
