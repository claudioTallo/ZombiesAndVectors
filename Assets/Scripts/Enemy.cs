using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 10f)] float speed = 2f;

    //[SerializeField][Range(0, 2)] int specimenType = 0;

    enum SpecimenTypes {Cyst, Slasher, Husk};

    [SerializeField] SpecimenTypes specimenType;

    [SerializeField] Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        //Se selecciona el tipo de especimen
        switch(specimenType)
        {
            //Zombie normal que ronda por ahi
            case SpecimenTypes.Cyst:
                MoveForward();
                break;
            //Zombie que te sigue velozmente
            case SpecimenTypes.Slasher:
                ChasePlayer();
                break;
            //Zombie que te dispara
            case SpecimenTypes.Husk:
                RotateAroundPlayer();
                break;
        }
    }

    private void RotateAroundPlayer()
    {
        LookPlayer();
        transform.RotateAround(playerTransform.position, Vector3.up, 20f * Time.deltaTime);
    }

    private void ChasePlayer()
    {
        LookPlayer();
        Vector3 direction = (playerTransform.position - transform.position);
        if (direction.magnitude > 1f)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void LookPlayer()
    {
        transform.LookAt(playerTransform);
    }
}
