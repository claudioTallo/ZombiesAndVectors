using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollition : MonoBehaviour
{
    //En 3d no usar clases ni metodos que digan 2d colliders <-----------

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Entrando en Colision Con: " + other.gameObject.name);    
    }

}
