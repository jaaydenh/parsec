using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UpAreaButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private bool touched;
	private int pointerID;
	private bool canMoveUp;

	void Awake () {
		touched = false;
	}

	public void OnPointerDown (PointerEventData data) {
		//if (!touched) {
			touched = true;
			pointerID = data.pointerId;
			canMoveUp = true;
		//}
	}

	public void OnPointerUp (PointerEventData data) {
		//if (data.pointerId == pointerID) {
			touched = false;
			canMoveUp = false;
		//}
	}

	public bool CanMoveUp () {
		return canMoveUp;
	}
}
