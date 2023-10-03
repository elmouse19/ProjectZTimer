using UnityEngine;

public class Main : MonoBehaviour
{
	InstantiatePrefab instantiateScript;
	ViewPortContent viewPortContentScript;

	[SerializeField] static int timersCount = 0;

	private void Awake()
	{
		instantiateScript = GetComponent<InstantiatePrefab>();
		viewPortContentScript = GameObject.FindGameObjectWithTag("VPContent").GetComponent<ViewPortContent>();
	}

	public void InstantiateTimer(TimerData timerData)
	{
		instantiateScript.Instantiate(timersCount, timerData);
		IncreaseTimersCount();
		viewPortContentScript.UpdateVPContentSize(timersCount);
	}

	void IncreaseTimersCount()
	{
		timersCount++;
	}
}
