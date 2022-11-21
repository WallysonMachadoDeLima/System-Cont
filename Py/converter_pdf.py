import os
from pdf2image import convert_from_path


diretorio_entrada ='C:\\Users\\rafag\\OneDrive\\Documentos\\PDS_projeto\\System-Cont\\Files\\Change\\'
diretorio_saida ='C:\\Users\\rafag\\OneDrive\\Documentos\\PDS_projeto\\System-Cont\\Files\\Finished\\'

dirs = os.listdir(diretorio_entrada)

for file in dirs:
    print(diretorio_entrada+file)
    images = convert_from_path(diretorio_entrada+file)

    for image in images:
        image.save(diretorio_saida+"%s_pagina_%d.jpg" % ("imagem_pdf",images.index(image)+1), "JPEG")

