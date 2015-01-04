using UnityEngine;
using System.Collections;

public class FlyingEnemyControler : MonoBehaviour {
	private float moveSpeed;
	private Vector3 moveDirection;
	private int scoreValue = 0;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		moveSpeed = Random.Range (1, 15);

		moveDirection = Vector3.left;

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
	void Update () {
		Vector3 currentPosition = transform.position;
		Vector3 target = moveDirection * moveSpeed + currentPosition;
		transform.position = Vector3.Lerp( currentPosition, target, Time.deltaTime );
		if (gameController.isGameOver ())
						Destroy (gameObject);
		if (currentPosition.x < -5) {
			gameController.setGameOver();
				}
	//	Debug.Log (currentPosition.x);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		
		if (col.gameObject.tag == "Player" ) {
			scoreValue++;
			gameController.AddScore(scoreValue);
			Destroy (gameObject);
		}
	}

}
