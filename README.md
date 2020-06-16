# Change Dungeon Side
Simple tModLoader mod for Terraria that changes the side of the world the dungeon generates on

Download from the mod browser (Change Dungeon Side) or get the .tmod file from the releases tab

<p align="center">
<img src="http://javid.ddns.net/tModLoader/widget/widgetimage/swapDungeon.png"/>
</p>

## Technical stuff
Turns out, getting the side of the world that the dungeon would be on is fairly hard.  So I had to write a function that detects which side of the world the snow biome is on, and use that to determine which side the dungeon would be on.  As far as I can tell, this is the earliest in worldgen you can do this.

If you want to yoink that function (getDungeonSideBySnow() in swapDungeonWorld.cs), feel free!

There's an easier way to find this after the dungeon is generated, by checking which side of the world dungeonX is on:
```cs
int dungeonSide = (WorldGen.dungeonX < Main.maxTilesX / 2) ? -1 : 1;
```
