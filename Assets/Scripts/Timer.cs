using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public TimerData timerData;

	GameObject timerChild;

	TMP_Text timerStart;
	TMP_Text timerEnd;
	TMP_Text countDown;
	TMP_Text timerName;

	[SerializeField] int hour, min, sec;
	[SerializeField] Sprite playSprite, stopSprite;

	DateTime dateTimeStart, dateTimeEnd;
	TimeSpan timeDiff;

	float rest;
	bool running;

	void Awake()
	{
		timerChild = transform.Find("TimerClock").gameObject;

		timerStart = timerChild.transform.Find("TimerStart").GetComponent<TMP_Text>();
		timerEnd = timerChild.transform.Find("TimerEnd").GetComponent<TMP_Text>();
		countDown = timerChild.transform.Find("CountDown").GetComponent<TMP_Text>();
		timerName = transform.Find("TimerName").GetComponent<TMP_Text>();
	}

	void Start()
	{
		//timerData =	new TimerData();
	}

	public void SetTimer(string start, string end, string name)
	{
		timerData.id = Guid.NewGuid().ToString();
		timerData.timerName = name;
		timerData.start = start;
		timerData.end = end;

		timerStart.text = start;
		timerEnd.text = end;
		timerName.text = name;

		string timeStartF = timerStart.text + ":00";
		string timeEndF = timerEnd.text + ":00";

		dateTimeStart = DateTime.ParseExact(timeStartF, "HH:mm:ss",
													 CultureInfo.InvariantCulture);
		dateTimeEnd = DateTime.ParseExact(timeEndF, "HH:mm:ss",
													 CultureInfo.InvariantCulture);

		timeDiff = dateTimeEnd - dateTimeStart;

		hour = timeDiff.Hours;
		min = timeDiff.Minutes;
		sec = timeDiff.Seconds;

		rest = hour * 60 * 60 + min * 60 + sec;
		//rest = 0;

		if (rest > 0)
		{
			transform.Find("PlayBtn").gameObject.GetComponent<Button>().interactable = true;
			UpdateCountDownText();
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (running)
		{
			//TimeSpan timerTex = TimeSpan.FromSeconds((double)(new decimal(rest)));

			rest -= Time.deltaTime;

			if (rest < 1)
			{
				// stop
				running = false;
			}

			UpdateCountDownText();
		}
	}

	void UpdateCountDownText()
	{
		TimeSpan timerTex = TimeSpan.FromSeconds((double)(new decimal(rest)));
		countDown.text = string.Format("{0:hh\\:mm\\:ss}", timerTex);
	}

	public void Run()
	{
		running = !running;

		if (running)
		{
			transform.Find("PlayBtn").GetComponent<Image>().sprite = stopSprite;
		}
		else
		{
			transform.Find("PlayBtn").GetComponent<Image>().sprite = playSprite;
		}
	}
}
