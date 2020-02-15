﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    int destination;
    float weight;

    public Edge(int destination, float weight)
    {
        this.destination = destination;
        this.weight = weight;
    }

    public int GetDestination()
    {
        return destination;
    }

    public float Getweight()
    {
        return weight;
    }
}

public class GridGraph
{
    public List<List<Edge>> nodes = new List<List<Edge>>();

    protected int width, height;

    protected int defaultweight = 1;

    protected int currentNode;


    public List<int> GetNeighbors(int v)
    {
        List<int> neighbors = new List<int>();

        foreach (Edge edge in nodes[v])
        {
            neighbors.Add( edge.GetDestination() );
        }

        return neighbors;
    }

    public int GetWeight(int u, int v)
    {
        return 1;
    }

    public int GetNodesQuantity()
    {
        return nodes.Count;
    }

    protected GridGraph()
    {

    }

    public GridGraph(int width, int heigth)
    {
        this.width = width;
        this.height = heigth;

        MountGraph();
    }

    protected void MountGraph()
    {
        InitializeWithEmptyLists();
        PopulateLists();
    }

    protected void InitializeWithEmptyLists()
    {
        //zero is a sentinel.
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                nodes.Add(new List<Edge>());
            }
        }
    }

    protected void PopulateLists()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                ConfigureEdges(i, j);
            }
        }
    }

    protected void ConfigureEdges(int i, int j)
    {
        currentNode = CalculateCurrentNode(i, j);

        AddToGraph(GetLeft(currentNode), condition: JHasLeft(j));

        AddToGraph(GetRight(currentNode), condition: JHasRight(j));

        AddToGraph(GetUp(currentNode), condition: IHasUp(i));

        AddToGraph(GetDown(currentNode), condition: IHasDown(i));
    }

    public int CalculateCurrentNode(int i, int j)
    {
        return i * width + j;
    }

    protected void AddToGraph(int destination, bool condition)
    {
        if (condition)
        {
            nodes[currentNode].Add(new Edge(destination, defaultweight));
        }
    }

    protected int GetLeft(int node)
    {
        return node - 1;
    }

    protected int GetRight(int node)
    {
        return node + 1;
    }

    protected int GetUp(int node)
    {
        return node - width;
    }

    protected int GetDown(int node)
    {
        return node + width;
    }

    protected bool JHasLeft(int j)
    {
        return j > 0;
    }

    protected bool JHasRight(int j)
    {
        return j < width-1;
    }

    protected bool IHasUp(int i)
    {
        return i > 0;
    }

    protected bool IHasDown(int i)
    {
        return i < height-1;
    }

}