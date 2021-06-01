5/27/21
Version 0.1
This will be a Here To Slay analysis tool.
I wanted a way to determine the strengths of different hands and combinations of cards,
so I'm designing this code to help with that.

<<<<<<< HEAD
Taking the old rubik code and repurposing that, instead of starting from scratch.
=======
2x2 and 3x3 fully functional.

---------------------------------

Activity Log:

12/14/20
Added Readme.md

12/15/20
Fixed Green face in wrong location

Moved Cube to 0,0,0 so rotation is centered

Trying to get a button to work on a HUD/CanvasLayer

12/16/20
Added ability to press buttons to get different cube sizes

Added back button to go back to cube selection screen

Added black backdrop to cube

To create outline of section to be turned, can make series of meshes that outline the section

Could also create rotating axis that changes depending on rotation of cube, so axes of rotation always clear

Maybe should also put camera at ground level, so rotation is more intuitive

12/17/20
still working on bounding box, and space constant wonkiness

12/18/20
fixed rotation bug when no cube present, made it so sides visible and no spacing constant needed.

Bounding box successfully added; takes same vector input as twistSide, so when selecting a side an outline will be created.

Can now select a side and rotate it; movements are absolute, and
saw weird visual glitches when moving too many pieces. Has something to do with piece location not being updated correctly.

12/22/20
noticed that pieces become rotated slightly when twisting a side
while cube view is rotated. Can fix that by having the Camera move instead. Also, almost have corners rotating correctly (meaning the 2x2 will soon be functional)

2x2 is functional. Corners working. Working on a hardcoded system for 3x3 edges, so maybe a pattern for all sizes will develop.

12/23/20
modified background, no longer a flat plane but a godot environment variable

Updated cube rotation; now, camera spins around cube. Still needs fine tuning,
but eliminates the problem of the cube coordinates being mangled.

12/24/20
fine tuned viewing code, might consider making a series of buttons to choose a corner and orientation, remove all vagueness

added reset cube button, hard coded 3x3 edge movements

3/25/20
Just testing 3x3 for now; Most of the edges are bad. In fact, only 1 is correct.
NO  1,2 -> 0,3 (-2,2)   -- move_vec_2 = (2,-2)
NO  2,1 -> 2,3 (0,4)    -- move_vec_2 = (4,0)
NO  2,3 -> 0,4 (-4,2)   -- move_vec_2 = (2,-4)
YES 3,2 -> 2,3 (-2,2)   -- move_vec_2 = (2,-2)
>>>>>>> parent of 561fdd2 (fixed edges going clockwise)
