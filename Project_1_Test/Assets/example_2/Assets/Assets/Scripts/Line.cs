using UnityEngine;
using System.Collections.Generic;

public class Line : MonoBehaviour {

	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCollider;
	public Rigidbody2D rigidBody;

	[HideInInspector] public List<Vector2> points = new List<Vector2> ( );
	[HideInInspector] public int pointsCount = 0;

	//The minimum distance between line's points.
	float pointsMinDistance = 0.05f;

	float pointsMaxDistance = 0.1f;

	//Circle collider added to each line's point
	float circleColliderRadius;

	public void AddPoint(Vector2 newPoint) 
	{
		//If distance between last point and new point is less than pointsMinDistance do nothing (return)
		if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
			return;

        //

        points.Add(newPoint);
		pointsCount++;

        //Line Renderer
        lineRenderer.positionCount = pointsCount;
		lineRenderer.SetPosition(pointsCount - 1, newPoint);

		//Edge Collider
		//Edge colliders accept only 2 points or more (we can't create an edge with one point :D )
	}

	private Vector2 GetPointNearOldPoint(Vector2 pointGet)
    {
		float distanceNewPointAndLastPoint = Vector2.Distance(pointGet, GetLastPoint());

		// k is he so ty le

		float k = (int)(pointsMaxDistance / distanceNewPointAndLastPoint);

		// dir is vector huong

		Vector2 dir = pointGet - GetLastPoint();

		dir = dir * k;

		Vector2 pointAdd = GetLastPoint() + dir;

		return pointAdd;
	}

	public Vector2 GetLastPoint() 
	{
		return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
	}

	public void UsePhysics ( bool usePhysics ) 
	{
		// isKinematic = true  means that this rigidbody is not affected by Unity's physics engine
		rigidBody.isKinematic = !usePhysics;
	}

	public void SetLineColor(Gradient colorGradient) 
	{
		lineRenderer.colorGradient = colorGradient;
	}

	public void SetPointsMinDistance(float distance)
	{
		pointsMinDistance = distance;
	}

	public void SetLineWidth(float width)
	{
		lineRenderer.startWidth = width;
		lineRenderer.endWidth = width;

		circleColliderRadius = width / 2f;

		edgeCollider.edgeRadius = circleColliderRadius;
	}


	public void SetPointForEdgeCollider()
    {
		if (pointsCount > 1)
			edgeCollider.points = points.ToArray();
	}
}