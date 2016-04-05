using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

	public Image myButtonImage; // Assign /Initilize from Editor or code
	Button myButton;
	void Awake() {
		myButton = GetComponent<Button>();
		myButton.image = myButtonImage;
	}
}
