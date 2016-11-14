using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System ; 
// the A* implemented here is based on the article in the website below and is a heavily upgraded implmetaiton of it 
//http://www.policyalmanac.org/games/aStarTutorial.htm


public class Pathfinding : MonoBehaviour {

	//public Transform seeker, target;
	PathRequestManager requestManager ;
	Grid grid;

	void Awake()
	{
		grid = GetComponent<Grid> ();
		requestManager = GetComponent <PathRequestManager>(); 
	}

	/*void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
		FindPath (seeker.position, target.position);
		}
	}*/
	//to be called in order to start path
	public void StartFindPath (Vector3 startPos , Vector3 targetPos )
	{
		StartCoroutine (FindPath (startPos , targetPos));
	}
	//todo convert to a coroutine
	IEnumerator FindPath(Vector3 startPos, Vector3 targetPos)
	{
		 Vector3 [] wayPoints = new Vector3[0];
		bool pathSucess  = false; 
		Debug.Log ("Starting FINDPATH"); 



		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);

		if (startNode.isWalkable&& targetNode.isWalkable)
		{
		Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);


			while (openSet.Count > 0)
			{
				Node currentNode = openSet.RemoveFirst();
				closedSet.Add(currentNode);

				if (currentNode == targetNode)
				{
					pathSucess = true ; 
					break; 
				}

				foreach (Node neighbour in grid.GetNeighbours(currentNode))
				{
					if (!neighbour.isWalkable || closedSet.Contains(neighbour))
					{
						continue;
					}

					int newCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
					if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
					{
						neighbour.gCost = newCostToNeighbour;
						neighbour.hCost = GetDistance(neighbour, targetNode);
						neighbour.parent = currentNode;

						if (!openSet.Contains(neighbour))
						{
							openSet.Add(neighbour);
							Debug.Log ("Updateing openset with new neighbor "); 
						}
						else 
						{
							openSet.UpdateItem(neighbour);
							Debug.Log ("Updateing openset"); 
						}
					}
				}
			}
	}
		yield return null;
		if (pathSucess )
		{
			wayPoints  = RetracePath(startNode,targetNode);
		}
		requestManager.FinsishedProcessingPath (wayPoints , pathSucess);

	}

	// the A* calculations are done from target to this objects position thus this mehtod is to reverse this 
	Vector3 [] RetracePath(Node startNode, Node endNode)
	{
		List<Node> path = new List<Node>();
		Node currentNode = endNode;

		while (currentNode != startNode)
		{
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		Vector3[] waypoints =  SimplifyPath (path);
		Array.Reverse (waypoints);
		return waypoints ; 
	}

	Vector3 [] SimplifyPath (List <Node> path)
	{
		List<Vector3 > waypoints = new List <Vector3>();
		Vector2 directionOld = Vector2.zero ;

		for (int i = 1 ; i < path.Count ; i++)
		{
			Vector2 directionNew = new Vector2 (path[i-1].gridX - path[i].gridX , path[i-1].gridY - path[i].gridY);
			if (directionNew != directionOld)
			{
				waypoints.Add (path [i].worldPosition);
				directionNew = directionOld ; 
			}
		}
		//converts list to an array 
		return waypoints.ToArray ();
	}

	int GetDistance(Node nodeA, Node nodeB)
	{
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if (dstX >= dstY)
		{
			return 14*dstY + 10* (dstX-dstY);
		}
		return 14*dstX + 10 * (dstY-dstX);
	}
}
