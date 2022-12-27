using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowMan : MonoBehaviour
{
	[SerializeField] private Transform player;
	[SerializeField] private GameObject snowMan;

	private void Start()
	{
		StartCoroutine(spawn());
	}
	private IEnumerator spawn()
	{
		while (true)
		{
			yield return new WaitForSeconds(5);
			float x = Random.Range(600, -70);
			float z = Random.Range(-470, 300);
			var newSnowMan = Instantiate(snowMan, new Vector3(x, 10f, z), Quaternion.identity);
			var snowManComponent = newSnowMan.GetComponent<SnowMan>();
			if (snowManComponent != null)
			{
				snowManComponent.SetTarget(player);
			}
		}
	}
}