using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace StreetsOfDiscord
{
	public class Inventory
	{
		public IInventoryHolder Holder { get; }
		public Inventory(IInventoryHolder holder)
		{
			Holder = holder;
			Items = items.AsReadOnly();
		}
		private readonly List<Item> items = new List<Item>();
		public ReadOnlyCollection<Item> Items { get; }

		public void AddItem(Item item)
		{
			item.Inventory = this;
			items.Add(item);
			OnAdded?.Invoke(item);
		}
		public bool RemoveItem(Item item)
		{
			bool res = items.Remove(item);
			if (res) OnRemoved?.Invoke(item);
			return res;
		}
		public bool SubtractFromItemCount<T>(int amount) where T : Item
		{
			Item item = GetItem<T>();
			if (item == null) return false;
			bool res = item.Count >= amount;
			if (res) item.Count -= amount;
			return res;
		}
		public bool HasItem<T>() where T : Item => Items.Any(i => i is T);
		public T GetItem<T>() where T : Item => (T)Items.FirstOrDefault(i => i is T);
		public event Action<Item> OnAdded;
		public event Action<Item> OnRemoved;

	}
	public interface IInventoryHolder
	{
		Inventory Inventory { get; }
	}
	public interface IInventoryItem
	{
		Inventory Inventory { get; }
	}
}
