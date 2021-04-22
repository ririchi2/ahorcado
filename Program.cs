using System;

namespace ahorcado
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] paises = new string[] { "italia", "grecia", "francia" };  //Añadir tantos como sea necesario o cambiar el tema del juego
            string palabra = paises[NumAleatorio(paises.Length)];  //Si se cambia el tema del juego refactorizar esta linea
            string adivinar = "";

            Console.WriteLine($"Tiene un total de {palabra.Length} letras");

            for (int i = 0; i < palabra.Length; i++) 
            {

                if (palabra.Substring(i, 1) != " ")
                {
                    adivinar = adivinar + "-";
                } else
                {
                    adivinar = adivinar + " ";
                }
            } //Mostramos la longitud de la palabra
            Console.WriteLine(adivinar);

            int intentos = 0;

            do
            {
                string letrapulsada = "";
                string letraenviada;
                bool bien = false;

                Console.WriteLine("Escriba una letra");
                letrapulsada = Console.ReadLine();

                for (int i = 0; i <= palabra.Length - 1; i++)
                {
                    letraenviada = palabra.Substring(i, 1); //palabra[i] da error -> no se puede convertir char a string
                    //letraenviada = palabra[i];

                    if (letraenviada == letrapulsada)
                    {
                        adivinar = adivinar.Remove(i, 1);
                        adivinar = adivinar.Insert(i, letrapulsada); //Quitamos un guion y añadimos la letra que ha sido acertada
                        Console.WriteLine(adivinar);
                        bien = true;
                    }
                }
                if (palabra == adivinar)
                {
                    Console.WriteLine("Has ganado!");
                    break;
                }
                else
                {
                    if (!bien) //Encapsulamos el error y la suma de intentos aqui, porque no se me ocurre otro sitio donde ponerlo
                    {
                        Console.WriteLine("Error. Prueba de nuevo");
                        intentos++;
                    }
                }
            } while (intentos <= 7);

            Console.ReadKey();

        }

        static int NumAleatorio(int max)
        {
            var random = new Random();
            return random.Next(0, max);
        }
    }
}
