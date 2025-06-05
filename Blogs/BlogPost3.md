# Development Update 1

During this phase of development, I completed the core player movement mechanics. I also added some visual flair, including a trail effect that activates during the player's second jump and dash, giving the gameplay a more dynamic feel.

A significant portion of the work went into sourcing suitable assets for the environment and designing a demo area set within a castle. This included implementing a camera system that transitions smoothly from one room to another. The transition is triggered by invisible checkpoints placed between rooms, which detect when the player passes through.

I also began working on traps that, upon collision with the player, trigger a death animation and disable player input. This ensures that the character remains motionless after dying. Since a respawn system hasn’t been implemented yet, the player is currently unable to regain control after dying — addressing this will be a priority moving forward.

One of the more challenging aspects was fine-tuning the camera movement. Initially, the camera would overshoot its target position, making it difficult for players to see both their character and the full room clearly. After some tweaking — including repositioning the rooms and adjusting the camera script — I managed to resolve the issue and achieve the intended behavior.

Another small but meaningful addition was implementing audio cues for the dash and jump actions, which helped make the controls feel more responsive and satisfying. I also added background music to make the game feel more engaging and enjoyable, helping to enhance the overall atmosphere of the demo area.

Looking ahead, my next focus will be integrating a proper respawn mechanic that resets the player's position and reactivates input after death. I also plan to begin fleshing out the enemy AI and work on more complex room layouts to better showcase the platforming mechanics and trap interactions. There’s still a long way to go, but progress so far has been steady and rewarding.


Features to implement:

Sun rays and player death if staying too long in them

✅Player dash/transform

✅First level environment

❌Shrines for refreshing the player's ability to dash(This has been replaced by giving the ability a cooldown)

UI(should include dash ability availability, timer for level)

Main menu and pause screen

✅OST/Sound effects to add to the game
