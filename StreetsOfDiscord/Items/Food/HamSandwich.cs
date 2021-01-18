using System;
using System.Collections.Generic;
using System.Text;

namespace StreetsOfDiscord.Items
{
	[ItemCategories("Food")]
	public class HamSandwich : ItemBaseFood<HamSandwich>
	{
		protected override GlobalItemData<HamSandwich> CreateGlobalData() => new GlobalItemData<HamSandwich>
		{
			Type = ItemType.Food,
			Stackable = true,
			InitCount = 1,
			RewardCount = 3,

			BaseValue = 15
		};
		public override int BaseHealthChange => 10;

		public HamSandwich() { }
		public HamSandwich(int count) : base(count) { }

	}
}
