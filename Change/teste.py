from google_images_download import google_images_download

response = google_images_download.googleimagesdownload()

search = str(input("Quais imagens você deseja baixar? "))


def downloadimages(query):
    arguments = {"keywords": query,
                 "format": "jpg",
                 "limit": 5,
                 "print_urls": True,
                 "size": "medium",
                 "aspect_ratio": "panoramic"}
    try:
        response.download(arguments)


    except FileNotFoundError:
        arguments = {"keywords": query,
                     "format": "jpg",
                     "limit": 4,
                     "print_urls": True,
                     "size": "medium"}

        try:
            response.download(arguments)
        except:
            pass


for query in search:
    downloadimages(query)
    print()