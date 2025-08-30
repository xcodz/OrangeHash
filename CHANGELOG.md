# Changelog

All notable changes to this project will be documented here.  
This project adheres to [Semantic Versioning](https://semver.org/).

---

## [v1.1] - 2025-08-31
### Added
- Inno Setup installer (`md5-installer.exe`) with **Modify / Repair / Remove** support
- Optional Explorer **context menu integration**  
  - Right-click any file → “MD5 Hash (copy & show)”  
  - Shows a popup and copies MD5 hash to clipboard
- Improved uninstall process (removes `md5.bat` from System32 + cleans registry keys)

### Changed
- Updated README with installer instructions, Explorer integration details, and project badges

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
