using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scriptCube : MonoBehaviour
{
    private float _tempsGare = 0;
    private float _tempsChantier = 0;
    private float _tempsForet = 0;
    private float _tempsTotal = 0;
    public TMP_Text valeurGareIG;
    public TMP_Text valeurChantierIG;
    public TMP_Text valeurForetIG;
    public TMP_Text valeurTotalIG;
    public TMP_Text messageFin;

    private int penaliteArbre;
    private int penaliteChantier;
    private int penaliteTrain;

    private int nbSecondes;
    private int minutes;
    private int secondes;
    private int nbSecondesGare;
    private int minutesGare;
    private int secondesGare;
    private int nbSecondesChantier;
    private int minutesChantier;
    private int secondesChantier;
    private int nbSecondesForet;
    private int minutesForet;
    private int secondesForet;

    public GameObject gameObjectInGame;

    public GameObject joueur;
    public GameObject plan;
    public float vitesse = 5f;

    private float limiteX;
    private float limiteZ;

    void Start()
    {
        joueur.transform.localPosition = new Vector3(20f, 1f, 3.3f);   
        limiteX = plan.transform.localScale.x * 5 - transform.localScale.x / 2;
        limiteZ = plan.transform.localScale.z * 5 - transform.localScale.z / 2;
    }

    void Update()
    {
        float vert = Input.GetAxis("Vertical") * vitesse * Time.deltaTime;
        float hor = Input.GetAxis("Horizontal") * vitesse * Time.deltaTime;

        float abs = transform.position.x + vert;
        float profond = transform.position.z + -1 * hor;

        joueur.transform.position = new Vector3(abs, 1, profond);

        if (transform.position.z >= 8.5f)                // limite z
        {
            joueur.transform.position = new Vector3(abs, 1, 8.5f);
        }
        if (transform.position.z <= -2.5f)               // limite z
        {
            joueur.transform.position = new Vector3(abs, 1, -2.5f);
        }
        if (transform.position.x >= 20f)                 // limite x
        {
            joueur.transform.position = new Vector3(20f, 1, profond);
        }
        if (transform.position.x <= -42f)                 // limite x
        {
            joueur.transform.position = new Vector3(-42f, 1, profond);
        }




        // cheat code N
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (transform.position.x < 20f && transform.position.x > 0f)      // sauter gare
            {
                joueur.transform.position = new Vector3(-0.2f, 1f, 3.3f);
            }
            else if (transform.position.x < -0.01f && transform.position.x > -20f)  // sauter chantier
            {
                joueur.transform.position = new Vector3(-20.01f, 1f, 3.3f);
            }
            else                                                               // sauter foret
            {
                joueur.transform.position = new Vector3(-40.8f, 1f, 3.3f);
            }
        }
       
        if (transform.position.x < 19.99f && transform.position.x > -40f)          // temps du jeu
        {
            _tempsTotal += Time.deltaTime;
            nbSecondes = (int)_tempsTotal;
            minutes = nbSecondes / 60;
            secondes = nbSecondes % 60;
            valeurTotalIG.text = minutes + " min " + secondes + " sec";
        
            if (transform.position.x < 19.99f && transform.position.x > 0)  // temps pour la gare
            {
                _tempsGare += Time.deltaTime;
                nbSecondesGare = (int)_tempsGare;
                minutesGare = nbSecondesGare / 60;
                secondesGare = nbSecondesGare % 60;
                valeurGareIG.text = minutesGare + " min " + secondesGare + " sec";
            }
            else if (transform.position.x < -0.01f && transform.position.x > -20f) // temps chantier
            {
                _tempsChantier += Time.deltaTime;
                nbSecondesChantier = (int)_tempsChantier;
                minutesChantier = nbSecondesChantier / 60;
                secondesChantier = nbSecondesChantier % 60;
                valeurChantierIG.text = minutesChantier + " min " + secondesChantier + " sec";
            }
            else if (transform.position.x < -19.99f && transform.position.x > -40f)   // temps foret
            {
                _tempsForet += Time.deltaTime;
                nbSecondesForet = (int)_tempsForet;
                minutesForet = nbSecondesForet / 60;
                secondesForet = nbSecondesForet % 60;
                valeurForetIG.text = minutesForet + " min " + secondesForet + " sec";
            }
        }    
    }


    void OnTriggerEnter(Collider other)
    {
        {
            if (transform.position.x < 20f && transform.position.x > 0f)  // trigger train
            {
                joueur.transform.position = new Vector3(19.9f, 1f, 3.3f);
                _tempsGare += 2;
                _tempsTotal += 2;
            }
            else if (transform.position.x < 0.01f && transform.position.x > -20f)   // trigger chantier
            {
                joueur.transform.position = new Vector3(0f, 1f, 3.3f);
                _tempsChantier += 2;
                _tempsTotal += 2;
            }
            else
            {
                joueur.transform.position = new Vector3(-20.1f, 1f, 3.3f);  // trigger arbre foret
                _tempsForet += 2;
                _tempsTotal += 2;
            }
        }
    }
}
