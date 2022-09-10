using login_system.Interfaces;
using login_system.Models;
using login_system.Repositories;
using System.Security;

namespace login_system
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UserRepository userRepository = new();

            string option;

            do
            {
                Console.WriteLine("\nO que deseja fazer?\n");
                Console.WriteLine("1 - Acessar Sistema");
                Console.WriteLine("2 - Cancelar\n");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("\nDigite seu email:");
                        var email = Console.ReadLine();

                        Console.WriteLine("\nDigite sua senha:");
                        var pwd = Console.ReadLine();
                        User newUser;
                        try
                        {
                            newUser = userRepository.GetUser(email, pwd);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);  // erro 400, retorno o erro
                            break;
                        }

                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("\nAcesso realizado com sucesso!");
                        Console.WriteLine("\nBem-vindo! O que deseja fazer?\n");
                        Console.WriteLine("1 - Deslogar");
                        Console.WriteLine("2 - Encerrar o sistema\n");
                        option = Console.ReadLine();
                        Console.WriteLine("-------------------------------");
                        userRepository.log.RegisterAccess(newUser, "deslogou");
                        break;
                    case "2":
                        Console.WriteLine("\nSaindo da aplicação");


                        break;

                    default:
                        Console.WriteLine("Insira um valor válido\n");
                        break;
                }

            } while (option != "2");
        }
    }
}
