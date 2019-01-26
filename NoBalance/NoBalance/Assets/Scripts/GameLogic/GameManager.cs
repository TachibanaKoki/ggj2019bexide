using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;
    [SerializeField]
    private StackOrder _orderStack;
    [SerializeField]
    Text _scoreText;
    [SerializeField]
    Text _playTimeText;
    [SerializeField]
    private float _playTime = 60.0f; 

    private int _Score = 0;
    private int _HighScores = 0;

    public void Start()
    {
        _inputManager.MissEvent += this.MissPenalty;
        GameOverCollider.GameOverEvent += this.GameOver;
        _orderStack.OnRemoveStack += this.RemoveStack;
        _HighScores = PlayerPrefs.GetInt("HighScore",0);
        _scoreText.text = "SCORE:"+_Score;
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
                if(_HighScores<_Score)
                {
                    Debug.Log("NEW RECORED:"+_Score);
                    PlayerPrefs.SetInt("HighScore",_Score);
                }
                Debug.Log("Score:" + _Score);
                SceneManager.LoadScene("Title");
            }
        }
    }

    public void RemoveStack(bool isLeft)
    {
        _Score++;
        _scoreText.text = "SCORE:" + _Score;
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