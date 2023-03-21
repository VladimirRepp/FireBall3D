using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    private TowerBuilder _builder;
    private List<Block> _blocks;
    private int _startSizeBloks;

    public event UnityAction<int> SizeChandged;
    public event UnityAction TowerIsDestroyed;

    public int StartSizeBloks => _startSizeBloks;

    private void Awake()
    {
        _builder = GetComponent<TowerBuilder>();
        _blocks = _builder.Build();
        
        foreach(Block block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }

        _startSizeBloks = _blocks.Count;
    }

    private void Start()
    {
        SizeChandged?.Invoke(0);
    }

    private void OnBulletHit(Block heitedBlock)
    {
        heitedBlock.BulletHit -= OnBulletHit;
        _blocks.Remove(heitedBlock);

        foreach (Block block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y / 2, block.transform.position.z);
        }

        SizeChandged?.Invoke(_startSizeBloks - _blocks.Count);

        if (_startSizeBloks - _blocks.Count == _startSizeBloks)
            TowerIsDestroyed?.Invoke();
    }
}
