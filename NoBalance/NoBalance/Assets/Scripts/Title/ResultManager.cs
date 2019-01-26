using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{

	// タイトルイメージ
	private Image m_titleImage;
	private Text m_scoreText;
	private Text m_HiscoreText;

	private int m_score;
	private float m_colorTimer;



	// Start is called before the first frame update
	void Start()
	{
		m_titleImage = transform.Find("Image").GetComponent<Image>();
		m_scoreText = transform.Find("Score").GetComponent<Text>();
		m_HiscoreText = transform.Find("HiScore").GetComponent<Text>();

		m_score = 0;

		Fader.FadeIn();

		
	}

	// Update is called once per frame
	void Update()
	{
		textupdate();
	}

	private void textupdate()
	{
		m_colorTimer += Time.deltaTime;

		if(m_score != 100)
		{
			m_score++;
		}

		m_scoreText.text = "Score:" + m_score;

		// タッチチェック
		if (m_score == 100 && Input.GetKeyDown(KeyCode.Space))
		{
			Fader.FadeOut(0);
		}

	}

}
