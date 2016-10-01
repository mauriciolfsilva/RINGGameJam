using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Main : MonoBehaviour 
{

	public List<GameObject>[] enemies = new List<GameObject>[4];
	public string  tryText = "";
	public int tries;
	string[] keyAnswer = new string[4];
	GameObject[] spawnPoints;
	float spawnTime = 5f;
	float time = 0;
	float comboTime = 0f;
	int combo = 0;
	float score = 0;
	int lastAdd;
	public GameObject enemy;

	void Start()
	{
		keyAnswer[0] = "XX";
		keyAnswer[1] = "OO";
		keyAnswer[2] = "SS";
		keyAnswer[3] = "TT";
		spawnPoints = GameObject.FindGameObjectsWithTag ("SP");

		for (int i = 0; i < 4; i++) 
		{
			enemies[i] = new List<GameObject>();
		}
	}

	void Update()
	{
		GameObject[] temp;
		time += Time.deltaTime;
		comboTime -= Time.deltaTime;

		if (comboTime <= 0f) 
		{
			combo = 0;
		}

		if (time >= spawnTime) 
		{
			Spawn ();
			temp = GameObject.FindGameObjectsWithTag ("C" + lastAdd);
			enemies [lastAdd].Clear ();
			for (int i = 0; i < temp.Length; i++) 
			{
				enemies [lastAdd].Add(temp [i]);
			}
			time = 0f;
		}

		for (int i = 0; i < 4; i++) 
		{
			if (tryText.Equals (keyAnswer[i])) 
			{
				Debug.Log (tryText + " : " + keyAnswer [i]);
				tries = 0;
				tryText = "";
				SocreGain (i);
				Debug.Log (tryText + " : " + keyAnswer [i]);
				for(int n = 0; n < enemies[i].Count; n++)
				{
					Destroy(enemies [i] [n]);
				}
				enemies [i].Clear();
			} 
		}

		if (tries >= 3) 
		{
			tries = 0;
			tryText = "";
		}
	}


	void Spawn()
	{
		lastAdd = Random.Range (0, 3);
		enemy.transform.position = spawnPoints [Random.Range(0,3)].transform.position;
		enemy.tag = "C" + lastAdd;
		enemy.GetComponent<Enemy> ().color = lastAdd;
		Instantiate (enemy);
	}

	void SocreGain(int i)
	{
		score += 5 * keyAnswer [i].Length + (2 + combo) * combo;
		combo++;
		comboTime = 2f;
		GameObject.Find ("Score").GetComponent<Text>().text = "Score : " + score;
	}
}