using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;

	private Maze mazeInstance;

	public Player playerPrefab;

	private Player playerInstance;

    public Flag flagPrefab;

    private Flag flagInstance;

	// Use this for initialization
	private void Start () {
		StartCoroutine(BeginGame ());
	}
	
	// Update is called once per frame
	private void Update () {
        if (playerInstance != null && playerInstance.getCurrentCell().getIsWinner())
        {
            SceneManager.LoadScene("WinScene");
        }
		if (Input.GetKeyDown (KeyCode.Space)) {
			RestartGame ();
		}
	}

	private IEnumerator BeginGame(){
		Camera.main.clearFlags = CameraClearFlags.Skybox;
		Camera.main.rect = new Rect (0f, 0f, 1f, 1f);
		mazeInstance = Instantiate (mazePrefab) as Maze;
		yield return StartCoroutine(mazeInstance.Generate ());
        flagInstance = Instantiate(flagPrefab) as Flag;
        flagInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
        playerInstance = Instantiate (playerPrefab) as Player;
		playerInstance.SetLocation (mazeInstance.GetCell (mazeInstance.RandomCoordinates));
        playerInstance.getHelper().setFlagCell(flagInstance.getCell());
        Camera.main.clearFlags = CameraClearFlags.Depth;
		Camera.main.rect = new Rect (0f, 0f, .5f, .5f);
	}

	private void RestartGame(){
		StopAllCoroutines ();
		Destroy (mazeInstance.gameObject);
		if (playerInstance != null) {
			Destroy (playerInstance.gameObject);
		}
        if (flagInstance != null)
        {
            Destroy(flagInstance.gameObject);
        }
        StartCoroutine(BeginGame ());
	}
}
