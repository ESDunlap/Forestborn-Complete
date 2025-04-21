using UnityEngine;
using UnityEngine.UI;

public class TowersLeft : MonoBehaviour
{
    private GameBehavior _gameManager;
    public Text scoreText;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void Update()
    {
        scoreText.text= "Towers Left: " + (_gameManager.maxTowers - _gameManager.Towers).ToString();
    }
}
