import shutil
import os

oldAdress = 'D:\IFRO\Projeto Cont/teste/' #pasta origem
newAdress = 'D:\IFRO\Projeto Cont/teste2/' #pasta destino

lista = os.listdir(oldAdress) #lista separando apenas os arquivos do caminho.

# *** lista_len recebe o tamanho da lista ***
lista_len = len(lista)
x = 0

# *** Utilizar a variável ao invés de chamar 'os.listdir()' ***
while x < lista_len:
    caminhoCompleto_old = oldAdress + lista[x] #variável recebe caminho + arquivo, conforme indice
    caminhoCompleto_new = newAdress + lista[x] #variável recebe caminho + arquivo, conforme indice
    shutil.move(caminhoCompleto_old, caminhoCompleto_new) #módulo 'shutil.move()' move os arquivos
    print(x, '-', lista[x]) #apenas para ver como está sendo feito
    x += 1

