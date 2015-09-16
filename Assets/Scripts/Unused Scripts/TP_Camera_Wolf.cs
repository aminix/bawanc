using UnityEngine;
using System.Collections;

public class TP_Camera_Wolf : MonoBehaviour 
{

	#region Static

	public static TP_Camera_Wolf Instance;

	#endregion


	#region Public


	public Transform TargetLookAt;
	public float Distance 			= 2f;
	public float MinDistance 		= 1.5f;
	public float MaxDistance 		= 10f;
	public float CameraDistSmooth	= 0.5f;

	
	public float X_Smooth			= 0.1f;
	public float Y_Smooth			= 0.1f;
	public float Y_MinLimit			= -20f;
	public float Y_MaxLimit			= 40f;
	public float preOccludedDist	= 0f;
	public float OcclusionDistStep	= 0.1f;
	public int MaxOcclusionChecks	= 50;
	public float DistResumeSmooth	= 1f;

	#endregion

	private float mouseX 			= 0f;
	private float mouseY 			= 0f;
	private float startDistance 	= 0f;
	private float desiredDistance 	= 0f;
	private Vector3 desiredPosition	= Vector3.zero;
	private float velDistance 		= 0f;
	private float velX				= 2;
	private float velY				= 2;
	private float velZ				= 2;
	private Vector3 camPosition		= Vector3.zero;

	void Awake()
	{

		Instance = this;
		camPosition = transform.position;
	}

	void Start()
	{
		UseExistingOrCreateNewMainCamera();
		Distance = Mathf.Clamp(Distance,MinDistance,MaxDistance);
		startDistance = Distance;
		Reset();
	}

	void Update()
	{
		if(TargetLookAt == null)
		{
			return;
		}








		CalculateDesiredPosition();

		UpdatePosition();

	}

	void CalculateDesiredPosition()
	{
		//Get back to previous distance after occlusion zoom
		ResetDesiredDistance();

		//evaluate distance 
		Distance = Mathf.SmoothDamp(Distance,desiredDistance,ref velDistance,CameraDistSmooth);


		// calculate desired position
		desiredPosition = CalculatePosition(mouseY,mouseX,Distance);

	}

	Vector3 CalculatePosition(float rotationX,float rotationY,float distance)
	{
		//Creating a Vector called direction that will point behind the character
		Vector3 direction = new Vector3(0,0, -distance);
	

		//Calculating orbit
		Quaternion rotation = Quaternion.Euler(0,0,0);  // Quaternion.Euler(rotationX,rotationY,0);

		return TargetLookAt.position + (rotation * direction);

	}

	bool CheckIfOccluded(int count)
	{
		var isOccluded = false;

		var nearestDistance = CheckCameraPoints(TargetLookAt.position, desiredPosition);

		if(nearestDistance != -1)	//something is hit man !
		{
			if(count < MaxOcclusionChecks)
			{
				isOccluded = true;
				Distance -= OcclusionDistStep;

				if(Distance < 0.25f)		//0.25f
				{
					Distance = 0.25f;
				}

			}
			else
			{
				Distance = nearestDistance - Camera.main.nearClipPlane;
			}

			desiredDistance = Distance;

		}


		return isOccluded;
	}


	float CheckCameraPoints(Vector3 from,Vector3 to )
	{
		var nearestDist = -1f;

		RaycastHit hitInfo;

		//Calculate those clip points
		Helper.ClipPlanePoints clipPlanePoints = Helper.ClipPlaneAtNear(to);

		#region Drawing Lines Pyramid for Camera Clipping
		//Draw lines in editor to make it easy to visualize
		Debug.DrawLine(from, (to + transform.forward * - Camera.main.nearClipPlane), Color.red);
		Debug.DrawLine(from, clipPlanePoints.UpperLeft);
		Debug.DrawLine(from, clipPlanePoints.UpperRight);
		Debug.DrawLine(from, clipPlanePoints.LowerLeft);
		Debug.DrawLine(from, clipPlanePoints.LowerRight);

		//Drawing Box
		Debug.DrawLine(clipPlanePoints.UpperLeft, clipPlanePoints.UpperRight);
		Debug.DrawLine(clipPlanePoints.UpperRight, clipPlanePoints.LowerRight);
		Debug.DrawLine(clipPlanePoints.LowerRight, clipPlanePoints.LowerLeft);
		Debug.DrawLine(clipPlanePoints.LowerLeft, clipPlanePoints.UpperRight);

		#endregion
		if(Physics.Linecast(from, clipPlanePoints.UpperLeft, out hitInfo) && hitInfo.collider.tag != "Player")
		{
			nearestDist = hitInfo.distance;
		}
		if(Physics.Linecast(from, clipPlanePoints.LowerLeft, out hitInfo) && hitInfo.collider.tag != "Player")
		{
			if(hitInfo.distance < nearestDist || nearestDist == -1)
				nearestDist = hitInfo.distance;
		}
		if(Physics.Linecast(from, clipPlanePoints.UpperRight, out hitInfo) && hitInfo.collider.tag != "Player")
		{
			if(hitInfo.distance < nearestDist || nearestDist == -1)
				nearestDist = hitInfo.distance;
		}
		if(Physics.Linecast(from, clipPlanePoints.LowerRight, out hitInfo) && hitInfo.collider.tag != "Player")
		{
			if(hitInfo.distance < nearestDist || nearestDist == -1)
				nearestDist = hitInfo.distance;
		}
		if(Physics.Linecast(from, to + transform.forward * - Camera.main.nearClipPlane, out hitInfo) && hitInfo.collider.tag != "Player")
		{
			if(hitInfo.distance < nearestDist || nearestDist == -1)
				nearestDist = hitInfo.distance;
		}

		return nearestDist;
	}

	void ResetDesiredDistance()
	{
		if(desiredDistance < preOccludedDist)
		{
			var pos = CalculatePosition(mouseY,mouseX, preOccludedDist);
			var nearestDist = CheckCameraPoints(TargetLookAt.position, pos);
			if(nearestDist == -1 || nearestDist > preOccludedDist)
			{
				desiredDistance = preOccludedDist;
			}
		}

	}


	void UpdatePosition()
	{



	

	

		var posX = Mathf.SmoothDamp(camPosition.x,desiredPosition.x, ref velX,X_Smooth);
	var posY = Mathf.SmoothDamp(camPosition.y,desiredPosition.y, ref velY,Y_Smooth);
		var posZ = Mathf.SmoothDamp(camPosition.z,desiredPosition.z, ref velZ,X_Smooth);

		camPosition = new Vector3(posX,posY,posZ);



		transform.position = camPosition;
		transform.LookAt(TargetLookAt);
	}




	public void Reset()
	{

		mouseX = 0;
		mouseY = 10;
		Distance = startDistance;
		desiredDistance = Distance;
		preOccludedDist = Distance;
	}





















	//Make a camera, idk why to do this ?
	void UseExistingOrCreateNewMainCamera()
	{
		GameObject tempCamera, targetLookAt;
		TP_Camera_Wolf myCamera;
		if(Camera.main != null)
		{
			tempCamera = Camera.main.gameObject;
		}
		else
		{
			tempCamera = new GameObject("Main Camera");
			tempCamera.AddComponent<Camera>();
			tempCamera.tag = "MainCamera";

		}

		 
		myCamera = tempCamera.GetComponent<TP_Camera_Wolf>();

		targetLookAt = GameObject.Find ("targetLookAt") as GameObject;
		if(targetLookAt == null)
		{
			targetLookAt = new GameObject("targetLookAt");
			targetLookAt.transform.position = Vector3.zero;
		}

		myCamera.TargetLookAt = targetLookAt.transform;

	}

}
