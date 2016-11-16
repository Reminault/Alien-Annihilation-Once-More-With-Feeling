using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class NodeCs : MonoBehaviour {


	List <NodeCs> children = new List<NodeCs>();

	State state; 
	enum State 
	{
		Success,
		Failure, 
		Running
	}
	// Use this for initialization

	public virtual void currentBehaviour()
	{

	}

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Succeed ()
	{
		state = State.Success;
	}

	public void Fail()
	{
		state = State.Failure;
	}

	public void Running ()
	{
		state = State.Running;
	}

	public void AddChild (NodeCs node) 
	{
		children.Add (node);
	}

	public bool isSuccessful()
	{

		return this.state.Equals (State.Success); 

	}

	public bool hasFailed () 
	{

		return this.state.Equals (State.Failure); 
	}

	public bool isRunning () 
	{
		
		return this.state.Equals (State.Running); 

	}
}
