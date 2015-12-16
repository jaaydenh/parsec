using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DownAreaButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private bool touched;
	private int pointerID;
	private bool canMoveDown;

	void Awake () {
		touched = false;
	}

	public void OnPointerDown (PointerEventData data) {
		//if (!touched) {
			touched = true;
			pointerID = data.pointerId;
			canMoveDown = true;
		//}
	}

	public void OnPointerUp (PointerEventData data) {
		//if (data.pointerId == pointerID) {
			touched = false;
			canMoveDown = false;
		//}
	}

	public bool CanMoveDown () {
		return canMoveDown;
	}
}
