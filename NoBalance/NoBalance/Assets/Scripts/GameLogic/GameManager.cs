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
    private ResultManager _resultManager;
    [SerializeField]
    Text _scoreText;
    [SerializeField]
    Text _playTimeText;
    [SerializeField]
    private float _playTime = 60.0f;
    [SerializeField]
    Slider _leftSlider;
    [SerializeField]
    Slider _rightSlider;

    private float _Timer = 0.0f;

    private int _Score = 0;
    private int _HighScores = 0;


	private AudioSource m_BGM;
	private bool m_BGMEnd;
	private bool m_Clear;

    private float startTime = 5.0f;
    public static  bool _startWait = true;
    private float startTimer = 0;


    public void Start()
    {
        _inputManager.MissEvent += this.MissPenalty;
        GameOverCollider.GameOverEvent += this.GameOver;
        _orderStack.OnRemoveStack += this.RemoveStack;

        _HighScores = PlayerPrefs.GetInt("HighScore",0);
        _scoreText.text = "SCORE:"+_Score;


		m_Clear = false;
		m_BGMEnd = false;
		var random = Random.Range(0, 100) % 3 + 1;
		m_BGM = GameObject.Find("BGM" + random).GetComponent<AudioSource>();
		m_BGM.Play();

        _startWait = true;

        Time.timeScale = 0.0f;
	}

    public void Update()
    {
        _rightSlider.value = _orderStack._rightOrderTypes.Count;
        _leftSlider.value = _orderStack._leftOrderTypes.Count;
        if (!_startWait)
        {
            _Timer += Time.deltaTime;
            _playTimeText.text = Mathf.Max(0, Mathf.Floor(_playTime - _Timer)).ToString();

            if (_playTime <= _Timer)
            {
                GameOver(true);
            }
        }
        else
        {
            startTimer += Time.unscaledDeltaTime;
            float t = Mathf.Floor(startTime - startTimer);
            if (t > 0)
            {
                _playTimeText.text = t.ToString();
            }
            else
            {
                _playTimeText.text = "START!";
            }

            if (startTimer >= startTime)
            {
                _startWait = false;
                Time.timeScale = 1.0f;
            }

        }

        if (m_BGM.isPlaying)
        {
            _gameOverDemoTimer -= Time.fixedDeltaTime;
        }
        else if (!m_BGM.isPlaying)
        {
            Debug.Log(Time.fixedDeltaTime);
            if (_gameOverDemoTimer <= 0.0f)
            {
                // tmp
                Time.timeScale = 1.0f;
                if (_HighScores < _Score)
                {
                    Debug.Log("NEW RECORED:" + _Score);
                    PlayerPrefs.SetInt("HighScore", _Score);
                }
                Debug.Log("Score:" + _Score);
                if (m_BGMEnd)
                {
                    m_BGMEnd = false;
                    Fader.FadeOut(0);
                }
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
		var missSE = GameObject.Find("Miss").GetComponent<AudioSource>();
		missSE.Play();
    }

    public void GameOver(bool clear)
    {

    //float _gameOverDemoTimer = 0.0f;

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
				_gameOverDemoTimer = 3.0f;
				// クリア時に鳴らすBGM
				m_BGM = GameObject.Find("Success").GetComponent<AudioSource>();
			}
			else
			{
				_gameOverDemoTimer = 5.0f;
				// ゲームオーバー時に鳴らすBGM
				m_BGM = GameObject.Find("Fail").GetComponent<AudioSource>();
			}
			m_BGMEnd = true;
			m_BGM.Play();

            _resultManager.StartResult(m_Clear, _Score, _HighScores);
        }
	}

	float _gameOverDemoTimer = 0.0f;

}