public class Character
{
    private string playerName;
    private string name;
    private string race;
    private string subRace;
    private string raceDesc;
    private string charClass;

    private int healthBar;
    private int wealth;
    private int level;

    public Character(string playerName, string name, string race, 
    string subRace, string charClass,int healthBar,int wealth,int level)
    {
        this.playerName = playerName;
        this.name = name;
        this.race = race;
        this.subRace = subRace;
        this.charClass = charClass;
        this.raceDesc = setDesc(race);
        this.healthBar = healthBar;
        this.wealth = wealth;
        this.level = level;
    }

    string setDesc(string race)
    {
        //TODO
        return "";
    }

    public bool isAlive()
    {
        return this.healthBar != 0;
    }

    //getters
    
    public string getPlayerName() => this.playerName;
    public string getName() => this.name;
    public string getRace() => this.race;
    public string getSubRace() => this.subRace;
    public string getRaceDesc() => this.raceDesc;
    public string getCharClass() => this.charClass;
    public int getHealthBar() => this.healthBar;
    public int getWealth() => this.wealth;
    public int getLevel() => this.level;


}