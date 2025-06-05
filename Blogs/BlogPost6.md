# Final Update (06/05/2025)

As the project deadline approached, development shifted toward wrapping things up and ensuring a playable and complete experience could be delivered in time. Unfortunately, due to time constraints, I wasn’t able to complete the design and implementation of the three additional levels that were originally planned. However, to provide a sense of closure for the player, I added a new final room to the game.

This last room includes a simple but symbolic reward: a coffee cup. When the player reaches it and makes contact, a win screen is triggered, signaling the successful completion of the game. 

To raise the difficulty a bit and make the transitions between rooms more engaging, I also implemented a new obstacle: moving doors between certain rooms. These doors rise and fall on a timed cycle, forcing the player to time their movement carefully to pass through. While the mechanic is simple, it adds a bit more challenge and helps keep the gameplay from feeling too static in the final moments of the experience.

During playtesting with friends, an interesting bug was discovered — if the player died with enough momentum, their character could still fly forward after triggering the death animation. In some cases, this caused them to pass through checkpoints post-mortem, effectively saving their progress despite dying along the way. After considering the impact, I decided to keep this behavior in the game. It unintentionally added a playful twist and opened up the possibility for speedrunning tricks and creative shortcuts, which added charm and replayability to an otherwise linear experience.

While not every planned feature made it into the final build, I’m proud of how much was accomplished during the project timeframe. From core mechanics and enemy behavior to UI polish and arcade machine compatibility, the game has grown into a complete and playable prototype that reflects the original vision. It’s been a great learning experience in managing scope, solving unexpected challenges, and pulling together a cohesive game under a tight deadline.


Features to implement:

✅Sun rays and player death if staying too long in them

✅Player dash/transform

✅First level environment

❌Shrines for refreshing the player's ability to dash(This has been replaced by giving the ability a cooldown)

❌UI(should include dash ability availability, timer for level) (The UI will be minimalistic to let the player have the whole room in view)

✅Main menu and pause screen

✅OST/Sound effects to add to the game
