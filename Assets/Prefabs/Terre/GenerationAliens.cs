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
        time = timeAttack;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            time = timeAttack;


        }
    }


    void popAlien()
    {
        string fileName = "Assets/Prefabs/Terre/infoVilles.txt";
        TextReader reader;
        reader = new StreamReader(fileName);
        string line;

        int nbLignes = 0;
        while (true)
        {
            // lecture de la ligne
            line = reader.ReadLine();
            // si la ligne est vide on arrête
            if (line == null) break;
            else nbLignes++;
        }
        reader.Close();

        int randLine = Random.Range(0, nbLignes/3);

        reader = new StreamReader(fileName);

        for (int i = 0; i < randLine * 3; i++)
            reader.ReadLine();

        // lecture de la ligne
        line = reader.ReadLine();
        float longitude, latitude;

        line = reader.ReadLine();
        longitude = float.Parse(line);
        line = reader.ReadLine();
        latitude = float.Parse(line);

        // On utilise les données récupérées dans le fichier

        GameObject newAlien = GameObject.Instantiate(alien);
        newAlien.transform.parent = gameObject.transform;
        newAlien.transform.localPosition = new Vector3(0, 0, 25f);
        newAlien.transform.RotateAround(new Vector3(0, gameObject.transform.position.y, 0), new Vector3(1, 0, 0), -latitude);
        newAlien.transform.RotateAround(new Vector3(0, gameObject.transform.position.y, 0), new Vector3(0, 1, 0), -longitude);

        reader.Close();
    }
}
