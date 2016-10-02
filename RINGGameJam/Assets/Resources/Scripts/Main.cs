using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Main : MonoBehaviour 
{

	public List<GameObject>[] enemies = new List<GameObject>[4];
	GameObject[] spawnPoints;
	float spawnTime = 3.5f;
	float time = 0;
	float comboTime = 0f;
	int combo = 0;
	public float score = 0;
	int lastAdd;
	int dif = 1;
	int blah = 0;
	public GameObject enemy;
	public GameObject aws;

	void Start()
	{
		spawnPoints = new GameObject[4];
		for (int i = 0; i < spawnPoints.Length; i++) {
			spawnPoints[i] = GameObject.Find ("SP" + (i + 1));
		}

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
			int mSp = Random.Range (1,dif);
			for (int n = 0; n < mSp; n++) {
				Spawn ();
				temp = GameObject.FindGameObjectsWithTag ("C" + lastAdd);
				enemies [lastAdd].Clear ();
				for (int i = 0; i < temp.Length; i++) {
					enemies [lastAdd].Add (temp [i]);
				}
			}
			time = 0f;
			if (spawnTime > 1.5f) spawnTime -= 0.1f;
		}
	}

	public void Atk(int _index)
	{
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
		if (blah >= 5 && dif < 4) {
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
		if (combo >= 4) {
			aws.transform.position = new Vector3 (0,3,0);//20 a -20
			aws.transform.Rotate(new Vector3(0,0,Random.Range(-20,20)));
			Instantiate (aws);
		}
	}
}