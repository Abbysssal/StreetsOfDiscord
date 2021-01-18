using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using AbbLab.Utilities;

namespace StreetsOfDiscord
{
	public class FormattedString : IEquatable<FormattedString>, IEquatable<string>
	{
		public FormattedString(string template, params object[] parameters)
		{
			Template = template;
			Parameters = new ReadOnlyCollection<string>(parameters.Select(p => p.ToString()).ToArray());
		}

		public string Template { get; }
		public ReadOnlyCollection<string> Parameters { get; }

		public string ToString(LocaleLanguage locale)
		{
			string text = Localize(locale, Template);
			for (int i = 0; i < Parameters.Count; i++)
			{
				string parameter = Localize(locale, Parameters[i]);
				text = text.Replace($"{{{i}}}", parameter);
			}
			return text;
		}
		public override string ToString() => ToString(Global.LocaleCollection.Languages[0]);

		private static string Localize(LocaleLanguage locale, string text)
		{
			if (string.IsNullOrEmpty(text) || text[0] != '{') return text ?? string.Empty;
			// '{' '<category>' ':' '<entry>' '}'
			//  0   1            i   i+1       length-1
			int separatorIndex = text.IndexOf(':');
			string category = text.Substring(1, separatorIndex - 1);
			string entry = text.Substring(separatorIndex + 1, text.Length - separatorIndex - 2);
			return locale.GetText(category, entry);
		}

		public static implicit operator FormattedString(string str) => new FormattedString(str);

		public bool Equals(FormattedString format) => Template == format.Template && Parameters.SequenceEqual(format.Parameters);
		public bool Equals(string text) => Template == text && Parameters.Count == 0;

		public override bool Equals(object obj) => (obj is FormattedString format && Equals(format)) || (obj is string text && Equals(text));
		public override int GetHashCode()
		{
			int hash = Template.GetHashCode();
			foreach (string parameter in Parameters)
				hash ^= parameter.GetHashCode();
			return hash;
		}
		public static bool operator ==(FormattedString a, FormattedString b) => a.Equals(b);
		public static bool operator !=(FormattedString a, FormattedString b) => !a.Equals(b);
		public static bool operator ==(FormattedString format, string text) => format.Equals(text);
		public static bool operator !=(FormattedString format, string text) => !format.Equals(text);
		public static bool operator ==(string text, FormattedString format) => format.Equals(text);
		public static bool operator !=(string text, FormattedString format) => !format.Equals(text);
	}
}
