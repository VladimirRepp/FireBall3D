using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Config", menuName = "Config")]
public class LenelsConfiguration : ScriptableObject
{
    [Header("Levels Congigs")]
    [SerializeField] private LevelConfig[] _configs;

    public int MaxLevel => _configs.Length;
    public LevelConfig this [int index] => _configs[index];
}

[System.Serializable]
public struct LevelConfig
{
    public int SizeTower;
    public int PatternObstacleIndex;
    public float DurationAnimationObstacle;
}
