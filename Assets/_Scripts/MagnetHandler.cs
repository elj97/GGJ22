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

	private int magnetNumber;
	[SerializeField] private int maxMagnets;

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
		if ( Input.GetButtonDown("ToggleMagnet1") )
		{
			CycleMagnet();
		}

		if ( Input.GetButtonDown("ToggleMagnet2") )
		{
			CycleMagnet();
		}
	}

	void CycleMagnet()
	{
		if (magnetNumber >= maxMagnets)
		{
			magnetNumber = 0;
		}
		else
		{
			magnetNumber++;
		}

		switch ( magnetNumber )
		{
			case 0:
				magnetState = MagnetState.Positive;
				break;
			case 1:
				magnetState = MagnetState.Negative;
				break;
		}
	}
}
