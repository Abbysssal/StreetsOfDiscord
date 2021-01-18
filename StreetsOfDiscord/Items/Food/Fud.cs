using System;
using System.Collections.Generic;
using System.Text;

namespace StreetsOfDiscord.Items
{
	[ItemCategories("Food")]
	public class Fud : ItemBaseFood<Fud>
	{
		protected override GlobalItemData<Fud> CreateGlobalData() => new GlobalItemData<Fud>
		{
			Type = ItemType.Food,
			Stackable = true,
			InitCount = 1,
			RewardCount = 3,

			BaseValue = 7
		};
		public override int BaseHealthChange => 5;

		public Fud() { }
		public Fud(int count) : base(count) { }

	}
}
