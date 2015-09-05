using UnityEngine;

public static class Helper 
{

	public struct ClipPlanePoints
	{
		public Vector3 UpperLeft;
		public Vector3 UpperRight;
		public Vector3 LowerLeft;
		public Vector3 LowerRight;


	}

	public static float ClampAngle(float angle, float min, float max)
	{

		do
		{
			//Stay in limits
			if(angle < -360)
				angle += 360;
			if(angle > 360)
				angle -= 360;
		
		
		
		}while( angle < -360 || angle > 360);


		return Mathf.Clamp(angle,min,max);
	}

	public static ClipPlanePoints ClipPlaneAtNear(Vector3  pos)
	{
		var clipPlanePoints = new ClipPlanePoints();

		if(Camera.main == null)
			return clipPlanePoints;

		var transforms 	= Camera.main.transform;
		var halfFOV 	= (Camera.main.fieldOfView / 2) * Mathf.Deg2Rad;
		var aspect		= Camera.main.aspect;
		var dist		= Camera.main.nearClipPlane;		// dist of camera to near clip plane
		var height		= dist * Mathf.Tan(halfFOV);
		var width		= height * aspect;


		clipPlanePoints.LowerRight 	= pos + transforms.right * width;
		clipPlanePoints.LowerRight 	-= transforms.up * height;
		clipPlanePoints.LowerRight	+= transforms.forward * dist;

		clipPlanePoints.LowerLeft 	= pos - transforms.right * width;
		clipPlanePoints.LowerLeft 	-= transforms.up * height;
		clipPlanePoints.LowerLeft	+= transforms.forward * dist;

		clipPlanePoints.UpperRight 	= pos + transforms.right * width;
		clipPlanePoints.UpperRight 	+= transforms.up * height;
		clipPlanePoints.UpperRight	+= transforms.forward * dist;

		clipPlanePoints.UpperLeft 	= pos - transforms.right * width;
		clipPlanePoints.UpperLeft 	+= transforms.up * height;
		clipPlanePoints.UpperLeft	+= transforms.forward * dist;

		return clipPlanePoints;

	}



}
