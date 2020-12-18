using Godot;
using System;

public class Cube : Spatial
{
    //[Export]
    PackedScene new_piece;

    Godot.Collections.Array piece_list = new Godot.Collections.Array();
    
    public float space_constant = 0;

    Vector3 x_axis = new Vector3(1, 0, 0);
    Vector3 y_axis = new Vector3(0, 1, 0);
    Vector3 z_axis = new Vector3(0, 0, 1);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    public void makeCube(int size, float spacing_constant)
    {
        space_constant = spacing_constant;

        for (var i = 1; i<=size; i++)
        {
            for (var j = 1; j<=size; j++)
            {
                for (var k = 1; k<=size; k++)
                {
                    new_piece = (PackedScene)ResourceLoader.Load("res://Piece.tscn");
                    Area piece = (Area)new_piece.Instance();
                    piece.Call("addPiece", size, i, j, k);

                    Vector3 new_loc = new Vector3(i, j, k);
                    Vector3 new_rot = new Vector3(0, 0, 0);
                    
                    piece.Call("setOriginalLocVal", new_loc);
                    piece.Call("setLocVal", new_loc);
                    piece.Call("setOriginalRotVal", new_rot);
                    piece.Call("setRotVal", new_rot);
                    
                    AddChild(piece);
//piece.Hide();
                    //test_loc = (Godot.Vector3)piece.Call("GetLocVal");

                    //GD.Print(test_loc);

                    // if even, use different translation to move to center
                    if (size%2==0)
                    {
                        new_loc.x = space_constant*(i-(size/2)-.5f);
                        new_loc.y = space_constant*(j-(size/2)-1f);
                        new_loc.z = space_constant*(k-(size/2)-.5f);
                    }
                    else
                    {   
                        new_loc.x = space_constant*(i-(size/2)-1);
                        new_loc.y = space_constant*(j-(size/2)-1.5f);
                        new_loc.z = space_constant*(k-(size/2)-1);
                    }
                    piece.Translate(new_loc);


                    // Vector3 box_vec = new Vector3(1, 1, 1);
                    // BoxShape box_shape = new BoxShape();
                    // box_shape.Extents = box_vec;

                    // var collision = new CollisionShape();
                    // collision.Shape = box_shape;
                    
                    // // give piece the collision shape
                    // piece.AddChild(collision);

                }
            }
        }

        // add all children to piece_list
        piece_list = GetChildren();
    }

    // These three functions would be used for direct manipulation
    // of the pieces; hopefully, can use another method.
    // public void translatePiece(Area piece, Vector3 new_loc)
    // {
    //     piece.Translate(new_loc);
    //     piece.Call("setLocVal", new_loc);
    //     return;
    // }

    // public void rotatePiece(Area piece, Vector3 new_rot)
    // {
    //     piece.RotationDegrees = new_rot;
    //     piece.Call("setRotVal", new_rot);
    //     return;
    // }

    // public void movePiece(Area piece, Vector3 new_loc, Vector3 new_rot)
    // {
    //     translatePiece(piece, new_loc);
    //     rotatePiece(piece, new_rot);
    //     return;
    // }

    // https://godotengine.org/qa/45609/how-do-you-rotate-spatial-node-around-axis-given-point-space
    public void rotateAround(Area obj, Vector3 point, Vector3 axis, float angle)
    {
        float rot = 0;

        if      (axis == x_axis){rot = angle + obj.Rotation.x;}
        else if (axis == y_axis){rot = angle + obj.Rotation.y;}
        else if (axis == z_axis){rot = angle + obj.Rotation.z;}
        else    {return;}

        var tStart = point;
        obj.GlobalTranslate (-tStart);
        obj.Transform = obj.Transform.Rotated(axis, -rot);
        obj.GlobalTranslate (tStart);

        return;
    }

    public Spatial makeOutline(int size, Vector3 side_select)
    {
        Spatial outline = new Spatial();
        AddChild(outline);

        Area box = new Area();
        outline.AddChild(box);

        Godot.Collections.Array edge_list = new Godot.Collections.Array();
        Godot.Collections.Array pos_list = new Godot.Collections.Array();

        float side_num = 0;
        Vector3 ss_normal = side_select.Normalized();
        Vector3 ss_normal_x = new Vector3(1, 0, 0);
        Vector3 ss_normal_y = new Vector3(0, 1, 0);
        Vector3 ss_normal_z = new Vector3(0, 0, 1);

        Vector3 ss_normal_1 = new Vector3(0, 0, 0);
        Vector3 ss_normal_2 = new Vector3(0, 0, 0);

        // need more comprehensive error checking
        if      (ss_normal.x == 1){side_num = side_select.x; ss_normal_1 = ss_normal_y; ss_normal_2 = ss_normal_z;}
        else if (ss_normal.y == 1){side_num = side_select.y; ss_normal_1 = ss_normal_x; ss_normal_2 = ss_normal_z;}
        else if (ss_normal.z == 1){side_num = side_select.z; ss_normal_1 = ss_normal_x; ss_normal_2 = ss_normal_y;}
        else {GD.Print("ERROR, side select makeOutline");return outline;}

        Vector3 scale_add = new Vector3(0.1f, 0.1f, 0.1f);

        // 12 edges to a rectangular prism, so can make 8 of them 
        // size-long, the other 4 are 1 unit long
        Vector3 scale_long = (ss_normal * size) + scale_add;
        Vector3 scale_short = ss_normal + scale_add;

        Vector3 rotation_long_1 = ss_normal_1*90f;
        Vector3 rotation_long_2 = ss_normal_2*90f;
        Vector3 rotation_short = ss_normal*90f;

        // limit of axis position is side_num +- 2.3/2
        // other two axes are 
        Vector3 base_pos = ss_normal*(0-side_num);

        Vector3 position_short_1 = base_pos;
        Vector3 position_short_2 = base_pos;
        Vector3 position_short_3 = base_pos;
        Vector3 position_short_4 = base_pos;

        Vector3 position_long_1_1 = base_pos;
        Vector3 position_long_1_2 = base_pos;
        Vector3 position_long_1_3 = base_pos;
        Vector3 position_long_1_4 = base_pos;

        Vector3 position_long_2_1 = base_pos;
        Vector3 position_long_2_2 = base_pos;
        Vector3 position_long_2_3 = base_pos;
        Vector3 position_long_2_4 = base_pos;

        pos_list.Add(position_short_1);
        pos_list.Add(position_short_2);
        pos_list.Add(position_short_3);
        pos_list.Add(position_short_4);
        pos_list.Add(position_long_1_1);
        pos_list.Add(position_long_1_2);
        pos_list.Add(position_long_1_3);
        pos_list.Add(position_long_1_4);
        pos_list.Add(position_long_2_1);
        pos_list.Add(position_long_2_2);
        pos_list.Add(position_long_2_3);
        pos_list.Add(position_long_2_4);

        // aligned with axis

        for (int i = 0; i < 12; i++)
        {
            MeshInstance edge = new MeshInstance();
            edge.Mesh = new CubeMesh{};
            box.AddChild(edge);
            
            edge.Translate((Vector3)pos_list[i]);

            if (i >= 0 && i < 4)
            {
                edge.Scale = scale_short;
                edge.RotationDegrees = rotation_short;
            }

            else if (i >= 4 && i < 8)
            {
                edge.Scale = scale_long;
                edge.RotationDegrees = rotation_long_2;
            }

            else if (i >= 8 && i < 12)
            {
                edge.Scale = scale_long;
                edge.RotationDegrees = rotation_long_1;
            }

            edge_list.Add(edge);
        }

        return outline;
    }

    public void spinSide(int size, Vector3 side_select, int direction, int times)
    {
        var side = 0;
        float side_num = 0;
        Godot.Collections.Array spin_piece_list = new Godot.Collections.Array();
        Vector3 temp_piece_coord = new Vector3(0, 0, 0);

        // axis of rotation for side
        Vector3 axis = new Vector3(0, 0, 0);

        const int x_side = 1;
        const int y_side = 2;
        const int z_side = 3;

        // need more comprehensive error checking
        if      (side_select.x != 0){side = x_side; side_num = side_select.x; axis = x_axis;}
        else if (side_select.y != 0){side = y_side; side_num = side_select.y; axis = y_axis;}
        else if (side_select.z != 0){side = z_side; side_num = side_select.z; axis = z_axis;}
        else {return;}

        // GD.Print("Children List (spinSide)");
        // GD.Print(piece_list);
        
        // first, get list of pieces to be moved
        foreach (Area piece in piece_list)
        {
            // get coordinates of current piece
            temp_piece_coord = (Vector3)piece.Call("getLocVal");
            
            switch (side)
            {
                case x_side:
                    if (temp_piece_coord.x == side_num)
                    {
                        spin_piece_list.Add(piece);
                    }
                    break;

                case y_side:
                    if (temp_piece_coord.y == side_num)
                    {
                        spin_piece_list.Add(piece);
                    }
                    break;

                case z_side:
                    if (temp_piece_coord.z == side_num)
                    {
                        spin_piece_list.Add(piece);
                    }
                    break;

                default:
                    break;

            }
        }

        GD.Print(spin_piece_list);
        
        // rotation point always center of cube
        float cent_pnt = space_constant*(size-1);
        Vector3 point = new Vector3(0, 0, 0);
        
        float angle = (float)Math.PI;

        foreach (Area piece in spin_piece_list)
        {
            rotateAround(piece, point, axis, angle);
        }

        // move each piece to location indicated by dir/side


        return;
    }

    // public override void _Process(float delta)
    // {
    // }
}

// These vectors will be decided by 'side' value

// new_side_select = (PackedScene)ResourceLoader.Load("res://SideSelect.tscn");
// Area side_select = (Area)new_side_select.Instance();
// side_select.Call("createBoundingBox", start_coord, end_coord);
// AddChild(side_select);

// Godot.Collections.Array pieces = side_select.GetOverlappingAreas();

// GD.Print(pieces);

// at end, remove side selector
//RemoveChild(side_select);   
