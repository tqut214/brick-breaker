using UnityEngine;
using UnityEngine.Events;

    public class TimerManager : MonoBehaviour
    {
        public float duration = 1f;
        
        public UnityEvent myEvent;

        public void SetDuration(float d)
        {
            this.duration = d;
        }
        private void Update()
        {
            duration -= Time.deltaTime;
            if (duration < 0)
            {
                duration = 0;
            }
            OnTimeTick();
            EndTimeTick();
        }
        private void OnTimeTick()
        {
            
            if (duration < 0)
            {
                return;
            }
            myEvent.Invoke();
        }

        private void EndTimeTick()
        {
            if (duration == 0)
            {
                
            }
        }
    }
