using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Villes : MonoBehaviour
{
    public GameObject canvas;
    public GameObject ville;

    // Start is called before the first frame update
    void Start()
    {

        string fileName = "Assets/Prefabs/Terre/infoVilles.txt";
        TextReader reader;
        reader = new StreamReader(fileName);
        string line;
        while (true)
        {
            // lecture de la ligne
            line = reader.ReadLine();
            // si la ligne est vide on arrête
            if (line == null) break;

            string nom = line;
            float longitude, latitude;

            line = reader.ReadLine();
            longitude = float.Parse(line);
            line = reader.ReadLine();
            latitude = float.Parse(line);
            line = reader.ReadLine();
            int population = int.Parse(line);

            // On utilise les données récupérées dans le fichier

            GameObject tempVille = GameObject.Instantiate(ville);
            tempVille.transform.parent = gameObject.transform;
            tempVille.transform.localPosition = new Vector3(0, 0, 20.3f);
            tempVille.transform.RotateAround(new Vector3(0, gameObject.transform.position.y, 0), new Vector3(1, 0, 0), -latitude);
            tempVille.transform.RotateAround(new Vector3(0, gameObject.transform.position.y, 0), new Vector3(0, 1, 0), -longitude);
            tempVille.layer = 9;

            tempVille.GetComponent<villeScript>().population = population;
            tempVille.GetComponent<villeScript>().longitude = longitude;
            tempVille.GetComponent<villeScript>().latitude = latitude;
            tempVille.name = nom;
            tempVille.tag = "ville";

            GameObject nomVille = GameObject.Instantiate(canvas);
            nomVille.transform.parent = gameObject.transform;

            nomVille.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), 180);

            nomVille.transform.localPosition = new Vector3(0, 0, 20.2f);
            
            nomVille.transform.RotateAround(new Vector3(0, gameObject.transform.position.y, 0), new Vector3(1, 0, 0), -latitude);
            nomVille.transform.RotateAround(new Vector3(0, gameObject.transform.position.y, 0), new Vector3(0, 1, 0), -longitude);
            nomVille.layer = 9;

            nomVille.GetComponent<UnityEngine.UI.Text>().text = nom;
        }
        reader.Close();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
