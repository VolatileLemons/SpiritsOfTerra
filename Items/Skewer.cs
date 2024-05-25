using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace beansvoid.Items
{
	public class Skewer : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.Tooltip.SetDefault("One hit is all It takes");
		}

		public override void SetDefaults()
		{
			base.item.damage = 1000000;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.width = 32;
			base.item.height = 32;
			base.item.useTime = 600;
			base.item.useAnimation = 6;
			base.item.useStyle = 5;
			base.item.knockBack = 2000f;
			base.item.value = 1000000000;
			base.item.rare = 12;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = false;
			base.item.shoot = 400;
			base.item.shootSpeed = 100f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3f, -3f);
		}

		public override void AddRecipes()
		{
		}
	}
}
