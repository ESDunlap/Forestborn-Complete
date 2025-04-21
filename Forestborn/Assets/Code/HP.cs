using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    private GameBehavior _gameManager;
    public Text scoreText;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void Update()
    {
        scoreText.text= "HP: " + _gameManager.HP.ToString();
    }
}
