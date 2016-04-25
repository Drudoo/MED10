using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

	public Toggle sound;

	void Start() {
		sound.isOn = !ApplicationModel.soundOn;
	}

	void Update() {
		Debug.Log(ApplicationModel.soundOn);
		if (sound.isOn == true) {
			ApplicationModel.soundOn = false;
		} else {
			ApplicationModel.soundOn = true;

		}
	}

}
