using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

	// Assign /Initilize from Editor or code
	public Button _button;
	public Texture _image;
	public string _text;
	private float x,y,width,height;

	void Start() {
		RectTransform rt = (RectTransform)_button.transform;
		width = rt.rect.width;
		height = rt.rect.height;
		x = _button.transform.position.x;
		y = _button.transform.position.y;
		Debug.Log("x: " + x + " y: " + y + " w: " + width + " h: " + height);
	}

	void OnGUI() {
		GUI.BeginGroup (new Rect (x, y, 100, 100));
		GUI.Box (new Rect (0,0,100,100), "Group is here");
    	GUI.Button (new Rect (10,40,500,500), _image);
		GUI.EndGroup();
	}
}
