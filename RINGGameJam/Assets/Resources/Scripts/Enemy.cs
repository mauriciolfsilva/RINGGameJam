using UnityEngine;
using System.Collections;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	GameObject player;
	public int color;
	public Sprite[] sprites;
	public int life;
	private AudioSource audio;

	void Start()
	{
		player = GameObject.Find ("Player");
		life = color + 1;
		audio = gameObject.GetComponent<AudioSource> ();
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

			if (PlayerPrefs.GetFloat ("HighScore") < GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Main> ().score)
				PlayerPrefs.SetFloat ("HighScore", GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Main> ().score);	
			audio.Play ();
			var doorway = new BlurTransition()
			{
				nextScene = 2,
				duration = 0.2f,
				blurMin = 0.0f,
				blurMax = 0.2f
			};
			TransitionKit.instance.transitionWithDelegate(doorway);
		}

	}
}