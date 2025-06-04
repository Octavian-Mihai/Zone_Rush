using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class scriptTrain : MonoBehaviour
{
    public float positionInitiale;
    public float positionMax = 6f;
    public float positionMin = -6f;
    public float vitesse;
    private Vector3 direction;
    private float limite;
    public GameObject planTrain;

    void Start()
    {
        positionInitiale = transform.position.y;
        vitesse =  Random.Range(0.5f, 1f);

        direction = new Vector3(0, 0, vitesse);
        limite = planTrain.transform.localScale.z *5 - transform.localScale.z/2;
    }

    void Update()
    {
        transform.position += direction * vitesse * Time.deltaTime;

        if (transform.localPosition.z >= limite || transform.localPosition.z <= -limite)
        {
            direction = -direction;
        }
    }
}
