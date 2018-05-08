using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManipulator : MonoBehaviour {

	public GameObject filledStar;
	public GameObject emptyStars;
	public Sprite filledStarSprite;
	public Sprite emptyStarSprite;

	Vector3 filledStarInitPos;

	void Start(){
		filledStarInitPos = filledStar.transform.position;
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
		MoveStar ();
	}

	void MoveStar(){
		filledStar.SetActive (true);
		iTween.MoveTo (filledStar,iTween.Hash("position" , emptyStars.transform.GetChild(0).position, "time" , 2,"oncomplete" , "Reset", "oncompletetarget", this.gameObject));


	}
	void Reset(){
		GameObject firstStar = emptyStars.transform.GetChild (0).gameObject;
		firstStar.GetComponent<Image> ().sprite = filledStarSprite;
		filledStar.SetActive (false);
		filledStar.transform.position = filledStarInitPos;
		Invoke ("ResetEmptyStars", 2f);

	}

	void ResetEmptyStars(){
		
		GameObject firstStar = emptyStars.transform.GetChild (0).gameObject;
		firstStar.GetComponent<Image> ().sprite = emptyStarSprite;
	}
}
