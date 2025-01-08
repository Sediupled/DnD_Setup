using System;
using VS_CODE;
public class PaperLessDnDApp
{
    DNDSETUP dnd;

    public PaperLessDnDApp()
    {

        Console.WriteLine("My DND Setup");
        Console.Write("The Weight of your Crew: ");
        int playerAmt = int.Parse(Console.ReadLine());
        dnd = new DNDSETUP(playerAmt);
        createCharacters();
        DisplaySheet();
        DisplayMenu();
        Console.ReadLine();
    }

    Character CharacterSelectAttributes()
    {
        Console.WriteLine("Select your traits:-");
        Console.WriteLine("Name Thyself: ");
        string playerName = Console.ReadLine();

        Console.WriteLine("");
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("");
        Console.WriteLine("HealthBar: ");
        int healthBar = int.Parse(Console.ReadLine() ?? ("unset-Health"));

        Console.WriteLine("");
        Console.WriteLine("Race: ");
        string race = Console.ReadLine() ?? ("unset-Race");

        Console.WriteLine("");
        Console.WriteLine("subRace: ");
        string subRace = Console.ReadLine() ?? ("unset-SubRace");

        Console.WriteLine("");
        Console.WriteLine("Class: ");
        string charClass = Console.ReadLine() ?? ("unset-Class");

        Console.WriteLine("");
        Console.WriteLine("Wealth: ");
        int wealth = int.Parse(Console.ReadLine() ?? ("unset-Wealth"));

        Console.WriteLine("");
        Console.WriteLine("Level: ");
        int level = int.Parse(Console.ReadLine() ?? ("unset-Level"));
        Console.WriteLine("");

        return new Character(playerName, name, race, subRace, charClass, healthBar, wealth, level);
    }

    void createCharacters()
    {
        for (int i = 0; i < dnd.getPlayerAmount(); i++) //picking character attributes
        {
            Character[] players = dnd.getPlayers();
            players[i] = CharacterSelectAttributes();
        }
    }

    void DisplaySheet()
    {

        Console.WriteLine("//===========THIS IS MY SHEET===========//");
        Console.WriteLine("");
        Character[] a = dnd.getPlayers();
        for (int i = 0; i < dnd.getPlayerAmount(); i++)
        {
            Console.WriteLine("//===========Character" + " " + (i + 1) + "===========//");
            Console.WriteLine(a[i].getPlayerName() + "'s Name is " + a[i].getName());
            Console.WriteLine(a[i].getPlayerName() + "'s Health is " + a[i].getHealthBar());
            Console.WriteLine(a[i].getPlayerName() + "'s Race is " + a[i].getRace());
            Console.WriteLine(a[i].getPlayerName() + "'s Sub-Race is " + a[i].getSubRace());
            Console.WriteLine(a[i].getPlayerName() + "'s Heritage is " + a[i].getRaceDesc());
            Console.WriteLine(a[i].getPlayerName() + "'s Class is " + a[i].getCharClass());
            Console.WriteLine(a[i].getPlayerName() + "'s Coin-Worth is " + a[i].getWealth());
            Console.WriteLine(a[i].getPlayerName() + "'s Experience in this Realm is " + a[i].getLevel());
        }
        Console.WriteLine("//===========END OF SHEET===========//");

    }

    void DisplayMenu()
    {

        int selection = 0;

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

        Console.Write("4) Show Character Sheet      ");

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.Write("Here: ");

        try
        {
            selection = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine($"Try again {e.Message}");

            DisplayMenu();
        }

        MenuSelector(selection);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Press any key to move on");

        Console.ReadKey();

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
            case 4:
                DisplaySheet();
                break;

            default:
                Console.WriteLine("Choose from options Please");
                break;

        }
    }

    public void MonsterGen()
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

        Console.WriteLine(diffSelect);

        Monster currMon = dnd.MonsterTraits(diffSelect);

        Console.WriteLine("Name : " + currMon.getName());

        Console.WriteLine("Health : " + currMon.getHealth());

        Console.WriteLine("Size : " + currMon.getSize());

        Console.WriteLine("Type : " + currMon.getType());

        Console.WriteLine("Alignment : " + currMon.getAlignment());

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

        int RealSelection = 2 * selection + 2;
        Console.WriteLine("You Chose the D" + RealSelection + " Dice.");
        Console.WriteLine("The Dice Shows: " + dnd.rand.Next(1, RealSelection));

    }

    void WhoinParty()
    {

        for (int i = 0; i < dnd.getPlayerAmount(); i++)
        {

            Console.WriteLine("[" + (i + 1) + "]" + dnd.getPlayers()[i].getName());

        }
    }

}