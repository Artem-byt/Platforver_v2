using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class GameInitialization
    {
        public GameInitialization(Controllers controllers, int animationSpeed, GamersMap gamersMap, List<ParalaxBackGround> backGround, GenerateLevelView generateLevelView)
        {
            new QuestCoinsController(gamersMap);
            new GeneratorLevelController(generateLevelView).Initialize();
            var timerController = new TimerController();
            var moveInputController = new MoveInputController();
            var playerConfig = Resources.Load<SpriteAnimatorConfig>("SpriteAnimationConfig");
            var coinConfig = Resources.Load<SpriteAnimatorConfig>("CoinAnimation");

            var playerAnimator = new SpriteAnimatorController(playerConfig);

            new PlayerMoveController(moveInputController, gamersMap.GetGamerMap[TypeOfGamer.Player][0], animationSpeed, playerAnimator, timerController);

            controllers.Add(timerController);
            controllers.Add(new GunFollowForPlayerController(gamersMap));
            controllers.Add(moveInputController);
            controllers.Add(playerAnimator);
            controllers.Add(new CoinAnimatorController(gamersMap, animationSpeed, coinConfig));
            controllers.Add(new CameraController(gamersMap));
            controllers.Add(new EnemyWayPointsController(gamersMap));
            controllers.Add(new ParallaxManager(Camera.main.transform, backGround));
        }
    }
}

