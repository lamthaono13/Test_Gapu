using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LinesDrawer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{

	public GameObject linePrefab;
	public LayerMask cantDrawOverLayer;
	int cantDrawOverLayerIndex;

	[Space ( 30f )]
	public Gradient lineColor;
	public float linePointsMinDistance;
	public float lineWidth;

	Line currentLine;

	private Camera cam;

	private bool interactable;

	private bool isInInteractZone;

	Vector2 positionTouch;

	private bool canCheck;

	void Start() 
	{
		Init();
	}

	public void Init()
    {
		//OnEndDraw = new UnityEvent();

		cam = LevelManager.Instance.CameraGame;

		LevelManager.Instance.MapManager.MapActionManager.GetAction((int)DrawGameAction.StartCount).ActionAdd(() => { interactable = false; });

		cantDrawOverLayerIndex = LayerMask.NameToLayer("Object");

		//isInInteractZone = true;

		interactable = true;
	}

	void Update() 
	{
        if (interactable && isInInteractZone)
        {

#if UNITY_EDITOR

			CheckDrawInputMouse();
#endif
			CheckDrawInputTouch();
		}
        else
        {
			if (!isInInteractZone && currentLine != null && interactable)
			{
				EndDraw();
			}
		}
    }

	private void CheckDrawInputMouse()
    {
		if (Input.GetMouseButtonDown(0))
			BeginDraw();

		if (currentLine != null)
			Draw();

		if (Input.GetMouseButtonUp(0))
			EndDraw();
	}

	private void CheckDrawInputTouch()
    {
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			// Handle finger movements based on touch phase.
			switch (touch.phase)
			{
				// Record initial touch position.
				case TouchPhase.Began:

					positionTouch = touch.position;

					BeginDraw();

					break;

				// Determine direction by comparing the current touch position with the initial one.
				case TouchPhase.Moved:

					positionTouch = touch.position;

					if (currentLine != null)
						Draw();
					break;

				// Report that a direction has been chosen when the finger is lifted.
				case TouchPhase.Ended:
					EndDraw();
					break;
			}
		}
	}

	// Begin Draw ----------------------------------------------

	void BeginDraw()
	{
		//listCurrentLine.Clear();

		currentLine = Instantiate(linePrefab).GetComponent <Line> ( );

		//Set line properties
		currentLine.UsePhysics(false);
		currentLine.SetLineColor(lineColor);
		currentLine.SetPointsMinDistance(linePointsMinDistance);
		currentLine.SetLineWidth(lineWidth);
	}

	// Draw ----------------------------------------------------

	void Draw()
	{
#if UNITY_EDITOR
		Vector2 interactPosition = cam.ScreenToWorldPoint(Input.mousePosition);
#else
		Vector2 interactPosition = cam.ScreenToWorldPoint (positionTouch);
#endif
		//Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )

		RaycastHit2D hit = Physics2D.CircleCast(interactPosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer);

		if (hit)
			EndDraw();
		else
			currentLine.AddPoint(interactPosition);
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

			} 
			else 
			{
				//Add the line to "CantDrawOver" layer
				currentLine.gameObject.layer = cantDrawOverLayerIndex;

				currentLine.SetPointForEdgeCollider();

				//Activate Physics on the line
				currentLine.UsePhysics(true);

				currentLine = null;
			}
		}

		//OnEndDraw?.Invoke();

		GameManager.Instance.SoundManager.PlaySoundDraw(false);

		LevelManager.Instance.MapManager.MapActionManager.GetAction((int)DrawGameAction.StartCount).ForceAction();
	}

	public void OnPointerDown(PointerEventData eventData)
    {
		canCheck = true;

		isInInteractZone = true;
	}

    public void OnPointerUp(PointerEventData eventData)
    {
		canCheck = false;
	}

    public void OnPointerExit(PointerEventData eventData)
    {
        if (canCheck)
        {
			isInInteractZone = false;
		}
	}
}
