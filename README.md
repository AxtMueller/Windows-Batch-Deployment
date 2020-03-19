
# Disclaimer
You can only use this software on your computers or computers which you have the right to use, and I will not be responsible for any consequences and losses caused by the abuse of this software. Until you fully understand how to use this software, please run it in virtual machines only.

# Introduction
Windows Batch Deployment (you can simply call it as "WBD") is a programmable and rootkit-like remote access tool, it supports from Windows XP to Windows 10 (32-bit and 64-bit). Compared with other remote access software, WBD does not have a server program in the traditional sense. WBD only provides a server DLL, and users must write server programs according to their needs. Therefore, WBD maximally meets the individual needs of users. WBD client is a kernel-mode driver without user-mode component, it hides its traces as much as possible, and the goal is to keep the user's attention as little as possible. WBD client can run user-defined programs when system starts, user-defined programs do not store on the disk in the form of files, and there are no startup entries in the registry. As WBD may be used illegally, when WBD client starts, it outputs a text file to the desktop or the root of system drive to inform its existence and how to uninstall manually.

### Main Features
1. File management (upload, download, copy, delete, rename, etc.).
2. Run program, driver and system shell (CMD).
3. Shut down or reboot the system.
4. The client protects itself against unauthorized uninstallation. The self-protection feature takes effect after first rebooting (of installation). If debug mode is enabled, the self-protection feature will be disabled. If you are interested in this feature, please check [this page](https://github.com/AxtMueller/Windows-Batch-Deployment/issues/1).

### How to configure and install WBD?
1. Edit “InstallClient.bat”, fill in the IP address or domain name (including port) of your server. Note: If you use WBD on the wide area network (WAN), you must have a server. If you only use WBD on the local area network (LAN, such as at home), you can use your own PC.
2. Run “InstallClient.bat” on the computers that you need access remotely.

### How to access the systems with WBD installed?
1. WBD comes with a demonstration server program, you can use it without programming.
2. WBD provides DLL (both 32-bit and 64-bit) for advanced users, you can write your server program based on the sample source code.

### How to uninstall WBD?
1. Call the related function from WBD server DLL (read sample source code for details).
2. Enable system debug mode, then reboot, and then delete the service of WBD client.

### About digital signature and negative comment from Anti-Virus softwares
Because I don't have a digital certificate, I have to use the leaked digital certificate from HT SRL to sign WBD client drivers. As for negative comment, any program of this type is considered a virus by Anti-Virus software, so who cares.

# Application Scenario Examples
1. You are an administrator of IT department. You need to perform repetitive tasks on hundreds of computers (such as updating firewall rules and scripts, pushing notifications, etc.).
2. You are a developer. Your software does not run properly on a few users' systems, but it cannot be replicated in your test environment, so you need to get some data or perform some debugging tests secretly (such as issuing a debug version software to specific users).
3. You are a person with a lot of secrets. You need to erase the data on your computer when you find that your computer is stolen.
4. You are a voyeur and you want to take a screenshot every 10 seconds to monitor what your spouse is doing on his / her computer (just kidding, this is illegal).

# [Screenshots](/screenshots/README.md)
In order to optimize the page load speed in low quality network environments, I only placed one picture on this page. 
![image](https://raw.githubusercontent.com/AxtMueller/Windows-Batch-Deployment/master/screenshots/1.png)

# Contact
### E-MAIL: AxtMueller#gmx.de (Replace # with @)
1. If you find bugs, have constructive suggestions or would like to purchase a paid service, please let me know.  
2. You'd better write E-MAIL in English or German, I only reply to E-MAILs that I am interested in.
### Paid services:
1. Binary customization I: Remove or modify all obvious characteristics of public WBD client.
2. Binary customization II: More powerful self-protection for WBD client, and different characteristic of data packet.
2. Binary customization III: Add more features based on your needs.
4. Source code: Entire source code of WBD.

# [Revision History](/binaries/README.md#all-revision-history)
### Client Version: 20200202
### Server Version: 20200202
