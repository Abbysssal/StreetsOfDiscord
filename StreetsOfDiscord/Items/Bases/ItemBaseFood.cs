using System;
using System.Collections.Generic;
using System.Text;

namespace StreetsOfDiscord.Items
{
	public abstract class ItemBaseFood<T> : Item, IItemUsable, IChangesHealth where T : ItemBaseFood<T>, new()
	{
		private static readonly GlobalItemData data = new T().CreateGlobalData();
		protected abstract GlobalItemData<T> CreateGlobalData();

		protected ItemBaseFood() : base(data) { }
		protected ItemBaseFood(int count) : base(data, count) { }

		public abstract int BaseHealthChange { get; }

		public virtual FormattedString GetTooltip() => "{Tooltips:RestoresHealth}".Format(this.GetHealthChange());

		private static readonly bool notAlcohol = !data.Categories.Contains("Alcohol");
		public virtual FormattedString UseCheck()
		{
			if (Character.HasTrait("OnlyBloodRestoresHealth")) return "{Msg:Health_OnlyBlood}";
			if (Character.HasTrait("OnlyOilRestoresHealth")) return "{Msg:Health_OnlyOil}";
			if (notAlcohol && Character.HasTrait("OnlyChargeRestoresHealth")) return "{Msg:Health_OnlyCharge}";
			if (notAlcohol && Character.HasTrait("OnlyHumanFleshRestoresHealth")) return "{Msg:Health_OnlyHumanFlesh}";
			if (Character.Health == Character.MaxHealth) return "{Msg:Health_Full}";
			return null;
		}

		public virtual void UseItem()
		{
			Character.ChangeHealth(this.GetHealthChange());
			Count--;
		}
	}
}
