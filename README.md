# Unity

## To Do

- [x] ~~Fix player through platform~~
- [ ] :exclamation: Joystick size. No down button just two arrows.
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
- [ ] settings: sound on/off
- [ ] Gallery: Previous games
- [ ] Upload: progess bar
- [ ] Download: Search for other games. Hard code games we made. Put them in to gallery when downloaded.
- [ ] Profile: Username, email and so on (look at report)
- [ ] :exclamation: ID for each game and you can add a name.
- [ ] :exclamation: Add game name
- [x] :exclamation: ~~No make game.~~
- [x] :exclamation: ~~Search in table.~~
- [ ] :exclamation: Popup saying game ID and questions and a button that says access game.
- [ ] Student: Add game ID. Load game.
	- [ ] Plugins
	- [ ] Achievements
- [ ] :rage: Student: new template shows games with name and id.
- [x] :sweat: ~~Dont show question when box is coin.~~
- [ ] Grow button back and make door able to close again.
- [x] :bug: ~~fix CameraFollow script error.~~  
- [ ] :bug: fix enemy quad/raycast script.
- [ ] :bug: fix texture length.  
- [ ] :bug: fix platform height so enemies can walk over.  
- [x] :exclamation: ~~only one correct answerC~~
- [x] ~~replace question buttons with boxes.~~
- [ ] display questions next to where you save them. 

## Open architecture
- :bangbang: How can plugins be created.

## Questions
- Is it okay to not have some of the functionality, like cloud structure and game sharing?
- Teacher

## Problems :ant: :heavy_plus_sign: Bugs :bug:

- :zap: UniqueID is the current date, so working on a quiz at mightnight can *potentially* cause problems.
- :rage: Enter game name is not native to android. Fix later.
	- :imp: text field is there, but cant get the value.
- :space_invader: enemies walk between obstacles and not between waypoints.
- :zap: Hide MakeGame and Print on android again. 

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
