using ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace ConsoleApp
{
    public class RegrasNegocio
    {
        static public void Executar(int opcaoDoMenu)
        {
            switch (opcaoDoMenu)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine("\n-------------------- Adotar um mascote --------------------" +
                                         $"\n\n{Mensagens.NomeUsuario} escolha um mascote: \n");

                        var mascotes = LerMascotes();

                        Mensagens.MostrarMascote(mascotes);

                        int index = Teclado.LeInt("\nDigite uma das opções acima ou qualquer outro número para voltar ao menu principal e aperter ENTER: ");

                        if (index < 1 || index > 20)
                            break;
                        else
                        {
                            while (true)
                            {

                                string nomeMascote = mascotes.results[index - 1].name.ToUpper();
                                int opcaoSubMenu = Mensagens.SubMenuPrincipal(nomeMascote);

                                if (opcaoSubMenu == 1)
                                    Mensagens.MostrarMascote(LerMascote(index));
                                else if (opcaoSubMenu == 2)
                                {
                                    if (Mensagens.ListaDosMeusMascotes.Exists(m => m.id == index))
                                        Console.WriteLine($"\n *** OPAAA {Mensagens.NomeUsuario}!!! ***" +
                                            $"\nMascote {nomeMascote} já foi adotado.");
                                    else
                                    {
                                        Mensagens.ListaDosMeusMascotes.Add(LerMascote(index));

                                        Console.WriteLine("\n------------------------------------------------------------------");
                                        Console.WriteLine($"\nMuito bem {Mensagens.NomeUsuario}! Mascote {nomeMascote} adotado com sucesso!");
                                        Console.WriteLine("\n\n" + @" ┌─┐　 ─┐
　│▒│ /▒/
　│▒│/▒/
　│▒ /▒/─┬─┐
　│▒│▒|▒│▒│
┌┴─┴─┐-┘─┘
│▒┌──┘▒▒▒│
└┐▒▒▒▒▒▒┌┘
　└┐▒▒▒▒┌");
                                        Console.WriteLine("\n------------------------------------------------------------------");
                                        break;
                                    }
                                }
                                else
                                    break;
                            }
                        }
                    }
                    break;
                case 2:
                    if (Mensagens.ListaDosMeusMascotes.Count == 0)
                        Console.WriteLine($"\n{Mensagens.NomeUsuario}, não foi encontrado nenhum mascote!\n");
                    else
                    {                        
                        Console.WriteLine($"\n\n-------------------- Lista de Adotados de {Mensagens.NomeUsuario} --------------------\n");
                        foreach (var mascote in Mensagens.ListaDosMeusMascotes)
                            Console.WriteLine(mascote.name.ToUpper());
                        Console.WriteLine("\n------------------------------------------------------------------\n\n");
                    }
                    break;
                case 3:
                    Console.WriteLine("\n\n-------------------------------------------------------");
                    Console.WriteLine($"------------------- Até logo {Mensagens.NomeUsuario}!!! -------------------");
                    Console.WriteLine("-------------------------------------------------------\n\n");
                    Environment.Exit(1);
                    break;
                default:
                    break;
            }
        }

        static public Mascote LerMascote(int codigoMascote)
        {
            try
            {
                RestClient client = new($"https://pokeapi.co/api/v2/pokemon/{codigoMascote}");
                RestRequest request = new("", Method.Get);
                var response = client.Execute(request);

                if (!response.StatusCode.Equals(HttpStatusCode.OK))
                    Console.WriteLine(response.ErrorMessage);

                return JsonConvert.DeserializeObject<Mascote>(response.Content);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algum erro ao ler a especie.");
            }
        }

        static public Mascotes LerMascotes()
        {
            try
            {
                RestClient client = new(@"https://pokeapi.co/api/v2/pokemon/");
                RestRequest request = new("", Method.Get);
                var response = client.Execute(request);

                if (!response.StatusCode.Equals(HttpStatusCode.OK))
                    Console.WriteLine(response.ErrorMessage);

                Mascotes mascotes = JsonConvert.DeserializeObject<Mascotes>(response.Content);

                return mascotes;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu algum erro ao ler a lista de especies.");
            }
        }
    }
}
