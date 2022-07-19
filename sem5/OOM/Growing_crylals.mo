package Growing_crylals
  model Burner
    Real dq(start = 10);
    parameter Real t = 1000; 
    Real dQGor;
    con_out dQ_out;
    con_in t_k;
  equation
  if time < 20 then
    dQGor = 0.63;
    elseif time < 40 then
    dQGor = 0.5;
    else
    dQGor = 0;
    end if;
    dq = dQGor*(t-t_k.val);
    dQ_out.val = dq;
  end Burner;

  connector con_in
    input Real val;
  end con_in;

  connector con_out
    output Real val;
  end con_out;

  model Crystal
    Real n(start = 1);
    parameter Integer N = 10;
    Real crg[N];
    Real dm[N];
    Real f;
    parameter Real C0 = 20;
    parameter Real Kup = 2;
    parameter Real p = 0.9982;
    Real conc_cr;
    con_in t;
    con_in conc;
    con_out loss;
  equation
    conc_cr = (C0 + C0*t.val/50)/100;  
      if conc.val >= conc_cr*1.1 then
      f = 1;
      for i in 1:N loop
        if i < n + 0.5 then
          der(crg[i]) = (conc.val -conc_cr)*Kup;
          dm[i] = p* der(crg[i])*(3/4)* 3.141592 * crg[i]^2; 
  //рождённые кристаллы растут
        else
          der(crg[i]) = 0;
          dm[i] = 0;
  //мнимые кристаллы отсутствуют
        end if;
      end for;
    else
       f = 0;
      for i in 1:N loop
        if i < n + 0.5 then
          der(crg[i]) = (conc.val -conc_cr)*Kup;
          dm[i] = p* der(crg[i])*(3/4)* 3.141592* crg[i]^2;
  //рождённые кристаллы растут
        else
          der(crg[i]) = 0;
          dm[i] = 0;
  //мнимые кристаллы отсутствуют
        end if;
      end for;
      end if;
    if f < 0.5 or n > 10 then
      der(n) = 0;
    else
      der(n) = 0.6;
    end if;
    loss.val = dm[1] + dm[2]+dm[3]+dm[4]+dm[5]+dm[6]+dm[7]+dm[8]+dm[9]+dm[10];
  end Crystal;

  model Liquid
    parameter Real C = 0.05;
    parameter Real Cisp = 1000;
    parameter Real out = 2;
    Real Q;
    Real dQisp;
    Real dQgas;
    Real T;
    parameter Real Tout = 25;
    Real m_l(start = 1000);
    Real m_s(start = 450);
    Real dmisp;
    parameter Real kmax = 2;
    parameter Real kgas = 1.5;
    parameter Real I = 1;
    Real kisp;
    Real conc;
    con_in loss;
    con_in q_q;
    con_out cons_o;
    con_out t_k;
  equation
    der(Q) = q_q.val - dQisp - dQgas;
    dQisp = Cisp*dmisp;
    dmisp = kisp*I;
    kisp = T^2 * kmax/10000;
    if T <= 100 then
    T = Q/(C*(m_l + m_s));
    else
    T = 100;
    end if;
    dQgas = kgas*(T-Tout);
    if m_l > 1 then
    der(m_l)= - dmisp;
    else
    der(m_l)= 0;
    end if;
    if m_s > 0 then
    der(m_s)= -loss.val;
    else
    der(m_s) = 0;
    end if;
    conc = (m_s / m_l);
    cons_o.val = conc;
    t_k.val = T;
  end Liquid;

  model Sold_crystal
    Burner b;
    Crystal c;
    Liquid l;
  equation
    connect(b.dQ_out, l.q_q);
    connect(l.t_k, b.t_k);
    connect(l.t_k, c.t);
    connect(l.cons_o, c.conc);
    connect(c.loss, l.loss);
    annotation(
      experiment(StartTime = 0, StopTime = 100, Tolerance = 1e-06, Interval = 0.002));
  end Sold_crystal;
end Growing_crylals;
