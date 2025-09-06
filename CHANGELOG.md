# Changelog

All notable changes to this project will be documented here.  
This project adheres to [Semantic Versioning](https://semver.org/).

---

## [v2.2.0] - 2025-09-06
### Added
- 🖐️ **Drag and Drop**: Files can now be dragged directly onto the window to be hashed.
- 📊 **Progress Bar**: A progress bar now appears for large files, providing visual feedback during hashing.
- 🔗 **Clickable Save Link**: After saving a hash file, the status label becomes a clickable link that opens the file's location in Explorer.

### Bug Fixed
- 🐛 **Startup Behavior**: The application no longer hashes itself automatically when opened without a file argument.

---

## [v2.1.0] - 2025-09-02
### Added
- 🍊 Introduced **OrangeHash GUI application** (`OrangeHash.exe`)
  - Retro-inspired interface for displaying file hashes
  - Displays **MD5, SHA-1, and SHA-256** side by side
  - Click any hash to copy to clipboard
  - Save hashes to `<filename>_hash.txt`
- 🖱 Enhanced **Explorer integration**:
  - Right-click → **OrangeHash** now opens the GUI instead of a message box
  - Works on Windows 10 (top-level) and Windows 11 (under *Show more options*)
- 📋 Optional **command-line shim**:
  - `md5.bat <path>` launches OrangeHash and shows the file’s MD5

### Changed
- Hashing logic now uses .NET `System.Security.Cryptography` for improved speed and reliability
- Updated installer to integrate the new GUI
- Documentation updated with screenshots, badges, and professional structure

---

## [v1.1.0] - 2025-08-31
### Added
- 🖥 Added **Inno Setup installer** (`md5-installer.exe`)
  - Automatically copies `md5.bat` into `C:\Windows\System32`
- 🖱 Optional **Explorer context menu**:
  - Right-click any file → “MD5 Hash (copy & show)”
  - Shows a popup with the MD5 hash and copies it to clipboard
  - On Windows 11, appears under **Show more options**
- ⚡ Improved uninstall:
  - Removes `md5.bat` from System32
  - Cleans up context menu registry keys

### Changed
- Simplified Inno Setup script with reliable quoting
- Stable `AppId` GUID ensures upgrades/uninstalls work smoothly

---

## [v1.0.0] - 2025-08-30
### Added
- Initial release of `md5.bat`
- Prints only the 32-character lowercase MD5 hash
- Supports:
  - Hashing literal strings
  - Hashing file paths
  - `-h` / `--help` flag for usage info
- GitHub Actions CI with automated tests
