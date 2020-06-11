using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace swapDungeon {
	public class swapDungeonConfig : ModConfig {
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[DefaultValue(false)]
		[Label("Randomize Dungeon Side")]
		[Tooltip("When enabled, randomizes which side of the world the dungeon generates on instead of setting to jungle side")]
		public bool randomizeSide;
	}
}