# locomotion-vr-tests
Unity scene using GoogleVR, testing some player locomotion ideas with limited user input.

![Unity Screenshot](screenshot.png)

### View Marker Locomotion

The first thing I wanted to test was an idea I blogged about here: http://blog.hiash.com/2016/08/vr-teleportation-mechanic_1.html

![Programmer art of locomotion mechanic idea](https://2.bp.blogspot.com/-4lSMxekiVF8/V5-laWADuiI/AAAAAAACz4A/2_WqgB7i2X81k13Y-wSsnL_mVe8g3LdtQCLcB/s1600/MarkerViewTeleport.jpg)

See a video of this movement mode in action here: https://youtu.be/ou8TKis23rc

The player is able to look around the scene by moving their head. By gazing at a spot on the floor and tapping, a View Marker will be placed. By gazing at some other point and tapping, the player will teleport, (actually, just move quickly,) to that second spot. When they reach it, the player's (virtual) body will turn to face the View Marker they first placed. Note that the head rotates independently from the body so your eyes may not be facing the view marker directly unless your head is facing forwards. The player can then repeat this by placing the View Marker again.

Alternatives could be made to this, such as persisting the View Marker until the player wants to reposition it, (easier if we had more buttons, but could be done with a long tap or by tapping directly on the View Marker to pick it up.)

### Other Locomotion Modes

You can switch to other modes by clicking a button on the "ceiling" of the scene.

The only other mode included so far is a fast-move teleport, which just moves to the player to the point they select.
