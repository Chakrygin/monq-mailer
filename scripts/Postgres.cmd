@echo off

for /f %%a in ('docker container ls --filter name^=postgres --quiet') do (
    echo Killing existing postgres container...
    docker container kill "%%a"
)

echo Running postgres container...
docker run --rm --detach ^
    --name postgres ^
    --publish 5432:5432 ^
    --env "POSTGRES_DB=postgres" ^
    --env "POSTGRES_USER=postgres" ^
    --env "POSTGRES_PASSWORD=postgres" ^
    postgres
