using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StreetsOfDiscord
{
	public abstract class Character : IHasInventoryProperty
	{
		protected Character()
		{
			Inventory = new Inventory(this);
			Traits = new ReadOnlyCollection<Trait>(traits);
			Effects = new ReadOnlyCollection<StatusEffect>(effects);
		}
		public Inventory Inventory { get; set; }

		private int health; public int Health
		{
			get => health;
			set => health = Math.Min(Math.Max(value, 0), MaxHealth);
		}
		private int maxHealth; public int MaxHealth
		{
			get => maxHealth;
			set
			{
				maxHealth = value;
				if (health > maxHealth) health = maxHealth;
			}
		}

		public void ChangeHealth(int change, bool silent = false)
		{
			int previousHealth = Health;
			Health += change;
			if (!silent)
			{
				throw new NotImplementedException("Discord.SendMessage");
			}
		}

		private readonly List<Trait> traits = new List<Trait>();
		public ReadOnlyCollection<Trait> Traits { get; }
		private readonly List<StatusEffect> effects = new List<StatusEffect>();
		public ReadOnlyCollection<StatusEffect> Effects { get; }

		public Trait AddTrait(string trait)
		{
			Trait newTrait = new Trait(trait);
			AddTrait(newTrait);
			return newTrait;
		}
		public void AddTrait(Trait trait)
		{
			trait.Character = this;
			traits.Add(trait);
		}
		public bool RemoveTrait(string trait)
		{
			int index = traits.FindIndex(t => t.Name == trait);
			bool res = index != -1;
			if (res) traits.RemoveAt(index);
			return res;
		}
		public bool RemoveTrait(Trait trait) => traits.Remove(trait);
		public bool HasTrait(string trait) => traits.Exists(t => t.Name == trait);
		public Trait GetTrait(string trait) => traits.Find(t => t.Name == trait);

		public T AddStatusEffect<T>() where T : StatusEffect, new()
		{
			T effect = new T { Character = this };
			effects.Add(effect);
			effect.TicksLeft = effect.GetEffectDuration();
			return effect;
		}
		public void AddStatusEffect(StatusEffect effect)
		{
			effect.Character = this;
			effects.Add(effect);
			if (effect.TicksLeft == 0) effect.TicksLeft = effect.GetEffectDuration();
		}
		public bool RemoveStatusEffect<T>() where T : StatusEffect
		{
			int index = effects.FindIndex(e => e is T);
			bool res = index != -1;
			if (res) effects.RemoveAt(index);
			return res;
		}
		public bool RemoveStatusEffect(StatusEffect effect) => effects.Remove(effect);
		public bool HasStatusEffect<T>() where T : StatusEffect => effects.Exists(e => e is T);
		public StatusEffect GetStatusEffect<T>() where T : StatusEffect => effects.Find(e => e is T);

		public ulong Channel { get; set; }
		public void SendMessage(FormattedString text) => Discord.SendMessage(Channel, text);

		public abstract IEnumerable<Item> GetStartingItems();
		public abstract IEnumerable<Trait> GetStartingTraits();
	}
}
