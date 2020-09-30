using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectInputs : MonoBehaviour
{
    public static Action OnSwipeUp; 
    public static Action OnSwipeDown; 
    public static Action OnSwipeLeft; 
    public static Action OnSwipeRight;

    public float SwipeDeadZone = 0.5f;

    [SerializeField] private InputActionAsset inputActions;

    private Vector2 _initialPosition;
    private float _sqrDeadZone;

    private void Awake()
    {
        inputActions = GetComponent<PlayerInput>().actions;
        inputActions["Tap"].started += Tap_started;
        inputActions["Tap"].canceled += Tap_canceled;

        _sqrDeadZone = SwipeDeadZone * SwipeDeadZone;
    }

    public virtual void HandleSwipeDirection(Vector2 swipeDir)
    {
        if (swipeDir.sqrMagnitude <= _sqrDeadZone)
        {
            return;
        }

        swipeDir.Normalize();

        if (Mathf.Abs(swipeDir.x) > Mathf.Abs(swipeDir.y))
        {
            if(swipeDir.x > float.Epsilon)
                OnSwipeRight?.Invoke();
            else
                OnSwipeLeft?.Invoke();
        }
        else
        {
            if (swipeDir.y > float.Epsilon)
                OnSwipeUp?.Invoke();
            else
                OnSwipeDown?.Invoke();
        }

        Debug.Log($"Direction: {swipeDir}");
    }

    private void Tap_canceled(InputAction.CallbackContext ctx)
    {
        Vector2 finalPosition;
#if UNITY_EDITOR
        finalPosition = Input.mousePosition;
#else
        finalPosition = Input.GetTouch(0).position;
#endif
        Vector2 swipeDirection = finalPosition - _initialPosition;
        HandleSwipeDirection(swipeDirection);
    }

    private void Tap_started(InputAction.CallbackContext ctx)
    {
#if UNITY_EDITOR
        MouseStarted();
#else
        MobileStarted();
#endif
    }

    private void MobileStarted()
    {
        _initialPosition = Input.GetTouch(0).position;
    }

    private void MouseStarted()
    {
        _initialPosition = Input.mousePosition;
    }

    private void OnDisable()
    {
        inputActions["Tap"].started -= Tap_started;
        inputActions["Tap"].canceled -= Tap_canceled;
        inputActions.Disable();
    }
}
