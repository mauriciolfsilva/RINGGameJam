using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InfoController : MonoBehaviour {

	public Image[] redPatterns;
	private string _redPatterns;
	public Image[] greenPatterns;
	private string _greenPatterns;
	public Image[] bluePatterns;
	private string _bluePatterns;
	public Image[] yellowPatterns;
	private string _yellowPatterns;

	public Sprite[] symbols;
	public Text counterText;
	private string listPatterns;
	private float counter;
	private int dificult;

	void Start () {
		counter = 10;
		dificult = PlayerPrefs.GetInt("SymbolsDif");
		for (int i = 0; i < dificult; i++) {
			//Debug.Log (PlayerPrefs.GetInt("ColorDif"));
			if (PlayerPrefs.GetInt ("ColorDif") >= 2)
			{
				redPatterns [i].sprite = symbols [Random.Range (0, 3)];
				bluePatterns [i].sprite = symbols [Random.Range (0, 3)];
			}

			else if(PlayerPrefs.GetInt("ColorDif") >= 3 )greenPatterns [i].sprite = symbols [Random.Range(0, 3)];
			if(PlayerPrefs.GetInt("ColorDif") >= 4) yellowPatterns [i].sprite = symbols [Random.Range(0, 3)];
		}
		for (int i = 0; i < dificult; i++) {
			_redPatterns += i;
			_greenPatterns += i;
			_bluePatterns += i;
			_yellowPatterns += i;
		}
	}

	void Update () {
		

		hideTip (redPatterns, dificult);
		hideTip (bluePatterns, dificult);
		hideTip (greenPatterns, dificult);
		hideTip (yellowPatterns, dificult);

		if (PlayerPrefs.GetInt ("ColorDif") >= 2) {
			PlayerPrefs.SetString ("0", _redPatterns);
			PlayerPrefs.SetString ("1", _bluePatterns);
			PlayerPrefs.SetString ("2", "");
			PlayerPrefs.SetString ("3", "");
		}
		if(PlayerPrefs.GetInt("ColorDif") >= 3 )PlayerPrefs.SetString ("2", _greenPatterns);
		if(PlayerPrefs.GetInt("ColorDif") >= 4 ) PlayerPrefs.SetString ("3", _yellowPatterns);

		counter -= Time.deltaTime;
		counterText.text = Mathf.Round(counter).ToString();
		if (counter < 1) {
			SceneManager.LoadScene ("Game");
		}
	}

	void hideTip(Image[] obj, int dificult) {
		
		if (dificult == 1) {
			obj [obj.Length - 1].color = new Color (obj [obj.Length - 1].color.r, obj [obj.Length - 1].color.g, obj [obj.Length - 1].color.b, 0);
			obj [obj.Length - 2].color = new Color (obj [obj.Length - 2].color.r, obj [obj.Length - 2].color.g, obj [obj.Length - 2].color.b, 0);
	
		} else if (dificult == 2)
			obj [obj.Length - 1].color = new Color (obj [obj.Length - 1].color.r, obj [obj.Length - 1].color.g, obj [obj.Length - 1].color.b, 0);
	}
}
