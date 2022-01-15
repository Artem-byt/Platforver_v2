using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace Platformer
{
    public class EnemyWayPointsController : IExecute
    {
        private List<LevelObjectView> _enemies = new List<LevelObjectView>(8);
        private List<AIDestinationSetter> _enemiesDestinations = new List<AIDestinationSetter>(8);
        private List<AIPath> _enemiesAIPath = new List<AIPath>(8);
        private List<int> _currentPointIndexes = new List<int>(8);
        private List<bool> _isFollowThePlayer = new List<bool>(8);
        private List<bool> _jumpPhysicsEnemies = new List<bool>(8);

        public EnemyWayPointsController(GamersMap gamerMap)
        {
            Initialize(TypeOfGamer.FlyingEnemy, gamerMap);
            Initialize(TypeOfGamer.PhysicsEnemy, gamerMap);

            for (int i = 0; i < _enemiesDestinations.Count; i++)
            {
                _enemiesDestinations[i].target = _enemies[i].WayPoints[0];
            }

            for (int i = 0; i < _enemies.Count; i++)
            {
                var index = i;
                gamerMap.GetGamerMap[TypeOfGamer.Player][0].OnTriggerEnter += delegate ()
                {
                    _isFollowThePlayer[index] = true;
                    _enemiesDestinations[index].target = gamerMap.GetGamerMap[TypeOfGamer.Player][0].TransformOfObject;

                };

                gamerMap.GetGamerMap[TypeOfGamer.Player][0].OnTriggerExit += delegate ()
                {
                    _isFollowThePlayer[index] = false;
                    _enemiesDestinations[index].target = _enemies[index].WayPoints[0];

                };
            }
        }

        public void Initialize(TypeOfGamer typeOfGamer, GamersMap gamerMap)
        {
            for (int i = 0; i < gamerMap.GetGamerMap[typeOfGamer].Count; i++)
            {
                _enemies.Add(gamerMap.GetGamerMap[typeOfGamer][i]);
                _isFollowThePlayer.Add(false);
                _enemiesDestinations.Add(gamerMap.GetGamerMap[typeOfGamer][i].GetComponent<AIDestinationSetter>());
                _enemiesAIPath.Add(gamerMap.GetGamerMap[typeOfGamer][i].GetComponent<AIPath>());
                _currentPointIndexes.Add(0);
                _jumpPhysicsEnemies.Add(false);

            }
        }



        public void Execute()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                var distance = Vector3.Distance(_enemies[i].TransformOfObject.position, _enemiesDestinations[i].target.transform.position);
                if (distance <= _enemiesAIPath[i].endReachedDistance && _isFollowThePlayer[i] == false)
                {
                    _currentPointIndexes[i] = (_currentPointIndexes[i] + 1) % _enemies[i].WayPoints.Count;
                    _enemiesDestinations[i].target = (_enemies[i].WayPoints[_currentPointIndexes[i]]);
                }

                if (_enemies[i].TypeOfGamer == TypeOfGamer.PhysicsEnemy)
                {
                    
                    var raycastdown = Physics2D.Raycast(_enemies[i].TransformOfObject.position, -_enemies[i].TransformOfObject.up, 1f, _enemies[i].LayerMask);
                    if (!raycastdown && _jumpPhysicsEnemies[i])
                    {
                        _enemies[i].Rigidbody2DOfObject.AddForce(_enemies[i].TransformOfObject.up * _enemies[i].Force);
                        _jumpPhysicsEnemies[i] = false;
                    }
                    if(raycastdown && !_jumpPhysicsEnemies[i])
                    {
                        _jumpPhysicsEnemies[i] = true;
                    }
                   
                }
            }
        }
    }
}

