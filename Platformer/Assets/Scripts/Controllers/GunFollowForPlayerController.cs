using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class GunFollowForPlayerController : IExecute
    {
        private List<LevelObjectView> _guns;
        private LevelObjectView _player;

        public GunFollowForPlayerController(GamersMap gamersMap)
        {
            _guns = gamersMap.GetGamerMap[TypeOfGamer.Gun];
            _player = gamersMap.GetGamerMap[TypeOfGamer.Player][0];
        }

        public void Execute()
        {
            foreach(var gun in _guns)
            {
                var dir = _player.TransformOfObject.position - gun.TransformOfObject.position;
                var angle = Vector3.Angle(Vector3.down, dir);
                var axis = Vector3.Cross(Vector3.down, dir);

                if(dir.x < 0)
                {
                    gun.TransformOfObject.localScale = new Vector3(-1, 1, 1);
                }
                if (dir.x > 0)
                {
                    gun.TransformOfObject.localScale = new Vector3(1, 1, 1);
                }
                gun.TransformOfObject.rotation = Quaternion.AngleAxis(angle - 90, axis);
            }
            
        }
    }
}

