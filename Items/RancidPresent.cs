using Terraria;
using Terraria.ModLoader;

namespace beansvoid.Items
{
	public class RancidPresent : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Rancid Present");
			base.Tooltip.SetDefault("Just <right> and get a nice surprise");
		}

		public override void SetDefaults()
		{
			base.item.width = 38;
			base.item.height = 46;
			base.item.rare = -12;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(1309);
			player.QuickSpawnItem(3480);
			player.QuickSpawnItem(277);
			player.QuickSpawnItem(744);
			player.QuickSpawnItem(ModContent.ItemType<Misery>());
			player.QuickSpawnItem(109, 3);
			player.QuickSpawnItem(296, 2);
			player.QuickSpawnItem(2322);
			player.QuickSpawnItem(290, 4);
		}
	}
}
