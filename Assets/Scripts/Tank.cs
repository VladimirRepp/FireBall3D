using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class Tank : MonoBehaviour
{
    [Header("Settings for Health")]
    [SerializeField] private int _health = 3;
    [SerializeField] private Obstacle[] _obstacles;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _durationAnimHealthBar;

    [Header("Settings")]
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _delayBetweenShoot;
    [SerializeField] private float _recoilDisance;

    private float _timeAfterShoot;
    private int _totalHealth;

    public UnityAction LivesOver;

    private void Start()
    {
        _totalHealth = _health;
        _healthBar.value = 1;
    }

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if(_timeAfterShoot > _delayBetweenShoot)
            {
                // Для пуль нужен ПУЛ
                Shoot();
                transform.DOMoveX(transform.position.x + _recoilDisance, _delayBetweenShoot / 2).SetLoops(2, LoopType.Yoyo);
                _timeAfterShoot = 0;
            }
        }
    }

    private void OnEnable()
    {
        foreach(Obstacle o in _obstacles)
        {
            o.HitInObstacle += OnHitInObstacle;
        }
    }

    private void OnDisable()
    {
        foreach (Obstacle o in _obstacles)
        {
            o.HitInObstacle -= OnHitInObstacle;
        }
    }

    private void OnHitInObstacle(int damage)
    {
        _health -= damage;
        _healthBar.DOValue((float)(_health) / _totalHealth, _durationAnimHealthBar);

        if (_health == 0)
        {
            LivesOver?.Invoke();
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
    }
}
