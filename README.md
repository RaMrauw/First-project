2025.11.07

## Description
My first project I want to do is something like Kawairun. 
I loved playing that game as a kid.
I won't be doing it exactly the same, but since I remember the gameplay, I'll try to add new mechanics.

## Goals
- Create a simple 2D/3D runner with parallax
- Add obstacles and player movement mechanics
『Add optional buffs later』

## Current Plan
1. **Location**
   - Parallax background
   - Procedurally generated obstacles

2. **Player**
   - Forward-only running
   - Jumping
   - Sliding under obstacles

##  Notes
I don't like working on jump mechanics because they often have many tricky parts.  
No strict deadlines — will progress step-by-step.
I hope I can do it.

## Tech Stack
- Unity
- C#
- Blender
- Photoshop

## Progress
- [x] Planning
- [ ] Running
- [ ] Jumping
- [ ] Sliding
- [ ] Buff mechanics


# 2025.11.10

## Description
I think making a mobile app is the most optimal solution.  
I had problems with choosing the movement mechanism, but now my "running" is ready — if we can call it that. I can slightly speed up or slow down.  

Jumping is also implemented, but it had some difficulties. I need to check if the character is on the ground.  
During the process of making a double jump, I discovered a funny bug which became a feature: instead of a double jump, the character can pause in the air, and when stamina runs out, they fall.  

Sliding is also implemented — basically just reducing the player's hitbox.

Now I will think about the next stage. I will consider buffs later — maybe something interesting will come up.  
The next step will be environment setup, creating the background: parallax layers and a minimal UI.

## Progress
- [x] Planning
- [x] Running
- [x] Jumping
- [x] Sliding
- [ ] Buff mechanics
