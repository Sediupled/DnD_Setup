using System.Runtime.InteropServices;

namespace VS_CODE;

class DNDSETUP
{

    static string[] PlayerNames;


    static void Main(string[] args)
    {
        DNDSETUP dnd = new DNDSETUP();
        Console.WriteLine("My DND Setup");
        Console.Write("The Weight of your Crew: ");
        int amt = int.Parse(Console.ReadLine());
        dnd.DndManager(amt);
        Console.ReadLine();
    }

    public void DndManager(int players)
    {
        GetShowPlayerNames(players);
        DisplayMenu();
    }

    void GetShowPlayerNames(int players)
    {
        Character[] Player = new Character[players];
        PlayerNames = new string[players];


        for (int i = 0; i < players; i++) // Array traversal for picking character attributes and names
        {
            Console.WriteLine("Name Thyself: ");
            PlayerNames[i] = Console.ReadLine();

            Player[i] = new Character();
            CharacterOps charOps = new CharacterOps();
            charOps.CharacterSelectAtributes(Player[i]);
        }

        DisplaySheet(Player, PlayerNames);


    }


    void DisplaySheet(Character[] playing, String[] names)
    {
        CharacterOps charOps = new CharacterOps();

        Console.WriteLine("//===========THIS IS MY SHEET===========//");
        Console.WriteLine("");

        charOps.DisplayAttributes(playing, names);
        Console.WriteLine("//===========END OF SHEET===========//");

    }


    void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("//===============M-E-N-U===============//");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Choose your Option: ");
        Console.Write("1) Roll Dice      ");
        Console.Write("2) Generate Monster      ");
        Console.Write("3) Who's in Party?      ");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Here: ");

        int selection = Convert.ToInt32(Console.ReadLine());

        MenuSelector(selection);
        DisplayMenu();

    }

    void MenuSelector(int selection)
    {
        switch (selection)
        {
            case 1:
                RollDice();
                break;

            case 2:
                MonsterGen();
                break;

            case 3:
                WhoinParty();
                break;

            default:
                Console.WriteLine("Choose from options Please");
                break;

        }
    }




    void RollDice()
    {

        Console.WriteLine("Which Dice would you like to roll?");
        for (int i = 1; i < 10; i++)
        {
            int a = (2 + 2 * i);
            Console.WriteLine(i + "=)" + a);
        }
        int selection = Convert.ToInt32(Console.ReadLine());
        if (selection < 1 || selection > 9)
        {
            Console.WriteLine("Try Again, Value should be within limits of the Realm");
            RollDice();
        }
        else
        {
            var rand = new Random();

            int RealSelection = (2 * selection + 2);
            Console.WriteLine("You Chose the D" + RealSelection + " Dice.");
            Console.WriteLine("The Dice Shows: " + rand.Next(0, RealSelection));
        }

        DisplayMenu();

    }



    void MonsterGen()
    {
        var rand = new Random();
        string[] DiffArr = { "Easy", "Average", "Hard" };

        Console.WriteLine();
        Console.WriteLine("Choose according to No.: ");
        Console.WriteLine();
        Console.WriteLine();

        //display difficulty and chooser
        for (int i = 0; i < DiffArr.Length; i++)
        {
            Console.Write((i + 1) + ")" + " " + DiffArr[i] + "    ");
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();


        int selectionNo = Convert.ToInt32(Console.ReadLine());

        string diffSelect = DiffArr[selectionNo - 1];

        MonsterTraits(diffSelect);

        DisplayMenu();

    }

    void MonsterTraits(string h)
    {

        //Make orcs sexually assault, elf males        
        TextReader tr = new StreamReader(@"D:\DnDScene\MonList.txt");
        string readtr = tr.ReadLine();

        string[] NameList = readtr.Split(",");

        string[] sizeList = { "Tiny", "Small", "Medium", "Large", "Huge" };

        string[] typeList = { "Plant", "Humanoid", "Fiend", "Beast", "Dragon", "Elemental", "Monstrosity", "Giant", "Undead", "Fey", "Construct", "Aberration", "Ooze", "Celestial" };

        string[] alignmentList = { "Lawful Good", "Neutral Good", "Chaotic Good", "Lawful Neutral", "True Neutral", "Chaotic Neutral", "Lawful Evil", "Neutral Evil", "Chaotic Evil" };


        var rand = new Random();

        string Name = NameList[rand.Next(NameList.Length)];
        string type = typeList[rand.Next(typeList.Length)];
        int Hp;
        string size;
        string alignment = alignmentList[rand.Next(alignmentList.Length)];


        if (h == "Easy")
        {
            Hp = rand.Next(0, 30);
            size = sizeList[rand.Next(2)];
        }
        if (h == "Average")
        {
            Hp = rand.Next(30, 60);
            size = sizeList[rand.Next(2, 4)];
        }
        else
        {
            Hp = rand.Next(60, 100);
            size = sizeList[rand.Next(4, 5)];
        }



        Console.WriteLine("Name : " + Name);

        Console.WriteLine("Health : " + Hp);

        Console.WriteLine("Size : " + size);

        Console.WriteLine("Type : " + type);

        Console.WriteLine("Alignment : " + alignment);

    }


    void WhoinParty()
    {
        for (int i = 0; i < PlayerNames.Length; i++)
        {
            Console.WriteLine("[" + (i + 1) + "]" + PlayerNames[i]);
        }
    }

}
