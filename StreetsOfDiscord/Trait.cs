using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StreetsOfDiscord
{
	public class Trait
	{
		public Character Character { get; set; }
		public Trait(string name) => Name = name;
		public string Name { get; }
		public bool Upgraded { get; }
	}
}
