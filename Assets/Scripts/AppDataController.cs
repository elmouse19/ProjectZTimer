using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AppDataController : MonoBehaviour
{
	Main mainScript;

	public string saveFile;
	public GameObject[] timersObjects;
	public DataBase dataBase;

	// Start is called before the first frame update
	void Awake()
	{
		saveFile = Application.dataPath + "/appData.json";

		mainScript = GameObject.Find("Main").GetComponent<Main>();
	}

	void Start()
	{
		dataBase = new DataBase();
		dataBase.timersList = new List<TimerData>();

		LoadData();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.L))
		{
			LoadData();
		}

		if (Input.GetKey(KeyCode.S))
		{
			SaveData();
		}
	}

	// Update is called once per frame
	void LoadData()
	{
		if (File.Exists(saveFile))
		{
			string content = File.ReadAllText(saveFile);
			dataBase = JsonUtility.FromJson<DataBase>(content);

			foreach (TimerData timer in dataBase.timersList)
			{
				TimerData tmpTD = new TimerData();
				tmpTD.order = timer.order;
				tmpTD.id = timer.id;
				tmpTD.timerName = timer.timerName;
				tmpTD.start = timer.start;
				tmpTD.end = timer.end;

				mainScript.InstantiateTimer(tmpTD);
			}
		}
		else
		{
			mainScript.InstantiateAlert("Can't find saved data");
		}
	}

	void SaveData()
	{
		dataBase.timersList = GetTimersData();

		string fileJSON = JsonUtility.ToJson(dataBase);

		File.WriteAllText(saveFile, fileJSON);

		Debug.Log("File saved");
	}

	List<TimerData> GetTimersData()
	{
		List<TimerData> newTimersList = new List<TimerData>();

		timersObjects = GameObject.FindGameObjectsWithTag("Timer");

		foreach (GameObject timer in timersObjects)
		{
			if (timer.GetComponent<Timer>().timerData != null)
			{
				TimerData scriptData = timer.GetComponent<Timer>().timerData;

				TimerData newData = new TimerData();

				newData.id = scriptData.id;
				newData.timerName = scriptData.timerName;
				newData.start = scriptData.start;
				newData.end = scriptData.end;
				newData.order = scriptData.order;

				newTimersList.Add(newData);
			}
		}

		return newTimersList;
	}
}
