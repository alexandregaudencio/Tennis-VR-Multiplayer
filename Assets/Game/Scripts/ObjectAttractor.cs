using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectAttractor : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject obj;
    [SerializeField] private InputActionReference TriggerInputActionReference;
    [SerializeField] private float speedAttraction = 10;

    public bool isPressing = false;

    private void Start()
    {
        //TriggerInputActionReference.action.performed += TriggerPerformed;
        obj = FindObjectOfType<Ball>().gameObject;
    }


    private void Update()
    {
        if(TriggerInputActionReference.action.WasPressedThisFrame())
        {
            isPressing = true;

        }
        if (TriggerInputActionReference.action.WasReleasedThisFrame())
        {
            isPressing = false;

        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            isPressing = true;
            obj.GetComponent<Rigidbody>().useGravity = false;

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isPressing = false;
            obj.GetComponent<Rigidbody>().useGravity = true;


        }


    }


    private void FixedUpdate()
    {
        if (isPressing) AttractObject();

    }


    private void AttractObject()
    {
        obj.transform.position = Vector3.Lerp(obj.transform.position, transform.position, speedAttraction * Time.fixedDeltaTime);
    }


}
