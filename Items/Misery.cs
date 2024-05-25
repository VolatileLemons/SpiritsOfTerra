using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace beansvoid.Items
{
	public class Misery : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Misery Torch");
			base.Tooltip.SetDefault("Makes all bosses have 20 % more health and almost completely changes their normal boring vanilla AI \n Resprites bosses \n Makes biomes much deadlier to traverse and pretty much makes everything deadlier \n 'Are you sure you want to go insane?' \n Inspired by Fargo's Eternity mode");
		}

		public override void SetDefaults()
		{
			base.item.width = 62;
			base.item.height = 62;
			base.item.useTime = 30;
			base.item.useAnimation = 30;
			base.item.useStyle = 4;
			base.item.value = 0;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item103;
		}

		public override bool UseItem(Player player)
		{
			if (!worlddata.miseryactive)
			{
				worlddata.miseryactive = true;
				Main.NewText("Misery has been activated", new Color(255, 0, 255));
				Main.NewText("Prepare to go insane...", new Color(255, 0, 255));
			}
			else
			{
				worlddata.miseryactive = false;
				Main.NewText("Misery has been disabled", new Color(255, 0, 255));
				Main.NewText("Sweet dreams...", new Color(255, 0, 255));
			}
			return true;
		}
	}
}
