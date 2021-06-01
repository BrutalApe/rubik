using Godot;
using System;

public class Main : Node
{
    PackedScene new_hud;
    private CanvasLayer HUD;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        HUD = addHUD();

        // functions
    }

    public CanvasLayer addHUD()
    {
        new_hud = (PackedScene)ResourceLoader.Load("res://HUD.tscn");
        CanvasLayer hud = (CanvasLayer)new_hud.Instance();
        AddChild(hud);

        hud.Call("menuShow");

        return hud;
    }

    public override void _Input(InputEvent inputEvent)
    {

        if (inputEvent is InputEventKey keyEvent && keyEvent.Pressed)
        {
            if ((KeyList)keyEvent.Scancode == KeyList.W)
            {
                // camera_rot.x = rotation_increment;
                // rot_axis = x_axis;
            }
        }

        return;
    }  

    private void ProcessInput(float delta)
    {
        //     if (Input.IsActionJustPressed("ui_cancel"))
        // {
        //     if (Input.GetMouseMode() == Input.MouseMode.Visible)
        //         Input.SetMouseMode(Input.MouseMode.Captured);
        //     else
        //         Input.SetMouseMode(Input.MouseMode.Visible);
        // }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        int result = 0;

        result = (int)HUD.Call("buttonProcess", delta);

        if (result == 0)
        {return;}
        GD.Print(result);
        
        if ((result >= (int)buttons.Hero) && (result <= (int)buttons.Monster))
        {
            HUD.Call("menuHide");

            return;
        }

        if (result == (int)buttons.Back)
        {
            
            return;
        }

        return;
        
    }
}
