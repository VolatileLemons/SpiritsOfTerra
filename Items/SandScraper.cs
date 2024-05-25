using Terraria.ID;
using Terraria.ModLoader;

namespace beansvoid.Items
{
	public class SandScraper : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.Tooltip.SetDefault("Here be dragons");
		}

		public override void SetDefaults()
		{
			base.item.damage = 1000000;
			base.item.noMelee = false;
			base.item.melee = true;
			base.item.width = 32;
			base.item.height = 32;
			base.item.useTime = 500;
			base.item.useAnimation = 500;
			base.item.useStyle = 1;
			base.item.knockBack = 2000f;
			base.item.value = 1000000;
			base.item.rare = -12;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = false;
		}

		public override void AddRecipes()
		{
		}
	}
}
