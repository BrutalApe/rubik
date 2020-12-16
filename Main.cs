using Godot;
using System;

public class Main : Node
{

    PackedScene new_cube;

    private Camera cameraMain;
    private Spatial cube;

    public float spacing_constant = 0;
    public int cube_size = 0;

    Vector3 x_axis = new Vector3(1, 0, 0);
    Vector3 y_axis = new Vector3(0, 1, 0);
    Vector3 z_axis = new Vector3(0, 0, 1);

    public void drawAxes()
    {

    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Input.SetMouseMode(Input.MouseMode.Captured);

        // initializiation
        cube_size = 4;
        spacing_constant = 2.3f;

        cube = addCube(cube_size);        
        cameraMain = addCamera(cube_size);

        // functions
        
        Vector3 edge_select = new Vector3(0, 0, 1);

        //twistCube(cube, cube_size, edge_select, 1, 1);
    }

    public Camera addCamera(int cube_size)
    {
        Camera camera = new Camera{};
        AddChild(camera);

        camera.Current = true;

        Vector3 new_loc = new Vector3();
        Vector3 new_rot = new Vector3();

        // all values should change for translation depending on size
        new_loc.x = -10;
        new_loc.y = ((cube_size+2) * 1.5f);
        new_loc.z = -10;
        new_rot.x = -30f;
        new_rot.y = -135f;
        new_rot.z = 0f;

        camera.Translate(new_loc);
        camera.RotationDegrees = new_rot;

        return camera;
    }

    public Spatial addCube(int cube_size)
    {
        new_cube = (PackedScene)ResourceLoader.Load("res://Cube.tscn");
        Spatial cube = (Spatial)new_cube.Instance();
        cube.Call("makeCube", cube_size, spacing_constant);
        AddChild(cube);

        return cube;
    }

    public void twistCube(Spatial cube, int size, Vector3 side_select, int direction, int times)
    {
        cube.Call("spinSide", size, side_select, direction, times);
    }

    public void rotateAround(Spatial obj, Vector3 angle)
    {
        Vector3 new_rot = new Vector3(0,0,0);

        new_rot = (angle)/(float)Math.PI/10 + obj.Rotation;

        obj.Rotation = new_rot;

        return;
    }

    public void rotateCamera(Vector3 rotation)
    {
        rotateAround(cube, rotation);
        return;
    }

    Vector3 zero_rot = new Vector3(0,0,0);
    Vector3 rot = new Vector3(0,0,0);

    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent is InputEventKey keyEvent && keyEvent.Pressed)
        {
            if ((KeyList)keyEvent.Scancode == KeyList.W)
            {
                rot.x = 1;
                //rotateCamera_x(1);
            }
            if ((KeyList)keyEvent.Scancode == KeyList.S)
            {
                rot.x = -1;
                //rotateCamera_x(-1);
            }
            
            if ((KeyList)keyEvent.Scancode == KeyList.A)
            {
                rot.y = 1;
                //rotateCamera_y(1);
            }
            if ((KeyList)keyEvent.Scancode == KeyList.D)
            {
                rot.y = -1;
                //rotateCamera_y(-1);
            }
            
            if ((KeyList)keyEvent.Scancode == KeyList.E)
            {
                rot.z = 1;
                //rotateCamera_z(1);
            }
            if ((KeyList)keyEvent.Scancode == KeyList.Q)
            {
                rot.z = -1;
                //rotateCamera_z(-1);
            }

            rotateCamera(rot);
            
            // reset rotation
            rot = zero_rot;

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
        ProcessInput(delta);
    }
}
