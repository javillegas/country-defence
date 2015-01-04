using UnityEngine;
using System.Collections;

public class BulletFull : MonoBehaviour {
	public float moveSpeed=1;
	private int scoreValue = 0;
	private Vector3 moveDirection;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		moveDirection = Vector3.left;
		GameObject gameControllerObject = GameObject.Find("GameController");
		gameController = gameControllerObject.GetComponent <GameController> ();


	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;
		Vector3 target = moveDirection * moveSpeed + currentPosition;
		transform.position = Vector3.Lerp( currentPosition, target, Time.deltaTime );
		if (gameController.isGameOver ())
			Destroy (gameObject);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		
				if (col.gameObject.tag == "Player") {
			gameController.increaseBulit();
			Destroy (gameObject);

		}
		}
}
