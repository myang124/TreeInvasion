using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBarFixed : MonoBehaviour {


	[Header("Dot Speed")]
	public float dotSpeed = 1.0f;

	[Header("Bar/Zone Properties")]
	public float maxBarRange = 1.0f;
	public float maxZoneRange = 1.0f;

	[Header("GameObject References")]
	public GameObject dotObj;
	public GameObject zoneObj;
	public GameObject barObj;
	public GameObject parentObj;

	[Header("DEBUG ONLY - DON'T TOUCH!")]
	public float _dotX;
	public bool _inZone;

	//Private variables
	private float _startPosOffset;
	private float _barPadding = 1.0f;


	private void Start ()
    {
       // float randomZonePos = random.Range(0, maxBarRange);

		_startPosOffset = dotObj.transform.position.x;
        barObj.transform.localScale = new Vector3(maxBarRange*2+_barPadding, barObj.transform.localScale.y, barObj.transform.localScale.y);
        zoneObj.transform.localScale = new Vector3(maxZoneRange*2, zoneObj.transform.localScale.y, zoneObj.transform.localScale.y);
    }
	
	private void Update () {
		DotPosition();
		DotInZoneChecker();
	}

	
	// This function calculates the dot position.
	private void DotPosition() {
		// This float variable uses the SINE math function to get an X value between a range.
		_dotX= (Mathf.Sin(Time.time * dotSpeed) * maxBarRange + parentObj.transform.position.x);
		
		// This line changes the position of the dot based on the new X value.
		dotObj.transform.position = new Vector3(_dotX, dotObj.transform.position.y, dotObj.transform.position.z);
	}

	//This function checks if the dot is within the red zone.
	private void DotInZoneChecker() {
		if (maxZoneRange >= Mathf.Abs(_dotX - parentObj.transform.position.x)) {
			//barObj.GetComponent<SpriteRenderer>().color = Color.green;
			_inZone = true;
		}
		else {
			//barObj.GetComponent<SpriteRenderer>().color = Color.blue;
			_inZone = false;
		}
	}
}
