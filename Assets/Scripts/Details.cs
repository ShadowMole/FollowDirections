using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Details : MonoBehaviour {

    //Make sure to attach these Buttons in the Inspector
    public Button menu;

    public Slider diff;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        menu.onClick.AddListener(MainMenu);
    }

    void Update()
    {
        Data.Difficulty = (int) diff.value;
    }

    void MainMenu()
    {
        //Output this to console when the Button3 is clicked
        SceneManager.LoadScene("MazeMenu");
    }
}
