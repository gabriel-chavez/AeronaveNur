#!/bin/sh

# Ejecucion de scripts
carpeta_scripts="scripts"

# Parámetros de conexión a SQL Server
server='34.118.139.240'
port='1434'
database='BD_PRUEBAS'
username='sa'
password='Gabriel123+'

# Obtener la lista de archivos .sql en la carpeta y ordenarlos alfabéticamente
archivos=$(ls -1 "$carpeta_scripts"/*.sql | sort)

# Iterar sobre cada archivo .sql en orden alfabético y ejecutarlo
for archivo in $archivos; do
  if [ -f "$archivo" ]; then
    echo "Ejecutando script: $archivo"
    sqlcmd -S "$server,$port" -d "$database" -U "$username" -P "$password" -i "$archivo"
  fi
done