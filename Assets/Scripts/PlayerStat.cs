using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;


namespace DefaultNamespace
{
    public class PlayerStat : MonoBehaviour
    {
        public Transform paddle;
        public Ball ball;
        public bool isGearBuff;
        public bool isBottleBuff;
        public float gearBuffTimer;
        public float bottleBuffTimer;
        private int _countBottleBuff;
        private float _originBallSpeed;
        private void Start()
        {
            paddle = FindObjectOfType<Paddle>().gameObject.transform;
            ball = FindObjectOfType<Ball>();
            _originBallSpeed = ball.speed;
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
                if (_countBottleBuff > 0&&bottleBuffTimer<=0)
                {
                    bottleBuffTimer = 5;
                }
                if (_countBottleBuff < 0 && bottleBuffTimer <= 0)
                {
                    ball.speed = _originBallSpeed;
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
            if (ball.speed < 0.1)
            {
                return;
            }
            
            if (!isBottleBuff)
            {
                float downSpeed = 1 - 0.1f;
                ball.speed -= downSpeed;
                bottleBuffTimer = 5;
                _countBottleBuff = 1;
                isBottleBuff = true;
            }
            if (isBottleBuff & bottleBuffTimer > 0)
            {
                _countBottleBuff++;
                float downSpeed = 1 - _countBottleBuff*0.1f;
                ball.speed -= downSpeed;
            }
        }
        public void EmptyBottle()
        {
            bottleBuffTimer = 0;
            _countBottleBuff = 0;
            isBottleBuff = false;
            gearBuffTimer = 0;
            isGearBuff = false;
            paddle.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}