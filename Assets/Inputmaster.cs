// GENERATED AUTOMATICALLY FROM 'Assets/Inputmaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputmaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputmaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputmaster"",
    ""maps"": [
        {
            ""name"": ""Animations"",
            ""id"": ""d603c006-ad15-46a0-a38a-882afeef0d50"",
            ""actions"": [],
            ""bindings"": []
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Animations
        m_Animations = asset.FindActionMap("Animations", throwIfNotFound: true);
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

    // Animations
    private readonly InputActionMap m_Animations;
    private IAnimationsActions m_AnimationsActionsCallbackInterface;
    public struct AnimationsActions
    {
        private @Inputmaster m_Wrapper;
        public AnimationsActions(@Inputmaster wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_Animations; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AnimationsActions set) { return set.Get(); }
        public void SetCallbacks(IAnimationsActions instance)
        {
            if (m_Wrapper.m_AnimationsActionsCallbackInterface != null)
            {
            }
            m_Wrapper.m_AnimationsActionsCallbackInterface = instance;
            if (instance != null)
            {
            }
        }
    }
    public AnimationsActions @Animations => new AnimationsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IAnimationsActions
    {
    }
}
