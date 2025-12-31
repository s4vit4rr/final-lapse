using System;
using System.Collections.Generic;

class Program
{
    static int devlet = 50, halk = 50, ekonomi = 50, din = 50;
    static bool gameOver = false;

    static Dictionary<int, string> olayMetni = new Dictionary<int, string>()
    {
        {0, "Halk yiyecek istiyor."},
        {1, "Depolar boşaldı, tüccarlar ayaklandı."},
        {2, "Yeni para birimi önerildi."},
        {3, "Para reformu protestolara yol açtı."},
        {100, "Seni kurtarıcı ilan ettiler."},
        {101, "Kült liderliği resmileştirmek istiyor."}
    };

    static Dictionary<int, string[]> secenekler = new Dictionary<int, string[]>()
    {
        {0, new []{"Depoları aç", "Paylaştır"}},
        {1, new []{"Baskı uygula", "Anlaş"}},
        {2, new []{"Kabul et", "Reddet"}},
        {3, new []{"Dağıt", "Geri adım at"}},
        {100, new []{"Kabul et", "Reddet"}},
        {101, new []{"Onayla", "Yasakla"}}
    };

    static Dictionary<int, Action<int>> etkiler = new Dictionary<int, Action<int>>()
    {
        {0, s => { if (s == 1) { halk += 15; devlet -= 5; ekonomi -= 10; }
                   else { halk += 5; ekonomi -= 5; } }},

        {1, s => { if (s == 1) { devlet += 10; ekonomi -= 15; }
                   else { ekonomi += 10; devlet -= 10; } }},

        {2, s => { if (s == 1) { ekonomi += 15; halk -= 5; }
                   else { ekonomi -= 10; din += 5; } }},

        {3, s => { if (s == 1) { devlet += 10; halk -= 15; }
                   else { halk += 10; devlet -= 10; } }},

        {100, s => { if (s == 1) { devlet += 30; halk -= 20; din += 10; }
                     else { halk += 15; devlet -= 15; } }},

        {101, s => { if (s == 1) { din += 20; devlet -= 10; }
                     else { devlet += 10; din -= 20; } }}
    };

    static Dictionary<int, int> zincir = new Dictionary<int, int>()
    {
        {0, 1},
        {2, 3},
        {100, 101}
    };

    static Queue<int> sonOlaylar = new Queue<int>();
    static int? zorunluOlay = null;
    static Random rnd = new Random();

    static void Main()
    {
        int tur = 1;

        Console.Title = "LAPSE - Console Edition";
        Console.WriteLine("🌍 YIL 2147 - ÇÖKÜŞ SONRASI");
        Console.WriteLine("Devam etmek için ENTER...");
        Console.ReadLine();

        while (!gameOver)
        {
            Console.Clear();
            Console.WriteLine($"📅 TUR {tur}\n");
            Console.WriteLine($"🏛 Devlet  : {devlet}");
            Console.WriteLine($"👥 Halk    : {halk}");
            Console.WriteLine($"💰 Ekonomi : {ekonomi}");
            Console.WriteLine($"✝ Din     : {din}");

            int olay = OlaySec();

            Console.WriteLine("\n-----------------------");
            Console.WriteLine(olayMetni[olay]);
            Console.WriteLine($"1) {secenekler[olay][0]}");
            Console.WriteLine($"2) {secenekler[olay][1]}");

            int secim;
            while (true)
            {
                var key = Console.ReadKey(true).KeyChar;
                if (key == '1' || key == '2')
                {
                    secim = key == '1' ? 1 : 2;
                    break;
                }
            }

            etkiler[olay](secim);

            if (zincir.ContainsKey(olay))
                zorunluOlay = zincir[olay];

            DegerKontrol();
            OlayHafizaEkle(olay);

            tur++;
        }

        Console.Clear();
        Console.WriteLine("💀 DENGE ÇÖKTÜ");
        Console.ReadLine();
    }

    static int OlaySec()
    {
        if (zorunluOlay != null)
        {
            int o = zorunluOlay.Value;
            zorunluOlay = null;
            return o;
        }

        List<int> uygunOlaylar = new List<int>();

        foreach (var o in olayMetni.Keys)
            if (!sonOlaylar.Contains(o))
                uygunOlaylar.Add(o);

        return uygunOlaylar[rnd.Next(uygunOlaylar.Count)];
    }

    static void OlayHafizaEkle(int olay)
    {
        sonOlaylar.Enqueue(olay);
        if (sonOlaylar.Count > 5)
            sonOlaylar.Dequeue();
    }

    static void DegerKontrol()
    {
        if (devlet <= 0 || halk <= 0 || ekonomi <= 0 || din <= 0)
            gameOver = true;

        if (devlet > 100) devlet = 100;
        if (halk > 100) halk = 100;
        if (ekonomi > 100) ekonomi = 100;
        if (din > 100) din = 100;
    }
}
