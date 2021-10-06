using UnityEngine;

namespace Game.TurnBasedBattle.Encounter
{ 
    public class BattleEncounterZone : MonoBehaviour
    {
        [SerializeField] private BattleEntity opponent;
        [SerializeField] private BattleEventChannel battleEventChannel;
        private void OnTriggerEnter(Collider other)
        {
            BattleEntity battleEntity = other.GetComponent<BattleEntity>();

            if (battleEntity != null)
            {
                battleEventChannel.RaiseOnBattleEncountered(new BattleEncounterData(battleEntity, opponent, transform.position));
            }
        }
    }
}
