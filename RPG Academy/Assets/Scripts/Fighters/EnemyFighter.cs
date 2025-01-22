using System.Collections;
using UnityEngine;
namespace Fighters
{
    public class EnemyFighter: Fighter
    {
        private void Awake()
        {
            this.stats = new Stats(60, 60, 50,50,30,10,1,1);
        }
        public override void InitTurn()
        {
            StartCoroutine(IA());
        }

        IEnumerator IA()
        {
            yield return new WaitForSeconds(1f);

            Skill skill = skills[Random.Range(0, skills.Length)];
                
            skill.SetEmitterAndReceiver(
                this, this.CombatManager.GetOpposingFighter()
            );
            this.CombatManager.OnFighterSkill(skill);
        }
    }
}