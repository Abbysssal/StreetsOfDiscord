using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace StreetsOfDiscord.Items
{
	[ItemCategories("Alcohol")]
	public class Whiskey : Item, IItemUsable, IRestoresHealth
	{
		private static readonly GlobalItemData data = new GlobalItemData<Whiskey>
		{
			Type = ItemType.Food,
			Stackable = true,
			InitCount = 1,
			RewardCount = 3,

			BaseValue = 20
		};
		public int BaseHealthChange => 15;
		public Whiskey(int count) : base(data, count) { }

		public FormattedString GetTooltip() => new FormattedString("{Tooltips:RestoresHealth}", this.GetHealthChange());
		public FormattedString UseCheck()
		{
			if (Inventory.Holder is Character user)
			{
				if (user.HasTrait("OnlyBloodRestoresHealth")) return "{Msg:Health_OnlyBlood}";
				if (user.HasTrait("OnlyOilRestoresHealth")) return "{Msg:Health_OnlyOil}";
				// not affected by OnlyChargeRestoresHealth. Robots can drink Whiskey
				// not affected by OnlyHumanFleshRestoresHealth. Cannibals can drink too
				if (user.Health == user.MaxHealth) return "{Msg:Health_Full}";
				return null;
			}
			return "{Err:NotCharacter}";
		}
		public void UseItem()
		{
			Character user = (Character)Inventory.Holder;
			user.ChangeHealth(this.GetHealthChange());
			Count--;
		}
	}
}
