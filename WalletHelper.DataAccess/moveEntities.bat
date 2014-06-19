@ECHO OFF

SET source=%1
SET destination=%2

robocopy %source% %destination% *.cs /MOVE /XF WalletHelperDatabase.Entities.cs
if errorlevel 1 exit 0
if errorlevel 2 exit 0 else exit %errorlevel%