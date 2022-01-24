using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class QuestCoinsController
    {
        private LevelObjectView _player;
        private int _coinCount;
        private int _currentPickedCoins;

        public QuestCoinsController(GamersMap player)
        {
            _player = player.GetGamerMap[TypeOfGamer.Player][0];
            _coinCount = player.GetGamerMap[TypeOfGamer.Coin].Count;
            _currentPickedCoins = 0;
            _player.OnPickedCoin += OnPickedCoin;
            _player.OnEndLevel += OnTouchEnd;
        }


        public void OnPickedCoin(GameObject coin)
        {
            _currentPickedCoins++;
            GameObject.Destroy(coin);
            Debug.Log($"Собрано {_currentPickedCoins} из {_coinCount} монеток");
        }

        public void OnTouchEnd()
        {
            if(_currentPickedCoins == _coinCount)
            {
                Debug.Log("Уровень пройден!");
                _player.TransformOfObject.position = new Vector3(2.46f, 0.84f, 0);
            }
            else
            {
                Debug.Log("Вы собрали не все монетки");
            }
        }
    }
}

