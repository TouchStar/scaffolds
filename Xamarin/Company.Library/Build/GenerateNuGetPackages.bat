@echo off
pushd %~dp0..\
if not exist uGet mkdir NuGet
nuget pack Company.Library/Contracts/Company.Library.Contracts.csproj -OutputDirectory NuGet -Prop Configuration=Release
nuget pack Company.Library/Portable/Company.Library.csproj -OutputDirectory NuGet -Prop Configuration=Release
nuget pack Company.Library/Android/Company.Library.Android.csproj -OutputDirectory NuGet -Prop Configuration=Release
nuget pack Company.Library/Desktop/Company.Library.Desktop.csproj -OutputDirectory NuGet -Prop Configuration=Release
popd
