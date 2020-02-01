
import requests
import json
import hashlib


def main():
    urlRequest = "https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=c3e11ed613d50979b23aa4dc4fda197ce8f0fb20"
    urlPost = "https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=c3e11ed613d50979b23aa4dc4fda197ce8f0fb20"
    response = requests.request("GET", urlRequest)
    salvar_json(response.text)

    arquivo_json = open("answer.json", "r")
    json_response = json.load(arquivo_json)

    # Descriptografar Júlio Cesar
    txt_cifrado = json_response["cifrado"]
    numero_casas = json_response["numero_casas"]
    json_response["decifrado"] = descriptografar(txt_cifrado, numero_casas)
    salvar_json(json.dumps(json_response))

    # Encriptar sh1
    m = hashlib.sha1()
    m.update(json_response["decifrado"].encode('utf-8'))
    json_response["resumo_criptografico"] = m.hexdigest()
    salvar_json(json.dumps(json_response))

    # Enviar Reposta
    result = requests.post(
        urlPost, files={"answer": open("answer.json", "rb")})
    print(result.text)


def descriptografar(texto, numero_casas):
    lista = list(texto)
    texto_descriptografado = ""
    alfabeto = 'abcdefghijklmnopqrstuvwxyz'

    for i in lista:
        if i in alfabeto:
            ord_c = ((ord(i) - ord('a') - numero_casas) % 26)
            texto_descriptografado += chr(ord_c + ord('a'))
        else:
            texto_descriptografado += i

    return texto_descriptografado


def salvar_json(json_response):
    arquivo_json = open("answer.json", "w")
    arquivo_json.write(json_response)
    arquivo_json.close()


main()
