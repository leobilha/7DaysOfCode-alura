using ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Executar(MenuPrincipal());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public void LerMascote(int codigoMascote)
        {
            try
            {
                if (codigoMascote < 1 || codigoMascote > 20)
                    Executar(MenuPrincipal());

                RestClient client = new($"https://pokeapi.co/api/v2/pokemon/{codigoMascote}");
                RestRequest request = new("", Method.Get);
                var response = client.Execute(request);

                if (!response.StatusCode.Equals(HttpStatusCode.OK))
                    Console.WriteLine(response.ErrorMessage);

                Mascote mascote = JsonConvert.DeserializeObject<Mascote>(response.Content);

                // Por enquanto mostra apenas a experiencia
                Console.WriteLine($"\n*** Informações de {mascote.name.ToUpper()} *** " +
                                  $"\n\nNome Pokemon: {mascote.name.ToUpper()} " +
                                  $"\nExperiência: {mascote.base_experience} " +
                                  $"\nAltura: {mascote.height} " +
                                  $"\nPeso: {mascote.weight} " +
                                  "\nHabilidades:");

                foreach (var abilitie in mascote.abilities)
                {
                    Console.WriteLine(abilitie.ability.name.ToUpper());
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algum erro ao ler a especie.");
            }
        }

        static public void LerMascotes()
        {
            try
            {
                RestClient client = new(@"https://pokeapi.co/api/v2/pokemon/");
                RestRequest request = new("", Method.Get);
                var response = client.Execute(request);

                if (!response.StatusCode.Equals(HttpStatusCode.OK))
                    Console.WriteLine(response.ErrorMessage);

                ListaMascotes mascotes = JsonConvert.DeserializeObject<ListaMascotes>(response.Content);

                Console.WriteLine("\n*** Lista de especies ***");

                int posicao = 1;

                foreach (var r in mascotes.results)
                {
                    Console.WriteLine($"\n {posicao++}. {r.name.ToUpper()}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algum erro ao ler a lista de especies.");
            }
        }

        static public int MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("\n*** Menu ***\n" +
                                  "Escolha uma das opções abaixo: \n" +
                                  "1. Mostrar Especies \n" +
                                  "2. Sair do programa \n\n");

                int op = Teclado.LeInt("Digite a opção e aperter ENTER: ");

                if (op >= 1 && op <= 2)
                    return op;
                else
                    Console.WriteLine("Essa opção não existe!");
            }
        }

        static public void Executar(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    LerMascotes();
                    Console.WriteLine("\n\nDigite o número da especie para mais informações ou qualquer número acima de 20 para voltar ao menu principal: ");
                    LerMascote(Teclado.LeInt());
                    MenuPrincipal();
                    break;
                case 2:
                    Environment.Exit(1);
                    break;
                default:
                    break;
            }
        }
    }
}
