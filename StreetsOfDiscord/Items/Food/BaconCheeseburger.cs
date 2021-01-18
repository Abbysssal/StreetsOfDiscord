using System;
using System.Collections.Generic;
using System.Text;

namespace StreetsOfDiscord.Items
{
	[ItemCategories("Food")]
	public class BaconCheeseburger : ItemBaseFood<BaconCheeseburger>
	{
		protected override GlobalItemData<BaconCheeseburger> CreateGlobalData() => new GlobalItemData<BaconCheeseburger>
		{
			Type = ItemType.Food,
			Stackable = true,
			InitCount = 1,
			RewardCount = 3,

			BaseValue = 25
		};
		public override int BaseHealthChange => 20;

		public BaconCheeseburger() { }
		public BaconCheeseburger(int count) : base(count) { }

	}
}
