using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    public string labelText = "Destroy all 4 towers and free nature!";
    public int maxTowers = 4;
    public GameObject completeLevelUI;
    private int _towersDestroyed = 0;
    private int currentEMPs = 0;
    public int Towers
    {
        get { return _towersDestroyed;}
        set
        {
            _towersDestroyed = value;
        }
    }
    public int EMPs
    {
        get { return currentEMPs; }
        set
        {
            currentEMPs = value;
        }
    }
    private int _playerHP = 3;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
            if (_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
            }
            else
            {
                labelText = "Ouch... that's got hurt.";
            }
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;
    }
    void Update()
    {
        if (_towersDestroyed >= maxTowers)
        {
            showWinScreen = true;
        }
    }

    void OnGUI()
    {
        if (showWinScreen)
        {
            completeLevelUI.SetActive(true);
        }
        else if (showLossScreen)
        {
            Time.timeScale = 0;
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
              Screen.height / 2 - 50, 200, 100), "You lose..."))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
