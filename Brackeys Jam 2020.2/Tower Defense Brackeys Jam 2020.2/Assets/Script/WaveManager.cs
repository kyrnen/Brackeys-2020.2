using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
	public enum SpawnState { SPAWNING, WAITING, COUNTING }
	[System.Serializable]
	public class Wave
	{
		public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	private int nextwave = 0;
	public Target target;

	public Transform[] spawnPoints;
	public float timeBettweenWaves = 5f;
	public float wavecountdown;
	private float searchcountdown = 1f;

	private SpawnState state = SpawnState.COUNTING;
	void Start()
	{
		if (spawnPoints.Length == 0)
		{
			Debug.LogError("no spawn points refrened");
		}
		wavecountdown = timeBettweenWaves;

	}
	void Update()
	{
		if (state == SpawnState.WAITING)
		{
			if (!EnemyIsAlive())
			{
				WaveCompleted();
			}
			else
				return;
		}
		if (wavecountdown <= 0)
		{
			if (state != SpawnState.SPAWNING)
			{
				StartCoroutine(Spawnwaves(waves[nextwave]));
				//start spawning waves
			}
		}
		else
		{
			wavecountdown -= Time.deltaTime;
		}
	}
	bool EnemyIsAlive()
	{
		searchcountdown -= Time.deltaTime;
		if (searchcountdown <= 0f)
		{
			searchcountdown = 1f;
			if (GameObject.FindGameObjectWithTag("Package") == null)
			{
				return false;
				
			}
		}
		return true;
	}

	void WaveCompleted() {
		Debug.Log("Wave Completed");
		state = SpawnState.COUNTING;
		wavecountdown = timeBettweenWaves;
		if(nextwave + 1 > waves.Length - 1)
		{
			nextwave = 0;
			Debug.Log("Completed all waves ");
		}
		nextwave++;
	}

	IEnumerator Spawnwaves(Wave _wave)
	{
		state = SpawnState.SPAWNING;

		for (int i = 0; i < _wave.count; i++)
		{
			SpwanEnemy(_wave.enemy);
			yield return new WaitForSeconds(1f / _wave.rate);
		}
		state = SpawnState.WAITING;

		yield break;
	}


	void SpwanEnemy(Transform _enemy)
	{
		Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
		Instantiate(_enemy, _sp.position, _sp.rotation);
		PickRandomNumber(1);
	}


	private void PickRandomNumber(int maxInt)
	{
		int RandomNumber = Random.Range(1, maxInt + 1);

		if(RandomNumber == 1)
		{
			target.IsBad = false;
		}
		
		if(RandomNumber == 2)
		{
			target.IsBad = true;
		}
		Debug.Log(target.IsBad);
		Debug.Log(RandomNumber);
	}
}