using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MazeWallWithPainting : MazeWall {

    public Transform painting;

    public Material black;
    public Material[] white;

    public override void Initialize(MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        base.Initialize(cell, otherCell, direction);
        if(cell.room.settingsIndex == 0)
        {
            painting.GetComponent<Renderer>().material = black;
        }else
        {
            System.Random rng = new System.Random();
            painting.GetComponent<Renderer>().material = white[rng.Next(2)];
        }
    }
}
