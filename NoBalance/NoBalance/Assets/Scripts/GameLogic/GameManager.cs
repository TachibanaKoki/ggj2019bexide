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

    private float _Timer = 0.0f;

    private int _Score = 0;
    private int _HighScores = 0;

	private AudioSource m_BGM;
	private bool m_Clear;

    public void Start()
    {
        _inputManager.MissEvent += this.MissPenalty;
        GameOverCollider.GameOverEvent += this.GameOver;
        _orderStack.OnRemoveStack += this.RemoveStack;
        _HighScores = PlayerPrefs.GetInt("HighScore",0);
        _scoreText.text = "SCORE:"+_Score;

		// クリア、ゲームオーバーが行われたかどうかの判定
		m_Clear = false;
		var random = Random.Range(0, 100) % 3 + 1;
		m_BGM = GameObject.Find("BGM" + random).GetComponent<AudioSource>();
		m_BGM.Play();
	}

    public void Update()
    {
        _Timer += Time.deltaTime;
        _playTimeText.text =  Mathf.Max(0, Mathf.Floor(_playTime - _Timer)).ToString();

        if (_playTime <= _Timer)
        {
			GameOver(true);
        }

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
				//SceneManager.LoadScene("Title");
				Fader.FadeOut(2);
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

    public void GameOver(bool clear)
    {

		if(m_Clear)
		{
			return;
		}

		m_Clear = true;
		// tmp
		Time.timeScale = 0.0f;
		if (_gameOverDemoTimer <= 0.0f)
		{

			m_BGM.Stop();
			if (clear)
			{
				_gameOverDemoTimer = 20.0f;
				// 繧ｯ繝ｪ繧｢譎ゅ↓魑ｴ繧峨☆BGM
				m_BGM = GameObject.Find("Success").GetComponent<AudioSource>();
			}
			else
			{
				_gameOverDemoTimer = 35.0f;
				// 繧ｲ繝ｼ繝繧ｪ繝ｼ繝舌�ｼ譎ゅ↓魑ｴ繧峨☆BGM
				m_BGM = GameObject.Find("Fail").GetComponent<AudioSource>();
			}
			m_BGM.Play();

		}
	}

	float _gameOverDemoTimer = 0.0f;
}