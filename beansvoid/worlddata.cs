using System.Threading.Tasks;
using beansvoid.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace beansvoid
{
	public class worlddata : ModWorld
	{
		public bool IsGifted;

		public static bool miseryactive;

		public override void PostWorldGen()
		{
			IsGifted = false;
			miseryactive = false;
		}

		public override TagCompound Save()
		{
			return new TagCompound
			{
				{ "IsGifted", IsGifted },
				{ "miseryactive", miseryactive }
			};
		}

		public override void Load(TagCompound tag)
		{
			IsGifted = tag.GetBool("IsGifted");
			miseryactive = tag.GetBool("miseryactive");
		}

		public override void PostUpdate()
		{
		}

		public override void Initialize()
		{
			spawnPresent();
		}

		private async Task spawnPresent()
		{
			await Task.Delay(5000);
			Main.NewText("set", new Color(0, 255, 255));
			if (!IsGifted)
			{
				Main.player[0].QuickSpawnItem(ModContent.ItemType<RancidPresent>());
			}
			IsGifted = true;
		}
	}
}
