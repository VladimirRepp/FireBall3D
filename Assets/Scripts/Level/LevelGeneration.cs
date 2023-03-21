using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelGeneration: MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _indexLevel;
    [SerializeField] private LenelsConfiguration _config;
    [SerializeField] private TMP_Text _myLevelView;
    [SerializeField] private GameUI _gameUI;
    [SerializeField] private Tower _tower;

    [Header("Builders")]
    [SerializeField] private TowerBuilder _towerBuilder;
    [SerializeField] private ObstacleBuilder _obstacleBuilder;

    [Header("Listen to Events")]
    [SerializeField] private Tank _tank;

    public int IndexCurrentLevel;
    public int IndexNextLevel => Mathf.Min(_indexLevel + 1, _config.MaxLevel - 1);
    public int IndexPrevLevel => Mathf.Max(_indexLevel - 1, 0);

    private void Awake()
    {
        _towerBuilder.TowerSize = _config[_indexLevel].SizeTower;

        _obstacleBuilder.DurationAnimation = _config[_indexLevel].DurationAnimationObstacle;
        _obstacleBuilder.IdexPattern = _config[_indexLevel].PatternObstacleIndex;

        _myLevelView.text += System.Convert.ToString(_indexLevel + 1);
    }

    private void OnEnable()
    {
        _tower.TowerIsDestroyed += OnTowerIsDestroyed;
        _tank.LivesOver += OnGameOver;
    }

    private void OnDisable()
    {
        _tower.TowerIsDestroyed -= OnTowerIsDestroyed;
        _tank.LivesOver += OnGameOver;
    }

    private void OnTowerIsDestroyed()
    {
        _gameUI.OpenPanel("Level Complete!");
    }

    private void OnGameOver()
    {
        _gameUI.OpenPanel("Game Over!");
    }
}
