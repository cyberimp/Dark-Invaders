d:
CD \devel
del /Q invaders.exe
rd /S /Q invaders_Data
del /Q invaders_64.exe
rd /S /Q invaders_64_Data

D:\soft\Unity\Editor\Unity.exe -quit -projectPath "D:\Devel\Dark-Invaders" -logFile D:\devel\unity.log -no-graphics -batchmode -buildWindowsPlayer "D:\Devel\invaders.exe" -buildWindows64Player "D:\Devel\invaders_64.exe" -executeMethod WebGLBuilder.build

del "invaders.old"
move "d:\devel\invaders.zip" "D:\devel\invaders.old"
D:\soft\7-zip\7z.exe a invaders.zip invaders.exe invaders_64.exe invaders_Data invaders_64_Data
del d:\dropbox\invaders.zip
copy "D:\devel\invaders.zip" D:\dropbox\

pause