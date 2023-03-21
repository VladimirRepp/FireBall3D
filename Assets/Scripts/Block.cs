using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroingEffect;
    public event UnityAction<Block> BulletHit;

    private MeshRenderer _meshRendere;

    private void Awake()
    {
        _meshRendere = GetComponent<MeshRenderer>();
    }

    public void SetColor(Color color)
    {
        _meshRendere.material.color = color;
    }

    public void Break()
    {
        BulletHit?.Invoke(this);
        Destroy(gameObject);
    }
}
