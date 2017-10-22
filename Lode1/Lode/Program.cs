using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    enum Typy
    {
        Lod, Prazdno, Zasah, Minuto, KolemLode, Mireni
    }
    enum Lode
    {
        Bitevni, Letadlova, Kriznik, Ponorka, Kurzor
    }
    class Program
    {
        static Typy[,] VytvoritPole()
        {
            Typy[,] PoleHrace = new Typy[9, 9];
            for (int i = 0; i < PoleHrace.GetLength(0); i++)
            {
                for (int f = 0; f < PoleHrace.GetLength(1); f++)
                {
                    PoleHrace[i, f] = Typy.Prazdno;
                }
            }
            return PoleHrace;
        }
        static void VypisPole(Typy[,] dvojrozmernePole, int hrac = 1)
        {
            String[] osaX = { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
            // String[] vypisTyp = { "O|", " |", "@", "X|", " |", "+" };

            for (int i = 0; i < dvojrozmernePole.GetLength(0) + 1; i++)
            {

                for (int f = 0; f < dvojrozmernePole.GetLength(1) + 1; f++)
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
                        switch ((int)dvojrozmernePole[i - 1, f - 1])
                        {
                            case 0:
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("O|");
                                Console.ResetColor();
                                break;
                            case 1:
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write(" |");
                                Console.ResetColor();
                                break;
                            case 2:
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("@");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write("|");
                                Console.ResetColor();
                                break;
                            case 3:
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write("X");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write("|");
                                Console.ResetColor();
                                break;
                            case 4:
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write(" |");
                                Console.ResetColor();
                                break;
                            case 5:
                                if (hrac == 1)
                                {
                                    Console.BackgroundColor = ConsoleColor.Yellow;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                }
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                }
                                Console.Write("+");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write("|");
                                Console.ResetColor();
                                break;
                        }
                        //Console.Write( vypisTyp[ (int)dvojrozmernePole[i-1,f-1] ] );
                    }
                }
                Console.WriteLine();
            }
        }
        static void Obraz(Typy[,] PoleHrace1, Typy[,] PoleHrace2)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Pole Hráče 1:       \n____________________");
            Console.ResetColor();
            VypisPole(PoleHrace1, 2);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Pole Hráče 2:       \n____________________");
            Console.ResetColor();
            VypisPole(PoleHrace2);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Legenda:            \n____________________");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("O");
            Console.ResetColor();
            Console.Write(" = loď\n");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(" ");
            Console.ResetColor();
            Console.Write(" = voda\n");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("+");
            Console.ResetColor();
            Console.Write(" = kurzor hráče 1\n");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("+");
            Console.ResetColor();
            Console.Write(" = kurzor hráče 2\n");
            Console.Write("X = minuto / špatné umístění lodě\n");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("@");
            Console.ResetColor();
            Console.Write(" = zásah");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nPokyny:             \n____________________");
            Console.ResetColor();
        }
        static int[] RozmeziOs(int x, int y, int minX, int maxX, int minY, int maxY)
        {
            x = (x <= minX) ? minX : x;
            x = (x >= maxX) ? maxX : x;
            y = (y <= minY) ? minY : y;
            y = (y >= maxY) ? maxY : y;

            int[] souradnice = { x, y };
            return souradnice;
        }
        static int[] ZapisLode_doPole(Lode Lod, Typy[,] dvojrozmernePole, int x, int y, int r)
        {
            int[] souradnice = { x, y };
            switch (Lod)
            {
                case Lode.Kriznik:
                    int[] osyZ = { 0, 0 };//osy změna
                    if (r == 1 || r == 3)
                    {
                        r = 1;
                        osyZ[0] = 1;
                    }
                    else
                    {
                        r = 2;
                        osyZ[1] = 1;
                    }
                    souradnice = RozmeziOs(souradnice[0], souradnice[1], 0 + osyZ[1], 8 - osyZ[1], 0 + osyZ[0], 8 - osyZ[0]);
                    dvojrozmernePole[souradnice[1] - osyZ[0], souradnice[0] - osyZ[1]] = (dvojrozmernePole[souradnice[1] - osyZ[0], souradnice[0] - osyZ[1]] == Typy.Lod || dvojrozmernePole[souradnice[1] - osyZ[0], souradnice[0] - osyZ[1]] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    dvojrozmernePole[souradnice[1], souradnice[0]] = (dvojrozmernePole[souradnice[1], souradnice[0]] == Typy.Lod || dvojrozmernePole[souradnice[1], souradnice[0]] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    dvojrozmernePole[souradnice[1] + osyZ[0], souradnice[0] + osyZ[1]] = (dvojrozmernePole[souradnice[1] + osyZ[0], souradnice[0] + osyZ[1]] == Typy.Lod || dvojrozmernePole[souradnice[1] + osyZ[0], souradnice[0] + osyZ[1]] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    break;

                case Lode.Ponorka:
                    r = 1;
                    souradnice = RozmeziOs(souradnice[0], souradnice[1], 0, 8, 0, 8);
                    dvojrozmernePole[souradnice[1], souradnice[0]] = (dvojrozmernePole[souradnice[1], souradnice[0]] == Typy.Lod || dvojrozmernePole[souradnice[1], souradnice[0]] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    break;

                case Lode.Letadlova:
                    r = 1;
                    souradnice = RozmeziOs(souradnice[0], souradnice[1], 1, 7, 1, 7);
                    dvojrozmernePole[souradnice[1], souradnice[0] + 1] = (dvojrozmernePole[souradnice[1], souradnice[0] + 1] == Typy.Lod || dvojrozmernePole[souradnice[1], souradnice[0] + 1] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    dvojrozmernePole[souradnice[1], souradnice[0] - 1] = (dvojrozmernePole[souradnice[1], souradnice[0] - 1] == Typy.Lod || dvojrozmernePole[souradnice[1], souradnice[0] - 1] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    dvojrozmernePole[souradnice[1], souradnice[0]] = (dvojrozmernePole[souradnice[1], souradnice[0]] == Typy.Lod || dvojrozmernePole[souradnice[1], souradnice[0]] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    dvojrozmernePole[souradnice[1] + 1, souradnice[0]] = (dvojrozmernePole[souradnice[1] + 1, souradnice[0]] == Typy.Lod || dvojrozmernePole[souradnice[1] + 1, souradnice[0]] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    dvojrozmernePole[souradnice[1] - 1, souradnice[0]] = (dvojrozmernePole[souradnice[1] - 1, souradnice[0]] == Typy.Lod || dvojrozmernePole[souradnice[1] - 1, souradnice[0]] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    break;


                case Lode.Bitevni:
                    int[] osyZ2 = new int[10];
                    if (r == 1 || r == 5)
                    {
                        r = 1;
                        int[] osyZ_temp1 = { 0, 2, 0, 1, -1, 0, 2, -2, 1, 0 };//osy změna
                        osyZ2 = osyZ_temp1;
                    }
                    else if (r == 2)
                    {
                        int[] osyZ_temp1 = { 2, 0, 1, 0, 0, -1, 1, 0, 2, -2 };
                        osyZ2 = osyZ_temp1;
                    }
                    else if (r == 3)
                    {
                        int[] osyZ_temp1 = { 0, 2, 0, 1, 1, 0, 2, -2, 0, -1 };
                        osyZ2 = osyZ_temp1;
                    }
                    else
                    {
                        r = 4;
                        int[] osyZ_temp1 = { 2, 0, 1, 0, 0, +1, 0, -1, 2, -2 };
                        osyZ2 = osyZ_temp1;
                    }
                    souradnice = RozmeziOs(souradnice[0], souradnice[1], 0 + osyZ2[6], 8 + osyZ2[7], 0 + osyZ2[8], 8 + osyZ2[9]);
                    dvojrozmernePole[souradnice[1] - osyZ2[0], souradnice[0] - osyZ2[1]] = (dvojrozmernePole[souradnice[1] - osyZ2[0], souradnice[0] - osyZ2[1]] == Typy.Lod || dvojrozmernePole[souradnice[1] - osyZ2[0], souradnice[0] - osyZ2[1]] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    dvojrozmernePole[souradnice[1] - osyZ2[2], souradnice[0] - osyZ2[3]] = (dvojrozmernePole[souradnice[1] - osyZ2[2], souradnice[0] - osyZ2[3]] == Typy.Lod || dvojrozmernePole[souradnice[1] - osyZ2[2], souradnice[0] - osyZ2[3]] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    dvojrozmernePole[souradnice[1], souradnice[0]] = (dvojrozmernePole[souradnice[1], souradnice[0]] == Typy.Lod || dvojrozmernePole[souradnice[1], souradnice[0]] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    dvojrozmernePole[souradnice[1] + osyZ2[4], souradnice[0] + osyZ2[5]] = (dvojrozmernePole[souradnice[1] + osyZ2[4], souradnice[0] + osyZ2[5]] == Typy.Lod || dvojrozmernePole[souradnice[1] + osyZ2[4], souradnice[0] + osyZ2[5]] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    dvojrozmernePole[souradnice[1] + osyZ2[2], souradnice[0] + osyZ2[3]] = (dvojrozmernePole[souradnice[1] + osyZ2[2], souradnice[0] + osyZ2[3]] == Typy.Lod || dvojrozmernePole[souradnice[1] + osyZ2[2], souradnice[0] + osyZ2[3]] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    dvojrozmernePole[souradnice[1] + osyZ2[0], souradnice[0] + osyZ2[1]] = (dvojrozmernePole[souradnice[1] + osyZ2[0], souradnice[0] + osyZ2[1]] == Typy.Lod || dvojrozmernePole[souradnice[1] + osyZ2[0], souradnice[0] + osyZ2[1]] == Typy.KolemLode) ? Typy.Minuto : Typy.Lod;
                    break;

            }
            int[] pozice = { souradnice[0], souradnice[1], r };
            return pozice;
        }
        static int VstupOsy(string osa = "x")
        {
            while (true)
            {
                try
                {
                    if (osa == "x" || osa == "X")
                    {
                        Console.WriteLine("Zadej řádek lodě [1 - 9]: ");
                        string vstup = Console.ReadLine();
                        int osa_souradnice = int.Parse(vstup);
                        if (osa_souradnice >= 1 && osa_souradnice <= 9)
                        {
                            return osa_souradnice;
                        }
                        Console.WriteLine("Chyba! Číslo mimo rozsah.");
                    }
                    else if (osa == "y" || osa == "Y")
                    {
                        Console.WriteLine("Zadej sloupec lodě [A - J]: ");
                        string vstup = Console.ReadLine();
                        int osa_souradnice = (int)Convert.ToChar(vstup);
                        //a97 - i105 // A65 - I73
                        if (osa_souradnice >= 97 && osa_souradnice <= 105)
                        {
                            osa_souradnice = osa_souradnice - 97;
                            return osa_souradnice;
                        }
                        else if (osa_souradnice >= 65 && osa_souradnice <= 73)
                        {
                            osa_souradnice = osa_souradnice - 65;
                            return osa_souradnice;
                        }
                        Console.WriteLine("Chyba! Špatný vstup.");
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Chyba! Špatný vstup.");
                }
            }
        }
        static bool ZkontrolovatPole_staveniLodi(Typy[,] PoleHrace)
        {
            for (int i = 0; i < PoleHrace.GetLength(0); i++)
            {
                for (int f = 0; f < PoleHrace.GetLength(1); f++)
                {
                    if (PoleHrace[i, f] == Typy.Minuto)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static bool ZkontrolovatPole_strelba(Typy[,] PoleHrace)
        {
            for (int i = 0; i < PoleHrace.GetLength(0); i++)
            {
                for (int f = 0; f < PoleHrace.GetLength(1); f++)
                {
                    if (PoleHrace[i, f] == Typy.Lod)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static void Zapsat_KolemLode(Typy[,] PoleHrace)
        {
            for (int i = 0; i < PoleHrace.GetLength(0); i++)
            {
                for (int f = 0; f < PoleHrace.GetLength(1); f++)
                {
                    if (PoleHrace[i, f] == Typy.Lod)
                    {
                        if (i > 0)
                        {
                            PoleHrace[i - 1, f] = (PoleHrace[i - 1, f] == Typy.Lod) ? Typy.Lod : Typy.KolemLode;
                        }
                        if (i < 8)
                        {
                            PoleHrace[i + 1, f] = (PoleHrace[i + 1, f] == Typy.Lod) ? Typy.Lod : Typy.KolemLode;
                        }
                        if (f > 0)
                        {
                            PoleHrace[i, f - 1] = (PoleHrace[i, f - 1] == Typy.Lod) ? Typy.Lod : Typy.KolemLode;
                        }
                        if (f < 8)
                        {
                            PoleHrace[i, f + 1] = (PoleHrace[i, f + 1] == Typy.Lod) ? Typy.Lod : Typy.KolemLode;
                        }
                    }
                }
            }
        }
        static bool Zjistit_PotopenaLod(Typy[,] PoleHrace)
        {
            bool potopena = true;
            for (int i = 0; i < PoleHrace.GetLength(0); i++)
            {
                for (int f = 0; f < PoleHrace.GetLength(1); f++)
                {
                    if (PoleHrace[i, f] == Typy.Zasah)
                    {
                        if (i > 0)
                        {
                            potopena = (PoleHrace[i - 1, f] == Typy.Lod) ? false : true;
                            if (!(potopena))
                            {
                                return false;
                            }
                        }
                        if (i < 8)
                        {
                            potopena = (PoleHrace[i + 1, f] == Typy.Lod) ? false : true;
                            if (!(potopena))
                            {
                                return false;
                            }
                        }
                        if (f > 0)
                        {
                            potopena = (PoleHrace[i, f - 1] == Typy.Lod) ? false : true;
                            if (!(potopena))
                            {
                                return false;
                            }
                        }
                        if (f < 8)
                        {
                            potopena = (PoleHrace[i, f + 1] == Typy.Lod) ? false : true;
                            if (!(potopena))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return potopena;
        }
        static Typy[,] Zapsat_KolemPotopeneLode(Typy[,] PoleHrace, Typy[,] PoleHraceNeviditelne)
        {
            for (int i = 0; i < PoleHrace.GetLength(0); i++)
            {
                for (int f = 0; f < PoleHrace.GetLength(1); f++)
                {
                    if (PoleHraceNeviditelne[i, f] == Typy.Zasah)
                    {
                        if (i > 0)
                        {
                            PoleHraceNeviditelne[i - 1, f] = (PoleHrace[i - 1, f] == Typy.KolemLode) ? Typy.Minuto : PoleHraceNeviditelne[i - 1, f];
                            PoleHrace[i - 1, f] = (PoleHrace[i - 1, f] == Typy.KolemLode) ? Typy.Minuto : PoleHraceNeviditelne[i - 1, f];
                        }
                        if (i < 8)
                        {
                            PoleHraceNeviditelne[i + 1, f] = (PoleHrace[i + 1, f] == Typy.KolemLode) ? Typy.Minuto : PoleHraceNeviditelne[i + 1, f];
                            PoleHrace[i + 1, f] = (PoleHrace[i + 1, f] == Typy.KolemLode) ? Typy.Minuto : PoleHraceNeviditelne[i + 1, f];
                        }
                        if (f > 0)
                        {
                            PoleHraceNeviditelne[i, f - 1] = (PoleHrace[i, f - 1] == Typy.KolemLode) ? Typy.Minuto : PoleHraceNeviditelne[i, f - 1];
                            PoleHrace[i, f - 1] = (PoleHrace[i, f - 1] == Typy.KolemLode) ? Typy.Minuto : PoleHraceNeviditelne[i, f - 1];
                        }
                        if (f < 8)
                        {
                            PoleHraceNeviditelne[i, f + 1] = (PoleHrace[i, f + 1] == Typy.KolemLode) ? Typy.Minuto : PoleHraceNeviditelne[i, f + 1];
                            PoleHrace[i, f + 1] = (PoleHrace[i, f + 1] == Typy.KolemLode) ? Typy.Minuto : PoleHraceNeviditelne[i, f + 1];
                        }
                    }
                }
            }
            return PoleHraceNeviditelne;
        }
        static int[] Zapsat_kurzor(Typy[,] dvojrozmernePole, int x, int y)
        {
            int[] souradnice = { x, y };
            souradnice = RozmeziOs(souradnice[0], souradnice[1], 0, 8, 0, 8);
            dvojrozmernePole[souradnice[1], souradnice[0]] = Typy.Mireni;
            return souradnice;
        }
        static void Main(string[] args)
        {
            int MyWindowWidth = Console.LargestWindowWidth < 80 ? Console.LargestWindowWidth : 80;
            int MyWindowHeight = Console.LargestWindowHeight < 44 ? Console.LargestWindowHeight : 44;
            Console.SetWindowSize(MyWindowWidth, MyWindowHeight);
            Typy[,] PoleHrace1 = VytvoritPole();
            Typy[,] PoleHrace2 = VytvoritPole();
            Typy[,] PoleNeviditelne1 = VytvoritPole();
            Typy[,] PoleNeviditelne2 = VytvoritPole();

            Typy[,] PoleHrace_kopie = VytvoritPole();
            Typy[,] PoleNeviditelne_kopie = VytvoritPole();

            Lode[] HraciLode = { Lode.Bitevni, Lode.Letadlova, Lode.Kriznik, Lode.Kriznik, Lode.Ponorka, Lode.Ponorka, Lode.Ponorka };
            //Lode[] HraciLode = { Lode.Bitevni, Lode.Kriznik, Lode.Ponorka }; //DEBUGGING
            int lodeCtr = 0;
            int[] poziceUkazatele = { 4, 4, 1 };
            bool chyba = false;
            int hrac = 1;

            // ÚVOD
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                                              \n  VÍTEJ V LOCAL MULTIPLAYEROVÉ HŘE LODĚ!!!    \n                                              ");
            Console.ResetColor();
            Console.WriteLine("\n\nStiskněte ENTER pro pokračování...\n");
            Console.ReadLine();
            Console.Clear();

            // ZAPSÁNÍ VLASTNÍCH LODÍ
            for (hrac = 1; hrac <= 2; hrac++)
            {
                while (true)
                {
                    if (lodeCtr >= HraciLode.GetLength(0))
                    {
                        lodeCtr = 0;
                        break;
                    }
                    PoleHrace_kopie = (hrac == 1) ? PoleHrace1.Clone() as Typy[,] : PoleHrace2.Clone() as Typy[,]; //refresh pole
                    poziceUkazatele = ZapisLode_doPole(HraciLode[lodeCtr], PoleHrace_kopie, poziceUkazatele[0], poziceUkazatele[1], poziceUkazatele[2]);
                    if (hrac == 1)
                    {
                        Obraz(PoleHrace_kopie, PoleNeviditelne2);
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" Hráč 1 ");
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n Jste na řadě");
                        Console.ResetColor();
                        Console.Write("\n Zapiště vaše lodě!\n Ovládání: WASD = pohyb, QE = rotace, SPACE = položit loď\n\n");
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" Hráč 2 ");
                        Console.ResetColor();
                        Console.Write("\n Nekoukat!\n\n");
                    }
                    else
                    {
                        Obraz(PoleNeviditelne1, PoleHrace_kopie);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" Hráč 2 ");
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n Jste na řadě");
                        Console.ResetColor();
                        Console.Write("\n Zapiště vaše lodě!\n Ovládání - NumPad: 8456 = pohyb, 79 = rotace, 0 = položit loď\n\n");
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" Hráč 1 ");
                        Console.ResetColor();
                        Console.Write("\n Nekoukat!\n\n");
                    }
                    if (chyba)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("WAROVÁNÍ: Lodě se nesmí překrývat ani dotýkat!");
                        Console.ResetColor();
                        chyba = false;
                    }

                    ConsoleKeyInfo pressed_key = Console.ReadKey();
                    if (hrac == 1)
                    {
                        switch (pressed_key.Key)
                        {
                            case ConsoleKey.A:
                                poziceUkazatele[0]--;
                                break;
                            case ConsoleKey.D:
                                poziceUkazatele[0]++;
                                break;
                            case ConsoleKey.S:
                                poziceUkazatele[1]++;
                                break;
                            case ConsoleKey.W:
                                poziceUkazatele[1]--;
                                break;
                            case ConsoleKey.Q:
                                poziceUkazatele[2]++;
                                break;
                            case ConsoleKey.E:
                                poziceUkazatele[2]--;
                                break;
                            case ConsoleKey.Spacebar:
                                if (ZkontrolovatPole_staveniLodi(PoleHrace_kopie))
                                {
                                    Zapsat_KolemLode(PoleHrace_kopie);
                                    PoleHrace1 = PoleHrace_kopie;// hrac 1 pole
                                    lodeCtr++;
                                    poziceUkazatele[0] = 4;
                                    poziceUkazatele[1] = 4;
                                    poziceUkazatele[2] = 1;
                                }
                                else
                                {
                                    chyba = true;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (pressed_key.Key)
                        {
                            case ConsoleKey.NumPad4:
                                poziceUkazatele[0]--;
                                break;
                            case ConsoleKey.NumPad6:
                                poziceUkazatele[0]++;
                                break;
                            case ConsoleKey.NumPad5:
                                poziceUkazatele[1]++;
                                break;
                            case ConsoleKey.NumPad8:
                                poziceUkazatele[1]--;
                                break;
                            case ConsoleKey.NumPad7:
                                poziceUkazatele[2]++;
                                break;
                            case ConsoleKey.NumPad9:
                                poziceUkazatele[2]--;
                                break;
                            case ConsoleKey.NumPad0:
                                if (ZkontrolovatPole_staveniLodi(PoleHrace_kopie))
                                {
                                    Zapsat_KolemLode(PoleHrace_kopie);
                                    PoleHrace2 = PoleHrace_kopie;// hrac 2 pole
                                    lodeCtr++;
                                    poziceUkazatele[0] = 4;
                                    poziceUkazatele[1] = 4;
                                    poziceUkazatele[2] = 1;
                                }
                                else
                                {
                                    chyba = true;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    Console.Clear();
                }
            }

            hrac = 1;
            bool zasah = false;
            bool potopena = false;
            int[] poziceUkazateleHrace1 = { 4, 4 };
            int[] poziceUkazateleHrace2 = { 4, 4 };
            int vyhra = 0;

            // STŘELBA
            while (true)
            {
                PoleNeviditelne_kopie = (hrac == 1) ? PoleNeviditelne2.Clone() as Typy[,] : PoleNeviditelne1.Clone() as Typy[,]; //refresh pole
                poziceUkazatele[0] = hrac == 1 ? poziceUkazateleHrace1[0] : poziceUkazateleHrace2[0];// uložená pozice kurzoru
                poziceUkazatele[1] = hrac == 1 ? poziceUkazateleHrace1[1] : poziceUkazateleHrace2[1];// uložená pozice kurzoru
                if (zasah == false)
                {
                    poziceUkazatele = Zapsat_kurzor(PoleNeviditelne_kopie, poziceUkazatele[0], poziceUkazatele[1]);
                }
                if (hrac == 1)
                {
                    Obraz(PoleNeviditelne1, PoleNeviditelne_kopie);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" Hráč 1 ");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("\n Jste na řadě");
                    Console.ResetColor();
                    Console.Write("\n Palte po svém protivníkovi!\n Ovládání: WASD = pohyb, SPACE = Palba!\n\n");
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" Hráč 2 ");
                    Console.ResetColor();
                    Console.Write("\n Vyčkejte na Váš tah!\n\n");
                }
                else
                {
                    Obraz(PoleNeviditelne_kopie, PoleNeviditelne2);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" Hráč 2 ");
                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("\n Jste na řadě");
                    Console.ResetColor();
                    Console.Write("\n Palte po svém protivníkovi!\n Ovládání - NumPad: 8456 = pohyb, 0 = Palba!\n\n");
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" Hráč 1 ");
                    Console.ResetColor();
                    Console.Write("\n Vyčkejte na Váš tah!\n\n");
                }
                if (chyba)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("WAROVÁNÍ: Na toto místo už jsi střílel, vyber si jiné!");
                    Console.ResetColor();
                    chyba = false;
                }
                if (zasah)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("ZÁSAH!! PAL ZNOVU!");
                    Console.ResetColor();
                    zasah = false;
                }
                if (potopena)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("LOĎ POTOPENA ADMIRÁLE!");
                    Console.ResetColor();
                    potopena = false;
                }
                ConsoleKeyInfo pressed_key = Console.ReadKey();

                if (hrac == 1)
                {
                    switch (pressed_key.Key)
                    {
                        case ConsoleKey.A:
                            poziceUkazatele[0]--;
                            break;
                        case ConsoleKey.D:
                            poziceUkazatele[0]++;
                            break;
                        case ConsoleKey.S:
                            poziceUkazatele[1]++;
                            break;
                        case ConsoleKey.W:
                            poziceUkazatele[1]--;
                            break;
                        case ConsoleKey.Spacebar:
                            if (PoleHrace2[poziceUkazatele[1], poziceUkazatele[0]] == Typy.Lod)
                            {
                                PoleNeviditelne2[poziceUkazatele[1], poziceUkazatele[0]] = Typy.Zasah;
                                PoleHrace2[poziceUkazatele[1], poziceUkazatele[0]] = Typy.Zasah;
                                zasah = true;
                                if (ZkontrolovatPole_strelba(PoleHrace2))
                                {
                                    vyhra = 1;
                                }
                                if (Zjistit_PotopenaLod(PoleHrace2))
                                {
                                    PoleNeviditelne2 = Zapsat_KolemPotopeneLode(PoleHrace2, PoleNeviditelne2);
                                    potopena = true;
                                }
                            }
                            else if (PoleHrace2[poziceUkazatele[1], poziceUkazatele[0]] == Typy.Prazdno || PoleHrace2[poziceUkazatele[1], poziceUkazatele[0]] == Typy.KolemLode)
                            {
                                PoleNeviditelne2[poziceUkazatele[1], poziceUkazatele[0]] = Typy.Minuto;
                                PoleHrace2[poziceUkazatele[1], poziceUkazatele[0]] = Typy.Minuto;
                                hrac = 2;
                            }
                            else if (PoleHrace2[poziceUkazatele[1], poziceUkazatele[0]] == Typy.Minuto || PoleNeviditelne2[poziceUkazatele[1], poziceUkazatele[0]] == Typy.Minuto || PoleHrace2[poziceUkazatele[1], poziceUkazatele[0]] == Typy.Zasah)
                            {
                                chyba = true;
                            }
                            break;
                    }
                    poziceUkazateleHrace1[0] = poziceUkazatele[0];
                    poziceUkazateleHrace1[1] = poziceUkazatele[1];
                }
                else
                {
                    switch (pressed_key.Key)
                    {
                        case ConsoleKey.NumPad4:
                            poziceUkazatele[0]--;
                            break;
                        case ConsoleKey.NumPad6:
                            poziceUkazatele[0]++;
                            break;
                        case ConsoleKey.NumPad5:
                            poziceUkazatele[1]++;
                            break;
                        case ConsoleKey.NumPad8:
                            poziceUkazatele[1]--;
                            break;
                        case ConsoleKey.NumPad0:
                            if (PoleHrace1[poziceUkazatele[1], poziceUkazatele[0]] == Typy.Lod)
                            {
                                PoleNeviditelne1[poziceUkazatele[1], poziceUkazatele[0]] = Typy.Zasah;
                                PoleHrace1[poziceUkazatele[1], poziceUkazatele[0]] = Typy.Zasah;
                                zasah = true;
                                if (ZkontrolovatPole_strelba(PoleHrace1))
                                {
                                    vyhra = 2;
                                }
                                if (Zjistit_PotopenaLod(PoleHrace1))
                                {
                                    PoleNeviditelne1 = Zapsat_KolemPotopeneLode(PoleHrace1, PoleNeviditelne1);
                                    potopena = true;
                                }
                            }
                            else if (PoleHrace1[poziceUkazatele[1], poziceUkazatele[0]] == Typy.Prazdno || PoleHrace1[poziceUkazatele[1], poziceUkazatele[0]] == Typy.KolemLode)
                            {
                                PoleNeviditelne1[poziceUkazatele[1], poziceUkazatele[0]] = Typy.Minuto;
                                PoleHrace1[poziceUkazatele[1], poziceUkazatele[0]] = Typy.Minuto;
                                hrac = 1;
                            }
                            else if (PoleHrace1[poziceUkazatele[1], poziceUkazatele[0]] == Typy.Minuto || PoleNeviditelne1[poziceUkazatele[1], poziceUkazatele[0]] == Typy.Minuto || PoleHrace1[poziceUkazatele[1], poziceUkazatele[0]] == Typy.Zasah)
                            {
                                chyba = true;
                            }
                            break;
                    }
                    poziceUkazateleHrace2[0] = poziceUkazatele[0];
                    poziceUkazateleHrace2[1] = poziceUkazatele[1];
                }
                Console.Clear();
                if (vyhra > 0)
                {
                    break;
                }
            }

            // KONEC
            if (vyhra == 1)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("KONEC HRY!!!\n");
            Console.ResetColor();
            Console.Write("Vítězem se stal:");
            if (vyhra == 1)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write(" Hráč " + vyhra);
            Console.ResetColor();
            Console.Write("!!!\n\n");
            Console.WriteLine("Blahopřeji vítězi a čest poraženému!\n\n");
            Console.Write("Autor hry Lodě:");
            if (vyhra == 1)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write(" JAN PŘEVRÁTIL \n");
            Console.ResetColor();
            Console.WriteLine("\n\nStisknutím ENTERU ukončíte hru...\n");
            Console.ReadLine();
        }
    }
}
