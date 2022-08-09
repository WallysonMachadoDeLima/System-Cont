import requests
from bs4 import BeautifulSoup

directory = str(input('Directory: '))
search = str(input("Quais imagens você deseja baixar? "))
num_of_img = int(input('Quantas imagens você deseja baixar? '))

url1 = f'https://www.google.com/search?q={search}&hl=pt-BR&gbv=1&source=lnms&tbm=isch&sa=X&ved=2ahUKEwipwcKTxOfrAhUUDrkGHZ3kB5kQ_AUoAXoECB8QAw&sfr=gws&sei=g8xeX6WWO4KI5OUP1Ne2sAQ'
i = 0

response = requests.get(url1)
soup = BeautifulSoup(response.text, 'html.parser')

links_list = []
repeat_list = []

table = soup.find_all('table', attrs=({'class':'TxbwNb'}))

for links in table:
    links_list.append(links.a.get('href'))

links_list = [sites[7: sites.index('&')] for sites in links_list]

for link in links_list:
    try:
        url = links
        response = requests.get(url)
        soup = BeautifulSoup(response.text, 'html.parser')

        images = soup.find_all('img')

        for image in images:
            with open(f'{directory}/{search.lower()}_{i}.png', 'wb') as f:
                if i == num_of_img:
                    break
                else:
                    img_response = requests.get(image.get('src'))
                    print(image.get('src'), '-', i)
                    f.write(img_response.content)
                    i += 1
    except:
        pass
