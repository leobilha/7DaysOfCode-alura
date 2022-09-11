using ConsoleApp.Controller;
using ConsoleApp.View;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                while (true)
                {
                    int opcaoSelecionada = Mensagens.MenuPrincipal();
                    RegrasNegocio.Executar(opcaoSelecionada);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
