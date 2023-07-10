using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] float detectionRange;
    [SerializeField] float movSpeed;
    [SerializeField] float pushForce = 150;                     //Oyuncunun itiş gücü
    [SerializeField] private Transform player;                  //Hedef karakter

    GameController gc;
    Rigidbody rb;
    float distance;  
    Vector3 temp;


    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindObjectOfType<GameController>();
        rb = GetComponent<Rigidbody>();


        if (!player)                        //Player tespiti
        {
            player = GameObject.FindObjectOfType<PlayerMovement>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

        temp = player.transform.position;
        temp.y = transform.position.y;

        distance = Vector3.Distance(transform.position, player.transform.position);                     //Player ve Enemy arasındaki mesafe

        if(distance <= detectionRange)
        {
            transform.LookAt(temp);
            transform.Translate(Vector3.forward * movSpeed * Time.deltaTime);
        }
    }

    /* GAME OVER */
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {
            gc.increaseScore();
        }
    }

    /* PLAYER SALDIRISI */
    private void OnCollisionEnter(Collision collision)                  //Oyuncunun düşmana uyguladığı itiş
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce(-transform.forward * pushForce);
        }
    }
}
