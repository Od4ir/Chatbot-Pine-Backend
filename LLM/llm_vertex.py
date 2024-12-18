import requests
response = requests.get(f"https://economia.awesomeapi.com.br/json/last/USD-BRL")
print(response.json)