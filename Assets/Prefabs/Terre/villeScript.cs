using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class villeScript : MonoBehaviour
{
    public int population;
    public float longitude, latitude;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (population <= 0)
            GameObject.Destroy(gameObject);
    }
}
