//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/KnifeOnlyI/Scripts/Prefabs/Players/FpsPlayerFreeCamera/FpsPlayerFreeCameraInputActions.inputactions
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

public partial class @FpsPlayerFreeCameraInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @FpsPlayerFreeCameraInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FpsPlayerFreeCameraInputActions"",
    ""maps"": [
        {
            ""name"": ""Movements"",
            ""id"": ""4b328b8e-d9c0-444e-957d-e0b72804e31f"",
            ""actions"": [
                {
                    ""name"": ""LookHorizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c695ce2f-9f36-429a-bbe5-91df22b71e62"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LookVertical"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7b3cbac0-86ea-4057-bca9-935d6417b3d7"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HorizontalMovements"",
                    ""type"": ""Value"",
                    ""id"": ""0ac02525-84ab-41bc-85d8-14eb992b14c2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SetMovementsSpeed"",
                    ""type"": ""Value"",
                    ""id"": ""c27d019b-5ecc-4c75-8d92-7d614c0f3cb4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""VerticalMovements"",
                    ""type"": ""Value"",
                    ""id"": ""cceb1e33-5600-4b7c-8349-9013d7069025"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""191de23c-812d-4266-82d9-b3e1e31a866d"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookHorizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df4bc734-cef7-4340-8315-4e55e7945170"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookVertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f542d5fc-8d2d-4a8f-9dcc-a0aa9cae5445"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovements"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""80e07fd4-091c-4256-b80a-13478633f825"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cac61d50-0881-4498-bad6-49fb2482a1fb"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""24ee098a-aeee-493c-ad40-ed181c71bab5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6b267595-8209-4474-a12e-ac3070d22e62"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d98ffb35-35c5-4e25-8966-ac7ecbce82e7"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""SetMovementsSpeed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""d5ab5c32-0c91-4f90-870e-76b08c7b976d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovements"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bc9ef7b5-cda8-43e0-be0a-698d3b2e47a9"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f1db05a4-064f-499f-b8c1-fa564ad5becb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movements
        m_Movements = asset.FindActionMap("Movements", throwIfNotFound: true);
        m_Movements_LookHorizontal = m_Movements.FindAction("LookHorizontal", throwIfNotFound: true);
        m_Movements_LookVertical = m_Movements.FindAction("LookVertical", throwIfNotFound: true);
        m_Movements_HorizontalMovements = m_Movements.FindAction("HorizontalMovements", throwIfNotFound: true);
        m_Movements_SetMovementsSpeed = m_Movements.FindAction("SetMovementsSpeed", throwIfNotFound: true);
        m_Movements_VerticalMovements = m_Movements.FindAction("VerticalMovements", throwIfNotFound: true);
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

    // Movements
    private readonly InputActionMap m_Movements;
    private IMovementsActions m_MovementsActionsCallbackInterface;
    private readonly InputAction m_Movements_LookHorizontal;
    private readonly InputAction m_Movements_LookVertical;
    private readonly InputAction m_Movements_HorizontalMovements;
    private readonly InputAction m_Movements_SetMovementsSpeed;
    private readonly InputAction m_Movements_VerticalMovements;
    public struct MovementsActions
    {
        private @FpsPlayerFreeCameraInputActions m_Wrapper;
        public MovementsActions(@FpsPlayerFreeCameraInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @LookHorizontal => m_Wrapper.m_Movements_LookHorizontal;
        public InputAction @LookVertical => m_Wrapper.m_Movements_LookVertical;
        public InputAction @HorizontalMovements => m_Wrapper.m_Movements_HorizontalMovements;
        public InputAction @SetMovementsSpeed => m_Wrapper.m_Movements_SetMovementsSpeed;
        public InputAction @VerticalMovements => m_Wrapper.m_Movements_VerticalMovements;
        public InputActionMap Get() { return m_Wrapper.m_Movements; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementsActions set) { return set.Get(); }
        public void SetCallbacks(IMovementsActions instance)
        {
            if (m_Wrapper.m_MovementsActionsCallbackInterface != null)
            {
                @LookHorizontal.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnLookHorizontal;
                @LookHorizontal.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnLookHorizontal;
                @LookHorizontal.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnLookHorizontal;
                @LookVertical.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnLookVertical;
                @LookVertical.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnLookVertical;
                @LookVertical.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnLookVertical;
                @HorizontalMovements.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnHorizontalMovements;
                @HorizontalMovements.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnHorizontalMovements;
                @HorizontalMovements.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnHorizontalMovements;
                @SetMovementsSpeed.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnSetMovementsSpeed;
                @SetMovementsSpeed.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnSetMovementsSpeed;
                @SetMovementsSpeed.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnSetMovementsSpeed;
                @VerticalMovements.started -= m_Wrapper.m_MovementsActionsCallbackInterface.OnVerticalMovements;
                @VerticalMovements.performed -= m_Wrapper.m_MovementsActionsCallbackInterface.OnVerticalMovements;
                @VerticalMovements.canceled -= m_Wrapper.m_MovementsActionsCallbackInterface.OnVerticalMovements;
            }
            m_Wrapper.m_MovementsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LookHorizontal.started += instance.OnLookHorizontal;
                @LookHorizontal.performed += instance.OnLookHorizontal;
                @LookHorizontal.canceled += instance.OnLookHorizontal;
                @LookVertical.started += instance.OnLookVertical;
                @LookVertical.performed += instance.OnLookVertical;
                @LookVertical.canceled += instance.OnLookVertical;
                @HorizontalMovements.started += instance.OnHorizontalMovements;
                @HorizontalMovements.performed += instance.OnHorizontalMovements;
                @HorizontalMovements.canceled += instance.OnHorizontalMovements;
                @SetMovementsSpeed.started += instance.OnSetMovementsSpeed;
                @SetMovementsSpeed.performed += instance.OnSetMovementsSpeed;
                @SetMovementsSpeed.canceled += instance.OnSetMovementsSpeed;
                @VerticalMovements.started += instance.OnVerticalMovements;
                @VerticalMovements.performed += instance.OnVerticalMovements;
                @VerticalMovements.canceled += instance.OnVerticalMovements;
            }
        }
    }
    public MovementsActions @Movements => new MovementsActions(this);
    public interface IMovementsActions
    {
        void OnLookHorizontal(InputAction.CallbackContext context);
        void OnLookVertical(InputAction.CallbackContext context);
        void OnHorizontalMovements(InputAction.CallbackContext context);
        void OnSetMovementsSpeed(InputAction.CallbackContext context);
        void OnVerticalMovements(InputAction.CallbackContext context);
    }
}
