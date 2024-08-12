public class Character
{
    public string? Name {get; set;}   
    public string? Race {get; set;}
    public string? subRace {get; set;}
    public string? RaceDesc {get; set;}
    public string? CharClass {get; set;}

    public int HealthBar;
    public int Wealth;
    public int Level;

    public bool isPlayer()
    {
        return true;
    }



}