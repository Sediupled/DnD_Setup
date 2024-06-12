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
        //Input Dice number
        //DiceRoll if 20,10,12,8,6,4 then do roll, notice dice = 2 + 2x(from 0-8)
        //if not then ask again for currect dice

        //show dice animation
        //show picture on screen
    }
    static void MonsterGen()
    {
        //Generates Monster with certain ability traits
    }



}
