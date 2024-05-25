using beansvoid.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace beansvoid.Items
{
	public class Verbera : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.Tooltip.SetDefault("Bring forth a barrage of swords from the palm of your hand");
		}

		public override void SetDefaults()
		{
			base.item.damage = 200;
			base.item.magic = true;
			base.item.noMelee = true;
			base.item.mana = 6;
			base.item.width = 32;
			base.item.height = 38;
			base.item.useTime = 14;
			base.item.useAnimation = 14;
			base.item.useStyle = 5;
			base.item.knockBack = 3f;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item71;
			base.item.value = 220200;
			base.item.autoReuse = true;
			base.item.shoot = ModContent.ProjectileType<VerberaProjectile>();
			base.item.shootSpeed = 22f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i < 5; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(9f));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(3787);
			modRecipe.AddIngredient(3570);
			modRecipe.AddIngredient(3457, 18);
			modRecipe.AddIngredient(501, 12);
			modRecipe.AddIngredient(520, 6);
			modRecipe.AddIngredient(526, 3);
			modRecipe.AddIngredient(528, 3);
			modRecipe.AddTile(412);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
