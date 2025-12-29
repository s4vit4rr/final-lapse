using System;

class Program
{
    static void Main()
    {
        // ===== OYUN DEĞERLERİ =====
        int devlet = 50;
        int halk = 50;
        int ekonomi = 50;
        int din = 50;

        int tur = 1;
        int sonOlay = -1;

        Random rnd = new Random();

        // ===== GİRİŞ HİKÂYESİ =====
        Console.Title = "LAPSE - Console Edition";
        Console.Clear();
        Console.WriteLine("🌍 YIL 2147\n");
        Console.WriteLine("Dünya çöktü.");
        Console.WriteLine("Savaşlar, salgınlar ve inanç çatışmaları eski düzeni yok etti.");
        Console.WriteLine("\nÖnceki lider bir gecede ortadan kayboldu.");
        Console.WriteLine("Devlet başsız kaldı.");
        Console.WriteLine("\nOrdu, halk, din ve tüccarlar");
        Console.WriteLine("dengeyi kurabilecek tek kişi olarak SENİ seçti.");
        Console.WriteLine("\nBu bir kurtuluş hikâyesi değil.");
        Console.WriteLine("Bu, çöküşü ne kadar geciktirebildiğinin hikâyesi.");
        Console.WriteLine("\nENTER'a bas ve yönetimi devral...");
        Console.ReadLine();

        // ===== ANA OYUN DÖNGÜSÜ =====
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========= TUR: " + tur + " =========\n");

            // DURUM
            Console.WriteLine("🏛 Devlet : " + devlet);
            Console.WriteLine("👥 Halk   : " + halk);
            Console.WriteLine("💰 Ekonomi: " + ekonomi);
            Console.WriteLine("✝ Din    : " + din);

            // ===== OLAY SEÇİMİ =====
            bool nadirMi = rnd.Next(100) < 10; // %10 nadir
            int olayId;

            do
            {
                if (nadirMi)
                    olayId = 100 + rnd.Next(5); // 100-104
                else
                    olayId = rnd.Next(10);      // 0-14
            }
            while (olayId == sonOlay);

            sonOlay = olayId;

            Console.WriteLine("\n📜 OLAY:");

            // ===== OLAY METİNLERİ =====
            switch (olayId)
            {
                case 0:
                    Console.WriteLine("Çöküşten kurtulan halk yiyecek istiyor.");
                    Console.WriteLine("1) Depoları aç");
                    Console.WriteLine("2) Paylaştır");
                    break;

                case 1:
                    Console.WriteLine("Eski rejim yanlıları gizlice örgütleniyor.");
                    Console.WriteLine("1) Tutukla");
                    Console.WriteLine("2) İzle");
                    break;

                case 2:
                    Console.WriteLine("Yeni bir para birimi önerildi.");
                    Console.WriteLine("1) Kabul et");
                    Console.WriteLine("2) Reddet");
                    break;

                case 3:
                    Console.WriteLine("Dini metinler yeniden yorumlanmak isteniyor.");
                    Console.WriteLine("1) Onayla");
                    Console.WriteLine("2) Yasakla");
                    break;

                case 4:
                    Console.WriteLine("Ordu şehirlerde kontrol noktası istiyor.");
                    Console.WriteLine("1) İzin ver");
                    Console.WriteLine("2) Reddet");
                    break;

                case 5:
                    Console.WriteLine("Salgın sonrası karantina öneriliyor.");
                    Console.WriteLine("1) Uygula");
                    Console.WriteLine("2) Reddet");
                    break;

                case 6:
                    Console.WriteLine("Tüccarlar vergi indirimi istiyor.");
                    Console.WriteLine("1) Kabul et");
                    Console.WriteLine("2) Reddet");
                    break;

                case 7:
                    Console.WriteLine("Tarikatlar halka umut dağıtıyor.");
                    Console.WriteLine("1) Destekle");
                    Console.WriteLine("2) Dağıt");
                    break;

                case 8:
                    Console.WriteLine("Sınır bölgelerinde isyan çıktı.");
                    Console.WriteLine("1) Asker gönder");
                    Console.WriteLine("2) Müzakere et");
                    break;

                case 9:
                    Console.WriteLine("Eski teknoloji yeniden kullanılabilir.");
                    Console.WriteLine("1) Yatırım yap");
                    Console.WriteLine("2) Görmezden gel");
                    break;

                case 100:
                    Console.WriteLine("⚠ NADİR OLAY: Önceki liderin günlüğü bulundu.");
                    Console.WriteLine("1) Açıkla");
                    Console.WriteLine("2) Gizle");
                    break;

                case 101:
                    Console.WriteLine("⚠ NADİR OLAY: Gökyüzünde kutsal bir işaret görüldü.");
                    Console.WriteLine("1) Kutsal ilan et");
                    Console.WriteLine("2) Bilimsel açıkla");
                    break;

                case 102:
                    Console.WriteLine("⚠ NADİR OLAY: Çöküşün gerçek sebebi ortaya çıktı.");
                    Console.WriteLine("1) Halkla paylaş");
                    Console.WriteLine("2) Devlet sırrı yap");
                    break;

                case 103:
                    Console.WriteLine("⚠ NADİR OLAY: Zaman kapsülü bulundu.");
                    Console.WriteLine("1) İncele");
                    Console.WriteLine("2) Yok et");
                    break;

                case 104:
                    Console.WriteLine("⚠ NADİR OLAY: Halk seni kurtarıcı ilan ediyor.");
                    Console.WriteLine("1) Kabul et");
                    Console.WriteLine("2) Reddet");
                    break;
            }

            Console.Write("\nSeçimin (1-2): ");
            string secim = Console.ReadKey(true).KeyChar.ToString();

            // ===== ETKİLER (GÜNCELLENMİŞ TAM LİSTE) =====
            switch (olayId)
            {
                case 0: // Yiyecek Sorunu
                    if (secim == "1") { halk += 15; devlet -= 5; ekonomi -= 10; } // Depoları aç
                    else { halk += 5; ekonomi -= 5; } // Paylaştır
                    break;

                case 1: // Rejim Yanlıları
                    if (secim == "1") { devlet += 10; halk -= 10; } // Tutukla
                    else { devlet -= 5; halk += 5; } // İzle
                    break;

                case 2: // Yeni Para Birimi
                    if (secim == "1") { ekonomi += 15; halk -= 5; } // Kabul
                    else { ekonomi -= 10; din += 5; } // Reddet
                    break;

                case 3: // Dini Metinler
                    if (secim == "1") { din -= 10; halk += 5; } // Onayla (Reform)
                    else { din += 10; halk -= 10; } // Yasakla (Muhafazakar)
                    break;

                case 4: // Ordu Kontrol Noktası
                    if (secim == "1") { devlet += 15; halk -= 15; } // İzin ver
                    else { devlet -= 10; halk += 10; } // Reddet
                    break;

                case 5: // Karantina
                    if (secim == "1") { halk -= 5; ekonomi -= 15; } // Uygula (Güvenli ama pahalı)
                    else { halk += 5; ekonomi += 10; devlet -= 10; } // Reddet (Riskli ama kârlı)
                    break;

                case 6: // Vergi İndirimi
                    if (secim == "1") { ekonomi += 10; devlet -= 10; } // Kabul
                    else { ekonomi -= 5; devlet += 5; } // Reddet
                    break;

                case 7: // Tarikatlar
                    if (secim == "1") { din += 15; devlet -= 10; } // Destekle
                    else { din -= 15; devlet += 10; } // Dağıt
                    break;

                case 8: // Sınır İsyanı
                    if (secim == "1") { devlet += 10; ekonomi -= 15; } // Asker gönder (Pahalı)
                    else { halk += 10; devlet -= 15; } // Müzakere (Otorite sarsılır)
                    break;

                case 9: // Eski Teknoloji
                    if (secim == "1") { ekonomi += 20; din -= 10; } // Yatırım yap (Bilim artar, inanç azalır)
                    else { din += 10; ekonomi -= 5; } // Görmezden gel
                    break;

                // --- NADİR OLAYLAR ---

                case 100: // Liderin Günlüğü
                    if (secim == "1") { halk += 15; devlet -= 10; din -= 5; } // Açıkla
                    else { devlet += 15; halk -= 15; } // Gizle
                    break;

                case 101: // Gökyüzü İşareti
                    if (secim == "1") { din += 25; ekonomi -= 10; } // Kutsal ilan et
                    else { din -= 20; ekonomi += 10; } // Bilimsel açıkla
                    break;

                case 102: // Çöküş Sebebi
                    if (secim == "1") { halk += 25; devlet -= 25; } // Halkla paylaş (Kaos riski)
                    else { devlet += 20; halk -= 10; } // Sır yap
                    break;

                case 103: // Zaman Kapsülü
                    if (secim == "1") { ekonomi += 25; din -= 15; } // İncele
                    else { din += 15; ekonomi -= 10; } // Yok et
                    break;

                case 104: // Kurtarıcı İlanı
                    if (secim == "1") { halk += 20; din += 10; devlet -= 15; } // Kabul (Mesih kompleksi)
                    else { devlet += 10; halk -= 5; } // Reddet (Mütevazı)
                    break;
            }

            // ===== SINIRLAMA =====
            if (devlet < 0) devlet = 0;
            if (halk < 0) halk = 0;
            if (ekonomi < 0) ekonomi = 0;
            if (din < 0) din = 0;

            if (devlet > 100) devlet = 100;
            if (halk > 100) halk = 100;
            if (ekonomi > 100) ekonomi = 100;
            if (din > 100) din = 100;

            // ===== OYUN BİTİŞİ =====
            if (devlet == 0 || halk == 0 || ekonomi == 0 || din == 0)
            {
                Console.Clear();
                Console.WriteLine("💀 DÜZEN ÇÖKTÜ");
                Console.WriteLine("Hayatta kalınan tur: " + tur);
                Console.ReadLine();
                break;
            }

            tur++;
            Console.WriteLine("\nDevam etmek için ENTER...");
            Console.ReadLine();
        }
    }
}
