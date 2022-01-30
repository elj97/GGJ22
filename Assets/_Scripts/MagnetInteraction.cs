using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetInteraction : MonoBehaviour
{
    private MagnetHandler MagnetH;
	//Animator mHAnimator;

	//[SerializeField] private GameObject posMag1;
	//[SerializeField] private GameObject negMag1;
	//[SerializeField] private GameObject posMag2;
	//[SerializeField] private GameObject negMag2;

	private PointEffector2D pe2D;

	private MagnetHandler otherPlayerMagnetH;
	private GameObject otherPlayer;

	[SerializeField] private float howFarAway;

	[SerializeField] private float forceMagnitude;

	private void Start()
	{
		MagnetH = GetComponent<MagnetHandler>();
		//mHAnimator = GetComponent<Animator>();
		pe2D = GetComponent<PointEffector2D>();

		string otherPlayerString = "Player1";

		if (this.tag == "Player1")
		{
			otherPlayerString = "Player2";
		}


		otherPlayer = GameObject.FindWithTag(otherPlayerString);

		otherPlayerMagnetH = otherPlayer.GetComponent<MagnetHandler>();

		//posMag1.SetActive(false);
		//negMag1.SetActive(false);
		//posMag2.SetActive(false);
		//negMag2.SetActive(false);
	}

	private void Update()
	{
		if (Mathf.Abs(Vector3.Distance(otherPlayer.transform.position, transform.position)) > howFarAway)
		{
			if ( MagnetH.PlayerMagnetState == MagnetHandler.MagnetState.Positive && otherPlayerMagnetH.PlayerMagnetState == MagnetHandler.MagnetState.Positive || MagnetH.PlayerMagnetState == MagnetHandler.MagnetState.Negative && otherPlayerMagnetH.PlayerMagnetState == MagnetHandler.MagnetState.Negative )
			{
				//posMag1.SetActive(true);
				//negMag1.SetActive(false);
				pe2D.forceMagnitude = forceMagnitude;
			}
			else
			{
				//posMag1.SetActive(false);
				//negMag1.SetActive(true);
				pe2D.forceMagnitude = -forceMagnitude;
			}
		}
		else
		{
			pe2D.forceMagnitude = 0;
		}
		/*
		if ( gameObject.tag == "Player2" )
		{
			if ( MagnetH.PlayerMagnetState == MagnetHandler.MagnetState.Positive )
			{
				//posMag2.SetActive(true);
				//negMag2.SetActive(false);
				pe2D.forceMagnitude = -50;
			}
			else
			{
				//posMag2.SetActive(false);
				//negMag2.SetActive(true);
				pe2D.forceMagnitude = 50;
			}
		}*/
	}
}
