using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StreetsOfDiscord
{
	public abstract class StatusEffect : IHasCharacterProperty, IHasTooltip
	{
		public Character Character { get; set; }
		public abstract int BaseEffectDuration { get; }
		private int ticksLeft; public int TicksLeft
		{
			get => ticksLeft;
			set
			{
				ticksLeft = value;
				if (value <= 0) Character.RemoveStatusEffect(this);
			}
		}
		public virtual void Tick() => TicksLeft--;
		public abstract FormattedString GetTooltip();
	}
}
