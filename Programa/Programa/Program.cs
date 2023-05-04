using Program;
using System;

namespace ChatbotSimples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Chatbot de Vendas de Pizzas!");
            UserContext userContext = new UserContext();

            while (true)
            {
                Console.Write("Você: ");
                string userInput = Console.ReadLine().Trim().ToLower();
                if (userInput == "sair") break;

                string response = Intent.ProcessInput(userContext, userInput);
                Console.WriteLine($"Chatbot: {response}");
            }
        }
    }
}