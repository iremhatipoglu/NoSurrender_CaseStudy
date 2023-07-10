using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedCamera : MonoBehaviour
{
    [SerializeField] private Transform target;                  //Hedef karakter
    [SerializeField] private Vector3 offset;                    //Mesafe   
    [SerializeField] private float camSpeed = 1;                //Kamera hızı


    void Start()
    {
        if (!target)            //Hedef tespiti
        {
            target = GameObject.FindObjectOfType<PlayerMovement>().transform;
        }
    }

    private void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, target.position + offset, camSpeed * Time.deltaTime);         /* Kamera mesafesi eklenerek konum 
                                                                                                                             * karakter konumuna dönüştürülür */
                                                                                                                             
    }
}