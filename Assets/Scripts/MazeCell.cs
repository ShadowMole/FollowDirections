using UnityEngine;

public class MazeCell : MonoBehaviour {

	public IntVector2 coordinates;

	private MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];

	private int initializedEdgeCount;

	public MazeRoom room;

    private bool isWinner;

	public void Initialize(MazeRoom room){
        isWinner = false;
		room.Add (this);
		transform.GetChild (0).GetComponent<Renderer> ().material = room.settings.floorMaterial;
	}

	public bool IsFullyInitialized{
		get{
			return initializedEdgeCount == MazeDirections.Count;
		}
	}

	public void SetEdge(MazeDirection direction, MazeCellEdge edge){
		edges[(int)direction] = edge;
		initializedEdgeCount++;
	}

	public MazeDirection RandomUninitializedDirection{
		get{
			int skips = Random.Range (0, MazeDirections.Count - initializedEdgeCount);
			for (int i = 0; i < MazeDirections.Count; i++) {
				if (edges [i] == null) {
					if (skips == 0) {
						return(MazeDirection)i;
					}
					skips--;
				}
			}
			throw new System.InvalidOperationException ("MazeCell has no uninitialized directions left.");
		}
	}

    public int getPassages()
    {
        int num = 0;
        foreach(MazeCellEdge edge in edges)
        {
            if(edge is MazePassage)
            {
                num++;
            }
        }
        return num;
    }

	public MazeCellEdge GetEdge(MazeDirection direction){
		return edges [(int)direction];
	}

    public MazeCellEdge[] GetEdges()
    {
        return edges;
    }

	public void OnPlayerEntered(){
		room.Show ();
		for (int i = 0; i < edges.Length; i++) {
			edges [i].OnPlayerEntered ();
		}
	}

    public void OnFlagSet()
    {
        isWinner = true;
    }

	public void OnPlayerExited(){
		room.Hide ();
		for (int i = 0; i < edges.Length; i++) {
			edges [i].OnPlayerExited ();
		}
	}

    public bool getIsWinner()
    {
        return isWinner;
    }

	public void Show(){
		//gameObject.SetActive (true);
	}

	public void Hide(){
		//gameObject.SetActive (false);
	}
}
