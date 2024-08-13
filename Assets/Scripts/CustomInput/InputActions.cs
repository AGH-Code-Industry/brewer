//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/CustomInput/InputActions.inputactions
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

namespace CustomInput
{
    public partial class @InputActions: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Dormitory"",
            ""id"": ""368e0ba7-abfb-4c2c-bddc-680eec8e9b2f"",
            ""actions"": [
                {
                    ""name"": ""PrimaryMouseClicked"",
                    ""type"": ""Button"",
                    ""id"": ""cfd04385-1c78-4edd-be97-749f1e8699b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondaryMouseClicked"",
                    ""type"": ""Button"",
                    ""id"": ""a31b5db6-2ae8-403b-a192-5c3968da62f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""8ea1e9d0-ec07-44f5-a4d5-aa519f6034ae"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e9c2d190-279f-4255-b1f5-1eeae2236320"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryMouseClicked"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""722f9c6a-f027-4f35-ae93-986c3471352e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryMouseClicked"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a54f608-2511-409b-b06e-53ec5cc95eec"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Town"",
            ""id"": ""95432c99-3dad-4182-9472-17810af046ec"",
            ""actions"": [
                {
                    ""name"": ""Navigation"",
                    ""type"": ""Value"",
                    ""id"": ""b8e21bb7-ce3a-433e-a3a4-3287b26417af"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Value"",
                    ""id"": ""810983f6-0eb2-4abc-9a45-bdda84a1b6cf"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""6f40876b-eec1-4e16-b62f-668c59f80069"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""235bd85c-271b-4ba7-8fd5-f84e992bf904"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5423518b-b3d3-42e9-9710-bf8f618b13a1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1e38fefc-4c70-4f4f-b24e-adaf12e49a06"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ae88eda2-4281-4b5d-9fda-6fb543465c16"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cf5e8675-cdf3-42b6-8970-ae12a2a14bad"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c4570c11-3d10-44af-89cc-410e6c46d6a4"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eed3a2a1-3716-441e-a98f-7a7c1b91129f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseMenu"",
            ""id"": ""1ca359c5-7d31-4cc2-88e6-80eab0dabf47"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""7471ece6-7f39-41ff-8ae2-e1cbf2063172"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8786079d-b7e9-4a1a-9547-01ab035252d3"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""AlwaysEnabled"",
            ""id"": ""4096b210-7feb-4563-aeff-3e3307e1e877"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""fcfd6504-c842-40a0-936c-846cb7cfd445"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2da02f31-ade3-4f97-8d84-68d349c234fd"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Testing"",
            ""id"": ""7856266c-9e70-4d38-979a-f3a15f4f1ac0"",
            ""actions"": [
                {
                    ""name"": ""SaveGame"",
                    ""type"": ""Button"",
                    ""id"": ""6bc4cb80-1f00-41d8-b4f6-62a6e2e35591"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0cd9eaa8-cf7d-4e57-8da3-d967945b5b5d"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SaveGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Dormitory
            m_Dormitory = asset.FindActionMap("Dormitory", throwIfNotFound: true);
            m_Dormitory_PrimaryMouseClicked = m_Dormitory.FindAction("PrimaryMouseClicked", throwIfNotFound: true);
            m_Dormitory_SecondaryMouseClicked = m_Dormitory.FindAction("SecondaryMouseClicked", throwIfNotFound: true);
            m_Dormitory_MousePosition = m_Dormitory.FindAction("MousePosition", throwIfNotFound: true);
            // Town
            m_Town = asset.FindActionMap("Town", throwIfNotFound: true);
            m_Town_Navigation = m_Town.FindAction("Navigation", throwIfNotFound: true);
            m_Town_Run = m_Town.FindAction("Run", throwIfNotFound: true);
            m_Town_Select = m_Town.FindAction("Select", throwIfNotFound: true);
            // PauseMenu
            m_PauseMenu = asset.FindActionMap("PauseMenu", throwIfNotFound: true);
            m_PauseMenu_Newaction = m_PauseMenu.FindAction("New action", throwIfNotFound: true);
            // AlwaysEnabled
            m_AlwaysEnabled = asset.FindActionMap("AlwaysEnabled", throwIfNotFound: true);
            m_AlwaysEnabled_Newaction = m_AlwaysEnabled.FindAction("New action", throwIfNotFound: true);
            // Testing
            m_Testing = asset.FindActionMap("Testing", throwIfNotFound: true);
            m_Testing_SaveGame = m_Testing.FindAction("SaveGame", throwIfNotFound: true);
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

        // Dormitory
        private readonly InputActionMap m_Dormitory;
        private List<IDormitoryActions> m_DormitoryActionsCallbackInterfaces = new List<IDormitoryActions>();
        private readonly InputAction m_Dormitory_PrimaryMouseClicked;
        private readonly InputAction m_Dormitory_SecondaryMouseClicked;
        private readonly InputAction m_Dormitory_MousePosition;
        public struct DormitoryActions
        {
            private @InputActions m_Wrapper;
            public DormitoryActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @PrimaryMouseClicked => m_Wrapper.m_Dormitory_PrimaryMouseClicked;
            public InputAction @SecondaryMouseClicked => m_Wrapper.m_Dormitory_SecondaryMouseClicked;
            public InputAction @MousePosition => m_Wrapper.m_Dormitory_MousePosition;
            public InputActionMap Get() { return m_Wrapper.m_Dormitory; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DormitoryActions set) { return set.Get(); }
            public void AddCallbacks(IDormitoryActions instance)
            {
                if (instance == null || m_Wrapper.m_DormitoryActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_DormitoryActionsCallbackInterfaces.Add(instance);
                @PrimaryMouseClicked.started += instance.OnPrimaryMouseClicked;
                @PrimaryMouseClicked.performed += instance.OnPrimaryMouseClicked;
                @PrimaryMouseClicked.canceled += instance.OnPrimaryMouseClicked;
                @SecondaryMouseClicked.started += instance.OnSecondaryMouseClicked;
                @SecondaryMouseClicked.performed += instance.OnSecondaryMouseClicked;
                @SecondaryMouseClicked.canceled += instance.OnSecondaryMouseClicked;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }

            private void UnregisterCallbacks(IDormitoryActions instance)
            {
                @PrimaryMouseClicked.started -= instance.OnPrimaryMouseClicked;
                @PrimaryMouseClicked.performed -= instance.OnPrimaryMouseClicked;
                @PrimaryMouseClicked.canceled -= instance.OnPrimaryMouseClicked;
                @SecondaryMouseClicked.started -= instance.OnSecondaryMouseClicked;
                @SecondaryMouseClicked.performed -= instance.OnSecondaryMouseClicked;
                @SecondaryMouseClicked.canceled -= instance.OnSecondaryMouseClicked;
                @MousePosition.started -= instance.OnMousePosition;
                @MousePosition.performed -= instance.OnMousePosition;
                @MousePosition.canceled -= instance.OnMousePosition;
            }

            public void RemoveCallbacks(IDormitoryActions instance)
            {
                if (m_Wrapper.m_DormitoryActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IDormitoryActions instance)
            {
                foreach (var item in m_Wrapper.m_DormitoryActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_DormitoryActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public DormitoryActions @Dormitory => new DormitoryActions(this);

        // Town
        private readonly InputActionMap m_Town;
        private List<ITownActions> m_TownActionsCallbackInterfaces = new List<ITownActions>();
        private readonly InputAction m_Town_Navigation;
        private readonly InputAction m_Town_Run;
        private readonly InputAction m_Town_Select;
        public struct TownActions
        {
            private @InputActions m_Wrapper;
            public TownActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Navigation => m_Wrapper.m_Town_Navigation;
            public InputAction @Run => m_Wrapper.m_Town_Run;
            public InputAction @Select => m_Wrapper.m_Town_Select;
            public InputActionMap Get() { return m_Wrapper.m_Town; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TownActions set) { return set.Get(); }
            public void AddCallbacks(ITownActions instance)
            {
                if (instance == null || m_Wrapper.m_TownActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_TownActionsCallbackInterfaces.Add(instance);
                @Navigation.started += instance.OnNavigation;
                @Navigation.performed += instance.OnNavigation;
                @Navigation.canceled += instance.OnNavigation;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }

            private void UnregisterCallbacks(ITownActions instance)
            {
                @Navigation.started -= instance.OnNavigation;
                @Navigation.performed -= instance.OnNavigation;
                @Navigation.canceled -= instance.OnNavigation;
                @Run.started -= instance.OnRun;
                @Run.performed -= instance.OnRun;
                @Run.canceled -= instance.OnRun;
                @Select.started -= instance.OnSelect;
                @Select.performed -= instance.OnSelect;
                @Select.canceled -= instance.OnSelect;
            }

            public void RemoveCallbacks(ITownActions instance)
            {
                if (m_Wrapper.m_TownActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ITownActions instance)
            {
                foreach (var item in m_Wrapper.m_TownActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_TownActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public TownActions @Town => new TownActions(this);

        // PauseMenu
        private readonly InputActionMap m_PauseMenu;
        private List<IPauseMenuActions> m_PauseMenuActionsCallbackInterfaces = new List<IPauseMenuActions>();
        private readonly InputAction m_PauseMenu_Newaction;
        public struct PauseMenuActions
        {
            private @InputActions m_Wrapper;
            public PauseMenuActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Newaction => m_Wrapper.m_PauseMenu_Newaction;
            public InputActionMap Get() { return m_Wrapper.m_PauseMenu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PauseMenuActions set) { return set.Get(); }
            public void AddCallbacks(IPauseMenuActions instance)
            {
                if (instance == null || m_Wrapper.m_PauseMenuActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PauseMenuActionsCallbackInterfaces.Add(instance);
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }

            private void UnregisterCallbacks(IPauseMenuActions instance)
            {
                @Newaction.started -= instance.OnNewaction;
                @Newaction.performed -= instance.OnNewaction;
                @Newaction.canceled -= instance.OnNewaction;
            }

            public void RemoveCallbacks(IPauseMenuActions instance)
            {
                if (m_Wrapper.m_PauseMenuActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPauseMenuActions instance)
            {
                foreach (var item in m_Wrapper.m_PauseMenuActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PauseMenuActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PauseMenuActions @PauseMenu => new PauseMenuActions(this);

        // AlwaysEnabled
        private readonly InputActionMap m_AlwaysEnabled;
        private List<IAlwaysEnabledActions> m_AlwaysEnabledActionsCallbackInterfaces = new List<IAlwaysEnabledActions>();
        private readonly InputAction m_AlwaysEnabled_Newaction;
        public struct AlwaysEnabledActions
        {
            private @InputActions m_Wrapper;
            public AlwaysEnabledActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Newaction => m_Wrapper.m_AlwaysEnabled_Newaction;
            public InputActionMap Get() { return m_Wrapper.m_AlwaysEnabled; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(AlwaysEnabledActions set) { return set.Get(); }
            public void AddCallbacks(IAlwaysEnabledActions instance)
            {
                if (instance == null || m_Wrapper.m_AlwaysEnabledActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_AlwaysEnabledActionsCallbackInterfaces.Add(instance);
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }

            private void UnregisterCallbacks(IAlwaysEnabledActions instance)
            {
                @Newaction.started -= instance.OnNewaction;
                @Newaction.performed -= instance.OnNewaction;
                @Newaction.canceled -= instance.OnNewaction;
            }

            public void RemoveCallbacks(IAlwaysEnabledActions instance)
            {
                if (m_Wrapper.m_AlwaysEnabledActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IAlwaysEnabledActions instance)
            {
                foreach (var item in m_Wrapper.m_AlwaysEnabledActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_AlwaysEnabledActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public AlwaysEnabledActions @AlwaysEnabled => new AlwaysEnabledActions(this);

        // Testing
        private readonly InputActionMap m_Testing;
        private List<ITestingActions> m_TestingActionsCallbackInterfaces = new List<ITestingActions>();
        private readonly InputAction m_Testing_SaveGame;
        public struct TestingActions
        {
            private @InputActions m_Wrapper;
            public TestingActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @SaveGame => m_Wrapper.m_Testing_SaveGame;
            public InputActionMap Get() { return m_Wrapper.m_Testing; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TestingActions set) { return set.Get(); }
            public void AddCallbacks(ITestingActions instance)
            {
                if (instance == null || m_Wrapper.m_TestingActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_TestingActionsCallbackInterfaces.Add(instance);
                @SaveGame.started += instance.OnSaveGame;
                @SaveGame.performed += instance.OnSaveGame;
                @SaveGame.canceled += instance.OnSaveGame;
            }

            private void UnregisterCallbacks(ITestingActions instance)
            {
                @SaveGame.started -= instance.OnSaveGame;
                @SaveGame.performed -= instance.OnSaveGame;
                @SaveGame.canceled -= instance.OnSaveGame;
            }

            public void RemoveCallbacks(ITestingActions instance)
            {
                if (m_Wrapper.m_TestingActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ITestingActions instance)
            {
                foreach (var item in m_Wrapper.m_TestingActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_TestingActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public TestingActions @Testing => new TestingActions(this);
        public interface IDormitoryActions
        {
            void OnPrimaryMouseClicked(InputAction.CallbackContext context);
            void OnSecondaryMouseClicked(InputAction.CallbackContext context);
            void OnMousePosition(InputAction.CallbackContext context);
        }
        public interface ITownActions
        {
            void OnNavigation(InputAction.CallbackContext context);
            void OnRun(InputAction.CallbackContext context);
            void OnSelect(InputAction.CallbackContext context);
        }
        public interface IPauseMenuActions
        {
            void OnNewaction(InputAction.CallbackContext context);
        }
        public interface IAlwaysEnabledActions
        {
            void OnNewaction(InputAction.CallbackContext context);
        }
        public interface ITestingActions
        {
            void OnSaveGame(InputAction.CallbackContext context);
        }
    }
}
