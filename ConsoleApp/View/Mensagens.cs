using ConsoleApp.Model;
using ConsoleApp.Service;
using System;
using System.Collections.Generic;

namespace ConsoleApp.View
{
    public class Mensagens
    {
        static public string NomeUsuario { get; set; }

        static public List<Mascote> ListaDosMeusMascotes { get; set; } = new();

        static public void MostrarMascote(Mascote mascote)
        {
            Console.WriteLine($"\n-------------------- Informações de {mascote.name.ToUpper()} --------------------" +
                  $"\n\nNome Pokemon: {mascote.name.ToUpper()} " +
                  $"\nExperiência: {mascote.base_experience} " +
                  $"\nAltura: {mascote.height} " +
                  $"\nPeso: {mascote.weight} " +
                  "\nHabilidades:");


            foreach (var abilitie in mascote.abilities)
            {
                Console.WriteLine(abilitie.ability.name.ToUpper());
            }

            Console.WriteLine("\n------------------------------------------------------------------");
        }

        static public void MostrarMascote(Mascotes mascotes)
        {
            int posicao = 1;

            foreach (var r in mascotes.results)
            {
                Console.WriteLine($" {posicao++}. {r.name.ToUpper()}");
            }
        }

        static public int MenuPrincipal()
        {
            if (string.IsNullOrEmpty(NomeUsuario))
            {
                Console.WriteLine(@" ____     ___  ___ ___      __ __  ____  ____   ___     ___  
|    \   /  _]|   |   |    |  |  ||    ||    \ |   \   /   \ 
|  o  ) /  [_ | _   _ |    |  |  | |  | |  _  ||    \ |     |
|     ||    _]|  \_/  |    |  |  | |  | |  |  ||  D  ||  O  |
|  O  ||   [_ |   |   |    |  :  | |  | |  |  ||     ||     |
|     ||     ||   |   |     \   /  |  | |  |  ||     ||     |
|_____||_____||___|___|      \_/  |____||__|__||_____| \___/ ");
                Console.WriteLine("\n\nQual seu nome?");
                NomeUsuario = Teclado.LeString();
            }

            while (true)
            {
                Console.WriteLine("\n-------------------------- Menu ---------------------------" +
                                 $"\n\n{NomeUsuario} escolha uma das opções abaixo: " +
                                  "\n\n1. Adotar um mascote " +
                                  "\n2. Ver meus mascotes " +
                                  "\n3. Sair do programa ");

                int op = Teclado.LeInt("\n\nDigite a opção e aperter ENTER: ");

                if (op >= 1 && op <= 3)
                    return op;

                Console.WriteLine("\nEssa opção não existe!\n");
            }
        }

        static public int SubMenuPrincipal(string nomeMascote)
        {
            while (true)
            {
                Console.WriteLine($"\n{NomeUsuario} escolha uma das opções abaixo: \n " +
                                   $"\n1. Saber mais sobre o {nomeMascote}" +
                                   $"\n2. Adotar {nomeMascote}" +
                                   $"\n3. Voltar");

                int op = Teclado.LeInt("\nDigite a opção e aperter ENTER: ");

                if (op >= 1 && op <= 3)
                    return op;

                Console.WriteLine("\nEssa opção não existe!\n");
            }
        }
    }
}
