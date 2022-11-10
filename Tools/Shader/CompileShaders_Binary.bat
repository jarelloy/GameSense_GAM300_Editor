echo OFF
SET folder=%1
SET folder=%~1
SET exe="%folder%SPIRV Tools\\glslangValidator.exe"
SET "vert=%folder%default.vert"
SET "frag=%folder%default.frag"
SET "outvert=%folder%shader_vert.h"
SET "outfrag=%folder%shader_frag.h"
rem -------------------------------------
rem Compiling Vertex Shader...
rem -------------------------------------
powershell write-host Compiling Vertex Shader...
echo.
%exe% -V -o "%outvert%" --target-env vulkan1.3 --vn defaultvert "%vert%"
if %ERRORLEVEL% GEQ 1 goto :VERTERROR

echo OFF
rem -------------------------------------
rem Compiling Fragment Shader...
rem -------------------------------------
powershell write-host Compiling Fragment Shader...
echo.
%exe% -V -o "%outfrag%" --target-env vulkan1.3 --vn defaultfrag "%frag%"
if %ERRORLEVEL% GEQ 1 goto :FRAGERROR

goto :DONE

:VERTERROR
powershell write-host -fore Red VERTEX SHADER COMPILATION - ERROR!!
IF [%1] == [] pause
exit -1

:FRAGERROR
powershell write-host -fore Red FRAGMENT SHADER COMPILATION - ERROR!!
IF [%1] == [] pause
exit -1

:DONE
powershell write-host -fore White SHADERS COMPILATION - DONE!!
IF [%1] == [] pause