Version 0.1
Features: 
- Cube Generation. Click the numbered button to generate that size of cube. Press the Back button to go back to cube selection. You can then pick an axis, move up or down that axis, and rotate the side.
-    Use W,S to rotate on X axis
-    Use A,D to rotate on Y axis
-    Use Q,E to rotate on Z axis


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