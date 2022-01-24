using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer
{
    public class PlayerMoveController
    {
        private LevelObjectView _levelObjectView;
        private int _animationSpeed;
        private SpriteAnimatorController _playerAnimator;
        private TimerController _timerController;

        public PlayerMoveController(MoveInputController moveInputController, LevelObjectView levelObjectView, int animationSpeed, SpriteAnimatorController spriteAnimatorController, TimerController timerController)
        {
            _timerController = timerController;
            _playerAnimator = spriteAnimatorController;
            _animationSpeed = animationSpeed;
            _levelObjectView = levelObjectView;
            moveInputController.MoveRight += MovePlayerRight;
            moveInputController.Idle += PlayerIdle;
            moveInputController.Jump += MovePlayerJump;
            moveInputController.MoveLeft += MovePlayerLeft;
        }

        public void PlayerIdle(bool isIdle)
        {
            if (isIdle)
            {
                _playerAnimator.StartAnimation(_levelObjectView.SpriteRendererOfObject, AnimState.Idle, true, _animationSpeed);
            }
        }

        private void MovePlayerRight(bool goingRight)
        {
            
            if (goingRight && _levelObjectView.IsGrounded)
            {
                var transform = _levelObjectView.TransformOfObject.localScale = new Vector3(1, 1, 1);
                _levelObjectView.Rigidbody2DOfObject.velocity = Vector2.right * _levelObjectView.Force;
                _playerAnimator.StartAnimation(_levelObjectView.SpriteRendererOfObject, AnimState.Run, true, _animationSpeed);
            }
        }

        private void MovePlayerLeft(bool goingLeft)
        {

            if (goingLeft && _levelObjectView.IsGrounded)
            {
                _levelObjectView.TransformOfObject.gameObject.transform.localScale = new Vector3(-1, 1, 1);
                _levelObjectView.Rigidbody2DOfObject.velocity = Vector2.left * _levelObjectView.Force;
                _playerAnimator.StartAnimation(_levelObjectView.SpriteRendererOfObject, AnimState.Run, true, _animationSpeed);
            }
        }


        private void MovePlayerJump(bool isJump)
        {

            if (isJump && _levelObjectView.IsGrounded)
            {
                _levelObjectView.Rigidbody2DOfObject.AddForce(Vector3.up * _levelObjectView.Force, ForceMode2D.Impulse);
                _playerAnimator.StartAnimation(_levelObjectView.SpriteRendererOfObject, AnimState.Jump, true, _animationSpeed);

                var timer = new TimerModel(2f);
                timer.OnStartTimer += DoBarrelRoll;
                _timerController.AddTImer(timer);
            }
        }

        public void DoBarrelRoll()
        {
            _levelObjectView.TransformOfObject.Rotate(new Vector3(0, 0, 1f));
        }
    }
}

