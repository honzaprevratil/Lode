using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    enum Typy
    {
        Lod, Prazdno, Strela, Minuto
    }
    enum Lode
    {
        Bitevni, Letadlova, Kriznik, Ponorka, Clun
    }
    class Program
    {
        static Typy[,] VytvoritPole()
        {
            Typy[,] PoleHrace = new Typy[10, 10];
            for (int i = 0; i < PoleHrace.GetLength(0); i++)
            {
                for (int f = 0; f < PoleHrace.GetLength(1); f++)
                {
                    PoleHrace[i, f] = Typy.Prazdno;
                }
            }
            return PoleHrace;
        }
        static void VypisPole(Typy[,] dvojrozmernePole, string popis)
        {
            String[] osaX = { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
            String[] vypisTyp = { "O|","-|", "@|", "X|" };

            Console.WriteLine(popis);

            for (int i = 0; i < dvojrozmernePole.GetLength(0); i++)
            {

                for (int f = 0; f < dvojrozmernePole.GetLength(1); f++)
                {
                    if (i == 0 && f > 0)
                    {
                        Console.Write(osaX[f - 1] + "|");
                    }
                    else if (f == 0 && i > 0)
                    {
                        Console.Write(i + "|");
                    }
                    else if (f == 0 && i == 0)
                    {
                        Console.Write(" |");
                    }
                    else
                    {
                        Console.Write(vypisTyp[ (int)dvojrozmernePole[i, f] ]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void VypisLode(Lode Lod, Typy[,] dvojrozmernePole, int x, int y)
        {
            if (Lod == Lode.Kriznik)
            {
                dvojrozmernePole[x, y] = Typy.Lod;
                dvojrozmernePole[x, y+1] = Typy.Lod;
                dvojrozmernePole[x, y+2] = Typy.Lod;
            }
        }
        static void Obraz(Typy[,] PoleHrace, Typy[,] PolePC)
        {
            VypisPole(PoleHrace, "Zde máš své lodě:\n____________________");
            VypisPole(PolePC, "Zde střílíš:\n____________________");
        }
        static void VstupX(Typy[,] PoleHrace, Typy[,] PolePC, string popis)
        {
            int omyl = 0;

            while (true)
            {
                Obraz(PoleHrace, PolePC);
                if (omyl == 1)
                {
                    Console.WriteLine("Toto není číslo");
                }
                Console.WriteLine(popis);
                try
                {
                    int X = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                }
            }
        }
        static void Main(string[] args)
        {
            Typy[,] PoleHrace = VytvoritPole();
            Typy[,] PolePC = VytvoritPole();

            while (true)
            {

                Obraz(PoleHrace, PolePC);
                Console.WriteLine("Zadej řádek lodě [0 - 9]: ");

                int lodX = int.Parse(Console.ReadLine());

                Console.WriteLine("Zadej sloupec lodě [A - J]: ");

                //a97 - i105 // A65 - I73

                int lodY = (int)Convert.ToChar(Console.ReadLine());
                Console.WriteLine(lodY);
                Console.ReadLine();
                VypisLode(Lode.Kriznik, PoleHrace, lodX, lodY);

                Console.Clear();
            }

            //Konec
            Console.ReadLine();
        }
    }
}
