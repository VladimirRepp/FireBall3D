using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textSize;
    [SerializeField] private Tower _tower;

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
        _textSize.text = size.ToString();
    }
}
