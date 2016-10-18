using UnityEngine;
using System.Collections;
using System.Collections.Generic ; 
public class PathFinding : MonoBehaviour {

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

		List<NodeClass> openSet = new List <NodeClass>();



	}
	/*int GetDistance (NodeClass nodeA, NodeClass nodeB)
	{
		
	}*/
}
