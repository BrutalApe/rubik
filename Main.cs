using Godot;
using System;

public class Main : Node
{

    PackedScene new_cube;
    PackedScene new_hud;

    private Camera cameraMain;
    private Spatial cube;
    private CanvasLayer HUD;


    public float spacing_constant = 0;
    public int cube_size = 0;

    Vector3 x_axis = new Vector3(1, 0, 0);
    Vector3 y_axis = new Vector3(0, 1, 0);
    Vector3 z_axis = new Vector3(0, 0, 1);

    Vector3 edge_select = new Vector3(0, 0, 0);

    Vector3 camera_rot = new Vector3(0,0,0);
    // amount to spin camera by
    float rotation_increment = (float)Math.PI/20f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

        //addBackdrop();

        //Input.SetMouseMode(Input.MouseMode.Captured);

        // initializiation
        spacing_constant = 2f;

        //cube = addCube(cube_size);        
        cameraMain = addCamera();
        moveCamera(cameraMain, cube_size);

        HUD = addHUD();

        // functions
        
        Vector3 edge_select = new Vector3(0, 0, 1);

        //twistCube(cube, cube_size, edge_select, 1, 1);
    }

    // public void addBackdrop()
    // {
    //     MeshInstance backdrop = new MeshInstance();
    //     backdrop.Mesh = new PlaneMesh{};
            
    //     var material = new SpatialMaterial{};
    //     // default color is black for plane
    //     Color color_black = new Color(0,0,0);

    //     material.AlbedoColor = color_black;
    //     backdrop.SetSurfaceMaterial(0, material);

    //     Vector3 scale = new Vector3(80, 0, 80);
    //     Vector3 position = new Vector3(-1f, 0, -1f);
    //     Vector3 rotation = new Vector3(30, 180-45, 30);

    //     backdrop.Scale = scale;
    //     backdrop.Translate(position);
    //     backdrop.RotationDegrees = rotation;

    //     AddChild(backdrop);
    //     return;
    // }  

    public CanvasLayer addHUD()
    {
        new_hud = (PackedScene)ResourceLoader.Load("res://HUD.tscn");
        CanvasLayer hud = (CanvasLayer)new_hud.Instance();
        AddChild(hud);

        hud.Call("menuView");

        return hud;
    }

    // https://godotengine.org/qa/45609/how-do-you-rotate-spatial-node-around-axis-given-point-space
    public void rotateCamera(Camera camera, Vector3 point, Vector3 axis, float angle)
    {
        float rot = 0;

        if      (axis == x_axis){rot = angle + camera.Rotation.x;}
        else if (axis == y_axis){rot = angle + camera.Rotation.y;}
        else if (axis == z_axis){rot = angle + camera.Rotation.z;}
        else    {return;}

        GD.Print(angle);

        var tStart = point;
        camera.GlobalTranslate (-tStart);
        camera.Transform = camera.Transform.Rotated(axis, -rot);
        camera.GlobalTranslate (tStart);

        return;
    }

    public void moveCamera(Camera camera, int size)
    {
        Vector3 new_loc = new Vector3();
        Vector3 new_rot = new Vector3();

        // all values should change for translation depending on size
        new_loc.x = 10;
        new_loc.y = (5 * 1.5f);
        new_loc.z = 10;
        new_rot.x = -30f;
        new_rot.y = 180-135f;
        new_rot.z = 0f;

        camera_rot = new_rot;

        camera.Translate(new_loc);
        camera.RotationDegrees = camera_rot;

        return;
    }

    public Camera addCamera()
    {
        Camera camera = new Camera{};
        AddChild(camera);
        camera.Current = true;
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

    public void changeView(Vector3 rotation, Vector3 axis) 
    {
        if (cube_size == 0)
        {
            return;
        }
        Vector3 center_point = new Vector3(0, 0, 0);

        rotateCamera(cameraMain, center_point, axis, rotation.Dot(axis));
        return;
    }

    Vector3 zero_rot = new Vector3(0,0,0);
    Vector3 rot_axis = new Vector3(0,0,0);

    public override void _Input(InputEvent inputEvent)
    {

        if (inputEvent is InputEventKey keyEvent && keyEvent.Pressed)
        {
            if ((KeyList)keyEvent.Scancode == KeyList.W)
            {
                camera_rot.x += rotation_increment;
                rot_axis = x_axis;
            }
            if ((KeyList)keyEvent.Scancode == KeyList.S)
            {
                camera_rot.x -= rotation_increment;
                rot_axis = x_axis;
            }
            
            if ((KeyList)keyEvent.Scancode == KeyList.A)
            {
                camera_rot.y += rotation_increment;
                rot_axis = y_axis;
            }
            if ((KeyList)keyEvent.Scancode == KeyList.D)
            {
                camera_rot.y -= rotation_increment;
                rot_axis = y_axis;
            }
            
            if ((KeyList)keyEvent.Scancode == KeyList.E)
            {
                camera_rot.z += rotation_increment;
                rot_axis = z_axis;
            }
            if ((KeyList)keyEvent.Scancode == KeyList.Q)
            {
                camera_rot.z -= rotation_increment;
                rot_axis = z_axis;
            }

            changeView(camera_rot, rot_axis);
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

        if ((result >= 2) && (result <= 7))
        {
            cube_size = result;
            cube = addCube(cube_size);
            //cube.Call("makeAxisLines", cube_size);
            return;
        }

        if (result == 10)
        {
            cube_size = 0;
            edge_select = new Vector3(0, 0, 0);
            //cube.Call("removeAxisLines");
            RemoveChild(cube);
            return;
        }
        
        if ((result >= 0x100) && (result <= 0x104))
        {
            cube.Call("removeOutline");
            
            if (result == 0x100){edge_select = new Vector3(1, 0, 0);}
            if (result == 0x101){edge_select = new Vector3(0, 1, 0);}
            if (result == 0x102){edge_select = new Vector3(0, 0, 1);}

            if ((result == 0x103) && (edge_select.Length() < cube_size))
            {
                edge_select = edge_select + edge_select.Normalized();
            }
            if ((result == 0x104) && (edge_select.Length() > 1))
            {
                edge_select = edge_select - edge_select.Normalized();
            }
            
            cube.Call("makeOutline", cube_size, edge_select);

            HUD.Call("cubeShow");

            return;
        }

        if ((result >= 0x200) && (result <= 0x201))
        {
            if (result == 0x200){twistCube(cube, cube_size, edge_select, -1, 1);}
            if (result == 0x201){twistCube(cube, cube_size, edge_select, 1, 1);}
            HUD.Call("cubeShow");
        }

        //twistCube(cube, cube_size, edge_select, 1, 1);
        return;
        
    }
}
