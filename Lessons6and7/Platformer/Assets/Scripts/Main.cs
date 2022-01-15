using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Platformer
{
    [Serializable]
    public struct ParalaxBackGround
    {
        public Transform _backGround;
        public float _coefficientOfParallax;
    }


    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private List<LevelObjectView> _Views;
        [SerializeField] private int _animationSpeed = 30;
        [SerializeField] private List<ParalaxBackGround> _backGround;
        [SerializeField] private GenerateLevelView _generateLevelView;

        private Controllers _controllers;
        private GamersMap _gamersMap;


        void Start()
        {
            _gamersMap = new GamersMap(_Views);
            _controllers = new Controllers();
            new GameInitialization(_controllers, _animationSpeed, _gamersMap, _backGround, _generateLevelView);

        }


        void Update()
        {
            _controllers.Execute();
        }
    }
}

