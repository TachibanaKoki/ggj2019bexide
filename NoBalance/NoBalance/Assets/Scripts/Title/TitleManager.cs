using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{

	// タイトルイメージ
	private Image m_titleImage;
	private Text m_touchText;

	private float m_colorTimer;
	
    // Start is called before the first frame update
    void Start()
    {
		m_titleImage = transform.Find("Image").GetComponent<Image>();
		m_touchText = transform.Find("Text").GetComponent<Text>();
		m_colorTimer = 0;

		// プラットフォームに合わせてケースわけ？（できるのであれば
		m_touchText.text = "Tap to Start";
    }

    // Update is called once per frame
    void Update()
    {
		textupdate();
    }

	private void textupdate()
	{
		m_colorTimer += Time.deltaTime;

		if(m_colorTimer < 1.5)
		{
			m_touchText.gameObject.SetActive(true);
		}
		else if(m_colorTimer < 2)
		{
			m_touchText.gameObject.SetActive(false);
			
		}

		if (m_colorTimer > 3)
		{
			m_colorTimer = 0;
		}

		// タッチチェック
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Fader.FadeOut(1);
		}
	}

}
