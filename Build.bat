@echo off
if NOT exist %windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe (
	echo .NET Framework 4.0 not installed, please install and try again.
	pause
	exit /b 1
)

%windir%\\Microsoft.NET\Framework\v4.0.30319\msbuild.exe MADS_GUI.sln /t:Build /p:Configuration=Release
echo.
echo Done
pause
exit /b 0