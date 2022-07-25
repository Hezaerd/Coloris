// GENERATED AUTOMATICALLY FROM 'Assets/Data/Input/Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controller : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""PlayerController"",
            ""id"": ""230a2442-ff8c-4555-9e92-60c58393a888"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""917c75eb-3f74-4212-9b05-1c408db06866"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8ec25e10-12b7-4004-9ff4-f4c27e07557b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JumpUp"",
                    ""type"": ""Button"",
                    ""id"": ""3c0e5d7c-028a-4718-8def-1336d34b4b09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""3ab7fc08-fec3-44d1-932f-66f57f477d92"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""99b1b3b8-1d4f-4047-a47e-698f27138b20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Color Blue Switch"",
                    ""type"": ""Button"",
                    ""id"": ""561c7898-72f8-4547-a2ff-596528af995e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Color Red Switch"",
                    ""type"": ""Button"",
                    ""id"": ""f65ba358-24b2-4dc2-91a7-277ae7735163"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""f92aa885-6173-4a63-9afa-03b1073f53ac"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""694a1e2c-2df0-46d1-b40c-e86bd662e7db"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""be7f1394-04a5-4817-aed0-e3896aa3f891"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2e311cf2-3866-41bc-a1e3-444eb112d271"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a70a3925-0cfd-42b6-8657-ef4567e8f884"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""70ea8181-83bf-4a1c-b33a-901a484db5d6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b917d75a-748d-4067-b110-378a89654791"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4c818db9-962c-4dad-9439-4812b16633ea"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4250fa20-59af-4030-8209-bdddb58c6aba"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""70d9b2f0-2e3d-43ec-b2cb-4a31c95808a0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""57ee5e54-7abf-4105-b42a-b2af95a96638"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""244fd4e8-f79f-4f89-9cca-fd49c7976487"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c02986ed-fe2a-4a0a-8736-5a6e64b75018"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""836622db-f7bc-4641-98c3-839dd5ce9d63"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b17801de-29d8-4f4d-8aeb-ca0bd1018af2"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a9e9076-b315-47ec-95a5-6c2a43c1023a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b6e588f-5cdd-4556-b10d-f1a6a662d707"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""JumpUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7d466da-210c-4e7e-8438-84493655d769"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""JumpUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""847089bc-3869-4327-ace9-8a012a4db440"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Color Blue Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98e370f1-f554-4a07-9044-49a4d3160c0c"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Color Blue Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8409796f-29fc-43be-9e60-cb85c4fb5014"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Color Red Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""490e4e22-b961-42b6-a0e5-6067766e3821"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Color Red Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerController
        m_PlayerController = asset.FindActionMap("PlayerController", throwIfNotFound: true);
        m_PlayerController_Movement = m_PlayerController.FindAction("Movement", throwIfNotFound: true);
        m_PlayerController_Jump = m_PlayerController.FindAction("Jump", throwIfNotFound: true);
        m_PlayerController_JumpUp = m_PlayerController.FindAction("JumpUp", throwIfNotFound: true);
        m_PlayerController_Interact = m_PlayerController.FindAction("Interact", throwIfNotFound: true);
        m_PlayerController_Dash = m_PlayerController.FindAction("Dash", throwIfNotFound: true);
        m_PlayerController_ColorBlueSwitch = m_PlayerController.FindAction("Color Blue Switch", throwIfNotFound: true);
        m_PlayerController_ColorRedSwitch = m_PlayerController.FindAction("Color Red Switch", throwIfNotFound: true);
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

    // PlayerController
    private readonly InputActionMap m_PlayerController;
    private IPlayerControllerActions m_PlayerControllerActionsCallbackInterface;
    private readonly InputAction m_PlayerController_Movement;
    private readonly InputAction m_PlayerController_Jump;
    private readonly InputAction m_PlayerController_JumpUp;
    private readonly InputAction m_PlayerController_Interact;
    private readonly InputAction m_PlayerController_Dash;
    private readonly InputAction m_PlayerController_ColorBlueSwitch;
    private readonly InputAction m_PlayerController_ColorRedSwitch;
    public struct PlayerControllerActions
    {
        private @Controller m_Wrapper;
        public PlayerControllerActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerController_Movement;
        public InputAction @Jump => m_Wrapper.m_PlayerController_Jump;
        public InputAction @JumpUp => m_Wrapper.m_PlayerController_JumpUp;
        public InputAction @Interact => m_Wrapper.m_PlayerController_Interact;
        public InputAction @Dash => m_Wrapper.m_PlayerController_Dash;
        public InputAction @ColorBlueSwitch => m_Wrapper.m_PlayerController_ColorBlueSwitch;
        public InputAction @ColorRedSwitch => m_Wrapper.m_PlayerController_ColorRedSwitch;
        public InputActionMap Get() { return m_Wrapper.m_PlayerController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControllerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControllerActions instance)
        {
            if (m_Wrapper.m_PlayerControllerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnJump;
                @JumpUp.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnJumpUp;
                @JumpUp.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnJumpUp;
                @JumpUp.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnJumpUp;
                @Interact.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnInteract;
                @Dash.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnDash;
                @ColorBlueSwitch.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnColorBlueSwitch;
                @ColorBlueSwitch.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnColorBlueSwitch;
                @ColorBlueSwitch.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnColorBlueSwitch;
                @ColorRedSwitch.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnColorRedSwitch;
                @ColorRedSwitch.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnColorRedSwitch;
                @ColorRedSwitch.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnColorRedSwitch;
            }
            m_Wrapper.m_PlayerControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @JumpUp.started += instance.OnJumpUp;
                @JumpUp.performed += instance.OnJumpUp;
                @JumpUp.canceled += instance.OnJumpUp;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @ColorBlueSwitch.started += instance.OnColorBlueSwitch;
                @ColorBlueSwitch.performed += instance.OnColorBlueSwitch;
                @ColorBlueSwitch.canceled += instance.OnColorBlueSwitch;
                @ColorRedSwitch.started += instance.OnColorRedSwitch;
                @ColorRedSwitch.performed += instance.OnColorRedSwitch;
                @ColorRedSwitch.canceled += instance.OnColorRedSwitch;
            }
        }
    }
    public PlayerControllerActions @PlayerController => new PlayerControllerActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    public interface IPlayerControllerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnJumpUp(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnColorBlueSwitch(InputAction.CallbackContext context);
        void OnColorRedSwitch(InputAction.CallbackContext context);
    }
}
