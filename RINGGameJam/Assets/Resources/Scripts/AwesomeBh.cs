using UnityEngine;
using System.Collections;

public class AwesomeBh : MonoBehaviour {

	float time = 0f;

	void Update () {
		time += Time.deltaTime * 1.25f;
		//this.gameObject.GetComponent<SpriteRenderer> ().color.a -= Time.deltaTime * 4;

		if (time >= 1)	Destroy (this.gameObject);
	}
}
