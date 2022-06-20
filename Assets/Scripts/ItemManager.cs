using System;
using DefaultNamespace;
using UnityEngine;

public enum TypeOfBuff
{
    Gear,
    BlueBottle,
    EmptyBottle,
    Heart
}
public class ItemManager : MonoBehaviour
{
    public TypeOfBuff typeOfBuff;
    private PlayerStat _playerStat;

    private void OnEnable()
    {
        _playerStat = FindObjectOfType<PlayerStat>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GetBuff();
            Destroy(this.gameObject,0.1f);
        }
    }
    public void GetBuff()
    {
        switch (typeOfBuff)   
        {
            case TypeOfBuff.Gear:
                GearBuff();
                break;
            case TypeOfBuff.Heart:
                HeartBuff();
                break;
            case TypeOfBuff.BlueBottle:
                BlueBottleBuff();
                break;
            case TypeOfBuff.EmptyBottle:
                EmptyBottleBuff();
                break;
            default:
                break;
        }
    }

    void GearBuff()
    {
        _playerStat.GearBuff();
    }

    void HeartBuff()
    {
        
        var gameSession = GameSession.Instance;
        // checks for over lives
        if (gameSession.PlayerLives >= 5)
        {
            return;
        }
        gameSession.PlayerLives++;
    }

    void BlueBottleBuff()
    {
        _playerStat.BlueBottleBuff();
    }

    void EmptyBottleBuff()
    {
        _playerStat.EmptyBottle();
    }
    
}
