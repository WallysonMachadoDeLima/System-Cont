import cv2
import pytesseract

#C:\Program Files\Tesseract-OCR

imagem = cv2.imread('receba.jpg')

pytesseract.pytesseract.tesseract_cmd = "C:\\Program Files\\Tesseract-OCR\\tesseract.exe"

texto = pytesseract.image_to_string(imagem)

print(texto)
