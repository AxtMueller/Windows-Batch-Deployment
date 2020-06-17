# Introduction
Binary files of Windows Batch Deployment.
### How to use?
1. Open InstallClient.bat.txt (in CLIENT directory) with a text editor.
2. Replace 127.0.0.1:9999 with your server IP or domain name. If you don't, the server will be localhost.
##### If you just want to test the effect, start with next step: 
3. Rename InstallClient.bat.txt to InstallClient.bat, then run it as administrator.
4. Run ServerTestVB6GUI.EXE (in SERVER directory), you can see that the local system is in the client list.
5. Select the local system in the client list (its IP is 127.0.0.1 and its status is "Online"), and then click the "Connect" button.
6. When its status changes to "Connected", you can submit operations. When you are finished, click the "Disconnect" button.


# Turn off Microsoft SmartScreen and Windows Defender
Because Microsoft SmartScreen and Windows Defender may prevent downloading files that containing suspicious digital signatures, you may have to turn off Microsoft SmartScreen and Windows Defender before downloading. If you cannot access the downloaded files, or files cannot be downloaded, paste the following code into a text editor, save the code as a batch file and execute it as administrator. After restarting, re-open this page and download again.
```
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows Defender" /v DisableAntiSpyware /t REG_DWORD /d 1 /f
reg add "HKLM\Software\Policies\Microsoft\Windows Defender" /v DisableAntiVirus /t REG_DWORD /d 1 /f
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection" /v DisableIOAVProtection /t REG_DWORD /d 1 /f
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection" /v DisableRealtimeMonitoring /t REG_DWORD /d 1 /f
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection" /v DisableBehaviorMonitoring /t REG_DWORD /d 1 /f
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection" /v DisableOnAccessProtection /t REG_DWORD /d 1 /f
reg add "HKLM\SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection" /v DisableScanOnRealtimeEnable /t REG_DWORD /d 1 /f
reg add "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer" /v SmartScreenEnabled /t REG_SZ /d "Off" /f
reg add "HKCU\SOFTWARE\Microsoft\Edge\SmartScreenEnabled" /v "" /t REG_DWORD /d 0 /f
reg add "HKCU\SOFTWARE\Microsoft\Edge\SmartScreenPuaEnabled" /v "" /t REG_DWORD /d 0 /f
reg add "HKCU\Software\Classes\Local Settings\Software\Microsoft\Windows\CurrentVersion\AppContainer\Storage\microsoft.microsoftedge_8wekyb3d8bbwe\MicrosoftEdge\PhishingFilter" /v EnabledV9 /t REG_DWORD /d 0 /f
shutdown /f /r /t 0
```

# All revision history
### Client Versions:
#### 2nd version: 20200505
[This is the latest version.](../README.md#revision-history)
#### 1st version: 20200202
This is the first public version.
### Server Versions:
#### 1st version: 20200202
[This is the latest version.](../README.md#revision-history)
