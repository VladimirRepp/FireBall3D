using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed;
    [SerializeField] private float _secondToDestroy;
    [SerializeField] private float _bounceForce = 100;
    [SerializeField] private float _bounceRadius = 100;

    private Vector3 _moveDirection;
    private float _passTime;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _moveDirection = Vector3.left;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);

        _passTime += Time.deltaTime;
        if (_passTime >= _secondToDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Block block))
        {
            block.Break();
            Destroy(this.gameObject);
        }

        if(other.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
            obstacle.OnHitInObstacle();
        }
    }

    private void Bounce()
    {
        _moveDirection = Vector3.right + Vector3.up;
        _rigidbody.isKinematic = false;
        _rigidbody.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, -1, 1), _bounceRadius);
    }
}
