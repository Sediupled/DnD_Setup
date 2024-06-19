using System;

namespace VS_CODE
{
    public class CharacterOps
    {

        public void isAlive(Character h)
        {
            if (h.HealthBar == 0)
            {
                Console.WriteLine(h.Name + " is dead.");
            }
            else
            {
                Console.WriteLine(h.Name + " is alive on " + h.HealthBar + " hp.");
            }
        }


        public bool CheckChosen(Character h)
        {
            if ((h.Name == null) || (h.Race == null) || (h.CharClass == null))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void CharacterSelectAtributes(Character a)
        {

            Console.WriteLine("Select your traits:-");
            try
            {
                Console.WriteLine("Name: ");
                a.Name = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("HealthBar: ");
                a.HealthBar = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine("Race: ");
                a.Race = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("subRace: ");
                a.subRace = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Race Description: ");
                a.RaceDesc = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Class: ");
                a.CharClass = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Wealth: ");
                a.Wealth = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine("Level: ");
                a.Level = int.Parse(Console.ReadLine());
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                CharacterSelectAtributes(a);
            }


        }

        public void DisplayAttributes(Character[] a, string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine("//===========Character" + " " + (i+1) + "===========//");
                Console.WriteLine(names[i]+ "'s Name is " + a[i].Name);
                Console.WriteLine(names[i]+ "'s Health is " + a[i].HealthBar);
                Console.WriteLine(names[i]+ "'s Race is " + a[i].Race);
                Console.WriteLine(names[i]+ "'s Sub-Race is " + a[i].subRace);
                Console.WriteLine(names[i]+ "'s Heritage is " + a[i].RaceDesc);
                Console.WriteLine(names[i]+ "'s Class is " + a[i].CharClass);
                Console.WriteLine(names[i]+ "'s Coin-Worth is " + a[i].Wealth);
                Console.WriteLine(names[i]+ "'s Experience in this Realm is " + a[i].Level);
            }
        }


    }
}

