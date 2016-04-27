using UnityEngine;
using System.Collections;

public class changeTOresults : MonoBehaviour {

	public AlertPopup alert;

	void OnTriggerEnter2D(Collider2D Hit)
	{
		Application.LoadLevel ("GameFinished");
		#if UNITY_EDITOR

		#else
		//alert.alertPopup();
		#endif

	}
}
