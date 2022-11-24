import os
import time
from pdf2image import convert_from_path
import schedule

cont = 0
def rodar():
    diretorio_entrada ='C:\\Users\\rafag\\OneDrive\\Documentos\\PDS_projeto\\System-Cont\\Files\\Change\\'
    diretorio_saida ='C:\\Users\\rafag\\OneDrive\\Documentos\\PDS_projeto\\System-Cont\\Files\\Finished\\'

    dirs = os.listdir(diretorio_entrada)

    for file in dirs:
        print(diretorio_entrada+file)
        images = convert_from_path(diretorio_entrada+file)

        for image in images:
            global cont
            cont = cont + 1
            image.save(diretorio_saida+"%s_pagina_%d.jpg" % ("imagem_pdf",images.index(image)+cont), "JPEG")

schedule.every(10).seconds.do(rodar)

while True:
    schedule.run_pending()
    print("runing")
    time.sleep(1)
