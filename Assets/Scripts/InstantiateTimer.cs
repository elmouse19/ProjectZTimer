using Unity.VisualScripting;
using UnityEngine;

public class InstantiateTimer : MonoBehaviour
{
	public GameObject prefab;
	public Transform target;
	public Transform point;
	public float livingTime;
	public float marginTop;
	public float marginBottom;

	private void Start()
	{
		marginTop = 15f;
		marginBottom = 5f;
	}

	public void Instantiate(int timersCount, TimerData timerData)
	{
		float prefabHeight = prefab.GetComponent<RectTransform>().sizeDelta.y;

		float cacltulateYPos = -marginTop + (-(prefabHeight + marginBottom) * timersCount);

		GameObject instantiatedObject = Instantiate(prefab, new Vector3(0, cacltulateYPos, 0), Quaternion.identity, target) as GameObject;

		instantiatedObject.GetComponent<Timer>().SetTdData(timerData.timerName, timerData.start, timerData.end, timerData.id, timerData.order);

		if (livingTime > 0f)
		{
			Destroy(instantiatedObject, livingTime);
		}
	}
}
