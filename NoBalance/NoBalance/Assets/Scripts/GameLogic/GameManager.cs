using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;
    [SerializeField]
    private StackOrder _orderStack;
    [SerializeField]
    private GameOverCollider _gameOverCollider;

    public void Start()
    {
        _inputManager.MissEvent += this.MissPenalty;
        GameOverCollider.GameOverEvent += this.GameOver;
    }

    public void Update()
    {
        if (0.0f < _gameOverDemoTimer)
        {
            _gameOverDemoTimer -= Time.fixedDeltaTime;
            if (_gameOverDemoTimer <= 0.0f)
            {
                // tmp
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("Title");
            }
        }
    }

    public void MissPenalty(bool isLeft)
    {
        _orderStack.SetPenalty(isLeft);
    }

    public void GameOver()
    {
        // tmp
        Time.timeScale = 0.0f;
        if (_gameOverDemoTimer <= 0.0f)
        {
            _gameOverDemoTimer = 1.0f;
        }
    }

    float _gameOverDemoTimer = 0.0f;
}