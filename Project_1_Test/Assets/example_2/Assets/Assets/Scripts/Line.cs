using UnityEngine;
using System.Collections.Generic;

public class Line : MonoBehaviour {

	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCollider;
	public Rigidbody2D rigidBody;

	[HideInInspector] public List<Vector2> points = new List<Vector2> ( );
	[HideInInspector] public int pointsCount = 0;

	//The minimum distance between line's points.
	float pointsMinDistance = 0.1f;

	float pointsMaxDistance = 0.2f;

	//Circle collider added to each line's point
	float circleColliderRadius;

	public void AddPoint ( Vector2 newPoint ) {
		//If distance between last point and new point is less than pointsMinDistance do nothing (return)
		if ( pointsCount >= 1 && Vector2.Distance ( newPoint, GetLastPoint ( ) ) < pointsMinDistance )
			return;



		if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) > pointsMaxDistance)
        {
			float a = Vector2.Distance(newPoint, GetLastPoint());

			int b = (int)(a / pointsMaxDistance);

			float k = a - b * pointsMaxDistance;

			float h = k / a;

			Vector2 dir = newPoint - GetLastPoint();

			Vector2 thua = dir * h;

			Vector2 conlai = dir - thua;

			Vector2 phan = conlai / b;

			for(int i = 0; i < b; i++)
            {
				Vector2 pointAdd = GetLastPoint() + phan;

				points.Add(pointAdd);
				pointsCount++;

				//Add Circle Collider to the Point
				//CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
				//circleCollider.offset = newPoint;
				//circleCollider.radius = circleColliderRadius;

				//Line Renderer
				lineRenderer.positionCount = pointsCount;
				lineRenderer.SetPosition(pointsCount - 1, pointAdd);
			}
        }

		points.Add ( newPoint );
		pointsCount++;

        //Add Circle Collider to the Point
        CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
        circleCollider.offset = newPoint;
        circleCollider.radius = circleColliderRadius;

        //Line Renderer
        lineRenderer.positionCount = pointsCount;
		lineRenderer.SetPosition ( pointsCount - 1, newPoint );

		//Edge Collider
		//Edge colliders accept only 2 points or more (we can't create an edge with one point :D )
		if ( pointsCount > 1 )
			edgeCollider.points = points.ToArray ( );
	}

	public Vector2 GetLastPoint ( ) {
		return ( Vector2 )lineRenderer.GetPosition ( pointsCount - 1 );
	}

	public void UsePhysics ( bool usePhysics ) {
		// isKinematic = true  means that this rigidbody is not affected by Unity's physics engine
		rigidBody.isKinematic = !usePhysics;
	}

	public void SetLineColor ( Gradient colorGradient ) {
		lineRenderer.colorGradient = colorGradient;
	}

	public void SetPointsMinDistance ( float distance ) {
		pointsMinDistance = distance;
	}

	public void SetLineWidth ( float width ) {
		lineRenderer.startWidth = width;
		lineRenderer.endWidth = width;

		circleColliderRadius = width / 2f;

		edgeCollider.edgeRadius = circleColliderRadius;
	}

}
