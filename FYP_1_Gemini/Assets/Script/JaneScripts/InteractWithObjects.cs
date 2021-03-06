//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Script/JaneScripts/InteractWithObjects.inputactions
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

public partial class @InteractWithObjects : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InteractWithObjects()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InteractWithObjects"",
    ""maps"": [
        {
            ""name"": ""InteractWithObject"",
            ""id"": ""9dfb97ca-6c59-45f5-a236-694f7720de15"",
            ""actions"": [
                {
                    ""name"": ""CollectFuse"",
                    ""type"": ""Button"",
                    ""id"": ""e4febf2b-3091-4c4a-92a4-feb0f1877821"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PutFuseIn"",
                    ""type"": ""Button"",
                    ""id"": ""bb28626b-332a-4e2d-8776-20c6d07e2973"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CollectKeycard"",
                    ""type"": ""Button"",
                    ""id"": ""65aaa4a1-9b8c-496e-a083-805036a0004e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PutKeycardIn"",
                    ""type"": ""Button"",
                    ""id"": ""97e86d32-8bc5-4983-832f-a880bbdea365"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PickUpItem"",
                    ""type"": ""Button"",
                    ""id"": ""39ba52b7-8f51-4f2d-923d-766434e5e689"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ScanKeycard"",
                    ""type"": ""Button"",
                    ""id"": ""901fe2a7-d248-4604-8902-67754f8a1ce1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9af1fd3a-66af-4203-918e-af74a8e314ba"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CollectFuse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cecd54b6-11e3-4d7b-985b-81864059d968"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PutFuseIn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e07da81e-2e3d-443f-8023-44c206540c9d"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CollectKeycard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""386220a6-588f-47da-92eb-c357835b8b37"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PutKeycardIn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0025a9d1-20d3-442e-a0cc-487892a8f438"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUpItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""166461cc-58bc-4bfd-9412-9c304d98f2e3"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ScanKeycard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""DetectivePath"",
            ""id"": ""dfb2bfa3-ebbf-45a6-bd06-1e616d829665"",
            ""actions"": [
                {
                    ""name"": ""SpamFToOpen"",
                    ""type"": ""Button"",
                    ""id"": ""caaeb18c-c0f7-4cc8-b74f-ee0b7b61caf5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""effaae95-2a0a-4a5d-ae28-2bbe9bccc3ec"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpamFToOpen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""tester"",
            ""id"": ""3d918653-323a-4de5-9921-82cd7f9e0314"",
            ""actions"": [
                {
                    ""name"": ""testAction"",
                    ""type"": ""Button"",
                    ""id"": ""35596e18-81b3-496f-998d-0adfc3b75ed9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9fccff90-bdc7-40da-91da-226cd993360f"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""testAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Inventory"",
            ""id"": ""fb8921ca-84bf-403d-aadc-4439627d238c"",
            ""actions"": [
                {
                    ""name"": ""InventoryUIMenu"",
                    ""type"": ""Button"",
                    ""id"": ""ddfd2e9d-8554-4086-a347-5d0c1d71b818"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ed9ea3bd-13e9-4eeb-833f-5eefcf3e0e10"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryUIMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InteractWithObject
        m_InteractWithObject = asset.FindActionMap("InteractWithObject", throwIfNotFound: true);
        m_InteractWithObject_CollectFuse = m_InteractWithObject.FindAction("CollectFuse", throwIfNotFound: true);
        m_InteractWithObject_PutFuseIn = m_InteractWithObject.FindAction("PutFuseIn", throwIfNotFound: true);
        m_InteractWithObject_CollectKeycard = m_InteractWithObject.FindAction("CollectKeycard", throwIfNotFound: true);
        m_InteractWithObject_PutKeycardIn = m_InteractWithObject.FindAction("PutKeycardIn", throwIfNotFound: true);
        m_InteractWithObject_PickUpItem = m_InteractWithObject.FindAction("PickUpItem", throwIfNotFound: true);
        m_InteractWithObject_ScanKeycard = m_InteractWithObject.FindAction("ScanKeycard", throwIfNotFound: true);
        // DetectivePath
        m_DetectivePath = asset.FindActionMap("DetectivePath", throwIfNotFound: true);
        m_DetectivePath_SpamFToOpen = m_DetectivePath.FindAction("SpamFToOpen", throwIfNotFound: true);
        // tester
        m_tester = asset.FindActionMap("tester", throwIfNotFound: true);
        m_tester_testAction = m_tester.FindAction("testAction", throwIfNotFound: true);
        // Inventory
        m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
        m_Inventory_InventoryUIMenu = m_Inventory.FindAction("InventoryUIMenu", throwIfNotFound: true);
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

    // InteractWithObject
    private readonly InputActionMap m_InteractWithObject;
    private IInteractWithObjectActions m_InteractWithObjectActionsCallbackInterface;
    private readonly InputAction m_InteractWithObject_CollectFuse;
    private readonly InputAction m_InteractWithObject_PutFuseIn;
    private readonly InputAction m_InteractWithObject_CollectKeycard;
    private readonly InputAction m_InteractWithObject_PutKeycardIn;
    private readonly InputAction m_InteractWithObject_PickUpItem;
    private readonly InputAction m_InteractWithObject_ScanKeycard;
    public struct InteractWithObjectActions
    {
        private @InteractWithObjects m_Wrapper;
        public InteractWithObjectActions(@InteractWithObjects wrapper) { m_Wrapper = wrapper; }
        public InputAction @CollectFuse => m_Wrapper.m_InteractWithObject_CollectFuse;
        public InputAction @PutFuseIn => m_Wrapper.m_InteractWithObject_PutFuseIn;
        public InputAction @CollectKeycard => m_Wrapper.m_InteractWithObject_CollectKeycard;
        public InputAction @PutKeycardIn => m_Wrapper.m_InteractWithObject_PutKeycardIn;
        public InputAction @PickUpItem => m_Wrapper.m_InteractWithObject_PickUpItem;
        public InputAction @ScanKeycard => m_Wrapper.m_InteractWithObject_ScanKeycard;
        public InputActionMap Get() { return m_Wrapper.m_InteractWithObject; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractWithObjectActions set) { return set.Get(); }
        public void SetCallbacks(IInteractWithObjectActions instance)
        {
            if (m_Wrapper.m_InteractWithObjectActionsCallbackInterface != null)
            {
                @CollectFuse.started -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnCollectFuse;
                @CollectFuse.performed -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnCollectFuse;
                @CollectFuse.canceled -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnCollectFuse;
                @PutFuseIn.started -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnPutFuseIn;
                @PutFuseIn.performed -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnPutFuseIn;
                @PutFuseIn.canceled -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnPutFuseIn;
                @CollectKeycard.started -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnCollectKeycard;
                @CollectKeycard.performed -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnCollectKeycard;
                @CollectKeycard.canceled -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnCollectKeycard;
                @PutKeycardIn.started -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnPutKeycardIn;
                @PutKeycardIn.performed -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnPutKeycardIn;
                @PutKeycardIn.canceled -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnPutKeycardIn;
                @PickUpItem.started -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnPickUpItem;
                @PickUpItem.performed -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnPickUpItem;
                @PickUpItem.canceled -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnPickUpItem;
                @ScanKeycard.started -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnScanKeycard;
                @ScanKeycard.performed -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnScanKeycard;
                @ScanKeycard.canceled -= m_Wrapper.m_InteractWithObjectActionsCallbackInterface.OnScanKeycard;
            }
            m_Wrapper.m_InteractWithObjectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CollectFuse.started += instance.OnCollectFuse;
                @CollectFuse.performed += instance.OnCollectFuse;
                @CollectFuse.canceled += instance.OnCollectFuse;
                @PutFuseIn.started += instance.OnPutFuseIn;
                @PutFuseIn.performed += instance.OnPutFuseIn;
                @PutFuseIn.canceled += instance.OnPutFuseIn;
                @CollectKeycard.started += instance.OnCollectKeycard;
                @CollectKeycard.performed += instance.OnCollectKeycard;
                @CollectKeycard.canceled += instance.OnCollectKeycard;
                @PutKeycardIn.started += instance.OnPutKeycardIn;
                @PutKeycardIn.performed += instance.OnPutKeycardIn;
                @PutKeycardIn.canceled += instance.OnPutKeycardIn;
                @PickUpItem.started += instance.OnPickUpItem;
                @PickUpItem.performed += instance.OnPickUpItem;
                @PickUpItem.canceled += instance.OnPickUpItem;
                @ScanKeycard.started += instance.OnScanKeycard;
                @ScanKeycard.performed += instance.OnScanKeycard;
                @ScanKeycard.canceled += instance.OnScanKeycard;
            }
        }
    }
    public InteractWithObjectActions @InteractWithObject => new InteractWithObjectActions(this);

    // DetectivePath
    private readonly InputActionMap m_DetectivePath;
    private IDetectivePathActions m_DetectivePathActionsCallbackInterface;
    private readonly InputAction m_DetectivePath_SpamFToOpen;
    public struct DetectivePathActions
    {
        private @InteractWithObjects m_Wrapper;
        public DetectivePathActions(@InteractWithObjects wrapper) { m_Wrapper = wrapper; }
        public InputAction @SpamFToOpen => m_Wrapper.m_DetectivePath_SpamFToOpen;
        public InputActionMap Get() { return m_Wrapper.m_DetectivePath; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DetectivePathActions set) { return set.Get(); }
        public void SetCallbacks(IDetectivePathActions instance)
        {
            if (m_Wrapper.m_DetectivePathActionsCallbackInterface != null)
            {
                @SpamFToOpen.started -= m_Wrapper.m_DetectivePathActionsCallbackInterface.OnSpamFToOpen;
                @SpamFToOpen.performed -= m_Wrapper.m_DetectivePathActionsCallbackInterface.OnSpamFToOpen;
                @SpamFToOpen.canceled -= m_Wrapper.m_DetectivePathActionsCallbackInterface.OnSpamFToOpen;
            }
            m_Wrapper.m_DetectivePathActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SpamFToOpen.started += instance.OnSpamFToOpen;
                @SpamFToOpen.performed += instance.OnSpamFToOpen;
                @SpamFToOpen.canceled += instance.OnSpamFToOpen;
            }
        }
    }
    public DetectivePathActions @DetectivePath => new DetectivePathActions(this);

    // tester
    private readonly InputActionMap m_tester;
    private ITesterActions m_TesterActionsCallbackInterface;
    private readonly InputAction m_tester_testAction;
    public struct TesterActions
    {
        private @InteractWithObjects m_Wrapper;
        public TesterActions(@InteractWithObjects wrapper) { m_Wrapper = wrapper; }
        public InputAction @testAction => m_Wrapper.m_tester_testAction;
        public InputActionMap Get() { return m_Wrapper.m_tester; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TesterActions set) { return set.Get(); }
        public void SetCallbacks(ITesterActions instance)
        {
            if (m_Wrapper.m_TesterActionsCallbackInterface != null)
            {
                @testAction.started -= m_Wrapper.m_TesterActionsCallbackInterface.OnTestAction;
                @testAction.performed -= m_Wrapper.m_TesterActionsCallbackInterface.OnTestAction;
                @testAction.canceled -= m_Wrapper.m_TesterActionsCallbackInterface.OnTestAction;
            }
            m_Wrapper.m_TesterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @testAction.started += instance.OnTestAction;
                @testAction.performed += instance.OnTestAction;
                @testAction.canceled += instance.OnTestAction;
            }
        }
    }
    public TesterActions @tester => new TesterActions(this);

    // Inventory
    private readonly InputActionMap m_Inventory;
    private IInventoryActions m_InventoryActionsCallbackInterface;
    private readonly InputAction m_Inventory_InventoryUIMenu;
    public struct InventoryActions
    {
        private @InteractWithObjects m_Wrapper;
        public InventoryActions(@InteractWithObjects wrapper) { m_Wrapper = wrapper; }
        public InputAction @InventoryUIMenu => m_Wrapper.m_Inventory_InventoryUIMenu;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void SetCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterface != null)
            {
                @InventoryUIMenu.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventoryUIMenu;
                @InventoryUIMenu.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventoryUIMenu;
                @InventoryUIMenu.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnInventoryUIMenu;
            }
            m_Wrapper.m_InventoryActionsCallbackInterface = instance;
            if (instance != null)
            {
                @InventoryUIMenu.started += instance.OnInventoryUIMenu;
                @InventoryUIMenu.performed += instance.OnInventoryUIMenu;
                @InventoryUIMenu.canceled += instance.OnInventoryUIMenu;
            }
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);
    public interface IInteractWithObjectActions
    {
        void OnCollectFuse(InputAction.CallbackContext context);
        void OnPutFuseIn(InputAction.CallbackContext context);
        void OnCollectKeycard(InputAction.CallbackContext context);
        void OnPutKeycardIn(InputAction.CallbackContext context);
        void OnPickUpItem(InputAction.CallbackContext context);
        void OnScanKeycard(InputAction.CallbackContext context);
    }
    public interface IDetectivePathActions
    {
        void OnSpamFToOpen(InputAction.CallbackContext context);
    }
    public interface ITesterActions
    {
        void OnTestAction(InputAction.CallbackContext context);
    }
    public interface IInventoryActions
    {
        void OnInventoryUIMenu(InputAction.CallbackContext context);
    }
}
