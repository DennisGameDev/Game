using System;
using Game.Character.Movement.Managers;
using Game.Utility;
using UnityEngine;

namespace Game.TurnBasedBattle
{
    [RequireComponent(typeof(BattleMovementManager), typeof(DisableEntity), typeof(EnableEntity))]
    public class BattleEntity : MonoBehaviour
    {
        [SerializeField] private BattleMovementManager battleMovementManager;
        [SerializeField] private DisableEntity toDisableOnEnable;
        [SerializeField] private EnableEntity onDisableEnableList;

        private BattleEntity currentTarget;
        
        private void OnEnable()
        {
            toDisableOnEnable.DisableList();
            battleMovementManager.enabled = true;
        }

        private void OnDisable()
        {
            battleMovementManager.enabled = false;
            onDisableEnableList.EnableList();
        }

        private void Update()
        {
            if (currentTarget != null)
            {
                transform.LookAt(currentTarget.transform);
            }
        }

        public void MoveToBattlePosition(Vector3 battlePosition)
        {
            battleMovementManager.SetBattleTargetPosition(battlePosition);
        }

        public void LookAtTarget(BattleEntity target)
        {
            currentTarget = target;
        }
    }
}
