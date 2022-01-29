using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_ActivateMagnet : MonoBehaviour
{
    public GameObject posMag;
    public GameObject negMag;
	public GameObject player;

	void Start()
	{
		posMag.SetActive(false);
		negMag.SetActive(false);
	}
    void Update()
	{
        if ( Input.GetButtonDown("Pos") )
		{
			Instantiate(posMag, transform.position, Quaternion.identity);
			posMag.transform.SetParent(player.transform);
			posMag.SetActive(true);

			
		}

		if ( Input.GetButtonDown("Neg") )
		{
			Instantiate(negMag, transform.position, Quaternion.identity);
			negMag.transform.SetParent(player.transform);
			negMag.SetActive(true);
		}
	}
}
