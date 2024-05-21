using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotFrame
{
    public Robot robot { get; set; }
    public Image riquadro { get; set; }

    public RobotFrame(Robot robot, Image riquadro)
    {
        this.robot = robot;
        this.riquadro = riquadro;
    }


}