﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate : IEquatable<Coordinate>
{
    public int x;
    public int y;
    public int tileValue;

    public Coordinate(int x, int y, int v)
    {
        this.x = x;
        this.y = y;
        tileValue = v;
    }
    public Coordinate ApplyMovement(Dir d)
    {
        return ApplyMovement(d, tileValue);
    }
    public Coordinate ApplyMovement(Dir d, int v)
    {
        switch (d)
        {
            case Dir.Up:    return new Coordinate(x    , y - 1, v);
            case Dir.Right: return new Coordinate(x + 1, y,     v);
            case Dir.Down:  return new Coordinate(x    , y + 1, v);
            case Dir.Left:  return new Coordinate(x - 1, y,     v);
        }
        throw new ArgumentOutOfRangeException("d");
    }
    public Coordinate ApplyMovements(IEnumerable<Dir> dirs)
    {
        Coordinate c = this.Copy();
        foreach (Dir d in dirs)
            c = c.ApplyMovement(d);
        return c;
    }

    public Coordinate Copy()
    {
        return new Coordinate(x, y, tileValue);
    }


    public override string ToString()
    {
        return string.Format("({0},{1} with value {2})", x, y, tileValue);
    }
    public override bool Equals(object obj)
    {
        return obj is Coordinate && Equals(obj as Coordinate);
    }
    public override int GetHashCode()
    {
        return x.GetHashCode() ^ y.GetHashCode();
    }
    public bool Equals(Coordinate other)
    {
        return x == other.x && y == other.y;
    }
}
