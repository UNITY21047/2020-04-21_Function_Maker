REM Compiles the program
csc -reference:"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.Windows.Forms.dll" -reference:"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.Drawing.dll" -reference:"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.ComponentModel.dll" -reference:"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.XML.dll" -reference:"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.IO.dll" -out:program.exe program.cs

REM Runs the executable.
program