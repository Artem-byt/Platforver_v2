using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{

    public class GamersMap
    {
        private Dictionary<TypeOfGamer, List<LevelObjectView>> _gamerMap = new Dictionary<TypeOfGamer, List<LevelObjectView>>();

        public Dictionary<TypeOfGamer, List<LevelObjectView>> GetGamerMap { get { return _gamerMap; } }
        public GamersMap(List<LevelObjectView> gamers)
        {
            var players = new List<LevelObjectView>();
            var guns = new List<LevelObjectView>();
            var enemies = new List<LevelObjectView>();
            var coins = new List<LevelObjectView>();
            var physicsEnemy = new List<LevelObjectView>();

            foreach(var gamer in gamers)
            {
                if(gamer.TypeOfGamer == TypeOfGamer.Player)
                {
                    players.Add(gamer);
                }
                if (gamer.TypeOfGamer == TypeOfGamer.Gun)
                {
                    guns.Add(gamer);
                }
                if (gamer.TypeOfGamer == TypeOfGamer.FlyingEnemy)
                {
                    enemies.Add(gamer);
                }
                if (gamer.TypeOfGamer == TypeOfGamer.Coin)
                {
                    coins.Add(gamer);
                }
                if (gamer.TypeOfGamer == TypeOfGamer.PhysicsEnemy)
                {
                    physicsEnemy.Add(gamer);
                }
            }
            _gamerMap[TypeOfGamer.Player] = players;
            _gamerMap[TypeOfGamer.Gun] = guns;
            _gamerMap[TypeOfGamer.FlyingEnemy] = enemies;
            _gamerMap[TypeOfGamer.Coin] = coins;
            _gamerMap[TypeOfGamer.PhysicsEnemy] = physicsEnemy;
        }

    }
}

