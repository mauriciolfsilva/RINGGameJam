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
	List<int> rSymRefs = new List<int>();
	List<int> gSymRefs = new List<int>();
	List<int> bSymRefs = new List<int>();
	List<int> ySymRefs = new List<int>();
	public Text counterText;
	private string listPatterns;
	private float counter;
	private int dificult;

	void Start () {
		counter = 10;
		dificult = PlayerPrefs.GetInt("SymbolsDif");
		for (int i = 0; i < dificult; i++) {
			if (PlayerPrefs.GetInt ("ColorDif") >= 2) {
				rSymRefs.Add (Random.Range (0, 3));
				bSymRefs.Add (Random.Range (0, 3));
				redPatterns [i].sprite = symbols [rSymRefs [rSymRefs.Count - 1]];
				bluePatterns [i].sprite = symbols [bSymRefs [bSymRefs.Count - 1]];
			} else if (PlayerPrefs.GetInt ("ColorDif") >= 3) {
				gSymRefs.Add (Random.Range (0, 3));
				greenPatterns [i].sprite = symbols [gSymRefs [gSymRefs.Count - 1]];
			}
			if (PlayerPrefs.GetInt ("ColorDif") >= 4) {
				ySymRefs.Add (Random.Range (0, 3));
				yellowPatterns [i].sprite = symbols [gSymRefs [gSymRefs.Count - 1]];
			}
		}
		for (int i = 0; i < dificult; i++) {
			if(rSymRefs.Count > 0)_redPatterns += rSymRefs[i];
			if(gSymRefs.Count > 0)_greenPatterns += gSymRefs[i];
			if(bSymRefs.Count > 0)_bluePatterns += bSymRefs[i];
			if(ySymRefs.Count > 0)_yellowPatterns += ySymRefs[i];
		}
	}

	void Update () {

		hideTip();

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

	void hideTip() 
	{
		
		if (PlayerPrefs.GetInt("SymbolsDif") == 1) {
			redPatterns [redPatterns.Length - 1].color = new Color (redPatterns [redPatterns.Length - 1].color.r, redPatterns [redPatterns.Length - 1].color.g, redPatterns [redPatterns.Length - 1].color.b, 0);
			redPatterns [redPatterns.Length - 2].color = new Color (redPatterns [redPatterns.Length - 2].color.r, redPatterns [redPatterns.Length - 2].color.g, redPatterns [redPatterns.Length - 2].color.b, 0);
	
		} 
		else if (PlayerPrefs.GetInt("SymbolsDif") == 2)
			redPatterns [redPatterns.Length - 1].color = new Color (redPatterns [redPatterns.Length - 1].color.r, redPatterns [redPatterns.Length - 1].color.g, redPatterns [redPatterns.Length - 1].color.b, 0);

		if (PlayerPrefs.GetInt ("ColorDif") == 2) 
		{
			if (PlayerPrefs.GetInt ("SymbolsDif") == 1) 
			{
				bluePatterns [bluePatterns.Length - 1].color = new Color (bluePatterns [bluePatterns.Length - 1].color.r, bluePatterns [bluePatterns.Length - 1].color.g, bluePatterns [bluePatterns.Length - 1].color.b, 0);
				bluePatterns [bluePatterns.Length - 2].color = new Color (bluePatterns [bluePatterns.Length - 2].color.r, bluePatterns [bluePatterns.Length - 2].color.g, bluePatterns [bluePatterns.Length - 2].color.b, 0);

			} 
			else if (PlayerPrefs.GetInt ("SymbolsDif") == 2)
				bluePatterns [bluePatterns.Length - 1].color = new Color (bluePatterns [bluePatterns.Length - 1].color.r, bluePatterns [bluePatterns.Length - 1].color.g, bluePatterns [bluePatterns.Length - 1].color.b, 0);
		} 
		else if(PlayerPrefs.GetInt ("ColorDif") < 2)
		{
			bluePatterns [bluePatterns.Length - 1].color = new Color (bluePatterns [bluePatterns.Length - 1].color.r, bluePatterns [bluePatterns.Length - 1].color.g, bluePatterns [bluePatterns.Length - 1].color.b, 0);
			bluePatterns [bluePatterns.Length - 2].color = new Color (bluePatterns [bluePatterns.Length - 2].color.r, bluePatterns [bluePatterns.Length - 2].color.g, bluePatterns [bluePatterns.Length - 2].color.b, 0);
			bluePatterns [bluePatterns.Length - 3].color = new Color (bluePatterns [bluePatterns.Length - 3].color.r, bluePatterns [bluePatterns.Length - 3].color.g, bluePatterns [bluePatterns.Length - 3].color.b, 0);
		}

		if (PlayerPrefs.GetInt ("ColorDif") == 3) 
		{
			Debug.Log (PlayerPrefs.GetInt ("ColorDif") + " : " + PlayerPrefs.GetInt ("SymbolsDif"));
			if (PlayerPrefs.GetInt ("SymbolsDif") == 1)
			{
				greenPatterns [greenPatterns.Length - 1].color = new Color (greenPatterns [greenPatterns.Length - 1].color.r, greenPatterns [greenPatterns.Length - 1].color.g, greenPatterns [greenPatterns.Length - 1].color.b, 0);
				greenPatterns [greenPatterns.Length - 2].color = new Color (greenPatterns [greenPatterns.Length - 2].color.r, greenPatterns [greenPatterns.Length - 2].color.g, greenPatterns [greenPatterns.Length - 2].color.b, 0);

			} 
			else if (PlayerPrefs.GetInt ("SymbolsDif") == 2)
				greenPatterns [greenPatterns.Length - 1].color = new Color (greenPatterns [greenPatterns.Length - 1].color.r, greenPatterns [greenPatterns.Length - 1].color.g, greenPatterns [greenPatterns.Length - 1].color.b, 0);
		}
		else if(PlayerPrefs.GetInt ("ColorDif") < 3)
		{
			greenPatterns [greenPatterns.Length - 1].color = new Color (greenPatterns [greenPatterns.Length - 1].color.r, greenPatterns [greenPatterns.Length - 1].color.g, greenPatterns [greenPatterns.Length - 1].color.b, 0);
			greenPatterns [greenPatterns.Length - 2].color = new Color (greenPatterns [greenPatterns.Length - 2].color.r, greenPatterns [greenPatterns.Length - 2].color.g, greenPatterns [greenPatterns.Length - 2].color.b, 0);
			greenPatterns [greenPatterns.Length - 3].color = new Color (greenPatterns [greenPatterns.Length - 3].color.r, greenPatterns [greenPatterns.Length - 3].color.g, greenPatterns [greenPatterns.Length - 3].color.b, 0);
		}

		if (PlayerPrefs.GetInt ("ColorDif") == 4) 
		{
			if (PlayerPrefs.GetInt ("SymbolsDif") == 1)
			{
				yellowPatterns [yellowPatterns.Length - 1].color = new Color (yellowPatterns [yellowPatterns.Length - 1].color.r, yellowPatterns [yellowPatterns.Length - 1].color.g, yellowPatterns [yellowPatterns.Length - 1].color.b, 0);
				yellowPatterns [yellowPatterns.Length - 2].color = new Color (yellowPatterns [yellowPatterns.Length - 2].color.r, yellowPatterns [yellowPatterns.Length - 2].color.g, yellowPatterns [yellowPatterns.Length - 2].color.b, 0);

			}
			else if (PlayerPrefs.GetInt ("SymbolsDif") == 2)
				yellowPatterns [yellowPatterns.Length - 1].color = new Color (yellowPatterns [yellowPatterns.Length - 1].color.r, yellowPatterns [yellowPatterns.Length - 1].color.g, yellowPatterns [yellowPatterns.Length - 1].color.b, 0);
		}
		else 
		{
			yellowPatterns [yellowPatterns.Length - 1].color = new Color (yellowPatterns [yellowPatterns.Length - 1].color.r, yellowPatterns [yellowPatterns.Length - 1].color.g, yellowPatterns [yellowPatterns.Length - 1].color.b, 0);
			yellowPatterns [yellowPatterns.Length - 2].color = new Color (yellowPatterns [yellowPatterns.Length - 2].color.r, yellowPatterns [yellowPatterns.Length - 2].color.g, yellowPatterns [yellowPatterns.Length - 2].color.b, 0);
			yellowPatterns [yellowPatterns.Length - 3].color = new Color (yellowPatterns [yellowPatterns.Length - 3].color.r, yellowPatterns [yellowPatterns.Length - 3].color.g, yellowPatterns [yellowPatterns.Length - 3].color.b, 0);
		}
	}
}
