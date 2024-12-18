using System;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

#region -- Abstract Class, Abstract Methods, Constructors, this --
// Abstract class: CharacterBase (Abstract Classes and Abstract Methods)
abstract class CharacterBase
{
    public string Name { get; set; }

    // Constructor to initialize name (Constructors)
    public CharacterBase(string name)
    {
        this.Name = name; // Using 'this' keyword
    }

    // Abstract method to input the character's features (Abstract Methods)
    public abstract void InputFeature();

    // Abstract method to input the character's stats (Abstract Methods)
    public abstract void InputStats();

    // Abstract method to save character data (Abstract Methods)
    public abstract void Save();
}
#endregion

#region -- Struct, Constructors, this --
// struct to hold character stats (Structure)
struct Stats
{
    public int Strength, Agility, Intelligence, Vitality, Luck, Dexterity, Endurance;

    // Constructor to initialize all stats (Constructors)
    public Stats(int strength, int agility, int intelligence, int vitality, int luck, int dexterity, int endurance)
    {
        this.Strength = strength; // Using 'this' keyword
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
// Class to hold character features like eye color, hair type, hair color (Encapsulation)
class CharacterFeatures
{
    public string EyeColor { get; set; }
    public string HairType { get; set; }
    public string HairColor { get; set; }
    public string Gender { get; set; }
    public string SkinTone { get; set; }
    public string ClothingType { get; set; }  
    public string Weapon {  get; set; }
    public string Footwear { get; set; }
    public string Accessories { get; set; } 
    public string Beast { get; set; }
    public string Ability { get; set; }
    public string Occupation { get; set; }
    public string Jewelry { get; set; }
    public string Headwear { get; set; }
    public string Race { get; set; }   
    public string BodyType {  get; set; }
    public string Region { get; set; }
    public string SkillOffensive {  get; set; }
    public string SkillSupportive { get; set; }


    // Constructor to initialize character features (Constructors)
    public CharacterFeatures(string eyeColor, string hairType, string hairColor, string gender, string skinTone, string clothingType, string weapon, 
        string footWear, string accessories, string beast, string ability, string occupation, string jewelry, string headWear,
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
// Interface to define character actions (Interfaces)
interface ICharacterActions
{
    void InputFeature();
    void InputStats();
    void Save();
}
#endregion

#region -- Inheritance, Interface, Encaps, Method Overriding, Method Overloading, Constructor, this, Exception Handling, Database -- 
// Concrete class: Character inherits from CharacterBase and implements ICharacterActions (Inheritance, Interface)
class Character : CharacterBase, ICharacterActions
{
    // Fields for encapsulating character attributes (Encapsulation)
    private int eyeColorChoice, hairTypeChoice, hairColorChoice, genderChoice, skinToneChoice,  clothingTypeChoice, weaponChoice, footWearChoice, 
                accessoriesChoice, beastChoice, abilityChoice, occupationChoice, jewelryChoice, headWearChoice, raceChoice, bodyTypeChoice, 
                regionChoice, skillOffensiveChoice, skillSupportiveChoice;

    private Stats characterStats;  // Composition: Character contains Stats
    private CharacterFeatures features;  // Composition: Character contains Features

    // Constructor that initializes base class (Constructors)
    public Character(string name) : base(name) { }

    // Method Overriding: Input the character's features like eye color, hair type, and hair color (Method Overriding)
    public override void InputFeature()
    {

        // Input the features like eye color, hair type, and hair color
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
        this.InputFeature("Jewelry", 1, 5);
        this.InputFeature("Headwear", 1, 5);
        this.InputFeature("Race", 1, 5);
        this.InputFeature("Body Type",1, 5);
        this.InputFeature("Region", 1, 5);
        this.InputFeature("Offensive Skill", 1, 5); // should be 5, add one more offensive skill
        this.InputFeature("Supportive Skill", 1, 6);
    }

    // Method Overloading: Input the feature choices like Eye Color, Hair Type, Hair Color, etc. (Method Overloading)
    public void InputFeature(string featureName)
    {
        Console.WriteLine($"\nChoose {featureName}:");

        // Display options inline based on featureName
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
            case "Jewelry":
                Console.WriteLine("1. Bracelet\n2. Necklace\n3. Earrings\n4. Ring\n5. Anklet");
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
                Console.WriteLine("1. Power Strike: A strong melee attack that deals heavy damage to a single target.\n2. Fireball: Launches a fiery projectile that explodes on impact, dealing area-of-effect damage over time.\n3. Arcane Blast: Unleashes a burst of arcane energy that damages all nearby enemies in a small radius.\n4. Thunder Strike: Calls down a lightning bolt to strike a target, with a chance to stun nearby enemies.\n5. MAGLAGAY");
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

        while (!validInput)
        {
            // Display feature name
            Console.WriteLine($"\nChoose {featureName}:");

            // Display options inline based on featureName
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
                case "Jewelry":
                    Console.WriteLine("1. Bracelet\n2. Necklace\n3. Earrings\n4. Ring\n5. Anklet");
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
                    Console.WriteLine("1. Power Strike: A strong melee attack that deals heavy damage to a single target.\n2. Fireball: Launches a fiery projectile that explodes on impact, dealing area-of-effect damage over time.\n3. Arcane Blast: Unleashes a burst of arcane energy that damages all nearby enemies in a small radius.\n4. Thunder Strike: Calls down a lightning bolt to strike a target, with a chance to stun nearby enemies.\n5. MAGLAGAY");
                    break;
                case "Supportive Skill":
                    Console.WriteLine("1. Quick Dash: Temporarily boosts your movement speed, allowing you to dodge attacks or quickly close the distance to enemies.\n2. Heal: Restores a portion of health to yourself or an ally, perfect for staying alive in tough fights.\n3. Shadow Cloak: Grants temporary invisibility, allowing you to sneak past enemies or avoid damage.\n4. Ice Shield: Creates a barrier of ice around you that absorbs damage for a short period.\n5. Trap Setting: Place traps that trigger when enemies walk over them, causing damage or status effects like poison.\n6. Summon Familiar: Summons a magical creature to assist you in combat, offering support or distracting enemies.");
                    break;

            }

            Console.WriteLine($"Enter the number corresponding to your choice ({minChoice}-{maxChoice}):");
            string input = Console.ReadLine();

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
        }

        // After valid input, you can continue processing the choice as needed
        Console.WriteLine($"You chose option {choice} for {featureName}.");
    

        // Assign the choice based on featureName
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
                // Add cases for other features
        }
    }



    // Method Overriding: Input stats and distribute points (Method Overriding)
    public override void InputStats()
    {
        Console.WriteLine("Distribute 20 points across the stats (max 5 per stat):");
        // Creating an instance of Stats using allocated points
        this.characterStats = new Stats(
            strength: 0,
            agility: 0,
            intelligence: 0,
            vitality: 0,
            luck: 0,
            dexterity: 0,
            endurance: 0
        );

        // Call PointAllocation for distributing points
        var points = PointAllocation();

        // Assigning the allocated points to the stats
        this.characterStats = new Stats(
            points.strength,
            points.agility,
            points.intelligence,
            points.vitality,
            points.luck,
            points.dexterity,
            points.endurance
        );

        // Assigning features based on choices made
        this.features = new CharacterFeatures(GetEyeColor(), GetHairType(), GetHairColor(), GetGender(), GetSkinTone(), 
                            GetClothingType(), GetWeapon(), GetFootWear(), GetAccessories(), GetBeast(), 
                            GetAbility(), GetOccupation(), GetJewelry(), GetHeadWear(), GetRace(), 
                            GetBodyType(), GetRegion(), GetSkillOffensive(), GetSkillSupportive());
    }

    // Method for point allocation
    public (int strength, int agility, int intelligence, int vitality, int luck, int dexterity, int endurance) PointAllocation()
    {
        int strength = 0, agility = 0, intelligence = 0, vitality = 0, luck = 0, dexterity = 0, endurance = 0;
        int totalPoints = 20;

        Console.WriteLine("Distribute allocation points only (maximum of 5 each stat). Total remaining points: 20");

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
            int choice = int.Parse(Console.ReadLine());

            if (choice < 1 || choice > 7)
            {
                Console.WriteLine("Invalid choice. Please select a number between 1 and 7.");
                continue;
            }

            int pointsToAllocate = GetPointsInput(totalPoints);

            switch (choice)
            {
                case 1: // Strength
                    strength += pointsToAllocate;
                    totalPoints -= pointsToAllocate;
                    break;

                case 2: // Agility
                    agility += pointsToAllocate;
                    totalPoints -= pointsToAllocate;
                    break;

                case 3: // Intelligence
                    intelligence += pointsToAllocate;
                    totalPoints -= pointsToAllocate;
                    break;

                case 4: // Vitality
                    vitality += pointsToAllocate;
                    totalPoints -= pointsToAllocate;
                    break;

                case 5: // Luck
                    luck += pointsToAllocate;
                    totalPoints -= pointsToAllocate;
                    break;

                case 6: // Dexterity
                    dexterity += pointsToAllocate;
                    totalPoints -= pointsToAllocate;
                    break;

                case 7: // Endurance
                    endurance += pointsToAllocate;
                    totalPoints -= pointsToAllocate;
                    break;
            }
        }

        return (strength, agility, intelligence, vitality, luck, dexterity, endurance);
    }


    // Allocate points to a specific stat (Encapsulation)
    private int AllocatePoints(string statName, ref int remainingPoints)
    {
        Console.WriteLine($"\n{statName} (max 5 per stat, Remaining Points: {remainingPoints})");
        int points = GetPointsInput(remainingPoints);

        remainingPoints -= points;
        return points;
    }

    // Modified to use encapsulated logic to get points input
    public int GetPointsInput(int remainingPoints)
    {
        int points;
        while (true)
        {
            Console.WriteLine($"Enter points to allocate (1-5) [Remaining points: {remainingPoints}]:");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out points) || points < 1 || points > 5 || points > remainingPoints)
            {
                Console.WriteLine($"Invalid input. Please enter a number between 1 and 5, and no more than {remainingPoints}.");
            }
            else
            {
                return points;
            }
        }
    }

    // Save character data to MySQL database (Database, Exception Handling)
    public override void Save()
    {
        string connStr = "Server=localhost;Database=character_db;Uid=root;Pwd=;";
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // SQL INSERT operation
                string query = "INSERT INTO characters (Name, HairColor, EyeColor, HairType, Strength, Agility, Intelligence, Vitality, Luck, Dexterity, Endurance) " +
                               "VALUES (@Name, @HairColor, @EyeColor, @HairType, @Strength, @Agility, @Intelligence, @Vitality, @Luck, @Dexterity, @Endurance)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", this.Name); // Using 'this' keyword
                    cmd.Parameters.AddWithValue("@HairColor", GetHairColor());
                    cmd.Parameters.AddWithValue("@EyeColor", GetEyeColor());
                    cmd.Parameters.AddWithValue("@HairType", GetHairType());
                    cmd.Parameters.AddWithValue("@Strength", this.characterStats.Strength);
                    cmd.Parameters.AddWithValue("@Agility", this.characterStats.Agility);
                    cmd.Parameters.AddWithValue("@Intelligence", this.characterStats.Intelligence);
                    cmd.Parameters.AddWithValue("@Vitality", this.characterStats.Vitality);
                    cmd.Parameters.AddWithValue("@Luck", this.characterStats.Luck);
                    cmd.Parameters.AddWithValue("@Dexterity", this.characterStats.Dexterity);
                    cmd.Parameters.AddWithValue("@Endurance", this.characterStats.Endurance);

                    cmd.ExecuteNonQuery(); // Execute SQL query
                }
            }
            Console.WriteLine("Character saved to MySQL database!");
        }
         // Exception Handling
        catch (MySqlException ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    #endregion

#region -- DISPLAY OR OUTPUT --
    // Display the character data (Method Overloading)
    public void Display()
    {
        Console.WriteLine("Tagumpay ang pagkakagawa sa character!!");
        Console.WriteLine("+----------------+----------------------+--------------------+");
        Console.WriteLine("|    Features    |    Character Info    |        Stats       |");
        Console.WriteLine("+----------------+----------------------+--------------------+");

        // Using 'this' to access properties of the character and its features/stats
        Console.WriteLine($"| Character Name | {this.Name.PadRight(20)} | Strength: {this.characterStats.Strength.ToString().PadLeft(10)} |");
        Console.WriteLine($"| Eye Color      | {this.features.EyeColor.PadRight(20)} | Agility: {this.characterStats.Agility.ToString().PadLeft(10)} |");
        Console.WriteLine($"| Hair Type      | {this.features.HairType.PadRight(20)} | Intelligence: {this.characterStats.Intelligence.ToString().PadLeft(10)} |");
        Console.WriteLine($"| Hair Color     | {this.features.HairColor.PadRight(20)} | Vitality: {this.characterStats.Vitality.ToString().PadLeft(10)} |");
        Console.WriteLine($"| Gender         | {this.features.Gender.PadRight(20)} | Luck: {this.characterStats.Luck.ToString().PadLeft(10)} |");
        Console.WriteLine($"| Skin Tone      | {this.features.SkinTone.PadRight(20)} | Dexterity: {this.characterStats.Dexterity.ToString().PadLeft(10)} |");
        Console.WriteLine($"| Clothing Type  | {this.features.ClothingType.PadRight(20)} | Endurance: {this.characterStats.Endurance.ToString().PadLeft(10)} |");
        Console.WriteLine($"| Weapon         | {this.features.Weapon.PadRight(20)} |                    |");
        Console.WriteLine($"| Footwear       | {this.features.Footwear.PadRight(20)} |                    |");
        Console.WriteLine($"| Accessories    | {this.features.Accessories.PadRight(20)} |                    |");
        Console.WriteLine($"| Beast          | {this.features.Beast.PadRight(20)} |                    |");
        Console.WriteLine($"| Ability        | {this.features.Ability.PadRight(20)} |                    |");
        Console.WriteLine($"| Occupation     | {this.features.Occupation.PadRight(20)} |                    |");
        Console.WriteLine($"| Jewelry        | {this.features.Jewelry.PadRight(20)} |                    |");
        Console.WriteLine($"| Headwear       | {this.features.Headwear.PadRight(20)} |                    |");
        Console.WriteLine($"| Race           | {this.features.Race.PadRight(20)} |                    |");
        Console.WriteLine($"| Offensive      | {this.features.SkillOffensive.PadRight(20)} |                    |");
        Console.WriteLine($"| Supportive     | {this.features.SkillSupportive.PadRight(20)} |                    |");
        Console.WriteLine($"| Body Type      | {this.features.BodyType.PadRight(20)} |                    |");
        Console.WriteLine($"| Region         | {this.features.Region.PadRight(20)} |                    |");

        Console.WriteLine("+----------------+----------------------+--------------------+");
    }


    // Helper methods to retrieve hair color, eye color, and hair type (Method Overloading)
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

    public string GetJewelry() => this.jewelryChoice switch
    {
        1 => "Bracelet",
        2 => "Necklace",
        3 => "Earrings",
        4 => "Ring",
        5 => "Anklet",
        _ => "Unknown"
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
        5 => "Nothing Please ADD something",
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

                    Console.Clear();  // Clears the screen
                    Console.SetCursorPosition(0, 0);  // Resets the cursor to the top-left corner
                    Console.WriteLine("\n==== Guardians of the Scattered Gems ====");
                    Console.WriteLine("\n1. Create New Karater");
                    Console.WriteLine("2. Lod Game");
                    Console.WriteLine("3. Campaign Mode");
                    Console.WriteLine("4. Credits");
                    Console.WriteLine("5. Alis sa far away");
                    Console.Write("Choose an option (1-5): ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    string name;

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

                    // Creating a new character instance
                    Character newCharacter = new Character(name);

                    newCharacter.InputFeature(); // Input character's features
                    newCharacter.InputStats();   // Input stats

                    newCharacter.Display(); // Display character data
                    newCharacter.Save(); // Save character to MySQL

                    bool ToGoOrNah = true;

                    while (ToGoOrNah)
                    {
                        Console.WriteLine("Do you want to proceed or go back to the main menu? (Y/N)");

                        string choose = Console.ReadLine().ToUpper();  

                        if (choose == "Y")
                        {
                            
                            Console.WriteLine("Game Start...");
                            return;
                            
                        }
                        else if (choose == "N")
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
                    string connStr = "Server=localhost;Database=character_db;Uid=root;Pwd=;";
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(connStr))
                        {
                            conn.Open();

                            string query = "SELECT * FROM characters";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        Console.Clear();  // Clears screen before loading characters
                                        Console.SetCursorPosition(0, 0);  // Resets the cursor
                                        Console.WriteLine("Load Existing Character:");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"Name: {reader["Name"]}, " +
                                                              $"Hair Color: {reader["HairColor"]}, " +
                                                              $"Eye Color: {reader["EyeColor"]}, " +
                                                              $"Hair Type: {reader["HairType"]}, " +
                                                              $"Strength: {reader["Strength"]}, " +
                                                              $"Agility: {reader["Agility"]}, " +
                                                              $"Intelligence: {reader["Intelligence"]}, " +
                                                              $"Vitality: {reader["Vitality"]}, " +
                                                              $"Luck: {reader["Luck"]}, " +
                                                              $"Dexterity: {reader["Dexterity"]}, " +
                                                              $"Endurance: {reader["Endurance"]}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No saved characters found.");
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading characters: {ex.Message}");
                    }
                    Thread.Sleep(2000); // Pause after displaying loaded characters
                }
                else if (choice == "3")
                {
                    Console.Clear();  // Clears screen before launching campaign mode
                    Console.SetCursorPosition(0, 0);  // Resets the cursor
                    CampaignMode();
                }
                else if (choice == "4")
                {
                    // Displaying the credits
                    Console.WriteLine("\n======== CREDITS =======\n");
                    Console.WriteLine("This game was developed by: \n");
                    Console.WriteLine("LEADER: \n\nMhart Aaron Navales (Overthinkerist) – Very passionate and dedicated sa kung ano mang ano na yan, pero tamad minsan tas \nprocrastinator ganon :>>. CS student na Customer Service.\n");
                    Console.WriteLine("MEMBERS: \n\nMyra Geanga - An imaginative storyteller inspired by television, I craft short stories filled with adventure, fantasy, and vivid settings.");
                    Console.WriteLine("Donna Tagura - a gifted storyteller who creates engaging and meaningful stories. My work somehow captures human experiences with \ngreat details, inspiring and connecting with my audiences. \n");
                    Console.WriteLine("\nThank you for playing!");

                    // Optional: You can add a prompt to go back to the main menu.
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();  // Wait for user input before returning to main menu
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Exiting the game...");
                    GameisRunning = false;
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000);  // Pause to allow user to see the invalid message before clearing
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
    // Method to validate character name
    static bool IsValidCharacterName(string name)
    {
        // Check if the name is empty or null
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("\nCharacter name cannot be empty.");
            return false;
        }

        // Check if the length is between 3 and 15 characters
        if (name.Length < 3 || name.Length > 15)
        {
            Console.WriteLine("\nCharacter name must be between 3 and 15 characters only.");
            return false;
        }

        // Regular expression to allow valid characters
        // Letters, numbers, and only these symbols: -, ., @, and ,
        string pattern = @"^[A-Za-z0-9\-.,@]+$";

        if (!Regex.IsMatch(name, pattern))
        {
            Console.WriteLine("\nInvalid character name. Only letters, numbers, and symbols (-, ., @,) are allowed.");
            return false;
        }

        return true;
    }
    #endregion

#region -- Campaign Mode --
    static void CampaignMode()
    {
        Console.WriteLine("===== CAMPAIGN MODE =====\n");
        Console.WriteLine("Welcome to the campaign! Your journey begins here...");
        Console.WriteLine("\n=== STORY ===\n");            
        Console.WriteLine(                               
"In the kingdom of Soltaria lay five gems, the center of the kingdom that protected and sustained it since day one.\n" +
"The people enjoyed peace and happiness, knowing nothing of the prophecy predicting the scattering of these precious gems.\n" +
"Seers for years had prophesied the loss of the gems and how only the chosen keepers would be able to retrieve them.\n" +
"On that fateful night, a force so potent and unseen broke the shield of protection meant to be around the kingdom,\n" +
"scattering the gems across far distances. Prophecy was thus fulfilled, and it is now up to the guardians to emerge\n" +
"and reposition the gems back in their original place.\n\n" +

"A traveler by the name of Jack was called in his dream with a vision of the fall of the kingdom and a voice urging him\n" +
"to seek out the white gem, an icon of peace. In his quest, he comes across an injured warrior, also seeking the red gem\n" +
"that will give him undying strength and courage. They soon get joined by a mage looking for the green gem, a seer searching\n" +
"for the purple gem for protection of secrets, and another keeper on a quest to find the blue gem of knowledge.\n" +
"The five keepers, though different from one another, are somehow interlinked in their destiny. They form an alliance\n" +
"that is based on trust and friendship. Together, they set off on their journey as guided by the mysterious voice inside them.\n\n" +

"As they journey, the keepers face many trials, each testing their strength, wisdom, and resolve.\n" +
"The faint voice inside their heads pushes them forward, urging them to overcome the challenges they encounter.\n" +
"However, as their quest nears its end, they learn the devastating truth: to restore the kingdom, each keeper must sacrifice\n" +
"their life to activate the gems' power. It is a fate they can never run away from - one that has been written in the stars\n" +
"since the formation of the kingdom. Finally, only their selfless sacrifice will save the kingdom, and the once-thriving\n" +
"land of the Karath will be returned to peace.");
        Console.WriteLine("Press Any Key to Skip...");
        Console.ReadKey();
        Console.Clear();


        bool campaignRunning = true;

        while (campaignRunning)
        {
            Console.WriteLine("===== CAMPAIGN MODE =====");
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Explore a dungeon");
            Console.WriteLine("2. Battle an enemy");
            Console.WriteLine("3. Return to Main Menu");
            Console.Write("Enter your choice: \n");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("You explore a dark and mysterious dungeon...\n");
                // Add logic for exploring a dungeon
            }
            else if (choice == "2")
            {
                Console.WriteLine("You encounter a fearsome enemy!\n");
                // Add logic for battling an enemy
            }
            else if (choice == "3")
            {
                Console.WriteLine("Exiting Campaign Mode...");
                Console.WriteLine("3...");
                Thread.Sleep(2000);
                Console.WriteLine("2..");
                Thread.Sleep(2000);
                Console.WriteLine("1.");
                Thread.Sleep(2000);
                campaignRunning = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
            }
        }
    }
}
#endregion


