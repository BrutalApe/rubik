using Godot;
using System;

enum buttons{
    Hero = 2,
    Item = 3,
    Magic = 4,
    Instant = 5,
    Leader = 6,
    Monster = 7,
    Back = 10,
}

enum card_hero {
	Napping_Nibbles = 1,
	Tipsy_Tootie = 2,
	Lucky_Bucky = 3,
	Peanut = 4,
	Mellow_Dee = 5,
	Greedy_Cheeks = 6,
	Fuzzy_Cheeks = 7,
	Dodgy_Dealer = 8,
	Tough_Teddy = 9,
	Heavy_Bear = 10,
	Fury_Knuckle = 11,
	Beary_Wise = 12,
	Bear_Claw = 13,
	Bad_Axe = 14,
	Pan_Chucks = 15,
	Qi_Bear = 16,
	Holy_Curselifter = 17,
	Radiant_Horn = 18,
	Wise_Shield = 19,
	Guiding_Light = 20,
	Mighty_Blade = 21,
	Iron_Resolve = 22,
	Vibrant_Glow = 23,
	Calming_Voice = 24,
	Lookie_Rookie = 25,
	Sharp_Fox = 26,
	Hook = 27,
	Bullseye = 28,
	Wildshot = 29,
	Quick_Draw = 30,
	Serious_Grey = 31,
	Wily_Red = 32,
	Slippery_Paws = 33,
	Sly_Pickings = 34,
	Plundering_Puma = 35,
	Smooth_Mimimeow = 36,
	Silent_Shadow = 37,
	Shurikitty = 38,
	Kit_Napper = 39,
	Meowzio = 40,
	Bun_Bun = 41,
	Buttons = 42,
	Snowball = 43,
	Hopper = 44,
	Spooky = 45,
	Fluffy = 46,
	Wiggles = 47,
	Whiskers = 48,
	Looting_Lupo = 49,
	Wolfgang_Pack = 50,
	Silent_Shield = 51,
	Critical_Fang = 52,
	Agile_Dagger = 53,
	Blinding_Blade = 54,
	Tenacious_Timber = 55,
	Hardened_Hunter = 56,
	Big_Buckley = 57,
	Stagguard = 58,
	Doe_Fallow = 59,
	Maegisty = 60,
	Glowing_Antler = 61,
	Majestelk = 62,
	Buck_Omens = 63,
	Magus_Moose = 64,
    First = 1,
    Last = 64,
};

enum card_magic {
    Call_to_the_Fallen = 65,
	Critical_Boost = 66,
	Destructive_Spell = 67,
	Enchanted_Spell = 68,
	Entangling_Trap = 69,
	Forced_Exchange = 70,
	Forceful_Winds = 71,
	Winds_of_Change = 72,
	Rapid_Refresh = 73,
	Beast_Call = 74,
    First = 65,
    Last = 74,
};

enum card_item {
	Bard = 75,
	Fighter = 76,
	Guardian = 77,
	Ranger = 78,
	Thief = 79,
	Wizard = 80,
	Warrior = 81,
	Druid = 82,
	Decoy_Doll = 83,
	Particularly_Rusty_Coin = 84,
	Really_Big_Ring = 85,
	Even_Bigger_Ring = 86,
	Temporal_Hourglass = 87,
	Bottomless_Bag = 88,
	Curse_of_the_Snakes_Eyes = 89,
	Sealing_Key = 90,
	Suspiciously_Shiny_Coin = 91,
	Soul_Tether = 92,
	Cursed_Glove = 93,
    First = 75,
    Last = 93,
};

enum card_instant {
	Challenge = 94,
	Druid_Challenge = 95,
	Warrior_Challenge = 96,
	Mod_p4 = 97,
	Mod_p3n1 = 98,
	Mod_p2n2 = 99,
	Mod_p1n3 = 100,
	Mod_n4 = 101,
	Mod_p1n1_S = 102,
	Mod_p4_S = 103,
	Mod_n4_S = 104,
	Mod_p2n1_S = 105,
    First = 94,
    Last = 105,
};

enum card_party_leader {
	The_Charismatic_Song = 106,
	The_Fist_of_Reason = 107,
	The_Protecting_Horn = 108,
	The_Divine_Arrow = 109,
	The_Shadow_Claw = 110,
	The_Cloaked_Sage = 111,
	The_Piercing_Howl = 112,
	The_Noble_Shaman = 113,
    First = 106,
    Last = 113,
};

enum card_monster {
	Dracos = 114,
	Arctic_Aries = 115,
	Terratuga = 116,
	Abyss_Queen = 117,
	Bloodwing = 118,
	Crowned_Serpent = 119,
	Dark_Dragon_King = 120,
	Titan_Wyvern = 121,
	Rex_Major = 122,
	Malamammoth = 123,
	Warworn_Owlbear = 124,
	Orthus = 125,
	Anuran_Cauldron = 126,
	Corrupted_Sabretooth = 127,
	Mega_Slime = 128,
	Muscipula_Rex = 129,
	Feral_Dragon = 130,
    First = 114,
    Last = 130,
};

public class HUD : CanvasLayer
{
    string[] card_names = {"NULL",
    "Napping Nibbles","Tipsy Tootie","Lucky Bucky","Peanut","Mellow Dee","Greedy Cheeks","Fuzzy Cheeks","Dodgy Dealer",
	"Tough Teddy","Heavy Bear","Fury Knuckle","Beary Wise","Bear Claw","Bad Axe","Pan Chucks","Qi Bear",
	"Holy Curselifter","Radiant Horn","Wise Shield","Guiding Light","Mighty Blade","Iron Resolve","Vibrant Glow","Calming Voice",
	"Lookie Rookie","Sharp Fox","Hook","Bullseye","Wildshot","Quick Draw","Serious Grey","Wily Red",
	"Slippery Paws","Sly Pickings","Plundering Puma","Smooth Mimimeow","Silent Shadow","Shurikitty","Kit Napper","Meowzio",
	"Bun Bun","Buttons","Snowball","Hopper","Spooky","Fluffy","Wiggles","Whiskers",
	"Looting Lupo","Wolfgang Pack","Silent Shield","Critical Fang","Agile Dagger","Blinding Blade","Tenacious Timber","Hardened Hunter",
	"Big Buckley","Stagguard","Doe Fallow","Maegisty","Glowing Antler","Majestelk","Buck Omens","Magus Moose",
	
    "Call to the Fallen","Critical Boost","Destructive Spell","Enchanted Spell","Entangling Trap","Forced Exchange","Forceful Winds","Winds of Change","Rapid Refresh","Beast Call",
	
    "Bard","Fighter","Guardian","Ranger","Thief","Wizard","Warrior","Druid",
	"Decoy Doll","Particularly Rusty Coin","Really Big Ring","Even Bigger Ring","Temporal Hourglass","Bottomless Bag",
	"Curse of the Snakes Eyes","Sealing Key","Suspiciously Shiny Coin","Soul Tether","Cursed Glove",
    
    "Challenge","Druid Challenge","Warrior Challenge",
	"Mod p4","Mod p3n1","Mod p2n2","Mod p1n3","Mod n4","Mod p1n1 S","Mod p4 S","Mod n4 S","Mod p2n1 S",
	
    "The Charismatic Song","The Fist of Reason","The Protecting Horn","The Divine Arrow","The Shadow Claw","The Cloaked Sage","The Piercing Howl","The Noble Shaman",
	
    "Dracos","Arctic Aries","Terratuga","Abyss Queen","Bloodwing","Crowned Serpent","Dark Dragon King","Titan Wyvern","Rex Major","Malamammoth","Warworn Owlbear","Orthus","Anuran Cauldron","Corrupted Sabretooth","Mega Slime","Muscipula Rex","Feral Dragon"
    };

    public Button hero = new Button();
    public Button item = new Button();
    public Button magic = new Button();
    public Button instant = new Button();
    public Button leader = new Button();
    public Button monster = new Button();
    public Button back_btn = new Button();

    public OptionButton hero_choice = new OptionButton();
    public OptionButton item_choice = new OptionButton();
    public OptionButton magic_choice = new OptionButton();
    public OptionButton instant_choice = new OptionButton();
    public OptionButton leader_choice = new OptionButton();
    public OptionButton monster_choice = new OptionButton();

    public RichTextLabel menu_text = new RichTextLabel();

    Vector2 tb_range_1 = new Vector2(0.2f, 0.3f);
    Vector2 tb_range_2 = new Vector2(0.4f, 0.5f);
    Vector2 tb_range_3 = new Vector2(0.6f, 0.7f);
    Vector2 tb_range_4 = new Vector2(0.8f, 0.9f);
    Vector2 lr_range_1 = new Vector2(0.1f, 0.3f);
    Vector2 lr_range_2 = new Vector2(0.4f, 0.6f);
    Vector2 lr_range_3 = new Vector2(0.7f, 0.9f);


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        FollowViewportEnable = true;

        hero_choice = addOptionButton(tb_range_3, lr_range_2, (int)card_hero.First, (int)card_hero.Last);
        item_choice = addOptionButton(tb_range_3, lr_range_2, (int)card_item.First, (int)card_item.Last);
        magic_choice = addOptionButton(tb_range_3, lr_range_2, (int)card_magic.First, (int)card_magic.Last);
        instant_choice = addOptionButton(tb_range_3, lr_range_2, (int)card_instant.First, (int)card_instant.Last);
        leader_choice = addOptionButton(tb_range_3, lr_range_2, (int)card_party_leader.First, (int)card_party_leader.Last);
        monster_choice = addOptionButton(tb_range_3, lr_range_2, (int)card_monster.First, (int)card_monster.Last);

        back_btn = addButton("Back...", tb_range_1, lr_range_1);

        hero = addButton("hero", tb_range_3, lr_range_1);
        item = addButton("item", tb_range_3, lr_range_2);
        magic = addButton("magic", tb_range_3, lr_range_3);
        instant = addButton("instant", tb_range_4, lr_range_1);
        leader = addButton("leader", tb_range_4, lr_range_2);
        monster = addButton("monster", tb_range_4, lr_range_3);

        menu_text = addText("Pick a card category", tb_range_2, lr_range_2);
    }

    public RichTextLabel addText(string text, Vector2 t_b, Vector2 l_r)
    {
        RichTextLabel txt = new RichTextLabel();
        txt.Text = text;
        txt.AnchorTop = t_b.x;
        txt.AnchorBottom = t_b.y;
        txt.AnchorLeft = l_r.x;
        txt.AnchorRight = l_r.y;
        AddChild(txt);

        return txt;
    }

    public Button addButton(string text, Vector2 t_b, Vector2 l_r)
    {
        Button btn = new Button();
        btn.Text = text;
        btn.AnchorTop = t_b.x;
        btn.AnchorBottom = t_b.y;
        btn.AnchorLeft = l_r.x;
        btn.AnchorRight = l_r.y;
        AddChild(btn);

        return btn;
    }

    public OptionButton addOptionButton(Vector2 t_b, Vector2 l_r, int first_id, int last_id)
    {
        OptionButton o_btn = new OptionButton();
        o_btn.AnchorTop = t_b.x;
        o_btn.AnchorBottom = t_b.y;
        o_btn.AnchorLeft = l_r.x;
        o_btn.AnchorRight = l_r.y;

        for (int id = first_id; id <= last_id; id++) {o_btn.AddItem(card_names[id], id);}
        AddChild(o_btn);

        return o_btn;
    }

    public void menuHide()
    {
        hero.Hide();
        item.Hide();
        magic.Hide();
        instant.Hide();
        leader.Hide();
        monster.Hide();
        menu_text.Hide();
        back_btn.Show();
        return;
    }

    public void menuShow()
    {
        hero.Show();
        item.Show();
        magic.Show();
        instant.Show();
        leader.Show();
        monster.Show();
        menu_text.Show();
        
        back_btn.Hide();

        hero_choice.Hide();
        item_choice.Hide();
        magic_choice.Hide();
        instant_choice.Hide();
        leader_choice.Hide();
        monster_choice.Hide();

        return;
    }

    public int buttonProcess(float delta)
    {
        int response_value = 0;

        if (hero.Pressed == true)       {hero_choice.Show();    response_value = (int)buttons.Hero;}
        if (item.Pressed == true)       {item_choice.Show();    response_value = (int)buttons.Item;}
        if (magic.Pressed == true)      {magic_choice.Show();   response_value = (int)buttons.Magic;}
        if (instant.Pressed == true)    {instant_choice.Show(); response_value = (int)buttons.Instant;}
        if (leader.Pressed == true)     {leader_choice.Show();  response_value = (int)buttons.Leader;}
        if (monster.Pressed == true)    {monster_choice.Show(); response_value = (int)buttons.Monster;}
        
        if (back_btn.Pressed == true)
        {
            menuShow();
            response_value = (int)buttons.Back;
        }

        return response_value;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }
}