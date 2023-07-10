using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameStates { START, WIN, LOSE, PAUSE, RESUME}
public class GameController : MonoBehaviour
{

    Timer timer;
    GameStates gameState;
    int maxScore = 40;                      //Oyuna eklenen 4 düşman için 40 (4*10) olarak hesaplanmıştır.
    int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.FindObjectOfType<Timer>();
        gameState = GameStates.START;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(score == maxScore)                      //Oyuncu max skora ulaştığında (sahnede tek kaldığında) oyun kazanılmış olur
        {
            gameState = GameStates.WIN;
        }

        switch (gameState)
        {
            case GameStates.WIN:
                Debug.Log("YOU WIN!");
                break; 

            case GameStates.LOSE:
                Debug.Log("YOU LOSE.");
                break;
        }
    }

    /* SKOR HESAPLAMALARI */
    public void increaseScore()                    //Skor artış hesabı
    {
               
        if (0 <= score && score < 40)                            
        {
            score = score + 10;
        }
        else
        {
            gameState = GameStates.WIN;
        }
    }
    
    /* GAME OVER */
    public void gameOverByFall()                   //Oyuncunun aşağı düşmesi ile oyunun sonlanması
    {
        gameState = GameStates.LOSE;
    }

    public void gameOverByTimeOut()
    {
        if(timer.startTime == 0)
        {
            gameState = GameStates.LOSE;            // Sürenin bitmesi sonucunda oyun kaybedilecek
        }
    }
}
