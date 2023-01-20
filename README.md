# LUH_Roguelike
## Git Commands
Basic:
```
git pull # updates local repo
git status # shows current status
git add <name> # stages a file 
git commit -m "sample text" # commits with a message
git push  # pushes changes into repo
```
Advanced:
```
git branch <name> # creates a new branch
git checkout <name> # changes work dir to that branch
git merge <name> # merges local braches into master
```
## General Information
This Project has not a real title. I call it "Magic Fighter". Its my first usage of Unity and its components.
The game has a few known bugs with enemy movements. Furthermore the code could be heavily optimized in structure and repition.

My Goals: 
- create a walkable area with hitboxes
- create a character which can be moved by player
- get a feeling for hitboxes and how collission works
- understanding of how textures work in a top-down game
- creating projectiles which are moving to the screen
- understanding of how animations works with different stages
- understanding of how raycasts can be used to determine enemy actions and movement

## General Idea
- Inital Idea: Hack and Slay game in a arena
- Interested in Roguelikes: Hades, Brotato, 20 Minutes Till Dawn  
- Only vertival and Horizontal movement is allowed 
- Only vertical and Horizontal shooting is allowed
## Goals of the Game
- Survive
- Collect loot and XP from slayed enemies
- Upgrade stats to become even more powerful
## Graphics
- 2D
- Top-Down
- Pixelart
## Character
- Has different stats
  - HP
  - Damage
  - Attackspeed
  - Movementspeed
  - Armor
  - Lifesteal
  - Level
  - Ressources
## Credits
### Developers
- Ole Brenner
Note: My partner decided to redo this modul later. He did not participate in the planning and creation of the project.
### Used Ressources
All rights are by the creator of the ressources. I do not own any of the linked ressources. Modifications are marked.
- Enviroment: [Rogue Fantasy Castle](https://assetstore.unity.com/packages/2d/environments/rogue-fantasy-castle-164725) by Szadi Art.
- Living creatures: [Roguelike Dungeon Asset Bundle](https://trevor-pupkin.itch.io/roguelike-dungeon-asset-bundle) by Pupkin
- Font: [Bubble Font (Free Version)](https://assetstore.unity.com/packages/2d/fonts/bubble-font-free-version-24987) by Jazz Create Games
- Character: [A load of Overworld 3/4 RPG Sprites](https://opengameart.org/content/a-load-of-overworld-34-rpg-sprites) by Redshrike (Stephen Challener)[^1] [^2]
- Character Animation: [Mage Attack](https://opengameart.org/content/mage-attack) modified version of Character Sprites by k-skills [^2]
- Spell Animations [Spell Animation Spritesheets](https://opengameart.org/content/spell-animation-spritesheets) by Viktor Hahn (Viktor.Hahn@web.de) [^2]
- Enemys [[LPC] Medival fantasy Character Sprites](https://opengameart.org/content/lpc-medieval-fantasy-character-sprites) by wulax [^2]
- Dropable Ressources: [Free Minerals Pixel Art Icons](https://assetstore.unity.com/packages/2d/gui/icons/free-minerals-pixel-art-icons-196216) by CraftPix
- Main Menu Sound: [Hopping Harmony](https://opengameart.org/content/hopping-harmony) by Magnesus Credit: Tomasz Kucza [^2]
- Button Sound: [Menu Click Sound](https://opengameart.org/content/menu-selection-click) by NenadSimic [^2]
- Level Up Sound: [Completion sound](https://opengameart.org/content/completion-sound) by Brandon Morris (Submitted by HaelDB) [^2]
- Death Sound: [Game Over Theme](https://opengameart.org/content/game-over-theme) by [Cleyton Kauffman](https://soundcloud.com/cleytonkauffman) [^2]
- Battle Music: [Egipet Battle Music](https://opengameart.org/content/egipet-battle-music) by Alex_089 [^2]
- Shop Background Music: [Free Music background (looping)](https://opengameart.org/content/free-music-background-looping) by Ali Hraich [^2]

[^1]: Modified for usage
[^2]: Link for [opengameart.org](https://opengameart.org/)


## Licence
This project is only build for educational reasons especially this project is not build for commercial purposes or beeing published in any larger enviroment than for correcting, evaluating or presentation. Its is allowed to be distributed with this contex within the Leibniz University Hannover. Furthermore it is allowed to show this project as exsample for later courses. <br>

For further restribution, other usages or questions feel free to ask: ole.brenner@stud.uni-hannover.de
## To do List
[Link for 2D Tutorial](https://www.youtube.com/playlist?list=PL0m-AJLtwLv7Fe6Wj32zJIHuHk5jBUDzO) 
- [x] implement Main menu scene
- [x] implement Game scene
- [x] implement Credit scene
- [x] create arena for first level
- [x] implement character movement
- [x] implement enemy movement and spawn
- [x] add dammage and display currents stats
- [x] add enemy dropping loot
- [x] add upgrades
- [x] implement a permanent save system for permanent upgrades and game informations
- [x] implement Permanent shop
- [x] implement settings
- [x] implement sound effects
- [ ] add more content...
Bugfixes:
- [x] fix enemy spawn point with movement
- [x] fix that player can shot and walk
- [x] fix that enemey  can shot and walk