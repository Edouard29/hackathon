using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LeftHand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(InputTracking.GetLocalPosition(XRNode.LeftHand), InputTracking.GetLocalPosition(XRNode.Head)) < 0.5)
        {
            gameObject.transform.position = InputTracking.GetLocalPosition(XRNode.LeftHand);
        } else
        {
            float coefficient = 0.5f + Vector3.Distance(InputTracking.GetLocalPosition(XRNode.LeftHand), InputTracking.GetLocalPosition(XRNode.Head));
            gameObject.transform.position = coefficient*InputTracking.GetLocalPosition(XRNode.LeftHand);
        }
        gameObject.transform.localRotation = InputTracking.GetLocalRotation(XRNode.LeftHand);
    }
}
