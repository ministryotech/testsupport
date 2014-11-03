@ECHO OFF

ECHO Preparing NuGet...
CALL ..\..\set-nuget-key.bat
del *.nupkg
pause

ECHO Publishing to NuGet...
nuget pack ..\Ministry.TestSupport\Ministry.TestSupport.csproj -Prop Configuration=Release
nuget pack ..\Ministry.TestSupport.Moq\Ministry.TestSupport.Moq.csproj -Prop Configuration=Release
nuget push *.nupkg

pause