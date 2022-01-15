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

        private bool _isStickLeft;
        private bool _isStickRight;

        private Vector3 _rotatePlayer = new Vector3(0, 0, 1f);
        private Vector3 _localScaleLeft = new Vector3(-1, 1, 1);
        private Vector3 _localScaleRight = new Vector3(1, 1, 1);

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

            _levelObjectView.OnTouchWallsLeft += StayOnWallsRight;
            _levelObjectView.OnTouchWallsRight += StayOnWallsLeft; 
            _levelObjectView.OnTouchEnd += OutOfCollision;

        }

        public void OutOfCollision()
        {
            _isStickLeft = false;
            _isStickRight = false;
        }

        public void StayOnWallsLeft()
        {
            _levelObjectView.Rigidbody2DOfObject.constraints = RigidbodyConstraints2D.FreezePosition;
            _isStickLeft = true;
        }
        public void StayOnWallsRight()
        {
            _levelObjectView.Rigidbody2DOfObject.constraints = RigidbodyConstraints2D.FreezePosition;
            _isStickRight = true;
        }


        public void PlayerIdle(bool isIdle)
        {
            if (isIdle)
            {
                _playerAnimator.StartAnimation(_levelObjectView.SpriteRendererOfObject, AnimState.Idle, true, _animationSpeed);
                _levelObjectView.Rigidbody2DOfObject.velocity = _levelObjectView.Rigidbody2DOfObject.velocity.Change(x: 0f);

            }
        }

        private void MovePlayerRight(bool goingRight)
        {
            
            if (goingRight && !_isStickRight)
            {
                DefaultConstraints();

                var transform = _levelObjectView.TransformOfObject.localScale = _localScaleRight;
                _levelObjectView.Rigidbody2DOfObject.velocity = _levelObjectView.Rigidbody2DOfObject.velocity.Change(x: 1f * _levelObjectView.Force) ;
                _playerAnimator.StartAnimation(_levelObjectView.SpriteRendererOfObject, AnimState.Run, true, _animationSpeed);
            }
        }

        private void MovePlayerLeft(bool goingLeft)
        {

            if (goingLeft && !_isStickLeft)
            {
                DefaultConstraints();

                _levelObjectView.TransformOfObject.gameObject.transform.localScale = _localScaleLeft;
                _levelObjectView.Rigidbody2DOfObject.velocity = _levelObjectView.Rigidbody2DOfObject.velocity.Change(x: -1f *_levelObjectView.Force) ;
                _playerAnimator.StartAnimation(_levelObjectView.SpriteRendererOfObject, AnimState.Run, true, _animationSpeed);
            }
        }


        private void MovePlayerJump(bool isJump)
        {

            if (isJump && _levelObjectView.IsGrounded)
            {
                DefaultConstraints();

                _levelObjectView.Rigidbody2DOfObject.AddForce(Vector3.up * _levelObjectView.Force, ForceMode2D.Impulse);
                _playerAnimator.StartAnimation(_levelObjectView.SpriteRendererOfObject, AnimState.Jump, true, _animationSpeed);

                var timer = new TimerModel(2f);
                timer.OnStartTimer += DoBarrelRoll;
                _timerController.AddTImer(timer);
            }
        }

        public void DefaultConstraints()
        {
            _levelObjectView.Rigidbody2DOfObject.constraints = RigidbodyConstraints2D.None;
            _levelObjectView.Rigidbody2DOfObject.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public void DoBarrelRoll()
        {
            _levelObjectView.TransformOfObject.Rotate(_rotatePlayer);
        }
    }
}

