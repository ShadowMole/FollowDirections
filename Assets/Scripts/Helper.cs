using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Helper{

    private MazeCell currentCell;

    private MazeCell flagCell;

    public Directions text;

    public void setCurrentCell(MazeCell cell)
    {
        currentCell = cell;
    }

    public void setFlagCell(MazeCell cell)
    {
        flagCell = cell;
        if(flagCell == null)
        {
            //Debug.Log("?Why?");
        }
    }

    public void help()
    {
        //Debug.Log("HELP!!!");
        if (currentCell.getPassages() > 2)
        {
            MazeCellEdge suggest = currentCell.GetEdges()[1];
            PriorityQueue<HelperNode> open = new PriorityQueue<HelperNode>();
            PriorityQueue<HelperNode> closed = new PriorityQueue<HelperNode>();
            open.Enqueue(new HelperNode(currentCell, getDistance(currentCell), 0, getDistance(currentCell), currentCell.GetEdges()[1]));
            bool flag = false;
            while (!flag && !open.isEmpty())
            {
                HelperNode q = open.Dequeue();
                foreach(MazeCellEdge edge in q.getMazeCell().GetEdges())
                {
                    if (edge is MazePassage)
                    {
                        MazeCell newCell = edge.otherCell;
                        int g = q.getG() + 1;
                        int h = getDistance(newCell);
                        int f = g + h;
                        MazeCellEdge e;
                        if(q.getMazeCell() == currentCell)
                        {
                            e = edge;
                        }else
                        {
                            e = q.getEdge();
                        }
                        if (newCell.getIsWinner())
                        {
                            flag = true;
                            suggest = e;
                            break;
                        }
                        if(!(open.contains(newCell, f) || closed.contains(newCell, f)))
                        {
                            open.Enqueue(new HelperNode(newCell, f, g, h, e));
                            //Debug.Log("New Node");
                        }
                    }
                }
                closed.Enqueue(new HelperNode(q.getMazeCell(), q.getPriority(), q.getG(), q.getH(), q.getEdge()));
                //Debug.Log("Bye Node");
            }
            //Do fun gui stuff
            Debug.Log(suggest.direction);
            System.Random rng = new System.Random();
            int helper;
            if(Data.Difficulty == 1)
            {
                helper = 1;
            }else if(Data.Difficulty == 2)
            {
                helper = rng.Next(1, 5);
            }else
            {
                helper = rng.Next(1, 9);
            }
            string s = "Helper " + helper + " Suggests:\nGo ";
            switch (suggest.direction)
            {
                case MazeDirection.North:
                    if(helper == 1 || helper == 5)
                    {
                        s += "Up";
                    }else if(helper == 3 || helper == 7)
                    {
                        s += "Down";
                    }else if(helper == 2 || helper == 8)
                    {
                        s += "Right";
                    }else
                    {
                        s += "Left";
                    }
                    break;
                case MazeDirection.East:
                    if (helper == 4 || helper == 8)
                    {
                        s += "Up";
                    }
                    else if (helper == 2 || helper == 6)
                    {
                        s += "Down";
                    }
                    else if (helper == 1 || helper == 7)
                    {
                        s += "Right";
                    }
                    else
                    {
                        s += "Left";
                    }
                    break;
                case MazeDirection.South:
                    if (helper == 3 || helper == 7)
                    {
                        s += "Up";
                    }
                    else if (helper == 1 || helper == 5)
                    {
                        s += "Down";
                    }
                    else if (helper == 4 || helper == 6)
                    {
                        s += "Right";
                    }
                    else
                    {
                        s += "Left";
                    }
                    break;
                default:
                    if (helper == 2 || helper == 6)
                    {
                        s += "Up";
                    }
                    else if (helper == 4 || helper == 8)
                    {
                        s += "Down";
                    }
                    else if (helper == 3 || helper == 5)
                    {
                        s += "Right";
                    }
                    else
                    {
                        s += "Left";
                    }
                    break;
            }
            text.newDirection(s);
        }
    }

    public int getDistance(MazeCell cell)
    {
        if(cell == null)
        {
            //Debug.Log("Cell");
        }
        else if(flagCell == null)
        {
            //Debug.Log("Flag");
        }else
        {
            //Debug.Log(cell.coordinates.x + " " + cell.coordinates.z + " " + flagCell.coordinates.x + " " + flagCell.coordinates.z);
        }
        return (Math.Abs(cell.coordinates.x - flagCell.coordinates.x) + Math.Abs(cell.coordinates.z - flagCell.coordinates.z));
    }

    public void setText(Directions t)
    {
        text = t;
        if (text != null)
        {
            //Debug.Log("Working");
        }
    }
}
