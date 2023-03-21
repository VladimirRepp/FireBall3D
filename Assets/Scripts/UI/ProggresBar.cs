using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProggresBar : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Slider _slayder;
    [SerializeField] private Tower _tower;

    private int _totalSize;

    private void Start()
    {
        _totalSize = _tower.StartSizeBloks;
    }

    private void OnEnable()
    {
        _tower.SizeChandged += OnSizeChandged;
    }

    private void OnDisable()
    {
        _tower.SizeChandged -= OnSizeChandged;
    }

    private void OnSizeChandged(int size)
    {
        _slayder.DOValue((float)(size) / _totalSize, _duration);
    }
}
