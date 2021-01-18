using System;
using System.Collections.Generic;
using System.Text;

namespace StreetsOfDiscord.StatusEffects
{
	public class Poison : StatusEffect, IChangesHealth
	{
		public int BaseHealthChange => -2;
		public override int BaseEffectDuration => 15;

		public override FormattedString GetTooltip() => "{Tooltips:Poison}".Format(this.GetHealthChange(), this.GetEffectDuration());
		public override void Tick()
		{
			Character.ChangeHealth(this.GetHealthChange());
			base.Tick();
		}
	}
}
