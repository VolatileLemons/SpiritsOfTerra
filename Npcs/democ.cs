using Terraria;
using Terraria.ModLoader;

namespace beansvoid.Npcs
{
	public class democ : ModNPC
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Cursed Eye");
		}

		public override void SetDefaults()
		{
			base.npc.CloneDefaults(2);
			animationType = 2;
		}

		public override void FindFrame(int frameHeight)
		{
			base.npc.frameCounter -= 0.5;
			base.npc.frameCounter %= Main.npcFrameCount[base.npc.type];
			int frame = (int)base.npc.frameCounter;
			base.npc.frame.Y = frame * frameHeight;
		}
	}
}
