using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication17
{
    class RastgeleSayi
    {
        private string[] sayi;
        public RastgeleSayi()
            : this(4)
        {
        }
        public RastgeleSayi(int hane)
        {
            sayi = new string[hane];
            Random r = new Random();
            int s = 0;
            for (int i = 0; i < hane; i++)
            {
                s = r.Next(0, 10);

                if (uygunMu(s))
                {
                    sayi[i] = s.ToString();
                }
                else
                {
                    i--;
                }
            }

        }

        private bool uygunMu(int s)
        {
            for (int i = 0; i < sayi.Length; i++)
            {
                if (i == 0 && s == 0)
                    return false;
                if (varmi(s.ToString()))
                    return false;
            }

            return true;
        }

        private bool varmi(string m)
        {
            for (int i = 0; i < sayi.Length; i++)
            {
                if (sayi[i] == m)
                    return true;
            }

            return false;
        }

        public string sayiOku()
        {
            string s = "";

            for (int i = 0; i < sayi.Length; i++)
            {
                s += sayi[i];
            }
            return s;
        }
        public string TahminEt(string tahmin)
        {
            string s = this.sayiOku();
            int ayni = 0;
            int farkli = 0;

            for (int i = 0; i < sayi.Length; i++)
            {
                if (s[i] == tahmin[i])
                    ayni++;
                else
                {
                    for (int t = 0; t < tahmin.Length; t++)
                    {
                        if (s[i] == tahmin[t])
                            farkli++;
                    }
                }
            }



            if (ayni != 0 && farkli != 0)
                return "+" + ayni.ToString() + " -" + farkli.ToString();
            if (ayni != 0)
                return "+" + ayni.ToString();
            if (farkli != 0)
                return "-" + farkli.ToString();
            return "0";
        }

        public bool TahminKontrol(string s)
        {
            if (s.Length != sayi.Length)
            {
                Console.WriteLine("!! HATA !!");
                return false;
            }

            if(s[0]=='0')
            {
                Console.WriteLine("!! HATA !!");
                return false;
            }
            return true;
        }
    }

    class Program
    {
        static string RastgeleSayi(int hane)
        {
            string[] sayi = new string[hane];
            Random r = new Random();
            int s = 0;
            for (int i = 0; i < hane; i++)
            {
                s = r.Next(0, 10);
                if (i == 0 && s == 0)
                {
                    i--;
                    continue;
                }

                if (yokmu(sayi, s.ToString()))
                {
                    sayi[i] = s.ToString();
                }
                else
                {
                    i--;
                }
            }

            return MetneCevir(sayi);
        }

        static bool yokmu(string[] dizi, string m)
        {
            for (int i = 0; i < dizi.Length; i++)
            {
                if (dizi[i] == m)
                    return false;
            }

            return true;
        }


        static string MetneCevir(string[] dizi)
        {
            string s = "";

            for (int i = 0; i < dizi.Length; i++)
            {
                s += dizi[i];
            }
            return s;
        }

        static string TahminEt(string sayi, string tahmin)
        {
            int ayni = 0;
            int farkli = 0;

            for (int i = 0; i < sayi.Length; i++)
            {
                if (sayi[i] == tahmin[i])
                    ayni++;
                else
                {
                    for (int t = 0; t < tahmin.Length; t++)
                    {
                        if (sayi[i] == tahmin[t])
                            farkli++;
                    }
                }
            }



            if (ayni != 0 && farkli != 0)
                return "+" + ayni.ToString() + " -" + farkli.ToString();
            if (ayni != 0)
                return "+" + ayni.ToString();
            if (farkli != 0)
                return "-" + farkli.ToString();
            return "0";
        }

        static void Main(string[] args)
        {
            // string sayi = RastgeleSayi(4);
            //// Console.WriteLine(sayi);
            // int tur = 0;
            // while (true)
            // {
            //     tur++;
            //     string tahmin = Console.ReadLine();
            //     string sonuc = TahminEt(sayi, tahmin);
            //     Console.WriteLine(sonuc);

            //     if (sonuc == "+4")
            //     {
            //         break;
            //     }

            // }
            //Console.WriteLine("tebrik ederiz {0} seferde bildiniz.", tur);

            RastgeleSayi s = new RastgeleSayi();
            Console.WriteLine(s.sayiOku());
            int tur = 0;
            while (true)
            {
               
                string tahmin = Console.ReadLine();
                if (s.TahminKontrol(tahmin))
                {
                    tur++;
                    string sonuc = s.TahminEt(tahmin);
                    

                    if (sonuc == "+4")
                    {
                        break;
                    }
                    else
                        Console.WriteLine(sonuc);
                }

            }

            Console.WriteLine("tebrik ederiz {0} seferde bildiniz.", tur);
            Console.ReadKey();
        }
    }
}
