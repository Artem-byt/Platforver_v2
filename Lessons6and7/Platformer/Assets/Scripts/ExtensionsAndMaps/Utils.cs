using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public static class Utils
    {
        public static Vector2 Change(this Vector2 org, object x = null, object y = null)
        {
            return new Vector2(x == null ? org.x : (float)x, y == null ? org.y : (float)y);
        }
    }
}

