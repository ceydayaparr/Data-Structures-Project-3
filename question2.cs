using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    public class UM_Alanı
    {
        public string Alan_Adı { get; set; }
        public List<string> İl_Adları { get; set; }
        public int İlan_Yılı { get; set; }
    }

    static void Main()
    {
        Hashtable alanHash = new Hashtable();

        string[] mirasAlanları =  {
            "Divriği Ulu Camii ve Darüşşifası,Sivas,1985",
            "İstanbul'un Tarihi Alanları,İstanbul,1985",
            "Göreme Millî Parkı ve Kapadokya,Nevşehir,1985",
            "Hattuşa: Hitit Başkenti,Çorum,1986",
            "Nemrut Dağı,Adıyaman,1987",
            "Hieropolis-Pamukkale,Denizli,1988",
            "Xanthos-Letoon,Antalya-Muğla,1988",
            "Safranbolu Şehri,Karabük,1994",
            "Truva Arkeolojik Alanı,Çanakkale,1998",
            "Edirne Selimiye Camii ve Külliyesi,Edirne,2011",
            "Çatalhöyük Neolitik Alanı,Konya,2012",
            "Bursa ve Cumalıkızık: Osmanlı İmparatorluğunun Doğuşu,Bursa,2014",
            "Bergama Çok Katmanlı Kültürel Peyzaj Alanı,İzmir,2014",
            "Diyarbakır Kalesi ve Hevsel Bahçeleri Kültürel Peyzajı,Diyarbakır,2015",
            "Efes,İzmir,2015",
            "Ani Arkeolojik Alanı,Kars,2016",
            "Aphrodisias,Aydın,2017",
            "Göbekli Tepe,Şanlıurfa,2018",
            "Arslantepe Höyüğü,Malatya,2021",
            "Gordion,Ankara,2023",
            "Anadolu’nun Ortaçağ Dönemi Ahşap Hipostil Camiileri,(Konya-Eşrefoğlu Camii- Kastamonu-Mahmut Bey Camii- Eskişehir-Sivrihisar Camii- Afyon-Afyon Ulu Camii- Ankara-Arslanhane Camii),2023"

        };

        foreach (var alanVerisi in mirasAlanları)
        {
            string[] alanBilgileri = alanVerisi.Split(',');
            UM_Alanı umAlan = new UM_Alanı
            {
                Alan_Adı = alanBilgileri[0],
                İl_Adları = new List<string> { alanBilgileri[1] },
                İlan_Yılı = int.Parse(alanBilgileri[2])
            };

            alanHash.Add(umAlan.Alan_Adı, umAlan);
        }

        Console.WriteLine("Hash Table'ın İlk Hali:");
        TumAlanlariYazdir(alanHash);

        Console.Write("Değiştirmek istediğiniz alanın adını girin: ");
        string eskiAlanAdi = Console.ReadLine();

        if (alanHash.ContainsKey(eskiAlanAdi))
        {
            UM_Alanı eskiAlan = (UM_Alanı)alanHash[eskiAlanAdi];

            Console.Write("Yeni adı girin: ");
            string yeniAlanAdi = Console.ReadLine();

            eskiAlan.Alan_Adı = yeniAlanAdi;

           
            alanHash.Remove(eskiAlanAdi);
            alanHash.Add(yeniAlanAdi, eskiAlan);

            Console.WriteLine($"{eskiAlanAdi} adlı alanın adı, {yeniAlanAdi} olarak değiştirildi.");

            Console.WriteLine("Güncellenmiş Hash Table:");
            TumAlanlariYazdir(alanHash);
        }
        else
        {
            Console.WriteLine($"{eskiAlanAdi} adlı bir UNESCO mirası alanı bulunamadı.");
        }
    }

    static void TumAlanlariYazdir(Hashtable alanHash)
    {
        foreach (DictionaryEntry entry in alanHash)
        {
            UM_Alanı alan = (UM_Alanı)entry.Value;
            Console.WriteLine($"Alan Adı: {alan.Alan_Adı} - İller: {string.Join(", ", alan.İl_Adları)} - İlan Yılı: {alan.İlan_Yılı}");
        }
    }
}