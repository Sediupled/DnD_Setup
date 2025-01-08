using System;

public class Monster
{
    private String name;
    private int health;
    private string size;
    private string type;
    private string alignment;

    public Monster(string name, int health, string size, string type, string alignment) {
        this.name = name;
        this.health = health;
        this.size = size;
        this.type = type;
        this.alignment = alignment;
    }

    public string getName() => this.name;
    public int getHealth() => this.health;
    public string getSize() => this.size;
    public string getType() => this.type;
    public string getAlignment() => this.alignment;


}
