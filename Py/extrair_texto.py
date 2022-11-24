import cv2
import pytesseract
import schedule
import time
import os

#C:\Program Files\Tesseract-OCR
cont = 0
def rodar():

    if(os.path.exists(r'C:\Users\rafag\OneDrive\Documentos\PDS_projeto\System-Cont\Py\receba.jpg')):

        global cont
        cont = cont+1

        imagem = cv2.imread('receba.jpg')

        pytesseract.pytesseract.tesseract_cmd = "C:\\Program Files\\Tesseract-OCR\\tesseract.exe"

        texto = pytesseract.image_to_string(imagem)

        with open("texto_extraido.doc", "w") as arquivo_doc:
            arquivo_doc.write(texto)


        list_arquivos = os.listdir(r"C:\Users\rafag\OneDrive\Documentos\PDS_projeto\System-Cont\Py")
        for arquivo in list_arquivos:
            if "texto_extraido.doc" in arquivo:
                os.rename(f"C:\\Users\\rafag\\OneDrive\\Documentos\\PDS_projeto\\System-Cont\\Py\\texto_extraido.doc", f"C:\\Users\\rafag\\OneDrive\\Documentos\\PDS_projeto\\System-Cont\\Files\\Finished\\texto_extraido{cont}.doc")
        os.remove('receba.jpg')
        print(texto)

schedule.every(5).seconds.do(rodar)

while True:
    schedule.run_pending()
    print("runing")
    time.sleep(1)

