import sys
sys.path.append("C:\Users\Cataa\Desktop\IronPython-2.7.7\Lib")


import random
import csv
from datetime import datetime



def citirecsv():
    blue=3
    path="C:/Users/Cataa/Desktop/foldernou.csv"
    file = open(path)
    reader= csv.reader(file)
    
    header=next(reader)      #header-ul fisierului 
    date=[]
    for rand in reader:
        
        data=rand[0]
        ora=int(rand[1])
        temperatura=int(rand[2])
        temperaturaF=int(rand[3])
        date.append([data,ora,temperatura,temperaturaF])
    i=4
    temptotal=[] ;an2017=[];an2016=[];an2015=[];an2014=[];an2013=[];ani=[] 
    while i<len(date):
        temptotal.append(date[i][2])
        i=i+8
    an2017=temptotal[0:32]
    an2016=temptotal[32:64]
    an2015=temptotal[64:96]
    an2014=temptotal[96:128]
    an2013=temptotal[128:160]
    ani.append(an2017);ani.append(an2016);ani.append(an2015);ani.append(an2014);ani.append(an2013)
    
    return ani
    
    
    
def Tendinta(w):
    S=0
    for index in range (9):
        S=S+w[ziua-(index+1)]
    media=S/9
    if (w[ziua]<=media):
        tendinta=0                          #tendinta este de scadere a temperaturii
    else:
        tendinta=1                          #tentinta este de crestere a temperaturii
        
    if(tendinta==0):
        print("Temperatura are tendinta sa scada")
        print(media)
    else:
        print("Temperatura are tendinta sa creasca")  
    return tendinta


def Algoritm(w,eroarea_mea):
    tziua4=w[ziua-1]
    tziua3=w[ziua-2]
    tziua2=w[ziua-3]
    tziua1=w[ziua-4]
    tziua0=w[ziua-5]
    w4=round(random.uniform(3,10),2)
    w3=round(random.uniform(1.5,5),2)
    w2=round(random.uniform(1,4),2)
    w1=round(random.uniform(0.5,3),2)
    w0=round(random.uniform(0.5,2),2)
    
    print(w4)
    print(w3)
    print(w2)
    print(w1)
    print(w0)
    
    pon=[]
    minim=100
    flag=0
    #media=(tziua4+tziua3+tziua2+tziua1+tziua0)/5
    #temperatura=abs(w[ziua]-media)
    #print("Diferenta de temperatura din ziua dorita si anterioarele",temperatura)
    for index in range (10000):
       # print("********* \n \n  O epoca  ************* \n\n")
        out=(w4*tziua4+w3*tziua3+w2*tziua2+w1*tziua1+w0*tziua0)/(w4+w3+w2+w1+w0)
       # print("Temperatura este : ",out)
       # print("iesirea este: ",out)
       # print("w4 ",w4)
       # print("w3 ",w3)
       # print("w2 ",w2)
       # print("w1 ",w1)
       # print("w0 ",w0)
        modw4=round(random.uniform(-1,1),2)
        modw3=round(random.uniform(-0.5,0.5),2)
        modw2=round(random.uniform(-0.5,0.5),2)
        modw1=round(random.uniform(-0.4,0.4),2)
        modw0=round(random.uniform(-0.2,0.2),2)
        w4=w4+modw4
        w3=w3+modw3
        w2=w2+modw2
        w1=w1+modw1
        w0=w0+modw0
        if ((w4>10) | (w4<3)):
            w4=5
        if ((w3>5) | (w3<1.5)):
            w3=3
        if ((w2>4) | (w2<1)):
            w2=2
        if ((w1>3) | (w1<0.5)):
            w1=1.5
        if ((w0>2) | (w0<0.5)):
            w0=1
            
        Eroarea=abs(w[ziua]-out)
        if Eroarea<minim:
            minim=Eroarea
        if (minim<=eroarea_mea):
            print("w0 este ",w0)
            print("w1 este ",w1)
            print("w2 este ",w2)
            print("w3 este ",w3)
            print("w4 este ",w4)
            flag=1
            break
        print("Eroarea este : ",Eroarea)
    if flag==1:
        pon.append(w0);pon.append(w1);pon.append(w2);pon.append(w3);pon.append(w4)
    else:
        pon.append(0);pon.append(0);pon.append(0);pon.append(0);pon.append(0)
    print("Minimul erorilor este : ",minim)
    
    return pon


def scriere(temp):
    file = open("C:/Users/Cataa/Desktop/Testul.csv","w") 
    file.write(temp)
    file.close() 


ponderi=[]
final=[]
ziua=31
S0=0;S1=0;S2=0;S3=0;S4=0
an2017=citirecsv()[0]
an2016=citirecsv()[1]
an2015=citirecsv()[2]
an2014=citirecsv()[3]
an2013=citirecsv()[4]
ponderi.append(Algoritm(an2013,2.8))
ponderi.append(Algoritm(an2014,2))
ponderi.append(Algoritm(an2015,1.7))
ponderi.append(Algoritm(an2016,2.8))
ponderi.append(Algoritm(an2017,3.2))
print(ponderi)
for i in range(5):
    S0=S0+ponderi[i][0]
    S1=S1+ponderi[i][1]
    S2=S2+ponderi[i][2]
    S3=S3+ponderi[i][3]
    S4=S4+ponderi[i][4]
w0=S0/5
w1=S1/5
w2=S2/5
w3=S3/5
w4=S4/5
print("w0 e ",w0)
print("w1 e ",w1)
print("w2 e ",w2)
print("w3 e ",w3)
print("w4 e ",w4)
final.append(w0);final.append(w1);final.append(w2);final.append(w3);final.append(w4)
    
    
 
t2018=[9,7,8,11,9]
ponderi=final
Temp_prezisa=(t2018[0]*ponderi[0]+t2018[1]*ponderi[1]+t2018[2]*ponderi[2]+t2018[3]*ponderi[3]+t2018[4]*ponderi[4])/(ponderi[0]+ponderi[1]+ponderi[2]+ponderi[3]+ponderi[4])
Temp_prezisa=str(Temp_prezisa)
print(Temp_prezisa)
scriere(Temp_prezisa)