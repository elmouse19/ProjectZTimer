using UnityEngine;

public class ViewPortContent : MonoBehaviour
{
	[SerializeField] GameObject timerPrefab;

	RectTransform vpContent;

	float timerHeight;

	public float marginBottom;
	public float paddingBottom;

	private void Awake()
	{
		vpContent = GetComponent<RectTransform>();
	}

	private void Start()
	{
		marginBottom = 5f;
		paddingBottom = 20f;
	}

	public void UpdateVPContentSize(int timersCount)
	{
		timerHeight = timerPrefab.GetComponent<RectTransform>().sizeDelta.y + marginBottom;
		vpContent.sizeDelta = new Vector2(vpContent.sizeDelta.x, (timerHeight * timersCount) + paddingBottom);
	}
}
