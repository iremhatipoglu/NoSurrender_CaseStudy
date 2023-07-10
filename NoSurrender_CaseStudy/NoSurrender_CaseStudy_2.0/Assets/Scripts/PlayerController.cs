using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float enemyPushForce;          //Düşmanların uygulayacağı itme kuvveti

    Rigidbody rb;
    GameController gc;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gc = GameObject.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* ENEMY SALDIRISI */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.AddForce(-transform.forward * enemyPushForce);
        }
    }

    /* GAME OVER */
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag ("GameOver"))
        {
            gc.gameOverByFall();
        }
    }

}
