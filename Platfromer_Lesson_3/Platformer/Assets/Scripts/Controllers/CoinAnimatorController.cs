using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CoinAnimatorController : IExecute
    {
        private SpriteAnimatorController _spriteAnimatorController;
        private GamersMap _gamersMap;

        public CoinAnimatorController( GamersMap gamersMap, int animationSpeed, SpriteAnimatorConfig coinConfig)
        {
            _gamersMap = gamersMap;
            _spriteAnimatorController = new SpriteAnimatorController(coinConfig);
            _spriteAnimatorController.StartAnimation(_gamersMap.GetGamerMap[TypeOfGamer.Coin][0].SpriteRendererOfObject, AnimState.Idle, true, animationSpeed);
        }

        public void Execute()
        {
            if (_gamersMap.GetGamerMap[TypeOfGamer.Coin][0] == null)
            {
                _spriteAnimatorController.StopAnimation(_gamersMap.GetGamerMap[TypeOfGamer.Coin][0].SpriteRendererOfObject);
            }
        }

    }
}

