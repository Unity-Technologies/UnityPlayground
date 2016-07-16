@ECHO OFF

::Set project specific variables
SET projName=Playground Project
SET finalPath=%USERPROFILE%\Desktop\%projName%

::Copy relevant folders to desktop (changes with each project)
xcopy /s/y/i "..\PlaygroundProject\Assets" "%finalPath%\Assets"
xcopy /s/y/i "..\PlaygroundProject\ProjectSettings" "%finalPath%\ProjectSettings"

::Copy relevant loose files to desktop (changes with each project)
