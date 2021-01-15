using System;
using System.Linq;
using System.Collections.Generic;
using StreetsOfDiscord.Items;

namespace StreetsOfDiscord.Characters
{
	// Default classes
	public class SlumDweller : Character
	{
		public override IEnumerable<Item> GetStartingItems()
		{
			yield return new Whiskey(1);
		}
		public override IEnumerable<Trait> GetStartingTraits()
		{
			yield break;
		}
	}
	/*
	public class Soldier : Character
	{
	}
	public class GangsterCrepe : Character
	{
	}
	public class Thief : Character
	{
	}
	public class Shopkeeper : Character
	{
	}
	public class GangsterBlahd : Character
	{
	}
	public class Bartender : Character
	{
	}
	public class Hacker : Character
	{
	}
	public class Doctor : Character
	{
	}
	public class Scientist : Character
	{
	}
	public class Gorilla : Character
	{
	}
	public class Cop : Character
	{
	}
	public class Vampire : Character
	{
	}
	public class Wrestler : Character
	{
	}
	public class Assassin : Character
	{
	}
	public class Comedian : Character
	{
	}
	public class Jock : Character
	{
	}
	public class Shapeshifter : Character
	{
	}
	public class InvestmentBanker : Character
	{
	}
	public class Werewolf : Character
	{
	}
	public class Cannibal : Character
	{
	}
	public class Slavemaster : Character
	{
	}
	public class Zombie : Character
	{
	}
	public class Firefighter : Character
	{
	}
	public class Mobster : Character
	{
	}
	public class Robot : Character
	{
	}
	public class Bouncer : Character
	{
	}
	public class Courier : Character
	{
	}
	public class Alien : Character
	{
	}
	public class Goon : Character
	{
	}
	public class Demolitionist : Character
	{
	}
	public class MechPilot : Character
	{
	}
	// Default upgrade classes
	public class UpperCruster : Character
	{
	}
	public class GangsterFuchsia : Character
	{
	}
	public class Supercop : Character
	{
	}
	public class Supergoon : Character
	{
	}
	// Normally unavailable classes
	public class DrugDealer : Character
	{
	}
	public class Clerk : Character
	{
	}
	public class CopBot : Character
	{
	}
	public class ButlerBot : Character
	{
	}
	public class KillerRobot : Character
	{
	}
	public class Ghost : Character
	{
	}
	public class Musician : Character
	{
	}
	public class OfficeDrone : Character
	{
	}
	public class Mayor : Character
	{
	}
	public class ResistanceLeader : Character
	{
	}
	public class Slave : Character
	{
	}
	public class FormerSlave : Character
	{
	}
	public class Worker : Character
	{
	}
	*/
}
