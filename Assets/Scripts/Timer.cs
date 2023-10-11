using System;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	//public GameObject messagePrefab; // Prefab of the message you want to display.

	public TimerData timerData;

	AppDataController appDataController;
	Main mainScript;

	GameObject timerChild, playBtn, resetBtnBig, resetBtnSmall;

	TMP_Text timerStart;
	TMP_Text timerEnd;
	TMP_Text countDown;
	TMP_Text timerName;

	[SerializeField] int hour, min, sec;
	[SerializeField] Sprite playSprite, stopSprite, resetSprite;

	DateTime dateTimeStart, dateTimeEnd;
	TimeSpan timeDiff;

	int clickCounter;
	float timeAmount, timeLeft, confirmActionTimeWait;
	bool running, watingConfirm;

	private float timeBetweenMessages = 900.0f; // Time in seconds (15 minutes).
	private float lastMessageTime = 0.1f;

	void Awake()
	{
		playBtn = transform.Find("PlayBtn").GameObject();
		resetBtnBig = transform.Find("ResetBtnBig").GameObject();
		resetBtnSmall = transform.Find("ResetBtnSmall").GameObject();


		mainScript = GameObject.Find("Main").GetComponent<Main>();

		timerChild = transform.Find("TimerClock").gameObject;

		timerStart = timerChild.transform.Find("TimerStart").GetComponent<TMP_Text>();
		timerEnd = timerChild.transform.Find("TimerEnd").GetComponent<TMP_Text>();
		countDown = timerChild.transform.Find("CountDown").GetComponent<TMP_Text>();
		timerName = transform.Find("TimerName").GetComponent<TMP_Text>();
	}

	void Start()
	{
		clickCounter = 0;
		confirmActionTimeWait = 5f;
		watingConfirm = false;

		appDataController = GameObject.Find("AppDataController").GetComponent<AppDataController>();
	}

	// Update is called once per frame
	void Update()
	{
		// RUNING TIMER
		if (running)
		{
			timeLeft -= Time.deltaTime;

			if (timeLeft <= 0)
			{
				// stop
				Run();
				Finish();
			}

			// Check if enough time has passed to display another message.
			if (Time.time - lastMessageTime >= timeBetweenMessages)
			{
				// Instantiate the message (you can create a prefab for this) at the desired position.
				mainScript.PlaySound();
				mainScript.InstantiateAlert("Notice: 15 minutes have passed. Take a break.");

				// Update the time of the last displayed message.
				lastMessageTime = Time.time;
			}

			UpdateCountDownText();
		}

		// CONFIRM DELETE
		if (watingConfirm && confirmActionTimeWait <= 5f && confirmActionTimeWait > 0f)
		{
			confirmActionTimeWait -= Time.deltaTime;
		}
		else if (watingConfirm && confirmActionTimeWait <= 0f)
		{
			ResetConfirmation();
		}
	}

	public void SetTdData(string name, string start, string end, string id = "", Nullable<int> order = null)
	{
		timerData.id = id != "" ? id : Guid.NewGuid().ToString();
		timerData.timerName = name;
		timerData.start = start;
		timerData.end = end;
		timerData.order = order;

		SetTimer();
	}

	public void SetTimer()
	{
		timerName.text = timerData.timerName;
		timerStart.text = timerData.start;
		timerEnd.text = timerData.end;

		string timeStartF = timerData.start + ":00";
		string timeEndF = timerData.end + ":00";

		dateTimeStart = DateTime.ParseExact(timeStartF, "HH:mm:ss",
													 CultureInfo.InvariantCulture);
		dateTimeEnd = DateTime.ParseExact(timeEndF, "HH:mm:ss",
													 CultureInfo.InvariantCulture);

		timeDiff = dateTimeEnd - dateTimeStart;

		hour = timeDiff.Hours;
		min = timeDiff.Minutes;
		sec = timeDiff.Seconds;

		timeAmount = hour * 60 * 60 + min * 60 + sec;
		timeLeft = timeAmount;

		if (timeLeft > 0)
		{
			playBtn.GetComponent<Button>().interactable = true;
			UpdateCountDownText();
		}
	}

	public void Run()
	{
		running = !running;

		if (running)
		{
			playBtn.GetComponent<Image>().sprite = stopSprite;
			resetBtnSmall.GetComponent<Button>().interactable = false;
		}
		else
		{
			playBtn.GetComponent<Image>().sprite = playSprite;
			resetBtnSmall.GetComponent<Button>().interactable = true;
		}
	}

	public void Finish()
	{
		playBtn.SetActive(false);
		resetBtnBig.SetActive(true);
		resetBtnSmall.SetActive(false);
	}

	public void ResetTimer()
	{
		timeLeft = timeAmount;
		running = false;

		playBtn.SetActive(true);

		resetBtnBig.SetActive(false);

		resetBtnSmall.SetActive(true);
		resetBtnSmall.GetComponent<Button>().interactable = false;

		UpdateCountDownText();
	}

	void UpdateCountDownText()
	{
		TimeSpan timerTex = TimeSpan.FromSeconds((double)(new decimal(timeLeft)));
		countDown.text = string.Format("{0:hh\\:mm\\:ss}", timerTex);
	}

	public void RemoveTimer()
	{
		clickCounter++;
		watingConfirm = true;

		if (clickCounter == 3)
		{
			mainScript.DecreaseTimersCount();
			Destroy(gameObject);
			appDataController.SaveData();
		}
	}

	void ResetConfirmation()
	{
		clickCounter = 0;
		confirmActionTimeWait = 5f;
		watingConfirm = false;
	}
}
