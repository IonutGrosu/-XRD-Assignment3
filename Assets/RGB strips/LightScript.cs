using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LightScript : MonoBehaviour
{
    [SerializeField] private XRRayInteractor _interactor;
    public GameObject onObj;
    public GameObject offObj;
    public GameObject lightText;
    public GameObject lightObj;

    public GameObject[] allLights; 

    public bool isLightOn;
    public bool isLightOff;
    public bool isInReach;

    [SerializeField] private InputActionAsset playerActions;
    private InputAction _activateAction;

    void Start()
    {
        var rightHandActions = playerActions.FindActionMap("XRI RightHand Interaction");
        _activateAction = rightHandActions.FindAction("Activate");
        
        isInReach = true;
        isLightOn = true;
        isLightOff = false;
        onObj.SetActive(true);
        lightObj.SetActive(true);

        allLights = GameObject.FindGameObjectsWithTag ("led_stripe");
    }


    public void ToggleLight()
    {
        isLightOn = !isLightOn;
        isLightOff = !isLightOff;

        // lightObj.SetActive(isLightOn);

         foreach (GameObject light in allLights){ 
            light.SetActive(isLightOn); 
        } 

        onObj.SetActive(isLightOff);
        offObj.SetActive(isLightOn);
    }

    
    void Update()
    {
        _interactor.TryGetCurrent3DRaycastHit(out RaycastHit hit);
        if (_activateAction.IsPressed() && hit.collider.gameObject.CompareTag("lightSwitch"))
        {
            ToggleLight();
        }
    }
}
