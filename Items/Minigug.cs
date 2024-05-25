using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace beansvoid.Items
{
	public class Minigug : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Scorch Volley");
			base.Tooltip.SetDefault("Shoot with gamebreaking speed! \n Not for the faint of heart");
		}

		public override void SetDefaults()
		{
			base.item.damage = 222;
			base.item.ranged = true;
			base.item.noMelee = true;
			base.item.width = 84;
			base.item.height = 10;
			base.item.useTime = 3;
			base.item.useAnimation = 1;
			base.item.useStyle = 5;
			base.item.knockBack = 0f;
			base.item.value = 1000000;
			base.item.rare = 10;
			base.item.UseSound = SoundID.Item41;
			base.item.autoReuse = true;
			base.item.shoot = 242;
			base.item.shootSpeed = 10f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0f, 7f);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i <= 4; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5f));
				Projectile.NewProjectile(position.X, position.Y + 10f, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(1929);
			modRecipe.AddIngredient(3475);
			modRecipe.AddIngredient(175, 12);
			modRecipe.AddIngredient(3467, 12);
			modRecipe.AddIngredient(3456, 18);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
