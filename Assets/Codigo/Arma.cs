using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public SpriteRenderer Arma1;
    public SpriteRenderer Arma2;
    public movimientopersonaje personaje;

    void Start()
    {
        Arma2.enabled = false;
        Arma1.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Arma1.enabled = true;
            Arma2.enabled = false;
            personaje.weapon=true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Arma2.enabled = true;
            Arma1.enabled = false;
            personaje.weapon=false;

        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Arma1.enabled = false;
            Arma2.enabled = false;
            personaje.weapon=false;

        }
    }
}