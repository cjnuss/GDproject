# GD Project - Team 2

## Program Controls
### General Game Commands
If at any time you wish to exit the game, it can be simply done with the press of the Q key on your keyboard. We currently have a feature which allows you to reset the room to its original state by pressing the reset key, R.

### Link Movement
Link can be moved around the screen by pressing the W,A,S,D or arrow keys. This will cause Link to be move up, left, right, or down with respect to the keys.

### Link Attacking
Link has several different options to attack with. Currently, Link is starting with an infinite number of green arrows, fire, and bombs. These items can be used by pressing the 1, 2, and 3 number keys on the top of your keyboard respectively. Link also has the ability to perform a sword attack. This can be accessed by pressing either the Z or N key.

### Dungeon Room Transition
Currently, Mouse input is required to transition between different rooms in the dungeons. A left-click will transition to the next room, and a right-click will transition to the previous room. Currently, we have three rooms, and the fourth room is used for debugging purposes with all items present.

## Known Bugs
### Gamestate Transitions
We currently have a bug where an action is only performed while the key is being pressed; for example, a green arrow throw will only be completed if the 1 key is held down. The expected behavior is that when you press the 1 key once, the green arrow will fire and continue as normal. This bug is present with all of Link's attack states and item attacks and is currently in the process of being addressed.

### Collision
We are aware of multiple issues with collision in our code which either produce unusual or unexpected behavior. These issues are also in the process of debugging and are currently being addressed.
