using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class scriptArbre : MonoBehaviour
{
    public float hauteurInitiale;
    public float hauteurMax = 1f;
    public float hauteurMin = -2f;
    public float vitesse;
    private Vector3 directionArbre;

    private bool versHaut = true;
     
    void Start()
    {
        hauteurInitiale = transform.position.y;
        vitesse = Random.Range(0.5f, 1f);

        directionArbre = new Vector3(0, vitesse, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (versHaut)
        {
            transform.Translate(directionArbre*vitesse*Time.deltaTime);
            if (transform.position.y >= hauteurMax)
            {
                 versHaut = false;
            }
        }
        else
        {
            transform.Translate(-(directionArbre * vitesse * Time.deltaTime));
            if (transform.position.y <= hauteurMin)
            {
                versHaut = true;
            }
        }
    }
}
