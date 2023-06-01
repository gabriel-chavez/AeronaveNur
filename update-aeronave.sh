#!/bin/sh
PATH_REPO="/ms/AeronaveNur"
RAMA_REPO="master"

cd $PATH_REPO

git checkout -b $RAMA_REPO
git fetch
git reset --hard HEAD
git merge origin/$RAMA_REPO

docker-compose up --build -d



# Obtiene la lista de archivos .sql en la carpeta 'scripts'
scripts=$(find scripts -type f -name '*.sql')

# Parámetros de conexión a SQL Server
server='34.118.139.240'
port='1434'
database='BD_PRUEBAS'
username='sa'
password='Gabriel123+'

# Itera sobre cada script y ejecútalo utilizando sqlcmd
for script in $scripts; do
  sqlcmd -S "$server,$port" -d "$database" -U "$username" -P "$password" -i "$script"
done

