using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Platformer
{
    public class SpriteAnimatorController : IDisposable, IExecute
    {
        private sealed class Animation
        {
            public AnimState Track;
            public List<Sprite> Sprites;
            public bool Loop;
            public float Speed = 10f;
            public float Counter = 0f;
            public bool Sleep;

            public void Update()
            {
                if (Sleep) return;

                Counter += Time.deltaTime * Speed;

                if (Loop)
                {
                    while (Counter > Sprites.Count)
                    {
                        Counter -= Sprites.Count;
                    }

                }
                else if (Counter > Sprites.Count)
                {
                    Counter = Sprites.Count;
                    Sleep = true;
                }
            }
        }

        private SpriteAnimatorConfig _config;
        private Dictionary<SpriteRenderer, Animation> _activeAnimation = new Dictionary<SpriteRenderer, Animation>();

        public SpriteAnimatorController(SpriteAnimatorConfig config)
        {
            _config = config;
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, AnimState track, bool loop, float speed)
        {
            if (_activeAnimation.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = speed;
                animation.Sleep = false;
                if (animation.Track != track)
                {
                    animation.Track = track;
                    animation.Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites;
                    animation.Counter = 0f;
                }
            }
            else
            {
                _activeAnimation.Add(spriteRenderer, new Animation()
                {
                    Track = track,
                    Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites,
                    Loop = loop,
                    Speed = speed
                });
            }
        }

        public void StopAnimation(SpriteRenderer sprite)
        {
            if (_activeAnimation.ContainsKey(sprite))
            {
                _activeAnimation.Remove(sprite);
            }
        }
        public void Execute()
        {
            Update();
        }
        public void Update()
        {
            foreach(var animation in _activeAnimation)
            {
                animation.Value.Update();
                if(animation.Value.Counter < animation.Value.Sprites.Count)
                {
                    animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
                }
            }
        }

        public void Dispose()
        {
            _activeAnimation.Clear();
        }
    }
}

