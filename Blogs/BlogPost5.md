# Development Update 3

This development update has been all about improving the player's overall experience outside of core gameplay. I started by building out the main menu and pause screen, which now serve as a more polished entry point and in-game control hub. The main menu includes options for starting the game, adjusting settings, and exiting, while the pause screen allows players to resume, return to the main menu, or tweak audio settings on the fly.

A big focus was on implementing a script that allows players to adjust the music and sound effects volume in increments of 20%. These changes are not just temporary — they’re saved locally, so the player’s settings persist between sessions. This was done using Unity’s PlayerPrefs system, which made it straightforward to store and retrieve values like volume values when the game launches.

Controller support was another key part of this sprint. I updated the main menu to be fully navigable with a game controller, making the interface intuitive whether you’re playing with a keyboard or a gamepad. This involved reworking some of the UI navigation logic and testing various edge cases to ensure everything functioned as expected.

To test the controller compatibility, I deployed the build to the VIA Arcade Machine. It was a valuable experience to validate that the controls behaved correctly in that environment. After a few tweaks to input mapping, everything worked smoothly on the arcade machine — a big step toward making the game feel like a complete and polished arcade experience.

To help arcade players get started quickly, I also added an instructional image to the first room of the game. This visual shows the correct buttons to use on the arcade machine, giving immediate context and preventing confusion. It’s a small addition, but it makes a big difference in accessibility, especially for new players who may not be familiar with the control layout.

Instructional image in the first room:
![Alt text](Images/FirstRoom.png)

Features to implement:

✅Sun rays and player death if staying too long in them

✅Player dash/transform

✅First level environment

❌Shrines for refreshing the player's ability to dash(This has been replaced by giving the ability a cooldown)

❌UI(should include dash ability availability, timer for level) (The UI will be minimalistic to let the player have the whole room in view)

✅Main menu and pause screen

✅OST/Sound effects to add to the game
