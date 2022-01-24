using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Platformer
{
    public enum AnimState
    {
        Idle = 0,
        Run = 1,
        Jump = 2
    }
    [CreateAssetMenu(fileName = "SpriteAnimationConfig", menuName = "Configs/Animation", order = 1)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        [Serializable]
        public sealed class SpriteSequence
        {
            [SerializeField] private AnimState _track;
            [SerializeField] private List<Sprite> _sprites = new List<Sprite>();

            public AnimState Track { get => _track; }
            public List<Sprite> Sprites { get => _sprites; }
        }

        [SerializeField] private List<SpriteSequence> _sequences = new List<SpriteSequence>();

        public List<SpriteSequence> Sequences { get => _sequences; }
    }
}

