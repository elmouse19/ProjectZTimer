using UnityEngine;
using UnityEngine.Tilemaps;

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

	public void InstantiateAlert()
	{
		instantiatePrefab.Instantiate();
	}

	void IncreaseTimersCount()
	{
		timersCount++;
	}
}
