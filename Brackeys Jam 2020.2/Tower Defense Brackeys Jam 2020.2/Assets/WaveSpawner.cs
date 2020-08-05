using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
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
	public float timeBettweenWaves = 5f;
	public float wavecountdown;
	private float searchcountdown = 1f;

	private SpawnState state = SpawnState.COUNTING;
	void Start()
	{
		wavecountdown = timeBettweenWaves;

	}
	void Update()
	{
		if (state == SpawnState.WAITING)
		{
			if (!EnemyIsAlive())
			{
				//begin a new round

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
		Instantiate(_enemy, transform.position, transform.rotation);
	}
}

