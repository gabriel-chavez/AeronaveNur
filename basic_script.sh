#!/bin/bash
whoami
date
carpeta_scripts="/ms/AeronaveNur/scripts"
server='35.203.92.126'
port='1434'
username='sa'
password='Gabriel123+'
archivos=$(ls -1 "$carpeta_scripts"/*.sql | sort)
for archivo in $archivos; do
echo "Ejecutando script: $archivo"
    sqlcmd -S "$server,$port" -U "$username" -P "$password" -i "$archivo"
done
