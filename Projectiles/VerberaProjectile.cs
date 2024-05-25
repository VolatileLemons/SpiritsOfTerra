using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace beansvoid.Projectiles
{
	internal class VerberaProjectile : ModProjectile
	{
		public override void AI()
		{
			base.projectile.rotation = base.projectile.velocity.ToRotation();
			int DustID = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y + 2f), base.projectile.width + 4, base.projectile.height + 4, 264, base.projectile.velocity.X * 0.2f, base.projectile.velocity.Y * 0.2f, 120, default(Color), 0.5f);
			Main.dust[DustID].noGravity = true;
		}

		public override void SetDefaults()
		{
			base.projectile.width = 46;
			base.projectile.height = 21;
			base.projectile.friendly = true;
			base.projectile.magic = true;
			base.projectile.timeLeft = 300;
			aiType = 660;
		}

		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			Main.PlaySound(25, base.projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(145, 300);
		}
	}
}
