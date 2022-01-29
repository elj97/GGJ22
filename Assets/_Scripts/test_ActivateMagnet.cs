using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class test_ActivateMagnet : MonoBehaviour
{
    [SerializeField] private GameObject posMag;
	[SerializeField] private GameObject negMag;
	[SerializeField] private GameObject player;

	void Start()
	{
		posMag.SetActive(false);
		negMag.SetActive(false);
	}
    void Update()
	{
        if ( Input.GetButtonDown("Pos") )
		{
			posMag.SetActive(true);
			negMag.SetActive(false);
		}

		if ( Input.GetButtonDown("Neg") )
		{
			negMag.SetActive(true);
			posMag.SetActive(false);
		}
	}
}
