using UnityEngine;
using System.Collections;

public class LaserControl : MonoBehaviour {

	public bool isShowingLaser = false;
	IEnumerator showLaser()
	{
		if( isShowingLaser ) yield return true;
		isShowingLaser = true;

		//this.Renderer.enabled = true;

		yield return new WaitForSeconds (0.05f);
		resetLaser();
		isShowingLaser = false;
	}

	void resetLaser()
	{    
		//this.renderer.enabled = false;
	}
}
