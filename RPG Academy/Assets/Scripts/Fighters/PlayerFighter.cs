using System;
using UnityEngine;

namespace Fighters
{
    public class PlayerFighter: Fighter
    {
        public string tipo;
        [Header("UI")] 
        public PlayerSkillPanel skillPanel;
        private void Awake()
        {
            this.stats = new Stats(60, 60, 1, 1, 40, 20,50,50);
    }

        public override void InitTurn()
        {
            this.skillPanel.Show();
            for (int i = 0; i < this.skills.Length; i++)
            {
                this.skillPanel.ConfigureButtons(i,skills[i].skillName);
            }
        }

        ///<summary>
        /// se llama desd los botones del panel de habilidades
        /// </summary>
        /// <param name="index"></param>
        public void ExecuteSkill(int index)
        {
            this.skillPanel.Hide( ) ;
            Skill skill = this.skills[index];

            skill.SetEmitterAndReceiver(
                this, this.CombatManager.GetOpposingFighter()
            );
            
// EXECUTE
            this.CombatManager.OnFighterSkill(skill);

        }
            
    }
}
