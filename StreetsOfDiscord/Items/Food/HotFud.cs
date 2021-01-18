using System;
using System.Collections.Generic;
using System.Text;

namespace StreetsOfDiscord.Items
{
	[ItemCategories("Food")]
	public class HotFud : ItemBaseFood<HotFud>
	{
		protected override GlobalItemData<HotFud> CreateGlobalData() => new GlobalItemData<HotFud>
		{
			Type = ItemType.Food,
			Stackable = true,
			InitCount = 1,

			BaseValue = 15
		};
		public override int BaseHealthChange => 15;

		public HotFud() { }
		public HotFud(int count) : base(count) { }

	}
}
