using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour 
{

	public List<GameObject>[] enemies = new List<GameObject>[4];
	public string  tryText = "";
	public int tries;
	string[] keyAnswer = new string[4];
	GameObject[] spawnPoints;
	float spawnTime = 5f;
	float time = 0;
	int lastAdd;
	public GameObject enemy;

	void Start()
	{
		keyAnswer[0] = "XX";
		keyAnswer[1] = "OO";
		keyAnswer[2] = "XTriSq";
		keyAnswer[3] = "OXO";
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
		if (time >= spawnTime) 
		{
			Spawn ();
			temp = GameObject.FindGameObjectsWithTag ("C" + lastAdd);
			Debug.Log (temp.Length);
			enemies [lastAdd].Clear ();
			for (int i = 0; i < temp.Length; i++) 
			{
				enemies [lastAdd].Add(temp [i]);
				Debug.Log (enemies.Length + " : " + enemies [lastAdd].Count);
			}
			time = 0f;
		}

		for (int i = 0; i < 4; i++) 
		{
			if (tryText.Equals (keyAnswer[i])) 
			{
				Debug.Log ("Killed" + i);
				tries = 0;
				tryText = "";
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
			Debug.Log ("WrongCombination");
		}
	}


	void Spawn()
	{
		lastAdd = Random.Range (0, 3);
		enemy.transform.position = spawnPoints [Random.Range(0,3)].transform.position;
		enemy.tag = "C" + lastAdd;
		Instantiate (enemy);
	}
}