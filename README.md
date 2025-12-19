# test-ojbect-to-world-interaction
A template that includes a first-person character controller. This serves as the base for a small coding and design test

## Instructions

You're tasked with creating an object-placement system. Similar to below, but not quite like this:
![touch-test_360](https://github.com/user-attachments/assets/f2bf46e5-edf8-49e7-b87f-7a82e94b8df5)

- Choose from a range of items in your inventory.
- Determine the best, most fun, user-friendly and intuitive way to place these items from your menu, into the 3D world.
  - You choose if the best way is drag/drop or click to enter placement-mode, or any other way you think will work.
  - When placed, items should stand upright on whichever surface you place them on.
  - Avoid invalid surfaces
- It should be possible to move and delete items after placing them. You determine the best UI/UX approach here as well.
- It should not clash with the user movement system. Again, you choose the best way with this, you could toggle UI-interaction, or make it so camera-control is only when holding right-click, etc. Up to you.
- The inventory can float or be a pop-up, whatever you think is best.
- The inventory should be able scalable, you can demonstrate with 10-20 items but we'd like to see it can scale easily to hold hundreds.
- The items can just be arrangements of cubes and spheres with different materials on them.

We aim to gain insights regarding around your design sensibilities with regards to functionality and user experience, your approach to code and your command of Unity components. How you explain your process will help as well. We're not trying to take too much of your time for the test, aiming for 2-3 hours would be reasonable.

You're provided with a first-person character controller and a village environment to get you started, feel free to modify, replace these in any way you see fit so that it works nicely with your inventory and object placement. You'll mainly be tested on your approach with the UI required for this task, though any extra effort will be taken into account.

## Repository setup requirements

This repository uses Git LFS for large .tif files.

1. Clone and initialize with Git LFS:
  ```bash
  git clone <repo-url>
  cd <repo>
  git lfs install
  git lfs pull
  ```
2. Open project in Unity 2022.3.62f3.
3. Open Test scene. Path: `Assets/Custom/Scenes/Test.unity`.
4. The scene should have a small village and a player called `FirstPersonCharacterController` for you to test with.
5. Add UI and object-placement functionality. Have fun!
