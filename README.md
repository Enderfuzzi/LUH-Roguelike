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
Test Project is used for experimental test of functions and seeing how features works. it is used due to a bad prject structure in folders.
## General Idea
- Hack and Slay game in a arena
## Goals of the Game
- Survive
- Collect loot and XP from slayed enemies
- Upgrade weapons and stats to become even more powerful
## Graphics
- 2D
- Top-Down
- Pixelart
## Character
- Has different stats
  - HP
  - Melee Damage
  - Magic Damage
  - Attackspeed
  - Movementspeed
  - Armor
  - Lifesteal
  - Level
  - Ressoruces
- Melee Attack (Sword)
- Range Attack (Magic)
- other Abilites
## Credits
### Developers
- Bennet Hueter
- Ole Brenner
### Used Ressources
- Enviroment: [Rogue Fantasy Castle](https://assetstore.unity.com/packages/2d/environments/rogue-fantasy-castle-164725) by Szadi Art.
- Living creatures: [Roguelike Dungeon Asset Bundle](https://trevor-pupkin.itch.io/roguelike-dungeon-asset-bundle) by Pupkin
- Font: [Bubble Font (Free Version)](https://assetstore.unity.com/packages/2d/fonts/bubble-font-free-version-24987) by Jazz Create Games
- Character: [A load of Overworld 3/4 RPG Sprites](https://opengameart.org/content/a-load-of-overworld-34-rpg-sprites) by Redshrike (Stephen Challener)[^1] [^2]
- Character Animation: [Mage Attack](https://opengameart.org/content/mage-attack) modified version of Character Sprites by k-skills [^2]
- Spell Animations [Spell Animation Spritesheets](https://opengameart.org/content/spell-animation-spritesheets) by Viktor Hahn (Viktor.Hahn@web.de) [^2]
- Enemys [[LPC] Medival fantasy Character Sprites](https://opengameart.org/content/lpc-medieval-fantasy-character-sprites) by wulax [^2]
- Dropable Ressources: [Free Minerals Pixel Art Icons](https://assetstore.unity.com/packages/2d/gui/icons/free-minerals-pixel-art-icons-196216) by CraftPix
[^1]: Modified for usage
[^2]: Link for [opengameart.org](https://opengameart.org/)
## Licence
"Sample text"
## To do List
[Link for 2D Tutorial](https://www.youtube.com/playlist?list=PL0m-AJLtwLv7Fe6Wj32zJIHuHk5jBUDzO) 
- [x] implement Main menu scene
- [x] implement Game scene
- [ ] implement Credit scene
- [x] create arena for first level
- [x] implement character movement
- [x] implement enemy movement and spawn
- [x] add first attack of player and enemys
- [x] add dammage and display currents stats
- [x] add enemy dropping loot
- [x] add upgrades
- [ ] implement a permanent save system for permanent upgrades and game informations
- [ ] implement Permanent shop
- [ ] implement settings
- [ ] implement sound effects
- [ ] add more content...
Bugfixes:
- [ ] fix enemy spawn point with movement