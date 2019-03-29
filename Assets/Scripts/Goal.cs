using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	private MazeCell currentCell;

	public void SetLocation(MazeCell cell){
		currentCell = cell;
	}
}
