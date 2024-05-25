using Terraria.ID;
using Terraria.ModLoader;

namespace beansvoid.Items
{
	public class Terragon : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.Tooltip.SetDefault("The final weapon \n Destroy everything. In every way. \n made by kook to enjoy life and just make something");
		}

		public override void SetDefaults()
		{
			base.item.damage = 1000000000;
			base.item.noMelee = false;
			base.item.width = 32;
			base.item.height = 32;
			base.item.useTime = 1;
			base.item.useAnimation = 1;
			base.item.useStyle = 1;
			base.item.knockBack = 0f;
			base.item.value = 0;
			base.item.rare = -12;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = false;
		}

		public override void AddRecipes()
		{
		}
	}
}
