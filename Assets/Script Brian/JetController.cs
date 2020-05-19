/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class JetController : MonoBehaviour
{

    public Transform leftHandTransform;
    public Transform rightHandTransform;

    public SteamVR_Input_Sources leftHand; // 1
    public SteamVR_Input_Sources rightHand; // 1

    public SteamVR_Action_Single thrustAction; // 2

    Rigidbody rb;

    public float power = 1000;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(thrustAction.GetAxis(leftHand));
        Debug.Log(thrustAction.GetAxis(rightHand));

        float leftThrust = thrustAction.GetAxis(leftHand);
        float rightThrust = thrustAction.GetAxis(rightHand);
        rb.AddForce(leftHandTransform.forward * leftThrust * power * Time.deltaTime);
        rb.AddForce(rightHandTransform.forward * rightThrust * power * Time.deltaTime);
    }
}
*/