1. Create docker container using the yaml file in /Docker.
```
docker compose up -d
```

2. Restore database from that file running the following SQL commands
```
RESTORE FILELISTONLY FROM DISK = '/var/opt/mssql/backup/KITSProduct_20260401_1055PM.bak';
```
```
RESTORE DATABASE KITSProduct
FROM DISK = '/var/opt/mssql/backup/KITSProduct_20260401_1055PM.bak'
WITH MOVE 'Sample_Data' TO '/var/opt/mssql/data/KITSProduct.mdf',
     MOVE 'Sample_Log' TO '/var/opt/mssql/data/KITSProduct_log.ldf';
```

3. Sping up a postgres database.