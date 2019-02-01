using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villes : MonoBehaviour
{
    public ArrayList villes;
    public GameObject ville;

    // Start is called before the first frame update
    void Start()
    {
        villes = new ArrayList();

        for(int i = 0; i < 10; i++)
        {
            GameObject tempVille = GameObject.Instantiate(ville);
            tempVille.transform.position = new Vector3(0, 0, 0);
            tempVille.transform.RotateAround(new Vector3(0, -5, 0), new Vector3(1, 0, 1), i * 360 / 10);

            villes.Add(tempVille);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
