using UnityEngine;
using System.Collections;

public class Node : IHeapItem<Node>
{
	// to check if node is walkable or not 
	public bool isWalkable;
	public Vector3 worldPosition;
	public int gridX;
	public int gridY;

	public int gCost;
	public int hCost;
	public Node parent;
	int heapIndex;

	public Node(bool walkable, Vector3 worldPos, int _gridX, int _gridY)
	{
		isWalkable = walkable;
		worldPosition = worldPos;
		gridX = _gridX;
		gridY = _gridY;
	}

	public int fCost
	{
		get
		{
			return gCost + hCost;
		}
	}

	public int HeapIndex
	{
		get 
		{
			return heapIndex ; 
		}
		set 
		{
			heapIndex = value ; 
		}
	}
	public int CompareTo(Node nodeToCompare )
	{
		int compare = fCost.CompareTo(nodeToCompare.fCost) ; 
		if (compare == 0 )
		{
			compare = hCost.CompareTo(nodeToCompare.hCost);
		}
		return -compare ;	
	}
}