FROM postgres:latest

# Copia o dump para o diretório que o Postgres reconhece
COPY backup/backup.dump /docker-entrypoint-initdb.d/backup.dump
