using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{

	// タイトルイメージ
	[SerializeField]
	private GameObject _sucess;
	[SerializeField]
	private GameObject _failed;
	[SerializeField]
	private GameObject _resultPanel;
	[SerializeField]
	private Text m_scoreText;
	[SerializeField]
	private Text m_HiscoreText;

	private int m_score;
	private float m_colorTimer;


	// Start Result
	public void StartResult(bool isSuccess, int score, int highScore)
	{
		_resultPanel.SetActive(true);
		m_HiscoreText.text = "HighScore : " + highScore;

		m_score = score;
		m_scoreText.text = "Score : " + m_score;

		_sucess.SetActive(isSuccess);
		_failed.SetActive(!isSuccess);
	}

	void Start()
	{
		_resultPanel.SetActive(false);

		m_score = 0;
	}

	// Update is called once per frame
	void Update()
	{
		textupdate();
	}

	private void textupdate()
	{
		m_colorTimer += Time.deltaTime;

		// タッチチェック
		if (100 <= m_colorTimer && Input.GetKeyDown(KeyCode.Space))
		{
			Fader.FadeOut(0);
		}

	}

}
