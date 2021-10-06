// GENERATED AUTOMATICALLY FROM 'Assets/Game/InputSystem/ActionMap/PlayerActionMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace InputSystem
{
    public class @PlayerActionMap : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerActionMap()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActionMap"",
    ""maps"": [
        {
            ""name"": ""CharacterController"",
            ""id"": ""42fb4868-2ab5-444e-90fc-b226224a3a0b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""62f965fe-b355-4908-8a7c-e95eb1c2aa3a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""54595c4c-09d4-4816-a6a1-218a1a32d04c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ff7a1ed4-736d-4432-8920-164da2da054a"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""522acc2d-f6a3-46b6-89ca-f8cd25f54fd4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7c39353f-80bc-445d-a1ed-b1631f5582df"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""744c4f9c-99e4-4c86-a180-ba1ca36fcc5e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""feb03d15-c4f0-4ab8-a2a3-03abb14126b3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9181a2e7-c9b1-4e45-a82e-154a6407c140"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
            // CharacterController
            m_CharacterController = asset.FindActionMap("CharacterController", throwIfNotFound: true);
            m_CharacterController_Movement = m_CharacterController.FindAction("Movement", throwIfNotFound: true);
            m_CharacterController_Sprint = m_CharacterController.FindAction("Sprint", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // CharacterController
        private readonly InputActionMap m_CharacterController;
        private ICharacterControllerActions m_CharacterControllerActionsCallbackInterface;
        private readonly InputAction m_CharacterController_Movement;
        private readonly InputAction m_CharacterController_Sprint;
        public struct CharacterControllerActions
        {
            private @PlayerActionMap m_Wrapper;
            public CharacterControllerActions(@PlayerActionMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_CharacterController_Movement;
            public InputAction @Sprint => m_Wrapper.m_CharacterController_Sprint;
            public InputActionMap Get() { return m_Wrapper.m_CharacterController; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharacterControllerActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterControllerActions instance)
            {
                if (m_Wrapper.m_CharacterControllerActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnMovement;
                    @Sprint.started -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnSprint;
                    @Sprint.performed -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnSprint;
                    @Sprint.canceled -= m_Wrapper.m_CharacterControllerActionsCallbackInterface.OnSprint;
                }
                m_Wrapper.m_CharacterControllerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Sprint.started += instance.OnSprint;
                    @Sprint.performed += instance.OnSprint;
                    @Sprint.canceled += instance.OnSprint;
                }
            }
        }
        public CharacterControllerActions @CharacterController => new CharacterControllerActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface ICharacterControllerActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
        }
    }
}
