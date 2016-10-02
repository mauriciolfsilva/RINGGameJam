using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Main : MonoBehaviour 
{

	public List<GameObject>[] enemies = new List<GameObject>[4];
	GameObject[] spawnPoints;
	float spawnTime = 5f;
	float time = 0;
	float comboTime = 0f;
	int combo = 0;
	float score = 0;
	int lastAdd;
	int dif = 1;
	int blah = 0;
	public GameObject enemy;

	void Start()
	{
		spawnPoints = GameObject.FindGameObjectsWithTag ("SP");

		for (int i = 0; i < 4; i++) 
		{
			enemies[i] = new List<GameObject>();
		}

		ScoreGain (0);
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
			if (spawnTime > 2) spawnTime -= 0.1f;
		}
	}

	public void Atk(string dir)
	{
		int _index = dir == "Up" ? 0 : dir == "Left" ? 1 : dir == "Right" ? 2 : 3;
		if(enemies[_index].Count > 0) enemies [_index] [0].GetComponent<Enemy>().life--;
	}

	void Spawn()
	{
		lastAdd = Random.Range((int)0, (int)enemies.Length);
		enemy.transform.position = spawnPoints [lastAdd].transform.position;
		enemy.tag = "C" + lastAdd;
		enemy.GetComponent<Enemy> ().color = Random.Range((int)0, (int)dif);
		Instantiate (enemy);
		blah++;
		if (blah >= 5 && dif < 5) {
			dif++;
			blah = 0;
		}
	}

	public void ScoreGain(int i)
	{
		score += 5 * i + (2 + combo) * combo;
		combo++;
		comboTime = 2f;
		GameObject.Find ("Score").GetComponent<Text>().text = "Score: " + score;
	}
}