using UnityEngine;

public class InputLabelResizer : MonoBehaviour
{
	RectTransform rt;
	private void Awake()
	{
		rt = GetComponent<RectTransform>();
	}

	void Update()
	{
		Transform parent = transform.parent;

		if (parent != null)
		{
			RectTransform parentObj = parent.gameObject.GetComponent<RectTransform>();

			rt.offsetMin = new Vector2(0f, rt.offsetMin.y);
			rt.offsetMax = new Vector2(-(parentObj.rect.width * 50 / 100 + 2.5f), rt.offsetMax.y);
		}
		else
		{
			Debug.Log("The object has no parent.");
		}
	}
}
