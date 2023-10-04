using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class NewTimer : MonoBehaviour
{
	[SerializeField] TMP_InputField inputName, inputStart, inputEnd, inputOrder;

	Main mainScript;

	bool validationOk;

	private void Awake()
	{
		mainScript = GameObject.Find("Main").GetComponent<Main>();
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

			tData.timerName = SanitizeTMPText(inputName.textComponent.GetParsedText());
			tData.start = SanitizeTMPText(inputStart.textComponent.GetParsedText());
			tData.end = SanitizeTMPText(inputEnd.textComponent.GetParsedText());
			tData.order = SanitizeTMPText(inputOrder.textComponent.GetParsedText());

			mainScript.InstantiateTimer(tData);
		}
		else
		{
			mainScript.InstantiateAlert("Check the data entered");
		}
	}

	string SanitizeTMPText(string text)
	{
		return Regex.Replace(text, "[^a-zA-Z0-9: ]", "");
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
