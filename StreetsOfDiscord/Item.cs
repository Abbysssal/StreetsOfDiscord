using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace StreetsOfDiscord
{
	public abstract class Item : IInventoryItem
	{
		protected Item(GlobalItemData data, int count)
		{
			Data = data;
			Count = count;
		}
		public Inventory Inventory { get; set; }
		private int count; public int Count
		{
			get => count;
			set
			{
				count = Math.Max(value, 0);
				if (count == 0 && !Data.HasCharges)
					Inventory.RemoveItem(this);
			}
		}

		public GlobalItemData Data { get; }
		public string Name => Data.Name;
		public ItemType Type => Data.Type;
		public ReadOnlyCollection<string> Categories => Data.Categories;
	}
	public interface IRestoresHealth
	{
		int BaseHealthChange { get; }
	}
	public interface IHasTooltip
	{
		FormattedString GetTooltip();
	}
	public interface IItemUsable : IHasTooltip
	{
		FormattedString UseCheck();
		void UseItem();
	}
	[AttributeUsage(AttributeTargets.Class)]
	public class ItemNameAttribute : Attribute
	{
		public ItemNameAttribute(string name) => Name = name;
		public string Name { get; }
	}
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class ItemCategoriesAttribute : Attribute
	{
		public ItemCategoriesAttribute(params string[] categories) => Categories = new ReadOnlyCollection<string>(categories);
		public ReadOnlyCollection<string> Categories { get; }
	}
	public class GlobalItemData
	{
		public GlobalItemData(Type type)
		{
			Name = type.GetCustomAttribute<ItemNameAttribute>()?.Name ?? type.Name;
			IEnumerable<string> allCategories = type.GetCustomAttributes<ItemCategoriesAttribute>().SelectMany(attr => attr.Categories).Distinct();
			Categories = new ReadOnlyCollection<string>(allCategories.ToArray());
		}
		public string Name { get; set; }
		public ItemType Type { get; set; }
		public ReadOnlyCollection<string> Categories { get; set; }

		public int BaseValue { get; set; }

		public bool Stackable { get; set; }
		public bool HasCharges { get; set; }

		public int InitCount { get; set; }
		public int RewardCount { get; set; }
	}
	public class GlobalItemData<T> : GlobalItemData where T : Item
	{
		public GlobalItemData() : base(typeof(T)) { }
	}
	public enum ItemType
	{
		Food = 1,
		Consumable = 2,
		Wearable = 3,
		WeaponMelee = 4,
		WeaponProjectile = 5,
		WeaponThrown = 6,
		Tool = 7,
		Combine = 8
	}
}
