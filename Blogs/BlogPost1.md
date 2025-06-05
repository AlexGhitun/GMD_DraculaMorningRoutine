# Roll-a-ball 

### Roll-a-ball blog post(03/03/2025)

Link to the roll-a-ball game: https://github.com/AlexGhitun/GMD.git

This project is the first assignment received from the GMD course which involves following the Unity tutorial for creating a game where the player is the ball and tries to get collectibles while avoiding enemies.
This being the first time I use Unity it took not that much time to get used to its functionalities and to start understanding its capabilities. Overall I am excited about the posibilities of creating games and trying new things to see how the engine runs.

In the beginning, it was interesting to see how the objects get created within a game and scripts are written to let the user input actions to move their object. Creating different materials and the playground where the player is allowed to move gave me a lot of insight as to how much customizability there is for a developer when making a game.

After creating the player object and the playground, next step was to add the collectibles. These would be spinning in place with the help of a script, but one of the issues I didn't expect was having to make them dissapear after the player would collide with them, while also increasing a counter to represent how many collectibles were gathered. This was an interesting aspect as I assumed that there would be just a function within Unity to be able to do without the help of a script, but regardless it wasn't that difficult.

The system with tags in Unity makes it really easy to be able to detect different actions and interactions between the player and different objects. This was used for detecting collision between the player and the enemy and for making the enmy dissapear after the player collects all the collectibles. The text for the winning screen and losing screen were pretty easy to figure out, but I still need to learn a bit more about how the Scene works in Unity to be able to easier interact with the game objects.

Finally, I added the victory text once all 8 cubes were picked up and added a few obstacles such as walls, pillars, ramps and moveable cubes around the playground so that it would be a bit more difficult for the player to get every collectible. This turned out to also mess with the AI of the enemy movement as it would not detect the objects the first time around, and later on having to modify how high the enemy can climb surfaces and at which angle so that it would properly follow the player and not go through objects.

There are still a few issues I am trying to improve before adding new features, one of them being related to the shadows not being loaded properly when the player is moving across the playground and the AI pathing not always climbing on surfaces the right way(climbing ramps from the side).

Next features to implement for the game:

Obstacles in the course that move which upon collision with the player would toss the player around the playground, I need to take into consideration enemy behaviour

Extra level that could be a follow-up to the already existing one

Power-ups, such as freeze enemies, that could spawn on the playground at random times and places 

Timer mode, which could have an amount of time to complete each level, otherwise the player would lose (this feature could also be just an addition to add a timer in the UI for the user to be able to compare with previous runs)

### Roll-a-ball extra features (07/03/2025)

From the last merge there have been some new additions regarding the game. Now there is a second level which will automatically start once the player completes the first level by picking up all the collectibles. The second level also includes a spinning obstacle which will throw the player around if they position in its trajectory. The timer mode has been implemented as a time text that will be displayed all the time in the top right corner of the screen. This timer will stop once the player wins/loses or if the level resets.

There still are a few issues that need to be fixed out of which the most important is that if the player loses they are stuck in the "You lose!" screen and they need to restart the game if they wish to replay. Some other bugs that need to be fixed are that in the second level the second enemy will not dissapear if the player wins.

Some of the challenges that I encountered while implementing these features were handling scenes and figuring how does a game in general handle multiple levels so that they can either be loaded once the player clears the current one or how can the player choose what level they want to play. I figure out that there is a built-in "SceneHandler" that can be used to swap between scenes and give the impression of multiple levels for a user.

Another important challenge was figuring out how to create a script for the obstacle to spin like a helicopter blade in a horizontal plane, while also taking into consideration the interactions with the enemies, not just the player. I decided in the end that the enemies will have the capabilities of climbing over the obstacle, so that the player could not use the obstacle to its advantage and that the enemies would have an upper hand, creating some sense of balance.

There was a challenge related to the timer displayed in the top-right while writing the script, because I thought it is such an obvious choice for a game so it shouldn't be hard, but I was a bit confused how I should approach it so that it brings some value for the player and it is working as intended. Thought that its use would be most relevant if it displayed the time that took for a level run so that the player could compare attempts and strategies. Given this mentality I decided to make the timer stop after the level ends (either by winning or losing), while also progressing to the next level resets the timer from 00:00 so that each level could be compared separately from each other between attempts. 

Out of the "Next feature to implement for the game" I managed to implement 3 out of 4 feature that I proposed for myself, which I consider a success given that they all had their own challenges to overcome and I was careful not to break already existing functionalities while also trying to preserve a frame-rate independent code mentality so that I would avoid performance issues. 
