using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManipulator : MonoBehaviour {


	void Start(){
		
	}

	public void addScore(int scoreToAdd){
		StartCoroutine (UpdateScoreOverTime(scoreToAdd));
	}
	//give the effect of score being updated over time.
	IEnumerator UpdateScoreOverTime(int scoreToAdd){
		int initScore = MenuManager.instance.score;
		while(MenuManager.instance.score < (scoreToAdd+initScore)){
			MenuManager.instance.score += 25;
			yield return new WaitForSeconds (0.02f);
		}
		MenuManager.instance.score = scoreToAdd + initScore;
	}
}
