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
        public event Action OnTriggerEnter;
        public event Action OnTriggerExit;

        [SerializeField] private TypeOfGamer _typeOfGamer;
        [SerializeField] private Transform _transformOfObject;
        [SerializeField] private SpriteRenderer _spriteRendererOfObject;
        [SerializeField] private Collider2D _colliderOfObject;
        [SerializeField] private Rigidbody2D _rigidbodyOfObject;
        [SerializeField] private int _force;
        [SerializeField] private List<Transform> _wayPointsForEnemy = new List<Transform>();

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
        public List<Transform> WayPoints { get => _wayPointsForEnemy; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(gameObject.GetComponent<LevelObjectView>().TypeOfGamer == TypeOfGamer.Player)
            {
                Debug.Log("Eneter");
                OnTriggerEnter?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(gameObject.GetComponent<LevelObjectView>().TypeOfGamer == TypeOfGamer.Player)
            {
                Debug.Log("Exit");
                OnTriggerExit?.Invoke();
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LAYER_OF_GRASS && _typeOfGamer == TypeOfGamer.Player)
            {
                _transformOfObject.rotation = collision.transform.rotation;
                _isGrounded = false;

            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LAYER_OF_GRASS && _typeOfGamer == TypeOfGamer.Player)
            {
                _isGrounded = true;
            }
            if(collision.gameObject.layer == LAYER_OF_COIN && _typeOfGamer == TypeOfGamer.Player)
            {
                Destroy(collision.gameObject);
            }
            if(collision.gameObject.layer == LAYER_OF_DEATH && _typeOfGamer == TypeOfGamer.Player)
            {
                transform.position = new Vector3(2.46f, 0.84f, 0);
            }
            if (collision.gameObject.layer == LAYER_OF_END && _typeOfGamer == TypeOfGamer.Player)
            {
                Debug.Log("Уровень пройден!");
                transform.position = new Vector3(2.46f, 0.84f, 0);
            }

        }

    }
}

