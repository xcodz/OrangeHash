# 🔑 MD5 for Windows Command Line & Windows Explorer

[![CI](https://github.com/xcodz/md5-bat/actions/workflows/ci.yml/badge.svg)](https://github.com/xcodz/md5-bat/actions)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](./LICENSE)
[![GitHub release](https://img.shields.io/github/v/release/xcodz/md5-bat.svg)](https://github.com/xcodz/md5-bat/releases)

A tiny Windows batch script that adds a simple `md5` command to your CMD.  
It prints **only the 32-character lowercase MD5 hash** — nothing else. 🎯

---

## ✨ Features
- 🔤 Hash a **literal string** (with or without quotes)
- 📂 Hash a **file** by path
- 📦 **Installer** available (`md5-installer.exe`) — one-click setup
- 🖱 Optional **Explorer context menu** (right-click → “MD5 Hash (copy & show)”)
- 🛠 Uses only built-in `certutil` (ships with Windows)
- 🖥 Works on Windows 10 / 11 / Server (no PowerShell required for CLI tool)
- 🧹 Clean output: just the hash on a single line

---

## 📥 Installation

### Option 1 — Quick Installer (Recommended)
Download the [**latest release installer**](https://github.com/xcodz/md5-bat/releases)  
Run `md5-installer.exe` → it will copy `md5.bat` into `C:\Windows\System32` so you can call `md5` globally from CMD.  
⚠️ Requires admin rights (writes to System32).  

During setup, you can also check:  
- **Shell integration** → adds right-click “MD5 Hash (copy/show)” to File Explorer.  
  (On Windows 11, it appears under **Show more options**).  

Re-running the installer later will offer **Modify / Repair / Remove**. Choosing *Remove* will uninstall everything.

### Option 2 — Manual
1. Download [`md5.bat`](./md5.bat)  
2. Copy it to a folder on your `%PATH%` (e.g. `C:\Windows\System32\`)  
3. Open a new `cmd.exe` window

---

## ▶️ Usage
```bat
md5 abc
md5 "hello world"
md5 "C:\path\to\file.ext"
md5 -h      :: show help
```

**Output:**
```
900150983cd24fb0d6963f7d28e17f72
```

✅ Always prints only the hash.  
⚠️ Errors and help text go to STDERR (safe for piping).

---

## 🧪 Examples
```bat
C:\> md5 abc
900150983cd24fb0d6963f7d28e17f72

C:\> md5 "hello world"
5eb63bbbe01eeed093cb22bb8f5acdc3

C:\> md5 "C:\Windows\notepad.exe"
<file hash here>
```

---

## 🔍 Why Batch?
- No PowerShell needed for the CLI tool  
- No external dependencies  
- Runs everywhere Windows + `certutil` exists  

---

## 📜 License
Released under the [MIT License](./LICENSE)  
© 2025 Milad Ahmadipour
