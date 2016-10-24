using UnityEngine;
using System.Collections;
using System.Collections.Generic ; 

public class GridClass : MonoBehaviour {

	// layer mask to avoid for pathfinding 
	public LayerMask unwalkableMask;
	public Vector2 gridWorldSize;
	public float nodeRadius;
	NodeClass[,] grid;

	// controlls size of each grid node 
	float nodeDiameter;
	int gridSizeX, gridSizeY;

	 void Start() {
		nodeDiameter = nodeRadius*2;
		// to make sure there is not havf a interger we are using the round method 
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x/nodeDiameter);
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y/nodeDiameter);
		CreateGrid();
	}

	void CreateGrid() {
		grid = new NodeClass[gridSizeX,gridSizeY];
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;

		for (int x = 0; x < gridSizeX; x ++) {
			for (int y = 0; y < gridSizeY; y ++) {
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
				// to check for collisions with cubes 
				bool walkable = !(Physics.CheckSphere(worldPoint,nodeRadius,unwalkableMask));
				// creates new node 
				grid[x,y] = new NodeClass(walkable,worldPoint ,x,y );
			}
		}
	}

	//TO convert node positions to world positions 
	public NodeClass nodeFromWorldPoint(Vector3 worldPosition) {
		float percentX = (worldPosition.x + gridWorldSize.x/2) / gridWorldSize.x;
		float percentY = (worldPosition.z + gridWorldSize.y/2) / gridWorldSize.y;
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizeX-1) * percentX);
		int y = Mathf.RoundToInt((gridSizeY-1) * percentY);
		return grid[x,y];
	}


	public List <NodeClass> GetNeighbors (NodeClass node )
	{
		List  <NodeClass> neighbors = new List<NodeClass> ();
		for (int x =-1 ;x<=1 ; x++  )
		{
			for (int y =-1 ;y<=1 ; y++  )
			{
				if (x == 0 &&y==0)
				{
					continue ; 
				}
				int checkX = node.gridX;
				int checkY = node.gridY;
				if (checkX >=0 && checkX <gridSizeX && checkY >=0&& checkY < gridSizeY)
				{
					neighbors.Add(grid [checkX,checkY]);
				}
			}
		}
		return neighbors ; 
	}
	public List <NodeClass> path ; 


	// draws 2 gizmos one to dtermine the outer range of the gizmos being drawn within it and anither to fraw thr smaller gizmos within it 
	void OnDrawGizmos()
	{
		// y will be Z becuase it is a top down view . so in 3d space y will be z 
		Gizmos.DrawWireCube(transform.position,new Vector3(gridWorldSize.x,1,gridWorldSize.y));
		if (grid != null)
		{
			foreach (NodeClass n in grid)
			{
				Gizmos.color = (n.walkable)?Color.white:Color.red;
				if (path != null)
				{
					if (path.Contains(n))
					{
						Gizmos.color = Color.cyan ; 
					}
				}

				//the -0.1f is too have space between the cubes 
				//todo make the spaceing var public 
				Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-0.1f));
			}
		}
	}
}
public class NodeClass 
{

	public bool walkable ;
	public Vector3 worldPosition;

	// Used to keep track of each individual node 
	public int gridX ;
	public int gridY;


	public int gCost ;
	public int hCost ;

	public NodeClass parent ;

	public NodeClass (bool isWalkable , Vector3 worldPos , int _gridX ,  int _gridY)
	{
		walkable = isWalkable ;
		worldPosition = worldPos ; 
		gridX = _gridX;
		gridY = _gridY;
	}


	//to get the cost of movement 
	public int fCost 
	{
		get
		{
			return gCost+hCost ;
		}
	}

}
