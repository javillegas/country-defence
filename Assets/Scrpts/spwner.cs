using UnityEngine;
using System.Collections;

public class spwner : MonoBehaviour {
	private float spawnTime ;		// The amount of time between each spawn.
	private float spawnDelay ;		// The amount of time before spawning starts.
	public GameObject enemie;		// Array of enemy prefabs.
	private GameController gameController;

	// Use this for initialization
	void Start () {
		spawnTime = Random.Range (5, 10);
		spawnDelay = Random.Range (3, 6);
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
		GameObject gameControllerObject = GameObject.Find("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

	}
	
	// Update is called once per frame
	void Spawn ()
	{
		// Instantiate a random enemy.
		//int enemyIndex = Random.Range(0, enemies.Length);
		if(!gameController.isGameOver())
			Instantiate(enemie, transform.position, transform.rotation);

	}
}
