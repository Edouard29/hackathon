using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienScript : MonoBehaviour
{
    float vitesse = 0.1f;
    int morts = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centreAlien = gameObject.transform.position - new Vector3(0, -20.2f, 0);

        if(centreAlien.magnitude > 20.2)
            gameObject.transform.position -= vitesse * centreAlien;
        else
        {
            morts++;
        }
    }
}
