using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetHandler : MonoBehaviour
{
	//private GameObject posMag;
	//private GameObject negMag;
	private GameObject player;
	public MagnetState PlayerMagnetState { get { return magnetState; } }

	private MagnetState magnetState;

	public enum MagnetState
	{
		Positive,
		Negative
	}

	void Start()
	{
		//posMag.SetActive(false);
		//negMag.SetActive(false);
	}
	void Update()
	{
		if ( Input.GetButtonDown("Pos") )
		{
			magnetState = MagnetState.Positive;
			//posMag.SetActive(true);
			//negMag.SetActive(false);
		}

		if ( Input.GetButtonDown("Neg") )
		{
			magnetState = MagnetState.Negative;
			//negMag.SetActive(true);
			//posMag.SetActive(false);
		}
	}
}
