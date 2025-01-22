using System;
using UnityEditor;

public class Stats
{
    public float health;
    public float maxHealth;
    public float debility;
    public float maxDebility;
   
    public float attack;
    public float defense;
    public float mana;
    public float maxMana;
    


    public Stats(float health, float maxHealth,float debility,float maxDebility, float attack, float defense,float mana,float maxMana)
    {
        this.health = health;
        this.maxHealth = maxHealth;
        this.debility = debility;
        this.maxDebility = maxDebility;
        this.attack = attack;
        this.defense = defense;
        this.mana = mana;
        this.maxMana = maxMana; 
        
    }

    public Stats Clone()
    {
        return new Stats( this.health, this.maxHealth, this.debility,this.maxDebility,this.attack,this.defense,this.mana,this.maxMana);
    }
}

