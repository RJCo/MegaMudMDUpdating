
namespace Records
{
    public class Common
    {
        public enum Abilities
        {
            NoAbility = 0x0000,
            AbsoluteDamage = 0x0001,
            Defence = 0x0002,
            ResistCold = 0x0003,
            AlterAttackDamage = 0x0004,
            ResistFire = 0x0005,
            EnslaveCreature = 0x0006,
            ResistDamage = 0x0007,
            StealHPs = 0x0008,
            ShadowStealth = 0x0009,
            ProtectiveShield = 0x000A,
            Speed = 0x000B,
            SummonCreature = 0x000C,
            NightVision = 0x000D,
            RoomLight = 0x000E,
            Hunger = 0x000F,
            Thirst = 0x0010,
            InflictDamage = 0x0011,
            Heal = 0x0012,
            Poison = 0x0013,
            CurePoison = 0x0014,
            PoisonImmunity = 0x0015,
            AlterAttackValue = 0x0016,
            KillDead = 0x0017,
            DefenceAgainstEvil = 0x0018,
            DefenceAgainstGood = 0x0019,
            DetectMagic = 0x001A,
            Stealth = 0x001B,
            Magical = 0x001C,
            Punch = 0x001D,
            Kick = 0x001E,
            Bash = 0x001F,
            Smash = 0x0020,
            Killblow = 0x0021,
            Dodge = 0x0022,
            Jumpkick = 0x0023,
            ResistMagic = 0x0024,
            Picklocks = 0x0025,
            Tracking = 0x0026,
            Thievery = 0x0027,
            FindTraps = 0x0028,
            DisarmTraps = 0x0029,
            LinkToSpell = 0x002A,
            OnetimeCast = 0x002B,
            AlterIntellect = 0x002C,
            AlterWisdom = 0x002D,
            AlterStrength = 0x002E,
            AlterHealth = 0x002F,
            AlterAgility = 0x0030,
            AlterCharm = 0x0031,
            MageBaneQuest = 0x0032,
            AntiMagic = 0x0033,
            EvilInCombat = 0x0034,
            BlindingLight = 0x0035,
            AlterGeneralLight = 0x0036,
            GeneralLightDuration = 0x0037,
            RechargeItem = 0x0038,
            SeeHidden = 0x0039,
            CriticalHitChance = 0x003A,
            ClassItemInclusion = 0x003B,
            Flee = 0x003C,
            AffectExit = 0x003D,
            AlterEvilChance = 0x003E,
            AlterExperience = 0x003F,
            AddCP = 0x0040,
            ResistStone = 0x0041,
            ResistLightning = 0x0042,
            Quickness = 0x0043,
            Slowness = 0x0044,
            Mana = 0x0045,
            SpellCasting = 0x0046,
            Confusion = 0x0047,
            DamagingShield = 0x0048,
            DispelMagic = 0x0049,
            HoldPerson = 0x004A,
            Paralyze = 0x004B,
            Mute = 0x004C,
            Perception = 0x004D,
            Animal = 0x004E,
            Magebind = 0x004F,
            AffectsAnimal = 0x0050,
            Freedom = 0x0051,
            Cursed = 0x0052,
            MajorCurse = 0x0053,
            RemoveCurse = 0x0054,
            Shatter = 0x0055,
            Quality = 0x0056,
            EnergyUsage = 0x0057,
            AlterHP = 0x0058,
            AlterPunchAverage = 0x0059,
            AlterKickAverage = 0x005A,
            AlterJumpkickAverage = 0x005B,
            AlterPunchDamage = 0x005C,
            AlterKickDamage = 0x005D,
            AlterJumpkickDamage = 0x005E,
            Slay = 0x005F,
            Encumberance = 0x0060,
            GoodAligned = 0x0061,
            EvilAligned = 0x0062,
            AlterDRbyPercent = 0x0063,
            LoyalItem = 0x0064,
            ConfuseMessage = 0x0065,
            RaceStealth = 0x0066,
            ClassStealth = 0x0067,
            DefenceModifier = 0x0068,
            Alter2ndAttack = 0x0069,
            Alter3rdAttack = 0x006A,
            BlindUser = 0x006B,
            AffectsLiving = 0x006C,
            Nonliving = 0x006D,
            NotGoodAligned = 0x006E,
            NotEvilAligned = 0x006F,
            NeutralAligned = 0x0070,
            NotNeutralAligned = 0x0071,
            AutoUseAbilities = 0x0072,
            DescriptionMessage = 0x0073,
            AlterBSAttack = 0x0074,
            AlterBSMinimum = 0x0075,
            AlterBSMaximum = 0x0076,
            DeleteAtCleanup = 0x0077,
            StartingMessage = 0x0078,
            CleanupRecharge = 0x0079,
            RemoveSpell = 0x007A,
            AlterHealingRate = 0x007B,
            NegateAbility = 0x007C,
            IceSorceressThroneQuest = 0x007D,
            GoodQuest = 0x007E,
            NeutralQuest = 0x007F,
            EvilQuest = 0x0080,
            HighDruidGemQuest = 0x0081,
            ChampionOfBloodAltarQuest = 0x0082,
            AdultSheDragonRubyQuest = 0x0083,
            MOD3_WereratContraptionQuest = 0x0084,
            MOD5_LowLevelQuest = 0x0085,
            MOD6_DesertQuest = 0x0086,
            MinimumLevel = 0x0087,
            MaximumLevel = 0x0088,
            ShockshieldMessage = 0x0089,
            VisiblePlacedItem = 0x008A,
            SpellImmunity = 0x008B,
            TeleportRoom = 0x008C,
            TeleportMap = 0x008D,
            HitMagical = 0x008E,
            ClearItem = 0x008F,
            NonMagicalSpell = 0x0090,
            ManaRegeneration = 0x0091,
            GuardedBy = 0x0092,
            ResistWater = 0x0093,
            TriggerTextblock = 0x0094,
            DeleteFromInventoryAtCleanup = 0x0095,
            HealManaOrKai = 0x0096,
            CastOnEnding = 0x0097,
            Rune = 0x0098,
            TerminateSpell = 0x0099,
            RemainVisibleAtCleanup = 0x009A,
            DeathTextblock = 0x009B,
            QuestItem = 0x009C,
            ScatterItems = 0x009D,
            RequiredToHit = 0x009E,
            KaiBind = 0x009F,
            GiveSpellTemporarily = 0x00A0,
            OpenDoor = 0x00A1,
            Lore = 0x00A2,
            SpellComponent = 0x00A3,
            CastOnEndingChance = 0x00A4,
            AlterSpellDamage = 0x00A5,
            AlterSpellDuration = 0x00A6,
            UnequipItem = 0x00A7,
            EquipItem = 0x00A8,
            CannotWearLocation = 0x00A9,
            PutToSleep = 0x00AA,
            Invisibility = 0x00AB,
            SeeInvisible = 0x00AC,
            Scry = 0x00AD,
            StealMana = 0x00AE,
            StealHPToMana = 0x00AF,
            StealManaToHP = 0x00B0,
            SpellColours = 0x00B1,
            Shadowform = 0x00B2,
            FindTrapsValue = 0x00B3,
            PicklocksValue = 0x00B4,
            GangHouseDeed = 0x00B5,
            GangHouseTax = 0x00B6,
            GangHouseItem = 0x00B7,
            GangShopController = 0x00B8,
            DoNotAttackIfItem = 0x00B9,
            PerfectStealth = 0x00BA,
            Meditate = 0x00BB,
        }

        // CLASS constants
        public static readonly int CLASS_NAME_LEN = 30;

        // ITEM constants
        public static readonly int ITEM_NAME_LEN = 29;

        // MESSAGE constants
        public static readonly int MESSAGE_NAME_LEN = 30;
        public static readonly int MESSAGE_MESSAGE1_LEN = 80;
        public static readonly int MESSAGE_MESSAGE2_LEN = 80;
        public static readonly int MESSAGE_REPLY_LEN = 80;

        // MONSTER constants
        public static readonly int MONSTER_NAME_LEN = 29;

        // PATH constants
        public static readonly int PATH_CODE_LEN = 4;
        public static readonly int PATH_NAME_LEN = 40;
        public static readonly int PATH_AUTHOR_LEN = 40;
        public static readonly int PATH_FILE_LEN = 12;

        // RACE constants
        public static readonly int RACE_NAME_LEN = 30;

        // ROOM constants
        public static readonly int ROOM_CODE_LEN = 4;
        public static readonly int ROOM_NAME_LEN = 50;
        public static readonly int ROOM_GROUP_LEN = 20;
        public static readonly int ROOM_MAP_LEN = 20;

        // SPELL constants
        public static readonly int SPELL_CODE_LEN = 6;
        public static readonly int SPELL_NAME_LEN = 29;
        public static readonly int SPELL_COMMAND_LEN = 40;

    }
}