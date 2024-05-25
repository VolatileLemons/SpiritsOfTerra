using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace beansvoid.Items
{
	public class StuffedShotgun : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Stuffed Shotgun");
			base.Tooltip.SetDefault("I'm a force of nature \n From deadlight004");
		}

		public override void SetDefaults()
		{
			base.item.damage = 13;
			base.item.ranged = true;
			base.item.noMelee = true;
			base.item.width = 84;
			base.item.height = 10;
			base.item.useTime = 120;
			base.item.useAnimation = 30;
			base.item.useStyle = 5;
			base.item.knockBack = 0f;
			base.item.value = 1002;
			base.item.rare = 2;
			base.item.UseSound = SoundID.Item41;
			base.item.autoReuse = false;
			base.item.shoot = 10;
			base.item.shootSpeed = 10f;
			base.item.useAmmo = AmmoID.Bullet;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0f, 0f);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			for (int i = 0; i <= 15; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5f));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
		}
	}
}
