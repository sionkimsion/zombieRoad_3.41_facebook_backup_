using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destroyer : MonoBehaviour
{
	//Destroy any game objects that collides with this script.

	void OnCollisionEnter2D(Collision2D col)
	{
		Destroy(col.gameObject);
	}
}
