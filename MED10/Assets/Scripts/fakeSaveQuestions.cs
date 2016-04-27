using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class fakeSaveQuestions : MonoBehaviour {


	private string fileName;
	private string filePath;

	void Start() {
		string date = System.DateTime.Now.ToString("dd");
		string month = System.DateTime.Now.ToString("MM");
		string year = System.DateTime.Now.ToString("yyyy");
		//Debug.Log(date + " " + month + " " + year);
		fileName = year+month+date+".txt";
		//Debug.Log(uniqueID);
		filePath = Application.persistentDataPath + "/" + fileName;
	}

	public void SaveQuestions() {


		try {
			if (!File.Exists(filePath)) {
				string temp = "q1\na1\nb1\nc1\nA\nq2\na2\nb2\nc2\nB\nq3\na3\nb3\nc3\nC\nq4\na4\nb4\nc4\nB\nq5\na5\nb5\nc5\nC\nq6\na6\nb6\nc6\nA";

				string[] lines = Regex.Split(temp, "[\\n]");

				File.WriteAllLines(filePath, lines);
				Debug.Log("File Created");
			} else {
				Debug.Log("File fileName" + " exists");
			}
		} catch (System.Exception e) {
			Debug.Log(e);
		}
	}

	public void deleteFile() {
		Debug.Log("Deleting " + filePath);
		if (File.Exists(filePath)) {
			Debug.Log("Deleting File...");
			File.Delete(filePath);
		} else {
			Debug.Log("File cannot be deleted.");
		}
	}

	private void printList(List<string> list) {
		string line = "";
		string temp;
		foreach (string str in list) {
			temp = " " + str;
			line = line + temp;
		}
		Debug.Log("Printing list: " + line);
	}
}
