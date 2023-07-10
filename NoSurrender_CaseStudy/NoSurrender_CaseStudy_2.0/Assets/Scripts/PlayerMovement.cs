using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    /* Hız ayarlamalarının kolay denenebilmesi için Serialize Field oluşturulmuştur. */


    [SerializeField] private float movSpeed;            //Movement Speed, karakterin hareket hızı
    [SerializeField] private float rotSpeed = 300;      //Rotation Speed, karakterin yön değiştirme hızı


    private Touch touch;                                //Mobil üzerinde dokunmatiği tanımlayan yapı  *** SİMÜLASYON EKLENTİSİ İLE GÖZLEMLENİR ***


    private bool screenTouch = false;                   //Ekrana dokunma kontrolü
    private bool isMoving = false;                      //Karakter hareket kontrolü
    private Vector3 a_Point;                            //Hareketin başladığı nokta
    private Vector3 b_Point;                            //Hareketin sona erdiği nokta



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /* DOKUNMA BAŞLANGIÇ */

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)         //Dokunmanın başladığı aşama
            {
                screenTouch = true;
                isMoving = true;                        //Animasyon kontrolü için

                a_Point = touch.position;               // Başlangıç ve bitiş noktalarının
                b_Point = touch.position;               // o anki konumu alınır. 
            }
        }


        /* DOKUNMA ANI */

        if (screenTouch)
        {

            if(touch.phase == TouchPhase.Moved)         //Dokunmatik yönlendiricinin sürüklenme aşaması
            {
                b_Point = touch.position;               //Sürüklenme aşamasında B noktası (Bitiş) güncellemesi
            }


            if(touch.phase == TouchPhase.Ended)         //Dokunma eyleminin bitişi
            {
                b_Point = touch.position;
                isMoving = false;                       //Karakter hareket etmeyi bırakır.
                screenTouch = false;                    //Dokunmatiğin bitişi
            }

            gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, calcRotation(), rotSpeed * Time.deltaTime);
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * movSpeed);
        }

    

        /* YÖN HESAPLAMALARI */

        Quaternion calcRotation()               //Açı hesabı
        {
            Quaternion temp = Quaternion.LookRotation(calcDirection(), Vector3.up);
            return temp;
        }

        Vector3 calcDirection()
        {
            Vector3 temp = (b_Point - a_Point).normalized;              // Ortaya çıkan vektör boyutu küçültürmüştür
            temp.z = temp.y;                                            // Z ekseninde hareket sağlanır
            temp.y = 0; 
            return temp;
        }
    }
}
