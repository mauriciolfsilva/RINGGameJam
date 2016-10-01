using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject player;
	public int color;
	public Sprite[] sprites;
	void Start()
	{
		player = GameObject.Find ("Player");
		takeColor ();
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

	void takeColor()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [color];
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag.Equals ("Player")) 
		{
			Debug.Log ("Game Over");
		}

	}


}