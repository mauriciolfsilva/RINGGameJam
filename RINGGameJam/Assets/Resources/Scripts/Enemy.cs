using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject player;

	void Start()
	{
		player = GameObject.Find ("Player");
	}

	void Update()
	{
		if (this.transform.position.x < player.transform.position.x)
			this.transform.position += new Vector3(1 * Time.deltaTime,0,0);
		else if (this.transform.position.x > player.transform.position.x)
			this.transform.position -= new Vector3(1 * Time.deltaTime,0,0);

		if (this.transform.position.y < player.transform.position.y)
			this.transform.position += new Vector3(0, 1 * Time.deltaTime,0);
		else if (this.transform.position.y > player.transform.position.y)
			this.transform.position -= new Vector3(0, 1 * Time.deltaTime,0);
	}


}