using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AbbLab.Utilities;
using StreetsOfDiscord.Items;

namespace StreetsOfDiscord
{
	public static class Global
	{
		public static LocaleCollection LocaleCollection { get; set; }
		public static int GetHealthChange<T>(this T obj) where T : IChangesHealth, IHasCharacterProperty
		{
			int value = obj.BaseHealthChange;
			if (obj is Banana)
			{
				Trait bananaLover = obj.Character.GetTrait("BananaLover");
				if (bananaLover != null) value *= bananaLover.Upgraded ? 4 : 2;
			}
			return value;
		}
		public static int GetEffectDuration(this StatusEffect obj)
		{
			int value = obj.BaseEffectDuration;
			Trait longerEffects = obj.Character.GetTrait("LongerStatusEffects");
			if (longerEffects != null) value = longerEffects.Upgraded ? value * 2 : value * 3 / 2;
			return value;
		}
		public static FormattedString Format(this string str, params object[] parameters) => new FormattedString(str, parameters);
	}
	public static class Discord
	{
		public static void SendMessage(ulong channel, FormattedString text)
			=> throw new NotImplementedException("Localize the string and output it through the DSharpPlus' Discord client.");
	}
}
