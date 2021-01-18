using System;
using System.Collections.Generic;
using System.Text;

namespace StreetsOfDiscord.StatusEffects
{
	public class Regeneration : StatusEffect, IChangesHealth
	{
		public int BaseHealthChange => 2;
		public override int BaseEffectDuration => 15;

		public override FormattedString GetTooltip() => "{Tooltips:Regeneration}".Format(this.GetHealthChange(), this.GetEffectDuration());
		public override void Tick()
		{
			Character.ChangeHealth(this.GetHealthChange());
			base.Tick();
		}
	}
}
