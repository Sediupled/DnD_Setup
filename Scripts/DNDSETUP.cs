using System.Runtime.InteropServices;

namespace VS_CODE;

class DNDSETUP
{

    static string[]? PlayerNames;
    public static int playerAmt;
    public static Character[]? Player;
    Random rand = new Random();


    static void Main(string[] args)
    {
        DNDSETUP dnd = new DNDSETUP(); // Initialise DNDSETUP

        Console.WriteLine("My DND Setup");

        Console.Write("The Weight of your Crew: ");

        int _playerAmt = int.Parse(Console.ReadLine()!); //Get amount of players
        
        playerAmt = _playerAmt;

        dnd.DndManager();
        
        Console.ReadLine();
    }

    public void DndManager()
    {
        GetPlayerNames(); // Creates Characters for other ops

        DisplayMenu(); //Displays the Interactive Menu
    }

    void GetPlayerNames()
    {
        Player = new Character[playerAmt]; // Creates a CharacterArr

        PlayerNames = new string[playerAmt];


        for (int i = 0; i < playerAmt; i++) //picking character attributes
        {
            Console.WriteLine("Name Thyself: ");

            PlayerNames[i] = Console.ReadLine()!;

            Player[i] = new Character();

            CharacterOps charOps = new CharacterOps();

            charOps.CharacterSelectAttributes(Player[i]);

            if(charOps.CheckChosen(Player[i]) == false)
            {
                Console.Write("Your Player isn't from this world,");

                Console.WriteLine("assign all necessary traits");

                charOps.CharacterSelectAttributes(Player[i]);
            }
        }

        DisplaySheet(Player);


    }


    void DisplaySheet(Character[] playing)
    {
        CharacterOps charOps = new CharacterOps();

        for(int i = 0; i<playing.Length; i++)
        {
            if(charOps.isAlive(playing[i]) == false)
            {
                if(i == 0) playing = playing[1..(playerAmt-1)];

                else if(i == playerAmt - 1) playing = playing[0..(playerAmt-2)];

                else 
                {
                    Character[] ini = playing[0..i];

                    Character[] end = playing[(i+1)..(playerAmt - 1)];

                    playing = ini.Concat(end).ToArray();
                }

                playerAmt--;

            }
        }

        Console.WriteLine("//===========THIS IS MY SHEET===========//");

        Console.WriteLine("");

        charOps.DisplayAttributes(playing, PlayerNames!);

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
        catch(Exception e)
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
                DisplaySheet(Player!);
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
            
            int RealSelection = (2 * selection + 2);

            Console.WriteLine("You Chose the D" + RealSelection + " Dice.");

            Console.WriteLine("The Dice Shows: " + rand.Next(1, RealSelection));

        }

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

        Console.WriteLine(diffSelect);

        //===========TEST 1============\\

/*         if(selectionNo == 1 && diffSelect == "Easy")
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Easy Test Passed" );
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if(selectionNo == 2 && diffSelect == "Average")
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Average Test Passed" );
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if(selectionNo == 3 && diffSelect == "Hard")
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Hard Test Passed" );
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine();
        }
 */
        //===========END OF TEST 1============\\

        MonsterTraits(diffSelect);

    }

    void MonsterTraits(string h)
    {

        //Make orcs sexually assault, elf males        
        TextReader tr = new StreamReader(@"D:\DnDScene\MonList.txt");

        string readtr = tr.ReadLine()!;

        string[] NameList = readtr.Split(",");

        string[] sizeList = { "Tiny", "Small", "Medium", "Large", "Huge" };

        string[] typeList = { "Plant", "Humanoid", "Fiend", "Beast", "Dragon", 
        "Elemental", "Monstrosity", "Giant", "Undead", "Fey", "Construct", 
        "Aberration", "Ooze", "Celestial" };

        string[] alignmentList = { "Lawful Good", "Neutral Good", "Chaotic Good"
        , "Lawful Neutral", "True Neutral", "Chaotic Neutral", "Lawful Evil", 
        "Neutral Evil", "Chaotic Evil" };


        var rand = new Random();

        string Name = NameList[rand.Next(NameList.Length)];

        string type = typeList[rand.Next(typeList.Length)];
        
        int Hp;

        string size;

        string alignment = alignmentList[rand.Next(alignmentList.Length)];

        int testVal = 10000;

        if (h == "Easy")
        {

            Hp = rand.Next(0, 30);

            testVal = rand.Next(0, 2);

            size = sizeList[testVal];

        }

        else if (h == "Average")
        {

            Hp = rand.Next(30, 60);

            size = sizeList[rand.Next(2, 4)];

        }

        else
        {

            Hp = rand.Next(60, 100);

            size = sizeList[rand.Next(3, 5)];

        }

        //===========TEST 2============\\

/*         if(h == "Easy" && (size == "Tiny" || size == "Small"))
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Easy Test Passed");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if(h == "Average" && (size == "Medium" || size == "Large"))
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Average Test Passed");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if(h == "Hard" && (size == "Large" || size == "Huge"))
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Hard Test Passed");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            //Console.WriteLine($"{h} test failed as size is {size}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Test Failed");
            Console.WriteLine(testVal);
            Console.WriteLine(sizeList[testVal]);

            Console.ForegroundColor = ConsoleColor.White;
        } */

        //===========END OF TEST 2============\\



        Console.WriteLine("Name : " + Name);

        Console.WriteLine("Health : " + Hp);

        Console.WriteLine("Size : " + size);

        Console.WriteLine("Type : " + type);

        Console.WriteLine("Alignment : " + alignment);

    }


    void WhoinParty()
    {

        for (int i = 0; i < PlayerNames?.Length; i++)
        {

            Console.WriteLine("[" + (i + 1) + "]" + PlayerNames[i]);

        }
    }

}