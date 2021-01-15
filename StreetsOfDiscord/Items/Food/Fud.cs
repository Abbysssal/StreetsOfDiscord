using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace StreetsOfDiscord.Items
{
	[ItemCategories("Food")]
	public class Fud : Item, IItemUsable, IRestoresHealth
	{
		private static readonly GlobalItemData data = new GlobalItemData<Fud>
		{
			Type = ItemType.Food,
			Stackable = true,
			InitCount = 1,
			RewardCount = 3,

			BaseValue = 7
		};
		public int BaseHealthChange => 5;
		public Fud(int count) : base(data, count) { }

		public FormattedString GetTooltip() => "{Tooltips:Fud}".Format(this.GetHealthChange());
		public FormattedString UseCheck()
		{
			if (Inventory.Holder is Character user)
			{
				if (user.HasTrait("OnlyBloodRestoresHealth")) return "{Msg:Health_OnlyBlood}";
				if (user.HasTrait("OnlyOilRestoresHealth")) return "{Msg:Health_OnlyOil}";
				if (user.HasTrait("OnlyChargeRestoresHealth")) return "{Msg:Health_OnlyCharge}";
				if (user.HasTrait("OnlyHumanFleshRestoresHealth")) return "{Msg:Health_OnlyHumanFlesh}";
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
