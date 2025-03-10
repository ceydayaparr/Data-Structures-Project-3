using System;
using System.Xml.Linq;

public class BinarySearchTree
{
    public class Node
    {
        public string Data;
        public Node Left, Right;

        public Node(string data)
        {
            Data = data;
            Left = Right = null;
        }
    }

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

        if (string.Compare(data, root.Data) < 0)
            root.Left = InsertRec(root.Left, data);
        else if (string.Compare(data, root.Data) > 0)
            root.Right = InsertRec(root.Right, data);

        return root;
    }

    public void InOrderTraversal()
    {
        InOrderTraversalRec(root);
    }

    private void InOrderTraversalRec(Node root)
    {
        if (root != null)
        {
            InOrderTraversalRec(root.Left);
            Console.WriteLine(root.Data);
            InOrderTraversalRec(root.Right);
        }
    }


    public void BuildBalancedTree(string[] sortedArray)
    {
        root = BuildBalancedTreeRec(sortedArray, 0, sortedArray.Length - 1);
    }

    private Node BuildBalancedTreeRec(string[] sortedArray, int start, int end)
    {
        if (start > end)
            return null;

        int mid = (start + end) / 2;
        Node newNode = new Node(sortedArray[mid]);

        newNode.Left = BuildBalancedTreeRec(sortedArray, start, mid - 1);
        newNode.Right = BuildBalancedTreeRec(sortedArray, mid + 1, end);

        return newNode;
    }

  
    public void BalanceTree()
    {
        string[] sortedArray = InOrderToArray(root);
        root = BuildBalancedTreeRec(sortedArray, 0, sortedArray.Length - 1);
    }

    private string[] InOrderToArray(Node root)
    {
        System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
        InOrderToArrayRec(root, list);
        return list.ToArray();
    }

   
    private void InOrderToArrayRec(Node root, System.Collections.Generic.List<string> list)
    {
        if (root != null)
        {
            InOrderToArrayRec(root.Left, list);
            list.Add(root.Data);
            InOrderToArrayRec(root.Right, list);
        }
    }
}

class Program
{
    static void Main()
    {
        BinarySearchTree tree = new BinarySearchTree();

        
        string[] sites = {
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
    

        
        Array.Sort(sites);

        tree.BuildBalancedTree(sites);

        tree.BalanceTree();

       
        Console.WriteLine("Dengeli İkili Arama Ağacı:");
        tree.InOrderTraversal();
    }
}