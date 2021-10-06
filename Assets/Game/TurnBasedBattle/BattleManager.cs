

using System;
using Game.TurnBasedBattle.Encounter;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.TurnBasedBattle
{
    public class BattleManager : MonoBehaviour
    {
        [SerializeField] private BattleEventChannel battleEventChannel;
        [SerializeField] private BattleController battlePrefab;

        private BattleController currentBattle;

        private void Awake()
        {
            battleEventChannel.OnBattleEncountered += HandleOnBattleEncountered;
        }
        
        private void HandleOnBattleEncountered(BattleEncounterData data)
        {
            CreateNewBattle(data);
        }

        private void CreateNewBattle(BattleEncounterData data)
        {
            currentBattle = Instantiate(battlePrefab, data.EncounterPosition, Quaternion.identity);
            currentBattle.InitializeBattle(data.Challenger, data.Opponent);
        }

        private void Update()
        {
            if (Keyboard.current.bKey.IsPressed())
            {
                RemoveBattle();
            }
        }

        private void RemoveBattle()
        {
            if (currentBattle != null)
            {
                currentBattle.StopBattle();
                Destroy(currentBattle.gameObject);
            }
        }
    }
}
