using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	GameObject player;
	public int color;
	public Sprite[] sprites;
	public int life;
	void Start()
	{
		player = GameObject.Find ("Player");
		life = color + 1;
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

		if (life <= 0) {
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Main> ().ScoreGain (color + 1);
			Destroy (this.gameObject);
		}

		else
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = sprites [life - 1];

	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag.Equals ("Player")) {
			SceneManager.LoadScene ("Menu");
		}

	}


}