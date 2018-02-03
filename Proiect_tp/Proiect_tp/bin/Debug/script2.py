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


def scrierecsv(a):
    global flag
    filename='C:/Users/Cataa/Desktop/experiment.csv'    
    listachei=list(a.keys())
    ordineamea=[-1,1,2,0]                       #schimbarea ordinii coloanelor in csv 
    listachei=[listachei[i] for i in ordineamea]
    file_exists = os.path.isfile(filename)
    with open(filename, 'ab') as csvfile:
        writer = csv.DictWriter(csvfile, fieldnames=listachei)
        if(flag==0):
            writer.writeheader()
        writer.writerow(a)
        flag=flag+1
        
    




def accesareAPI(oras):
    lista=[]
    f = urllib.urlopen('http://api.worldweatheronline.com/premium/v1/weather.ashx?key=ce572520ee034f5899f191026171012&q=%s&format=json&num_of_days=5' % oras)
    json_string = f.read()
    parsed_json = json.loads(json_string)
    Oras=parsed_json['data']['request'][0]['query']
    temperatura=parsed_json['data']['current_condition'][0]
    del temperatura['weatherIconUrl']
    del temperatura['weatherDesc']
    del temperatura['windspeedMiles']
    del temperatura['weatherCode']
    del temperatura['winddir16Point']
    del temperatura['windspeedKmph']
    del temperatura['precipMM']
    del temperatura['winddirDegree']
    del temperatura['humidity']
    del temperatura['FeelsLikeF']
    del temperatura['cloudcover']
    del temperatura['pressure']
    del temperatura['temp_F']
    del temperatura['visibility']
    
    
    locatie={'Locatie':Oras}
       
    
    print(temperatura)
    temperatura.update(locatie)
    f.close()
    return temperatura
    
    
oras=['Satu%20Mare','Iasi','Cluj%20Napoca','Targu%20Mures','Miercurea%20Ciuc','Sibiu','Brasov','Timisoara','Ramnicu%20Valcea','Craiova','Bucuresti','Constanta']
  
os.remove('C:/Users/Cataa/Desktop/experiment.csv')   
flag=0
for index in range(12):
    scrierecsv(accesareAPI(oras[index]))