using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class TimerController : IExecute
    {
        private List<TimerModel> _timers = new List<TimerModel>();

        public void AddTImer(TimerModel timer)
        {
            _timers.Add(timer);
        }

        public void Execute()
        {
            for (int i = 0; i < _timers.Count; i++)
            {
                _timers[i].DoActionOnStartTimer();
                var delta = Time.time - _timers[i].StartOfTimer;
                if(delta > _timers[i].DeltaOfTImer)
                {
                    _timers[i].DoActionOnEndTimer();
                    _timers.Remove(_timers[i]);
                }
            }
        }
    }
}

