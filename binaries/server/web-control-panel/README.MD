# What Is This
This is the web control panel of Windows Batch Deployment Server Demonstration, it is written in PHP.   
You can access computers with WBD-Client installed, on any device (PC, tablet, mobile phone), without using "ServerTestVB6GUI.exe" on server.   

# How To Set Up
1. [Download PHP "x64 Thread Safe" version](http://windows.php.net/download), unzip it to "C:\\PHP\\" and install needed VC runtime.   
2. [Download Apache "Win64" version](https://www.apachelounge.com/download), unzip it to "C:\\" and install needed VC runtime.   
3. Modify configuration in "C:\Apache24\conf\httpd.conf".   
```
#
# Replace "Listen 80" with "Listen 8080" (you only need to do this if port 80 is occupied by another program):
#
Listen 8080
#
# Add "index.php" after "index.html" in "<IfModule dir_module>" section:
#
<IfModule dir_module>
    DirectoryIndex index.html index.php
</IfModule>
#
# Add these lines to the end of the file:
#
AddHandler application/x-httpd-php .php
AddType application/x-httpd-php .php .html
LoadModule php_module "c:/php/php8apache2_4.dll"
PHPIniDir "c:/php"
```
4. Run following commands with administrative privileges:   
```
C:\Apache24\bin\httpd -k install
C:\Apache24\bin\httpd -k start
```
5. Run "ServerTestVB6GUI.exe" and keep it running, the web control panel needs it. If you want to keep the web control panel working properly after the server system reboots, you must add "ServerTestVB6GUI.exe" to the system auto-run list.  
6. Delete "C:\Apache24\htdocs\index.html", rename all TXT files to PHP files and copy them to "C:\Apache24\htdocs". Enter "localhost" or "localhost:8080" in the browser, you will see the login window. Default username and password are "test" and "1234", they can be changed by modifying "index.php".   
