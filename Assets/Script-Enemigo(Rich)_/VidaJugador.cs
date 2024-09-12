using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int cantidadDeVida;

    public void TomarDano(int dano)
    {
        cantidadDeVida -= dano;
        if(cantidadDeVida <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
