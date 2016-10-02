using UnityEngine;
using UnityEngine.UI;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {

	private AudioSource audio;

	void Start(){
		audio = gameObject.GetComponent<AudioSource>();
	}

	public void ChangeSceneWind(int level) {
		audio.Play ();
		var wind = new WindTransition()
		{
			nextScene = level,
			duration = 1.0f,
			size = 0.3f,
			windVerticalSegments = 50f
		};
		TransitionKit.instance.transitionWithDelegate( wind );
	}
}
