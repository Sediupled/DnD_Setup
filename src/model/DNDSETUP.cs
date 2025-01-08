﻿using System.Runtime.InteropServices;

namespace VS_CODE;

class DNDSETUP
{
    private int playerAmt;
    private Character[] Players;
    public Random rand;
    

    public DNDSETUP(int playerAmt)
    {
        this.playerAmt = playerAmt;
        Players = new Character[this.playerAmt]; // Creates a CharacterArr
        rand = new Random();
    }

    public Monster MonsterTraits(string h)
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


        Monster mon = new Monster(Name,Hp,size,type,alignment);

        return mon;
    }
    
    public void setPlayerAmount(int value) => this.playerAmt = value;
    public int getPlayerAmount() => this.playerAmt;
    public Character[] getPlayers() => this.Players;


}