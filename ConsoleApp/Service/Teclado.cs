using System;

namespace ConsoleApp.Service
{
    /* Classe que permite fazer leitura de dados do teclado. */
    public class Teclado
    {
        /* Le um inteiro. */
        static public int LeInt()
        {
            int a = 0;
            string s = Console.ReadLine();

            try
            {
                a = int.Parse(s);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("O valor digitado deve ser inteiro: " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro de I/O: " + ex);
            }

            return a;
        }

        /* Le um inteiro, com mensagem. */
        static public int LeInt(string msg)
        {
            int a = 0;
            Console.WriteLine(msg);
            string s = Console.ReadLine();

            try
            {
                a = int.Parse(s);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("O valor digitado deve ser inteiro: " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro de I/O: " + ex);
            }

            return a;
        }

        /* Le uma string. */
        static public string LeString()
        {
            string s = "";

            try
            {
                s = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro de I/O: " + ex);
            }

            return s;
        }

        /* Le uma string, com mensagem. */
        static public string LeString(string msg)
        {
            string s = "";

            Console.WriteLine(msg);

            try
            {
                s = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro de I/O: " + ex);
            }

            return s;
        }

    }
}
