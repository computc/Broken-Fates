docker run -it --rm -e "UNITY_USERNAME=Connor-McPherson@mocs.utc.edu" -e "UNITY_PASSWORD=Terrar1a" -e "TEST_PLATFORM=linux" -e "WORKDIR=/root/project" -v "/root/project" gableroux/unity3d:2018.3.3f1 bash

xvfb-run --auto-servernum --server-args='-screen 0 640x480x24' /opt/Unity/Editor/Unity -logFile -batchmode -createManualActivationFile -username "$UNITY_USERNAME" -password "$UNITY_PASSWORD"

BgZqa5AHinC?zCc
export KEY=BgZqa5AHinC?zCc
openssl aes-256-cbc -e -in Unity_v2018.x.ulf -out ci/Unity_v2018.x.ulf-cipher -k $KEY
git add ci/Unity_v2018.x.ulf-cipher
git commit -m "Add encrypted Unity_v2018.x.ulf using openssl aes-256-cbc KEY"


<?xml version="1.0" encoding="UTF-8"?>
<root>
<SystemInfo>
<IsoCode>
  en
</IsoCode>
<UserName>
  (unset)
</UserName>
<OperatingSystem>
  Linux 4.9 Ubuntu 16.04 64bit
</OperatingSystem>
<OperatingSystemNumeric>
  409
</OperatingSystemNumeric>
<ProcessorType>
  Intel(R) Core(TM) i7-7700 CPU @ 3.60GHz
</ProcessorType>
<ProcessorSpeed>
  3056
</ProcessorSpeed>
<ProcessorCount>
  2
</ProcessorCount>
<ProcessorCores>
  2
</ProcessorCores>
<PhysicalMemoryMB>
  1980
</PhysicalMemoryMB>
<ComputerName>c0b1c7a94f5c
</ComputerName>
<ComputerModel>
PC
</ComputerModel><UnityVersion>2018.3.3f1</UnityVersion><SupportedLicenseVersion>6.x</SupportedLicenseVersion></SystemInfo><License id="Terms"><MachineID Value="2jmj7l5rSw0yVb/vlWAYkK/YBwk=" /><MachineBindings><Binding Key="1" Value="" /></MachineBindings><UnityVersion Value="2018.3.3f1" /></License></root>