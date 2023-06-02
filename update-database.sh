#!/bin/sh
carpeta_scripts="scripts"
server='35.203.92.126'
port='1434'
username='sa'
password='Gabriel123+'
archivos=$(ls -1 "$carpeta_scripts"/*.sql | sort)
for archivo in $archivos; do
  if [ -f "$archivo" ]; then
    echo "Ejecutando script: $archivo"
    sqlcmd -S "$server,$port" -d "$database" -U "$username" -P "$password" -i "$archivo"
  fi
done
