using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatStatus
{
    WAITING_FOR_FIGHTER,
    FIGHTER_ACTION,
    CHECK_FOR_VICTORY,
    NEXT_TURN
} 

public class CombatManager : MonoBehaviour
{

    public Fighter[] fighters;

    private int fighterIndex;
    private bool isCombatActive;

    private CombatStatus combatStatus;

    private Skill currentFighterSkill; 

    // Start is called before the first frame update
    void Start()
    {
        LogPanel.Write("Batalla Iniciada");
        
        foreach (var fgtr in this.fighters)
        {
            fgtr.CombatManager = this;
        }
        this.combatStatus =CombatStatus.NEXT_TURN;
        
        
        this.fighterIndex = -1;
        this.isCombatActive = true;
        StartCoroutine(this.CombatLoop());

    }

    IEnumerator CombatLoop()
    {
       
            while (this.isCombatActive)
            {
                switch (this.combatStatus)
                {
                    case CombatStatus.WAITING_FOR_FIGHTER:
                        yield return null;
                        break;
                    
                    case CombatStatus.FIGHTER_ACTION:
                        LogPanel.Write($"{this.fighters[this.fighterIndex].idName} Uso {currentFighterSkill.skillName}");
                        
                        yield return null;
                        
                        currentFighterSkill.Run();
                        
                        //esperar por la animacion de la skill
                        yield return new WaitForSeconds(currentFighterSkill.animationDuration);
                        this.combatStatus = CombatStatus.CHECK_FOR_VICTORY;

                        currentFighterSkill = null;
                        break;
                    
                    case CombatStatus.CHECK_FOR_VICTORY:
                        
                        foreach (var fgtr in this.fighters)
                        {
                            if (fgtr.isAlive==false)
                            {
                                this.isCombatActive = false;
                                
                                LogPanel.Write("Victoria");
                                
                            }
                            else
                            {
                                this.combatStatus = CombatStatus.NEXT_TURN;
                            }
                            
                        }

                        yield return null;
                        break;
                    case CombatStatus.NEXT_TURN:
                        yield return new WaitForSeconds(1f);
                        this.fighterIndex = (this.fighterIndex + 1) % this.fighters.Length;
                        
                        var currentTurn = this.fighters[this.fighterIndex];
            
                        
                        LogPanel.Write($"{currentTurn.idName} tiene el turno.");
                        currentTurn.InitTurn();
                        
                       

                        this.combatStatus = CombatStatus.WAITING_FOR_FIGHTER;
                        break;
                }
            }
    }
    public Fighter GetOpposingFighter()
    {
        if (this.fighterIndex==0)
        {
            return this.fighters[1];
                
        }
        else
        {
            return fighters[0];
        }
    }

    public void OnFighterSkill(Skill skill)
    {
        this.currentFighterSkill = skill;
        this.combatStatus = CombatStatus.FIGHTER_ACTION;
    }
}
