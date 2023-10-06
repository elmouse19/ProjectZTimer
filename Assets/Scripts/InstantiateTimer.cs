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
		/************************* Revisar para corregir y poder utilizar este metodo con el calculo correcto ************************************/
		////float prefabHeight = prefab.GetComponent<RectTransform>().sizeDelta.y;
		//float prefabHeight = prefab.GetComponent<RectTransform>().rect.height;
		////float prefabHeight = point.GetComponent<RectTransform>().rect.height;

		//float cacltulateYPos = -marginTop + (-(prefabHeight + marginBottom) * timersCount);

		//GameObject instantiatedObject = Instantiate(prefab, new Vector3(point.position.x, point.GetComponent<RectTransform>().anchoredPosition.y, point.position.z), Quaternion.identity, target) as GameObject;

		//instantiatedObject.transform.position = new Vector3(point.position.x, cacltulateYPos, point.position.z);
		/************************* Revisar para corregir y poder utilizar este metodo con el calculo correcto ************************************/
		float cacltulateYPos = point.position.y + ((-100f + -marginBottom) * timersCount);


		GameObject instantiatedObject = Instantiate(prefab, new Vector3(point.position.x, cacltulateYPos, 0), Quaternion.identity, target) as GameObject;


		instantiatedObject.GetComponent<Timer>().SetTdData(timerData.timerName, timerData.start, timerData.end, timerData.id, timerData.order);

		if (livingTime > 0f)
		{
			Destroy(instantiatedObject, livingTime);
		}
	}
}
