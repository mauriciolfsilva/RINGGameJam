using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

	public Text t;

	void Start () {
		t.text = "The HighScore is " + PlayerPrefs.GetFloat ("HighScore"); 
	}
}
