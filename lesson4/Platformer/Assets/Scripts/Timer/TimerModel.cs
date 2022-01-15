using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Platformer
{
    public class TimerModel
    {
        public event Action OnStartTimer;
        public event Action OnStopTimer;

        private float _startOfTimer;
        private float _deltaStopTimer;

        public float StartOfTimer { get => _startOfTimer; }
        public float DeltaOfTImer { get => _deltaStopTimer; }

        public TimerModel(float deltaTime)
        {
            _deltaStopTimer = deltaTime;
            _startOfTimer = Time.time;
        }

        public void DoActionOnStartTimer()
        {
            OnStartTimer?.Invoke();
        }
        public void DoActionOnEndTimer()
        {
            OnStopTimer?.Invoke();
        }
    }
}

