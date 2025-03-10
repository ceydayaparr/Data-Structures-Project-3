using System;
using System.Collections.Generic;

class UM_Alanı
{
    public string AlanAdi { get; set; }
    public List<string> Words { get; set; } 

    public UM_Alanı(string alanAdi)
    {
        AlanAdi = alanAdi;
        Words = new List<string>();
    }
}

class Node
{
    public string Data;
    public Node Left, Right;

    public Node(string data)
    {
        Data = data;
        Left = Right = null;
    }
}

class BinarySearchTree
{
    private Node root;

    public BinarySearchTree()
    {
        root = null;
    }

    public void Insert(string data)
    {
        root = InsertRec(root, data);
    }

    private Node InsertRec(Node root, string data)
    {
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        if (string.Compare(data, root.Data, StringComparison.Ordinal) < 0)
            root.Left = InsertRec(root.Left, data);
        else if (string.Compare(data, root.Data, StringComparison.Ordinal) > 0)
            root.Right = InsertRec(root.Right, data);

        return root;
    }

    public bool Search(string data)
    {
        return SearchRec(root, data);
    }

    private bool SearchRec(Node root, string data)
    {
        if (root == null)
            return false;

        if (data == root.Data)
            return true;

        if (string.Compare(data, root.Data, StringComparison.Ordinal) < 0)
            return SearchRec(root.Left, data);

        return SearchRec(root.Right, data);
    }

    public void AddWordsToAlan(string alanAdi, string paragraph)
    {
        Node alanNode = FindNode(root, alanAdi);
        if (alanNode != null)
        {
            UM_Alanı umAlanı = new UM_Alanı(alanAdi);

            string[] words = paragraph.Split(new[] { ' ', ',', '.', ':', ';', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                umAlanı.Words.Add(word.ToLower()); 
            }

            Console.WriteLine($"Words for {alanAdi}: {string.Join(", ", umAlanı.Words)}");

            
        }
        else
        {
            Console.WriteLine($"{alanAdi} not found.");
        }
    }

    private Node FindNode(Node root, string data)
    {
        if (root == null)
            return null;

        if (string.Compare(data, root.Data, StringComparison.Ordinal) == 0)
            return root;

        if (string.Compare(data, root.Data, StringComparison.Ordinal) < 0)
            return FindNode(root.Left, data);

        return FindNode(root.Right, data);
    }

    public void ListAllNodesAndDepth()
    {
        Console.WriteLine("List of All Nodes and Their Depth:");
        ListAllNodesAndDepth(root, 1);
    }

    private void ListAllNodesAndDepth(Node node, int depth)
    {
        if (node != null)
        {
            Console.WriteLine($"{node.Data} - Depth: {depth}");
            ListAllNodesAndDepth(node.Left, depth + 1);
            ListAllNodesAndDepth(node.Right, depth + 1);
        }
    }

   
    public int CountNodes()
    {
        return CountNodes(root);
    }

    private int CountNodes(Node node)
    {
        if (node == null)
            return 0;

        return 1 + CountNodes(node.Left) + CountNodes(node.Right);
    }

    
    public int CalculateBalancedDepth()
    {
        int totalNodes = CountNodes();
        return (int)Math.Ceiling(Math.Log2(totalNodes + 1)) - 1;
    }
    public void ListAlansBetweenLetters(char startLetter, char endLetter)
    {
        ListAlansBetweenLetters(root, startLetter, endLetter);
    }

    private void ListAlansBetweenLetters(Node root, char startLetter, char endLetter)
    {
        if (root == null)
            return;

       
        ListAlansBetweenLetters(root.Left, startLetter, endLetter);

        string alanAdi = root.Data;
        char firstChar = char.ToLower(alanAdi[0]);

        if (firstChar >= char.ToLower(startLetter) && firstChar <= char.ToLower(endLetter))
        {
            Console.WriteLine(alanAdi);
        }

        ListAlansBetweenLetters(root.Right, startLetter, endLetter);
    }
}

class Program
{
    static void Main()
    {
        BinarySearchTree tree = new BinarySearchTree();

        string[] alanAdlari = {
            "Divriği Ulu Camii",
            "İstanbul'un Tarihi Alanları",
            "Göreme Millî Parkı",
            "Hattuşa : Hitit Başkenti",
            "Nemrut Dağı",
            "Hieropolis-Pamukkale",
            "Xanthos-Letoon" ,
            "Safranbolu Şehri",
            "Truva Arkeolojik Alanı",
            "Edirne Selimiye Camii ve Külliyesi",
            "Çatalhöyük Neolitik Alanı",
            "Bursa ve Cumalıkızık: Osmanlı İmparatorluğunun Doğuşu",
            "Bergama Çok Katmanlı Kültürel Peyzaj Alanı",
            "Diyarbakır Kalesi ve Hevsel Bahçeleri Kültürel Peyzajı",
            "Efes",
            "Ani Arkeolojik Alanı",
            "Aphrodisias" ,
            "Göbekli Tepe" ,
            "Arslantepe Höyüğü",
            "Gordion",
            "Anadolu’nun Ortaçağ Dönemi Ahşap Hipostil Camiileri"
       
    };

        foreach (var alanAdi in alanAdlari)
        {
            tree.Insert(alanAdi);
        }

      

        string sampleParagraph_1 = "Located in southwestern Turkey, in the upper valley of the Morsynus River, the site consists of two components: the archaeological site of Aphrodisias and the marble quarries northeast of the city. The temple of Aphrodite dates from the 3rd century BC and the city was built one century later. The wealth of Aphrodisias came from the marble quarries and the art produced by its sculptors. The city streets are arranged around several large civic structures, which include temples, a theatre, an agora and two bath complexes.";
        string sampleParagraph_2 = "This site is located on a secluded plateau of northeast Turkey overlooking a ravine that forms a natural border with Armenia. This medieval city combines residential, religious and military structures, characteristic of a medieval urbanism built up over the centuries by Christian and then Muslim dynasties. The city flourished in the 10th and 11th centuries CE when it became the capital of the medieval Armenian kingdom of the Bagratides and profited from control of one branch of the Silk Road. Later, under Byzantine, Seljuk and Georgian sovereignty, it maintained its status as an important crossroads for merchant caravans. The Mongol invasion and a devastating earthquake in 1319 marked the beginning of the city’s decline. The site presents a comprehensive overview of the evolution of medieval architecture through examples of almost all the different architectural innovations of the region between the 7th and 13th centuries CE.";
        string sampleParagraph_3 = "Troy, with its 4,000 years of history, is one of the most famous archaeological sites in the world. The first excavations at the site were undertaken by the famous archaeologist Heinrich Schliemann in 1870. In scientific terms, its extensive remains are the most significant demonstration of the first contact between the civilizations of Anatolia and the Mediterranean world. Moreover, the siege of Troy by Spartan and Achaean warriors from Greece in the 13th or 12th century B.C., immortalized by Homer in the Iliad, has inspired great creative artists throughout the world ever since.";
        string sampleParagraph_4 = "The extensive and systematic excavations of the palace complex, full of material in situ, have allowed to reconstruct the characteristics of this civilization, the life of these early elites and their activities in incomparable detail, enlightening this early period of establishment of governance and administration systems controlling the economy of the population and exercising a central political authority. The palace complex hence illustrates an exceptionally well-preserved testimony of the comparatively short period between 3400 and 3100 BCE, when Arslantepe was a centre of governance in the region.";
        string sampleParagraph_5 = "Located on the slopes of Uludağ Mountain in the north-western part of Turkey, Bursa and Cumalıkızık represent the creation of an urban and rural system establishing the first capital city of the Ottoman Empire and the Sultan’s seat in the early 14th century. In the empire’s establishment process, Bursa became the first city, which was shaped by kulliyes, in the context of waqf (public endowments) system determining the expansion of the city and its architectural and stylistic traditions.";
        string sampleParagraph_6 = "From the 13th century to the advent of the railway in the early 20th century, Safranbolu was an important caravan station on the main East–West trade route. The Old Mosque, Old Bath and Süleyman Pasha Medrese were built in 1322. During its apogee in the 17th century, Safranbolu's architecture influenced urban development throughout much of the Ottoman Empire.";
        string sampleParagraph_7 = "Located on an escarpment of the Upper Tigris River Basin that is part of the so-called Fertile Crescent, the fortified city of Diyarbakır and the landscape around has been an important centre since the Hellenistic period, through the Roman, Sassanid, Byzantine, Islamic and Ottoman times to the present. The site encompasses the Inner castle, known as İçkale and including the Amida Mound, and the 5.8 km-long city walls of Diyarbakır with their numerous towers, gates, buttresses, and 63 inscriptions. The site also includes the Hevsel Gardens, a green link between the city and the Tigris that supplied the city with food and water, the Anzele water source and the Ten-Eyed Bridge.";
        string sampleParagraph_8 = "Located within what was once the estuary of the River Kaystros, Ephesus comprises successive Hellenistic and Roman settlements founded on new locations, which followed the coastline as it retreated westward. Excavations have revealed grand monuments of the Roman Imperial period including the Library of Celsus and the Great Theatre. Little remains of the famous Temple of Artemis, one of the “Seven Wonders of the World,” which drew pilgrims from all around the Mediterranean. Since the 5th century, the House of the Virgin Mary, a domed cruciform chapel seven kilometres from Ephesus, became a major place of Christian pilgrimage. The Ancient City of Ephesus is an outstanding example of a Roman port city, with sea channel and harbour basin.";
        string sampleParagraph_9 = "Located in the Germuş mountains of south-eastern Anatolia, this property presents monumental round-oval and rectangular megalithic structures erected by hunter-gatherers in the Pre-Pottery Neolithic age between 9,600 and 8,200 BCE. These monuments were probably used in connection with rituals, most likely of a funerary nature. Distinctive T-shaped pillars are carved with images of wild animals, providing insight into the way of life and beliefs of people living in Upper Mesopotamia about 11,500 years ago.";
        string sampleParagraph_10 = "Located in an open rural landscape, the archaeological site of Gordion is a multi-layered ancient settlement, encompassing the remains of the ancient capital of Phrygia, an Iron Age independent kingdom. The key elements of this archaeological site include the Citadel Mound, the Lower Town, the Outer Town and Fortifications, and several burial mounds and tumuli with their surrounding landscape. Archaeological excavations and research have revealed a wealth of remains that document construction techniques, spatial arrangements, defensive structures, and inhumation practices that shed light on Phrygian culture and economy.";
        string sampleParagraph_11 = "This region of Anatolia was conquered by the Turks at the beginning of the 11th century. In 1228–29 Emir Ahmet Shah founded a mosque, with its adjoining hospital, at Divrigi. The mosque has a single prayer room and is crowned by two cupolas. The highly sophisticated technique of vault construction, and a creative, exuberant type of decorative sculpture – particularly on the three doorways, in contrast to the unadorned walls of the interior – are the unique features of this masterpiece of Islamic architecture.";
        string sampleParagraph_12 = "The archaeological site of Hattusha, former capital of the Hittite Empire, is notable for its urban organization, the types of construction that have been preserved (temples, royal residences, fortifications), the rich ornamentation of the Lions' Gate and the Royal Gate, and the ensemble of rock art at Yazilikaya. The city enjoyed considerable influence in Anatolia and northern Syria in the 2nd millennium B.C";
        string sampleParagraph_13 = "With its strategic location on the Bosphorus peninsula between the Balkans and Anatolia, the Black Sea and the Mediterranean, Istanbul has been associated with major political, religious and artistic events for more than 2,000 years. Its masterpieces include the ancient Hippodrome of Constantine, the 6th-century Hagia Sophia and the 16th-century Süleymaniye Mosque, all now under threat from population pressure, industrial pollution and uncontrolled urbanization.";
        string sampleParagraph_14 = "The mausoleum of Antiochus I (69–34 B.C.), who reigned over Commagene, a kingdom founded north of Syria and the Euphrates after the breakup of Alexander's empire, is one of the most ambitious constructions of the Hellenistic period. The syncretism of its pantheon, and the lineage of its kings, which can be traced back through two sets of legends, Greek and Persian, is evidence of the dual origin of this kingdom's culture.";
        string sampleParagraph_15 = "Two hills form the 37 ha site on the Southern Anatolian Plateau. The taller eastern mound contains eighteen levels of Neolithic occupation between 7400 bc and 6200 bc, including wall paintings, reliefs, sculptures and other symbolic and artistic features. Together they testify to the evolution of social organization and cultural practices as humans adapted to a sedentary life. The western mound shows the evolution of cultural practices in the Chalcolithic period, from 6200 bc to 5200 bc. Çatalhöyük provides important evidence of the transition from settled villages to urban agglomeration, which was maintained in the same location for over 2,000 years. It features a unique streetless settlement of houses clustered back to back with roof access into the buildings.";
        string sampleParagraph_16 = "This site rises high above the Bakirçay Plain in Turkey’s Aegean region. The acropolis of Pergamon was the capital of the Hellenistic Attalid dynasty, a major centre of learning in the ancient world. Monumental temples, theatres, stoa or porticoes, gymnasium, altar and library were set into the sloping terrain surrounded by an extensive city wall. The rock-cut Kybele Sanctuary lies to the north-west on another hill visually linked to the acropolis. Later the city became capital of the Roman province of Asia known for its Asclepieion healing centre. The acropolis crowns a landscape containing burial mounds and remains of the Roman, Byzantine and Ottoman empires in and around the modern town of Bergama on the lower slopes.";
        string sampleParagraph_17 = "The square Mosque with its single great dome and four slender minarets, dominates the skyline of the former Ottoman capital of Edirne. Sinan, the most famous of Ottoman architects in the 16th century, considered the complex, which includes madrasas (Islamic schools), a covered market, clock house, outer courtyard and library, to be his best work. The interior decoration using Iznik tiles from the peak period of their production testifies to an art form that remains unsurpassed in this material. The complex is considered to be the most harmonious expression ever achieved of the Ottoman külliye, a group of buildings constructed around a mosque and managed as a single institution.";
        string sampleParagraph_18 = "This serial property is comprised of five hypostyle mosques built in Anatolia between the late 13th and mid-14th centuries, each located in a different province of present-day Türkiye. The unusual structural system of the mosques combines an exterior building envelope built of masonry with multiple rows of wooden interior columns (“hypostyle”) that support a flat wooden ceiling and the roof. These mosques are known for the skilful woodcarving and handiwork used in their structures, architectural fittings, and furnishings.";
        string sampleParagraph_19 = "This site, which was the capital of Lycia, illustrates the blending of Lycian traditions and Hellenic influence, especially in its funerary art. The epigraphic inscriptions are crucial for our understanding of the history of the Lycian people and their Indo-European language.";
        string sampleParagraph_20 = "In a spectacular landscape, entirely sculpted by erosion, the Göreme valley and its surroundings contain rock-hewn sanctuaries that provide unique evidence of Byzantine art in the post-Iconoclastic period. Dwellings, troglodyte villages and underground towns – the remains of a traditional human habitat dating back to the 4th century – can also be seen there.";
        string sampleParagraph_21 = "Deriving from springs in a cliff almost 200 m high overlooking the plain, calcite-laden waters have created at Pamukkale (Cotton Palace) an unreal landscape, made up of mineral forests, petrified waterfalls and a series of terraced basins. At the end of the 2nd century B.C. the dynasty of the Attalids, the kings of Pergamon, established the thermal spa of Hierapolis. The ruins of the baths, temples and other Greek monuments can be seen at the site.";
        
        tree.AddWordsToAlan("Aphrodisias", sampleParagraph_1);
        tree.AddWordsToAlan("Ani Arkeolojik Alanı", sampleParagraph_2);
        tree.AddWordsToAlan("Truva Arkeolojik Alanı", sampleParagraph_3);
        tree.AddWordsToAlan("Arslantepe Höyüğü", sampleParagraph_4);
        tree.AddWordsToAlan("Bursa ve Cumalıkızık: Osmanlı İmparatorluğunun Doğuşu", sampleParagraph_5);
        tree.AddWordsToAlan("Safranbolu Şehri", sampleParagraph_6);
        tree.AddWordsToAlan("Diyarbakır Kalesi ve Hevsel Bahçeleri Kültürel Peyzajı", sampleParagraph_7);
        tree.AddWordsToAlan("Efes", sampleParagraph_8);
        tree.AddWordsToAlan("Göbekli Tepe", sampleParagraph_9);
        tree.AddWordsToAlan("Gordion", sampleParagraph_10);
        tree.AddWordsToAlan("Divriği Ulu Camii", sampleParagraph_11);
        tree.AddWordsToAlan("Hattuşa : Hitit Başkenti", sampleParagraph_12);
        tree.AddWordsToAlan("İstanbul'un Tarihi Alanları", sampleParagraph_13);
        tree.AddWordsToAlan("Nemrut Dağı", sampleParagraph_14);
        tree.AddWordsToAlan("Çatalhöyük Neolitik Alanı", sampleParagraph_15);
        tree.AddWordsToAlan("Bergama Çok Katmanlı Kültürel Peyzaj Alanı", sampleParagraph_16);
        tree.AddWordsToAlan("Edirne Selimiye Camii ve Külliyesi", sampleParagraph_17);
        tree.AddWordsToAlan("Anadolu’nun Ortaçağ Dönemi Ahşap Hipostil Camiileri", sampleParagraph_18);
        tree.AddWordsToAlan("Xanthos-Letoon", sampleParagraph_19);
        tree.AddWordsToAlan("Göreme Millî Parkı", sampleParagraph_20);
        tree.AddWordsToAlan("Hieropolis-Pamukkale", sampleParagraph_21);

    
   
        tree.ListAllNodesAndDepth();

        int totalNodes = tree.CountNodes();
        Console.WriteLine($"Total number of nodes in the tree: {totalNodes}");

        
        int balancedDepth = tree.CalculateBalancedDepth();
        Console.WriteLine($"Ideal depth for a balanced tree: {balancedDepth}");

        Console.Write("Enter the start letter: ");
        char startLetter = char.ToLower(Console.ReadLine()[0]);

        Console.Write("Enter the end letter: ");
        char endLetter = char.ToLower(Console.ReadLine()[0]);

       
        tree.ListAlansBetweenLetters(startLetter, endLetter);
    }
}