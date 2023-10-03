using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
	public GameObject prefab;
	public Transform target;
	public Transform point;
	public float livingTime;

	public void Instantiate(int timersCount, TimerData timerData)
	{
		
		float cacltulateYPos = point.position.y + (-105f * timersCount);

		GameObject instantiatedObject = Instantiate(prefab, new Vector3(point.position.x, cacltulateYPos, 0), Quaternion.identity, target) as GameObject;

		instantiatedObject.GetComponent<Timer>().SetTdData(timerData.timerName, timerData.start, timerData.end, timerData.id, timerData.order);

		if (livingTime > 0f)
		{
			Destroy(instantiatedObject, livingTime);
		}
	}
}
