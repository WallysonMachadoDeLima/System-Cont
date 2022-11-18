import os
from pdf2image import convert_from_path

diretorio ='C:\\Users\\rafag\\OneDrive\\Documentos\\Projeto_PDS\\System-Cont\\Files\\Change'

dirs = os.listdir(diretorio)

for file in dirs:
    print(diretorio+file)
    images = convert_from_path(diretorio+file)

    for image in images:
        image.save(diretorio+"%s-pagina-%d.jpg" %
                   (file, images.index(image)+1), "JPEG")

