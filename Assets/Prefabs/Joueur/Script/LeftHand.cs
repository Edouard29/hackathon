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
        gameObject.transform.position = InputTracking.GetLocalPosition(XRNode.LeftHand);
        gameObject.transform.localRotation = InputTracking.GetLocalRotation(XRNode.LeftHand);
    }
}
