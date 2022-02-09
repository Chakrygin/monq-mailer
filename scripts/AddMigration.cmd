@echo off

pushd "%~dp0.."

dotnet ef migrations add ^
    --project .\src\Monq.Mailer\Monq.Mailer.csproj ^
    %*

popd
