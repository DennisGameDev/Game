using Game.Character.Movement.Entities;
using Game.Character.Movement.Enums;
using Game.InputSystem;
using UnityEngine;

namespace Game.Character.Movement.Managers
{ 
    [RequireComponent(typeof(GameInputSystem))]
    public class InputDefaultMovementManager : DefaultMovementManager
    {
        [Header("Input settings")]
        [SerializeField] private GameInputSystem inputSystem;
        
        public void Update()
        {
            UpdateAnimations();
            
            moveEntity.Move(inputSystem.CharacterInput.Movement,
                GetMovementSpeedByInput());
            rotateEntity.RotateTowardsDirection(moveEntity.CurrentMovementDirection);
        }

        private float GetMovementSpeedByInput()
        {
            return inputSystem.CharacterInput.MovementBoost ? boostSpeed : defaultSpeed;
        }
    }
}
