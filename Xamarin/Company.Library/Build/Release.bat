@echo off
pushd %~dp0..\
msbuild Company.Library.sln /p:Configuration=Release /p:DefineConstants="$(DefineConstants);AUTOBUILD;PCL"
popd