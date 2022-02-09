@echo off

for /f %%a in ('docker container ls --filter name^=maildev --quiet') do (
    echo Killing existing maildev container...
    docker container kill "%%a"
)

echo Running maildev container...
docker run --rm --detach ^
    --name maildev ^
    --publish 2525:25 ^
    --publish 8080:80 ^
    maildev/maildev

start "" "http://localhost:8080"
