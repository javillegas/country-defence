using UnityEngine;
using System.Collections;

public class BulletFullSpawn : MonoBehaviour {
	public float spawnTime = 1;		// The amount of time between each spawn.
	public GameObject enemie;		// Array of enemy prefabs.
	private GameController gameController;
	
	// Use this for initialization
	void Start () {
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
	void Update ()
	{
		// Instantiate a random enemy.
		//int enemyIndex = Random.Range(0, enemies.Length);
		if(gameController.ShouldCharged())
			Instantiate(enemie, transform.position, transform.rotation);
		
	}
}
