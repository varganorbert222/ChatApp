@echo off

set fontDir="./wwwroot/fonts"
IF NOT EXIST %fontDir% (
    mkdir %fontDir%
)
xcopy .\node_modules\bootstrap-icons\font\fonts\* .\wwwroot\fonts /i /s /y /q
EXIT