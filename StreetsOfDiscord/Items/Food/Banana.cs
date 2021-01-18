using System;
using System.Collections.Generic;
using System.Text;

namespace StreetsOfDiscord.Items
{
	[ItemCategories("Food")]
	public class Banana : ItemBaseFood<Banana>
	{
		protected override GlobalItemData<Banana> CreateGlobalData() => new GlobalItemData<Banana>
		{
			Type = ItemType.Food,
			Stackable = true,
			InitCount = 1,
			RewardCount = 3,

			BaseValue = 15
		};
		public override int BaseHealthChange => 10;

		public Banana() { }
		public Banana(int count) : base(count) { }

	}
}
