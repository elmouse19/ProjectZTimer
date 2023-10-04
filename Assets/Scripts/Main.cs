using TMPro;
using UnityEngine;

public class Main : MonoBehaviour
{
	InstantiatePrefab instantiatePrefab;
	InstantiateTimer instantiateTimerScript;
	ViewPortContent viewPortContentScript;

	[SerializeField] static int timersCount = 0;

	private void Awake()
	{
		instantiatePrefab = GetComponent<InstantiatePrefab>();
		instantiateTimerScript = GetComponent<InstantiateTimer>();
		viewPortContentScript = GameObject.FindGameObjectWithTag("VPContent").GetComponent<ViewPortContent>();
	}

	public void InstantiateTimer(TimerData timerData)
	{
		instantiateTimerScript.Instantiate(timersCount, timerData);
		IncreaseTimersCount();
		viewPortContentScript.UpdateVPContentSize(timersCount);
	}

	public void InstantiateAlert(string msg)
	{
		instantiatePrefab.Instantiate();

		GameObject alert = GameObject.FindWithTag("Alert");
		alert.GetComponentInChildren<TMP_Text>().text = msg;
	}

	void IncreaseTimersCount()
	{
		timersCount++;
	}
}
