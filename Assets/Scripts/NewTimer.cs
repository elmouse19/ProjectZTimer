using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class NewTimer : MonoBehaviour
{
	[SerializeField] TMP_Text inputName, inputStart, inputEnd, inputOrder;

	Main mainScrit;

	bool validationOk;

	private void Awake()
	{
		mainScrit = GameObject.Find("Main").GetComponent<Main>();
	}

	private void Start()
	{
		validationOk = false;
	}

	public void CreateTimerObj()
	{
		if (Validations())
		{
			TimerData tData = new TimerData();

			tData.timerName = inputName.GetParsedText();
			tData.start = inputStart.GetParsedText();
			tData.end = inputEnd.GetParsedText();
			tData.order = inputOrder.GetParsedText();

			mainScrit.InstantiateTimer(tData);
		}
		else
		{
			print("error");
		}
	}

	bool Validations()
	{
		string regex = "\\d{2}:\\d{2}";
		var matchStart = Regex.Match(inputStart.text, regex, RegexOptions.IgnoreCase);
		var matchEnd = Regex.Match(inputEnd.text, regex, RegexOptions.IgnoreCase);

		if (inputName.text.Length > 0 && matchStart.Success && matchEnd.Success)
		{
			validationOk = true;
		}
		else
		{
			// does not match
			validationOk = false;
		}

		return validationOk;
	}
}
