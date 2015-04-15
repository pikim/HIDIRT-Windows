@echo off
for /F "tokens=3 delims=: " %%H in ('sc query "TvService" ^| findstr "        STATE"') do (
  if /I "%%H" EQU "RUNNING" (
    REM Put your code you want to execute here
    sc stop TvService > NUL
  )
)

:loop
for /F "tokens=3 delims=: " %%H in ('sc query "TvService" ^| findstr "        STATE"') do (
  if /I "%%H" NEQ "STOPPED" (
    REM Put your code you want to execute here
    goto loop
  )
)
