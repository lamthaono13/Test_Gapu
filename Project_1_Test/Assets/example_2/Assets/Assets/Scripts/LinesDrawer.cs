using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LinesDrawer : MonoBehaviour {

	public GameObject linePrefab;
	public LayerMask cantDrawOverLayer;
	int cantDrawOverLayerIndex;

	[Space ( 30f )]
	public Gradient lineColor;
	public float linePointsMinDistance;
	public float lineWidth;

	Line currentLine;

	[SerializeField] private Camera cam;

	//private List<Line> listCurrentLine;

	private bool interactable;

	//public UnityEvent OnEndDraw;

	void Start() {
		//cam = Camera.main;

		//listCurrentLine = new List<Line>();
	}

	public void Init()
    {
		//OnEndDraw = new UnityEvent();

		LevelManager.Instance.GameActionManager.StartCountAction.ActionAdd(() => { interactable = false; });

		cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawOver");

		interactable = true;
	}

	void Update() 
	{
        if (interactable)
        {
			if (Input.GetMouseButtonDown(0))
				BeginDraw();

			if (currentLine != null)
				Draw();

			if (Input.GetMouseButtonUp(0))
				EndDraw();
		}
	}

	// Begin Draw ----------------------------------------------

	void BeginDraw()
	{

		//listCurrentLine.Clear();

		currentLine = Instantiate ( linePrefab, this.transform ).GetComponent <Line> ( );

		//Set line properties
		currentLine.UsePhysics ( false );
		currentLine.SetLineColor ( lineColor );
		currentLine.SetPointsMinDistance ( linePointsMinDistance );
		currentLine.SetLineWidth ( lineWidth );

	}

	// Draw ----------------------------------------------------

	void Draw() 
	{
		Vector2 mousePosition = cam.ScreenToWorldPoint ( Input.mousePosition );

		//Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )
		RaycastHit2D hit = Physics2D.CircleCast ( mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer );

		if ( hit )
			EndDraw ( );
		else
			currentLine.AddPoint ( mousePosition );
	}

	// End Draw ------------------------------------------------

	void EndDraw() 
	{
		if (currentLine != null) 
		{
			if(currentLine.pointsCount < 2) 
			{
				//If line has one point
				Destroy(currentLine.gameObject);
				//currentLine = null;

			} else {
				//Add the line to "CantDrawOver" layer
				currentLine.gameObject.layer = cantDrawOverLayerIndex;

				//Activate Physics on the line
				currentLine.UsePhysics(true);

				currentLine = null;
			}
		}

		//OnEndDraw?.Invoke();

		LevelManager.Instance.GameActionManager.StartCountAction.ForceAction();
	}
}
