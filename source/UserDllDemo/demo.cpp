#include <Windows.h>

#pragma warning(disable:4996)
#pragma comment(lib,"user32.lib")

typedef int (WINAPI *MSGBOXAAPI)
(
	IN HWND hWnd, 
	IN LPCSTR lpText, 
	IN LPCSTR lpCaption, 
	IN UINT uType, 
	IN WORD wLanguageId, 
	IN DWORD dwMilliseconds
);

int MessageBoxTimeoutA
(	
	HWND hWnd, 
	LPCSTR lpText, 
	LPCSTR lpCaption, 
	UINT uType, 
	WORD wLanguageId, 
	DWORD dwMilliseconds
)
{
	static MSGBOXAAPI pfnMessageBoxTimeoutA = NULL;
	if (!pfnMessageBoxTimeoutA)
	{
		HMODULE hUser32 = LoadLibraryW(L"user32.dll");
		if (hUser32)
		{
			pfnMessageBoxTimeoutA = (MSGBOXAAPI)GetProcAddress(hUser32, "MessageBoxTimeoutA");
		}
	}
	if (pfnMessageBoxTimeoutA)
	{
		return pfnMessageBoxTimeoutA(hWnd, lpText, lpCaption, uType, wLanguageId, dwMilliseconds);
	}
	else
	{
		return 0;
	}
}

#define I_DO_NOT_WANT_TO_EXPORT_FUNCTION
#ifndef I_DO_NOT_WANT_TO_EXPORT_FUNCTION
extern "C" __declspec(dllexport) int rundll32()
{
	return MessageBoxTimeoutA(0,0,__FUNCTION__,0,0,3000);
}
#endif

BOOL WINAPI DllMain
(
	_In_ HINSTANCE hinstDLL,
	_In_ DWORD     fdwReason,
	_In_ LPVOID    lpvReserved
)
{
	if(fdwReason==DLL_PROCESS_ATTACH)
	{
		MessageBoxTimeoutA(0,0,__FUNCTION__,0,0,USN_PAGE_SIZE);
		//if you do not want RUNDLL32.EXE to call an export function,
		//you need to patch the "user32!MessageBoxW" function, 
		//otherwise RUNDLL32.EXE will show an error message.
#ifdef I_DO_NOT_WANT_TO_EXPORT_FUNCTION
		DWORD fp;
		if(VirtualProtect(MessageBoxW,3,PAGE_EXECUTE_READWRITE,&fp))
		{
			if(sizeof(void*)>4)
			{
				memset(MessageBoxW,0xC3,1);
			}
			else
			{
				UCHAR code[] = {0x31,0xC0,0xC3};
				memcpy(MessageBoxW,code,3);
			}
			VirtualProtect(MessageBoxW,10,fp,&fp);
		}
#endif
	}
	return TRUE;
}