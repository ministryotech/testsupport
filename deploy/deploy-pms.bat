@ECHO OFF

ECHO Preparing NuGet...
CALL ..\..\set-nuget-key.bat
del *.nupkg
pause

ECHO Publishing to NuGet...
nuget pack ..\Ministry.TestSupport\Ministry.TestSupport.csproj -Prop Configuration=Release
nuget pack ..\Ministry.TestSupport.Moq\Ministry.TestSupport.Moq.csproj -Prop Configuration=Release
ECHO .
ECHO Ready to push. If you only wish to push one package please delete the packages not to push before pressing a key.
pause
nuget push *.nupkg

pause