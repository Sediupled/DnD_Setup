namespace VS_CODE;

class DNDSETUP
{
    static void Main(string[] args)
    {
        Console.WriteLine("My DND Setup");
        Console.WriteLine("The Weight of your Crew: ");
        int amt = int.Parse(Console.ReadLine());
        DndManager(amt);
        Console.ReadLine();
    }

    public static void DndManager(int players)
    {
        GameSetup(players);
    }

    static void GameSetup(int players)
    {
        GetPlayerNames(players);
        //RollDice();
    }

    static void GetPlayerNames(int players)
    {
        Character[] Player = new Character[players];
        Player = new Character[players];
        String[] PlayerNames = new string[players];


        for (int i = 0; i < players; i++) // Array traversal for picking character attributes and names
        {
            Console.WriteLine("Name Thyself: ");
            PlayerNames[i] = Console.ReadLine();

            Player[i] = new Character();
            CharacterOps charOps = new CharacterOps();
            charOps.CharacterSelectAtributes(Player[i]);
        }

        DisplaySheet(players, Player, PlayerNames);


    }

    static void DisplaySheet(int players, Character[] playing, String[] names)
    {
        CharacterOps charOps = new CharacterOps();

        Console.WriteLine("//===========THIS IS MY SHEET===========//");
        Console.WriteLine("");

        charOps.DisplayAttributes(playing, names);
        Console.WriteLine("//===========END OF SHEET===========//");
    }


    static void RollDice()
    {

        Console.WriteLine("Which Dice would you like to roll?");
        for (int i = 1; i < 10; i++)
        {
            int a = (2 + 2 * i);
            Console.WriteLine(i + "=)" + a);
        }
        int selection = Convert.ToInt32(Console.ReadLine());
        if (selection<1 || selection>9)
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






    }
    static void MonsterGen()
    {
        //
    }



}
