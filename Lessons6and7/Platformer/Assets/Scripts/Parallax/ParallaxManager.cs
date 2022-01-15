using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer 
{
    public class ParallaxManager : IExecute
    {

        private  List<float> _coefficients = new List<float>(8);
        private List<Transform> _backs = new List<Transform>(8);
        private List<Vector3> _backsStartPositions = new List<Vector3>(8);
        private Transform _camera;
        private Vector3 _cameraStartPosition;


        public ParallaxManager(Transform camera, List<ParalaxBackGround> back)
        {
            _camera = camera;
            for(int i = 0; i < back.Count; i++)
            {
                _backs.Add(back[i]._backGround);
                _coefficients.Add(back[i]._coefficientOfParallax);
                _backsStartPositions.Add(_backs[i].position);
            }
            _cameraStartPosition = _camera.transform.position;
        }

        public void Execute()
        {
            for(int i =0; i < _backs.Count; i++)
            {
                _backs[i].position = _backsStartPositions[i] + (_camera.position - _cameraStartPosition) * _coefficients[i];

            }
        }

    }
}


