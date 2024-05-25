using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace beansvoid.Npcs
{
	public class CelesitalJelly : ModNPC
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Celestial Jelly");
			Main.npcFrameCount[base.npc.type] = 2;
		}

		public override void SetDefaults()
		{
			base.npc.lifeMax = 200;
			base.npc.damage = 1000;
			base.npc.defense = 1000;
			base.npc.knockBackResist = 0.3f;
			base.npc.width = 26;
			base.npc.height = 56;
			base.npc.aiStyle = 1;
			base.npc.noGravity = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath6;
			base.npc.value = Item.buyPrice(0, 0, 15);
			animationType = 81;
		}
	}
}
