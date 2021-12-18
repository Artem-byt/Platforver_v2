using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class GameInitialization
    {
        public GameInitialization(Controllers controllers, int animationSpeed, GamersMap gamersMap)
        {
            var timerController = new TimerController();
            var moveInputController = new MoveInputController();
            var playerConfig = Resources.Load<SpriteAnimatorConfig>("SpriteAnimationConfig");

            var playerAnimator = new SpriteAnimatorController(playerConfig);
            var playerMoveController = new PlayerMoveController(moveInputController, gamersMap.GetGamerMap[TypeOfGamer.Player][0], animationSpeed, playerAnimator, timerController);

            controllers.Add(timerController);
            controllers.Add(new GunFollowForPlayerController(gamersMap));
            controllers.Add(moveInputController);
            controllers.Add(playerAnimator);
        }
    }
}

