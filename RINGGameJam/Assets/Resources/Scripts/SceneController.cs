	using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {

	public Texture2D fadeTex;
	public int fadeDir;
	public float fadeSpeed;

	void Start()
	{
		PlayerPrefs.SetInt ("ColorDif",2);
		PlayerPrefs.SetInt ("SymbolsDif",1);
	}


	public void ChangeScene(int level) {
		SceneManager.LoadScene (level);
	}

	public void ChangeScene(string level) {
		SceneManager.LoadScene (level);
	}
}
