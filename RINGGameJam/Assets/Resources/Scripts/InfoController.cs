using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InfoController : MonoBehaviour {

	public Image[] patterns;
	public Sprite[] symbols;
	public Text counterText;
	private string listPatterns;
	private IEnumerable<string> listPatternsDivided;
	private float counter;

	void Start () {
		counter = 10;
		for (int i = 0; i < patterns.Length; i++) {
			int rand = Random.Range(0, 3);
			patterns [i].sprite = symbols [rand];
			listPatterns += rand;
			listPatternsDivided = Split (listPatterns, 3);
		}
	}

	void Update () {
		for (int i = 0; i < 4; i++) {
			PlayerPrefs.SetString(i.ToString(), listPatternsDivided.ElementAt(i));
		}
		counter -= Time.deltaTime;
		counterText.text = Mathf.Round(counter).ToString();
		if (counter < 1) {
			SceneManager.LoadScene ("Game");
		}
	}

	static IEnumerable<string> Split(string str, int chunkSize) {
		return Enumerable.Range(0, str.Length / chunkSize)
			.Select(i => str.Substring(i * chunkSize, chunkSize));
	}
}
