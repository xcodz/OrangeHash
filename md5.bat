@echo off
:: md5.bat — print only the MD5 for a file or a literal string
:: Usage:
::   md5 abc
::   md5 "hello world"
::   md5 "C:\path\to\file.ext"
::   md5 -h   (show help)

setlocal EnableExtensions EnableDelayedExpansion

if "%~1"=="" (
  call :ShowHelp
  exit /b 1
)

if /i "%~1"=="-h" (
  call :ShowHelp
  exit /b 0
)

if /i "%~1"=="--help" (
  call :ShowHelp
  exit /b 0
)

:: If the single argument is an existing file, hash the file; otherwise hash the literal string.
if exist "%~1" (
  call :HashFile "%~1" || exit /b 2
) else (
  call :HashString "%~1" || exit /b 3
)

echo(!HASH!
exit /b 0

:: ---------------------- helpers ----------------------

:ShowHelp
>&2 echo Usage:
>&2 echo   md5 ^<string^>
>&2 echo   md5 "string with spaces"
>&2 echo   md5 "C:\path\to\file.ext"
>&2 echo   md5 -h ^| --help
>&2 echo.
>&2 echo Prints only the 32-character lowercase MD5 hash.
exit /b 0

:HashString
:: Write the literal (arg 1) into a temp file, then reuse :HashFile
set "TMP=%TEMP%\md5_%RANDOM%_%RANDOM%.txt"
> "%TMP%" <nul set /p ="%~1"
call :HashFile "%TMP%"
del /q "%TMP%" >nul 2>&1
exit /b 0

:HashFile
set "HASH="

:: Run certutil and grab the FIRST non-empty line after the header.
for /f "usebackq skip=1 tokens=* delims=" %%L in (`certutil -hashfile "%~1" MD5`) do (
  if not "%%L"=="" (
    set "HASH=%%L"
    goto :got
  )
)
:got

if not defined HASH exit /b 1

:: Remove spaces (certutil prints spaced hex bytes)
set "HASH=!HASH: =!"

:: Lowercase A-F
set "HASH=!HASH:A=a!"
set "HASH=!HASH:B=b!"
set "HASH=!HASH:C=c!"
set "HASH=!HASH:D=d!"
set "HASH=!HASH:E=e!"
set "HASH=!HASH:F=f!"

exit /b 0
