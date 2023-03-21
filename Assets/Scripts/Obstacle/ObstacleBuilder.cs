using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBuilder : MonoBehaviour
{
    [SerializeField] private int _indexPattern;
    [SerializeField] private GameObject[] _patterns;
    [SerializeField] private float _durationAnimation;

    public int IndexPattern
    {
        get
        {
            return _indexPattern;
        }
        set
        {
            _indexPattern = value;
        }
    }

    private ObstacleAtimation _animation;

    public int IdexPattern
    {
        get
        {
            return _indexPattern;
        }
        set
        {
            _indexPattern = value;
        }
    }
    public float DurationAnimation
    {
        get
        {
            return _durationAnimation;
        }
        set
        {
            _durationAnimation = value;
        }
    }

    private void Start()
    {
        _animation = GetComponent<ObstacleAtimation>();
        _animation.AnimDuration = _durationAnimation;

        _patterns[_indexPattern].SetActive(true);
    }
}
    