public class ApplicationModel {


	static public string currentLevel = "";

	static public bool soundOn = false;

	static public string username = "";

	//Name, Game ID, Score, Right Answer, Coins, Boxes, Time

	static public bool downloaded = true;

	static public int rightAnswers = 0;
	static public int wrongAnswers = 0;
	static public int coins = 0;
	static public int boxes = 0;

	static public string assessment = "Name\tGame ID\tScore\tRight Answers\tCoins\tBoxes\tTime\nBob Ross\t20160427.txt\t11%\t2\t2\t3\t2016-05-01T21:14:02+02:00\nTaylor Rey\t20160427.txt\t67%\t5\t2\t9\t2016-05-01T15:02:57+02:00\nAndrea Keiser\t20160521.txt\t67%\t4\t4\t8\t2016-05-09T09:24:22+02:00\nAnnie Bech\t20160521.txt\t89%\t5\t4\t9\t2016-05-12T11:00:37+02:00\n";


	//Mathf.Round (((rA-wA+c)/9*100))
					//(5-1+2)/9*100

}
