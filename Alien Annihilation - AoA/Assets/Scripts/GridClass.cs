using UnityEngine;
using System.Collections;

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
				grid[x,y] = new NodeClass(walkable,worldPoint);
			}
		}
	}

	public NodeClass nodeFromWorldPoint(Vector3 worldPosition) {
		float percentX = (worldPosition.x + gridWorldSize.x/2) / gridWorldSize.x;
		float percentY = (worldPosition.z + gridWorldSize.y/2) / gridWorldSize.y;
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizeX-1) * percentX);
		int y = Mathf.RoundToInt((gridSizeY-1) * percentY);
		return grid[x,y];
	}


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

	public NodeClass (bool isWalkable , Vector3 worldPos )
	{
		walkable = isWalkable ;
		worldPosition = worldPos ; 
	}

}
