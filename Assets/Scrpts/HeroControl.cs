using UnityEngine;
using System.Collections;

public class HeroControl : MonoBehaviour {
	private Animator anim ;
	public Camera camera;
	private GameController gameController;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
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
				if (!gameController.isGameOver()) {

						//if(anim.GetBool("shoot") == true)
						anim.SetBool ("shoot", false);
						anim.SetBool ("shootUp", false);

						if (Input.GetButtonDown ("Fire1") && !gameController.isGameOver ()) {
								Vector3 pz = camera.ScreenToWorldPoint (Input.mousePosition);
				gameObject.audio.Play();
								//Give triger to animate shooting hero
								if (pz.y > 0.7)
										anim.SetBool ("shootUp", true);
								else
										anim.SetBool ("shoot", true);
								//Disable triger so animatioN WILL NOT LOOP

						}
				}
	}
}
