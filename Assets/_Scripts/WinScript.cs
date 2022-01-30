using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WinScript : MonoBehaviour
{
    public GameObject endGameUI;
    public GameObject player1;
    public GameObject player2;
    public AudioSource winSound;
    public AudioSource creditSound;
    public AudioSource themeMusic;

    public float timeLeft;
    private bool won;

    // Start is called before the first frame update
    void Start()
    {
        endGameUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (won)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft == 0)
            {
                creditSound.Play();
            }
        }*/
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player2")
        {
            endGameUI.gameObject.SetActive(true);
            winSound.Play();
            themeMusic.Stop();
            won = true;
            player1.gameObject.SetActive(false);
            player2.gameObject.SetActive(false);
        }
    }
}
