using UnityEngine;
using System.Collections;
using System.Collections.Generic ; 

public class PathFinding : MonoBehaviour
{

	public Transform seeker , target ; 

	GridClass grid ; 

	void Awake ()
	{
		//target = GameObject.Find ("");    add a tag or name for 
		grid = GetComponent <GridClass> (); 
	}

	void Update ()
	{
		FindPath (seeker.position , target.position); 	
	}

	void FindPath (Vector3 startPos , Vector3 targetPos )
	{
		NodeClass startNode  = grid.nodeFromWorldPoint (startPos);
		NodeClass targeNode = grid.nodeFromWorldPoint(targetPos) ; 

		// the set of nodes to be evaluated 
		List<NodeClass> openSet = new List <NodeClass>();
		// nodes that have been evaluated 
		HashSet <NodeClass> closedSet = new HashSet<NodeClass>();
		openSet.Add (startNode) ; 

		while (openSet.Count >0)
		{
			NodeClass currentNode = openSet[0];

			//to loop through all the nodes in the openSet
			for (int i = 1 ; i <openSet.Count ; i++)
			{
				if (openSet[i].fCost < currentNode.fCost|| openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost )
				{
					currentNode= openSet [i];
				}
			}
			openSet.Remove(currentNode);
			closedSet.Add (currentNode);

			//break point 
			if (currentNode == targeNode)
			{
				RetracePath (startNode , targeNode);
				return ; 
			}

			foreach (NodeClass neighbour in grid.GetNeighbors(currentNode))
			{
				if (!neighbour.walkable || closedSet.Contains(neighbour))
				{
					continue ; 
				}
				int newMovemntCostToNeighbour = currentNode.gCost + GetDistance(currentNode , neighbour);

				if (newMovemntCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
				{
					neighbour.gCost = newMovemntCostToNeighbour;
					//distance from the node to end node 
					neighbour.hCost = GetDistance (neighbour , targeNode);
					neighbour.parent = currentNode ; 
					if (!openSet.Contains (neighbour))
					{
						openSet.Add(neighbour) ; 
					}
				}
			}
		}
		Debug.Log ("Path finding successfull "); 
	}

	void RetracePath (NodeClass startNode ,NodeClass endNode)
	{
		List <NodeClass> path  = new List <NodeClass>();
		NodeClass currentNode = endNode ; 

		while (currentNode != startNode)
		{
			path.Add(currentNode);
			currentNode = currentNode.parent ;  
		}
		// the path is calculated in a revered manner thus it must be revesed 
		path.Reverse (); 

		grid.path = path ; 
		Debug.Log ("Retrace Path successfull "); 
	}

	int GetDistance (NodeClass nodeA , NodeClass nodeB)
	{
		int distX = Mathf.Abs (nodeA.gridX- nodeB.gridX);
		int distY = Mathf.Abs (nodeB.gridY- nodeB.gridY);

		if(distX> distY)
		{
			return 14*distY + 10*(distX - distY);
		}
		return 14*distX + 10*(distY - distX);

	}
}