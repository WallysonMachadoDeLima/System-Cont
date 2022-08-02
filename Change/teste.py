import DuckDuckGoImages as ddg
#testes
filtro = 'cpf'
destino = 'C:\Users\macha\OneDrive\Área de Trabalho\PROJETOS\System-Cont\Change\Files\CPF'

print('Iniciando downloads...')
try:
    ddg.download(filtro, folder=destino, remove_folder=False, parallel=True)
except Exception as e:
    print("type error: ", e)
print('Downloads concluidos...')