VERSION 5.00
Object = "{6B7E6392-850A-101B-AFC0-4210102A8DA7}#1.3#0"; "COMCTL32.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form frmMain 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Windows-Batch-Deployment Server Demonstration"
   ClientHeight    =   9375
   ClientLeft      =   45
   ClientTop       =   390
   ClientWidth     =   11895
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   9375
   ScaleWidth      =   11895
   StartUpPosition =   2  'CenterScreen
   Begin VB.Timer Timer1 
      Interval        =   1000
      Left            =   360
      Top             =   2640
   End
   Begin VB.Frame Frame1 
      Caption         =   "Client"
      Height          =   3135
      Left            =   120
      TabIndex        =   9
      ToolTipText     =   "Double-click to refresh the status of all clients, it can find all clients that lost connection."
      Top             =   120
      Width           =   11655
      Begin ComctlLib.ListView lvClient 
         Height          =   2775
         Left            =   120
         TabIndex        =   10
         Top             =   240
         Width           =   10095
         _ExtentX        =   17806
         _ExtentY        =   4895
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         _Version        =   327682
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   6
         BeginProperty ColumnHeader(1) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
            Key             =   ""
            Object.Tag             =   ""
            Text            =   "ID"
            Object.Width           =   212
         EndProperty
         BeginProperty ColumnHeader(2) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
            SubItemIndex    =   1
            Key             =   ""
            Object.Tag             =   ""
            Text            =   "IP"
            Object.Width           =   3175
         EndProperty
         BeginProperty ColumnHeader(3) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
            SubItemIndex    =   2
            Key             =   ""
            Object.Tag             =   ""
            Text            =   "System"
            Object.Width           =   1764
         EndProperty
         BeginProperty ColumnHeader(4) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
            SubItemIndex    =   3
            Key             =   ""
            Object.Tag             =   ""
            Text            =   "Name"
            Object.Width           =   4623
         EndProperty
         BeginProperty ColumnHeader(5) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
            SubItemIndex    =   4
            Key             =   ""
            Object.Tag             =   ""
            Text            =   "Status"
            Object.Width           =   1764
         EndProperty
         BeginProperty ColumnHeader(6) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
            SubItemIndex    =   5
            Key             =   ""
            Object.Tag             =   ""
            Text            =   "Hash"
            Object.Width           =   2611
         EndProperty
      End
      Begin VB.OptionButton Option2 
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         Caption         =   "Stop R.C.L"
         ForeColor       =   &H80000008&
         Height          =   255
         Left            =   10320
         TabIndex        =   24
         ToolTipText     =   "Stop Refreshing Client List"
         Top             =   600
         Width           =   1215
      End
      Begin VB.OptionButton Option1 
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         Caption         =   "Auto R.C.L"
         ForeColor       =   &H80000008&
         Height          =   255
         Left            =   10320
         TabIndex        =   23
         ToolTipText     =   "Automatically Refresh Client List"
         Top             =   240
         Value           =   -1  'True
         Width           =   1215
      End
      Begin VB.CommandButton btnClient 
         Caption         =   "Connect"
         Height          =   255
         Index           =   0
         Left            =   10320
         TabIndex        =   0
         ToolTipText     =   "You must connect to the client before performing any operation."
         Top             =   960
         Width           =   1215
      End
      Begin VB.CommandButton btnClient 
         Caption         =   "Disconnect"
         Height          =   255
         Index           =   1
         Left            =   10320
         TabIndex        =   1
         ToolTipText     =   "You cannot perform any operation after disconnecting the client."
         Top             =   1320
         Width           =   1215
      End
      Begin VB.CommandButton btnClient 
         Caption         =   "Shutdown"
         Height          =   255
         Index           =   2
         Left            =   10320
         TabIndex        =   2
         Top             =   1680
         Width           =   1215
      End
      Begin VB.CommandButton btnClient 
         Caption         =   "Reboot"
         Height          =   255
         Index           =   3
         Left            =   10320
         TabIndex        =   3
         Top             =   2040
         Width           =   1215
      End
      Begin VB.CommandButton btnClient 
         Caption         =   "Update"
         Height          =   255
         Index           =   4
         Left            =   10320
         TabIndex        =   4
         Top             =   2400
         Width           =   1215
      End
      Begin VB.CommandButton btnClient 
         Caption         =   "Uninstall"
         Height          =   255
         Index           =   5
         Left            =   10320
         TabIndex        =   5
         Top             =   2760
         Width           =   1215
      End
   End
   Begin TabDlg.SSTab SSTab1 
      Height          =   5895
      Left            =   120
      TabIndex        =   6
      Top             =   3360
      Width           =   11655
      _ExtentX        =   20558
      _ExtentY        =   10398
      _Version        =   393216
      Tabs            =   4
      TabsPerRow      =   4
      TabHeight       =   520
      TabCaption(0)   =   "File Browser"
      TabPicture(0)   =   "frmMain.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "cmdFile(3)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "cmdFile(2)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).Control(2)=   "btnFile(2)"
      Tab(0).Control(2).Enabled=   0   'False
      Tab(0).Control(3)=   "btnFile(3)"
      Tab(0).Control(3).Enabled=   0   'False
      Tab(0).Control(4)=   "btnFile(4)"
      Tab(0).Control(4).Enabled=   0   'False
      Tab(0).Control(5)=   "btnFile(5)"
      Tab(0).Control(5).Enabled=   0   'False
      Tab(0).Control(6)=   "Frame2"
      Tab(0).Control(6).Enabled=   0   'False
      Tab(0).Control(7)=   "btnFile(0)"
      Tab(0).Control(7).Enabled=   0   'False
      Tab(0).Control(8)=   "btnFile(1)"
      Tab(0).Control(8).Enabled=   0   'False
      Tab(0).Control(9)=   "Frame3"
      Tab(0).Control(9).Enabled=   0   'False
      Tab(0).Control(10)=   "btnFile(6)"
      Tab(0).Control(10).Enabled=   0   'False
      Tab(0).Control(11)=   "btnFile(7)"
      Tab(0).Control(11).Enabled=   0   'False
      Tab(0).Control(12)=   "btnFile(8)"
      Tab(0).Control(12).Enabled=   0   'False
      Tab(0).ControlCount=   13
      TabCaption(1)   =   "System Shell"
      TabPicture(1)   =   "frmMain.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "txtCmdRet"
      Tab(1).Control(1)=   "txtCMD"
      Tab(1).Control(2)=   "btnOperate(2)"
      Tab(1).Control(3)=   "btnOperate(3)"
      Tab(1).ControlCount=   4
      TabCaption(2)   =   "Server Configuration"
      TabPicture(2)   =   "frmMain.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "txtCfgText"
      Tab(2).Control(1)=   "txtCfgFile"
      Tab(2).Control(2)=   "btnOperate(4)"
      Tab(2).Control(3)=   "btnOperate(5)"
      Tab(2).ControlCount=   4
      TabCaption(3)   =   "Auto-Run Management"
      TabPicture(3)   =   "frmMain.frx":0054
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "Frame6"
      Tab(3).Control(1)=   "Frame5"
      Tab(3).Control(2)=   "Frame4"
      Tab(3).ControlCount=   3
      Begin VB.Frame Frame6 
         Caption         =   "Program (DLL)"
         Height          =   5415
         Left            =   -67200
         TabIndex        =   51
         Top             =   360
         Width           =   3735
         Begin VB.ListBox lstDLL 
            Height          =   4740
            Left            =   120
            TabIndex        =   56
            Top             =   240
            Width           =   3495
         End
         Begin VB.CommandButton btnOperate 
            Caption         =   "Refresh"
            Height          =   255
            Index           =   14
            Left            =   120
            TabIndex        =   55
            Top             =   5040
            Width           =   855
         End
         Begin VB.CommandButton btnOperate 
            Caption         =   "Add"
            Height          =   255
            Index           =   15
            Left            =   1080
            TabIndex        =   54
            Top             =   5040
            Width           =   735
         End
         Begin VB.CommandButton btnOperate 
            Caption         =   "Delete"
            Height          =   255
            Index           =   16
            Left            =   1920
            TabIndex        =   53
            Top             =   5040
            Width           =   735
         End
         Begin VB.CommandButton btnOperate 
            Caption         =   "Delete All"
            Height          =   255
            Index           =   17
            Left            =   2760
            TabIndex        =   52
            Top             =   5040
            Width           =   855
         End
      End
      Begin VB.CommandButton btnFile 
         Caption         =   "HTTP Download"
         Height          =   255
         Index           =   8
         Left            =   10080
         TabIndex        =   50
         Tag             =   "http://libevent.org/sm-web-appnexus-logo.png"
         Top             =   5520
         Width           =   1455
      End
      Begin VB.Frame Frame5 
         Caption         =   "Program (EXE)"
         Height          =   5415
         Left            =   -71040
         TabIndex        =   39
         Top             =   360
         Width           =   3735
         Begin VB.CommandButton btnOperate 
            Caption         =   "Delete All"
            Height          =   255
            Index           =   13
            Left            =   2760
            TabIndex        =   49
            Top             =   5040
            Width           =   855
         End
         Begin VB.CommandButton btnOperate 
            Caption         =   "Delete"
            Height          =   255
            Index           =   12
            Left            =   1920
            TabIndex        =   48
            Top             =   5040
            Width           =   735
         End
         Begin VB.CommandButton btnOperate 
            Caption         =   "Add"
            Height          =   255
            Index           =   11
            Left            =   1080
            TabIndex        =   47
            Top             =   5040
            Width           =   735
         End
         Begin VB.CommandButton btnOperate 
            Caption         =   "Refresh"
            Height          =   255
            Index           =   10
            Left            =   120
            TabIndex        =   46
            Top             =   5040
            Width           =   855
         End
         Begin VB.ListBox lstExe 
            Height          =   4740
            Left            =   120
            TabIndex        =   41
            Top             =   240
            Width           =   3495
         End
      End
      Begin VB.Frame Frame4 
         Caption         =   "Driver"
         Height          =   5415
         Left            =   -74880
         TabIndex        =   38
         Top             =   360
         Width           =   3735
         Begin VB.CommandButton btnOperate 
            Caption         =   "Delete All"
            Height          =   255
            Index           =   9
            Left            =   2760
            TabIndex        =   45
            Top             =   5040
            Width           =   855
         End
         Begin VB.CommandButton btnOperate 
            Caption         =   "Delete"
            Height          =   255
            Index           =   8
            Left            =   1920
            TabIndex        =   44
            Top             =   5040
            Width           =   735
         End
         Begin VB.CommandButton btnOperate 
            Caption         =   "Add"
            Height          =   255
            Index           =   7
            Left            =   1080
            TabIndex        =   43
            Top             =   5040
            Width           =   735
         End
         Begin VB.CommandButton btnOperate 
            Caption         =   "Refresh"
            Height          =   255
            Index           =   6
            Left            =   120
            TabIndex        =   42
            Top             =   5040
            Width           =   855
         End
         Begin VB.ListBox lstDrv 
            Height          =   4740
            Left            =   120
            TabIndex        =   40
            Top             =   240
            Width           =   3495
         End
      End
      Begin VB.CommandButton btnFile 
         Caption         =   "Get Attribute"
         Height          =   255
         Index           =   7
         Left            =   8760
         TabIndex        =   37
         Top             =   5520
         Width           =   1215
      End
      Begin VB.CommandButton btnFile 
         Caption         =   "Set Attribute"
         Height          =   255
         Index           =   6
         Left            =   7440
         TabIndex        =   36
         Top             =   5520
         Width           =   1215
      End
      Begin VB.Frame Frame3 
         Caption         =   "Remote"
         Height          =   5055
         Left            =   3960
         TabIndex        =   31
         Top             =   360
         Width           =   7575
         Begin ComctlLib.ListView lvFile 
            Height          =   4335
            Left            =   120
            TabIndex        =   35
            ToolTipText     =   "Double click to open directory or execute program."
            Top             =   600
            Width           =   7335
            _ExtentX        =   12938
            _ExtentY        =   7646
            View            =   3
            LabelEdit       =   1
            LabelWrap       =   -1  'True
            HideSelection   =   0   'False
            _Version        =   327682
            ForeColor       =   -2147483640
            BackColor       =   -2147483643
            BorderStyle     =   1
            Appearance      =   1
            NumItems        =   3
            BeginProperty ColumnHeader(1) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
               Key             =   ""
               Object.Tag             =   ""
               Text            =   "Name"
               Object.Width           =   5645
            EndProperty
            BeginProperty ColumnHeader(2) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
               SubItemIndex    =   1
               Key             =   ""
               Object.Tag             =   ""
               Text            =   "Size"
               Object.Width           =   2293
            EndProperty
            BeginProperty ColumnHeader(3) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
               SubItemIndex    =   2
               Key             =   ""
               Object.Tag             =   ""
               Text            =   "Last Modify Time"
               Object.Width           =   2822
            EndProperty
         End
         Begin VB.TextBox txtFilePath 
            Height          =   270
            Left            =   120
            TabIndex        =   34
            Text            =   "\"
            Top             =   240
            Width           =   5415
         End
         Begin VB.CommandButton btnOperate 
            Caption         =   "Go To"
            Height          =   255
            Index           =   0
            Left            =   5640
            TabIndex        =   33
            Top             =   240
            Width           =   615
         End
         Begin VB.CommandButton btnOperate 
            Caption         =   "Go To P.D"
            Height          =   255
            Index           =   1
            Left            =   6360
            TabIndex        =   32
            ToolTipText     =   "Return to the parent directory"
            Top             =   240
            Width           =   1095
         End
      End
      Begin VB.CommandButton btnFile 
         Caption         =   "Download"
         Height          =   255
         Index           =   1
         Left            =   2040
         TabIndex        =   30
         Top             =   5520
         Width           =   1815
      End
      Begin VB.CommandButton btnFile 
         Caption         =   "Upload"
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   29
         Top             =   5520
         Width           =   1815
      End
      Begin VB.Frame Frame2 
         Caption         =   "Local"
         Height          =   5055
         Left            =   120
         TabIndex        =   25
         Top             =   360
         Width           =   3735
         Begin VB.DriveListBox Drive1 
            Appearance      =   0  'Flat
            Height          =   300
            Left            =   120
            TabIndex        =   28
            Top             =   240
            Width           =   3495
         End
         Begin VB.DirListBox Dir1 
            Height          =   1890
            Left            =   120
            TabIndex        =   27
            ToolTipText     =   "Right-click to refresh."
            Top             =   600
            Width           =   3495
         End
         Begin VB.FileListBox File1 
            Height          =   2430
            Left            =   120
            TabIndex        =   26
            ToolTipText     =   "Right-click to refresh."
            Top             =   2550
            Width           =   3495
         End
      End
      Begin VB.TextBox txtCfgText 
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   4935
         Left            =   -74880
         MultiLine       =   -1  'True
         ScrollBars      =   3  'Both
         TabIndex        =   22
         Top             =   840
         Width           =   11415
      End
      Begin VB.TextBox txtCfgFile 
         Height          =   285
         Left            =   -74880
         TabIndex        =   21
         Text            =   "TEST.cfg"
         Top             =   480
         Width           =   9495
      End
      Begin VB.CommandButton btnOperate 
         Caption         =   "Preview"
         Height          =   255
         Index           =   4
         Left            =   -65280
         TabIndex        =   20
         Top             =   480
         Width           =   855
      End
      Begin VB.CommandButton btnOperate 
         Caption         =   "Configure"
         Height          =   255
         Index           =   5
         Left            =   -64320
         TabIndex        =   19
         Top             =   480
         Width           =   855
      End
      Begin VB.CommandButton btnFile 
         Caption         =   "Rename"
         Height          =   255
         Index           =   5
         Left            =   6480
         TabIndex        =   18
         Top             =   5520
         Width           =   855
      End
      Begin VB.CommandButton btnFile 
         Caption         =   "Delete"
         Height          =   255
         Index           =   4
         Left            =   5640
         TabIndex        =   17
         Top             =   5520
         Width           =   735
      End
      Begin VB.CommandButton btnFile 
         Caption         =   "Copy"
         Height          =   255
         Index           =   3
         Left            =   4800
         TabIndex        =   16
         Top             =   5520
         Width           =   735
      End
      Begin VB.CommandButton btnFile 
         Caption         =   "New"
         Height          =   255
         Index           =   2
         Left            =   3960
         TabIndex        =   15
         Top             =   5520
         Width           =   735
      End
      Begin VB.CommandButton btnOperate 
         Caption         =   "Clear"
         Height          =   255
         Index           =   3
         Left            =   -64320
         TabIndex        =   14
         Top             =   480
         Width           =   855
      End
      Begin VB.CommandButton btnOperate 
         Caption         =   "Execute"
         Height          =   255
         Index           =   2
         Left            =   -65280
         TabIndex        =   13
         Top             =   480
         Width           =   855
      End
      Begin VB.TextBox txtCMD 
         Height          =   285
         Left            =   -74880
         TabIndex        =   12
         Text            =   "ipconfig"
         Top             =   480
         Width           =   9495
      End
      Begin VB.TextBox txtCmdRet 
         BeginProperty Font 
            Name            =   "Courier New"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   4935
         Left            =   -74880
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         ScrollBars      =   3  'Both
         TabIndex        =   11
         Top             =   840
         Width           =   11415
      End
      Begin VB.CommandButton cmdFile 
         Caption         =   "Download"
         Height          =   375
         Index           =   2
         Left            =   720
         TabIndex        =   8
         Top             =   7440
         Width           =   1215
      End
      Begin VB.CommandButton cmdFile 
         Caption         =   "Upload"
         Height          =   375
         Index           =   3
         Left            =   2040
         TabIndex        =   7
         Top             =   7440
         Width           =   1215
      End
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'/*
'    Author:      Axt Mueller
'    Description: Windows-Batch-Deployment Server Demonstration.
'*/
Option Explicit

'################################################################################
' WIN32API CONSTANT
'################################################################################
Private Const SW_SHOW As Long = 5
Private Const LVM_FIRST As Long = &H1000
Private Const LVS_EX_FULLROWSELECT As Long = &H20
Private Const LVM_SETEXTENDEDLISTVIEWSTYLE As Long = LVM_FIRST + 54
Private Const LVM_GETEXTENDEDLISTVIEWSTYLE As Long = LVM_FIRST + 55

'################################################################################
' WIN32API DECLARATION
'################################################################################
Private Declare Sub ExitProcess Lib "kernel32" (ByVal dwExitCode As Long)
Private Declare Sub memcpy Lib "kernel32" Alias "RtlMoveMemory" (ByVal Destination As Long, ByVal Source As Long, ByVal Length As Long)
Private Declare Function VirtualAlloc Lib "kernel32" (ByVal dwAddr As Long, ByVal dwSize As Long, ByVal flAllocationType As Long, ByVal flNewProtect As Long) As Long
Private Declare Function VirtualFree Lib "kernel32" (ByVal dwAddr As Long, ByVal dwSize As Long, ByVal dwType As Long) As Long
Private Declare Function VirtualProtect Lib "kernel32" (ByVal dwAddr As Long, ByVal dwSize As Long, ByVal flNewProtect As Long, ByRef lpflOldProtect As Long) As Long
Private Declare Function lstrlenA Lib "kernel32" (ByVal lpString As Long) As Long
Private Declare Function lstrlenW Lib "kernel32" (ByVal lpString As Long) As Long
Private Declare Function lstrcpyA Lib "kernel32" (ByVal lpString1 As Long, ByVal lpString2 As Long) As Long
Private Declare Function lstrcpyW Lib "kernel32" (ByVal lpString1 As Long, ByVal lpString2 As Long) As Long
Private Declare Function SendMessageA Lib "user32" (ByVal hWnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
Private Declare Function MessageBoxA Lib "user32" (ByVal hWnd As Long, ByVal txt As Long, ByVal title As Long, ByVal dwType As Long) As Long
Private Declare Function MessageBoxW Lib "user32" (ByVal hWnd As Long, ByVal txt As Long, ByVal title As Long, ByVal dwType As Long) As Long
Private Declare Function LoadLibraryA Lib "kernel32.dll" (ByVal lpModuleName As String) As Long
Private Declare Function GetProcAddress Lib "kernel32.dll" (ByVal hModule As Long, ByVal lpProcName As String) As Long

'################################################################################
' WINDOWS BATCH DEPLOYMENT CONSTANT
'################################################################################
Const SERVER_MAX_CLIENTS As Long = 4096
Const CLIENT_CONFIG_SERVER As Long = 0
Const CLIENT_STATUS_ONLINE As String = "online"
Const CLIENT_STATUS_OFFLINE As String = "offline"
Const CLIENT_STATUS_CONNECTED As String = "connected"
Const CLIENT_AUTORUN_EMPTY As String = "((LEER))"
Const CLIENT_AUTORUN_TYPE_SYS As Long = 0
Const CLIENT_AUTORUN_TYPE_EXE As Long = 1
Const CLIENT_AUTORUN_TYPE_DLL As Long = 2
Const CLIENT_RUN_DLL_P1 As Byte = &HFE
Const CLIENT_RUN_DLL_P2 As Long = &HFFFFFFFF
Const CLIENT_RUN_SYS_P1 As Byte = &HFF
Const CLIENT_RUN_SYS_P2 As Long = &HFFFFFFFF
Const CLIENT_FSO_CREATE_FILE As Long = 0
Const CLIENT_FSO_CREATE_DIRECTORY As Long = 1
Const CLIENT_FSO_COPY As Long = 2
Const CLIENT_FSO_DELETE As Long = 3
Const CLIENT_FSO_RENAME As Long = 4
Const CLIENT_FSO_SET_ATTRIB As Long = 5
Const CLIENT_FSO_GET_ATTRIB As Long = 6
Const CLIENT_FSO_HTTP_DOWNLOAD As Long = 7

'################################################################################
' WINDOWS BATCH DEPLOYMENT STRUCTURE DECLARATION
'################################################################################
Private Type CLIENT_INFO
    id As Long
    hash_low As Long
    hash_high As Long
    szAddr(31) As Byte
    szStatus(31) As Byte
    szDescription(51) As Byte
End Type

Private Type BDP_FILE_TIME
    Year As Integer
    Month As Byte
    Day As Byte
    Hour As Byte
    Minute As Byte
    Second As Byte
    Weekday As Byte
End Type

Private Type BDP_FILE_INFO
    FileModifyTime As BDP_FILE_TIME
    FileSizeLow As Long
    FileSizeHigh As Long
    FileName(247) As Integer
End Type

'################################################################################
' WINDOWS BATCH DEPLOYMENT API DECLARATION
'################################################################################
Private Declare Function init Lib "Server32.dll" (ByVal port As Long) As Byte
Private Declare Function uninit Lib "Server32.dll" () As Byte
Private Declare Function ClientList Lib "Server32.dll" (ByVal pInfoAddress As Long) As Long
Private Declare Function ClientConnect Lib "Server32.dll" (ByVal id As Long) As Byte
Private Declare Function ClientDisconnect Lib "Server32.dll" (ByVal id As Long) As Byte
Private Declare Function ClientTest Lib "Server32.dll" (ByVal id As Long, ByRef pHash As Currency) As Byte
Private Declare Function ClientReboot Lib "Server32.dll" (ByVal id As Long) As Byte
Private Declare Function ClientShutdown Lib "Server32.dll" (ByVal id As Long) As Byte
Private Declare Function ClientUpdate Lib "Server32.dll" (ByVal id As Long, ByVal wsLocalFile As Long) As Byte
Private Declare Function ClientConfig Lib "Server32.dll" (ByVal id As Long, ByVal ConfigId As Byte, ByVal wsLocalConfigFilePath As Long) As Byte
Private Declare Function CmdQueryDirectory Lib "Server32.dll" (ByVal id As Long, ByVal wsPath As Long, ByVal pStructAddress As Long, ByRef pCount As Long) As Byte
Private Declare Function CmdUploadFileTo Lib "Server32.dll" (ByVal id As Long, ByVal wsLocalFile As Long, ByVal wsRemoteSaveTo As Long, ByVal stdcall_callback As Long) As Byte
Private Declare Function CmdDownloadFileFrom Lib "Server32.dll" (ByVal id As Long, ByVal wsRemoteFile As Long, ByVal wsLocalSaveTo As Long, ByVal stdcall_callback As Long) As Byte
Private Declare Function CmdExecuteBinary Lib "Server32.dll" (ByVal id As Long, ByVal wsPath As Long, ByVal wndmode As Byte, ByVal waittmo As Long, ByRef pRetVal As Currency) As Byte
Private Declare Function CmdSystemShell Lib "Server32.dll" (ByVal id As Long, ByVal wsParam As Long, ByVal szBuffer As Long, ByVal Length As Long) As Byte
Private Declare Function CmdFileOperation Lib "Server32.dll" (ByVal id As Long, ByVal fn As Byte, ByVal wsPath1 As Long, ByVal wsPath2 As Long, ByRef pRetVal As Long) As Byte
Private Declare Function CmdAddAutoRunBin Lib "Server32.dll" (ByVal id As Long, ByVal bType As Byte, ByVal wsName As Long, ByVal wsPath As Long, ByVal wsParam As Long) As Byte
Private Declare Function CmdDelAutoRunBin Lib "Server32.dll" (ByVal id As Long, ByVal bType As Byte, ByVal wsName As Long) As Byte
Private Declare Function CmdQueryAutoRunBin Lib "Server32.dll" (ByVal id As Long, ByVal bType As Byte, ByVal ppNames As Long) As Byte
Private Declare Function CmdClearAutoRunBin Lib "Server32.dll" (ByVal id As Long, ByVal bType As Byte) As Byte

'################################################################################
' DEMONSTRATION PROGRAM STRUCTURE
'################################################################################
Private Type mDec
    lo As Long
    hi As Long
    hh As Long
End Type

Private Type mVar
    ty As Integer
    tyl As Integer
    tt As Long
    lo As Long
    hi As Long
End Type

'################################################################################
' DEMONSTRATION PROGRAM CODE
'################################################################################
Private Function i64toa(ByVal sv As Variant) As String
    Dim v As Variant: v = sv
    Dim vDec As mDec
    Dim vVar As mVar
    Dim i As Integer
    Dim ls As String
    memcpy VarPtr(vVar.ty), VarPtr(v), 16
    memcpy VarPtr(vDec.lo), VarPtr(vVar.lo), 8
    vDec.hh = vVar.tt
    ls = Hex(vDec.lo)
    i64toa = Hex(vDec.hh) & "" & Hex(vDec.hi) & "" & String(8 - Len(ls), "0") & ls
    For i = 1 To Len(i64toa)
        If Left$(i64toa, 1) = "0" Then
            i64toa = Mid$(i64toa, 2)
        Else
            Exit For
        End If
    Next
End Function

Public Function sz2bstr(ByRef ba() As Byte) As String
    sz2bstr = StrConv(ba, vbUnicode, 0)
End Function

Private Function StrFromPtr(ByVal lpString As Long, Optional bUnicode As Boolean = False) As String
    On Error Resume Next
    If bUnicode Then
        StrFromPtr = String(lstrlenW(lpString), Chr(0))
        lstrcpyW StrPtr(StrFromPtr), ByVal lpString
    Else
        StrFromPtr = String(lstrlenA(lpString), Chr(0))
        lstrcpyA ByVal StrFromPtr, ByVal lpString
    End If
End Function

Private Function ReadText(ByVal szFileName As String) As String
    Dim szTextCodes As String
    Open szFileName For Binary As #1
        szTextCodes = StrConv(InputB(LOF(1), 1), vbUnicode)
    Close #1
    ReadText = szTextCodes
End Function

Private Sub SaveText(ByVal szFileName As String, ByVal sz As String)
    Open szFileName For Output As #1
        Print #1, sz
    Close #1
End Sub

Private Function GetParentDirectory(ByVal szPath As String) As String
    Dim i As Long
    Dim sa() As String
    Dim sz As String: sz = ""
    If Trim$(szPath) <> "\" Then
        sa = Split(szPath, "\")
        If UBound(sa) = 1 And Len(szPath) = 3 Then
            sz = "\"
        Else
            For i = 0 To UBound(sa) - 1
                sz = sz & sa(i) & "\"
            Next
            If Len(sz) > 3 Then
                sz = Left$(sz, Len(sz) - 1)
            End If
        End If
    Else
        sz = "\"
    End If
    GetParentDirectory = sz
End Function

Private Function GetNameFromPath(ByVal szPath As String) As String
    On Error GoTo errHandler
    Dim sa() As String
    sa = Split(szPath, "\")
    GetNameFromPath = sa(UBound(sa))
    Exit Function
errHandler:
    GetNameFromPath = ""
End Function

Private Function GetNameFromURL(ByVal szPath As String) As String
    On Error GoTo errHandler
    Dim sa() As String
    sa = Split(szPath, "/")
    GetNameFromURL = sa(UBound(sa))
    Exit Function
errHandler:
    GetNameFromURL = ""
End Function

Private Sub InitUI()
    On Error Resume Next
    SendMessageA lvClient.hWnd, LVM_SETEXTENDEDLISTVIEWSTYLE, LVS_EX_FULLROWSELECT, -1
    SendMessageA lvFile.hWnd, LVM_SETEXTENDEDLISTVIEWSTYLE, LVS_EX_FULLROWSELECT, -1
    Drive1.Drive = Environ("HOMEDRIVE")
    Dir1.Path = Drive1.Drive
    File1.Path = Dir1.Path
End Sub

Private Sub AddClientInfo(ByRef lv As ListView, ByVal id As Long, ByVal ip As String, ByVal desc As String, _
                            ByVal status As String, ByVal hash_lo As Long, ByVal hash_hi As Long)
    Dim ltmItem As ListItem
    Set ltmItem = lv.ListItems.Add()
    ltmItem.Text = CStr(id)
    ltmItem.SubItems(1) = ip
    ltmItem.SubItems(2) = Mid(desc, 2, InStr(desc, ")") - 2)
    ltmItem.SubItems(3) = Mid(desc, InStr(desc, ")") + 1)
    ltmItem.SubItems(4) = Replace$(status, " ", "") ': MsgBox Len(ltmItem.SubItems(4))
    Dim szlo As String: szlo = Hex$(hash_lo)
    Dim szhi As String: szhi = Hex$(hash_hi)
    ltmItem.SubItems(5) = String(8 - Len(szhi), "0") & szhi & String(8 - Len(szlo), "0") & szlo
End Sub

Private Sub AddFileInfo(ByRef lv As ListView, ByRef FileInfo As BDP_FILE_INFO)
    Dim ltmItem As ListItem
    Set ltmItem = lv.ListItems.Add()
    ltmItem.Text = StrFromPtr(VarPtr(FileInfo) + 16, True)
    If FileInfo.FileSizeLow = &HFFFFFFFF And FileInfo.FileSizeLow = &HFFFFFFFF Then
        If FileInfo.FileModifyTime.Year = &HFFFF And FileInfo.FileModifyTime.Month = &HFF And FileInfo.FileModifyTime.Day = &HFF And _
            FileInfo.FileModifyTime.Hour = &HFF And FileInfo.FileModifyTime.Minute = &HFF And FileInfo.FileModifyTime.Second = &HFF And _
            FileInfo.FileModifyTime.Weekday = &HFF Then
            ltmItem.SubItems(1) = "<Drive>"
            ltmItem.SubItems(2) = "-"
        Else
            If ltmItem.Text = ".." Or ltmItem.Text = "." Then
                ltmItem.SubItems(1) = "<Directory>"
                ltmItem.SubItems(2) = ""
            Else
                ltmItem.SubItems(1) = "<Directory>"
                ltmItem.SubItems(2) = CStr(FileInfo.FileModifyTime.Year) & "-" & CStr(FileInfo.FileModifyTime.Month) & "-" & CStr(FileInfo.FileModifyTime.Day) & " " & _
                                        CStr(FileInfo.FileModifyTime.Hour) & ":" & CStr(FileInfo.FileModifyTime.Minute) & ":" & CStr(FileInfo.FileModifyTime.Second)
            End If
        End If
    Else
        If FileInfo.FileSizeHigh = 0 Then
            ltmItem.SubItems(1) = CStr(FileInfo.FileSizeLow)
        Else
            Dim szlo As String: szlo = Hex$(FileInfo.FileSizeLow)
            Dim szhi As String: szhi = Hex$(FileInfo.FileSizeHigh)
            ltmItem.SubItems(1) = CStr(CCur("&H" & szhi & String(8 - Len(szlo), "0") & szlo))
        End If
        ltmItem.SubItems(2) = CStr(FileInfo.FileModifyTime.Year) & "-" & CStr(FileInfo.FileModifyTime.Month) & "-" & CStr(FileInfo.FileModifyTime.Day) & " " & _
                                CStr(FileInfo.FileModifyTime.Hour) & ":" & CStr(FileInfo.FileModifyTime.Minute) & ":" & CStr(FileInfo.FileModifyTime.Second)
    End If
End Sub

Private Sub btnClient_Click(Index As Integer)
    Dim b As Byte
    If lvClient.ListItems.Count = 0 Then Exit Sub
    Select Case Index
        Case 0
            b = ClientConnect(CLng(lvClient.SelectedItem.Text))
            If b = 0 Then
                MsgBox "Connect client unsuccessfully.", vbCritical
            End If
        Case 1
            b = ClientDisconnect(CLng(lvClient.SelectedItem.Text))
            If b = 0 Then
                MsgBox "Disconnect client unsuccessfully.", vbCritical
            End If
        Case 2
            b = ClientShutdown(CLng(lvClient.SelectedItem.Text))
            If b = 0 Then
                MsgBox "Shutdown client unsuccessfully.", vbCritical
            End If
        Case 3
            b = ClientReboot(CLng(lvClient.SelectedItem.Text))
            If b = 0 Then
                MsgBox "Reboot client unsuccessfully.", vbCritical
            End If
        Case 4
            Dim szNewFile As String
            Dim szDefaultFile As String
            If InStr(1, lvClient.SelectedItem.SubItems(2), "WIN32-", vbTextCompare) Then
                szDefaultFile = App.Path & "\UpdateTest32.sys"
            Else
                szDefaultFile = App.Path & "\UpdateTest64.sys"
            End If
            szNewFile = InputBox("Input new binary file:", "Update", szDefaultFile)
            If StrPtr(szNewFile) Then
                b = ClientUpdate(CLng(lvClient.SelectedItem.Text), StrPtr(szNewFile))
                If b = 0 Then
                    MsgBox "Update client unsuccessfully.", vbCritical
                Else
                    MsgBox "Update client successfully.", vbInformation
                End If
            End If
        Case 5
            b = ClientUpdate(CLng(lvClient.SelectedItem.Text), 0)
            If b = 0 Then
                MsgBox "Uninstall client unsuccessfully.", vbCritical
            Else
                MsgBox "Uninstall client successfully.", vbInformation
            End If
        Case Else
    End Select
End Sub

Private Sub btnFile_Click(Index As Integer)
    Dim b As Byte
    Dim lf As String
    Dim rf As String
    Dim newName As String
    If lvClient.ListItems.Count = 0 Then Exit Sub
    Select Case Index
        Case 0
            lf = Replace(File1.Path & "\" & File1.FileName, "\\", "\")
            rf = Replace(txtFilePath.Text & "\" & File1.FileName, "\\", "\")
            b = CmdUploadFileTo(CLng(lvClient.SelectedItem.Text), StrPtr(lf), StrPtr(rf), 0)
            If b = 0 Then
                MsgBox "Upload file unsuccessfully.", vbCritical
            Else
                btnOperate_Click 0
            End If
        Case 1
            rf = Replace(txtFilePath.Text & "\" & lvFile.SelectedItem.Text, "\\", "\")
            lf = Replace(File1.Path & "\" & lvFile.SelectedItem.Text, "\\", "\")
            b = CmdDownloadFileFrom(CLng(lvClient.SelectedItem.Text), StrPtr(rf), StrPtr(lf), 0)
            If b = 0 Then
                MsgBox "Download file unsuccessfully.", vbCritical
            Else
                File1.Refresh
            End If
        Case 2
            newName = InputBox("Input directory name:", "New Directory")
            If StrPtr(newName) Then
                rf = Replace(txtFilePath.Text & "\" & newName, "\\", "\")
                b = CmdFileOperation(CLng(lvClient.SelectedItem.Text), CLIENT_FSO_CREATE_DIRECTORY, StrPtr(rf), StrPtr(""), 0)
                If b = 0 Then
                    MsgBox "Create directory unsuccessfully.", vbCritical
                Else
                    btnOperate_Click 0
                End If
            End If
        Case 3
            newName = InputBox("Input new file full path name:", "Copy")
            If StrPtr(newName) Then
                rf = Replace(txtFilePath.Text & "\" & lvFile.SelectedItem.Text, "\\", "\")
                b = CmdFileOperation(CLng(lvClient.SelectedItem.Text), CLIENT_FSO_COPY, StrPtr(rf), StrPtr(newName), 0)
                If b = 0 Then
                    MsgBox "Copy unsuccessfully.", vbCritical
                Else
                    btnOperate_Click 0
                End If
            End If
        Case 4
            rf = Replace(txtFilePath.Text & "\" & lvFile.SelectedItem.Text, "\\", "\")
            b = CmdFileOperation(CLng(lvClient.SelectedItem.Text), CLIENT_FSO_DELETE, StrPtr(rf), StrPtr(""), 0)
            If b = 0 Then
                MsgBox "Delete unsuccessfully.", vbCritical
            Else
                btnOperate_Click 0
            End If
        Case 5
            newName = InputBox("Input new name:", "Rename")
            If StrPtr(newName) Then
                newName = Replace(txtFilePath.Text & "\" & newName, "\\", "\")
                rf = Replace(txtFilePath.Text & "\" & lvFile.SelectedItem.Text, "\\", "\")
                b = CmdFileOperation(CLng(lvClient.SelectedItem.Text), CLIENT_FSO_RENAME, StrPtr(rf), StrPtr(newName), 0)
                If b = 0 Then
                    MsgBox "Rename unsuccessfully.", vbCritical
                Else
                    btnOperate_Click 0
                End If
            End If
        Case 6
            newName = InputBox("Input numerical value of file attribute constants:", "Set Attribute")
            If StrPtr(newName) Then
                rf = Replace(txtFilePath.Text & "\" & lvFile.SelectedItem.Text, "\\", "\")
                b = CmdFileOperation(CLng(lvClient.SelectedItem.Text), CLIENT_FSO_SET_ATTRIB, StrPtr(rf), StrPtr(newName), 0)
                If b = 0 Then
                    MsgBox "Set file attribute unsuccessfully.", vbCritical
                Else
                    MsgBox "Set file attribute successfully.", vbInformation
                End If
            End If
        Case 7
            Dim rv As Long
            rf = Replace(txtFilePath.Text & "\" & lvFile.SelectedItem.Text, "\\", "\")
            b = CmdFileOperation(CLng(lvClient.SelectedItem.Text), CLIENT_FSO_GET_ATTRIB, StrPtr(rf), StrPtr(""), rv)
            If b = 0 Then
                MsgBox "Query file attribute unsuccessfully.", vbCritical
            Else
                MsgBox "Attribute: " & CStr(rv), vbInformation
            End If
        Case 8
            rf = InputBox("Input URL:", "HTTP Download", btnFile(8).Tag)
            If StrPtr(rf) Then
                lf = Replace(txtFilePath.Text & "\" & GetNameFromURL(rf), "\\", "\") ': MsgBox rf, , lf
                b = CmdFileOperation(CLng(lvClient.SelectedItem.Text), CLIENT_FSO_HTTP_DOWNLOAD, StrPtr(rf), StrPtr(lf), 0)
                If b = 0 Then
                    MsgBox "Download unsuccessfully.", vbCritical
                Else
                    btnOperate_Click 0
                End If
            End If
    End Select
End Sub

Private Sub btnOperate_Click(Index As Integer)
    Dim b As Byte
    If lvClient.ListItems.Count = 0 Then Exit Sub
    Select Case Index
        Case 0
            'A lazy way: assume the maximum file count is 16384...
            Dim i, sc As Long: sc = 16384
            Dim fs(16383) As BDP_FILE_INFO
            b = CmdQueryDirectory(CLng(lvClient.SelectedItem.Text), StrPtr(txtFilePath.Text), VarPtr(fs(0)), sc)
            If b = 0 Then
                txtFilePath.Text = GetParentDirectory(txtFilePath.Text)
                MsgBox "Query directory unsuccessfully.", vbCritical
            Else
                lvFile.ListItems.Clear
                For i = 0 To sc - 1
                    AddFileInfo lvFile, fs(i)
                Next
            End If
        Case 1
            txtFilePath.Text = GetParentDirectory(txtFilePath.Text)
            btnOperate_Click 0
        Case 2
            Dim baReturn(4095) As Byte
            If CmdSystemShell(CLng(lvClient.SelectedItem.Text), StrPtr(txtCMD.Text), VarPtr(baReturn(0)), 4096) Then
                txtCmdRet.Text = "COMMAND: " & txtCMD.Text & vbCrLf & sz2bstr(baReturn)
            Else
                txtCmdRet.Text = "COMMAND: " & txtCMD.Text & vbCrLf & "Execute system shell unsuccessfully."
            End If
        Case 3
            txtCmdRet.Text = ""
        Case 4
            If InStr(txtCfgFile.Text, "\") = 0 Then
                txtCfgText.Text = ReadText(App.Path & "\" & txtCfgFile.Text)
            Else
                txtCfgText.Text = ReadText(txtCfgFile.Text)
            End If
            txtCfgText.Tag = ""
            txtCfgText.BackColor = &H80000005
        Case 5
            Dim szFile As String
            If InStr(txtCfgFile.Text, "\") = 0 Then
                szFile = App.Path & "\" & txtCfgFile.Text
            Else
                szFile = txtCfgFile.Text
            End If
            If txtCfgText.Tag <> "" Then
                If MsgBox("Configuration file has been modified, do you want to save?", vbQuestion + vbYesNo) = vbYes Then
                    SaveText szFile, txtCfgText.Text
                    txtCfgText.Tag = ""
                    txtCfgText.BackColor = &H80000005
                End If
            End If
            b = ClientConfig(CLng(lvClient.SelectedItem.Text), CLIENT_CONFIG_SERVER, StrPtr(szFile))
            If b = 0 Then
                MsgBox "Configure client unsuccessfully.", vbCritical
            Else
                MsgBox "Configure client successfully.", vbInformation
            End If
        Case 6, 10, 14
            Dim bType As Byte
            Dim ppNames As Long
            Dim CurrentName As String
            If Index = 6 Then
                bType = CLIENT_AUTORUN_TYPE_SYS
                lstDrv.Clear
            ElseIf Index = 10 Then
                bType = CLIENT_AUTORUN_TYPE_EXE
                lstExe.Clear
            Else
                bType = CLIENT_AUTORUN_TYPE_DLL
                lstDLL.Clear
            End If
            If CmdQueryAutoRunBin(CLng(lvClient.SelectedItem.Text), bType, VarPtr(ppNames)) Then
                CurrentName = StrFromPtr(ppNames, True)
                If CurrentName <> CLIENT_AUTORUN_EMPTY Then
                    Do While 1
                        CurrentName = StrFromPtr(ppNames, True)
                        If Len(CurrentName) = 0 Then Exit Do
                        If Index = 6 Then
                            lstDrv.AddItem CurrentName
                        ElseIf Index = 10 Then
                            lstExe.AddItem CurrentName
                        Else
                            lstDLL.AddItem CurrentName
                        End If
                        ppNames = ppNames + Len(CurrentName) * 2 + 2
                    Loop
                End If
            Else
                MsgBox "Query auto-run information unsuccessfully.", vbCritical
            End If
        Case 7, 11, 15
            Dim newName As String
            Dim newFile As String
            Dim newParam As String
            Dim defPath As String
            Dim defParam As String
            If Index = 7 Then
                bType = CLIENT_AUTORUN_TYPE_SYS
                defPath = "c:\windows\system32\drivers\usb8023.sys"
            ElseIf Index = 11 Then
                bType = CLIENT_AUTORUN_TYPE_EXE
                defPath = "c:\windows\system32\write.exe"
                defParam = "c:\windows\win.ini"
            Else
                bType = CLIENT_AUTORUN_TYPE_DLL
                defPath = "c:\windows\system32\shell32.dll"
                defParam = "Control_RunDLL intl.cpl,,1"
            End If
            newFile = InputBox("Input file on the client:", "Add auto-run", defPath)
            If StrPtr(newFile) Then
                newName = GetNameFromPath(newFile): newName = Left$(newName, 19) 'max-name-len=19
                If Index <> 7 Then
                    newParam = InputBox("Input parameter(s):", "Add auto-run", defParam)
                End If
                If CmdAddAutoRunBin(CLng(lvClient.SelectedItem.Text), bType, StrPtr(newName), StrPtr(newFile), StrPtr(newParam)) Then
                    If Index = 7 Then
                        btnOperate_Click 6
                    ElseIf Index = 11 Then
                        btnOperate_Click 10
                    Else
                        btnOperate_Click 14
                    End If
                Else
                    MsgBox "Add auto-run unsuccessfully.", vbCritical
                End If
            End If
        Case 8, 12, 16
            If Index = 8 Then
                bType = CLIENT_AUTORUN_TYPE_SYS
                newFile = lstDrv.Text
            ElseIf Index = 12 Then
                bType = CLIENT_AUTORUN_TYPE_EXE
                newFile = lstExe.Text
            Else
                bType = CLIENT_AUTORUN_TYPE_DLL
                newFile = lstDLL.Text
            End If
            If StrPtr(newFile) Then
                If CmdDelAutoRunBin(CLng(lvClient.SelectedItem.Text), bType, StrPtr(newFile)) Then
                    If Index = 8 Then
                        btnOperate_Click 6
                    ElseIf Index = 12 Then
                        btnOperate_Click 10
                    Else
                        btnOperate_Click 14
                    End If
                Else
                    MsgBox "Delete auto-run unsuccessfully.", vbCritical
                End If
            End If
        Case 9, 13, 17
            If Index = 9 Then
                bType = CLIENT_AUTORUN_TYPE_SYS
            ElseIf Index = 13 Then
                bType = CLIENT_AUTORUN_TYPE_EXE
            Else
                bType = CLIENT_AUTORUN_TYPE_DLL
            End If
            If CmdClearAutoRunBin(CLng(lvClient.SelectedItem.Text), bType) Then
                If Index = 9 Then
                    btnOperate_Click 6
                ElseIf Index = 13 Then
                    btnOperate_Click 10
                Else
                    btnOperate_Click 14
                End If
            Else
                MsgBox "Clear auto-run unsuccessfully.", vbCritical
            End If
    End Select
End Sub

Private Sub Dir1_Change()
    On Error Resume Next
    File1.Path = Dir1.Path
End Sub

Private Sub Dir1_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    If Button = 2 Then
        Dir1.Refresh
    End If
End Sub

Private Sub Drive1_Change()
    On Error Resume Next
    Dir1.Path = Drive1.Drive
End Sub

Private Sub File1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    If Button = 2 Then
        File1.Refresh
    End If
End Sub

Private Sub Form_Initialize()
    Dim b As Byte
    b = init(9999) ': MsgBox b, , "init"
    If b = 0 Then
        MsgBox "Initialization failed.", vbCritical
        ExitProcess 0
    End If
End Sub

Private Sub Form_Load()
    InitUI
End Sub

Private Sub Form_Unload(Cancel As Integer)
    Dim b As Byte
    b = uninit() ': MsgBox b, , "uninit"
    ExitProcess 0
End Sub

Private Sub Frame1_DblClick()
    Dim i As Long, hash As Currency
    If vbYes = MsgBox("This operation may take a long time, do you want to continue?", vbQuestion + vbYesNo, "Test Clients") Then
        For i = 1 To lvClient.ListItems.Count
            ClientTest CLng(lvClient.ListItems(i).Text), hash
        Next
        MsgBox "Finished.", vbInformation, "Test Clients"
    End If
End Sub

Private Sub lvFile_DblClick()
    If lvFile.ListItems.Count = 0 Then Exit Sub
    If Trim$(txtFilePath.Text) = "\" Then txtFilePath.Text = ""
    If lvFile.SelectedItem.SubItems(1) = "<Directory>" Or _
        lvFile.SelectedItem.SubItems(1) = "<Drive>" Or _
        lvFile.SelectedItem.SubItems(1) = "" Then
        txtFilePath.Text = txtFilePath.Text & "\" & lvFile.SelectedItem.Text
        If Left$(txtFilePath.Text, 1) = "\" Then
            txtFilePath.Text = Mid$(txtFilePath.Text, 2)
        End If
        txtFilePath.Text = Replace(txtFilePath.Text, "\\", "\")
        If Right$(txtFilePath.Text, 3) = "\.." Then
            txtFilePath.Text = Left$(txtFilePath.Text, Len(txtFilePath.Text) - 3)
            txtFilePath.Text = GetParentDirectory(txtFilePath.Text)
        End If
        btnOperate_Click 0
    Else
        Dim rv As Currency
        Dim szParam As String
        Dim szDefault As String
        Dim szRemoteFile As String
        szRemoteFile = txtFilePath.Text & "\" & lvFile.SelectedItem.Text
        szRemoteFile = Replace(szRemoteFile, "\\", "\")
        If LCase$(Right$(lvFile.SelectedItem.Text, 4)) = ".exe" Then
            If InStr(lvFile.SelectedItem.Text, "write.exe") Then
                szDefault = "c:\windows\win.ini"
            End If
            szParam = InputBox("Input program parameter(s):", lvFile.SelectedItem.Text, szDefault)
            If StrPtr(szParam) Then
                szRemoteFile = szRemoteFile & " " & szParam
                If CmdExecuteBinary(CLng(lvClient.SelectedItem.Text), StrPtr(szRemoteFile), SW_SHOW, 0, rv) = 0 Then
                    MsgBox "Run program unsuccessfully.", vbCritical
                Else
                    MsgBox "Run program successfully.", vbInformation, "PID = " & CStr(CLng("&H" & i64toa(rv)))
                End If
            End If
        ElseIf LCase$(Right$(lvFile.SelectedItem.Text, 4)) = ".sys" Then
            If vbYes = MsgBox("Do you want to load the driver?", vbYesNo + vbQuestion, lvFile.SelectedItem.Text) Then
                If CmdExecuteBinary(CLng(lvClient.SelectedItem.Text), StrPtr(szRemoteFile), CLIENT_RUN_SYS_P1, CLIENT_RUN_SYS_P2, rv) = 0 Then
                    MsgBox "Load driver unsuccessfully.", vbCritical
                Else
                    MsgBox "Load driver successfully.", vbInformation, "DriverObject = " & i64toa(rv)
                End If
            End If
        ElseIf LCase$(Right$(lvFile.SelectedItem.Text, 4)) = ".dll" Then
            If InStr(lvFile.SelectedItem.Text, "shell32.dll") Then
                szDefault = "Control_RunDLL intl.cpl,,1"
            End If
            szParam = InputBox("Input export function name and parameter(s):", lvFile.SelectedItem.Text, szDefault)
            If StrPtr(szParam) Then
                szRemoteFile = szRemoteFile & "," & szParam
                If CmdExecuteBinary(CLng(lvClient.SelectedItem.Text), StrPtr(szRemoteFile), CLIENT_RUN_DLL_P1, CLIENT_RUN_DLL_P2, rv) = 0 Then
                    MsgBox "Load DLL unsuccessfully.", vbCritical
                Else
                    MsgBox "Load DLL successfully.", vbInformation, "RunDll32-PID = " & CStr(CLng("&H" & i64toa(rv)))
                End If
            End If
        End If
    End If
End Sub

Private Sub Option1_Click()
    Timer1.Enabled = True
End Sub

Private Sub Option2_Click()
    Timer1.Enabled = False
End Sub

Private Sub Timer1_Timer()
    Dim c As Long, i As Long, lv_sel As Long
    Dim ci(SERVER_MAX_CLIENTS - 1) As CLIENT_INFO
    c = ClientList(VarPtr(ci(0))): Frame1.Caption = "Client: " & CStr(c)
    If c > 0 Then
        'get current selection of listview
        lv_sel = 0
        For i = 1 To lvClient.ListItems.Count
            If lvClient.ListItems(i).Selected = True Then
                lv_sel = i
                Exit For
            End If
        Next
        'clear old items
        lvClient.ListItems.Clear
        'add latest items
        For i = 0 To c - 1
            AddClientInfo lvClient, ci(i).id, sz2bstr(ci(i).szAddr), sz2bstr(ci(i).szDescription), _
                            sz2bstr(ci(i).szStatus), ci(i).hash_low, ci(i).hash_high
        Next
        'set selection
        If lv_sel Then
            If lv_sel > lvClient.ListItems.Count Then
                lv_sel = lvClient.ListItems.Count
            End If
            If lv_sel Then
                lvClient.ListItems.Item(lv_sel).Selected = True
            End If
        End If
    End If
End Sub

Private Sub txtCfgText_Change()
    txtCfgText.Tag = "."
    txtCfgText.BackColor = &H80000018
End Sub
