using System;
using InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.InputSystem
{
    [RequireComponent(typeof(PlayerInput))]
    public class GameInputSystem : MonoBehaviour
    {
        private PlayerInput playerUnityInput;
        private PlayerActionMap playerActionMap;

        private PlayerCharacterInput characterInput;
        public PlayerCharacterInput CharacterInput => characterInput;

        private IInput currentInput;

        private void Awake()
        {
            playerUnityInput = GetComponent<PlayerInput>();
            playerActionMap = new PlayerActionMap();
            playerActionMap.Enable();
            
            characterInput = new PlayerCharacterInput(playerActionMap);
            
            EnableCharacterInput();
        }

        private void EnableCharacterInput()
        {
            currentInput = characterInput;
            playerUnityInput.SwitchCurrentActionMap(currentInput.ActionMapName);
        }

        private void Update()
        {
            currentInput.Update();
        }
    }
}
