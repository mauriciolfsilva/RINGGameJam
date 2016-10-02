	using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {

	public Texture2D fadeTex;
	public int fadeDir;
	public float fadeSpeed;

	public void ChangeScene(int level) {
		SceneManager.LoadScene (level);
	}

	public void ChangeScene(string level) {
		SceneManager.LoadScene (level);
	}
}
