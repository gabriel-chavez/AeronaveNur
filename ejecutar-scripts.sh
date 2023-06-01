#!/bin/sh
carpeta_scripts="scripts"
server='34.118.139.240'
port='1434'
database='BD_PRUEBAS'
username='sa'
password='Gabriel123+'
archivos=$(ls -1 "$carpeta_scripts"/*.sql | sort)
for archivo in $archivos; do
  if [ -f "$archivo" ]; then
    echo "Ejecutando script: $archivo"
    sqlcmd -S "$server,$port" -d "$database" -U "$username" -P "$password" -i "$archivo"
  fi
done
