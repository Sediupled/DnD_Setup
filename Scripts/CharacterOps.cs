using System;

namespace VS_CODE
{
    public class CharacterOps
    {

        public bool isAlive(Character h)
        {
            if (h.HealthBar == 0)
            {
                return false;
            }
            else
            {
                return true;
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

        public void CharacterSelectAttributes(Character a)
        {

            Console.WriteLine("Select your traits:-");
            try
            {
                Console.WriteLine("Name: ");
                a.Name = Console.ReadLine() ??("unset-Name");
                Console.WriteLine("");
                Console.WriteLine("HealthBar: ");
                a.HealthBar = int.Parse(Console.ReadLine()??("unset-Health"));
                Console.WriteLine("");
                Console.WriteLine("Race: ");
                a.Race = Console.ReadLine()??("unset-Race");
                Console.WriteLine("");
                Console.WriteLine("subRace: ");
                a.subRace = Console.ReadLine()??("unset-SubRace");
                Console.WriteLine("");
                Console.WriteLine("Race Description: ");
                a.RaceDesc = Console.ReadLine()??("unset-Race Description");
                Console.WriteLine("");
                Console.WriteLine("Class: ");
                a.CharClass = Console.ReadLine()??("unset-Class");
                Console.WriteLine("");
                Console.WriteLine("Wealth: ");
                a.Wealth = int.Parse(Console.ReadLine()??("unset-Wealth"));
                Console.WriteLine("");
                Console.WriteLine("Level: ");
                a.Level = int.Parse(Console.ReadLine()??("unset-Level"));
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                CharacterSelectAttributes(a);
            }

            if(CheckChosen(a) == false)
            {

                Console.WriteLine("Atleast fill in Major Traits!");

                Console.WriteLine("Eg: (Name, Race, Class)");

                CharacterSelectAttributes(a);
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

