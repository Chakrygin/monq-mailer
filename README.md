# monq-mailer
 
Как запустить:

- Запустить postgres скриптом `.\scripts\Postgres.cmd`.
- Запустить smtp-сервер скриптом `.\scripts\MailDev.cmd`.
- Далее можно:
  - Либо запустить сервис из проекта `src/Monq.Mailer`. Для простоты миграции накатываются при старте сервиса.
  - Либо запустить тесты из проекта `tests/Monq.Mailer.Tests`.
