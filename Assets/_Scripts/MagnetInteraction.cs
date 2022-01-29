using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetInteraction : MonoBehaviour
{
    private MagnetHandler MagnetH;
	Animator mHAnimator;

	[SerializeField] private GameObject posMag1;
	[SerializeField] private GameObject negMag1;
	[SerializeField] private GameObject posMag2;
	[SerializeField] private GameObject negMag2;

	private void Start()
	{
		MagnetH = GetComponent<MagnetHandler>();
		mHAnimator = GetComponent<Animator>();

		posMag1.SetActive(false);
		negMag1.SetActive(false);
		posMag2.SetActive(false);
		negMag2.SetActive(false);
	}

	private void Update()
	{

	}
}
