using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMan : MonoBehaviour
{

	[SerializeField] private Transform target;
	[SerializeField] private Transform point;
	[SerializeField] private GameObject snowBall;
	[SerializeField] private float speed = 250f;
	private int health = 100;
	public int speedSnowman = 25;
	private Vector3 rotateTo;

	public void SetTarget(Transform target)
	{
		this.target = target;
	}

	private IEnumerator shoot()
	{
		while (true)
		{
			yield return new WaitForSeconds(3);

			float angle = 0.5f * Mathf.Asin(rotateTo.magnitude * -Physics.gravity.y / (speed * speed));
			if (!float.IsNaN(angle))
			{
				var newSnowBall = Instantiate(snowBall, point.position, Quaternion.identity);
				var rb = newSnowBall.GetComponent<Rigidbody>();
				if (rb != null)
				{
					point.localRotation = Quaternion.Euler(-(float)((angle * 180f) / Mathf.PI), 0, 0);
					rb.AddForce(point.forward * speed, ForceMode.VelocityChange);
				}
			}
		}
	}

	void Start()
	{
		StartCoroutine(shoot());
	}

	void Update()
	{
		transform.Translate(transform.forward * Time.deltaTime * speedSnowman);

		rotateTo = target.position - transform.position;
		transform.rotation = Quaternion.LookRotation(rotateTo, Vector3.up);
	}

	public void Damage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}
}