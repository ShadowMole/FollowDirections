using UnityEngine;

public class Flag : MonoBehaviour {

    private MazeCell currentCell;

    public void SetLocation(MazeCell cell)
    {
        currentCell = cell;
        transform.localPosition = cell.transform.localPosition;
        currentCell.OnFlagSet();
        if (currentCell == null)
        {
            Debug.Log("Weird Shit");
        }
    }

    public MazeCell getCell()
    {
        return currentCell;
    }
}
