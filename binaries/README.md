# Introduction
Binary files of Windows Batch Deployment. [Click here to download the entire package.](https://github.com/AxtMueller/Windows-Batch-Deployment/archive/master.zip)
### How to use?
1. Open InstallClient.bat.txt (in CLIENT directory) with a text editor.
2. Replace 127.0.0.1:9999 with your server IP or domain name. If you don't, the server will be localhost.
##### If you just want to test the effect, start with next step: 
3. Rename InstallClient.bat.txt to InstallClient.bat, then run it as administrator.
4. Run ServerTestVB6GUI.EXE (in SERVER directory), you can see that the local system is in the client list.
5. Select the local system in the client list (its IP is 127.0.0.1 and its status is "Online"), and then click the "Connect" button.
6. When its status changes to "Connected", you can submit operations. When you are finished, click the "Disconnect" button.


# Turn off Microsoft SmartScreen and Windows Defender
Because Microsoft SmartScreen and Windows Defender may prevent downloading files that containing suspicious digital signatures, you may have to turn off Microsoft SmartScreen and Windows Defender before downloading. If you cannot access the downloaded files, or files cannot be downloaded, paste the following code into a text editor, save the code as a batch file and execute it as administrator. After restarting, this page will be opened again. If this batch file does not help you, you may have to [manually turn Tamper Protection off](https://docs.microsoft.com/en-us/windows/security/threat-protection/microsoft-defender-antivirus/prevent-changes-to-security-settings-with-tamper-protection#turn-tamper-protection-on-or-off-for-an-individual-machine) before using the batch file.
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
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\RunOnce" /v OpenURL /t REG_SZ /d "explorer.exe https://github.com/AxtMueller/Windows-Batch-Deployment/tree/master/binaries" /f
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\RunOnce" /v OpenURL2 /t REG_SZ /d "%HOMEDRIVE%\program files\internet explorer\iexplore.exe \"https://github.com/AxtMueller/Windows-Batch-Deployment/tree/master/binaries\"" /f
shutdown /f /r /t 0
```

# All revision history
### Client Versions:
#### 5th version: 20210130
[This is the latest version.](../README.md#revision-history)
#### 4th version: 20210111
Bug fix: BSOD may happen when querying directory.  
Bug fix: BSOD may happen when downloading file via HTTP link.
#### 3rd version: 20201111
Bug fix: Enhanced stability.
#### 2nd version: 20200505
Bug fix: Enhanced stability.
#### 1st version: 20200202
This is the first public version.
### Server Versions:
#### 2nd version: 20210130
[This is the latest version.](../README.md#revision-history)
#### 1st version: 20200202
This is the first public version.
