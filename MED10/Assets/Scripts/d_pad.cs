using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class d_pad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {

	private bool buttonHeld = false;

	public void OnPointerDown(PointerEventData eventData) {
		buttonHeld = true;
	}

	public void OnPointerUp(PointerEventData eventData) {
		buttonHeld = false;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		buttonHeld = true;
	}

	public void OnPointerExit(PointerEventData eventData) {
		buttonHeld = false;
	}

	public bool getButtonState() {
		return buttonHeld;
	}

	void Update() {
		if (Input.touches.Length <= 0) {
			buttonHeld = false;
		} else {
			for (int i=0; i < Input.touchCount; i++) {
				//if (Input.GetTouch(i).phase == TouchPhase.Began) {
				//}
				//if (Input.GetTouch(i).phase == TouchPhase.Ended) {

				//}
			}
		}
	}
}
