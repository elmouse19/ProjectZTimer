using UnityEngine;

public class ViewPortContent : MonoBehaviour
{
	RectTransform vpContent;

	private void Awake()
	{
		vpContent = GetComponent<RectTransform>();
	}
	public void UpdateVPContentSize(int timersCount)
	{
		vpContent.sizeDelta = new Vector2(vpContent.sizeDelta.x, (104.8158f * timersCount) + 20f );
	}
}
