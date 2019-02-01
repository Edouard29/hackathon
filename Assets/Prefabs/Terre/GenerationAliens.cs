using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GenerationAliens : MonoBehaviour
{
    public GameObject alien;

    float time;
    float timeAttack = 10;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            time = timeAttack;

            popAlien();
        }
    }


    void popAlien()
    {
        GameObject []villes = GameObject.FindGameObjectsWithTag("ville");

        if (villes.Length > 0)
        {
            int rand = Random.Range(0, villes.Length - 1);

            string nom = villes[rand].name;
            float longitude = villes[rand].GetComponent<villeScript>().longitude;
            float latitude = villes[rand].GetComponent<villeScript>().latitude;

            // On utilise les données récupérées dans le fichier

            GameObject newAlien = GameObject.Instantiate(alien);
            newAlien.transform.parent = gameObject.transform;

            newAlien.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(1, 0, 0), 90);
            newAlien.transform.localPosition = new Vector3(0, 0.8f, 40f);
            newAlien.transform.RotateAround(new Vector3(0, gameObject.transform.position.y, 0), new Vector3(1, 0, 0), -latitude);
            newAlien.transform.RotateAround(new Vector3(0, gameObject.transform.position.y, 0), new Vector3(0, 1, 0), -longitude);

            newAlien.GetComponent<alienScript>().nomVilleADetruire = nom;
        }
    }
}
