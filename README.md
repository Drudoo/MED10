# Unity

## To Do

- [x] ~~Fix player through platform~~
- [ ] Joystick size. No down button just two arrows. 
- [ ] Table view size
- [ ] Game z distance on button and player
- [ ] Save questions to file
- [ ] Load question in to game
- [ ] 10 questions
- [ ] 3 answers per question
- [ ] have 15 questions/coins and randomly give either question or coin. 
- [ ] Enemy. Just walk around, when you collide you die.
- [ ] Question when you die. 
- [ ] Save one question for when they die. 
- [ ] settings: sound on/off
- [ ] Gallery: Previous games
- [ ] Upload: progess bar
- [ ] Download: Search for other games. Hard code games we made. Put them in to gallery when downloaded. 
- [ ] Profile: Username, email and so on (look at report)
- [ ] ID for each game and you can add a name. 
- [ ] No make game.
- [ ] Search in table. 
- [ ] Popup saying game ID and questions and a button that says access game. 
- [ ] Student: Add game ID. Load game.
	- [ ] Plugins
	- [ ] Achievements
- [ ] Student: new template shows games with name and id. 

## Open architecture
- How can plugins be created. 

## Questions
- Is it okay to not have some of the functionality, like cloud structure and game sharing?
- Teacher 

## Build wirelessly to Android (Mac)

- Install `adb`:

		brew install android-platform-tools	
	
Plug in device:

    adb tcpip 5555

Unplug device

    adb connect deviceIP

Build and Run normally from Unity.
