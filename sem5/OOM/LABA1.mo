package LABA1_0
  model testmodel
    parameter Integer n = 10;
    parameter Integer a = 2;
    parameter Integer b = 2;
    Real x[n];
    Real y[n];
  initial equation
    for i in 1:n loop
      x[i] = i + 5;
      y[i] = i + 7;
    end for;
  equation
    for i in 1:n loop
      y[i] = der(x[i]);
      der(y[i]) = -2*a*y[i] - b*sin(x[i]);
    end for;
  end testmodel;

  model laba1_2
  import Modelica.SIunits;
  Modelica.SIunits.Angle phi(start = 0.25);
  Modelica.SIunits.AngularVelocity omega(start = 1.0);
  parameter Modelica.SIunits.Acceleration g = 9.8;
  parameter Modelica.SIunits.Mass m = 50.0;
  parameter Modelica.SIunits.Length l = 3.0;
  
  parameter Modelica.Mechanics.MultiBody.Frames.Orientation O1=Modelica.Mechanics.MultiBody.Frames.axesRotations({1, 2, 3}, {0, 0, 0}, {0, 0, 0});
  Modelica.Mechanics.MultiBody.Visualizers.Advanced.Shape OA(shapeType = "cylinder", length = l, width = 0.125,height = 0.125, lengthDirection = {cos(phi), sin(phi), 0}, widthDirection = {0, 0, 1}, color = {255, 99, 71}, 
  specularCoefficient = 0.1, r = {0, 0, 0}, R = O1, r_shape = {0, 0, 0});
  Modelica.Mechanics.MultiBody.Visualizers.Advanced.Shape O(shapeType = "sphere", height = 1, length = 1, width = 1, r={cos(phi)*(l), sin(phi)*(l), 0},color = {0, 0, 255}, lengthDirection = {cos(phi), sin(phi), 0});
  equation
    der(phi) = omega;
    m*l*l*der(omega) = -m*g*l*sin(phi);
    
  end laba1_2;
end LABA1_0;
