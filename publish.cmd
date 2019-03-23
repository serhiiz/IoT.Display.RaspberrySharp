del .\IoT.Display.RaspberrySharp\bin\Release\IoT.Display.RaspberrySharp.*.nupkg 
dotnet pack -c Release --include-symbols
nuget push .\IoT.Display.RaspberrySharp\bin\Release\IoT.Display.RaspberrySharp.*.nupkg -Source https://api.nuget.org/v3/index.json