using System;
using InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.InputSystem
{
    public class PlayerCharacterInput : IInput
    {
        public string ActionMapName => "CharacterController";

        private PlayerActionMap playerActionMap;

        private float movementBoost; // Fix later
        public bool MovementBoost => Convert.ToBoolean(movementBoost); //Left shift default 

        private Vector2 movement;
        public Vector2 Movement => movement;

        public PlayerCharacterInput(PlayerActionMap actionMap)
        {
            playerActionMap = actionMap;
            
            playerActionMap.CharacterController.Sprint.performed += OnMovementBoost;
            playerActionMap.CharacterController.Sprint.canceled += OnMovementBoost;
        }

        private void OnMovementBoost(InputAction.CallbackContext context)
        {
            movementBoost = context.ReadValue<float>();
        }

        public void Update()
        {
            movement = playerActionMap.CharacterController.Movement.ReadValue<Vector2>();
        }
    }
}
