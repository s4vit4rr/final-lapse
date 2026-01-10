using System;

namespace LapseCloneNoArrayNoMethod
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Başkan Simülatörü";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("==============================================");
            Console.WriteLine("       BAŞKAN SİMÜLATÖRÜ: ZOR ZAMANLAR        ");
            Console.WriteLine("==============================================");
            Console.ResetColor();

            Console.WriteLine("\n[HİKAYE]");
            Console.WriteLine("Tebrikler Sayın Başkan! Zorlu bir darbe girişimi ve ekonomik krizin");
            Console.WriteLine("ardından yönetimi devraldınız. Ülke uçurumun kenarında.");
            Console.WriteLine("Sınırda düşmanlar, içeride isyancılar, kasada ise fareler var.");
            Console.WriteLine("Amacınız: 50 kritik kararı atlatıp ülkeyi düzlüğe çıkarmak.");

            Console.WriteLine("\n[OYUN KURALLARI]");
            Console.WriteLine("1. Karşınıza çıkan olaylara '1' veya '2' tuşlarıyla cevap verin.");
            Console.WriteLine("2. Dört temel gücü dengede tutmalısınız: HALK, ORDU, PARA, DOĞA.");
            Console.WriteLine("3. DİKKAT: Bu göstergeler ne 0 olmalı ne de 100!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   - 0'a düşerse: Yok oluş (İsyan, İflas, İşgal...)");
            Console.WriteLine("   - 100'e çıkarsa: Felaket (Darbe, Enflasyon, Tembellik...)");
            Console.ResetColor();
            Console.WriteLine("4. Her karar bir şeyleri düzeltirken başka şeyleri bozabilir.");
            Console.WriteLine("5. Her 5 kararda bir (1 Yıl) geçer ve yaşlanırsınız.");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n>> Kayıt işlemlerine geçmek için bir tuşa basın... <<");
            Console.ResetColor();
            Console.ReadKey();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== RESMİ KAYIT EKRANI ===");
            Console.ResetColor();

            Console.Write("\nBaşkanın Adı ve Soyadı: ");
            string baskanAdi = Console.ReadLine();

            Console.Write("Yönetilecek Ülkenin Adı: ");
            string ulkeAdi = Console.ReadLine();

            Console.Write("Başkanın Başlangıç Yaşı: ");
            string yasGiris = Console.ReadLine();
            int baslangicYasi;

            if (int.TryParse(yasGiris, out baslangicYasi) == false)
            {
                baslangicYasi = 40;
            }

            int baslangicYili = 2026;

            Console.WriteLine("\nKaydınız oluşturuldu. Koltuğa geçiliyor...");
            System.Threading.Thread.Sleep(1500);

            int halk = 50;
            int ordu = 50;
            int para = 50;
            int doga = 50;

            int turSayisi = 1;
            bool oyunDevamEdiyor = true;

            string oynananOlaylar = "|";
            int toplamOlaySayisi = 50;
            int oynananOlaySayaci = 0;

            Random rastgele = new Random();

            while (oyunDevamEdiyor)
            {
                int gecenYil = (turSayisi - 1) / 5;
                int guncelYas = baslangicYasi + gecenYil;
                int guncelYil = baslangicYili + gecenYil;

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=======================================");
                Console.WriteLine($" BAŞKAN: {baskanAdi.ToUpper()} ({guncelYas})");
                Console.WriteLine($" ÜLKE  : {ulkeAdi.ToUpper()} CUMHURİYETİ");
                Console.WriteLine($" TARİH : {guncelYil} | Tur: {turSayisi}/{toplamOlaySayisi}");
                Console.WriteLine("=======================================");
                Console.ResetColor();

                Console.Write(" HALK: ");
                if (halk < 20 || halk > 80) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(halk + "  ");
                Console.ResetColor();

                Console.Write("ORDU: ");
                if (ordu < 20 || ordu > 80) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ordu + "  ");
                Console.ResetColor();

                Console.Write("PARA: ");
                if (para < 20 || para > 80) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(para + "  ");
                Console.ResetColor();

                Console.Write("DOĞA: ");
                if (doga < 20 || doga > 80) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(doga);
                Console.ResetColor();
                Console.WriteLine("---------------------------------------");

                string olumSebebi = "";
                if (halk <= 0) olumSebebi = $"Halk isyan etti. Sayın {baskanAdi}, sarayınız basıldı.";
                else if (halk >= 100) olumSebebi = $"Halk şımardı, {ulkeAdi} tembellikten battı.";
                else if (ordu <= 0) olumSebebi = $"{ulkeAdi} işgal edildi. Savunacak asker kalmadı.";
                else if (ordu >= 100) olumSebebi = $"General darbe yaptı. {baskanAdi} tutuklandı.";
                else if (para <= 0) olumSebebi = "İflas ettiniz. Ekonomi çöktü.";
                else if (para >= 100) olumSebebi = "Hiper enflasyon! Paranın değeri kalmadı.";
                else if (doga <= 0) olumSebebi = "Hava kirliliğinden boğuldunuz.";
                else if (doga >= 100) olumSebebi = "Doğa şehri geri aldı. İnsanlık ormana döndü.";

                if (olumSebebi != "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOYUN BİTTİ!");
                    Console.WriteLine(olumSebebi);
                    Console.ResetColor();
                    Console.WriteLine($"\nİktidarda Kaldığınız Süre: {gecenYil} Yıl ({turSayisi} Tur)");
                    Console.WriteLine($"Vefat Yaşı: {guncelYas}");
                    Console.ReadKey();
                    break;
                }

                if (oynananOlaySayaci >= toplamOlaySayisi)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nTEBRİKLER SAYIN {baskanAdi.ToUpper()}!");
                    Console.WriteLine($"{ulkeAdi} tarihinin en başarılı lideri oldunuz.");
                    Console.WriteLine($"Görevi bıraktığınızda yaşınız: {guncelYas}");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                }

                int secilenOlayID;
                while (true)
                {
                    int adayID = rastgele.Next(1, toplamOlaySayisi + 1);
                    string aranan = "|" + adayID + "|";

                    if (oynananOlaylar.IndexOf(aranan) == -1)
                    {
                        secilenOlayID = adayID;
                        oynananOlaylar += secilenOlayID + "|";
                        oynananOlaySayaci++;
                        break;
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nBİR OLAY GELİŞİYOR...\n");
                Console.ForegroundColor = ConsoleColor.Yellow;

                string secenek1 = "";
                string secenek2 = "";

                switch (secilenOlayID)
                {
                    case 1: Console.WriteLine("General sınırdaki komşu ülkeye saldırmak için izin istiyor."); secenek1 = "Saldır!"; secenek2 = "Barış korunsun."; break;
                    case 2: Console.WriteLine("Büyük bir maden rezervi bulundu. Ormanı yok edip madeni çıkaralım mı?"); secenek1 = "Kazın!"; secenek2 = "Doğayı koru."; break;
                    case 3: Console.WriteLine("Gizemli bir salgın yayılıyor. Karantina ilan edelim mi?"); secenek1 = "Tam kapanma."; secenek2 = "Hayat devam etsin."; break;
                    case 4: Console.WriteLine("Bilim insanları yapay zeka araştırmaları için fon istiyor."); secenek1 = "Ver gitsin."; secenek2 = "Çok riskli, reddet."; break;
                    case 5: Console.WriteLine("Halk vergilerin yüksekliğinden şikayetçi. İndirim yapalım mı?"); secenek1 = "İndirim yap."; secenek2 = "Devlete para lazım."; break;
                    case 6: Console.WriteLine("Kuzeyden gelen mülteciler sınıra dayandı."); secenek1 = "Kapıları aç."; secenek2 = "Sınırı kapat."; break;
                    case 7: Console.WriteLine("Büyük bir sel felaketi yaşandı. Yardıma orduyu gönderelim mi?"); secenek1 = "Ordu yardıma gitsin."; secenek2 = "Siviller halletsin."; break;
                    case 8: Console.WriteLine("Yabancı bir şirket dev bir fabrika kurmak istiyor."); secenek1 = "İzin ver."; secenek2 = "Reddet."; break;
                    case 9: Console.WriteLine("Casuslarımız komşu ülkede darbe planlıyor."); secenek1 = "Onaylıyorum."; secenek2 = "İptal et."; break;
                    case 10: Console.WriteLine("Eğitim sistemini dindar bir müfredata mı yoksa bilimsel bir müfredata mı çevirelim?"); secenek1 = "Geleneksel/Dini."; secenek2 = "Bilimsel/Modern."; break;
                    case 11: Console.WriteLine("Şehir merkezine dev bir heykelinizi dikmek istiyorlar."); secenek1 = "Harika olur!"; secenek2 = "İsraf, gerek yok."; break;
                    case 12: Console.WriteLine("Tarım ilaçlarının kullanımı arıları öldürüyor. Yasaklayalım mı?"); secenek1 = "Yasakla."; secenek2 = "Tarım devam etmeli."; break;
                    case 13: Console.WriteLine("Gizli bir yeraltı örgütü size rüşvet teklif ediyor."); secenek1 = "Parayı al."; secenek2 = "Onları tutukla!"; break;
                    case 14: Console.WriteLine("Uzaylılardan bir sinyal aldık. Cevap verelim mi?"); secenek1 = "Cevap ver!"; secenek2 = "Sessiz kal."; break;
                    case 15: Console.WriteLine("Dünya Bankası kredi teklif ediyor, ama doğayı sömürme şartıyla."); secenek1 = "Anlaşmayı imzala."; secenek2 = "Reddet."; break;
                    case 16: Console.WriteLine("Halk internette tam özgürlük ve sansürün kalkmasını istiyor."); secenek1 = "Sansürü kaldır."; secenek2 = "Kontrol şart."; break;
                    case 17: Console.WriteLine("Enerji krizi kapıda. Nükleer santral kuralım mı?"); secenek1 = "Kurulsun."; secenek2 = "Çok tehlikeli, hayır."; break;
                    case 18: Console.WriteLine("Olimpiyatlara ev sahipliği yapmak için başvuracak mıyız?"); secenek1 = "Başvur, prestijdir."; secenek2 = "Bütçemiz yetmez."; break;
                    case 19: Console.WriteLine("Sokak hayvanları için dev barınaklar yapılsın mı?"); secenek1 = "Yapılsın."; secenek2 = "Kaynak israfı."; break;
                    case 20: Console.WriteLine("Ordu envanterini yenilemek için devasa bir bütçe istiyor."); secenek1 = "Onayla."; secenek2 = "Reddet."; break;
                    case 21: Console.WriteLine("Sanatçılar devletten teşvik fonu talep ediyor."); secenek1 = "Destek ol."; secenek2 = "Sanat karın doyurmaz."; break;
                    case 22: Console.WriteLine("Hapishaneler doldu taştı. Genel af çıkaralım mı?"); secenek1 = "Af çıkar."; secenek2 = "Suçlular yatsın."; break;
                    case 23: Console.WriteLine("Geri dönüşümü zorunlu kılan katı yasalar getirelim mi?"); secenek1 = "Getir."; secenek2 = "Halkı sıkmayalım."; break;
                    case 24: Console.WriteLine("Özel bir şirket uzay madenciliği için vergi muafiyeti istiyor."); secenek1 = "Muafiyet ver."; secenek2 = "Herkes vergi ödeyecek."; break;
                    case 25: Console.WriteLine("İnsan klonlama deneylerine gizlice izin verelim mi?"); secenek1 = "Bilim için evet."; secenek2 = "Bu günahtır/etiktir."; break;
                    case 26: Console.WriteLine("Fabrikalardaki robotlar işçilerin yerini alıyor. Müdahale edelim mi?"); secenek1 = "Robotları kısıtla."; secenek2 = "Teknoloji ilerlemeli."; break;
                    case 27: Console.WriteLine("Su kaynaklarını özelleştirip satalım mı?"); secenek1 = "Sat, para lazım."; secenek2 = "Su haktır, satılamaz."; break;
                    case 28: Console.WriteLine("Müzedeki tarihi eserleri satıp dış borcu ödeyelim mi?"); secenek1 = "Sat gitsin."; secenek2 = "Tarih satılamaz."; break;
                    case 29: Console.WriteLine("Milli marşı daha modern bir besteyle değiştirelim mi?"); secenek1 = "Değiştir."; secenek2 = "Eskisi kalsın."; break;
                    case 30: Console.WriteLine("Nüfus patlaması var. Tek çocuk politikası uygulayalım mı?"); secenek1 = "Uygula."; secenek2 = "Özgürlüğe karışma."; break;
                    case 31: Console.WriteLine("Suç oranları arttı. Gece sokağa çıkma yasağı ilan edelim mi?"); secenek1 = "Yasakla."; secenek2 = "Özgürlük kalsın."; break;
                    case 32: Console.WriteLine("Tüm medya kanallarını tek bir holding satın almak istiyor."); secenek1 = "İzin ver."; secenek2 = "Tekelleşmeyi engelle."; break;
                    case 33: Console.WriteLine("GDO'lu tarım ürünlerine izin verelim mi?"); secenek1 = "Verim artar, izin ver."; secenek2 = "Sağlıksız, yasakla."; break;
                    case 34: Console.WriteLine("Zorunlu askerliği kaldıralım mı?"); secenek1 = "Kaldır, profesyonel olsun."; secenek2 = "Vatan borcudur, kalsın."; break;
                    case 35: Console.WriteLine("İlkokullarda tamamen yabancı dilde eğitime geçelim mi?"); secenek1 = "Geçelim, dünya dili."; secenek2 = "Ana dilimiz yeter."; break;
                    case 36: Console.WriteLine("Turizmi canlandırmak için kumarhaneleri yasal yapalım mı?"); secenek1 = "Yasallaştır."; secenek2 = "Ahlakı bozar."; break;
                    case 37: Console.WriteLine("Açık havada bile sigara içmeyi yasaklayalım mı?"); secenek1 = "Yasakla, sağlık önemli."; secenek2 = "Abartmayalım."; break;
                    case 38: Console.WriteLine("Tüm ülkeyi kapsayan bir hızlı tren ağı kuralım mı?"); secenek1 = "Kur."; secenek2 = "Çok pahalı."; break;
                    case 39: Console.WriteLine("Antik bir kentin üzerine AVM yapmak istiyorlar."); secenek1 = "İnşaata izin ver."; secenek2 = "Korumaya al."; break;
                    case 40: Console.WriteLine("Plastik poşetleri ve pipetleri tamamen yasaklayalım mı?"); secenek1 = "Yasakla."; secenek2 = "Halk tepki gösterir."; break;
                    case 41: Console.WriteLine("Hükümetin gizli belgeleri internete sızdı."); secenek1 = "Montaj de, yalanla."; secenek2 = "İtiraf et, özür dile."; break;
                    case 42: Console.WriteLine("Muhalifleri izlemek için gizli bir polis teşkilatı kuralım mı?"); secenek1 = "Kur, güvenlik şart."; secenek2 = "Demokrasiye aykırı."; break;
                    case 43: Console.WriteLine("Mahkemelerde yargıç yerine Yapay Zeka karar versin mi?"); secenek1 = "Yapay Zeka geçsin."; secenek2 = "İnsan vicdanı şart."; break;
                    case 44: Console.WriteLine("Uluslararası Mars kolonisi projesine bütçe ayıralım mı?"); secenek1 = "Ayır, gelecek uzayda."; secenek2 = "Dünyadaki sorunlar bitmedi."; break;
                    case 45: Console.WriteLine("Kripto paraları ülkede tamamen yasaklayalım mı?"); secenek1 = "Yasakla."; secenek2 = "Serbest bırak."; break;
                    case 46: Console.WriteLine("Devlet tüm halka ücretsiz ve sınırsız internet versin mi?"); secenek1 = "Ver."; secenek2 = "Hazine batar."; break;
                    case 47: Console.WriteLine("Süper zenginlere %90 varlık vergisi getirelim mi?"); secenek1 = "Getir."; secenek2 = "Sermaye kaçar, yapma."; break;
                    case 48: Console.WriteLine("Müzeler ve ören yerleri halka tamamen ücretsiz olsun mu?"); secenek1 = "Olsun."; secenek2 = "Bakım masrafı var."; break;
                    case 49: Console.WriteLine("Orman yangınları için uçak filosu mu kuralım yoksa dua mı edelim?"); secenek1 = "Uçak filosu kur."; secenek2 = "Masrafsız yolu seç."; break;
                    case 50: Console.WriteLine("Bilim insanları paralel evrene geçit açmak için izin istiyor."); secenek1 = "İzin ver, keşif zamanı!"; secenek2 = "Kıyamet kopabilir, hayır."; break;
                }

                Console.ResetColor();
                Console.WriteLine("\nSEÇİMİNİZ:");
                Console.WriteLine($"[1] {secenek1}");
                Console.WriteLine($"[2] {secenek2}");

                bool secimYapildi = false;
                while (!secimYapildi)
                {
                    ConsoleKeyInfo tus = Console.ReadKey(true);

                    if (tus.Key == ConsoleKey.D1 || tus.Key == ConsoleKey.NumPad1)
                    {
                        if (secilenOlayID == 1) { halk -= 10; ordu += 15; para -= 10; doga -= 5; }
                        else if (secilenOlayID == 2) { para += 20; doga -= 20; }
                        else if (secilenOlayID == 3) { halk -= 15; para -= 15; doga += 10; }
                        else if (secilenOlayID == 4) { para -= 15; ordu += 10; halk += 5; }
                        else if (secilenOlayID == 5) { halk += 15; para -= 15; }
                        else if (secilenOlayID == 6) { halk += 10; para -= 10; ordu -= 5; }
                        else if (secilenOlayID == 7) { halk += 10; ordu -= 10; doga -= 5; }
                        else if (secilenOlayID == 8) { para += 20; doga -= 15; halk += 5; }
                        else if (secilenOlayID == 9) { ordu += 15; para -= 15; halk -= 5; }
                        else if (secilenOlayID == 10) { halk += 10; ordu += 5; para -= 5; }
                        else if (secilenOlayID == 11) { halk += 5; para -= 15; doga -= 5; }
                        else if (secilenOlayID == 12) { doga += 20; para -= 10; halk -= 5; }
                        else if (secilenOlayID == 13) { para += 25; halk -= 15; ordu -= 10; }
                        else if (secilenOlayID == 14) { doga -= 10; ordu += 10; halk += 5; }
                        else if (secilenOlayID == 15) { para += 20; doga -= 20; }
                        else if (secilenOlayID == 16) { halk += 15; ordu -= 5; para -= 5; }
                        else if (secilenOlayID == 17) { para += 10; doga -= 10; halk -= 5; }
                        else if (secilenOlayID == 18) { para -= 20; halk += 10; ordu += 5; }
                        else if (secilenOlayID == 19) { halk += 10; para -= 10; }
                        else if (secilenOlayID == 20) { ordu += 20; para -= 20; }
                        else if (secilenOlayID == 21) { halk += 5; para -= 5; }
                        else if (secilenOlayID == 22) { halk -= 10; para += 5; ordu -= 5; }
                        else if (secilenOlayID == 23) { doga += 15; halk -= 5; para -= 5; }
                        else if (secilenOlayID == 24) { para += 5; }
                        else if (secilenOlayID == 25) { halk += 5; }
                        else if (secilenOlayID == 26) { para += 10; halk -= 5; }
                        else if (secilenOlayID == 27) { halk += 10; para -= 5; }
                        else if (secilenOlayID == 28) { halk += 5; para -= 5; }
                        else if (secilenOlayID == 29) { halk += 5; }
                        else if (secilenOlayID == 30) { doga -= 5; halk += 10; }
                        else if (secilenOlayID == 31) { ordu -= 5; halk += 5; }
                        else if (secilenOlayID == 32) { halk += 5; para -= 5; }
                        else if (secilenOlayID == 33) { para -= 5; doga += 5; halk += 5; }
                        else if (secilenOlayID == 34) { ordu += 10; halk -= 5; }
                        else if (secilenOlayID == 35) { halk += 5; }
                        else if (secilenOlayID == 36) { halk += 5; para -= 5; }
                        else if (secilenOlayID == 37) { halk += 5; doga -= 5; }
                        else if (secilenOlayID == 38) { para += 10; halk -= 5; }
                        else if (secilenOlayID == 39) { para -= 5; halk += 5; }
                        else if (secilenOlayID == 40) { halk += 5; doga -= 10; }
                        else if (secilenOlayID == 41) { halk += 5; ordu -= 5; }
                        else if (secilenOlayID == 42) { halk += 10; ordu -= 5; }
                        else if (secilenOlayID == 43) { halk += 5; }
                        else if (secilenOlayID == 44) { para += 5; }
                        else if (secilenOlayID == 45) { para += 10; halk -= 5; }
                        else if (secilenOlayID == 46) { para += 5; halk -= 5; }
                        else if (secilenOlayID == 47) { para -= 10; ordu += 5; }
                        else if (secilenOlayID == 48) { para += 5; halk -= 5; }
                        else if (secilenOlayID == 49) { para += 5; doga -= 15; }
                        else if (secilenOlayID == 50) { doga += 5; }

                        secimYapildi = true;
                    }
                    else if (tus.Key == ConsoleKey.D2 || tus.Key == ConsoleKey.NumPad2)
                    {
                        if (secilenOlayID == 1) { halk += 5; ordu -= 10; para += 5; doga += 5; }
                        else if (secilenOlayID == 2) { para -= 10; doga += 10; }
                        else if (secilenOlayID == 3) { halk -= 20; para += 5; ordu -= 10; }
                        else if (secilenOlayID == 4) { para += 5; halk -= 5; }
                        else if (secilenOlayID == 5) { halk -= 10; para += 10; }
                        else if (secilenOlayID == 6) { halk -= 10; ordu += 5; para += 5; }
                        else if (secilenOlayID == 7) { halk -= 15; ordu += 5; para += 5; }
                        else if (secilenOlayID == 8) { para -= 10; doga += 10; halk -= 5; }
                        else if (secilenOlayID == 9) { ordu -= 10; para += 5; halk += 5; }
                        else if (secilenOlayID == 10) { halk -= 10; ordu -= 5; para += 10; doga += 5; }
                        else if (secilenOlayID == 11) { halk += 5; para += 5; ordu -= 5; }
                        else if (secilenOlayID == 12) { doga -= 15; para += 10; halk += 5; }
                        else if (secilenOlayID == 13) { para -= 5; ordu += 15; halk += 5; }
                        else if (secilenOlayID == 14) { doga += 5; ordu -= 5; halk -= 5; }
                        else if (secilenOlayID == 15) { para -= 10; doga += 10; }
                        else if (secilenOlayID == 16) { halk -= 5; ordu += 5; }
                        else if (secilenOlayID == 17) { para -= 5; doga += 5; }
                        else if (secilenOlayID == 18) { para += 5; halk -= 5; }
                        else if (secilenOlayID == 19) { halk -= 5; para += 5; }
                        else if (secilenOlayID == 20) { ordu -= 10; para += 5; }
                        else if (secilenOlayID == 21) { halk -= 5; para += 5; }
                        else if (secilenOlayID == 22) { halk += 5; para -= 5; }
                        else if (secilenOlayID == 23) { doga -= 10; halk += 5; }
                        else if (secilenOlayID == 24) { para += 5; }
                        else if (secilenOlayID == 25) { halk += 5; }
                        else if (secilenOlayID == 26) { para += 10; halk -= 5; }
                        else if (secilenOlayID == 27) { halk += 10; para -= 5; }
                        else if (secilenOlayID == 28) { halk += 5; para -= 5; }
                        else if (secilenOlayID == 29) { halk += 5; }
                        else if (secilenOlayID == 30) { doga -= 5; halk += 10; }
                        else if (secilenOlayID == 31) { ordu -= 5; halk += 5; }
                        else if (secilenOlayID == 32) { halk += 5; para -= 5; }
                        else if (secilenOlayID == 33) { para -= 5; doga += 5; halk += 5; }
                        else if (secilenOlayID == 34) { ordu += 10; halk -= 5; }
                        else if (secilenOlayID == 35) { halk += 5; }
                        else if (secilenOlayID == 36) { halk += 5; para -= 5; }
                        else if (secilenOlayID == 37) { halk += 5; doga -= 5; }
                        else if (secilenOlayID == 38) { para += 10; halk -= 5; }
                        else if (secilenOlayID == 39) { para -= 5; halk += 5; }
                        else if (secilenOlayID == 40) { halk += 5; doga -= 10; }
                        else if (secilenOlayID == 41) { halk += 5; ordu -= 5; }
                        else if (secilenOlayID == 42) { halk += 10; ordu -= 5; }
                        else if (secilenOlayID == 43) { halk += 5; }
                        else if (secilenOlayID == 44) { para += 5; }
                        else if (secilenOlayID == 45) { para += 10; halk -= 5; }
                        else if (secilenOlayID == 46) { para += 5; halk -= 5; }
                        else if (secilenOlayID == 47) { para -= 10; ordu += 5; }
                        else if (secilenOlayID == 48) { para += 5; halk -= 5; }
                        else if (secilenOlayID == 49) { para += 5; doga -= 15; }
                        else if (secilenOlayID == 50) { doga += 5; }

                        secimYapildi = true;
                    }
                }

                turSayisi++;
            }
        }
    }
}