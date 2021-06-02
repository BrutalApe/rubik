using Godot;
using System;

public class HUD : CanvasLayer
{
    public Button b2 = new Button();
    public Button b3 = new Button();
    public Button b4 = new Button();
    public Button b5 = new Button();
    public Button b6 = new Button();
    public Button b7 = new Button();

    public Button turn_c_btn = new Button();
    public Button turn_cc_btn = new Button();
    public Button up_axis_btn = new Button();
    public Button down_axis_btn = new Button();

    public Button x_axis_btn = new Button();
    public Button y_axis_btn = new Button();
    public Button z_axis_btn = new Button();
    public Button back_btn = new Button();

    public Button reset_cube_btn = new Button();

    public RichTextLabel menu_text = new RichTextLabel();

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

        b2 = addButton("2", top_bottom_range_3, left_right_range_1);
        b3 = addButton("3", top_bottom_range_3, left_right_range_2);
        b4 = addButton("4", top_bottom_range_3, left_right_range_3);
        b5 = addButton("5", top_bottom_range_4, left_right_range_1);
        b6 = addButton("6", top_bottom_range_4, left_right_range_2);
        b7 = addButton("7", top_bottom_range_4, left_right_range_3); 

        up_axis_btn = addButton("Move up axis", top_bottom_range_2, left_right_range_1);
        down_axis_btn = addButton("Move down axis", top_bottom_range_3, left_right_range_1);

        turn_c_btn = addButton("Turn clockwise", top_bottom_range_2, left_right_range_3);
        turn_cc_btn = addButton("Turn counter-clockwise", top_bottom_range_3, left_right_range_3);

        x_axis_btn = addButton("X-Axis", top_bottom_range_4, left_right_range_1);
        y_axis_btn = addButton("Y-Axis", top_bottom_range_4, left_right_range_2);
        z_axis_btn = addButton("Z-Axis", top_bottom_range_4, left_right_range_3);
        back_btn = addButton("Back", top_bottom_range_1, left_right_range_1);

        reset_cube_btn = addButton("Reset Cube", top_bottom_range_1, left_right_range_3);

        menu_text = addText("Pick a Cube size", top_bottom_range_2, left_right_range_2);
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

    public void cubeHide()
    {
        turn_c_btn.Hide();
        turn_cc_btn.Hide();
        up_axis_btn.Hide();
        down_axis_btn.Hide();
        x_axis_btn.Hide();
        y_axis_btn.Hide();
        z_axis_btn.Hide();
        back_btn.Hide();
        reset_cube_btn.Hide();
        return;
    }

    public void cubeShow()
    {
        turn_c_btn.Show();
        turn_cc_btn.Show();
        up_axis_btn.Show();
        down_axis_btn.Show();
        x_axis_btn.Show();
        y_axis_btn.Show();
        z_axis_btn.Show();
        back_btn.Show();
        reset_cube_btn.Show();
        return;
    }

    public void menuHide()
    {
        b2.Hide();
        b3.Hide();
        b4.Hide();
        b5.Hide();
        b6.Hide();
        b7.Hide();
        menu_text.Hide();
        return;
    }

    public void menuShow()
    {
        b2.Show();
        b3.Show();
        b4.Show();
        b5.Show();
        b6.Show();
        b7.Show();
        menu_text.Show();
        return;
    }

    public void menuView()
    {
        cubeHide();
        menuShow();
        return;
    }

    public void cubeView()
    {
        menuHide();
        cubeShow();
        return;
    }

    public int buttonProcess(float delta)
    {
        int response_value = 0;

        if (b2.Pressed == true)
        {     
            cubeView();
            response_value = 2;  
        }

        if (b3.Pressed == true)
        {
            cubeView();
            response_value = 3;
        }

        if (b4.Pressed == true)
        {
            cubeView();
            response_value = 4; 
        }

        if (b5.Pressed == true)
        {
            cubeView();
            response_value = 5;        
        }

        if (b6.Pressed == true)
        {
            cubeView();
            response_value = 6;        
        }

        if (b7.Pressed == true)
        {
            cubeView();
            response_value = 7;        
        }

        if (x_axis_btn.Pressed == true)
        {
            response_value = 0x100;
            cubeHide();
        }

        if (y_axis_btn.Pressed == true)
        {
            response_value = 0x101;
            cubeHide();
        }

        if (z_axis_btn.Pressed == true)
        {
            response_value = 0x102;
            cubeHide();
        }

        if (up_axis_btn.Pressed == true)
        {
            response_value = 0x103;
            cubeHide();
        }

        if (down_axis_btn.Pressed == true)
        {
            response_value = 0x104;
            cubeHide();
        }

        if (reset_cube_btn.Pressed == true)
        {
            response_value = 0x105;
        }

        if (turn_c_btn.Pressed == true)
        {
            response_value = 0x200;
            cubeHide();
        }

        if (turn_cc_btn.Pressed == true)
        {
            response_value = 0x201;
            cubeHide();
        }

        if (back_btn.Pressed == true)
        {
            menuView();
            response_value = 10;
        }

        return response_value;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }
}