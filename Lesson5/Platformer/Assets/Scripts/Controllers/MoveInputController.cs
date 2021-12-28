using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Platformer
{
    public class MoveInputController : IExecute
    {
        public event Action<bool> MoveRight;
        public event Action<bool> MoveLeft;
        public event Action<bool> Jump;
        public event Action<bool> Idle;

        public void Execute()
        {
            GetMoveInput();
        }

        public void GetMoveInput()
        {
            var isIdle = Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.Space);
            MoveRight?.Invoke(Input.GetKey(KeyCode.D));
            MoveLeft?.Invoke(Input.GetKey(KeyCode.A));
            Jump?.Invoke(Input.GetKeyDown(KeyCode.Space));
            Idle?.Invoke(isIdle);
        }
    }
}

