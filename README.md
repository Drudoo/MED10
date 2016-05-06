# Unity

## To Do

- [x] ~~Fix player through platform~~
- [x] ~~:exclamation: Joystick size. No down button just two arrows.~~
- [x] ~~:bangbang: Table view size~~
- [x] ~~Game z distance on button and player~~
- [x] ~~:bangbang: Save questions to file~~
- [x] ~~:bangbang: Load question in to game~~
- [x] ~~10 questions~~
- [x] ~~3 answers per question~~
- [x] ~~:confused: add correct answer to questions~~
- [x] ~~:bangbang: have 15 questions/coins and randomly give either question or coin.~~
- [x] ~~:bangbang: Enemy. Just walk around, when you collide you die.~~
- [x] ~~Question when you die.~~
- [x] ~~Save one question for when they die.~~
- [x] ~~settings: sound on/off~~
- [x] ~~Gallery: Previous games~~
- [x] ~~Upload: progess bar~~
- [x] ~~Download: Search for other games. Hard code games we made. Put them in to gallery when downloaded.~~
- [ ] Profile: Username, email and so on (look at report)
- [x] ~~:exclamation: ID for each game and you can add a name.~~
- [x] ~~:exclamation: Add game name~~
- [x] :exclamation: ~~No make game.~~
- [x] :exclamation: ~~Search in table.~~
- [x] ~~:exclamation: Popup saying game ID and questions and a button that says access game.~~
- [x] ~~Student: Add game ID. Load game.~~
	- [x] ~~Plugins~~
	- [x] ~~Achievements~~
- [x] :rage: ~~Student: new template shows games with name and id.~~
- [x] :sweat: ~~Dont show question when box is coin.~~
- [x] ~~Grow button back and make door able to close again.~~
- [x] :bug: ~~fix CameraFollow script error.~~  
- [ ] :bug: fix enemy quad/raycast script.
- [x] :bug: ~~fix texture length.~~
- [x] :bug: ~~fix platform height so enemies can walk over.~~  
- [x] :exclamation: ~~only one correct answerC~~
- [x] ~~replace question buttons with boxes.~~
- [x] ~~display questions next to where you save them.~~
- [x] ~~remove toggle box after the 10th questions.~~
- [ ] :mortar_board: change educator icon size.
- [x] :sound: ~~add sound~~
- [x] :mute: ~~make sound button work.~~  
- [x] :skull: ~~respawn at the same place if answer right on dead question.~~ 
- [x] ~~destroy scene when new is loaded, so old stuff is not there.~~ 
- [x] ~~save student name~~
- [x] ~~assessment based on the games result. Save that to file and load in to assessment scene.~~
- [x] ~~dont show gallery before pressing download.~~ 
- [x] :bangbang: ~~six questions, four coins.~~ 
- [x] ~~test question button (save questions to file, delete other file)~~
- [ ] change date in file name to a random number. 
- [ ] :bangbang: new scene when learning analytics is pressed with graph.  
- [ ] :space_invader: no trigger on enemy
- [ ] question on die not working. 
- [x] ~~:exclamation: remove download functionality. just make a popup.~~
- [ ] :bangbang: fix assessment not showing for user. 
- [x] ~~upload/ddownload title congratulation.~~ 
- [x] ~~:exclamation: student new template, fake test input, load button loads a new game.~~ 
- [x] ~~:exclamation: student gallery should just be one button.~~
- [x] ~~student settings not working.~~
- [x] ~~:exclamation: create quiz previous question box bigger and move add questions to the right.~~ 
- [ ] test every button/popup. 
- [x] ~~:exclamation: Currently Story template is not available.~~ 
- [x] ~~:bangbang: when creating own questions should delete the previous one~~
- [x] ~~:bangbang: Fix make game screen with own questions.~~ 
- [x] ~~:exclamation: Fix fake assessment numbers~~
- [ ] :exclamation: assessment popup fix. 
- [ ] :bangbang: fix hour min second for file name. 


## Open architecture
- :bangbang: How can plugins be created.

## new to do

- [x] ~~Fix make game scene not showing questions.~~
- [ ] add andrea stuff to assessment
- [ ] add everything to github.
- [x] ~~move assessemnt search bar~~

## Report

- clarify advantages and disadvantages

## LaTeX

- Fix Other Sources in report
- write 25 pages of implementation


## Problems :ant: :heavy_plus_sign: Bugs :bug:

- :zap: UniqueID is the current date, so working on a quiz at mightnight can *potentially* cause problems.
- :rage: Enter game name is not native to android. Fix later.
	- :imp: text field is there, but cant get the value.
- :space_invader: enemies walk between obstacles and not between waypoints.
- :zap: Hide MakeGame and Print on android again. 
- You can dismiss questions on android. 

## Build wirelessly to Android (Mac)

- Install ``adb``:


	brew install android-platform-tools


Plug in device:

    adb tcpip 5555

Unplug device

    adb connect deviceIP

Build and Run normally from Unity.

## Get Debug.Log() from Android (Mac)

- Using ``adb``:


	adb logcat
    
   
- Only get current app data

	db logcat | grep `adb shell ps | grep com.drudoo.med10 | cut -c10-15`
