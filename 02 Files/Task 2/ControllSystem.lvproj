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
			<Item Name="AirHeater.vi" Type="VI" URL="../AirHeater.vi"/>
			<Item Name="ConfirmShutdown.vi" Type="VI" URL="../ConfirmShutdown.vi"/>
			<Item Name="getServerParams.vi" Type="VI" URL="../getServerParams.vi"/>
			<Item Name="LoginOPC.vi" Type="VI" URL="../LoginOPC.vi"/>
			<Item Name="LPF.vi" Type="VI" URL="../LPF.vi"/>
			<Item Name="OPCServerConnect.vi" Type="VI" URL="../../Task 3/OPCServerConnect.vi"/>
			<Item Name="OPCServerSettings.vi" Type="VI" URL="../OPCServerSettings.vi"/>
			<Item Name="PId.vi" Type="VI" URL="../PId.vi"/>
			<Item Name="SimulatedData.vi" Type="VI" URL="../SimulatedData.vi"/>
		</Item>
		<Item Name="Bifrost.vi" Type="VI" URL="../Bifrost.vi"/>
		<Item Name="rtmBifrost.rtm" Type="Document" URL="../rtmBifrost.rtm"/>
		<Item Name="settings.ini" Type="Document" URL="../settings.ini"/>
		<Item Name="Dependencies" Type="Dependencies"/>
		<Item Name="Build Specifications" Type="Build"/>
	</Item>
</Project>
