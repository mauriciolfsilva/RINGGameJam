using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public void OnClick(string n)
	{
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Main> ().tryText += n;
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Main> ().tries++;
	}
}
