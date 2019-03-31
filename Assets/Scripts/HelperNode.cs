using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HelperNode : IComparable {

    private MazeCell cell;

    private int priority;

    private HelperNode parent;

    private HelperNode rightChild, leftChild;

    private int g;

    private int h;
    private MazeCellEdge edge;

    public HelperNode(MazeCell c, int p, int g, int h, MazeCellEdge e)
    {
        cell = c;
        priority = p;
        this.g = g;
        this.h = h;
        edge = e;
    }

    public MazeCell getMazeCell()
    {
        return cell;
    }

    public int getPriority()
    {
        return priority;
    }

    public HelperNode getLeftChild()
    {
        return leftChild;
    }

    public HelperNode getRightChild()
    {
        return rightChild;
    }

    public void setLeftChild(HelperNode child)
    {
        leftChild = child;
    }

    public void setRightChild(HelperNode child)
    {
        rightChild = child;
    }

    public HelperNode getParent()
    {
        return parent;
    }

    public void setParent(HelperNode node)
    {
        parent = node;
    }

    public int CompareTo(object obj)
    {
        if(obj == null)
        {
            return 1;
        }

        HelperNode node = obj as HelperNode;

        if(node != null)
        {
            return priority.CompareTo(node.getPriority());
        }
        return 1;
    }

    public int getG()
    {
        return g;
    }

    public int getH()
    {
        return h;
    }

    public MazeCellEdge getEdge()
    {
        return edge;
    }

    public void setMazeCell(MazeCell cell)
    {
        this.cell = cell;
    }

    public void setPriority(int p)
    {
        priority = p;
    }

    public void setG(int g)
    {
        this.g = g;
    }

    public void setH(int h)
    {
        this.h = h;
    }

    public void setEdge(MazeCellEdge e)
    {
        edge = e;
    }
}
