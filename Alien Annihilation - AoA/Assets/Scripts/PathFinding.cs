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
		
	}

	void FindPath (Vector3 startPos , Vector3 targetPos )
	{
		NodeClass startNode  = grid.nodeFromWorldPoint (startPos);
		NodeClass targeNode = grid.nodeFromWorldPoint(targetPos) ; 

		// the set of nodes to be evaluated 
		List<NodeClass> openSet = new List <NodeClass>();
		// nodes that have been evaluated 
		HashSet <NodeClass> closedSet = new HashSet<NodeClass>();


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
				return ; 
			}
		}


	}
	/*int GetDistance (NodeClass nodeA, NodeClass nodeB)
	{
		
	}*/
}
