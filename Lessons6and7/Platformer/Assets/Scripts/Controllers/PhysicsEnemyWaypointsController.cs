using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace Platformer
{
    public class PhysicsEnemyWaypointsController : IExecute
    {
        private List<LevelObjectView> _physicsEnemies = new List<LevelObjectView>(8);
        private List<AIDestinationSetter> _enemiesDestinations = new List<AIDestinationSetter>(8);
        private List<AIPath> _enemiesAIPath = new List<AIPath>(8);
        private List<int> _currentPointIndexes = new List<int>(8);


        public PhysicsEnemyWaypointsController(GamersMap gamerMap)
        {

        }

        public void Execute()
        {
            
        }
    }
}

