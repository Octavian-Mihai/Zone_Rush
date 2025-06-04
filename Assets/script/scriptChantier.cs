using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public float vitesse; 
   
    void Start()
    {
        vitesse = Random.Range(-25f, 25f);
    }
     
    void Update()
    {
        transform.Rotate(0, 0, vitesse * Time.deltaTime);
    }

}
