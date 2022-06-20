using UnityEngine;


    public class BuffManager : MonoBehaviour
    {
        public float changeSizeTimer;
        public float upSpeedTimer;
        private bool isGetChangeSizeBuff;
        private bool isGetSpeedBuff;
        public float initalSpeed;
        public float currentSpeed;
        public void GearBuff()
        {
            if (isGetChangeSizeBuff)
            {
                if (changeSizeTimer < 10)
                {
                    changeSizeTimer = 0;
                }
            }
        }
        public void GetSpeedBuff()
        {
            if (isGetSpeedBuff)
            {
                if (currentSpeed == initalSpeed)
                {
                    currentSpeed += 1 + 0.3f;
                }
                else
                {
                    currentSpeed += 0.3f;
                }
            }
            else
            {
                if (currentSpeed != initalSpeed + 1 + 0.3f)
                {
                    currentSpeed -= 0.3f;
                }
                else
                {
                    currentSpeed -= (1 + 0.3f);
                }
            }
        }
    }
