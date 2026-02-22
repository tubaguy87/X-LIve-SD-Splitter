Regenerating the application icon
---------------------------------
If you change Icon1.png in the "X-Live SD Splitter" folder, run:

  powershell -ExecutionPolicy Bypass -File build_icon.ps1

This compiles CreateIco.cs and overwrites Icon1.ico with a valid
Vista-style ICO (embedded PNG, 256x256) that Visual Studio can open.
