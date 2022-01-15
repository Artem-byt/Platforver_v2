using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CameraController : IExecute
    {
        private Camera _camera;
        private LevelObjectView _player;

        private const float SPEED = 1000f;

        public CameraController(GamersMap player)
        {
            _camera = Camera.main;
            _player = player.GetGamerMap[TypeOfGamer.Player][0];
        }
        public void Execute()
        {
            var positionPlayer = _player.TransformOfObject.position;
            positionPlayer.z = -10;
            var cameraPosition = _camera.transform.position;
            cameraPosition.z = -10;

            _camera.transform.position = Vector3.Lerp(cameraPosition, positionPlayer, SPEED * Time.deltaTime);
        }
    }
}

