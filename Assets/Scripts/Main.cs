using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	InstantiatePrefab instantiateScript;

	[SerializeField] static int timersCount = 0;

	// Start is called before the first frame update
	void Start()
	{
		instantiateScript = GetComponent<InstantiatePrefab>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void InstantiateTimer(TimerData timerData)
	{
		instantiateScript.Instantiate(timersCount, timerData);
		IncreaseTimersCount();
		UpdateVPContentSize();
	}

	public void ASD()
	{
		TimerData tData = new TimerData();

		tData.timerName = "name";
		tData.start = "00:00";
		tData.end = "00:00";

		InstantiateTimer(tData);
	}

	void IncreaseTimersCount()
	{
		timersCount++;
	}

	void UpdateVPContentSize()
	{
		RectTransform vpContent = GameObject.FindWithTag("VPContent").GetComponent<RectTransform>();

		vpContent.sizeDelta = new Vector2(vpContent.sizeDelta.x, 100f * timersCount);
	}
}
