using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreAdder : MonoBehaviour {


	private int generatedScore;
	private GameObject number;
	//generates a random number to be added to the current value of score.
	public void GenerateScore(){
		generatedScore = Random.Range (100, 500);
		MoveToScore ();
	}

	//move the generated number text to merge with the original score.
	void MoveToScore(){
		number = this.transform.GetChild (1).gameObject;
		number.gameObject.SetActive (true);
		number.GetComponent<Text> ().text = generatedScore.ToString();
		iTween.MoveTo (number,iTween.Hash("position" , MenuManager.instance.scoreText.gameObject.transform.position, "time" , 1,"oncomplete" , "Reset", "oncompletetarget", this.gameObject));

	}
	//reset the position of the travelling number and make the original score update.
	void Reset(){
		number.SetActive (false);
		MenuManager.instance.scoreManipulator.addScore (generatedScore);
		number.transform.localPosition = new Vector3 (0, 0, 0);
	}
}
