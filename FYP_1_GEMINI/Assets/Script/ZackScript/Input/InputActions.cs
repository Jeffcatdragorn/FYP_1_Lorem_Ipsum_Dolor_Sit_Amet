//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Script/ZackScript/Input/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""HumanoidLand"",
            ""id"": ""dfa4449d-e8b0-4949-97db-db89aa2f9a2d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""71d2f5d6-b1da-4dce-8c7e-8c70fc5fab69"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""089841c5-a12d-4e20-8212-01e1497ead29"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ChangeCamera"",
                    ""type"": ""Button"",
                    ""id"": ""49bba93a-b27b-4ddc-8da5-820101ab62a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ZoomCamera"",
                    ""type"": ""Value"",
                    ""id"": ""7ad0834a-ba74-4227-9226-4b9f44d77182"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Value"",
                    ""id"": ""f08debbd-5075-4187-a172-eec93663994d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""e7ed38c4-645d-44b5-a66f-04e897838613"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shield"",
                    ""type"": ""Button"",
                    ""id"": ""5e339728-cce3-4553-85bc-beed6187d4db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""d6032791-49f1-460f-96a9-4ae2a18639ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""0a3d0962-828d-4f2c-afb5-765c6fb93cf5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenDoor"",
                    ""type"": ""Button"",
                    ""id"": ""61d48eee-5886-469a-a17a-20627ac2763b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Teleport"",
                    ""type"": ""Button"",
                    ""id"": ""c81236a5-a0a8-4d40-bdd8-4f58b7eebcf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PickUpObject"",
                    ""type"": ""Button"",
                    ""id"": ""461cf661-4715-4765-8ddd-7d78a83134a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""9172d801-03a8-4541-981e-01cfb108bcc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GunReload"",
                    ""type"": ""Button"",
                    ""id"": ""e130ed35-fe48-4acf-88a8-3e7a1f757df4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""148efeb7-5e18-4ce9-80da-c7947e4b740b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""5928c221-c13d-4659-90dd-7f54f9c27767"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""29a2d01e-e9bf-4ab9-8af0-2afef7dc0d79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c8a0fe9f-b856-436d-8e39-ac3eea79e286"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""79b5df4d-5782-40ae-aa7e-5a978fa63bcd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c200cbec-ebdd-46a5-b324-ee1bdeb8873a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""29e3769d-32cd-4f8e-b00b-8470ac572908"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""da172eb0-f7d8-4ddf-8636-83497259be7d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d757f64e-1b7c-452c-b68a-e9d21ea3c57e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""10eba502-f7c6-426b-87ca-acf21edf2604"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c427a2f6-bfe0-4529-92ff-e3fb8b94369e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.03,y=0.03)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bd1b217-d622-41d0-a0b9-1f8d922c41f6"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""855dc17a-8f7b-486f-b4ba-d91704160d4a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e62c4fc-f205-42c2-9a96-d0bc52228654"",
                    ""path"": ""<Gamepad>/dpad/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZoomCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81b5392c-c111-494a-aa9b-f4e434309c98"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-4,max=4)"",
                    ""groups"": """",
                    ""action"": ""ZoomCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""692810f6-25a5-45aa-acbd-3b2919b197cd"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d185cfb-647b-426a-84dd-ab07cec867cf"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""616cd50e-7300-47ce-ba78-28294a7d7553"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""543dcf24-527e-4ff0-848d-0ec7afac113c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34bf5f3d-b3e9-433f-9e69-6f624c6b60ec"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f58cbef6-3f69-4ce4-b10c-12038844499d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""956706ca-a931-45b1-b69f-faebc17dd9cd"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12000143-5a42-4ed6-8fca-eb886442c855"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""095b0a11-9b97-4733-b89d-d5ce55aab60f"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8b38c4a-5a2f-4e7a-b897-9b0281154575"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenDoor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56d974a8-6f4b-430a-8952-e5344de6f1fc"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Teleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d0b57ea-2ec4-4891-9939-9f55e133c271"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Teleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31bf602d-a3dd-427c-b49d-3926f28445a6"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUpObject"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b44e27d2-887c-4788-bae4-320939ce4505"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ecb5864-a55a-4de9-95f7-7796b111add4"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GunReload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1aef1a8-d36c-4c5f-94b4-13c17c1bdfc2"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GunReload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1aa855d1-cb98-40cb-a486-b8983d407187"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3594999-508f-46a3-98d6-487ecdb2afa0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7460f3d-92a4-4c46-abad-43c698ca0de3"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // HumanoidLand
        m_HumanoidLand = asset.FindActionMap("HumanoidLand", throwIfNotFound: true);
        m_HumanoidLand_Move = m_HumanoidLand.FindAction("Move", throwIfNotFound: true);
        m_HumanoidLand_Look = m_HumanoidLand.FindAction("Look", throwIfNotFound: true);
        m_HumanoidLand_ChangeCamera = m_HumanoidLand.FindAction("ChangeCamera", throwIfNotFound: true);
        m_HumanoidLand_ZoomCamera = m_HumanoidLand.FindAction("ZoomCamera", throwIfNotFound: true);
        m_HumanoidLand_Run = m_HumanoidLand.FindAction("Run", throwIfNotFound: true);
        m_HumanoidLand_Jump = m_HumanoidLand.FindAction("Jump", throwIfNotFound: true);
        m_HumanoidLand_Shield = m_HumanoidLand.FindAction("Shield", throwIfNotFound: true);
        m_HumanoidLand_Shoot = m_HumanoidLand.FindAction("Shoot", throwIfNotFound: true);
        m_HumanoidLand_Dash = m_HumanoidLand.FindAction("Dash", throwIfNotFound: true);
        m_HumanoidLand_OpenDoor = m_HumanoidLand.FindAction("OpenDoor", throwIfNotFound: true);
        m_HumanoidLand_Teleport = m_HumanoidLand.FindAction("Teleport", throwIfNotFound: true);
        m_HumanoidLand_PickUpObject = m_HumanoidLand.FindAction("PickUpObject", throwIfNotFound: true);
        m_HumanoidLand_PauseGame = m_HumanoidLand.FindAction("PauseGame", throwIfNotFound: true);
        m_HumanoidLand_GunReload = m_HumanoidLand.FindAction("GunReload", throwIfNotFound: true);
        m_HumanoidLand_Interact = m_HumanoidLand.FindAction("Interact", throwIfNotFound: true);
        m_HumanoidLand_MousePosition = m_HumanoidLand.FindAction("MousePosition", throwIfNotFound: true);
        m_HumanoidLand_Crouch = m_HumanoidLand.FindAction("Crouch", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // HumanoidLand
    private readonly InputActionMap m_HumanoidLand;
    private IHumanoidLandActions m_HumanoidLandActionsCallbackInterface;
    private readonly InputAction m_HumanoidLand_Move;
    private readonly InputAction m_HumanoidLand_Look;
    private readonly InputAction m_HumanoidLand_ChangeCamera;
    private readonly InputAction m_HumanoidLand_ZoomCamera;
    private readonly InputAction m_HumanoidLand_Run;
    private readonly InputAction m_HumanoidLand_Jump;
    private readonly InputAction m_HumanoidLand_Shield;
    private readonly InputAction m_HumanoidLand_Shoot;
    private readonly InputAction m_HumanoidLand_Dash;
    private readonly InputAction m_HumanoidLand_OpenDoor;
    private readonly InputAction m_HumanoidLand_Teleport;
    private readonly InputAction m_HumanoidLand_PickUpObject;
    private readonly InputAction m_HumanoidLand_PauseGame;
    private readonly InputAction m_HumanoidLand_GunReload;
    private readonly InputAction m_HumanoidLand_Interact;
    private readonly InputAction m_HumanoidLand_MousePosition;
    private readonly InputAction m_HumanoidLand_Crouch;
    public struct HumanoidLandActions
    {
        private @InputActions m_Wrapper;
        public HumanoidLandActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_HumanoidLand_Move;
        public InputAction @Look => m_Wrapper.m_HumanoidLand_Look;
        public InputAction @ChangeCamera => m_Wrapper.m_HumanoidLand_ChangeCamera;
        public InputAction @ZoomCamera => m_Wrapper.m_HumanoidLand_ZoomCamera;
        public InputAction @Run => m_Wrapper.m_HumanoidLand_Run;
        public InputAction @Jump => m_Wrapper.m_HumanoidLand_Jump;
        public InputAction @Shield => m_Wrapper.m_HumanoidLand_Shield;
        public InputAction @Shoot => m_Wrapper.m_HumanoidLand_Shoot;
        public InputAction @Dash => m_Wrapper.m_HumanoidLand_Dash;
        public InputAction @OpenDoor => m_Wrapper.m_HumanoidLand_OpenDoor;
        public InputAction @Teleport => m_Wrapper.m_HumanoidLand_Teleport;
        public InputAction @PickUpObject => m_Wrapper.m_HumanoidLand_PickUpObject;
        public InputAction @PauseGame => m_Wrapper.m_HumanoidLand_PauseGame;
        public InputAction @GunReload => m_Wrapper.m_HumanoidLand_GunReload;
        public InputAction @Interact => m_Wrapper.m_HumanoidLand_Interact;
        public InputAction @MousePosition => m_Wrapper.m_HumanoidLand_MousePosition;
        public InputAction @Crouch => m_Wrapper.m_HumanoidLand_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_HumanoidLand; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HumanoidLandActions set) { return set.Get(); }
        public void SetCallbacks(IHumanoidLandActions instance)
        {
            if (m_Wrapper.m_HumanoidLandActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnLook;
                @ChangeCamera.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnChangeCamera;
                @ChangeCamera.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnChangeCamera;
                @ChangeCamera.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnChangeCamera;
                @ZoomCamera.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnZoomCamera;
                @ZoomCamera.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnZoomCamera;
                @ZoomCamera.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnZoomCamera;
                @Run.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnRun;
                @Jump.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnJump;
                @Shield.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnShield;
                @Shield.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnShield;
                @Shield.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnShield;
                @Shoot.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnShoot;
                @Dash.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnDash;
                @OpenDoor.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnOpenDoor;
                @OpenDoor.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnOpenDoor;
                @OpenDoor.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnOpenDoor;
                @Teleport.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnTeleport;
                @Teleport.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnTeleport;
                @Teleport.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnTeleport;
                @PickUpObject.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnPickUpObject;
                @PickUpObject.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnPickUpObject;
                @PickUpObject.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnPickUpObject;
                @PauseGame.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnPauseGame;
                @GunReload.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnGunReload;
                @GunReload.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnGunReload;
                @GunReload.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnGunReload;
                @Interact.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnInteract;
                @MousePosition.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnMousePosition;
                @Crouch.started -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_HumanoidLandActionsCallbackInterface.OnCrouch;
            }
            m_Wrapper.m_HumanoidLandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @ChangeCamera.started += instance.OnChangeCamera;
                @ChangeCamera.performed += instance.OnChangeCamera;
                @ChangeCamera.canceled += instance.OnChangeCamera;
                @ZoomCamera.started += instance.OnZoomCamera;
                @ZoomCamera.performed += instance.OnZoomCamera;
                @ZoomCamera.canceled += instance.OnZoomCamera;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Shield.started += instance.OnShield;
                @Shield.performed += instance.OnShield;
                @Shield.canceled += instance.OnShield;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @OpenDoor.started += instance.OnOpenDoor;
                @OpenDoor.performed += instance.OnOpenDoor;
                @OpenDoor.canceled += instance.OnOpenDoor;
                @Teleport.started += instance.OnTeleport;
                @Teleport.performed += instance.OnTeleport;
                @Teleport.canceled += instance.OnTeleport;
                @PickUpObject.started += instance.OnPickUpObject;
                @PickUpObject.performed += instance.OnPickUpObject;
                @PickUpObject.canceled += instance.OnPickUpObject;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
                @GunReload.started += instance.OnGunReload;
                @GunReload.performed += instance.OnGunReload;
                @GunReload.canceled += instance.OnGunReload;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
            }
        }
    }
    public HumanoidLandActions @HumanoidLand => new HumanoidLandActions(this);
    public interface IHumanoidLandActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnChangeCamera(InputAction.CallbackContext context);
        void OnZoomCamera(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnOpenDoor(InputAction.CallbackContext context);
        void OnTeleport(InputAction.CallbackContext context);
        void OnPickUpObject(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
        void OnGunReload(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
}
