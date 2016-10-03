using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class FadeText : MonoBehaviour {

	public bool isSet;

	void Start()
	{
		if(SceneManager.GetActiveScene().buildIndex == 0) StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
	}

	void Update() {
		if (SceneManager.GetActiveScene().buildIndex == 0 && GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Main> ().pause && isSet) {
			StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
			isSet = false;
		}
	}

	public IEnumerator FadeTextToFullAlpha(float time, Text txt)
	{
		txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 0);
		while (txt.color.a < 1.0f)
		{
			txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, txt.color.a + (Time.deltaTime / time));
			yield return null;
		}
		StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<Text>()));
	}

	public IEnumerator FadeTextToZeroAlpha(float time, Text txt)
	{
		txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 1);
		while (txt.color.a > 0.0f)
		{
			txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, txt.color.a - (Time.deltaTime / time));
			yield return null;
		}
		StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<Text>()));
	}
}