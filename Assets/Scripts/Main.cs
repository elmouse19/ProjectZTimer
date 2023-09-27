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
	}

	void IncreaseTimersCount()
	{
		timersCount++;
	}
}
