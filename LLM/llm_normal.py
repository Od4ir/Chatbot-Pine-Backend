
import requests
import google.generativeai as genai

def get_quote_currency(moeda_requerida:str, moeda_base:str):
    """
    Args: 
        moeda_requirida: Moeda para qual deseja saber o câmbio
        moeda_base: Moeda usada como comparação com a moeda requirida
    return:
        response.json() (dict): dicionario com varias informações a cotação da moeda requirida em relação a moeda base
    """
    print("entrei eba")
    response = requests.get(f"https://economia.awesomeapi.com.br/json/last/{moeda_requerida}-{moeda_base}")
    return response.json()

def get_user_by_id(user_id:str):
    """
    Agrs:
        user_id: Número de identificação da conta do usuário
    return
        response.json() (dict): Retorna informações como nome, email, telefone, idad, genero, contas, investimentos e produtos contratados pelo usuário
    """
    try:
      response = requests.get(f"http://localhost:7296/api/Usuarios/{user_id}")
      return response.json()
    except:
      return "Não foi possivel verificar essa pessoa no banco de dados :("

tool = [get_quote_currency, get_user_by_id]
  
genai.configure(api_key="AIzaSyCA8UFoADPrHVzFq26gFWtzqJ4IzyxfqRc")

generation_config = {
  "temperature": 1,
  "top_p": 0.95,
  "top_k": 40,
  "max_output_tokens": 8192,
  "response_mime_type": "text/plain",
}

model = genai.GenerativeModel(
  'gemini-1.5-flash', 
  generation_config=generation_config,
  system_instruction="Seu nome é Agente Pinho e você é um assistente virtual do Banco Pine. Suas tarefas é responder os clientes de forma mais amigavel possível e conseguir resolver questões bancárias dos clientes do banco como consulta de saldo de conta, gerar os extratos bancários, informar cotação de moedas, informar sobre investimentos e sobre o mercado financeiro. Alguns serviços terá que fazer chamadas de API externas como ver cotações e usuarios. Você não deve responder questões fora dos assuntos de mercado financeiro, transações ou serviços do Banco.",
  tools=tool 
)

history = []
while True:
  user_input = input("Cliente: ") 
  chat_session = model.start_chat(
    history=history,
    enable_automatic_function_calling=True
  )
  response = chat_session.send_message(user_input)
  model_response = response.text
  print()
  print("Agente Pinho: ", model_response)

  history.append({"role":"user","parts":[user_input]})
  history.append({"role":"model","parts":[model_response]})