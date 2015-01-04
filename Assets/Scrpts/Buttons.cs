using UnityEngine;
using System.Collections;
using System;
public class Buttons : MonoBehaviour {
	private string buttonText = "Score";
	private GameController gameController;

	WWW internet;
	void Start () {
		// Select the Google Play Games platform as our social platform implementation
		GooglePlayGames.PlayGamesPlatform.Activate();
		AdBuddizBinding.SetAndroidPublisherKey (
			"da456d00-d86e-4c9d-9c2b-5405bd14f3b0");
		AdBuddizBinding.CacheAds();
		GameObject gameControllerObject = GameObject.Find("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
		AdBuddizBinding.ShowAd();


	}
	void Auth(){
		buttonText = "Authenticating...";

		Social.localUser.Authenticate ((bool success) => {
			//mWaitingForAuth = false;
			if(success)
				SubmitScote();
			else
			buttonText = "Authentication failed.";
		});

	}

	void SubmitScote(){
		buttonText = "Submiting Score...";
		Social.ReportScore(gameController.score, "CgkI9u-u__sCEAIQAQ", (bool success) => {
			if(success)
				buttonText = "Score";
			Social.ShowLeaderboardUI();
		});
		 }
	void OnGUI () {
		GUIStyle customButton = new GUIStyle();
		customButton.fontSize = 50;
		GUIStyle customLabel = new GUIStyle("Game Over");
		customLabel.fontSize = 100;

		int xSize = Screen.width/2-50;
		int ySize = Screen.height / 2;
		// Make a background box
				if (gameController.isGameOver ()) {
			GUI.Label (new Rect (xSize-50, ySize-90, 10, 10), "Game Over",customLabel);
		
			if (GUI.Button (new Rect (xSize, Screen.height/2 + 10, 100, 100), buttonText,customButton)) {
								if (!Social.localUser.authenticated) {
										// Authenticate
									Auth();
								}
				else{
					SubmitScote();
				}


						}
		
						// Make the second button.
			if (GUI.Button (new Rect (xSize, Screen.height/2 + 100, 100, 100), "Restart",customButton)) {
				Application.LoadLevel (0);
				AdBuddizBinding.ShowAd();
								//Social.ShowLeaderboardUI ();

								//((GooglePlayGames.PlayGamesPlatform) Social.Active).SignOut();
								/*(Social.ReportScore(111100, "CgkI9u-u__sCEAIQAQ", (bool success) => {
				if(success)
					buttonText = "me";
				Social.ShowLeaderboardUI();
			});*/

						}
				}
		}

	}