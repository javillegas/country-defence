using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GUIText scoreText;
	public GUIText bullitText;
	public long score;
	private int bulits;
	private bool gameOver = false;
	private bool isCharged = false;
	// Use this for initialization
	void Start () {
		score = 0;
		updateScore ();
		bulits = 10;
		updateBulit ();
	}
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		updateScore ();
	}
	
	void updateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	void updateBulit(){
		bullitText.text =""+ bulits;
		}
	public void decreaseText()
	{
		bulits -= 1;
		updateBulit ();
	}

	public void increaseBulit(){
		bulits += 10;
		isCharged = false;
		updateBulit ();
	}
	public bool isGameOver(){
		if (bulits < 0 || gameOver)
			return true;
		else
			return false;

		}
	public int getBullitsNumber(){
		return bulits;
	}
	public bool ShouldCharged(){
		if (bulits == 2 && !isCharged) {
						isCharged = true;
						return true;
				}
		return false;
		}
	public void setGameOver(){
		gameOver = true;
		}

}
