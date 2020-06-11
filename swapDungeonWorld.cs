using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace swapDungeon {
	public class swapDungeonWorld : ModWorld {
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight){
			int dungeonIndex = tasks.FindIndex(genPass => genPass.Name.Equals("Dungeon"));
			if (dungeonIndex != -1){
				tasks[dungeonIndex] = new PassLegacy("Dungeon", altDungeonGen);
				//replace the default dungeon pass with our own
			}
		}

		private void altDungeonGen(GenerationProgress progress){
			progress.Message = "Creating Dungeon";

			int dungeonSide = getDungeonSideBySnow();

			//vanilla dungeon gen code, but swap which side of the world it's on
			int dunGenX = 0;
			if (dungeonSide == 1) {
				dunGenX = WorldGen.genRand.Next((int)((double)Main.maxTilesX * 0.05), (int)((double)Main.maxTilesX * 0.2));
			}
			else {
				dunGenX = WorldGen.genRand.Next((int)((double)Main.maxTilesX * 0.8), (int)((double)Main.maxTilesX * 0.95));
			}

			int dunGenY = (int)((Main.worldSurface + Main.rockLayer) / 2.0) + WorldGen.genRand.Next(-200, 200);
			WorldGen.MakeDungeon(dunGenX, dunGenY);
		}

		private int getDungeonSideBySnow(){
			//Call any time after pass "Slush Check" (Snow biome) to return the probable value of dungeonSide, because that's a local variable for some reason

			for (int i = 0; i < Main.maxTilesX / 2; i++){ //going from both sides at once, see which hits first
				for (int j = 0; j < Main.maxTilesY; j++){
					if (Main.tile[i, j].active() && Main.tile[i, j].type == 147){ //147 = snow block  Good enough to just check for snow and not ice
						return -1; //left side of world
					}
					if (Main.tile[Main.maxTilesX - i - 1, j].active() && Main.tile[Main.maxTilesX - i - 1, j].type == 147){
						return 1; //right side of world
					}
				}
			}

			return -1; //should never happen, but prefer left ig
		}
	}
}