using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button back;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        back.onClick.AddListener(ToMenu);
    }


    void ToMenu()
    {
        //Output this to console when Button1 or Button3 is clicked
        SceneManager.LoadScene("MazeMenu");
    }
}