@echo off
rem runs t4 templates on both 32 and 64bit systems (we check versions 14.0,12.0,11.0)
SET TT=
FOR %%A IN (14,12,11) DO (
    IF EXIST "C:\Program Files\Common Files\Microsoft Shared\TextTemplating\%%A.0" (
        rem echo MATCH64 %%A
        IF NOT DEFINED TT ( SET TT="C:\Program Files\Common Files\Microsoft Shared\TextTemplating\%%A.0\")
        GOTO :FOUND
    ) ELSE IF EXIST "C:\Program Files (x86)\Common Files\Microsoft Shared\TextTemplating\%%A.0" (
        rem echo MATCH32 %%A
        IF NOT DEFINED TT ( SET TT="C:\Program Files (x86)\Common Files\Microsoft Shared\TextTemplating\%%A.0\")
        GOTO :FOUND
    )
)

:FOUND
IF NOT DEFINED TT (
    echo Warning: TextTransform.exe not found!
) ELSE (
    %TT%\TextTransform.exe %*
)