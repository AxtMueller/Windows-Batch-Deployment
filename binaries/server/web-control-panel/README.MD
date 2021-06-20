# WHAT IS IT
This is the web control panel of Windows Batch Deployment Server Demonstration, it is written in PHP.   
You can access computers with WBD-client installed, on any device (PC, tablet, mobile phone), without using "ServerTestVB6GUI.exe" on server.   

# HOW TO SETUP
1. [Download PHP "x64 Thread Safe" version](http://windows.php.net/download), unzip it to "C:\PHP\" and install needed VC runtime.   
2. [Download Apache "Win64" version](https://www.apachelounge.com/download), unzip it to "C:\" and install needed VC runtime.   
3. Modify configuration in "C:\Apache24\conf\httpd.conf".   
```
#
# Replace "Listen 80" with "Listen 8080" (you must do this if port 80 is occupied by other program, such as IIS):
#
Listen 8080
#
# Find "IfModule dir_module" section, add "index.php" after "index.html":   
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
5. Run "ServerTestVB6GUI.exe" and keep it running, the web control panel needs it.   
6. Copy all TXT files to "C:\Apache24\htdocs", delete the TXT extension and delete "index.html", enter "localhost" or "localhost:8080" in the browser, you will see the login window. Default username and password are "test" and "1234", they can be changed by modifying "index.php".   