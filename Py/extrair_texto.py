import cv2
import pytesseract
import schedule
import time

#C:\Program Files\Tesseract-OCR

def rodar():

    imagem = cv2.imread('receba.jpg')

    pytesseract.pytesseract.tesseract_cmd = "C:\\Program Files\\Tesseract-OCR\\tesseract.exe"

    texto = pytesseract.image_to_string(imagem)

    with open("texto_extraido.doc", "w") as arquivo_doc:
        arquivo_doc.write(texto)

    import os

    list_arquivos = os.listdir(r"C:\Users\rafag\OneDrive\Documentos\PDS_projeto\System-Cont\Py")

    for arquivo in list_arquivos:
        if "texto_extraido.doc" in arquivo:
            os.rename(f"C:\\Users\\rafag\\OneDrive\\Documentos\\PDS_projeto\\System-Cont\\Py\\{arquivo}", f"C:\\Users\\rafag\\OneDrive\\Documentos\\PDS_projeto\\System-Cont\\Files\\Finished\\{arquivo}")

schedule.every(5).seconds.do(rodar)

while True:
    schedule.run_pending()
    print("runing")
    time.sleep(1)

print(texto)