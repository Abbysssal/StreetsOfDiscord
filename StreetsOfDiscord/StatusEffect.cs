using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StreetsOfDiscord
{
	public abstract class StatusEffect
	{
		public Character Character { get; set; }
		protected StatusEffect(int ticks) => Ticks = ticks;
		public int Ticks { get; set; }
		public virtual void Tick() => Ticks--;
	}
}
