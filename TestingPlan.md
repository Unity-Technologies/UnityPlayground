# Unity Playground - Test Plan

This document contains instructions on how to test the Unity Playground before an update is released.

### 001 - Custom Inspectors

**How to test:** Create a GameObject, inspect its Transform. Add various components and look at the Inspectors.  
**Expected result:** The custom Inspectors shown and no errors are produced in the console. To recognise the custom Inspectors:
- The Transform has coloured labels (red, green, blue) to the left of the properties, that identify the X, Y, Z axes.
- All Colliders2D have less properties than usual, and a foldout at the end called "Extra Options".
- The Camera Inspector only shows Frame Size, Background Color, and a button named "Add Camera Follow Script".

### 002 - Disable custom Inspectors
**How to test:** Go to the top menu and click on the menu item **Playground > Custom Inspectors**.
**Expected result:** By default, Inspectors should be custom and the menu item should show a ✔️ checkmark. Ensure that this is what happens when the Editor is launched.  
If clicking on the menu item, after a recompile, the Inspectors now show their regular properties. Also, the checkmark on the menu item is gone.  
If the Editor is restarted, the custom Inspectors should be visualised again.

### 003 - Test the included sample games
**How to test:** Open the scenes in 📂 **Unity Technologies/Playground/Examples**, and press Play.
**Expected result:**
- **Adventure**  
Controls: WASD to move  
Gameplay: Move the character, avoid the bees and collect the stars. 3 stars should show "Player 1 wins!". If touched by a bee, the player should lose 1 health, until the game goes into game over.
- **Defender**  
Controls: AD to rotate the cannon, Spacebar to shoot  
Gameplay: Hit the falling asteroids. Each successful hit grants 1 point. If an asteroid hits the ground, the player loses 1 health, until game over.
- **Football**  
Controls: WASD to move character 1, Arrows to move character 2  
Gameplay: Move the characters and run them into the ball, to push it in the opponent's goal. Each time one scores, they get a point and the screen shows an explosion of confetti. At 3 goals, whichever player reaches that wins the match.
- **Lander**  
Controls: AD to rotate the cannon, Spacebar to fly  
Gameplay: Lift-off from the platform to the left, and land on the platform to the right. If the player manages, they win. If they land upside down, they explode and get a game over.
- **Maze**  
Controls: WASD to move  
Gameplay: Move the character through the maze. Collecting the coins is optional, but they should grant 1 point each.  
Get to the flag, and the game should load another level (scene named "MazeLevel1"). Get to the second flag, and the game will say "Player 1 wins!".
- **Roguelike**  
Controls: WASD to move  
Gameplay: Move the character in front of the merchant. They should say "Give me 3 coins in exchange for a key.".  
Collect the 3 coins. They should appear to the left in the UI.  
Go back to the merchant. The coins will be consumed, and a key will appear. Grab it, it should appear in the UI too.  
Go to the door. The key is consumed, and the door disappears.  
Go inside the grotto. A star should appear where the sparks are. The player can collect it too, and it will show up in the UI.