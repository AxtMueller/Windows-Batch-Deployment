/*
	Author: Axt Müller
	Description: Windows-Batch-Deployment DLL function test.
*/
#include <stdio.h>
#include <Windows.h>
#include "test.h"

#pragma warning (disable:4996)

//If this macro is enbled, the test code will execute continuously for each client.
//#define CLIENT_STABILITY_TEST

//If this macro is enbled, the program will not the update the binary file of the client.
//#define DO_NOT_UPDATE_CLIENT

//################################################################################
// global definitions
//################################################################################
#define MALLOC(l) VirtualAlloc(NULL,(l),MEM_COMMIT,PAGE_READWRITE)
#define FREE(p) VirtualFree((p),0,MEM_RELEASE)
#define INVERVAL 4096

//################################################################################
// global variables
//################################################################################
CHAR g_szLatestClientVersion[16] = {0};
WCHAR g_AppPath[MAX_PATH] = {0};
ULONG64 g_Hash[MAX_CONNECT_REQUEST] = {0};
ULONG g_HashCount = 0;

//################################################################################
// functions
//################################################################################
#ifndef CLIENT_STABILITY_TEST
//Check if the specific HASH exists in the list
BOOLEAN CheckHash(ULONG64 hash)
{
	ULONG i;
	BOOLEAN b = FALSE;
	for(i=0;i<g_HashCount;i++)
	{
		if(hash==g_Hash[i])
		{
			b = TRUE;
			break;
		}
	}
	return b;
}

//Add client a HASH to the list.
void AddHash(ULONG64 hash)
{
	if(g_HashCount<MAX_CONNECT_REQUEST)
	{
		g_Hash[g_HashCount] = hash;
		g_HashCount++;
	}
}
#endif

DWORD FunctionTest(void *parameter)
{
	PCLIENT_INFO p = (PCLIENT_INFO)parameter;
	ULONG wt = 0;
	ULONG64 ClientVersion = 0;
	char szClientVersion[16] = {0};
	//Wait for the client connection to complete, it needs some time!
	while(wt<INVERVAL*2)
	{
		Sleep(INVERVAL/4);wt+=INVERVAL/4;
		_ClientTest(p->id, &ClientVersion);
		if(ClientVersion)
		{
			printf("[%04ld]The client version: %ld.\n",p->id,ClientVersion);
			_i64toa(ClientVersion,szClientVersion,10);
			break;
		}
	}
	//If ClientVersion is 0, it means that the connection was not established successfully.
	if(!ClientVersion)
	{
		printf("[%04ld]The client did not connect.\n",p->id);
		goto __exit;
	}
#ifdef CLIENT_STABILITY_TEST
	while(1)
#endif
	{
		//======================================================================
		//Client configuration (ClientConfig)
		//======================================================================
		WCHAR file[MAX_PATH] = {0};
		WCHAR path[MAX_PATH] = {0};
        GetModuleFileNameW(0,path,MAX_PATH);
        for(SIZE_T i=wcslen(path)-1;i>=0;i--)
        {
            if(path[i]=='\\')
            {
                path[i+1]='\0';
                break;
            }
        }
		wcscpy(file, path);
		wcscat(file, L"test.cfg");
		if(_ClientConfig(p->id, CLIENT_CONFIG_SERVER, file))
		{
			printf("[%04ld]Configure client successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Configure client unsuccessfully.\n",p->id);
			goto __exit;
		}
		//======================================================================
		//Client update (ClientUpdate)
		//======================================================================
		wcscpy(file, path);
#ifndef DO_NOT_UPDATE_CLIENT
		//Update the client binary file if new client binary is available.
		if(g_szLatestClientVersion[0]!=0)
		{
			if(strstr(p->szDescription,"(WIN32-"))
			{
				wcscat(file, L"LatestClient32.sys");
			}
			else
			{
				wcscat(file, L"LatestClient64.sys");
			}
			if(stricmp(g_szLatestClientVersion, szClientVersion))
			{
				printf("[%04ld]THE CLIENT NEED UPDATE.\n",p->id);
				if(_ClientUpdate(p->id,file))
				{
					printf("[%04ld]Update client successfully.\n",p->id);
					strcpy(szClientVersion, g_szLatestClientVersion);
				}
				else
				{
					printf("[%04ld]Update client unsuccessfully.\n",p->id);
					goto __exit;
				}
			}
			else
			{
				printf("[%04ld]THE CLIENT DOES NOT NEED UPDATE.\n",p->id);
			}
		}
		else
		{
			//Update the client binary file anyway, for testing purposes only.
			if(strstr(p->szDescription,"(WIN32-"))
			{
				wcscat(file, L"UpdateTest32.sys");
			}
			else
			{
				wcscat(file, L"UpdateTest64.sys");
			}
			if(_ClientUpdate(p->id,file))
			{
				printf("[%04ld]Test update successfully.\n",p->id);
				strcpy(szClientVersion, g_szLatestClientVersion);
			}
			else
			{
				printf("[%04ld]Test update unsuccessfully.\n",p->id);
				goto __exit;
			}
		}
#endif
		//======================================================================
		//File transmission (CmdQueryDirectory + CmdUploadFileTo + CmdDownloadFileFrom)
		//======================================================================
		BOOLEAN bNeedExit = 0;
		ULONG dwFiles = 0;
		WCHAR wsDir[MAX_PATH] = L"C:\\windows\\";
		//Query file of WINDOWS directory.
		if(_CmdQueryDirectory(p->id,wsDir,NULL,&dwFiles))
		{
			printf("[%04ld]Enumerate directory successfully, number of files: %ld.\n",p->id, dwFiles);
			//Allocate file buffer
			PBDP_FILE_INFO pFiles = (PBDP_FILE_INFO)MALLOC(sizeof(BDP_FILE_INFO) * dwFiles);
			if(pFiles)
			{
				RtlZeroMemory(pFiles, sizeof(BDP_FILE_INFO) * dwFiles);
				if(_CmdQueryDirectory(p->id,wsDir,pFiles,&dwFiles))
				{
					for(ULONG i=0;i<dwFiles;i++)
					{
						if(pFiles[i].FileSize==0xFFFFFFFFFFFFFFFF)
							printf("[%04ld][D](%ld): %S.\n",p->id, i, pFiles[i].FileName);
						else
							printf("[%04ld][F](%ld): %S.\n",p->id, i, pFiles[i].FileName);
					}
				}
				else
				{
					printf("[%04ld]Enumerate directory unsuccessfully.\n",p->id);
					bNeedExit = 1;
				}
				FREE(pFiles);
			}
			if(bNeedExit){goto __exit;}
		}
		else
		{
			printf("[%04ld]Query directory file count unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Download NTOSKRNL file.
		WCHAR wsRF[MAX_PATH] = L"c:\\windows\\system32\\ntoskrnl.exe";
		WCHAR wsLF[MAX_PATH] = {0};swprintf(wsLF,MAX_PATH,L"c:\\[%S]ntoskrnl.exe",p->szDescription);
		if(_CmdDownloadFileFrom(p->id,wsRF,wsLF,NULL))
		{
			printf("[%04ld]Download file successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Download file unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Upload test DLL file.
		wcscpy(wsRF,L"c:\\test.dll");
		wcscpy(wsLF,g_AppPath);
		if(strstr(p->szDescription,"(WIN32-"))
		{
			wcscat(wsLF,L"UserDemo32.dll");
		}
		else
		{
			wcscat(wsLF,L"UserDemo64.dll");
		}
		if(_CmdUploadFileTo(p->id,wsLF,wsRF,NULL))
		{
			printf("[%04ld]Upload file successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Upload file unsuccessfully.\n",p->id);
			goto __exit;
		}
		//======================================================================
		//File operation (CmdFileOperation)
		//======================================================================
		ULONG AttrVal;
		//Clean up last test
		_CmdFileOperation(p->id,CLIENT_FSO_DELETE,L"C:\\22222222",NULL,NULL);
		//Create directory.
		if(_CmdFileOperation(p->id,CLIENT_FSO_CREATE_DIRECTORY,L"c:\\00000000",NULL,NULL))
		{
			printf("[%04ld]Create directory successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Create directory unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Create file (file content can be NULL).
		if(_CmdFileOperation(p->id,CLIENT_FSO_CREATE_FILE,L"c:\\00000000\\test.TXT",L"Hello,World!",NULL))
		{
			printf("[%04ld]Create file successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Create file unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Copy file or directory.
		if(_CmdFileOperation(p->id,CLIENT_FSO_COPY,L"C:\\WINDOWS\\WEB",L"C:\\11111111",NULL))
		{
			printf("[%04ld]Copy directory successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Copy directory unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Rename file or directory.
		if(_CmdFileOperation(p->id,CLIENT_FSO_RENAME,L"C:\\11111111",L"C:\\22222222",NULL))
		{
			printf("[%04ld]Rename directory successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Rename directory unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Delete file or directory.
		if(_CmdFileOperation(p->id,CLIENT_FSO_DELETE,L"C:\\00000000",NULL,NULL))
		{
			printf("[%04ld]Delete directory successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Delete directory unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Set attribute of file or directory (you need to convert the file attribute value to a string).
		WCHAR wsAttr[10] = {0}; 
		_itow(FILE_ATTRIBUTE_HIDDEN,wsAttr,10);
		if(_CmdFileOperation(p->id,CLIENT_FSO_SET_ATTRIB,L"C:\\22222222",wsAttr,NULL))
		{
			printf("[%04ld]Set file attribute successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Set file attribute unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Query attribute of file or directory.
		if(_CmdFileOperation(p->id,CLIENT_FSO_GET_ATTRIB,L"C:\\22222222",NULL,&AttrVal))
		{
			printf("[%04ld]Query file attribute successfully: 0x%X.\n",p->id,AttrVal);
		}
		else
		{
			printf("[%04ld]Query file attribute unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Download file via HTTP link.
		if(_CmdFileOperation(p->id,CLIENT_FSO_HTTP_DOWNLOAD,L"http://libevent.org/sm-web-appnexus-logo.png",L"C:\\22222222\\logo.png",&AttrVal))
		{
			printf("[%04ld]Download file successfully: 0x%X.\n",p->id,AttrVal);
		}
		else
		{
			printf("[%04ld]Download file unsuccessfully.\n",p->id);
			goto __exit;
		}
		//======================================================================
		//Binary execution (CmdExecuteBinary)
		//======================================================================
		ULONG64 RetVal;
		//You must use the full path name of the driver file.
		if(_CmdExecuteBinary(p->id,L"c:\\windows\\system32\\drivers\\usb8023.sys",CLIENT_RUN_SYS_P1,CLIENT_RUN_SYS_P2,&RetVal))
		{
			printf("[%04ld]Load SYS successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Load SYS unsuccessfully.\n",p->id);
		}
		//You can add command line arguments after the program path name.
		if(_CmdExecuteBinary(p->id,L"c:\\windows\\system32\\taskmgr.exe",SW_SHOWMINIMIZED,0,&RetVal))
		{
			//NOTE1: If UAC is enabled, TaskMgr will not run successfully, because it requires administrative privileges.
			//NOTE2: If you add CLIENT_BYPASS_UAC_UNSAFE to the third parameter, 
			//       it can create a process that requires administrative privileges, 
			//       but it may cause some systems to crash after multiple (>10) uses.
			//       DEMO: _CmdExecuteBinary(p->id,L"reg add HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System /v EnableLUA /t REG_DWORD /d 0 /f",SW_HIDE+CLIENT_BYPASS_UAC_UNSAFE,0,&RetVal);
			//NOTE3: You can use the code of the UACME project to bypass UAC in your program, it will not cause the system to crash. 
			printf("[%04ld]Run EXE successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Run EXE unsuccessfully.\n",p->id);
		}
		//You must write an exported function name after the DLL path name (separated by comma), otherwise the DLL will not be loaded.
		if(_CmdExecuteBinary(p->id,L"c:\\test.dll,0",CLIENT_RUN_DLL_P1,CLIENT_RUN_DLL_P2,&RetVal))
		{
			printf("[%04ld]Load DLL successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Load DLL unsuccessfully.\n",p->id);
		}
		//======================================================================
		//System shell (CmdSystemShell)
		//======================================================================
		char cmdtxt[1024] = {0};
		//If the command does not complete within a certain time, the function will return with empty string.
		if(_CmdSystemShell(p->id,L"type c:\\windows\\win.ini",cmdtxt,1024))
		{
			printf("[%04ld]Run CMD successfully.\n",p->id);
			printf("%s\n\n",cmdtxt);
		}
		else
		{
			printf("[%04ld]Run CMD unsuccessfully.\n",p->id);
		}
		//======================================================================
		//Auto-Run operation (CmdAddAutoRunBin + CmdDelAutoRunBin + CmdQueryAutoRunBin + CmdClearAutoRunBin)
		//======================================================================
		//Add binaries to Auto-Run list.
		PWCHAR names = NULL;
		if(_CmdAddAutoRunBin(p->id,CLIENT_AUTORUN_TYPE_SYS,L"USB8023",L"c:\\windows\\system32\\drivers\\USB8023.SYS",NULL))
		{
			printf("[%04ld]Add auto-run successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Add auto-run unsuccessfully.\n",p->id);
			goto __exit;
		}
		if(_CmdAddAutoRunBin(p->id,CLIENT_AUTORUN_TYPE_SYS,L"BRIDGE",L"c:\\windows\\system32\\drivers\\BRIDGE.SYS",NULL))
		{
			printf("[%04ld]Add auto-run successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Add auto-run unsuccessfully.\n",p->id);
			goto __exit;
		}
		if(_CmdAddAutoRunBin(p->id,CLIENT_AUTORUN_TYPE_EXE,L"WRITE",L"c:\\windows\\system32\\WRITE.EXE",L"c:\\windows\\win.ini"))
		{
			printf("[%04ld]Add auto-run successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Add auto-run unsuccessfully.\n",p->id);
			goto __exit;
		}
		if(_CmdAddAutoRunBin(p->id,CLIENT_AUTORUN_TYPE_DLL,L"SHELL32",L"c:\\windows\\system32\\SHELL32.DLL",L"Control_RunDLL intl.cpl,,1"))
		{
			printf("[%04ld]Add auto-run successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Add auto-run unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Enumerate Auto-Run list.
		if(_CmdQueryAutoRunBin(p->id,CLIENT_AUTORUN_TYPE_SYS,&names))
		{
			PWCHAR ptr = names;
			while(1)
			{
				if(wcslen(ptr)==0)break;
				printf("[%04ld][EnumAutoRun1]%S.\n",p->id,ptr);
				ptr = ptr + wcslen(ptr)+1;
			}
			FREE(names);
		}
		else
		{
			printf("[%04ld]Query auto-run unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Delete USB8023 from Auto-Run list.
		if(_CmdDelAutoRunBin(p->id,CLIENT_AUTORUN_TYPE_SYS,L"USB8023"))
		{
			printf("[%04ld]Delete auto-run successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Delete auto-run unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Enumerate Auto-Run list again to show the effect.
		if(_CmdQueryAutoRunBin(p->id,CLIENT_AUTORUN_TYPE_SYS,&names))
		{
			PWCHAR ptr = names;
			while(1)
			{
				if(wcslen(ptr)==0)break;
				printf("[%04ld][EnumAutoRun2]%S.\n",p->id,ptr);
				ptr = ptr + wcslen(ptr)+1;
			}
			FREE(names);
		}
		else
		{
			printf("[%04ld]Query auto-run unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Delete everything from Auto-Run list.
		if(_CmdClearAutoRunBin(p->id,CLIENT_AUTORUN_TYPE_SYS))
		{
			printf("[%04ld]Clear auto-run successfully.\n",p->id);
		}
		else
		{
			printf("[%04ld]Clear auto-run unsuccessfully.\n",p->id);
			goto __exit;
		}
		//Enumerate Auto-Run list again to show the effect.
		if(_CmdQueryAutoRunBin(p->id,CLIENT_AUTORUN_TYPE_SYS,&names))
		{
			PWCHAR ptr = names;
			while(1)
			{
				if(wcslen(ptr)==0)break;
				printf("[%04ld][EnumAutoRun3]%S.\n",p->id,ptr);
				ptr = ptr + wcslen(ptr)+1;
			}
			FREE(names);
		}
		else
		{
			printf("[%04ld]Query auto-run unsuccessfully.\n",p->id);
			goto __exit;
		}
		Sleep(INVERVAL);
	}
__exit:
	printf("[%04ld]Thread exited.\n",p->id);
	//Disconnect the client and exit thread.
	_ClientDisconnect(p->id);
	FREE(p);
	ExitThread(0);
}

void main()
{
	PCLIENT_INFO g_ci = (PCLIENT_INFO)MALLOC(MAX_CONNECT_REQUEST*sizeof(CLIENT_INFO));
	if(!g_ci)
	{
		puts("Allocate memory unsuccessfully.");
		goto __exit;
	}
	//Query program path.
	if(GetModuleFileNameW(0, g_AppPath, MAX_PATH))
	{
		size_t i, c = wcslen(g_AppPath);
		for(i=c-1; i>=0; i--)
		{
			if(g_AppPath[i]==L'\\')
			{
				g_AppPath[i+1]=L'\0';
				break;
			}
		}
	}
	else
	{
		puts("Query program path unsuccessfully.");
		goto __exit;
	}
	//Initialize DLL.
	if(InitializeApis())
	{
#ifndef DO_NOT_UPDATE_CLIENT
		char szLatestServerVersion[16] = {0}, szCurrentServerVersion[16] = {0};
		if(_UpdateClient(g_szLatestClientVersion, "LatestClient32.sys", "LatestClient64.sys"))
		{
			printf("Latest Client Version: %s\n", g_szLatestClientVersion);
		}
		else
		{
			puts("Check client update unsuccessfully!");
		}
		if(_UpdateServer(szCurrentServerVersion, szLatestServerVersion, "LatestServer32.dll", "LatestServer64.dll"))
		{
			printf("Latest Server Version: %s\n", szLatestServerVersion);
			printf("Current Server Version: %s\n", szCurrentServerVersion);
			if(stricmp(szLatestServerVersion, szCurrentServerVersion)==0)
			{
				puts("The server DLL is up to date.");
			}
			else
			{
				puts("The server DLL needs to be updated!");
			}
		}
		else
		{
			puts("Check server update unsuccessfully!");
		}
#endif
		//Initialize connection.
		if(_init(9999))
		{
			while(1)
			{
				//Query clients.
				ULONG i, c = _ClientList(g_ci);
				if(c)
				{
					for(i=0;i<c;i++)
					{
						//Check the clients that wait for connection.
						if(_strnicmp(g_ci[i].szStatus,CLIENT_STATUS_ONLINE,strlen(CLIENT_STATUS_ONLINE))==0)
						{
							BOOLEAN bNeedConnect = TRUE;
#ifndef CLIENT_STABILITY_TEST
							//If the client is not in the list, add it to the list and let it connect. Otherwise, ignore it.
							if(CheckHash(g_ci[i].hash))
							{
								bNeedConnect = FALSE;
							}
							else
							{
								AddHash(g_ci[i].hash);
							}
#endif
							if(bNeedConnect)
							{
								printf("NEW: %04ld %016I64X %s %s\n", g_ci[i].id, g_ci[i].hash, 
																		g_ci[i].szAddr, 
																		g_ci[i].szDescription);
								//Send connection flag to the client, when the client gets the flag, it will connect to the serer.
								if(_ClientConnect(g_ci[i].id))
								{
									PCLIENT_INFO pc = (PCLIENT_INFO)MALLOC(sizeof(CLIENT_INFO));
									if(pc)
									{
										HANDLE h;
										memcpy(pc, &g_ci[i], sizeof(CLIENT_INFO));ULONG tid = 0;
										h = CreateThread(NULL,0,(LPTHREAD_START_ROUTINE)FunctionTest,pc,0,&tid);
										if(h)
										{
											//printf("TID: %ld\n",tid);
											CloseHandle(h);
										}
									}
								}
							}
						}
					}
				}
				RtlZeroMemory(g_ci,sizeof(g_ci));
				Sleep(INVERVAL);
			}
			//Clear rubbish.
			_uninit();
		}
		else
		{
			puts("Initialize connection unsuccessfully.");
		}
	}
	else
	{
		puts("Loading DLL unsuccessfully.");
	}
__exit:
	if(g_ci)
	{
		FREE(g_ci);
	}
	system("pause");
}