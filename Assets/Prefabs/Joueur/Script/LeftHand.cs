using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LeftHand : MonoBehaviour
{
    Vector3 oldPos;
    Transform transformPre;
    bool trigger = false;
    
    public GameObject terre;

    // Start is called before the first frame update
    void Start()
    {
        transformPre = terre.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centre = new Vector3(0, -21, 0);
        Vector3 pos = transform.TransformPoint(InputTracking.GetLocalPosition(XRNode.LeftHand));
        float dist = Vector3.Distance(pos, centre);

        Debug.Log(dist);

        if (dist > 20.2)
        {
            Vector3 ventre = InputTracking.GetLocalPosition(XRNode.Head) - new Vector3(0, 0.2f, 0);
            Vector3 angleVue = InputTracking.GetLocalRotation(XRNode.Head).eulerAngles ;
            float coefficient = 15 * (Vector3.Distance(InputTracking.GetLocalPosition(XRNode.LeftHand), ventre));
            gameObject.transform.position = InputTracking.GetLocalPosition(XRNode.LeftHand) + coefficient * (InputTracking.GetLocalPosition(XRNode.LeftHand) - ventre);

            Vector3 rotation = InputTracking.GetLocalRotation(XRNode.LeftHand).eulerAngles;
            rotation += new Vector3(90,180,0);
            rotation.x *= -1;
            rotation.y -= angleVue.y;
            gameObject.transform.localRotation = Quaternion.Euler(rotation);
            oldPos = gameObject.transform.position;
        } else
        {
            Vector3 dirDep = Vector3.Normalize(transform.TransformPoint(gameObject.transform.position) - transform.TransformPoint(oldPos));
            Vector3 axeRotation = new Vector3(-dirDep.z, 0, dirDep.x);
            axeRotation.Normalize();

            if (axeRotation.magnitude > 0)
            {
                terre.transform.position = transformPre.position;
                terre.transform.rotation = transformPre.rotation;

                float distance = Vector3.Distance(transform.TransformPoint(gameObject.transform.position), transform.TransformPoint(oldPos));

                float angle = Mathf.Asin(0.5f*distance / 20.2f);
                terre.transform.RotateAround(centre, axeRotation, -angle);

                transformPre = terre.transform;
            }
        }
    }

}
