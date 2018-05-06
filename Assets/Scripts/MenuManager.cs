using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	#region Variables
	[HideInInspector]
	public static MenuManager instance = null;      //instace of this class to create a singleton pattern 

	public Text scoreText;
	public ScoreManipulator scoreManipulator;
	public ScoreAdder scoreAdder;
	public int score;

	#endregion
	void Awake() {
		
		if (instance == null){
			instance = this;
		}else if (instance != this){
			Destroy (gameObject);
		}
			
		DontDestroyOnLoad(gameObject);

	}

	void Start () {
		score = Random.Range (1000, 9000);     //randomly generate score inititally since there is no game to generate score yet.
		scoreText.text = score.ToString();
	}
	

	void Update () {
		scoreText.text = score.ToString ();
	}

	//handles click for the ADD TO SCORE button
	public void AddToScoreClickHandler(){		
		scoreAdder.GenerateScore ();
	}


}
