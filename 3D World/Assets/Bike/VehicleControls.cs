// GENERATED AUTOMATICALLY FROM 'Assets/Input System/VehicleControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @VehicleControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @VehicleControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""VehicleControls"",
    ""maps"": [
        {
            ""name"": ""AirBike"",
            ""id"": ""6e301a80-e8ad-4e13-82b0-d1c2da0df782"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""da792278-7972-48a6-b6ef-eb8a51956487"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throttle"",
                    ""type"": ""Value"",
                    ""id"": ""46e4da07-9b75-4a5b-8f36-b14597378c91"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FlyMode"",
                    ""type"": ""Button"",
                    ""id"": ""f2309883-07b2-45da-8304-247d6eb43301"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""334e06b8-f790-4fb3-8ecc-fa42c3a8ceb3"",
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
                    ""id"": ""8b6f3d2a-ea37-427e-b0b1-f8fe31fda14a"",
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
                    ""id"": ""8c43131f-ce7d-4b57-8688-f89cdc8e0ea7"",
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
                    ""id"": ""d809a415-d910-437e-a669-b377529809c3"",
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
                    ""id"": ""d77d52de-ad13-4b62-96d3-67cfbc24767f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Up/Down"",
                    ""id"": ""16dcc581-51c3-4450-885f-82cef53d0e57"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""99441843-9b12-4370-b343-f129a70713d6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2cb4aaae-835e-42e2-ad73-b783b29c61d3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""527dd3e3-8ddf-428e-ab26-8fd23f0b3e07"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlyMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // AirBike
        m_AirBike = asset.FindActionMap("AirBike", throwIfNotFound: true);
        m_AirBike_Move = m_AirBike.FindAction("Move", throwIfNotFound: true);
        m_AirBike_Throttle = m_AirBike.FindAction("Throttle", throwIfNotFound: true);
        m_AirBike_FlyMode = m_AirBike.FindAction("FlyMode", throwIfNotFound: true);
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

    // AirBike
    private readonly InputActionMap m_AirBike;
    private IAirBikeActions m_AirBikeActionsCallbackInterface;
    private readonly InputAction m_AirBike_Move;
    private readonly InputAction m_AirBike_Throttle;
    private readonly InputAction m_AirBike_FlyMode;
    public struct AirBikeActions
    {
        private @VehicleControls m_Wrapper;
        public AirBikeActions(@VehicleControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_AirBike_Move;
        public InputAction @Throttle => m_Wrapper.m_AirBike_Throttle;
        public InputAction @FlyMode => m_Wrapper.m_AirBike_FlyMode;
        public InputActionMap Get() { return m_Wrapper.m_AirBike; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AirBikeActions set) { return set.Get(); }
        public void SetCallbacks(IAirBikeActions instance)
        {
            if (m_Wrapper.m_AirBikeActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_AirBikeActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_AirBikeActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_AirBikeActionsCallbackInterface.OnMove;
                @Throttle.started -= m_Wrapper.m_AirBikeActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_AirBikeActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_AirBikeActionsCallbackInterface.OnThrottle;
                @FlyMode.started -= m_Wrapper.m_AirBikeActionsCallbackInterface.OnFlyMode;
                @FlyMode.performed -= m_Wrapper.m_AirBikeActionsCallbackInterface.OnFlyMode;
                @FlyMode.canceled -= m_Wrapper.m_AirBikeActionsCallbackInterface.OnFlyMode;
            }
            m_Wrapper.m_AirBikeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @FlyMode.started += instance.OnFlyMode;
                @FlyMode.performed += instance.OnFlyMode;
                @FlyMode.canceled += instance.OnFlyMode;
            }
        }
    }
    public AirBikeActions @AirBike => new AirBikeActions(this);
    public interface IAirBikeActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnThrottle(InputAction.CallbackContext context);
        void OnFlyMode(InputAction.CallbackContext context);
    }
}
