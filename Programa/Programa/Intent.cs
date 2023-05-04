using Program;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatbotSimples
{
    public class Intent
    {
        public List<string> Keywords { get; set; }
        public Func<UserContext, string, string> Response { get; set; }

        public static List<Intent> Intents = new List<Intent>
        {
            new Intent
            {
                Keywords = new List<string> { "olá", "oi", "oie" },
                Response = (userContext, userInput) => "Olá! Bem-vindo(a) à Pizzaria! Posso ajudar você a escolher uma pizza?"
            },
            new Intent
            {
                Keywords = new List<string> { "cardápio", "opções", "sabores" },
                Response = (userContext, userInput) => "Nossos sabores de pizza incluem: Margherita, Pepperoni, Quatro Queijos e Vegana. Qual você gostaria de pedir?"
            },
            new Intent
            {
                Keywords = new List<string> { "margherita", "marguerita" },
                Response = (userContext, userInput) => "Ótima escolha! Você gostaria de uma pizza tamanho pequeno, médio ou grande?"
            },
            new Intent
            {
                Keywords = new List<string> { "pequeno", "médio", "grande" },
                Response = (userContext, userInput) =>
                {
                    userContext.UserData["TamanhoPizza"] = userInput;
                    return "Você gostaria de adicionar algum ingrediente extra à sua pizza?";
                }
            },
            new Intent
            {
                Keywords = new List<string> { "sim", "adicional", "ingrediente" },
                Response = (userContext, userInput) => "Quais ingredientes adicionais você gostaria de adicionar à sua pizza? Temos azeitonas, bacon, cogumelos e cebola."
            },
            new Intent
            {
                Keywords = new List<string> { "não", "nenhum", "sem adicional" },
                Response = (userContext, userInput) => "Certo, sem ingredientes adicionais. Para finalizar, qual a forma de pagamento? Aceitamos dinheiro, cartão de crédito e débito."
            },
            new Intent
            {
                Keywords = new List<string> { "dinheiro", "cartão", "crédito", "débito" },
                Response = (userContext, userInput) =>
                {
                    string tamanho = userContext.UserData.ContainsKey("TamanhoPizza") ? userContext.UserData["TamanhoPizza"] : "tamanho desconhecido";
                    return $"Perfeito! Seu pedido de uma pizza {tamanho} foi registrado. Estará pronto em aproximadamente 30 minutos. Obrigado por escolher nossa pizzaria!";
                }
            },
            new Intent
            {
                Keywords = new List<string> { "tchau", "adeus", "até mais" },
                Response = (userContext, userInput) => "Até mais! Obrigado por visitar nossa pizzaria! Tenha um ótimo dia!"
            }
        };

        public static string ProcessInput(UserContext userContext, string userInput)
        {
            foreach (Intent intent in Intents)
            {
                if (intent.Keywords.Any(keyword => userInput.Contains(keyword)))
                {
                    return intent.Response(userContext, userInput);
                }
            }
            return "Desculpe, eu não entendi o que você disse. Você poderia repetir ou tentar outra coisa?";
        }
    }
}