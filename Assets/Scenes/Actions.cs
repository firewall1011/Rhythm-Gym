// GENERATED AUTOMATICALLY FROM 'Assets/Scenes/Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Actions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Actions"",
    ""maps"": [
        {
            ""name"": ""Supino"",
            ""id"": ""f483db39-19c3-48d4-b2e4-6a7d525ffd85"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""Button"",
                    ""id"": ""f2dcccf1-9b06-4a08-80ef-c00a036bfb26"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9b2cde88-c634-46ad-bd30-891ecb33e77b"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6dfd4cf2-5355-47fc-95f9-bce1b9245ce3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Supino
        m_Supino = asset.FindActionMap("Supino", throwIfNotFound: true);
        m_Supino_Tap = m_Supino.FindAction("Tap", throwIfNotFound: true);
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

    // Supino
    private readonly InputActionMap m_Supino;
    private ISupinoActions m_SupinoActionsCallbackInterface;
    private readonly InputAction m_Supino_Tap;
    public struct SupinoActions
    {
        private @Actions m_Wrapper;
        public SupinoActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_Supino_Tap;
        public InputActionMap Get() { return m_Wrapper.m_Supino; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SupinoActions set) { return set.Get(); }
        public void SetCallbacks(ISupinoActions instance)
        {
            if (m_Wrapper.m_SupinoActionsCallbackInterface != null)
            {
                @Tap.started -= m_Wrapper.m_SupinoActionsCallbackInterface.OnTap;
                @Tap.performed -= m_Wrapper.m_SupinoActionsCallbackInterface.OnTap;
                @Tap.canceled -= m_Wrapper.m_SupinoActionsCallbackInterface.OnTap;
            }
            m_Wrapper.m_SupinoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tap.started += instance.OnTap;
                @Tap.performed += instance.OnTap;
                @Tap.canceled += instance.OnTap;
            }
        }
    }
    public SupinoActions @Supino => new SupinoActions(this);
    public interface ISupinoActions
    {
        void OnTap(InputAction.CallbackContext context);
    }
}
