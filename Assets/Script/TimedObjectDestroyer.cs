using UnityEngine;
using System.Collections;

public class TimedObjectDestroyer : MonoBehaviour
{
	public float lifeTime = 7.0f;

	// Use this for initialization
	void Start()
	{
		Destroy(gameObject, lifeTime);
	}
}