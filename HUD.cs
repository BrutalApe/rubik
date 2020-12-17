using Godot;
using System;

public class HUD : CanvasLayer
{
    public Button b2 = new Button();
    public Button b3 = new Button();
    public Button b4 = new Button();
    public Button back_btn = new Button();

    Vector2 top_bottom_range_1 = new Vector2(0.2f, 0.3f);
    Vector2 top_bottom_range_2 = new Vector2(0.4f, 0.5f);
    Vector2 top_bottom_range_3 = new Vector2(0.6f, 0.7f);
    Vector2 top_bottom_range_4 = new Vector2(0.8f, 0.9f);
    Vector2 left_right_range_1 = new Vector2(0.1f, 0.3f);
    Vector2 left_right_range_2 = new Vector2(0.4f, 0.6f);
    Vector2 left_right_range_3 = new Vector2(0.7f, 0.9f);


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        FollowViewportEnable = true;

        b2 = addButton("2", top_bottom_range_4, left_right_range_1);
        b3 = addButton("3", top_bottom_range_4, left_right_range_2);
        b4 = addButton("4", top_bottom_range_4, left_right_range_3);
        back_btn = addButton("Back", top_bottom_range_1, left_right_range_1);
        back_btn.Hide();
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

    public void backToMenu()
    {
        b2.Show();
        b3.Show();
        b4.Show();
        back_btn.Hide();
    }

    public void sizeSelected()
    {
        b2.Hide();
        b3.Hide();
        b4.Hide();
        back_btn.Show();

        return;
    }

    public int buttonProcess(float delta)
    {
        int response_value = 0;

        if (b2.Pressed == true)
        {     
            sizeSelected();
            response_value = 2;        
            //addButton("two", top_bottom_range_1, left_right_range_2);
        }

        if (b3.Pressed == true)
        {
            sizeSelected();
            response_value = 3;
            //addButton("three", top_bottom_range_1, left_right_range_2);
        }

        if (b4.Pressed == true)
        {
            sizeSelected();
            response_value = 4;        
            //addButton("four", top_bottom_range_1, left_right_range_2);
        }

        if (back_btn.Pressed == true)
        {
            backToMenu();
            response_value = 10;
        }

        return response_value;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }
}