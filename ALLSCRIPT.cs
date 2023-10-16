using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// TO EDIT TEXTMESHPRO TEXT follow the comments below
/*
	import TMPro;
	instantiate = 	public TextMeshProUGUI textmesh;	
	textmesh.text = "type text here";
	
 
 */



public class ALLSCRIPT : MonoBehaviour
{
	// setting the panel
	public GameObject homepanel;
	public GameObject quiz1;
	public GameObject quiz2;
	public GameObject quiz3;
	public GameObject quiz4;
	public GameObject quiz5;

	// the score
	private int Score;


	public TextMeshProUGUI textmeshCongrats;
	public TextMeshProUGUI textmeshTryagain;

	// results panel
	public GameObject results;
	public GameObject CongratsPanel;
	public GameObject TryAgainPanel;

	// to determin if the game is finished using update
	public bool finished;

	//SOUNDS = need to have audio source and audio clip
	public AudioSource src;
	public AudioClip correct, wrong;


	// Start is called before the first frame update
	void Start()
	{
		Score = 0;
		StartGame();
		finished = false;
	}

	// Update is called once per frame
	void Update()
	{
		// the boll finished returned true the game is finished
		if(finished == true)
		{
			GameFinished();
		}

	}
	public void RESTART()
	{
		StartGame();
	}
	public void StartHomebutton()
	{
		homepanel.SetActive(false);
		quiz1.SetActive(true);
	}
	public void Qpanel1()
	{
		quiz2.SetActive(true);
	}
	public void Qpanel2()
	{
		quiz3.SetActive(true);
	}
	public void Qpanel3()
	{
		quiz4.SetActive(true);
	}
	public void Qpanel4()
	{
		quiz5.SetActive(true);
	
	}
	public void Qpanel5()
	{
		SetFinishedState(true);
	}

	public void StartGame()
	{
		homepanel.SetActive(true);
		quiz1.SetActive(false);
		quiz2.SetActive(false);
		quiz3.SetActive(false);
		quiz4.SetActive(false);
		quiz5.SetActive(false);
	}

	
	// if the answer is correct
	public void Correct()
	{
		Score++;
		Debug.Log("Correct");
		src.clip = correct;
		src.Play();

	}


	//wrong answer
	public void Wrong()
	{
		Debug.Log("Wrong");
		src.clip = wrong;
		src.Play();
	}

	// game state to be called in update when methd public bool SetFinishedState is true
	public void GameFinished()
	{
		if (Score >= 3)
		{	
			results.SetActive(true);
			textmeshCongrats.text = $"SCORE: {Score} / 5";
			CongratsPanel.SetActive(true);
		}
		else if (Score <= 2)
		{
			results.SetActive(true);
			textmeshTryagain.text = $"SCORE: {Score} / 5";
			TryAgainPanel.SetActive(true);
		}
	}

	// return the bool in the update to be check by the game

	public void SetFinishedState(bool newState)
	{
		finished = newState;
	}

	public void Quitgame()
	{
		Application.Quit();
	}

	public void ToHome()
	{
		Score = 0;
		finished = false;
		homepanel.SetActive(true);
		CongratsPanel.SetActive(false);
		TryAgainPanel.SetActive(false);
		results.SetActive(false);
	}


}
