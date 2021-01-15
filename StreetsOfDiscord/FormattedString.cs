using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace StreetsOfDiscord
{
	public class FormattedString
	{
		public FormattedString(string template, params object[] parameters)
		{
			Template = template;
			Parameters = new ReadOnlyCollection<string>(parameters.Select(p => p.ToString()).ToArray());
		}

		public string Template { get; }
		public ReadOnlyCollection<string> Parameters { get; }

		public string ToString(object locale)
		{
			locale.GetHashCode();
			throw new NotImplementedException("Use LocaleCollection in here and replace '{0}', '{1}', ... with Parameters (optionally, localize them too).");
		}
		public override string ToString()
			=> throw new NotImplementedException("Use the default output language, English.");

		public static implicit operator FormattedString(string str) => new FormattedString(str);
	}
}
