#!/bin/bash

FolderName=$1
#App=$2

mkdir ${FolderName}
cd ${FolderName}

for (( i=0; i<=10; i=i+1))
do
	../MockAlgorithm/build/MockAlgorithm > test$i.txt
	#$App > $FolderName/test$i.txt
done