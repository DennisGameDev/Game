using UnityEngine;

namespace Game.TurnBasedBattle
{
    public class BattleController : MonoBehaviour
    {
        [SerializeField] private Transform challengerPosition;
        [SerializeField] private Transform opponentPosition;
        
        private BattleEntity challenger;
        private BattleEntity opponent;
        
        public void InitializeBattle(BattleEntity challengerEntity, BattleEntity opponentEntity)
        {
            challenger = challengerEntity;
            opponent = Instantiate(opponentEntity, transform, true);
            
            challenger.enabled = true;
            opponent.enabled = true;
            
            opponent.MoveToBattlePosition(challengerPosition.position);
            challenger.MoveToBattlePosition(opponentPosition.position);
        }

        public void StopBattle()
        {
            challenger.enabled = false;
            opponent.enabled = false;
        }
    }
}
