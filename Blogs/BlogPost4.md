# Development Update 2

In this development cycle, I focused on expanding the core gameplay systems, starting with the implementation of a proper respawn mechanic. I placed doors in each room that act as checkpoints — when the player passes by one, the door opens to indicate it has been activated. If the player dies, they now respawn at the last activated checkpoint. This adds a better sense of progression and removes some of the frustration during testing, especially in rooms with traps.

Another major addition was the light-based mechanic. The player can only remain in lit areas for a limited amount of time — specifically, 3 seconds. During this countdown, the character begins to blink red to warn the player that time is running out. If they don't leave the lit area in time, it results in death and triggers the respawn system. This mechanic added a layer of tension and urgency to the exploration and made the movement and timing feel more meaningful.

I also introduced a basic enemy AI to bring some challenge into the environment. These enemies currently patrol left and right along a defined path. I set up a simple patrol script using waypoints and physics-based movement, which gives the AI a predictable but effective presence in the level. Alongside the logic, I created animations for walking, idle and attacking states, which switch appropriately based on the AI’s movement.

To expand on enemy behavior, I added an attack script that detects when the player enters a defined range in front of the enemy. When triggered, the AI briefly stops moving and plays an attack animation. If the player is hit during this time, the same death and respawn process is initiated. This simple mechanic is enough to create tense moments, especially when combined with traps or the light countdown mechanic.

Getting the animations to sync with the movement and attacks required some fine-tuning, especially ensuring the transitions felt smooth and that hitboxes triggered at the right moment. I also had to refine the attack timing so that it was fair and gave the player a chance to escape if they reacted quickly enough.

Moving forward, I plan to continue working through the remaining items on the to-do list, with a particular focus on level design. Now that most of the core mechanics are in place, the next step is to populate the rooms with traps, enemies, and structures to make the gameplay more engaging and dynamic.


Features to implement:

✅Sun rays and player death if staying too long in them

✅Player dash/transform

✅First level environment

❌Shrines for refreshing the player's ability to dash(This has been replaced by giving the ability a cooldown)

❌UI(should include dash ability availability, timer for level) (The UI will be minimalistic to let the player have the whole room in view)

Main menu and pause screen

✅OST/Sound effects to add to the game
