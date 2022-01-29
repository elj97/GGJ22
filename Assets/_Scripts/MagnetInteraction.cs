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

	private void Start()
	{
		MagnetH = GetComponent<MagnetHandler>();
		//mHAnimator = GetComponent<Animator>();
		pe2D = GetComponent<PointEffector2D>();

		//posMag1.SetActive(false);
		//negMag1.SetActive(false);
		//posMag2.SetActive(false);
		//negMag2.SetActive(false);
	}

	private void Update()
	{
		//if ( gameObject.tag == "Player1" )
		//{
			if ( MagnetH.PlayerMagnetState == MagnetHandler.MagnetState.Positive )
			{
				//posMag1.SetActive(true);
				//negMag1.SetActive(false);
				pe2D.forceMagnitude = -50;
			}
			else
			{
				//posMag1.SetActive(false);
				//negMag1.SetActive(true);
				pe2D.forceMagnitude = 50;
			}
		//}
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
