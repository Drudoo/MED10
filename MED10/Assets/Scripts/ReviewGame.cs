using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using System.Net;
using System.Text;

public class ReviewGame : MonoBehaviour {

	private string fileName;
	private string filePath;
	private int uniqueID;

	public Text q_and_a;
	private string qaText;

	void Start() {
		string date = System.DateTime.Now.ToString("dd");
		string month = System.DateTime.Now.ToString("MM");
		string year = System.DateTime.Now.ToString("yyyy");
		string hour = System.DateTime.Now.ToString("hh");
		string min = System.DateTime.Now.ToString("mm");

		//uniqueID = int.Parse(date)+int.Parse(month)+int.Parse(year);
		//fileName = year+month+date+hour+min+".txt";
		//filePath = Application.persistentDataPath + "/" + fileName;
		fileName = ApplicationModel.currentLevel;
		qaText = q_and_a.GetComponent<Text>().text;
		qaText+=" "+ ApplicationModel.currentLevel;
		filePath = Application.persistentDataPath + "/" + fileName;
		//q_and_a.GetComponent<Text>().text=qaText;
		loadQuestions();
		q_and_a.GetComponent<Text>().text=qaText;
		//ApplicationModel.currentLevel = year+month+date;
	}

	private void loadQuestions() {
		try {
			if (File.Exists(filePath)) {
				string[] temp = File.ReadAllLines(filePath);
				string answer;
				for (int i = 0; i < temp.Length; i+=5) {
					if (temp[i+4]=="A") {
						answer=temp[i+1];
					} else if (temp[i+4]=="B") {
						answer=temp[i+2];
					} else {
						answer=temp[i+3];
					}
					qaText+="\n"+temp[i]+"\t"+answer;
				}
			} else {
				Debug.Log("File fileName" + " does not exist: " + filePath);
			}
		} catch (System.Exception e) {
			Debug.Log(e);
		}
	}

}
