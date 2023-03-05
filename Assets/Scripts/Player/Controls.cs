using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    public static Controls Instance;

    [SerializeField] private InputActionMap playerControls;
    
    public InputActionMap Crtls
    {
        get { return playerControls; }
        set { playerControls = value; }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable() 
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }    
}
