using System;


namespace Records
{
    public class Monster : IRecord
    {
        #region Enums
        public enum MonsterType
        {
            Solo = 0x00,
            Leader = 0x01,
            Follower = 0x02,
            Stationary = 0x03,
        }

        public enum MonsterAlignment
        {
            Good = 0x00,
            Evil = 0x01,
            ChoaticEvil = 0x02,
            Neutral = 0x03,
            LawfulGood = 0x04,
            NeutralEvil = 0x05,
            LawfulEvil = 0x06,
            Unknown = 0x07,
        }

        public enum Priority
        {
            Normal = 0x00,
            FindFirst = 0x08,
            Last = 0x10,
            Low = 0x20,
            High = 0x40,
            First = 0x80,
        }

        public enum MegamudFlags
        {
            NotHostile = 0x02,
            DontBackstab = 0x01,
            CheckIfAlive = 0x04,
        }

        public enum Relationship
        {
            Unknown = 0x00,
            Friend = 0x02,
            Avoid = 0x03,
            Enemy = 0x04,
            Flee = 0x05,
            Hangup = 0x06,
        }

        public enum Gender
        {
            It = 0x00,
            Male = 0x01,
            Female = 0x02,
            Unknown = 0x03
        }

        public enum LocationGroup
        {
            OrcMansion = 0x26,
            SpecialCreateAtUser = 0x25,
            NewhavenGraveyardAndCrypt = 0x24,
            ProphecyOfPlagueMod9 = 0x20,
            SavageLandsMod7 = 0x1f,
            SmugglersMod5 = 0x1e,
            ObsidianPassageways = 0x1d,
            CrystalTunnels = 0x1c,
            CrackedPlainsAndLavaFields = 0x1b,
            FungusForestAndBlackFort = 0x1a,
            HazySwamp = 0x19,
            DwarfMinesMod4 = 0x18,
            BlackWastelands = 0x17,
            BlackCavesMod3 = 0x16,
            AncientRuinsMod2 = 0x15,
            DesertMod6 = 0x14,
            Rhudaur = 0x13,
            NomadsAndMonastery = 0x12,
            FrozenCaverns = 0x11,
            RockyTrailNomads = 0x10,
            Monastery = 0x0f,
            CryptQuestMonsters = 0x0e,
            HornedDemon = 0x0d,
            CryptQuestArea = 0x0c,
            Labyrinth = 0x0b,
            GoblinCaves = 0x0a,
            DragonsTeethHills = 0x09,
            BlackHouseAndBelow = 0x08,
            GraveyardAndCrypt = 0x07,
            SlumsAndSewers = 0x06,
            GuardsTemplars = 0x05,
            UniquesShopkeepers = 0x02,
            Arena = 0x00,
        }

        public enum AttackType
        {
            None = 0,
            Normal = 1,
            Spell = 2,
            Rob3 = 3,
        }
        #endregion

        public int ID { get; set; }
        public string Name { get; set; }
        public Priority AttackPriority { get; set; }
        public MegamudFlags Flags { get; set; }
        public MonsterAlignment Alignment { get; set; }
        public Relationship MonsterRelationship { get; set; }
        public string PreAttackSpell { get; set; }
        public string AttackSpell { get; set; }
        public int PreAttackSpellMaxCast { get; set; }
        public int AttackSpellMaxCast { get; set; }
        public Gender Sex { get; set; }
        public int Level { get; set; }
        public int Hitpoints { get; set; }
        public int Energy { get; set; }
        public int MagicResistance { get; set; }
        public int Accuracy { get; set; }
        public int ArmorClass { get; set; }
        public int DamageResistance { get; set; }
        public int EnslaveLevel { get; set; }
        public LocationGroup Group { get; set; }
        public MonsterType Type { get; set; }
        public int GameMax { get; set; }
        public int RegenInHours { get; set; }
        public int LocationMap { get; set; }
        public int LocationRoom { get; set; }
        public int ItemDrop1_ItemID { get; set; }
        public int ItemDrop2_ItemID { get; set; }
        public int ItemDrop3_ItemID { get; set; }
        public int ItemDrop4_ItemID { get; set; }
        public int ItemDrop5_ItemID { get; set; }
        public int ItemDrop1_DropRate { get; set; }
        public int ItemDrop2_DropRate { get; set; }
        public int ItemDrop3_DropRate { get; set; }
        public int ItemDrop4_DropRate { get; set; }
        public int ItemDrop5_DropRate { get; set; }
        public int CashDrop_Runic { get; set; }
        public int CashDrop_Platinum { get; set; }
        public int CashDrop_Gold { get; set; }
        public int CashDrop_Silver { get; set; }
        public int CashDrop_Copper { get; set; }
        public int Experience { get; set; }

        // TODO:  Fill in the rest of Monsters info here.  
        public int BSDefense;                   // BS defense
        public int CharmResist;                 // Charm resist
        public int FollowChance;                // Monster follow% (agility?)
        public int sLevelUnknown;               // HP regen? Monster level?
        public int Undead;                      // Undead?
        public Common.Abilities Abilities;      // max 10   // Monster abilities
        public int AbilityValues;               // max 10   // Monster abil values
        public Item Weapon;                     // Weapon used
        public AttackType Attack;               // max 5    // Attack type (0=None,1=Normal,2=Spell,3=Rob3?)
        public int AttackChance;                // max 5    // Attack chance     (only 5 used now)
        public int AttackAccuracy;              // max 5    // Attack accuracy/spell#
        public int AttackMinimumDamage;         // max 5    // Attack min damage/cast%
        public int AttackMaxDamage;             // max 5    // Attack max damage/cast level
        public int AttackEnergyCost;            // max 5    // Attack energy used
        public int AlternateAttackHitSpells;    // max 5    // Alternate attack hit spells
        public Spell OnDeathSpell;              // Death spell
        public Spell OnRegenSpell;              // Regen spell
        public Spell InBetweenRoundSpell;       // max 5    // In-between round spells
        public int InBetweenRoundSpellChange;   // max 5    // In-between round chance %
        public int InBetweenRoundSpellLevel;    // max 5    // In-between rount cast level

        public new string ToString()
        {
            throw new NotImplementedException();

            /*
            string recordStr = string.Empty;

            recordStr += string.Format("ID: {0}\t", ID);
            recordStr += string.Format("Name: {0}\n", Name);
            recordStr += string.Format("Experience: {0}\n", ExperiencePercentage);
            recordStr += string.Format("Weapon Type: {0}\n", Enum.GetName(typeof(WeaponClasses), WeaponType));

            foreach (var ability in AbilitiesAndMods) {
                recordStr += string.Format("Ability/Modifier: {0}:{1}\n", Enum.GetName(typeof(AbilitiesAndModifiers), ability.Key), ability.Value);
            }
            return recordStr;
            */
        }
    }
}
