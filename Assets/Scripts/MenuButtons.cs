using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button start, instructions, quit;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        start.onClick.AddListener(StartGame);
        instructions.onClick.AddListener(ShowInstructions);
        quit.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        //Output this to console when Button1 or Button3 is clicked
        SceneManager.LoadScene("MainScene");
    }

    void ShowInstructions()
    {
        //Output this to console when the Button2 is clicked
        SceneManager.LoadScene("Details");
    }

    void QuitGame()
    {
        //Output this to console when the Button3 is clicked
        Application.Quit();
    }
}