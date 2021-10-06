using System;
using Game.Character.Movement.Managers;
using UnityEngine;

namespace Game.TurnBasedBattle
{
    public class BattleMovementManager : DefaultMovementManager
    {
        private Vector3 targetDestination;
        private void Update()
        {
            moveEntity.MoveTo(targetDestination, 3);
            rotateEntity.RotateTowardsDirection(moveEntity.CurrentMovementDirection);
            UpdateAnimations();
        }

        public void SetBattleTargetPosition(Vector3 destination)
        {
            targetDestination = destination;
        }
    }
}
