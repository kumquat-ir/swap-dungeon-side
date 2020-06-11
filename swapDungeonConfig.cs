using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace swapDungeon {
	public class swapDungeonConfig : ModConfig {
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[DefaultValue(false)]
		[Label("Randomize Dungeon Side")]
		[Tooltip("When enabled, randomizes which side of the world the dungeon generates on instead of setting to jungle side")]
		public bool randomizeSide;
	}
}