using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LinesDrawer : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
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

	//private List<Line> listCurrentLine;

	private bool interactable;

	private bool isInInteractZone;

	Vector2 positionTouch;

	//public UnityEvent OnEndDraw;

	private bool canCheck;

	void Start() {
		//cam = Camera.main;

		//listCurrentLine = new List<Line>();

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

			if (Input.GetMouseButtonDown(0))
                BeginDraw();

            if (currentLine != null)
                Draw();

            if (Input.GetMouseButtonUp(0))
                EndDraw();
#endif
			if (Input.touchCount > 0)
			{
				//if (!isInInteractZone && currentLine != null)
				//{
				//	EndDraw();

				//	return;
				//}

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
        else
        {
			if (!isInInteractZone && currentLine != null && interactable)
			{
				EndDraw();

				return;
			}
		}
    }

	// Begin Draw ----------------------------------------------

	void BeginDraw()
	{

		//listCurrentLine.Clear();

		currentLine = Instantiate(linePrefab).GetComponent <Line> ( );

		//Set line properties
		currentLine.UsePhysics ( false );
		currentLine.SetLineColor ( lineColor );
		currentLine.SetPointsMinDistance ( linePointsMinDistance );
		currentLine.SetLineWidth ( lineWidth );

	}

	// Draw ----------------------------------------------------

	void Draw() 
	{
		GameManager.Instance.SoundManager.PlaySoundDraw(true);

#if UNITY_EDITOR
		Vector2 mousePosition = cam.ScreenToWorldPoint ( Input.mousePosition );
#else
		Vector2 mousePosition = cam.ScreenToWorldPoint (positionTouch);
#endif
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

			} 
			else 
			{
				//Add the line to "CantDrawOver" layer
				currentLine.gameObject.layer = cantDrawOverLayerIndex;

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
		//if (interactable)
		//{
		//	if (Input.GetMouseButtonDown(0))
		//		BeginDraw();
		//}

		canCheck = true;

		isInInteractZone = true;
	}

    public void OnPointerMove(PointerEventData eventData)
    {
		//if (interactable)
		//{
		//	if (currentLine != null)
		//		Draw();
		//}
	}

    public void OnPointerUp(PointerEventData eventData)
    {
		//if (interactable)
		//{
		//	if (Input.GetMouseButtonUp(0))
		//		EndDraw();
		//}

		canCheck = false;
	}

    public void OnPointerEnter(PointerEventData eventData)
    {


	}

    public void OnPointerExit(PointerEventData eventData)
    {
        if (canCheck)
        {
			isInInteractZone = false;
		}
	}
}
