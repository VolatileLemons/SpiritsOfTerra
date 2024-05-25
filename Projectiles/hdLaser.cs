using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace beansvoid.Projectiles
{
	public class hdLaser : ModProjectile
	{
		private const float MAX_CHARGE = 2000f;

		private const float MOVE_DISTANCE = 130f;

		public float Distance
		{
			get
			{
				return base.projectile.ai[0];
			}
			set
			{
				base.projectile.ai[0] = value;
			}
		}

		public float Charge
		{
			get
			{
				return base.projectile.localAI[0];
			}
			set
			{
				base.projectile.localAI[0] = value;
			}
		}

		public bool IsAtMaxCharge => Charge == 2000f;

		public override void SetDefaults()
		{
			base.projectile.width = 10;
			base.projectile.height = 10;
			base.projectile.friendly = true;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = false;
			base.projectile.magic = true;
			base.projectile.hide = true;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			if (IsAtMaxCharge)
			{
				DrawLaser(spriteBatch, Main.projectileTexture[base.projectile.type], Main.player[base.projectile.owner].Center, base.projectile.velocity, 10f, base.projectile.damage, -1.57f, 1f, 1000f, Color.White, 130);
			}
			return false;
		}

		public void DrawLaser(SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 unit, float step, int damage, float rotation = 0f, float scale = 1f, float maxDist = 2000f, Color color = default(Color), int transDist = 50)
		{
			float r = unit.ToRotation() + rotation;
			for (float i = transDist; i <= Distance; i += step)
			{
				Color c = Color.White;
				Vector2 origin = start + i * unit;
				spriteBatch.Draw(texture, origin - Main.screenPosition, new Rectangle(0, 26, 28, 26), (i < (float)transDist) ? Color.Transparent : c, r, new Vector2(14f, 13f), scale, SpriteEffects.None, 0f);
			}
			spriteBatch.Draw(texture, start + unit * ((float)transDist - step) - Main.screenPosition, new Rectangle(0, 0, 28, 26), Color.White, r, new Vector2(14f, 13f), scale, SpriteEffects.None, 0f);
			spriteBatch.Draw(texture, start + (Distance + step) * unit - Main.screenPosition, new Rectangle(0, 52, 28, 26), Color.White, r, new Vector2(14f, 13f), scale, SpriteEffects.None, 0f);
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			if (!IsAtMaxCharge)
			{
				return false;
			}
			Player player = Main.player[base.projectile.owner];
			Vector2 unit = base.projectile.velocity;
			float point = 0f;
			return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.Center, player.Center + unit * Distance, 22f, ref point);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.projectile.owner] = 5;
		}

		public override void AI()
		{
			Player player = Main.player[base.projectile.owner];
			base.projectile.position = player.Center + base.projectile.velocity * 130f;
			base.projectile.timeLeft = 2;
			UpdatePlayer(player);
			ChargeLaser(player);
			if (!(Charge < 2000f))
			{
				SetLaserPosition(player);
				SpawnDusts(player);
				CastLights();
			}
		}

		private void SpawnDusts(Player player)
		{
			Vector2 unit = base.projectile.velocity * -1f;
			Vector2 dustPos = player.Center + base.projectile.velocity * Distance;
			for (int i = 0; i < 2; i++)
			{
				float num1 = base.projectile.velocity.ToRotation() + ((Main.rand.Next(2) == 1) ? (-1f) : 1f) * 1.57f;
				float num2 = (float)(Main.rand.NextDouble() * 0.800000011920929 + 1.0);
				Vector2 dustVel = new Vector2((float)Math.Cos(num1) * num2, (float)Math.Sin(num1) * num2);
				Dust obj = Main.dust[Dust.NewDust(dustPos, 0, 0, 226, dustVel.X, dustVel.Y)];
				obj.noGravity = true;
				obj.scale = 1.2f;
				Dust dust2 = Dust.NewDustDirect(Main.player[base.projectile.owner].Center, 0, 0, 31, (0f - unit.X) * Distance, (0f - unit.Y) * Distance);
				dust2.fadeIn = 0f;
				dust2.noGravity = true;
				dust2.scale = 0.88f;
				dust2.color = Color.Cyan;
			}
			if (Main.rand.NextBool(5))
			{
				Vector2 offset = base.projectile.velocity.RotatedBy(1.5700000524520874) * ((float)Main.rand.NextDouble() - 0.5f) * base.projectile.width;
				Dust dust = Main.dust[Dust.NewDust(dustPos + offset - Vector2.One * 4f, 8, 8, 31, 0f, 0f, 100, default(Color), 1.5f)];
				dust.velocity *= 0.5f;
				dust.velocity.Y = 0f - Math.Abs(dust.velocity.Y);
				unit = dustPos - Main.player[base.projectile.owner].Center;
				unit.Normalize();
				dust = Main.dust[Dust.NewDust(Main.player[base.projectile.owner].Center + 55f * unit, 8, 8, 31, 0f, 0f, 100, default(Color), 1.5f)];
				dust.velocity *= 0.5f;
				dust.velocity.Y = 0f - Math.Abs(dust.velocity.Y);
			}
		}

		private void SetLaserPosition(Player player)
		{
			for (Distance = 130f; Distance <= 2200f; Distance += 5f)
			{
				Vector2 start = player.Center + base.projectile.velocity * Distance;
				if (!Collision.CanHit(player.Center, 1, 1, start, 1, 1))
				{
					Distance -= 5f;
					break;
				}
			}
		}

		private void ChargeLaser(Player player)
		{
			if (!player.channel)
			{
				base.projectile.Kill();
				return;
			}
			if (Main.time % 10.0 < 1.0 && !player.CheckMana(player.inventory[player.selectedItem].mana, pay: true))
			{
				base.projectile.Kill();
			}
			Vector2 offset = base.projectile.velocity;
			offset *= 110f;
			Vector2 pos = player.Center + offset - new Vector2(10f, 10f);
			if (Charge < 2000f)
			{
				Charge++;
			}
			int chargeFact = (int)(Charge / 20f);
			Vector2 dustVelocity = Vector2.UnitX * 18f;
			dustVelocity = dustVelocity.RotatedBy(base.projectile.rotation - 1.57f);
			Vector2 spawnPos = base.projectile.Center + dustVelocity;
			for (int k = 0; k < chargeFact + 1; k++)
			{
				Vector2 spawn = spawnPos + ((float)Main.rand.NextDouble() * 6.28f).ToRotationVector2() * (12f - (float)(chargeFact * 2));
				Dust obj = Main.dust[Dust.NewDust(pos, 20, 20, 226, base.projectile.velocity.X / 2f, base.projectile.velocity.Y / 2f)];
				obj.velocity = Vector2.Normalize(spawnPos - spawn) * 1.5f * (10f - (float)chargeFact * 2f) / 10f;
				obj.noGravity = true;
				obj.scale = (float)Main.rand.Next(10, 20) * 0.05f;
			}
		}

		private void UpdatePlayer(Player player)
		{
			if (base.projectile.owner == Main.myPlayer)
			{
				Vector2 diff = Main.MouseWorld - player.Center;
				diff.Normalize();
				base.projectile.velocity = diff;
				base.projectile.direction = ((Main.MouseWorld.X > player.position.X) ? 1 : (-1));
				base.projectile.netUpdate = true;
			}
			int dir = base.projectile.direction;
			player.ChangeDir(dir);
			player.heldProj = base.projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2(base.projectile.velocity.Y * (float)dir, base.projectile.velocity.X * (float)dir);
		}

		private void CastLights()
		{
			DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
			Utils.PlotTileLine(base.projectile.Center, base.projectile.Center + base.projectile.velocity * (Distance - 130f), 26f, DelegateMethods.CastLight);
		}

		public override bool ShouldUpdatePosition()
		{
			return false;
		}

		public override void CutTiles()
		{
			DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
			Vector2 unit = base.projectile.velocity;
			Utils.PlotTileLine(base.projectile.Center, base.projectile.Center + unit * Distance, (float)(base.projectile.width + 16) * base.projectile.scale, DelegateMethods.CutTiles);
		}
	}
}
