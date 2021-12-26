using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Platformer
{
    [Serializable]
    public enum TypeOfGamer
    {
        Player = 0,
        Gun = 1,
        Enemy = 2,
        Coin = 3
    }
    public class LevelObjectView : MonoBehaviour
    {

        [SerializeField] private TypeOfGamer _typeOfGamer;
        [SerializeField] private Transform _transformOfObject;
        [SerializeField] private SpriteRenderer _spriteRendererOfObject;
        [SerializeField] private Collider2D _colliderOfObject;
        [SerializeField] private Rigidbody2D _rigidbodyOfObject;
        [SerializeField] private int _force;

        private bool _isGrounded = true;
        private const int LAYER_OF_GRASS = 6;
        private const int LAYER_OF_COIN = 7;
        private const int LAYER_OF_DEATH = 8;
        private const int LAYER_OF_END = 9;

        public TypeOfGamer TypeOfGamer { get => _typeOfGamer; }
        public Transform TransformOfObject { get => _transformOfObject; }
        public SpriteRenderer SpriteRendererOfObject { get => _spriteRendererOfObject; }
        public Collider2D ColliderOfObject { get => _colliderOfObject; }
        public Rigidbody2D Rigidbody2DOfObject { get => _rigidbodyOfObject; }
        public int Force { get => _force; }
        public bool IsGrounded { get => _isGrounded; }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LAYER_OF_GRASS)
            {
                _transformOfObject.rotation = collision.transform.rotation;
                _isGrounded = false;

            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LAYER_OF_GRASS)
            {
                _isGrounded = true;
            }
            if(collision.gameObject.layer == LAYER_OF_COIN)
            {
                Destroy(collision.gameObject);
            }
            if(collision.gameObject.layer == LAYER_OF_DEATH)
            {
                transform.position = new Vector3(2.46f, 0.84f, 0);
            }
            if (collision.gameObject.layer == LAYER_OF_END)
            {
                Debug.Log("Уровень пройден!");
                transform.position = new Vector3(2.46f, 0.84f, 0);
            }

        }

    }
}

