import sys
sys.path.append("C:\Users\Cataa\Desktop\IronPython-2.7.7\Lib")

import csv
from datetime import datetime
import random
import urllib
import json
import datetime
import csv
import os.path
import os

'''
def datatemp(a):
    """Returneaza un string pentru accesarea API-ului"""
    if a==0:
        data=input("Oferiti data de inceput cu formatul yyyy-MM-dd ")
    else:
        data=input("Oferiti data de sfarsit cu formatul yyyy-MM-dd")
    return data
'''

    
def citiredincsv():
    with open('C:/Users/Cataa/Desktop/foldernou.csv') as csvfile:
        reader = csv.DictReader(csvfile)
        row_count = sum(1 for row in reader)
        #for row in reader:
            #print(row['data'], row['time'])
    return row_count   
            

def oratemp(argument):
    switcher = {0:0,3:1,6:2,9:3,12:4,15:5,18:6,21:7}
    return switcher.get(argument, "Ora incorecta,alegeti dintre orele : 0,3,6,9,12,15,18,21")

def accesareAPI(an):
    f = urllib.urlopen('http://api.worldweatheronline.com/premium/v1/past-weather.ashx?key=ce572520ee034f5899f191026171012&q=Ramnicu%20Valcea&format=json&date={0}-01-03&enddate={0}-02-03'.format(an))
    json_string = f.read()
    parsed_json = json.loads(json_string)
    #ora=input("Dati ora la care vreti temperatura:")
    oreinzi=parsed_json['data']['weather'][0]['hourly']  # orele cu temperatura masurata in prima zi a lunii
    zileinluna=parsed_json['data']['weather']            # zilele intr-un apel pentru o luna
    for index in range(len(zileinluna)):                       # len(date) poate fi  31,30,28 in functie de nr de zile in o luna
        for j in range(len(oreinzi)):
            datetemperaturi.append(parsed_json['data']['weather'][index]['hourly'][j])
            zile.append(parsed_json['data']['weather'][index]['date'])
    #print(type(date))
    #print(date)
    #print(datetemperaturi)
    #print(type(datetemperaturi))
    f.close()
    return datetemperaturi

def prelucraredate():
    for ora in range(len(a)):
        del a[ora]['winddirDegree'] ; del a[ora]['weatherCode'] ; del a[ora]['weatherIconUrl'] ; del a[ora]['weatherDesc']
        del a[ora]['HeatIndexC'] ; del a[ora]['HeatIndexF'] ; del a[ora]['DewPointC'] ; del a[ora]['DewPointF']
        del a[ora]['WindChillC'] ; del a[ora]['WindChillF'] ; del a[ora]['WindGustKmph'] ; del a[ora]['FeelsLikeF']
        del a[ora]['windspeedMiles'] ;del a[ora]['WindGustMiles']
        zi={'data':zile[ora]}
        a[ora].update(zi)
    
def scrierecsv():
    global flag
    print(flag)
    listachei=list(a[0].keys())
    ordineamea=[7,6,0,1,10,5,2,11,8,9,3,4]                       #schimbarea ordinii coloanelor in csv 
    listachei=[listachei[i] for i in ordineamea]
    filename='C:/Users/Cataa/Desktop/foldernou.csv'
   

    file_exists = os.path.isfile(filename)
    with open(filename, 'a' ) as csvfile:
        writer = csv.DictWriter(csvfile, fieldnames=listachei)
        if  flag==0:
            writer.writeheader()
        for i in range(len(a)):
            writer.writerow(a[i])
    print(" scriere in fisier odata")
    print(a[0]['data'])
    flag=flag+1

today=datetime.date.today()
datetemperaturi= []
zile = []
flag=0



if (citiredincsv()==1280) :
    print("Fisierul contine datele pentru anteriorii 5 ani in total %s randuri , pregatit pentru algoritm: ", citiredincsv())
else:
        
        for i in range(1,6):                                       # date pentru 5 luni corespunzatoare a 5 ani
            a=accesareAPI((today.year-i))
            prelucraredate()
            scrierecsv()
            del a[:]
            del zile[:]