using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StreetsOfDiscord
{
	public static class Global
	{
		public static int GetHealthChange<T>(this T item) where T : IRestoresHealth, IInventoryItem
		{
			int value = item.BaseHealthChange;
			if (/*item is Banana && */item.Inventory.Holder is Character user)
			{
				Trait bananaLover = user.GetTrait("BananaLover");
				if (bananaLover != null) value *= bananaLover.Upgraded ? 4 : 2;
			}
			return value;
			throw new NotImplementedException("Implement Banana and uncomment the expression above.");
		}
		public static FormattedString Format(this string str, params object[] parameters) => new FormattedString(str, parameters);
	}
	public static class Discord
	{
		public static void SendMessage(ulong channel, FormattedString text)
			=> throw new NotImplementedException("Localize the string and output it through the DSharpPlus' Discord client.");
	}
}
