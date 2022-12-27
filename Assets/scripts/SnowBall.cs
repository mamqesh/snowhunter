using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
	private int damage = 0;
	void Start()
	{
		damage = Random.Range(10, 20);
	}
	private void OnCollisionEnter(Collision collision)
	{
		var snowMan = collision.gameObject.GetComponent<SnowMan>();
		if (snowMan != null)
		{
			snowMan.Damage(damage);
		}
		else
		{
			var player = collision.gameObject.GetComponent<Player>();
			if (player)
			{
				player.Damage(damage);
			}
		}

		Destroy(gameObject);
	}

}