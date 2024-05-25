using beansvoid.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace beansvoid.Items
{
	public class NerfSaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Sensational Shredder");
			base.Tooltip.SetDefault("Works as a weapon to shred your foes and as a tool to destroy the forests... quite handy");
		}

		public override void SetDefaults()
		{
			base.item.damage = 325;
			base.item.melee = true;
			base.item.width = 20;
			base.item.height = 12;
			base.item.useTime = 7;
			base.item.useAnimation = 25;
			base.item.channel = true;
			base.item.noUseGraphic = true;
			base.item.noMelee = true;
			base.item.axe = 250;
			base.item.tileBoost++;
			base.item.useStyle = 5;
			base.item.knockBack = 2f;
			base.item.value = 123465;
			base.item.rare = 9;
			base.item.UseSound = SoundID.Item23;
			base.item.autoReuse = true;
			base.item.shoot = ModContent.ProjectileType<NerfSawProjectile>();
			base.item.shootSpeed = 40f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0f, 7f);
		}
	}
}
