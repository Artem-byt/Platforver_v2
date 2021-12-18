using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private List<LevelObjectView> _Views;
        [SerializeField] private int _animationSpeed = 30;

        private Controllers _controllers;
        private GamersMap _gamersMap;


        void Start()
        {
            _gamersMap = new GamersMap(_Views);
            _controllers = new Controllers();
            new GameInitialization(_controllers, _animationSpeed, _gamersMap);

        }


        void Update()
        {
            _controllers.Execute();
        }
    }
}

