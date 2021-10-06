using System;
using Game.TurnBasedBattle.Encounter;
using UnityEngine;

namespace Game.TurnBasedBattle
{
    [CreateAssetMenu(menuName = "Events/Battle Event", fileName = "BattleEventChannel")]
    public class BattleEventChannel : ScriptableObject
    {
        public event Action<BattleEncounterData> OnBattleEncountered;

        public void RaiseOnBattleEncountered(BattleEncounterData battleEncounterData)
        {
            OnBattleEncountered?.Invoke(battleEncounterData);
        }
    }
}
