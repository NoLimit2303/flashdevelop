:: reset local files to original state
@if "%1" neq "full" goto build
del /S /Q FlashDevelop\Bin\Debug 
git reset HEAD --hard

:build
msbuild PluginCore\PluginCore.csproj /p:Configuration=Release /p:Platform=x86
call SetVersion
msbuild FlashDevelop\FlashDevelop.csproj /p:Configuration=Release /p:Platform=x86
msbuild FlashDevelop.sln /p:Configuration=Release /p:Platform=x86

:: remove debug files
cd FlashDevelop\Bin\Debug
del /S *.vshost.exe*

:: exit with error if needed
if %errorlevel% neq 0 exit /b %errorlevel%