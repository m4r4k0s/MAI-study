package laba2

  model func4
    Real x(start = 5);
    Real v(start = 1);
    Real F;
    parameter Real K = 6;
    parameter Real k2 = 3;
    parameter Real k3 = 4;
    parameter Real k4 = 5;
    parameter Real a = 2;
    parameter Real b = 3;
    parameter Real d = 5;
  
  equation
    if x < (-d) then
      F = -K;
    elseif x < (-a) then
      F = (K - b) / (d - a) * (x + a) - b;
    elseif x < a then
      F = 0;
    elseif x < d then
      F = (K - b) / (d - a) * (x - a) + b;
    else
      F = K;
    end if;
    der(x) = v;
    der(v) = (-F) - k2 * x + k3 * sin(k4 * time);
    
  end func4;
  annotation(
    uses(Modelica(version = "3.2")));
end laba2;
