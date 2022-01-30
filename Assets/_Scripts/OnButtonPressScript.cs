using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnButtonPressScript : MonoBehaviour
{
    public GameObject instructions;

    /*void Start()
    {
        instructions.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey("escape") && !instructions) //esc key assigned in input manager
            instructions.SetActive(true);

        else
            instructions.SetActive(false);
    }*/
    public void OnButtonPressPlay() //play game
    {
        SceneManager.LoadScene("Level_One");
    }

    public void OnButtonPressQuit() //quit game
    {
        Application.Quit();
    }

    public void OnButtonNextLvlTwo() //quit game
    {
        SceneManager.LoadScene("Level_Two");
    }

    public void OnButtonPressNxtLvlThree()
    {
        SceneManager.LoadScene("Level_Three");
    }
}
