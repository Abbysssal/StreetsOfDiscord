using System;
using System.Collections.Generic;
using System.Text;

namespace StreetsOfDiscord.Items
{
	[ItemCategories("Alcohol")]
	public class Whiskey : ItemBaseFood<Whiskey>
	{
		protected override GlobalItemData<Whiskey> CreateGlobalData() => new GlobalItemData<Whiskey>
		{
			Type = ItemType.Food,
			Stackable = true,
			InitCount = 1,
			RewardCount = 3,

			BaseValue = 20
		};
		public override int BaseHealthChange => 15;

		public Whiskey() : base() { }
		public Whiskey(int count) : base(count) { }

	}
}
