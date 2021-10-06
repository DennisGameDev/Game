using UnityEngine;

namespace Game.TurnBasedBattle.Encounter
{
    public class BattleEncounterData
    {
        public BattleEntity Challenger;
        public BattleEntity Opponent;
        public Vector3 EncounterPosition;
        
        public BattleEncounterData(BattleEntity challenger, BattleEntity opponent, Vector3 encounterPosition)
        {
            Challenger = challenger;
            Opponent = opponent;
            EncounterPosition = encounterPosition;
        }
    }
}
