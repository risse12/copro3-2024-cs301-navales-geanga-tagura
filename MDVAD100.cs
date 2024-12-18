using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Threading;


namespace MDVAD100
{

    #region -- Abstract Class, Abstract Methods, Constructors, this --

    abstract class CharacterBase
    {
        public string Name { get; set; }


        public CharacterBase(string name)
        {
            this.Name = name;
        }

        public abstract void InputFeature();

        public abstract void InputStats();

        public abstract void Save();
    }
    #endregion

    #region -- Struct, Constructors, this --

    struct Stats
    {
        public int Strength, Agility, Intelligence, Vitality, Luck, Dexterity, Endurance;

        public Stats(int strength, int agility, int intelligence, int vitality, int luck, int dexterity, int endurance)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Intelligence = intelligence;
            this.Vitality = vitality;
            this.Luck = luck;
            this.Dexterity = dexterity;
            this.Endurance = endurance;
        }
    }
    #endregion

    #region -- Encapsulation, Properties, Constructors, this --

    class CharacterFeatures
    {
        public string EyeColor { get; set; }
        public string HairType { get; set; }
        public string HairColor { get; set; }
        public string Gender { get; set; }
        public string SkinTone { get; set; }
        public string ClothingType { get; set; }
        public string Weapon { get; set; }
        public string Footwear { get; set; }
        public string Accessories { get; set; }
        public string Beast { get; set; }
        public string Ability { get; set; }
        public string Occupation { get; set; }
        public bool Jewelry { get; set; }
        public string Headwear { get; set; }
        public string Race { get; set; }
        public string BodyType { get; set; }
        public string Region { get; set; }
        public string SkillOffensive { get; set; }
        public string SkillSupportive { get; set; }



        public CharacterFeatures(string eyeColor, string hairType, string hairColor, string gender, string skinTone, string clothingType, string weapon,
            string footWear, string accessories, string beast, string ability, string occupation, bool jewelry, string headWear,
            string race, string bodyType, string region, string skillOffensive, string skillSupportive)
        {
            this.EyeColor = eyeColor; // Using 'this' keyword
            this.HairType = hairType;
            this.HairColor = hairColor;
            this.Gender = gender;
            this.SkinTone = skinTone;
            this.ClothingType = clothingType;
            this.Footwear = footWear;
            this.Accessories = accessories;
            this.Beast = beast;
            this.Ability = ability;
            this.Occupation = occupation;
            this.Jewelry = jewelry;
            this.Headwear = headWear;
            this.Weapon = weapon;
            this.Race = race;
            this.BodyType = bodyType;
            this.Region = region;
            this.SkillOffensive = skillOffensive;
            this.SkillSupportive = skillSupportive;
        }
    }
    #endregion

    #region -- Interface --

    interface ICharacterActions
    {
        void InputFeature();
        void InputStats();
        void Save();
    }
    #endregion

    #region -- Inheritance, Interface, Encaps, Method Overriding, Method Overloading, Constructor, this, Exception Handling, Database -- 

    class Character : CharacterBase, ICharacterActions
    {

        private int eyeColorChoice, hairTypeChoice, hairColorChoice, genderChoice, skinToneChoice, clothingTypeChoice, weaponChoice, footWearChoice,
                    accessoriesChoice, beastChoice, abilityChoice, occupationChoice, jewelryChoice, headWearChoice, raceChoice, bodyTypeChoice,
                    regionChoice, skillOffensiveChoice, skillSupportiveChoice;

        private Stats characterStats;
        private CharacterFeatures features;


        public Character(string name) : base(name) {

            features = new CharacterFeatures(
                eyeColor: "Unknown",
                hairType: "Unknown",
                hairColor: "Unknown",
                gender: "Unknown",
                skinTone: "Unknown",
                clothingType: "Unknown",
                weapon: "Unknown",
                footWear: "Unknown",
                accessories: "Unknown",
                beast: "Unknown",
                ability: "Unknown",
                occupation: "Unknown",
                jewelry: false,
                headWear: "Unknown",
                race: "Unknown",
                bodyType: "Unknown",
                region: "Unknown",
                skillOffensive: "Unknown",
                skillSupportive: "Unknown"
            );

        }


        public override void InputFeature()
        {


            this.InputFeature("Eye Color", 1, 5);
            this.InputFeature("Hair Type", 1, 5);
            this.InputFeature("Hair Color", 1, 6);
            this.InputFeature("Gender", 1, 2);
            this.InputFeature("Skin Tone", 1, 5);
            this.InputFeature("Clothing Type", 1, 10);
            this.InputFeature("Weapon", 1, 6);
            this.InputFeature("Footwear", 1, 5);
            this.InputFeature("Accessories", 1, 5);
            this.InputFeature("Beast", 1, 5);
            this.InputFeature("Ability", 1, 6);
            this.InputFeature("Occupation", 1, 7);
            this.InputFeature("if you want to Wear Jewelry?", 1, 2);
            this.InputFeature("Headwear", 1, 5);
            this.InputFeature("Race", 1, 5);
            this.InputFeature("Body Type", 1, 5);
            this.InputFeature("Region", 1, 5);
            this.InputFeature("Offensive Skill", 1, 5); // should be 5, add one more offensive skill
            this.InputFeature("Supportive Skill", 1, 6);
        }


        public void InputFeature(string featureName)
        {
            Console.WriteLine($"\nChoose {featureName}:");


            switch (featureName)
            {
                case "Eye Color":
                    Console.WriteLine("1. Bloody Red\n2. Ocean Blue\n3. Midnight Black\n4. Earthy Brown\n5. Forest Green");
                    break;
                case "Hair Type":
                    Console.WriteLine("1. Short Hair\n2. Long Hair\n3. Medium Hair\n4. Tail\n5. Bald");
                    break;
                case "Hair Color":
                    Console.WriteLine("1. Dark Brown\n2. Black\n3. Blue\n4. Ash Grey\n5. Red\n6. Mystic Purple"); // AYUSIN MO YUNG CHOICES
                    break;
                case "Gender":
                    Console.WriteLine("1. Male\n2. Female");
                    break;
                case "Skin Tone":
                    Console.WriteLine("1. Black\n2. Brown\n3. Blue\n4. White\n5. Orange");
                    break;
                case "Clothing Type":
                    Console.WriteLine("1. Squire\n2. Forester\n3. Minstrel\n4. Merchant\n5. Noble\n6. Priestess\n7. Knight\n8. Peasant\n9. Hunter\n10. Wizard");
                    break;
                case "Weapon":
                    Console.WriteLine("1. Sword\n2. Crossbow\n3. Magic Wand\n4. Spear\n5. Dagger\n6. Knuckles");
                    break;
                case "Footwear":
                    Console.WriteLine("1. Shoes\n2. Boots\n3. Sandals\n4. Slippers\n5. Barefoot");
                    break;
                case "Accessories":
                    Console.WriteLine("1. Gloves\n2. Gauntlet\n3. Wings\n4. Warrior Bag\n5. Scarf");
                    break;
                case "Beast":
                    Console.WriteLine("1. Unicorn\n2. Pegasus\n3. Hydra\n4. Dire Wolf\n5. Thunderbird");
                    break;
                case "Ability":
                    Console.WriteLine("1. Battle Rage - Unleash a warrior's fury, enhancing strength and attack speed for a short time.\n2. Flame Touch - Enchant your weapon with flames, scorching enemies with each strike.\n3. Arcane Blast - Harness ancient magic to unleash a powerful burst that damages foes.\n4. Healing Touch - Channel divine energy to restore health to yourself or an ally.\n5. Shadow Step - Move through the shadows to reposition swiftly and evade danger.\n6. Invisibility - Cloak yourself in magic, becoming unseen to enemies and gaining the element of surprise.");
                    break;
                case "Occupation":
                    Console.WriteLine("1. Wizard - A master of arcane arts, wielding powerful spells to control the battlefield and obliterate enemies.\n2. Knight - A noble warrior clads in heavy armor, excelling in melee combat and defending allies.\n3. Assassin - A stealthy killer who uses agility and precision to eliminate targets swiftly and silently.\n4. Alchemist - A skilled potion maker and scientist, crafting powerful brews and explosives to aid in battle.\n5. Merchant - A savvy trader who thrives on commerce, amassing wealth and acquiring rare goods.\n6. Ranger - A master of the wilderness, skilled with the bow and able to track and hunt foes from afar\n7. Craftsman - An artisan with unparalleled skills in creating weapons, armor, and tools essential for survival.");
                    break;
                case "if you want to Wear Jewelry?":
                    Console.WriteLine("[1] Yes\n[2] No\n");
                    break;
                case "Headwear":
                    Console.WriteLine("1. Bandana\n2. Berret\n3. Blade Helmet\n4. Crown\n5. Feather’s Cap");
                    break;
                case "Race":
                    Console.WriteLine("1. Orc\n2. Werewolf\n3. Human\n4. Elf\n5. Monster");
                    break;
                case "Body Type":
                    Console.WriteLine("1. Slim\n2. Muscular\n3. Average\n4. Skinny\n5. Heavyset");
                    break;
                case "Region":
                    Console.WriteLine("1. Forest of Eldoria - A lush, green forest filled with ancient trees and mystical creatures. \nIdeal for adventurers seeking a balance between danger and tranquility.\n2. Caves of Draugmar - Dark and mysterious underground caverns where ancient treasures and deadly \nmonsters lie in wait. Perfect for those with a taste for danger and exploration.\n3. Kingdom of Soltaria - A grand and prosperous kingdom ruled by a wise king. Its bustling cities and peaceful \ncountryside are perfect for characters seeking to build connections and influence.\n4. Desert of Karath - A vast, scorching desert full of ruins and hidden oases. A land of solitude \nand tough survival, where only the strongest and most resourceful thrive.\n5. Winter of Freljord - A harsh, icy landscape where survival is a constant struggle against the \nelements. Only the bravest can endure its freezing cold and fierce storms.");
                    break;
                case "Offensive Skill":
                    Console.WriteLine("1. Power Strike: A strong melee attack that deals heavy damage to a single target.\n2. Fireball: Launches a fiery projectile that explodes on impact, dealing area-of-effect damage over time.\n3. Arcane Blast: Unleashes a burst of arcane energy that damages all nearby enemies in a small radius.\n4. Thunder Strike: Calls down a lightning bolt to strike a target, with a chance to stun nearby enemies.\n5. Super Slash - Casting a powerful slash that hits multiple enemies");
                    break;
                case "Supportive Skill":
                    Console.WriteLine("1. Quick Dash: Temporarily boosts your movement speed, allowing you to dodge attacks or quickly close the distance to enemies.\n2. Heal: Restores a portion of health to yourself or an ally, perfect for staying alive in tough fights.\n3. Shadow Cloak: Grants temporary invisibility, allowing you to sneak past enemies or avoid damage.\n4. Ice Shield: Creates a barrier of ice around you that absorbs damage for a short period.\n5. Trap Setting: Place traps that trigger when enemies walk over them, causing damage or status effects like poison.\n6. Summon Familiar: Summons a magical creature to assist you in combat, offering support or distracting enemies.");
                    break;

            }
        }
        public void InputFeature(string featureName, int minChoice, int maxChoice)
        {

            int choice = 0;
            bool validInput = false;
            string input;
            while (!validInput)
            {

                Console.WriteLine($"\nChoose {featureName}:");


                switch (featureName)
                {
                    case "Eye Color":
                        Console.WriteLine("1. Bloody Red\n2. Ocean Blue\n3. Midnight Black\n4. Earthy Brown\n5. Forest Green");
                        break;
                    case "Hair Type":
                        Console.WriteLine("1. Short Hair\n2. Long Hair\n3. Medium Hair\n4. Tail\n5. Bald");
                        break;
                    case "Hair Color":
                        Console.WriteLine("1. Dark Brown\n2. Black\n3. Blue\n4. Ash Grey\n5. Red\n6. Mystic Purple"); // AYUSIN MO YUNG CHOICES
                        break;
                    case "Gender":
                        Console.WriteLine("1. Male\n2. Female");
                        break;
                    case "Skin Tone":
                        Console.WriteLine("1. Black\n2. Brown\n3. Blue\n4. White\n5. Orange");
                        break;
                    case "Clothing Type":
                        Console.WriteLine("1. Squire\n2. Forester\n3. Minstrel\n4. Merchant\n5. Noble\n6. Priestess\n7. Knight\n8. Peasant\n9. Hunter\n10. Wizard");
                        break;
                    case "Weapon":
                        Console.WriteLine("1. Sword\n2. Crossbow\n3. Magic Wand\n4. Spear\n5. Dagger\n6. Knuckles");
                        break;
                    case "Footwear":
                        Console.WriteLine("1. Shoes\n2. Boots\n3. Sandals\n4. Slippers\n5. Barefoot");
                        break;
                    case "Accessories":
                        Console.WriteLine("1. Gloves\n2. Gauntlet\n3. Wings\n4. Warrior Bag\n5. Scarf");
                        break;
                    case "Beast":
                        Console.WriteLine("1. Unicorn\n2. Pegasus\n3. Hydra\n4. Dire Wolf\n5. Thunderbird");
                        break;
                    case "Ability":
                        Console.WriteLine("1. Battle Rage - Unleash a warrior's fury, enhancing strength and attack speed for a short time.\n2. Flame Touch - Enchant your weapon with flames, scorching enemies with each strike.\n3. Arcane Blast - Harness ancient magic to unleash a powerful burst that damages foes.\n4. Healing Touch - Channel divine energy to restore health to yourself or an ally.\n5. Shadow Step - Move through the shadows to reposition swiftly and evade danger.\n6. Invisibility - Cloak yourself in magic, becoming unseen to enemies and gaining the element of surprise.");
                        break;
                    case "Occupation":
                        Console.WriteLine("1. Wizard - A master of arcane arts, wielding powerful spells to control the battlefield and obliterate enemies.\n2. Knight - A noble warrior clads in heavy armor, excelling in melee combat and defending allies.\n3. Assassin - A stealthy killer who uses agility and precision to eliminate targets swiftly and silently.\n4. Alchemist - A skilled potion maker and scientist, crafting powerful brews and explosives to aid in battle.\n5. Merchant - A savvy trader who thrives on commerce, amassing wealth and acquiring rare goods.\n6. Ranger - A master of the wilderness, skilled with the bow and able to track and hunt foes from afar\n7. Craftsman - An artisan with unparalleled skills in creating weapons, armor, and tools essential for survival.");
                        break;
                    case "if you want to Wear Jewelry?":
                        Console.WriteLine("[1] Yes\n[2] No\n");
                        break;
                    case "Headwear":
                        Console.WriteLine("1. Bandana\n2. Berret\n3. Blade Helmet\n4. Crown\n5. Feather’s Cap");
                        break;
                    case "Race":
                        Console.WriteLine("1. Orc\n2. Werewolf\n3. Human\n4. Elf\n5. Monster");
                        break;
                    case "Body Type":
                        Console.WriteLine("1. Slim\n2. Muscular\n3. Average\n4. Skinny\n5. Heavyset");
                        break;
                    case "Region":
                        Console.WriteLine("1. Forest of Eldoria - A lush, green forest filled with ancient trees and mystical creatures. \nIdeal for adventurers seeking a balance between danger and tranquility.\n2. Caves of Draugmar - Dark and mysterious underground caverns where ancient treasures and deadly \nmonsters lie in wait. Perfect for those with a taste for danger and exploration.\n3. Kingdom of Soltaria - A grand and prosperous kingdom ruled by a wise king. Its bustling cities and peaceful \ncountryside are perfect for characters seeking to build connections and influence.\n4. Desert of Karath - A vast, scorching desert full of ruins and hidden oases. A land of solitude \nand tough survival, where only the strongest and most resourceful thrive.\n5. Winter of Freljord - A harsh, icy landscape where survival is a constant struggle against the \nelements. Only the bravest can endure its freezing cold and fierce storms.");
                        break;
                    case "Offensive Skill":
                        Console.WriteLine("1. Power Strike: A strong melee attack that deals heavy damage to a single target.\n2. Fireball: Launches a fiery projectile that explodes on impact, dealing area-of-effect damage over time.\n3. Arcane Blast: Unleashes a burst of arcane energy that damages all nearby enemies in a small radius.\n4. Thunder Strike: Calls down a lightning bolt to strike a target, with a chance to stun nearby enemies.\n5. Super Slash - Casting a powerful slash that hits multiple enemies");
                        break;
                    case "Supportive Skill":
                        Console.WriteLine("1. Quick Dash: Temporarily boosts your movement speed, allowing you to dodge attacks or quickly close the distance to enemies.\n2. Heal: Restores a portion of health to yourself or an ally, perfect for staying alive in tough fights.\n3. Shadow Cloak: Grants temporary invisibility, allowing you to sneak past enemies or avoid damage.\n4. Ice Shield: Creates a barrier of ice around you that absorbs damage for a short period.\n5. Trap Setting: Place traps that trigger when enemies walk over them, causing damage or status effects like poison.\n6. Summon Familiar: Summons a magical creature to assist you in combat, offering support or distracting enemies.");
                        break;

                }

                Console.WriteLine($"Enter the number corresponding to your choice ({minChoice}-{maxChoice}):");
                input = Console.ReadLine();

                Console.WriteLine($"Input received: '{input}' (Length: {input.Length})");

                // Validate input
                if (int.TryParse(input, out choice))
                {
                    if (choice >= minChoice && choice <= maxChoice)
                    {
                        validInput = true;  // Input is valid
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input. Please enter a number between {minChoice} and {maxChoice}.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            
            // Handle specific feature
            switch (featureName)
            {
                case "if you want to Wear Jewelry?":
                    if (choice == 1)
                    {
                        jewelryChoice = 1;  // Yes, wear jewelry
                    }
                    else if (choice == 2)
                    {
                        jewelryChoice = 0;  // No, do not wear jewelry
                    }
                    else
                    {
                       
                     // Default to No
                    }
                    break;

                    // Handle other feature cases
            }
        }

            

            switch (featureName)
            {
                case "Eye Color":
                    this.eyeColorChoice = choice;
                    break;
                case "Hair Type":
                    this.hairTypeChoice = choice;
                    break;
                case "Hair Color":
                    this.hairColorChoice = choice;
                    break;
                case "Gender":
                    this.genderChoice = choice;
                    break;
                case "Skin Tone":
                    this.skinToneChoice = choice;
                    break;
                case "Clothing Type":
                    this.clothingTypeChoice = choice;
                    break;
                case "Weapon":
                    this.weaponChoice = choice;
                    break;
                case "Footwear":
                    this.footWearChoice = choice;
                    break;
                case "Accessories":
                    this.accessoriesChoice = choice;
                    break;
                case "Beast":
                    this.beastChoice = choice;
                    break;
                case "Ability":
                    this.abilityChoice = choice;
                    break;
                case "Occupation":
                    this.occupationChoice = choice;
                    break;
                case "Jewelry":
                    this.jewelryChoice = choice;
                    break; 
                case "Headwear":
                    this.headWearChoice = choice;
                    break;
                case "Race":
                    this.raceChoice = choice;
                    break;
                case "Body Type":
                    this.bodyTypeChoice = choice;
                    break;
                case "Region":
                    this.regionChoice = choice;
                    break;
                case "Offensive Skill":
                    this.skillOffensiveChoice = choice;
                    break;
                case "Supportive Skill":
                    this.skillSupportiveChoice = choice;
                    break;

            }
        }

        

        public override void InputStats()
        {

            this.characterStats = new Stats(
                strength: 0,
                agility: 0,
                intelligence: 0,
                vitality: 0,
                luck: 0,
                dexterity: 0,
                endurance: 0
            );

            var points = PointAllocation();

            this.characterStats = new Stats(
                points.strength,
                points.agility,
                points.intelligence,
                points.vitality,
                points.luck,
                points.dexterity,
                points.endurance
            );

            this.features = new CharacterFeatures(GetEyeColor(), GetHairType(), GetHairColor(), GetGender(), GetSkinTone(),
                                GetClothingType(), GetWeapon(), GetFootWear(), GetAccessories(), GetBeast(),
                                GetAbility(), GetOccupation(), GetJewelry(), GetHeadWear(), GetRace(),
                                GetBodyType(), GetRegion(), GetSkillOffensive(), GetSkillSupportive());
        }

        public (int strength, int agility, int intelligence, int vitality, int luck, int dexterity, int endurance) PointAllocation()
        {
            int strength = 0, agility = 0, intelligence = 0, vitality = 0, luck = 0, dexterity = 0, endurance = 0;
            int totalPoints = 20;

            Console.WriteLine("Distribute allocation points (maximum of 5 per stat). Total remaining points: 20");

            while (totalPoints > 0)
            {
                Console.WriteLine($"\nRemaining Points: {totalPoints}");
                Console.WriteLine($"1. Strength ({strength})");
                Console.WriteLine($"2. Agility ({agility})");
                Console.WriteLine($"3. Intelligence ({intelligence})");
                Console.WriteLine($"4. Vitality ({vitality})");
                Console.WriteLine($"5. Luck ({luck})");
                Console.WriteLine($"6. Dexterity ({dexterity})");
                Console.WriteLine($"7. Endurance ({endurance})");

                Console.WriteLine("\nChoose a stat to allocate points to (1-7):");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 7)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
                    continue;
                }

                Console.WriteLine("Enter points to allocate (1-5):");
                if (!int.TryParse(Console.ReadLine(), out int pointsToAllocate) || pointsToAllocate < 1 || pointsToAllocate > 5 || pointsToAllocate > totalPoints)
                {
                    Console.WriteLine($"Invalid input. Enter a number between 1 and 5, and no more than your remaining points ({totalPoints}).");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        if (strength + pointsToAllocate > 5)
                        {
                            Console.WriteLine("Strength cannot exceed 5 points. Try again.");
                        }
                        else
                        {
                            strength += pointsToAllocate;
                            totalPoints -= pointsToAllocate;
                        }
                        break;

                    case 2:
                        if (agility + pointsToAllocate > 5)
                        {
                            Console.WriteLine("Agility cannot exceed 5 points. Try again.");
                        }
                        else
                        {
                            agility += pointsToAllocate;
                            totalPoints -= pointsToAllocate;
                        }
                        break;

                    case 3:
                        if (intelligence + pointsToAllocate > 5)
                        {
                            Console.WriteLine("Intelligence cannot exceed 5 points. Try again.");
                        }
                        else
                        {
                            intelligence += pointsToAllocate;
                            totalPoints -= pointsToAllocate;
                        }
                        break;

                    case 4:
                        if (vitality + pointsToAllocate > 5)
                        {
                            Console.WriteLine("Vitality cannot exceed 5 points. Try again.");
                        }
                        else
                        {
                            vitality += pointsToAllocate;
                            totalPoints -= pointsToAllocate;
                        }
                        break;

                    case 5:
                        if (luck + pointsToAllocate > 5)
                        {
                            Console.WriteLine("Luck cannot exceed 5 points. Try again.");
                        }
                        else
                        {
                            luck += pointsToAllocate;
                            totalPoints -= pointsToAllocate;
                        }
                        break;

                    case 6:
                        if (dexterity + pointsToAllocate > 5)
                        {
                            Console.WriteLine("Dexterity cannot exceed 5 points. Try again.");
                        }
                        else
                        {
                            dexterity += pointsToAllocate;
                            totalPoints -= pointsToAllocate;
                        }
                        break;

                    case 7:
                        if (endurance + pointsToAllocate > 5)
                        {
                            Console.WriteLine("Endurance cannot exceed 5 points. Try again.");
                        }
                        else
                        {
                            endurance += pointsToAllocate;
                            totalPoints -= pointsToAllocate;
                        }
                        break;
                }
            }

            return (strength, agility, intelligence, vitality, luck, dexterity, endurance);
        }

        public override void Save()
        {
           
            string connStr = "Server=localhost;Database=character_dbmdvad100;Uid=root;Pwd=;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // SQL INSERT operation
                    string query = "INSERT INTO characters (Name, EyeColor, HairType, HairColor, Gender, SkinTone, ClothingType, Weapon, Footwear, Accessories, Beast, Ability, Occupation, Jewelry, Headwear, Race, BodyType, Region, OffensiveSkill, SupportiveSkill, Strength, Agility, Intelligence, Vitality, Luck, Dexterity, Endurance) " +
                                   "VALUES (@Name, @EyeColor, @HairType, @HairColor, @Gender, @SkinTone, @ClothingType, @Weapon, @Footwear, @Accessories, @Beast, @Ability, @Occupation, @Jewelry, @Headwear, @Race, @BodyType, @Region, @OffensiveSkill, @SupportiveSkill, @Strength, @Agility, @Intelligence, @Vitality, @Luck, @Dexterity, @Endurance)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", this.Name);
                        cmd.Parameters.AddWithValue("@EyeColor", GetEyeColor());
                        cmd.Parameters.AddWithValue("@HairType", GetHairType());
                        cmd.Parameters.AddWithValue("@HairColor", GetHairColor());
                        cmd.Parameters.AddWithValue("@Gender", GetGender());
                        cmd.Parameters.AddWithValue("@SkinTone", GetSkinTone());
                        cmd.Parameters.AddWithValue("@ClothingType", GetClothingType());
                        cmd.Parameters.AddWithValue("@Weapon", GetWeapon());
                        cmd.Parameters.AddWithValue("@Footwear", GetFootWear());
                        cmd.Parameters.AddWithValue("@Accessories", GetAccessories());
                        cmd.Parameters.AddWithValue("@Beast", GetBeast());
                        cmd.Parameters.AddWithValue("@Ability", GetAbility());
                        cmd.Parameters.AddWithValue("@Occupation", GetOccupation());
                        cmd.Parameters.AddWithValue("@Jewelry", GetJewelry());
                        cmd.Parameters.AddWithValue("@Headwear", GetHeadWear());
                        cmd.Parameters.AddWithValue("@Race", GetRace());
                        cmd.Parameters.AddWithValue("@BodyType", GetBodyType());
                        cmd.Parameters.AddWithValue("@Region", GetRegion());
                        cmd.Parameters.AddWithValue("@OffensiveSkill", GetSkillOffensive());
                        cmd.Parameters.AddWithValue("@SupportiveSkill", GetSkillSupportive());
                        cmd.Parameters.AddWithValue("@Strength", this.characterStats.Strength);
                        cmd.Parameters.AddWithValue("@Agility", this.characterStats.Agility);
                        cmd.Parameters.AddWithValue("@Intelligence", this.characterStats.Intelligence);
                        cmd.Parameters.AddWithValue("@Vitality", this.characterStats.Vitality);
                        cmd.Parameters.AddWithValue("@Luck", this.characterStats.Luck);
                        cmd.Parameters.AddWithValue("@Dexterity", this.characterStats.Dexterity);
                        cmd.Parameters.AddWithValue("@Endurance", this.characterStats.Endurance);

                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Character saved!!");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error!! Please check your SQL if its started and if not please try again: {ex.Message}");
                Environment.Exit(0);
            }
        }
        #endregion

        #region -- DISPLAY OR OUTPUT --

        public void Display()
        {
            Console.WriteLine("Tagumpay ang pagkakagawa sa character!!");
            Console.WriteLine("+-------------------+---------------------+-----------------------+");
            Console.WriteLine("|      Features     |   Character Info    |         Stats         |");
            Console.WriteLine("+-------------------+---------------------+-----------------------+");

            Console.WriteLine($"| Character Name    | {this.Name,-19} | Strength     : {this.characterStats.Strength,-7}|");
            Console.WriteLine($"| Eye Color         | {this.features.EyeColor,-19} | Agility      : {this.characterStats.Agility,-7}|");
            Console.WriteLine($"| Hair Type         | {this.features.HairType,-19} | Intelligence : {this.characterStats.Intelligence,-7}|");
            Console.WriteLine($"| Hair Color        | {this.features.HairColor,-19} | Vitality     : {this.characterStats.Vitality,-7}|");
            Console.WriteLine($"| Gender            | {this.features.Gender,-19} | Luck         : {this.characterStats.Luck,-7}|");
            Console.WriteLine($"| Skin Tone         | {this.features.SkinTone,-19} | Dexterity    : {this.characterStats.Dexterity,-7}|");
            Console.WriteLine($"| Clothing Type     | {this.features.ClothingType,-19} | Endurance    : {this.characterStats.Endurance,-7}|");
            Console.WriteLine($"| Weapon            | {this.features.Weapon,-19} |                       |");
            Console.WriteLine($"| Footwear          | {this.features.Footwear,-19} |                       |");
            Console.WriteLine($"| Accessories       | {this.features.Accessories,-19} |                       |");
            Console.WriteLine($"| Beast             | {this.features.Beast,-19} |                       |");
            Console.WriteLine($"| Ability           | {this.features.Ability,-19} |                       |");
            Console.WriteLine($"| Occupation        | {this.features.Occupation,-19} |                       |");
            Console.WriteLine($"| Jewelry           | {this.features.Jewelry,-19} |                       |");
            Console.WriteLine($"| Headwear          | {this.features.Headwear,-19} |                       |");
            Console.WriteLine($"| Race              | {this.features.Race,-19} |                       |");
            Console.WriteLine($"| Offensive         | {this.features.SkillOffensive,-19} |                       |");
            Console.WriteLine($"| Supportive        | {this.features.SkillSupportive,-19} |                       |");
            Console.WriteLine($"| Body Type         | {this.features.BodyType,-19} |                       |");
            Console.WriteLine($"| Region            | {this.features.Region,-19} |                       |");

            Console.WriteLine("+-------------------+---------------------+-----------------------+");


        }


        public string GetHairColor() => this.hairColorChoice switch
        {
            1 => "Dark Brown",
            2 => "Black",
            3 => "Blue",
            4 => "Ash Grey",
            5 => "Red",
            6 => "Mystic Purple",
            _ => "Unknown"
        };



        public string GetHairType() => this.hairTypeChoice switch
        {
            1 => "Short Hair",
            2 => "Long Hair",
            3 => "Medium Hair",
            4 => "Tail",
            5 => "Bald",
            _ => "Unknown"
        };

        public string GetEyeColor() => this.eyeColorChoice switch
        {
            1 => "Bloody Red",
            2 => "Ocean Blue",
            3 => "Midnight Black",
            4 => "Earthy Brown",
            5 => "Forest Green",
            _ => "Unknown"
        };

        public string GetGender() => this.genderChoice switch
        {
            1 => "Male",
            2 => "Female",
            _ => "Unknown"
        };

        public string GetSkinTone() => this.skinToneChoice switch
        {
            1 => "Black",
            2 => "Brown",
            3 => "Blue",
            4 => "White",
            5 => "Orange",
            _ => "Unknown"
        };

        public string GetClothingType() => this.clothingTypeChoice switch
        {
            1 => "Squire",
            2 => "Forester",
            3 => "Minstrel",
            4 => "Merchant",
            5 => "Noble",
            6 => "Priestess",
            7 => "Knight",
            8 => "Peasant",
            9 => "Hunter",
            10 => "Wizard",
            _ => "Unknown"
        };

        public string GetWeapon() => this.weaponChoice switch
        {
            1 => "Sword",
            2 => "Crossbow",
            3 => "Magic Wand",
            4 => "Spear",
            5 => "Dagger",
            6 => "Knuckles",
            _ => "Unknown"
        };

        public string GetFootWear() => this.footWearChoice switch
        {
            1 => "Shoes",
            2 => "Boots",
            3 => "Sandals",
            4 => "Slippers",
            5 => "Barefoot",
            _ => "Unknown"
        };

        public string GetAccessories() => this.accessoriesChoice switch
        {
            1 => "Gloves",
            2 => "Gauntlet",
            3 => "Wings",
            4 => "Warrior Bag",
            5 => "Scarf",
            _ => "Unknown"
        };

        public string GetBeast() => this.beastChoice switch
        {
            1 => "Unicorn",
            2 => "Pegasus",
            3 => "Hydra",
            4 => "Dire Wolf",
            5 => "Thunderbird",
            _ => "Unknown"
        };

        public string GetAbility() => this.abilityChoice switch
        {
            1 => "Battle Rage",
            2 => "Flame Touch",
            3 => "Arcane Blast",
            4 => "Healing Touch",
            5 => "Shadow Step",
            6 => "Invisibility",
            _ => "Unknown"
        };

        public string GetOccupation() => this.occupationChoice switch
        {
            1 => "Wizard",
            2 => "Knight",
            3 => "Assassin",
            4 => "Alchemist",
            5 => "Merchant",
            6 => "Ranger",
            7 => "Craftsman",
            _ => "Unknown"
        };

        public bool GetJewelry() => this.jewelryChoice switch
        {
            1 => true,
            _ => false
        };

        public string GetHeadWear() => this.headWearChoice switch
        {
            1 => "Bandana",
            2 => "Berret",
            3 => "Blade Helmet",
            4 => "Crown",
            5 => "Feather’s Cap",
            _ => "Unknown"
        };

        public string GetRace() => this.raceChoice switch
        {
            1 => "Orc",
            2 => "Werewolf",
            3 => "Human",
            4 => "Elf",
            5 => "Monster",
            _ => "Unknown"
        };

        public string GetBodyType() => this.bodyTypeChoice switch
        {
            1 => "Slim",
            2 => "Muscular",
            3 => "Average",
            4 => "Skinny",
            5 => "Heavyset",
            _ => "Unknown"
        };

        public string GetRegion() => this.regionChoice switch
        {
            1 => "Forest of Eldoria",
            2 => "Caves of Draugmar",
            3 => "Kingdom of Soltaria",
            4 => "Desert of Karath",
            5 => "Winter of Freljord",
            _ => "Unknown"
        };

        public string GetSkillOffensive() => this.skillOffensiveChoice switch
        {
            1 => "Power Strike",
            2 => "Fireball",
            3 => "Arcane Blast",
            4 => "Thunder Strike",
            5 => "Super Slash",
            _ => "Unknown"
        };

        public string GetSkillSupportive() => this.skillSupportiveChoice switch
        {
            1 => "Quick Dash",
            2 => "Heal",
            3 => "Shadow Cloak",
            4 => "Ice Shield",
            5 => "Trap Setting",
            6 => "Summon Familiar",
            _ => "Unknown"
        };
    }

    #endregion


    #region -- Main Method -- 
    class Program
    {
        static void Main(string[] args)
        {
            
            bool GameisRunning = true;

            try
            {
                while (GameisRunning)
                {
                    ShowLoadingScreen();
                    Console.Clear();
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);

                    string choice = "";


                    bool validChoice = false;
                    while (!validChoice)
                    {
                        Console.Clear();
                        Console.WriteLine("\n==== Guardians of the Scattered Gems ====");
                        Console.WriteLine("\n1. Create New Character");
                        Console.WriteLine("2. Load Game");
                        Console.WriteLine("3. Campaign Mode");
                        Console.WriteLine("4. Credits");
                        Console.WriteLine("5. Exit");
                        Console.Write("Choose an option (1-5): ");
                        choice = Console.ReadLine();


                        if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5")
                        {
                            validChoice = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please try again.\n");
                            Thread.Sleep(1500);
                        }
                    }

                    if (choice == "1")
                    {
                        string name;
                        Console.Clear();
                        Console.WriteLine("===== Creating New Character =====\n");

                        while (true)
                        {
                            Console.Write("Enter your character's name (Allowed: 3-15 characters, letters, numbers, and (@,-,.): ");
                            name = Console.ReadLine();

                            if (IsValidCharacterName(name))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid character name. Please ensure it meets the criteria.");
                                Console.WriteLine("Please try again.\n");
                            }
                        }


                        Character newCharacter = new Character(name);

                        newCharacter.InputFeature();
                        newCharacter.InputStats();

                        newCharacter.Display();
                        newCharacter.Save();

                        bool ToGoOrNah = true;

                        while (ToGoOrNah)
                        {
                            Console.WriteLine("Go back to Main Menu Or Press 'S' to Start Game (Y/S)");

                            string choose = Console.ReadLine().ToUpper();

                            if (choose == "S")
                            {
                                Console.WriteLine("Game Start...");
                                CampaignMode();
                                ToGoOrNah = false;
                            }
                            else if (choose == "Y")
                            {
                                Console.WriteLine("You chose to go back to the main menu.");
                                ToGoOrNah = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 'Y' for Yes or 'N' for No.");
                            }

                            Thread.Sleep(2500);
                        }
                    }

                    else if (choice == "2")
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        string connStr = "Server=localhost;Database=character_dbmdvad100;Uid=root;Pwd=;";
                        try
                        {
                            using (MySqlConnection conn = new MySqlConnection(connStr))
                            {
                                conn.Open();

                                bool validSubChoice = false;

                                Console.WriteLine("\n\n\n\n====== LOAD GAME ======");

                                while (!validSubChoice)
                                {
                                    Console.WriteLine("1. Load a character");
                                    Console.WriteLine("2. Delete a character");
                                    Console.WriteLine("3. Back to Main Menu");
                                    Console.Write("Please choose an option: ");
                                    string subChoice = Console.ReadLine().Trim();

                                    if (subChoice == "1" || subChoice == "2" || subChoice == "3")
                                    {
                                        validSubChoice = true;

                                        if (subChoice == "3")
                                        {
                                            Console.WriteLine("Returning to the main menu...");
                                            Thread.Sleep(1500);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Please enter '1', '2', or '3'.\n");
                                    }

                                    if (subChoice == "1")
                                    {
                                        
                                        string query = "SELECT id, Name, EyeColor, HairType, HairColor, Gender, SkinTone, ClothingType, Weapon, Footwear, Accessories, Beast, Ability, Occupation, Jewelry, Headwear, Race, BodyType, Region, OffensiveSkill, SupportiveSkill, Strength, Agility, Intelligence, Vitality, Luck, Dexterity, Endurance FROM characters";
                                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                                        {
                                            using (MySqlDataReader reader = cmd.ExecuteReader())
                                            {
                                                if (reader.HasRows)
                                                {
                                                    Console.WriteLine("\nAvailable Characters:\n\n\n\n\n");
                                                    while (reader.Read())
                                                    {
                                                        Console.WriteLine("Character Details:");
                                                        Console.WriteLine("+-------------------+---------------------+-----------------------+");
                                                        Console.WriteLine($"|              =======>     ID: {reader["id"]}     <=======                  |");
                                                        Console.WriteLine("|-------------------+---------------------+-----------------------|");
                                                        Console.WriteLine("+-------------------+---------------------+-----------------------+");
                                                        Console.WriteLine("+-------------------+---------------------+-----------------------+");
                                                        Console.WriteLine("|      Features     |   Character Info    |         Stats         |");
                                                        Console.WriteLine("+-------------------+---------------------+-----------------------+");
                                                        Console.WriteLine($"| Character Name    | {reader["Name"],-19} | Strength     : {reader["Strength"],-6} |");
                                                        Console.WriteLine($"| Eye Color         | {reader["EyeColor"],-19} | Agility      : {reader["Agility"],-6} |");
                                                        Console.WriteLine($"| Hair Type         | {reader["HairType"],-19} | Intelligence : {reader["Intelligence"],-6} |");
                                                        Console.WriteLine($"| Hair Color        | {reader["HairColor"],-19} | Vitality     : {reader["Vitality"],-6} |");
                                                        Console.WriteLine($"| Gender            | {reader["Gender"],-19} | Luck         : {reader["Luck"],-6} |");
                                                        Console.WriteLine($"| Skin Tone         | {reader["SkinTone"],-19} | Dexterity    : {reader["Dexterity"],-6} |          ");
                                                        Console.WriteLine($"| Clothing Type     | {reader["ClothingType"],-19} | Endurance    : {reader["Endurance"],-6} |  SCROLL (UP/DOWN) TO SEE OTHER CHAR.");
                                                        Console.WriteLine($"| Weapon            | {reader["Weapon"],-19} |                       |          ");
                                                        Console.WriteLine($"| Footwear          | {reader["Footwear"],-19} |                       |");
                                                        Console.WriteLine($"| Accessories       | {reader["Accessories"],-19} |                       |");
                                                        Console.WriteLine($"| Beast             | {reader["Beast"],-19} |                       |");
                                                        Console.WriteLine($"| Ability           | {reader["Ability"],-19} |                       |");
                                                        Console.WriteLine($"| Occupation        | {reader["Occupation"],-19} |                       |");
                                                        Console.WriteLine($"| Jewelry           | {reader["Jewelry"],-19} |                       |");
                                                        Console.WriteLine($"| Headwear          | {reader["Headwear"],-19} |                       |");
                                                        Console.WriteLine($"| Race              | {reader["Race"],-19} |                       |");
                                                        Console.WriteLine($"| Offensive Skill   | {reader["OffensiveSkill"],-19} |                       |");
                                                        Console.WriteLine($"| Supportive Skill  | {reader["SupportiveSkill"],-19} |                       |");

                                                        Console.WriteLine("+-------------------+---------------------+-----------------------+\n");

                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No characters found in the database.");
                                                    Thread.Sleep(1500);
                                                    Console.WriteLine("Returning to the main menu...");
                                                    Thread.Sleep(1500);
                                                    break;
                                                }
                                            }
                                        }


                                        bool isValid = false;
                                        int selectedId = 0;

                                        while (!isValid)
                                        {
                                            Console.Write("\nEnter the ID of the character you want to load: ");
                                            string input = Console.ReadLine();

                                            if (!int.TryParse(input, out selectedId))
                                            {
                                                Console.WriteLine("Invalid input. Please enter a valid numeric ID.\n");
                                                continue;
                                            }

                                            query = "SELECT COUNT(*) FROM characters WHERE id = @id";
                                            using (MySqlCommand cmdCheck = new MySqlCommand(query, conn))
                                            {
                                                cmdCheck.Parameters.AddWithValue("@id", selectedId);
                                                int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                                                if (count > 0)
                                                {
                                                    isValid = true;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No character found with the specified ID. Please try again.\n");
                                                }
                                            }
                                        }


                                        query = "SELECT * FROM characters WHERE id = @id";
                                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                                        {
                                            cmd.Parameters.AddWithValue("@id", selectedId);
                                            using (MySqlDataReader reader = cmd.ExecuteReader())
                                            {
                                                if (reader.Read())
                                                {
                                                      
                                                    Console.WriteLine("\n\n\n\n\n+-------------------+---------------------+-----------------------+");
                                                    Console.WriteLine("|      Features     |   Character Info    |         Stats         |");
                                                    Console.WriteLine("+-------------------+---------------------+-----------------------+");
                                                    Console.WriteLine($"| Character Name    | {reader["Name"],-19} | Strength     : {reader["Strength"],-6} |");
                                                    Console.WriteLine($"| Eye Color         | {reader["EyeColor"],-19} | Agility      : {reader["Agility"],-6} |");
                                                    Console.WriteLine($"| Hair Type         | {reader["HairType"],-19} | Intelligence : {reader["Intelligence"],-6} |");
                                                    Console.WriteLine($"| Hair Color        | {reader["HairColor"],-19} | Vitality     : {reader["Vitality"],-6} |");
                                                    Console.WriteLine($"| Gender            | {reader["Gender"],-19} | Luck         : {reader["Luck"],-6} |");
                                                    Console.WriteLine($"| Skin Tone         | {reader["SkinTone"],-19} | Dexterity    : {reader["Dexterity"],-6} |");
                                                    Console.WriteLine($"| Clothing Type     | {reader["ClothingType"],-19} | Endurance    : {reader["Endurance"],-6} |");
                                                    Console.WriteLine($"| Weapon            | {reader["Weapon"],-19} |                       |");
                                                    Console.WriteLine($"| Footwear          | {reader["Footwear"],-19} |                       |");
                                                    Console.WriteLine($"| Accessories       | {reader["Accessories"],-19} |                       |");
                                                    Console.WriteLine($"| Beast             | {reader["Beast"],-19} |                       |");
                                                    Console.WriteLine($"| Ability           | {reader["Ability"],-19} |                       |");
                                                    Console.WriteLine($"| Occupation        | {reader["Occupation"],-19} |                       |");
                                                    Console.WriteLine($"| Jewelry           | {reader["Jewelry"],-19} |                       |");
                                                    Console.WriteLine($"| Headwear          | {reader["Headwear"],-19} |                       |");
                                                    Console.WriteLine($"| Race              | {reader["Race"],-19} |                       |");
                                                    Console.WriteLine($"| Offensive Skill   | {reader["OffensiveSkill"],-19} |                       |");
                                                    Console.WriteLine($"| Supportive Skill  | {reader["SupportiveSkill"],-19} |                       |");

                                                    Console.WriteLine("+-------------------+---------------------+-----------------------+");

                                                    Console.WriteLine("\nCharacter loaded successfully!");


                                                    bool ToGoOrNah = true;

                                                    while (ToGoOrNah)
                                                    {
                                                        Console.WriteLine("Do you want to go back to Main Menu? Or Press 'S' to Start (Y/S)");

                                                        string choose = Console.ReadLine().ToUpper();

                                                        if (choose == "S")
                                                        {
                                                            Console.WriteLine("Game Start...");
                                                         
                                                            CampaignMode();
                                                            break;
                                                        }
                                                        else if (choose == "Y")
                                                        {
                                                            Console.WriteLine("You chose to go back to the main menu.");
                                                            ToGoOrNah = false;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Invalid input. Please enter 'Y' or 'S' for Start Game.");
                                                        }

                                                        Thread.Sleep(2500);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (subChoice == "2")
                                    {

                                        string query = "SELECT id, Name, EyeColor, HairType, HairColor, Gender, SkinTone, ClothingType, Weapon, Footwear, Accessories, Beast, Ability, Occupation, Jewelry, Headwear, Race, BodyType, Region, OffensiveSkill, SupportiveSkill, Strength, Agility, Intelligence, Vitality, Luck, Dexterity, Endurance FROM characters";
                                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                                        {
                                            using (MySqlDataReader reader = cmd.ExecuteReader())
                                            {
                                                if (reader.HasRows)
                                                {
                                                    Console.WriteLine("\nAvailable Characters:");
                                                    while (reader.Read())
                                                    {
                                                        Console.WriteLine("Character Details:");
                                                        Console.WriteLine("\n\n\n\n\n+-------------------+---------------------+-----------------------+");
                                                        Console.WriteLine($"|              =======>     ID: {reader["id"]}     <=======                  |");
                                                        Console.WriteLine("|-------------------+---------------------+-----------------------|");
                                                        Console.WriteLine("+-------------------+---------------------+-----------------------+");
                                                        Console.WriteLine("+-------------------+---------------------+-----------------------+");
                                                        Console.WriteLine("|      Features     |   Character Info    |         Stats         |");
                                                        Console.WriteLine("+-------------------+---------------------+-----------------------+");
                                                        Console.WriteLine($"| Character Name    | {reader["Name"],-19} | Strength     : {reader["Strength"],-6} |");
                                                        Console.WriteLine($"| Eye Color         | {reader["EyeColor"],-19} | Agility      : {reader["Agility"],-6} |");
                                                        Console.WriteLine($"| Hair Type         | {reader["HairType"],-19} | Intelligence : {reader["Intelligence"],-6} |");
                                                        Console.WriteLine($"| Hair Color        | {reader["HairColor"],-19} | Vitality     : {reader["Vitality"],-6} |");
                                                        Console.WriteLine($"| Gender            | {reader["Gender"],-19} | Luck         : {reader["Luck"],-6} |");
                                                        Console.WriteLine($"| Skin Tone         | {reader["SkinTone"],-19} | Dexterity    : {reader["Dexterity"],-6} |");
                                                        Console.WriteLine($"| Clothing Type     | {reader["ClothingType"],-19} | Endurance    : {reader["Endurance"],-6} |   SCROLL (UP/DOWN) TO SEE OTHER CHAR.");
                                                        Console.WriteLine($"| Weapon            | {reader["Weapon"],-19} |                       |");
                                                        Console.WriteLine($"| Footwear          | {reader["Footwear"],-19} |                       |");
                                                        Console.WriteLine($"| Accessories       | {reader["Accessories"],-19} |                       |");
                                                        Console.WriteLine($"| Beast             | {reader["Beast"],-19} |                       |");
                                                        Console.WriteLine($"| Ability           | {reader["Ability"],-19} |                       |");
                                                        Console.WriteLine($"| Occupation        | {reader["Occupation"],-19} |                       |");
                                                        Console.WriteLine($"| Jewelry           | {reader["Jewelry"],-19} |                       |");
                                                        Console.WriteLine($"| Headwear          | {reader["Headwear"],-19} |                       |");
                                                        Console.WriteLine($"| Race              | {reader["Race"],-19} |                       |");
                                                        Console.WriteLine($"| Offensive Skill   | {reader["OffensiveSkill"],-19} |                       |");
                                                        Console.WriteLine($"| Supportive Skill  | {reader["SupportiveSkill"],-19} |                       |");

                                                        Console.WriteLine("+-------------------+---------------------+-----------------------+\n");

                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nNo characters found.\n");
                                                    Thread.Sleep(1500);
                                                    Console.WriteLine("Please CREATE A CHARACTER FIRST!!!");
                                                    Console.WriteLine("Returning to the main menu...");
                                                    Thread.Sleep(2100);
                                                    break;
                                                }
                                            }
                                        }

                                        bool isValid = false;
                                        int selectedId = 0;


                                        while (!isValid)
                                        {
                                            Console.Write("\nEnter the ID of the character you want to delete: ");
                                            string input = Console.ReadLine();

                                            if (!int.TryParse(input, out selectedId))
                                            {
                                                Console.WriteLine("Invalid input. Please enter a valid numeric ID.\n");
                                                continue;
                                            }

                                            query = "SELECT COUNT(*) FROM characters WHERE id = @id";
                                            using (MySqlCommand cmdCheck = new MySqlCommand(query, conn))
                                            {
                                                cmdCheck.Parameters.AddWithValue("@id", selectedId);
                                                int count = Convert.ToInt32(cmdCheck.ExecuteScalar()); // executing only Id
                                                if (count > 0)
                                                {
                                                    isValid = true;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No character found with the specified ID. Please try again.\n");
                                                }
                                            }
                                        }

                                       
                                        Console.Write($"\nAre you sure you want to delete the character with ID {selectedId}? (Y/N): ");
                                        string firstConfirmation = Console.ReadLine().ToUpper();

                                        while (firstConfirmation != "Y" && firstConfirmation != "N")
                                        {
                                            Console.WriteLine("Invalid input. Please enter 'Y' for Yes or 'N' for No.");
                                            Console.Write($"\nAre you sure you want to delete the character with ID {selectedId}? (Y/N): ");
                                            firstConfirmation = Console.ReadLine().ToUpper();
                                        }

                                        if (firstConfirmation == "Y")
                                        {
                                            
                                            Console.Write("\nAre you absolutely sure? This action cannot be undone! (Y/N): ");
                                            string secondConfirmation = Console.ReadLine().ToUpper();

                                            while (secondConfirmation != "Y" && secondConfirmation != "N")
                                            {
                                                Console.WriteLine("Invalid input. Please enter 'Y' for Yes or 'S' for Start Game");
                                                Console.Write("\nAre you absolutely sure? This action cannot be undone! (Y/N): ");
                                                secondConfirmation = Console.ReadLine().ToUpper();
                                            }

                                            if (secondConfirmation == "Y")
                                            {
                                               
                                               
                                              
                                            }
                                            else
                                            {
                                                Console.WriteLine("Deletion canceled. Returning to the main menu...");
                                                Thread.Sleep(1500);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Deletion canceled. Returning to the main menu...");
                                            Thread.Sleep(1500);
                                            break;
                                        }




                                        query = "DELETE FROM characters WHERE id = @id";
                                        using (MySqlCommand cmdDelete = new MySqlCommand(query, conn))
                                        {
                                            cmdDelete.Parameters.AddWithValue("@id", selectedId);
                                            int rowsAffected = cmdDelete.ExecuteNonQuery();

                                            if (rowsAffected > 0)
                                            {
                                                Console.WriteLine("Character successfully deleted.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("An error occurred while trying to delete the character.");
                                            }

                                            bool ToGoOrNah = true;

                                            while (ToGoOrNah)
                                            {
                                                Console.WriteLine("Do you want to go back to Main Menu? Press (Y)");

                                                string choose = Console.ReadLine().ToUpper();

                                                if (choose == "Y")
                                                {
                                                    Console.WriteLine("You chose to go back to the main menu.");
                                                    ToGoOrNah = false;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid input. Please enter 'Y' for Yes");
                                                }

                                                Thread.Sleep(2500);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid option. Returning to the main menu...");
                                    }
                                }
                            }
                        }
                        catch (MySqlException ex)
                        {
                            Console.WriteLine($"An error occurred! Please Start your SQL and Try again: {ex.Message}");
                            Environment.Exit(0);
                        }
                    }




                    else if (choice == "3")
                    {

                        Console.SetCursorPosition(0, 0);
                        CampaignMode();
                    }
                    else if (choice == "4")
                    {
                        Console.Clear();
                        Console.WriteLine("\n======== CREDITS =======\n");
                        Console.WriteLine("This game was developed by: \n");
                        Console.WriteLine("LEADER: \n\nMhart Aaron Navales (Overthinkerist) – Very passionate and dedicated sa kung ano mang ano na yan, pero tamad minsan tas \nprocrastinator ganon :>>. CS student na Customer Service.\n");
                        Console.WriteLine("MEMBERS: \n\nMyra Geanga - An imaginative storyteller inspired by television, I craft short stories filled with adventure, fantasy, and vivid settings.");
                        Console.WriteLine("Donna Tagura - a gifted storyteller who creates engaging and meaningful stories. My work somehow captures human experiences with \ngreat details, inspiring and connecting with my audiences. \n");
                        Console.WriteLine("\nThank you for playing!");

                        Console.WriteLine("\nPress any key to return to the main menu...");
                        Console.ReadKey();
                    }
                    else if (choice == "5")
                    {
                        ShowExitScreen();
                        GameisRunning = false;
                        Environment.Exit(0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        #endregion

        #region -- Regex Name Validation -- 

        static bool IsValidCharacterName(string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("\nCharacter name cannot be empty.");
                return false;
            }

            if (name.Length < 3 || name.Length > 15)
            {
                Console.WriteLine("\nCharacter name must be between 3 and 15 characters only.");
                return false;
            }


            string pattern = @"^[A-Za-z0-9\-.,@]+$";
            if (!Regex.IsMatch(name, pattern))
            {
                Console.WriteLine("\nOnly letters, numbers, and symbols (-, ., @,) are allowed.");
                return false;
            }


            string connStr = "Server=localhost;Database=character_dbmdvad100;Uid=root;Pwd=;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM characters WHERE Name = @name";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            Console.WriteLine("\nName is already taken..");
                            return false;
                        }
                        else
                        {
                            Console.WriteLine("Character name created..\n");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"\nError checking name availability! Please Start your SQL and Try again: {ex.Message}");
                Environment.Exit(0);


            }

            return true;
        }

        #endregion

        #region -- Campaign Mode --


        static void CampaignMode()
        {
            Console.Clear();
            Console.WriteLine("===== CAMPAIGN MODE =====\n");

            DisplayWithEffect("Welcome to the campaign! Your journey begins here...\n", 50, true);

            Console.WriteLine("\n=== STORY ===\n");
            DisplayWithEffect(@"
  .     '     ,
    _________
 _ /_|_____|_\ _
   '. \   / .'
     '.\ /.'
       '.'                      You can press any key to skip...
 
", 1, false);

            DisplayWithEffect(@"
In the kingdom of Soltaria lay five gems, the center of the kingdom that protected and sustained it since day one.
The people enjoyed peace and happiness, knowing nothing of the prophecy predicting the scattering of these precious gems.

Seers for years had prophesied the loss of the gems and how only the chosen keepers would be able to retrieve them.

On that fateful night, a force so potent and unseen broke the shield of protection meant to be around the kingdom,
scattering the gems across far distances. Prophecy was thus fulfilled, and it is now up to the guardians to emerge
and reposition the gems back in their original place.
", 1, true);

            Console.ForegroundColor = ConsoleColor.Cyan;
            DisplayWithEffect(@"
    ~ Journey Begins ~
", 1, true);
            Console.ResetColor();

            DisplayWithEffect(@"
A traveler by the name of Jack was called in his dream with a vision of the fall of the kingdom and a voice urging him
to seek out the white gem, an icon of peace. In his quest, he comes across an injured warrior, also seeking the red gem
that will give him undying strength and courage. They soon get joined by a mage looking for the green gem, a seer searching
for the purple gem for protection of secrets, and another keeper on a quest to find the blue gem of knowledge.
", 1, true);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DisplayWithEffect(@"
    * Trials of the Keepers *
", 1, true);
            Console.ResetColor();

            DisplayWithEffect(@"
As they journey, the keepers face many trials, each testing their strength, wisdom, and resolve.
The faint voice inside their heads pushes them forward, urging them to overcome the challenges they encounter.
However, as their quest nears its end, they learn the devastating truth: to restore the kingdom, each keeper must sacrifice
their life to activate the gems' power. It is a fate they can never run away from, one that has been written in the stars
since the formation of the kingdom. Finally, only their selfless sacrifice will save the kingdom, and the once-thriving
land of Soltaria will be returned to peace.
", 1, true);

            DisplayWithEffect(@"

           .          .           .     .                .       .
  .      .      *           .       .          .                       .
                 .       .   . *            ""I will get stronger...
  .       ____     .      . .   _         .    For the kingdom of Soltaria!!""

", 1, true);
            Console.WriteLine("   >>         .        .               .\r\n .   .  /WWWI; \\  .       .    .  ____               .         .     .         \r\n  *    /WWWWII; \\=====;    .     /WI; \\   *    .        /\\_             .\r\n  .   /WWWWWII;..      \\_  . ___/WI;:. \\     .        _/M; \\    .   .         .\r\n     /WWWWWIIIIi;..      \\__/WWWIIII:.. \\____ .   .  /MMI:  \\   * .\r\n . _/WWWWWIIIi;;;:...:   ;\\WWWWWWIIIII;.     \\     /MMWII;   \\    .  .     .\r\n  /WWWWWIWIiii;;;.:.. :   ;\\WWWWWIII;;;::     \\___/MMWIIII;   \\              .\r\n /WWWWWIIIIiii;;::.... :   ;|WWWWWWII;;::.:      :;IMWIIIII;:   \\___     *\r\n/WWWWWWWWWIIIIIWIIii;;::;..;\\WWWWWWIII;;;:::...    ;IMIII;;     ::  \\     .\r\nWWWWWWWWWIIIIIIIIIii;;::.;..;\\WWWWWWWWIIIII;;..  :;IMIII;:::     :    \\   \r\nWWWWWWWWWWWWWIIIIIIii;;::..;..;\\WWWWWWWWIIII;::; :::::::::.....::       \\\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXX\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXX\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXX\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXX\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXX\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXX");


            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Press C to Continue To Game and Press R if you want to Return to Main Menu");
                string continue_ = Console.ReadLine().ToUpper().Trim();

                if (continue_ == "C")
                {
                    Console.WriteLine("GAME START!!");

                }
                else if (continue_ == "R")
                {
                    Console.WriteLine("Returning to Main Menu...");
                    Thread.Sleep(1500);
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Please input a valid key");
                }


            }
        }

        static void DisplayWithEffect(string text, int delay, bool allowSkip)
        {
            foreach (char c in text)
            {
                if (allowSkip && Console.KeyAvailable)
                {

                    Console.Write(text.Substring(text.IndexOf(c)));
                    Console.ReadKey(true);
                    return;
                }

                Console.Write(c);
                Thread.Sleep(delay);
            }
        }





        static void ShowLoadingScreen()
        {
            Console.Clear();
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;
            int centerX = consoleWidth / 2;
            int centerY = consoleHeight / 2;

            string[] loadingSymbols = new string[]
            {
        @"  ^_______^ 1
 /       \ 
 /  O | O  \ 
 \         / 
 \_______/ |",
        @"  ^_______^ 2
 /       \ 
 / O  \  O \ 
 \         / |
 \_______/ |",
        @"  ^_______^ 3
 /       \ 
 /    -    \ |
 \         / |
 \_______/ |",
        @"      ^_______^ -|===>
 /   O   \ |
 /    /    \ |
 \    O    / |
 \_______/ |",
            };

            string loadingText = "Loading... Please Wait (PLDT ANO NA)";
            int index = 0;
            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < 15; i++)
            {
                Console.Clear();

                string[] gemLines = loadingSymbols[index].Split('\n');
                for (int lineIndex = 0; lineIndex < gemLines.Length; lineIndex++)
                {
                    int gemX = centerX - gemLines[lineIndex].Length / 2;
                    int gemY = centerY - 3 + lineIndex;
                    Console.SetCursorPosition(gemX, gemY);
                    Console.Write(gemLines[lineIndex]);
                }


                int textX = centerX - loadingText.Length / 2;
                int textY = centerY + 3;
                Console.SetCursorPosition(textX, textY);
                Console.Write(loadingText);

                index = (index + 1) % loadingSymbols.Length;
                Thread.Sleep(200);
            }

            Console.Clear();
            Console.ResetColor();
        }

        static void ShowExitScreen()
        {
            Console.Clear();
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;
            int centerX = consoleWidth / 2;
            int centerY = consoleHeight / 2;

            string[] loadingSymbols = new string[]
            {
        @"  ^_______^ 1
 /       \ 
 /  X | X  \ 
 \         / 
 \_______/ |",
        @"  ^_______^ 2
 /       \ 
 / X  \  X \ 
 \         / |
 \_______/ |",
        @"  ^_______^ 3
 /       \ 
 /    -    \ |
 \         / |
 \_______/ |",
        @"      ^_______^ -|===>
 /   X   \ |
 /    /    \ |
 \    X    / |
 \_______/ |",
            };

            string loadingText = "Exiting the game...x_x";
            int index = 0;
            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < 15; i++)
            {
                Console.Clear();


                string[] gemLines = loadingSymbols[index].Split('\n');
                for (int lineIndex = 0; lineIndex < gemLines.Length; lineIndex++)
                {
                    int gemX = centerX - gemLines[lineIndex].Length / 2;
                    int gemY = centerY - 3 + lineIndex;
                    Console.SetCursorPosition(gemX, gemY);
                    Console.Write(gemLines[lineIndex]);
                }


                int textX = centerX - loadingText.Length / 2;
                int textY = centerY + 3;
                Console.SetCursorPosition(textX, textY);
                Console.Write(loadingText);

                index = (index + 1) % loadingSymbols.Length;
                Thread.Sleep(200);
            }

            Console.Clear();
            Console.ResetColor();
        }


    }
}

#endregion

