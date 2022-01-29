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
	Animator mAnimator;

	public enum MagnetState
	{
		Positive,
		Negative
	}

	void Start()
	{
		mAnimator = GetComponent<Animator>();
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
				AnimMagnetState();
				break;
			case 1:
				magnetState = MagnetState.Negative;
				AnimMagnetState();
				break;
		}
	}
	private void AnimMagnetState()
	{
		if ( PlayerMagnetState == MagnetState.Positive )
		{
			mAnimator.SetBool("Positive", true);
		}
		if ( PlayerMagnetState == MagnetState.Negative )
		{
			mAnimator.SetBool("Positive", false);
		}
	}
	//TODO: not working, something here is wrong with animmagetstate()
}
