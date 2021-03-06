﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StreetsOfDiscord.Items
{
	[ItemCategories("Alcohol")]
	public class Beer : ItemBaseFood<Beer>
	{
		protected override GlobalItemData<Beer> CreateGlobalData() => new GlobalItemData<Beer>
		{
			Type = ItemType.Food,
			Stackable = true,
			InitCount = 1,
			RewardCount = 3,

			BaseValue = 10
		};
		public override int BaseHealthChange => 10;

		public Beer() { }
		public Beer(int count) : base(count) { }

	}
}
