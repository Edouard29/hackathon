using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienScript : MonoBehaviour
{
    float vitesse = 0.002f;
    int morts = 0;
    bool end = false;

    public string nomVilleADetruire;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centreAlien = gameObject.transform.position - new Vector3(0, -20.2f, 0);

        if (!end)
        {
            if (centreAlien.magnitude > 21)
                gameObject.transform.position -= vitesse * centreAlien;
            else
            {
                int m = Random.Range(0, 2000);
                if (GameObject.Find(nomVilleADetruire).GetComponent<villeScript>().population - m < 0)
                {
                    m = GameObject.Find(nomVilleADetruire).GetComponent<villeScript>().population;
                    end = true;
                }

                GameObject.Find(nomVilleADetruire).GetComponent<villeScript>().population -= m;
                morts += m;
            }
        }
        else
        {
            gameObject.transform.position += vitesse * centreAlien;
            if (centreAlien.magnitude > 50)
            {
                GameObject.Destroy(gameObject);
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("alien");
        GameObject.Destroy(gameObject);
    }
}
