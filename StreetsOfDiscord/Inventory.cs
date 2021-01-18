using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace StreetsOfDiscord
{
	public class Inventory : IHasCharacterProperty
	{
		public Character Character { get; }
		public Inventory(Character character)
		{
			Character = character;
			Items = items.AsReadOnly();
		}
		private readonly List<Item> items = new List<Item>();
		public ReadOnlyCollection<Item> Items { get; }

		public T AddItem<T>() where T : Item, new()
		{
			T item = new T() { Inventory = this };
			items.Add(item);
			OnAdded?.Invoke(item);
			return item;
		}
		public T AddItem<T>(int count) where T : Item, new()
		{
			T item = new T() { Inventory = this, Count = count };
			items.Add(item);
			OnAdded?.Invoke(item);
			return item;
		}
		public void AddItem(Item item)
		{
			item.Inventory = this;
			items.Add(item);
			OnAdded?.Invoke(item);
		}
		public void AddItem(Item item, int count)
		{
			item.Inventory = this;
			item.Count = count;
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
		public bool HasItem<T>(int amount) where T : Item => Items.Any(i => i is T && i.Count >= amount);
		public T GetItem<T>() where T : Item => (T)Items.FirstOrDefault(i => i is T);
		public event Action<Item> OnAdded;
		public event Action<Item> OnRemoved;

	}
	public interface IHasCharacterProperty
	{
		Character Character { get; }
	}
	public interface IHasInventoryProperty
	{
		Inventory Inventory { get; }
	}
}
