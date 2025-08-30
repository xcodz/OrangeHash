# md5 — print only the MD5 (Windows)

Tiny Windows batch script that prints just the 32-char **lowercase** MD5 for either:
- a **literal string** (quote it if it has spaces), or
- a **file path** (quote it if it has spaces).

## Install
Copy `md5.bat` into a folder on your `%PATH%` (e.g. `C:\Windows\System32\`), then open a new `cmd.exe`.

## Usage
```bat
md5 abc
md5 "hello world"
md5 "C:\path\to\file.ext"
md5 -h      :: show help
```

**Output:** only the hash on STDOUT.  
**Errors/help:** written to STDERR, with non-zero exit codes.

## Why batch?
- No PowerShell required.
- Only uses built-in `certutil` (ships with Windows).

## Notes
- Works on modern Windows (10/11, Server 2016+).
- Locale-safe parsing (skips header; reads first non-empty line).
