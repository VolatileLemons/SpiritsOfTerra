using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace beansvoid.Npcs
{
	public class global : GlobalNPC
	{
		public override bool Autoload(ref string name)
		{
			return true;
		}

		public override void AI(NPC npc)
		{
			if (worlddata.miseryactive)
			{
				npc.scale = 5f;
				npc.color = Color.ForestGreen;
			}
		}
	}
}
