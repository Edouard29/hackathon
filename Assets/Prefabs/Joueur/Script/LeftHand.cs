using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LeftHand : MonoBehaviour
{
    Vector3 oldPos;
    bool trigger = false;

    public GameObject terre;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centre = new Vector3(0, -52, 0);
        Vector3 pos = transform.TransformPoint(InputTracking.GetLocalPosition(XRNode.LeftHand));
        float dist = Vector3.Distance(pos, centre);

        if (dist > 50)
        {
            Vector3 ventre = InputTracking.GetLocalPosition(XRNode.Head) - new Vector3(0, 0.2f, 0);
            float coefficient = 15 * (Vector3.Distance(InputTracking.GetLocalPosition(XRNode.LeftHand), ventre));
            gameObject.transform.position = InputTracking.GetLocalPosition(XRNode.LeftHand) + coefficient * (InputTracking.GetLocalPosition(XRNode.LeftHand) - ventre);

            gameObject.transform.localRotation = InputTracking.GetLocalRotation(XRNode.LeftHand);
        } else
        {
            Vector3 dirDep = Vector3.Normalize(gameObject.transform.position - oldPos);
            Vector3 axeRotation = new Vector3(-dirDep.y, 0, dirDep.x);
            terre.transform.RotateAround(centre, axeRotation, 0.1f * Mathf.Acos(Vector3.Distance(gameObject.transform.position, oldPos)/50.0f));
        }

        oldPos = gameObject.transform.position;
    }

}
