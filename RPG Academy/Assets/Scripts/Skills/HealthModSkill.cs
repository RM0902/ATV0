using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HealthModType
{
  STAT_BASED, FIXED, PERCENTAGE
}
public class HealthModSkill : Skill
{
  [Header("Health Mod")]
  public float amount;

  public HealthModType ModType;

  protected override void OnRun()
  {
    float damage = this.GetModification();
    
    this.receiver.ModifyHealth(amount);
  }

  public float GetModification()
  {
    switch (this.ModType)
    {
      case HealthModType.STAT_BASED:
        Stats emitterStats = this.emitter.GetCurrentStats();
        Stats receiverStats = this.receiver.GetCurrentStats();

        float rawDamage = (((2 * 10) / 5) + 2) * this.amount * (emitterStats.attack / receiverStats.defense);

        return (rawDamage / 50) + 2;
      case HealthModType.FIXED:
        return this.amount;

      case HealthModType.PERCENTAGE:
        Stats rStats = this.receiver.GetCurrentStats();

        return rStats.maxHealth * this.amount;
        
    }

    throw new System.InvalidOperationException("HealtModSkill:GetDamage Unreacheble");
  }

}
