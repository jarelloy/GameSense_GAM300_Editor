echo OFF
SET inputShader=%1
SET ext=%~x1
SET exe="SPIRV Tools\\glslangValidator.exe"
if not [%2] == [] SET "exe=%2"
SET "outputShader=%~d1%~p1%~n1%ext:~1%.spv"
rem -------------------------------------
rem Compiling Vertex Shader...
rem -------------------------------------
powershell write-host Compiling Shader...
echo.
%exe% --target-env vulkan1.3 -V -o "%outputShader%" %inputShader%
if %ERRORLEVEL% GEQ 1 goto :VERTERROR

goto :DONE

:VERTERROR
powershell write-host -fore Red VERTEX SHADER COMPILATION - ERROR!!
IF [%2] == [] (
    pause
    exit -1
)
exit -1

:FRAGERROR
powershell write-host -fore Red FRAGMENT SHADER COMPILATION - ERROR!!
IF [%2] == [] (
    pause
    exit -1
)
exit -1

:DONE
powershell write-host -fore White SHADERS COMPILATION - DONE!!
IF [%2] == [] (
    pause
    exit 0
)
exit 0