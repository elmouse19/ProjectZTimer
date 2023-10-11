using TMPro;
using UnityEngine;

public class Main : MonoBehaviour
{
	public AudioClip sound; // Drag and drop the sound clip you want to play here

	InstantiatePrefab instantiatePrefab;
	InstantiateTimer instantiateTimerScript;
	ViewPortContent viewPortContentScript;
	AudioSource audioSource; // Drag and drop the AudioSource component here

	[SerializeField] static int timersCount = 0;

	private void Awake()
	{
		instantiatePrefab = GetComponent<InstantiatePrefab>();
		instantiateTimerScript = GetComponent<InstantiateTimer>();
		audioSource = GetComponent<AudioSource>();
		viewPortContentScript = GameObject.FindGameObjectWithTag("VPContent").GetComponent<ViewPortContent>();
	}

	public void PlaySound()
	{
		audioSource.PlayOneShot(sound);
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

	public void DecreaseTimersCount()
	{
		timersCount--;
	}
}
