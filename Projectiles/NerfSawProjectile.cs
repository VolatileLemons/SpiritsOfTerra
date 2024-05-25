using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace beansvoid.Projectiles
{
	public class NerfSawProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			base.projectile.width = 22;
			base.projectile.height = 22;
			base.projectile.aiStyle = 20;
			base.projectile.friendly = true;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = false;
			base.projectile.hide = true;
			base.projectile.ownerHitCheck = true;
			base.projectile.melee = true;
		}

		public override void AI()
		{
			int dust = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 6, base.projectile.velocity.X * 0.2f, base.projectile.velocity.Y * 0.2f, 100, default(Color), 1.9f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(10))
			{
				target.AddBuff(24, 180);
			}
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool(10))
			{
				target.AddBuff(24, 180, quiet: false);
			}
		}
	}
}
