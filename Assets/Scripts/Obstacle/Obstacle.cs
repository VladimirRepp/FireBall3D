using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    public UnityAction<int> HitInObstacle;

    public void OnHitInObstacle()
    {
        HitInObstacle?.Invoke(_damage);
    }
}
