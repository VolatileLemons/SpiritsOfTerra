using beansvoid.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace beansvoid.Items
{
	public class lasergun : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("H.D.L");
			base.Tooltip.SetDefault("High Density Laser \n Will consume very high amounts of mana");
		}

		public override void SetDefaults()
		{
			base.item.damage = 2000;
			base.item.noMelee = true;
			base.item.magic = true;
			base.item.channel = true;
			base.item.mana = 200;
			base.item.rare = -12;
			base.item.width = 28;
			base.item.height = 30;
			base.item.useTime = 20;
			base.item.UseSound = SoundID.Item13;
			base.item.useStyle = 5;
			base.item.shootSpeed = 14f;
			base.item.useAnimation = 20;
			base.item.shoot = ModContent.ProjectileType<hdLaser>();
			base.item.value = 3000000;
		}
	}
}
