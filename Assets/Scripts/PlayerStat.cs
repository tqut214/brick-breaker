using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;


namespace DefaultNamespace
{
    public class PlayerStat : MonoBehaviour
    {
        public Transform paddle;
        public bool isGearBuff;
        public bool isBottleBuff;
        public Ball ball;
        public float gearBuffTimer;
        public float bottleBuffTimer;
        private int countBottleBuff;
        private Vector2 originBallSpeed;
        private void Start()
        {
            paddle = FindObjectOfType<Paddle>().gameObject.transform;
            ball = FindObjectOfType<Ball>();
            originBallSpeed = ball.InitialBallSpeed;
            
        }

        private void Update()
        {
           
            if (isGearBuff)
            {
                gearBuffTimer -= Time.deltaTime;
                if (gearBuffTimer <= 0)
                {
                    paddle.transform.localScale = new Vector3(1, 1, 1);
                    isGearBuff = false;
                }
            }
            if (isBottleBuff)
            {
                bottleBuffTimer -= Time.deltaTime;
                if (countBottleBuff > 0&&bottleBuffTimer<=0)
                {
                    bottleBuffTimer = 5;
                }

                if (countBottleBuff < 0 && bottleBuffTimer <= 0)
                {
                    ball.InitialBallSpeed = originBallSpeed;
                }
            }
        }

        public void GearBuff()
        {
            if (!isGearBuff)
            {
                paddle.transform.localScale += new Vector3(1, 0, 0);
                gearBuffTimer = 10;
                isGearBuff = true;
            }

            if (isGearBuff&&gearBuffTimer >0)
            {
                gearBuffTimer = 10;
            }
        }
        public void BlueBottleBuff()
        {
            
            if (!isBottleBuff)
            {
                float tempSpeed = 1 - 0.1f;
                ball.InitialBallSpeed = new Vector2(2,10)*tempSpeed;
                bottleBuffTimer = 5;
                countBottleBuff = 1;
                isBottleBuff = true;
            }

            if (isBottleBuff & bottleBuffTimer > 0)
            {
                countBottleBuff++;
                float tempSpeed = 1 - countBottleBuff*0.1f;
                ball.InitialBallSpeed = new Vector2(2,10)*tempSpeed;
            }
        }
        public void EmptyBottle()
        {
            bottleBuffTimer = 0;
            countBottleBuff = 0;
            isBottleBuff = false;
            gearBuffTimer = 0;
            isGearBuff = false;
            paddle.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}