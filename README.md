# 🍊 OrangeHash v2.2.0 - Windows Hash Viewer (MD5, SHA-1, SHA-256)

[![CI](https://github.com/xcodz/OrangeHash/actions/workflows/ci.yml/badge.svg)](https://github.com/xcodz/OrangeHash/actions)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](./LICENSE)
[![GitHub release](https://img.shields.io/github/v/release/xcodz/OrangeHash.svg)](https://github.com/xcodz/OrangeHash/releases)
<img alt="GitHub language count" src="https://img.shields.io/github/languages/count/xcodz/OrangeHash">
<img alt="GitHub top language" src="https://img.shields.io/github/languages/top/xcodz/OrangeHash">
<img alt="GitHub code search count" src="https://img.shields.io/github/search?query=OrangeHash">
<img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/xcodz/OrangeHash">

**OrangeHash** is a lightweight Windows desktop application for quickly viewing file hashes 🎯
It supports **MD5, SHA-1, and SHA-256**, runs on Windows 10 and newer, and integrates with File Explorer’s right-click menu.  
A single EXE build is produced for Release (no external DLLs required).

---

## ✨ Features
- 🔑 View **MD5, SHA-1, and SHA-256** at a glance
- 🖐️ **Drag and Drop** a file directly onto the app window
- 📊 **Progress bar** for hashing very large files
- 📋 Click any hash to copy it to the clipboard
- 💾 Save hashes to `<filename>_hash.txt`
- 🔗 **Click the "Saved" status message** to open the file's location
- 🖱 Optional File Explorer context menu entry (“OrangeHash”)
- ⚙️ Optional `md5.bat` shim for launching from CMD (`md5.bat <path>`)

---

## 🖼 Screenshot


<p align="center">
  <img src="https://github.com/xcodz/OrangeHash/blob/main/docs/screenshot.png" alt="OrangeHash Screenshot" width="571"/>
</p>


## 📥 Installation

### Option 1 — Installer (Recommended)
- Download **`OrangeHash-Setup.exe`** from [Releases](https://github.com/xcodz/OrangeHash/releases).
- During setup you can optionally:
  - Add File Explorer context menu entry (“OrangeHash”).
  - Install `md5.bat` to `System32` to launch from CMD.
- Uninstall removes the app, context menu, and `md5.bat`.

### Option 2 — Portable
- Use the Release build `OrangeHash.exe` (single file). Place it anywhere and run.
- Context menu integration and `md5.bat` are not available in pure portable mode.

**Requirements**
- 🖥 Windows 10 or newer  
- 📦 .NET Framework 4.8 (preinstalled on most Windows 10+ systems)

---

## ▶️ Usage

### File Explorer
- Right-click any file → **OrangeHash**  
  The app opens showing MD5, SHA-1, and SHA-256.

### Inside the App
- **Drag and drop a file** onto the window.
- Or, if launched without an argument, click the main label to **select a file**.
- 📋 Click any hash box to copy to the clipboard.
- 💾 Click **Save** to write `<filename>_hash.txt` next to the source file.
- 🔗 After saving, **click the status message** to open the folder containing the new text file.

### 🔤 Command Line
If you installed the optional `md5.bat` 
(Currently, only MD5 is supported in CLI mode):

```bat
C:\> md5 abc
900150983cd24fb0d6963f7d28e17f72

C:\> md5 "hello world"
5eb63bbbe01eeed093cb22bb8f5acdc3

C:\> md5 "C:\Windows\notepad.exe"
d43b8f81cebb77c7d7c21846cc9fc38e
```

---

## 📜 License
Released under the [MIT License](./LICENSE)  
© 2025 Milad Ahmadipour

---

## 🙏 Acknowledgments
- 🖊 Built with **C#** and **WinForms** (.NET Framework 4.8)  
- 📦 **Inno Setup** for packaging  
- ⚡ **Costura.Fody** for single-file embedding
