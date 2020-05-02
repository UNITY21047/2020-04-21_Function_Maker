REM Compiles the program
REM Refrences just in case -reference:"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Windows.Forms.dll" -reference:"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Drawing.dll" -reference:"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.ComponentModel.dll" -reference:"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.XML.dll" -reference:"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.IO.dll".
csc  -out:.\bin\program.exe .\scr\*.cs

REM Runs the executable.
.\bin\program