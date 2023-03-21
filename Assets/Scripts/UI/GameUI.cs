using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private LevelGeneration _generation;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _header;

    public void OpenPanel(string header = "")
    {
        _header.text = header;
        _panel.SetActive(true);
    }

    public void ClosePanel()
    {
        _panel.SetActive(false);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("GameScene_" + _generation.IndexNextLevel);
    }

    public void PrevLevel()
    {
        SceneManager.LoadScene("GameScene_" + _generation.IndexPrevLevel);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene_" + _generation.IndexCurrentLevel);
    }
}
