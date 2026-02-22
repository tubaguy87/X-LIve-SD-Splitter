# Copies PNG from Cursor assets, compiles CreateIco, and writes a valid Icon1.ico
$ErrorActionPreference = "Stop"
$repoRoot = Split-Path $PSScriptRoot -Parent
$projectDir = Join-Path $repoRoot "X-Live SD Splitter"
$cursorPng = Join-Path $env:USERPROFILE ".cursor\projects\c-Users-tubag-source-repos-tubaguy87-X-LIve-SD-Splitter\assets\Icon1.png"

if (Test-Path $cursorPng) {
    Copy-Item $cursorPng (Join-Path $projectDir "Icon1.png") -Force
    Write-Host "Copied Icon1.png to project."
} else {
    if (-not (Test-Path (Join-Path $projectDir "Icon1.png"))) {
        Write-Error "Icon1.png not found in project or at $cursorPng. Add Icon1.png to the project folder and run again."
        exit 1
    }
}

$csc = Join-Path $env:SystemRoot "Microsoft.NET\Framework64\v4.0.30319\csc.exe"
if (-not (Test-Path $csc)) { $csc = Join-Path $env:SystemRoot "Microsoft.NET\Framework\v4.0.30319\csc.exe" }
$exePath = Join-Path $PSScriptRoot "CreateIco.exe"
$csPath = Join-Path $PSScriptRoot "CreateIco.cs"
& $csc /nologo /r:System.Drawing.dll "/out:$exePath" $csPath
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

$pngPath = Join-Path $projectDir "Icon1.png"
$icoPath = Join-Path $projectDir "Icon1.ico"
& $exePath $pngPath $icoPath
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
Write-Host "Icon1.ico created successfully."
