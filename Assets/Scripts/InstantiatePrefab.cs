using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InstantiatePrefab : MonoBehaviour
{
	public GameObject prefab;
	public Transform target;
	public Transform point;
	public float livingTime;

	public void Instantiate()
	{
		GameObject instantiatedObject = Instantiate(prefab, point.position, Quaternion.identity, target) as GameObject;

		if (livingTime > 0f)
		{
			Destroy(instantiatedObject, livingTime);
		}
	}
}
