package laba3
  model my_resist
    parameter Modelica.SIunits.Resistance R(start = 1) "Resistance at temperature T_ref";
    parameter Modelica.SIunits.Temperature T_ref = 300.15 "Reference temperature";
    parameter Real alpha = 0;
    parameter Real imax = 3;
    parameter Real A = 2;
    parameter Modelica.SIunits.Current Io = 1;
    extends Modelica.Electrical.Analog.Interfaces.OnePort;
    extends Modelica.Electrical.Analog.Interfaces.ConditionalHeatPort(T = T_ref);
    Modelica.SIunits.Resistance R_actual;
  equation
    assert(1 + alpha * (T_heatPort - T_ref) >= Modelica.Constants.eps, "Temperature outside scope of model!");
    if abs(i) <= imax then
      R_actual = A * i * i * i;
    elseif i > imax then
      R_actual = A * imax * imax * imax;
    else
      R_actual = -A * imax * imax * imax;
    end if;
    v = R_actual * i;
    LossPower = v * i;
    annotation(
      Documentation(info = "<html>
<p>The linear resistor connects the branch voltage <i>v</i> with the branch current <i>i</i> by <i>i*R = v</i>. The Resistance <i>R</i> is allowed to be positive, zero, or negative.</p>
</html>", revisions = "<html>
<ul>
<li><i> August 07, 2009   </i>
       by Anton Haumer<br> temperature dependency of resistance added<br>
       </li>
<li><i> March 11, 2009   </i>
       by Christoph Clauss<br> conditional heat port added<br>
       </li>
<li><i> 1998   </i>
       by Christoph Clauss<br> initially implemented<br>
       </li>
</ul>
</html>"),
      Icon(coordinateSystem(preserveAspectRatio = true, extent = {{-100, -100}, {100, 100}}, grid = {2, 2}), graphics = {Rectangle(extent = {{-70, 30}, {70, -30}}, lineColor = {0, 0, 255}, fillColor = {255, 255, 255}, fillPattern = FillPattern.Solid), Line(points = {{-90, 0}, {-70, 0}}, color = {0, 0, 255}), Line(points = {{70, 0}, {90, 0}}, color = {0, 0, 255}), Text(extent = {{-144, -40}, {142, -72}}, lineColor = {0, 0, 0}, textString = "R=%R"), Line(visible = useHeatPort, points = {{0, -100}, {0, -30}}, color = {127, 0, 0}, smooth = Smooth.None, pattern = LinePattern.Dot), Text(extent = {{-152, 87}, {148, 47}}, textString = "%name", lineColor = {0, 0, 255})}),
      Diagram(coordinateSystem(preserveAspectRatio = true, extent = {{-100, -100}, {100, 100}}, grid = {2, 2}), graphics = {Rectangle(extent = {{-70, 30}, {70, -30}}, lineColor = {0, 0, 255}), Line(points = {{-96, 0}, {-70, 0}}, color = {0, 0, 255}), Line(points = {{70, 0}, {96, 0}}, color = {0, 0, 255})}));
  end my_resist;

  model func4
    my_resist R3(R = 2351) annotation(
      Placement(transformation(extent = {{-10, -10}, {10, 10}}, rotation = 270, origin = {54, 8})));
    my_resist R0(R = 1000) annotation(
      Placement(transformation(extent = {{-60, 28}, {-40, 48}})));
    my_resist R2(R = 1200) annotation(
      Placement(transformation(extent = {{22, 12}, {42, 32}})));
    my_resist R1(R = 345) annotation(
      Placement(transformation(extent = {{22, 42}, {42, 62}})));
    Modelica.Electrical.Analog.Basic.Inductor L0(L = 43) annotation(
      Placement(transformation(extent = {{-26, 12}, {-6, 32}})));
    Modelica.Electrical.Analog.Basic.Capacitor C0(C = 0.0045) annotation(
      Placement(transformation(extent = {{-26, 42}, {-6, 62}})));
    Modelica.Electrical.Analog.Sources.SineVoltage sineVoltage(V = 230, freqHz = 50) annotation(
      Placement(transformation(extent = {{-10, -10}, {10, 10}}, rotation = -90, origin = {-72, 8})));
    Modelica.Electrical.Analog.Basic.Ground ground annotation(
      Placement(visible = true, transformation(extent = {{44, -28}, {64, -8}}, rotation = 0)));
  equation
    connect(sineVoltage.p, R0.p) annotation(
      Line(points = {{-72, 18}, {-72, 38}, {-60, 38}}, color = {0, 0, 255}, smooth = Smooth.None));
    connect(R0.n, C0.p) annotation(
      Line(points = {{-40, 38}, {-34, 38}, {-34, 52}, {-26, 52}}, color = {0, 0, 255}, smooth = Smooth.None));
    connect(R0.n, L0.p) annotation(
      Line(points = {{-40, 38}, {-34, 38}, {-34, 22}, {-26, 22}}, color = {0, 0, 255}, smooth = Smooth.None));
    connect(L0.n, R2.p) annotation(
      Line(points = {{-6, 22}, {22, 22}}, color = {0, 0, 255}, smooth = Smooth.None));
    connect(C0.n, R1.p) annotation(
      Line(points = {{-6, 52}, {22, 52}}, color = {0, 0, 255}, smooth = Smooth.None));
    connect(R1.n, R3.p) annotation(
      Line(points = {{42, 52}, {54, 52}, {54, 18}}, color = {0, 0, 255}, smooth = Smooth.None));
    connect(R2.n, R3.p) annotation(
      Line(points = {{42, 22}, {54, 22}, {54, 18}}, color = {0, 0, 255}, smooth = Smooth.None));
    connect(R3.n, sineVoltage.n) annotation(
      Line(points = {{54, -2}, {-72, -2}}, color = {0, 0, 255}, smooth = Smooth.None));
    connect(R3.n, ground.p) annotation(
      Line(points = {{54, -2}, {54, -8}}, color = {0, 0, 255}));
    annotation(
      Diagram(graphics));
  end func4;
  annotation(
    uses(Modelica(version = "3.2")));
end laba3;
