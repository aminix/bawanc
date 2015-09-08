using UnityEngine;
using System.Collections;

public class SkyBoXScript : MonoBehaviour {
	
	public static SkyBoXScript Instance;




	//PUBLIC
	public bool OrbActivated;

	//GEtting Background back to BLACK
	public float 			exposureReducingTime;



	//PRIVATE


	private Light				mainLight;
	private Skybox				skyBox;
	private Material			skMat;


	//Sky Tint variables
	private float			exposure;
	private float			defExposure;





	
	// Use this for initialization
	void Start () 
	{
		Instance = this;
	//	mainLight = GetComponent<Light>();

		skMat = RenderSettings.skybox;
		defExposure = 0.01f;
		SetExposure(defExposure);
		skMat.SetFloat("_AtmosphereThickness",0.35f);


	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(OrbActivated)
		{
			if(defExposure < exposure)
			{

				// To get back the background color back to BLACK.
				exposure -= exposureReducingTime;
				SetExposure(exposure);
			}
			else
			{
				OrbActivated = false;
			}
		}
	}
	
	
	public void ChangeToRed()
	{
		skMat.SetColor("_SkyTint",Color.red);
		exposure = 6;
		SetExposure(exposure);
		OrbActivated = true;

	}
	
	public void ChangeToGreen()
	{
		skMat.SetColor("_SkyTint",Color.green);
		exposure = 1;
		SetExposure(exposure);
		OrbActivated = true;
	}
	public void ChangeToBlue()
	{
		skMat.SetColor("_SkyTint",Color.blue);
		exposure = 0.5f;
		SetExposure(exposure);
		OrbActivated = true;
	}
	public void ChangeToYellow()
	{
		skMat.SetColor("_SkyTint",Color.yellow);
		exposure = 4;
		SetExposure(exposure);
		OrbActivated = true;
	}

	public void SetExposure(float value)
	{
		skMat.SetFloat("_Exposure",value);
	}

}
