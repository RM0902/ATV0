
using System;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public string idName;
    public StatusPanel statusPanel;
    

    public CombatManager CombatManager;

    protected Stats stats;

    protected Skill[] skills;

    public bool isAlive
    {
        get => this.stats.health > 0;
    }
    protected void Start()
    {
        this.statusPanel.SetStats(this.idName,this.stats);
        this.skills = this.GetComponentsInChildren<Skill>();

    }

    public void ModifyHealth(float amount)
    {
        this.stats.health = Mathf.Clamp(this.stats.health+ amount, 0f, this.stats.maxHealth);
        this.statusPanel.SetHealth(this.stats.health, this.stats.maxHealth);
    }
    public void ModifyDebility(float amount)
    {
        this.stats.debility = Mathf.Clamp(this.stats.debility+ amount, 0f, this.stats.maxDebility);
        this.statusPanel.SetDebility(this.stats.debility, this.stats.maxDebility);
    }

    public Stats GetCurrentStats()
    {
        //todo stats modifications
        return this.stats;
    }
    public abstract void InitTurn();
}
