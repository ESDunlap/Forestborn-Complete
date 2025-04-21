using UnityEngine;
using UnityEngine.UI;

public class EMPSLeft : MonoBehaviour
{
    private GameBehavior _gameManager;
    public Text scoreText;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void Update()
    {
        scoreText.text= "EMPS: " + (_gameManager.EMPs).ToString();
    }
}
