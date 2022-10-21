#!/bin/sh
PATH_REPO="/ms/AeronaveNur"
RAMA_REPO="master"

cd $PATH_REPO

git checkout -b $RAMA_REPO
git fetch
git reset --hard HEAD
git merge origin/$RAMA_REPO

docker-compose up --build -d
