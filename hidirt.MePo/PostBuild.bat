@echo off
REM %1 = Solution Directory
REM %2 = Project Directory
REM %3 = $(ConfigurationName) Debug/Release
REM %4 = $(TargetName) Name of output file without extension

xcopy "%2bin\%3\%~n4.*" "C:\Program Files (x86)\Team MediaPortal\MediaPortal TV Server\Plugins\" /R /Y /D
xcopy "%2bin\%3\GenericHid.dll" "C:\Program Files (x86)\Team MediaPortal\MediaPortal TV Server\Plugins\" /R /Y /D
xcopy "%2bin\%3\hidirt.common.dll" "C:\Program Files (x86)\Team MediaPortal\MediaPortal TV Server\Plugins\" /R /Y /D
