using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollected : MonoBehaviour
{
    public GameSession gameSession;
    public enum ItemName { Heart, Gear, Bluebottle, Emptybottle }

    public ItemName orientation;
    void Start()
    {
        gameSession = GameSession.Instance;
    }
    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
    void HeartBuff(Paddle paddle)
    {
        if(gameSession.PlayerLives < 5)
        {
            gameSession.PlayerLives++;
        }
    }
    void GearBuff()
    {

    }
    void BlueBottleBuff()
    {

    }
    void EmptyBottleBuff()
    {

    }
}
