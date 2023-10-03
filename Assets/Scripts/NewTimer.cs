using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class NewTimer : MonoBehaviour
{
	[SerializeField] TMP_InputField inputName, inputStart, inputEnd, inputOrder;

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

			tData.timerName = SanitizeTMPText(inputName.textComponent.GetParsedText());
			tData.start = SanitizeTMPText(inputStart.textComponent.GetParsedText());
			tData.end = SanitizeTMPText(inputEnd.textComponent.GetParsedText());
			tData.order = SanitizeTMPText(inputOrder.textComponent.GetParsedText());

			mainScrit.InstantiateTimer(tData);
		}
		else
		{
			print("error");
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
