@ECHO OFF
TITLE Compiling MeGUI...
PUSHD "megui\trunk"
START /B /WAIT compile-msbuild.bat
POPD

REM Detect if we are running on 64bit WIN and use Wow6432Node, set the path
REM of NSIS accordingly and compile installer
IF "%PROGRAMFILES(x86)%zzz"=="zzz" (SET "U_=HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
) ELSE (
SET "U_=HKLM\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
)

SET "K_=NSIS"
FOR /f "delims=" %%a IN (
	'REG QUERY "%U_%\%K_%" /v "InstallLocation"2^>Nul^|FIND "REG_"') DO (
	SET "NSISPath=%%a"&Call :Sub %%NSISPath:*Z=%%)

ECHO.
IF DEFINED NSISPath (
  ECHO:Compiling installer...
  "%NSISPath%\makensis.exe" /V2 "Installer\trunk\megui.nsi"
  "%NSISPath%\makensis.exe" /V2 "Installer\trunk\megui_x64.nsi"
  IF EXIST "Installer\trunk\FullPackage" (
    "%NSISPath%\makensis.exe" /V2 "Installer\trunk\megui_full.nsi"
  )
  IF EXIST "Installer\trunk\FullPackage_x64" (
    "%NSISPath%\makensis.exe" /V2 "Installer\trunk\megui_x64_full.nsi"
  )
)

ECHO. && ECHO.
PAUSE
EXIT /B

:Sub
SET NSISPath=%*
GOTO :EOF
