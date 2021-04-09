namespace CTrue.FsConnect
{
    public enum FsEventId
    {
        /// <summary>
        /// Set throttles max
        /// </summary>
        KEY_THROTTLE_FULL,
        /// <summary>
        /// Increment throttles
        /// </summary>
        KEY_THROTTLE_INCR,
        /// <summary>
        /// Increment throttles small
        /// </summary>
        KEY_THROTTLE_INCR_SMALL,
        /// <summary>
        /// Decrement throttles
        /// </summary>
        KEY_THROTTLE_DECR,
        /// <summary>
        /// Decrease throttles small
        /// </summary>
        KEY_THROTTLE_DECR_SMALL,
        /// <summary>
        /// Set throttles to idle
        /// </summary>
        KEY_THROTTLE_CUT,
        /// <summary>
        /// Increment throttles
        /// </summary>
        KEY_INCREASE_THROTTLE,
        /// <summary>
        /// Decrement throttles
        /// </summary>
        KEY_DECREASE_THROTTLE,
        /// <summary>
        /// Set throttles exactly (0- 16383)
        /// </summary>
        KEY_THROTTLE_SET,
        /// <summary>
        /// Set throttles (0- 16383)
        /// </summary>
        KEY_AXIS_THROTTLE_SET,
        /// <summary>
        /// Set throttle 1 exactly (0 to 16383)
        /// </summary>
        KEY_THROTTLE1_SET,
        /// <summary>
        /// Set throttle 2 exactly (0 to 16383)
        /// </summary>
        KEY_THROTTLE2_SET,
        /// <summary>
        /// Set throttle 3 exactly (0 to 16383)
        /// </summary>
        KEY_THROTTLE3_SET,
        /// <summary>
        /// Set throttle 4 exactly (0 to 16383)
        /// </summary>
        KEY_THROTTLE4_SET,
        /// <summary>
        /// Set throttle 1 max
        /// </summary>
        KEY_THROTTLE1_FULL,
        /// <summary>
        /// Increment throttle 1
        /// </summary>
        KEY_THROTTLE1_INCR,
        /// <summary>
        /// Increment throttle 1 small
        /// </summary>
        KEY_THROTTLE1_INCR_SMALL,
        /// <summary>
        /// Decrement throttle 1
        /// </summary>
        KEY_THROTTLE1_DECR,
        /// <summary>
        /// Set throttle 1 to idle
        /// </summary>
        KEY_THROTTLE1_CUT,
        /// <summary>
        /// Set throttle 2 max
        /// </summary>
        KEY_THROTTLE2_FULL,
        /// <summary>
        /// Increment throttle 2
        /// </summary>
        KEY_THROTTLE2_INCR,
        /// <summary>
        /// Increment throttle 2 small
        /// </summary>
        KEY_THROTTLE2_INCR_SMALL,
        /// <summary>
        /// Decrement throttle 2
        /// </summary>
        KEY_THROTTLE2_DECR,
        /// <summary>
        /// Set throttle 2 to idle
        /// </summary>
        KEY_THROTTLE2_CUT,
        /// <summary>
        /// Set throttle 3 max
        /// </summary>
        KEY_THROTTLE3_FULL,
        /// <summary>
        /// Increment throttle 3
        /// </summary>
        KEY_THROTTLE3_INCR,
        /// <summary>
        /// Increment throttle 3 small
        /// </summary>
        KEY_THROTTLE3_INCR_SMALL,
        /// <summary>
        /// Decrement throttle 3
        /// </summary>
        KEY_THROTTLE3_DECR,
        /// <summary>
        /// Set throttle 3 to idle
        /// </summary>
        KEY_THROTTLE3_CUT,
        /// <summary>
        /// Set throttle 1 max
        /// </summary>
        KEY_THROTTLE4_FULL,
        /// <summary>
        /// Increment throttle 4
        /// </summary>
        KEY_THROTTLE4_INCR,
        /// <summary>
        /// Increment throttle 4 small
        /// </summary>
        KEY_THROTTLE4_INCR_SMALL,
        /// <summary>
        /// Decrement throttle 4
        /// </summary>
        KEY_THROTTLE4_DECR,
        /// <summary>
        /// Set throttle 4 to idle
        /// </summary>
        KEY_THROTTLE4_CUT,
        /// <summary>
        /// Set throttles to 10%
        /// </summary>
        KEY_THROTTLE_10,
        /// <summary>
        /// Set throttles to 20%
        /// </summary>
        KEY_THROTTLE_20,
        /// <summary>
        /// Set throttles to 30%
        /// </summary>
        KEY_THROTTLE_30,
        /// <summary>
        /// Set throttles to 40%
        /// </summary>
        KEY_THROTTLE_40,
        /// <summary>
        /// Set throttles to 50%
        /// </summary>
        KEY_THROTTLE_50,
        /// <summary>
        /// Set throttles to 60%
        /// </summary>
        KEY_THROTTLE_60,
        /// <summary>
        /// Set throttles to 70%
        /// </summary>
        KEY_THROTTLE_70,
        /// <summary>
        /// Set throttles to 80%
        /// </summary>
        KEY_THROTTLE_80,
        /// <summary>
        /// Set throttles to 90%
        /// </summary>
        KEY_THROTTLE_90,
        /// <summary>
        /// Set throttle 1 exactly (-16383 - +16383)
        /// </summary>
        KEY_AXIS_THROTTLE1_SET,
        /// <summary>
        /// Set throttle 2 exactly (-16383 - +16383)
        /// </summary>
        KEY_AXIS_THROTTLE2_SET,
        /// <summary>
        /// Set throttle 3 exactly (-16383 - +16383)
        /// </summary>
        KEY_AXIS_THROTTLE3_SET,
        /// <summary>
        /// Set throttle 4 exactly (-16383 - +16383)
        /// </summary>
        KEY_AXIS_THROTTLE4_SET,
        /// <summary>
        /// Decrease throttle 1 small
        /// </summary>
        KEY_THROTTLE1_DECR_SMALL,
        /// <summary>
        /// Decrease throttle 2 small
        /// </summary>
        KEY_THROTTLE2_DECR_SMALL,
        /// <summary>
        /// Decrease throttle 3 small
        /// </summary>
        KEY_THROTTLE3_DECR_SMALL,
        /// <summary>
        /// Decrease throttle 4 small
        /// </summary>
        KEY_THROTTLE4_DECR_SMALL,
        /// <summary>
        /// Decrease prop levers small
        /// </summary>
        KEY_PROP_PITCH_DECR_SMALL,
        /// <summary>
        /// Decrease prop lever 1 small
        /// </summary>
        KEY_PROP_PITCH1_DECR_SMALL,
        /// <summary>
        /// Decrease prop lever 2 small
        /// </summary>
        KEY_PROP_PITCH2_DECR_SMALL,
        /// <summary>
        /// Decrease prop lever 3 small
        /// </summary>
        KEY_PROP_PITCH3_DECR_SMALL,
        /// <summary>
        /// Decrease prop lever 4 small
        /// </summary>
        KEY_PROP_PITCH4_DECR_SMALL,
        /// <summary>
        /// Set mixture lever 1 to max rich
        /// </summary>
        KEY_MIXTURE1_RICH,
        /// <summary>
        /// Increment mixture lever 1
        /// </summary>
        KEY_MIXTURE1_INCR,
        /// <summary>
        /// Increment mixture lever 1 small
        /// </summary>
        KEY_MIXTURE1_INCR_SMALL,
        /// <summary>
        /// Decrement mixture lever 1
        /// </summary>
        KEY_MIXTURE1_DECR,
        /// <summary>
        /// Set mixture lever 1 to max lean
        /// </summary>
        KEY_MIXTURE1_LEAN,
        /// <summary>
        /// Set mixture lever 2 to max rich
        /// </summary>
        KEY_MIXTURE2_RICH,
        /// <summary>
        /// Increment mixture lever 2
        /// </summary>
        KEY_MIXTURE2_INCR,
        /// <summary>
        /// Increment mixture lever 2 small
        /// </summary>
        KEY_MIXTURE2_INCR_SMALL,
        /// <summary>
        /// Decrement mixture lever 2
        /// </summary>
        KEY_MIXTURE2_DECR,
        /// <summary>
        /// Set mixture lever 2 to max lean
        /// </summary>
        KEY_MIXTURE2_LEAN,
        /// <summary>
        /// Set mixture lever 3 to max rich
        /// </summary>
        KEY_MIXTURE3_RICH,
        /// <summary>
        /// Increment mixture lever 3
        /// </summary>
        KEY_MIXTURE3_INCR,
        /// <summary>
        /// Increment mixture lever 3 small
        /// </summary>
        KEY_MIXTURE3_INCR_SMALL,
        /// <summary>
        /// Decrement mixture lever 3
        /// </summary>
        KEY_MIXTURE3_DECR,
        /// <summary>
        /// Set mixture lever 3 to max lean
        /// </summary>
        KEY_MIXTURE3_LEAN,
        /// <summary>
        /// Set mixture lever 4 to max rich
        /// </summary>
        KEY_MIXTURE4_RICH,
        /// <summary>
        /// Increment mixture lever 4
        /// </summary>
        KEY_MIXTURE4_INCR,
        /// <summary>
        /// Increment mixture lever 4 small
        /// </summary>
        KEY_MIXTURE4_INCR_SMALL,
        /// <summary>
        /// Decrement mixture lever 4
        /// </summary>
        KEY_MIXTURE4_DECR,
        /// <summary>
        /// Set mixture lever 4 to max lean
        /// </summary>
        KEY_MIXTURE4_LEAN,
        /// <summary>
        /// Set mixture levers to exact value (0 to 16383)
        /// </summary>
        KEY_MIXTURE_SET,
        /// <summary>
        /// Set mixture levers to max rich
        /// </summary>
        KEY_MIXTURE_RICH,
        /// <summary>
        /// Increment mixture levers
        /// </summary>
        KEY_MIXTURE_INCR,
        /// <summary>
        /// Increment mixture levers small
        /// </summary>
        KEY_MIXTURE_INCR_SMALL,
        /// <summary>
        /// Decrement mixture levers
        /// </summary>
        KEY_MIXTURE_DECR,
        /// <summary>
        /// Set mixture levers to max lean
        /// </summary>
        KEY_MIXTURE_LEAN,
        /// <summary>
        /// Set mixture lever 1 exact value (0 to 16383)
        /// </summary>
        KEY_MIXTURE1_SET,
        /// <summary>
        /// Set mixture lever 2 exact value (0 to 16383)
        /// </summary>
        KEY_MIXTURE2_SET,
        /// <summary>
        /// Set mixture lever 3 exact value (0 to 16383)
        /// </summary>
        KEY_MIXTURE3_SET,
        /// <summary>
        /// Set mixture lever 4 exact value (0 to 16383)
        /// </summary>
        KEY_MIXTURE4_SET,
        /// <summary>
        /// Set mixture lever 1 exact value (-16383 to +16383)
        /// </summary>
        KEY_AXIS_MIXTURE_SET,
        /// <summary>
        /// Set mixture lever 1 exact value (-16383 to +16383)
        /// </summary>
        KEY_AXIS_MIXTURE1_SET,
        /// <summary>
        /// Set mixture lever 2 exact value (-16383 to +16383)
        /// </summary>
        KEY_AXIS_MIXTURE2_SET,
        /// <summary>
        /// Set mixture lever 3 exact value (-16383 to +16383)
        /// </summary>
        KEY_AXIS_MIXTURE3_SET,
        /// <summary>
        /// Set mixture lever 4 exact value (-16383 to +16383)
        /// </summary>
        KEY_AXIS_MIXTURE4_SET,
        /// <summary>
        /// Set mixture levers to current best power setting
        /// </summary>
        KEY_MIXTURE_SET_BEST,
        /// <summary>
        /// Decrement mixture levers small
        /// </summary>
        KEY_MIXTURE_DECR_SMALL,
        /// <summary>
        /// Decrement mixture lever 1 small
        /// </summary>
        KEY_MIXTURE1_DECR_SMALL,
        /// <summary>
        /// Decrement mixture lever 4 small
        /// </summary>
        KEY_MIXTURE2_DECR_SMALL,
        /// <summary>
        /// Decrement mixture lever 4 small
        /// </summary>
        KEY_MIXTURE3_DECR_SMALL,
        /// <summary>
        /// Decrement mixture lever 4 small
        /// </summary>
        KEY_MIXTURE4_DECR_SMALL,
        /// <summary>
        /// Set prop pitch levers (0 to 16383)
        /// </summary>
        KEY_PROP_PITCH_SET,
        /// <summary>
        /// Set prop pitch levers max (lo pitch)
        /// </summary>
        KEY_PROP_PITCH_LO,
        /// <summary>
        /// Increment prop pitch levers
        /// </summary>
        KEY_PROP_PITCH_INCR,
        /// <summary>
        /// Increment prop pitch levers small
        /// </summary>
        KEY_PROP_PITCH_INCR_SMALL,
        /// <summary>
        /// Decrement prop pitch levers
        /// </summary>
        KEY_PROP_PITCH_DECR,
        /// <summary>
        /// Set prop pitch levers min (hi pitch)
        /// </summary>
        KEY_PROP_PITCH_HI,
        /// <summary>
        /// Set prop pitch lever 1 exact value (0 to 16383)
        /// </summary>
        KEY_PROP_PITCH1_SET,
        /// <summary>
        /// Set prop pitch lever 2 exact value (0 to 16383)
        /// </summary>
        KEY_PROP_PITCH2_SET,
        /// <summary>
        /// Set prop pitch lever 3 exact value (0 to 16383)
        /// </summary>
        KEY_PROP_PITCH3_SET,
        /// <summary>
        /// Set prop pitch lever 4 exact value (0 to 16383)
        /// </summary>
        KEY_PROP_PITCH4_SET,
        /// <summary>
        /// Set prop pitch lever 1 max (lo pitch)
        /// </summary>
        KEY_PROP_PITCH1_LO,
        /// <summary>
        /// Increment prop pitch lever 1
        /// </summary>
        KEY_PROP_PITCH1_INCR,
        /// <summary>
        /// Increment prop pitch lever 1 small
        /// </summary>
        KEY_PROP_PITCH1_INCR_SMALL,
        /// <summary>
        /// Decrement prop pitch lever 1
        /// </summary>
        KEY_PROP_PITCH1_DECR,
        /// <summary>
        /// Set prop pitch lever 1 min (hi pitch)
        /// </summary>
        KEY_PROP_PITCH1_HI,
        /// <summary>
        /// Set prop pitch lever 2 max (lo pitch)
        /// </summary>
        KEY_PROP_PITCH2_LO,
        /// <summary>
        /// Increment prop pitch lever 2
        /// </summary>
        KEY_PROP_PITCH2_INCR,
        /// <summary>
        /// Increment prop pitch lever 2 small
        /// </summary>
        KEY_PROP_PITCH2_INCR_SMALL,
        /// <summary>
        /// Decrement prop pitch lever 2
        /// </summary>
        KEY_PROP_PITCH2_DECR,
        /// <summary>
        /// Set prop pitch lever 2 min (hi pitch)
        /// </summary>
        KEY_PROP_PITCH2_HI,
        /// <summary>
        /// Set prop pitch lever 3 max (lo pitch)
        /// </summary>
        KEY_PROP_PITCH3_LO,
        /// <summary>
        /// Increment prop pitch lever 3
        /// </summary>
        KEY_PROP_PITCH3_INCR,
        /// <summary>
        /// Increment prop pitch lever 3 small
        /// </summary>
        KEY_PROP_PITCH3_INCR_SMALL,
        /// <summary>
        /// Decrement prop pitch lever 3
        /// </summary>
        KEY_PROP_PITCH3_DECR,
        /// <summary>
        /// Set prop pitch lever 3 min (hi pitch)
        /// </summary>
        KEY_PROP_PITCH3_HI,
        /// <summary>
        /// Set prop pitch lever 4 max (lo pitch)
        /// </summary>
        KEY_PROP_PITCH4_LO,
        /// <summary>
        /// Increment prop pitch lever 4
        /// </summary>
        KEY_PROP_PITCH4_INCR,
        /// <summary>
        /// Increment prop pitch lever 4 small
        /// </summary>
        KEY_PROP_PITCH4_INCR_SMALL,
        /// <summary>
        /// Decrement prop pitch lever 4
        /// </summary>
        KEY_PROP_PITCH4_DECR,
        /// <summary>
        /// Set prop pitch lever 4 min (hi pitch)
        /// </summary>
        KEY_PROP_PITCH4_HI,
        /// <summary>
        /// Set propeller levers exact value (-16383 to +16383)
        /// </summary>
        KEY_AXIS_PROPELLER_SET,
        /// <summary>
        /// Set propeller lever 1 exact value (-16383 to +16383)
        /// </summary>
        KEY_AXIS_PROPELLER1_SET,
        /// <summary>
        /// Set propeller lever 2 exact value (-16383 to +16383)
        /// </summary>
        KEY_AXIS_PROPELLER2_SET,
        /// <summary>
        /// Set propeller lever 3 exact value (-16383 to +16383)
        /// </summary>
        KEY_AXIS_PROPELLER3_SET,
        /// <summary>
        /// Set propeller lever 4 exact value (-16383 to +16383)
        /// </summary>
        KEY_AXIS_PROPELLER4_SET,
        /// <summary>
        /// Selects jet engine starter (for +/- sequence)
        /// </summary>
        KEY_JET_STARTER,
        /// <summary>
        /// Sets magnetos (0,1)
        /// </summary>
        KEY_STARTER_SET,
        /// <summary>
        /// Toggle starter 1
        /// </summary>
        KEY_TOGGLE_STARTER1,
        /// <summary>
        /// Toggle starter 2
        /// </summary>
        KEY_TOGGLE_STARTER2,
        /// <summary>
        /// Toggle starter 3
        /// </summary>
        KEY_TOGGLE_STARTER3,
        /// <summary>
        /// Toggle starter 4
        /// </summary>
        KEY_TOGGLE_STARTER4,
        /// <summary>
        /// Toggle starters
        /// </summary>
        KEY_TOGGLE_ALL_STARTERS,
        /// <summary>
        /// Triggers auto-start
        /// </summary>
        KEY_ENGINE_AUTO_START,
        /// <summary>
        /// Triggers auto-shutdown
        /// </summary>
        KEY_ENGINE_AUTO_SHUTDOWN,
        /// <summary>
        /// Selects magnetos (for +/- sequence)
        /// </summary>
        KEY_MAGNETO,
        /// <summary>
        /// Decrease magneto switches positions
        /// </summary>
        KEY_MAGNETO_DECR,
        /// <summary>
        /// Increase magneto switches positions
        /// </summary>
        KEY_MAGNETO_INCR,
        /// <summary>
        /// Set engine 1 magnetos off
        /// </summary>
        KEY_MAGNETO1_OFF,
        /// <summary>
        /// Toggle engine 1 right magneto
        /// </summary>
        KEY_MAGNETO1_RIGHT,
        /// <summary>
        /// Toggle engine 1 left magneto
        /// </summary>
        KEY_MAGNETO1_LEFT,
        /// <summary>
        /// Set engine 1 magnetos on
        /// </summary>
        KEY_MAGNETO1_BOTH,
        /// <summary>
        /// Set engine 1 magnetos on and toggle starter
        /// </summary>
        KEY_MAGNETO1_START,
        /// <summary>
        /// Set engine 2 magnetos off
        /// </summary>
        KEY_MAGNETO2_OFF,
        /// <summary>
        /// Toggle engine 2 right magneto
        /// </summary>
        KEY_MAGNETO2_RIGHT,
        /// <summary>
        /// Toggle engine 2 left magneto
        /// </summary>
        KEY_MAGNETO2_LEFT,
        /// <summary>
        /// Set engine 2 magnetos on
        /// </summary>
        KEY_MAGNETO2_BOTH,
        /// <summary>
        /// Set engine 2 magnetos on and toggle starter
        /// </summary>
        KEY_MAGNETO2_START,
        /// <summary>
        /// Set engine 3 magnetos off
        /// </summary>
        KEY_MAGNETO3_OFF,
        /// <summary>
        /// Toggle engine 3 right magneto
        /// </summary>
        KEY_MAGNETO3_RIGHT,
        /// <summary>
        /// Toggle engine 3 left magneto
        /// </summary>
        KEY_MAGNETO3_LEFT,
        /// <summary>
        /// Set engine 3 magnetos on
        /// </summary>
        KEY_MAGNETO3_BOTH,
        /// <summary>
        /// Set engine 3 magnetos on and toggle starter
        /// </summary>
        KEY_MAGNETO3_START,
        /// <summary>
        /// Set engine 4 magnetos off
        /// </summary>
        KEY_MAGNETO4_OFF,
        /// <summary>
        /// Toggle engine 4 right magneto
        /// </summary>
        KEY_MAGNETO4_RIGHT,
        /// <summary>
        /// Toggle engine 4 left magneto
        /// </summary>
        KEY_MAGNETO4_LEFT,
        /// <summary>
        /// Set engine 4 magnetos on
        /// </summary>
        KEY_MAGNETO4_BOTH,
        /// <summary>
        /// Set engine 4 magnetos on and toggle starter
        /// </summary>
        KEY_MAGNETO4_START,
        /// <summary>
        /// Set engine magnetos off
        /// </summary>
        KEY_MAGNETO_OFF,
        /// <summary>
        /// Set engine right magnetos on
        /// </summary>
        KEY_MAGNETO_RIGHT,
        /// <summary>
        /// Set engine left magnetos on
        /// </summary>
        KEY_MAGNETO_LEFT,
        /// <summary>
        /// Set engine magnetos on
        /// </summary>
        KEY_MAGNETO_BOTH,
        /// <summary>
        /// Set engine magnetos on and toggle starters
        /// </summary>
        KEY_MAGNETO_START,
        /// <summary>
        /// Decrease engine 1 magneto switch position
        /// </summary>
        KEY_MAGNETO1_DECR,
        /// <summary>
        /// Increase engine 1 magneto switch position
        /// </summary>
        KEY_MAGNETO1_INCR,
        /// <summary>
        /// Decrease engine 2 magneto switch position
        /// </summary>
        KEY_MAGNETO2_DECR,
        /// <summary>
        /// Increase engine 2 magneto switch position
        /// </summary>
        KEY_MAGNETO2_INCR,
        /// <summary>
        /// Decrease engine 3 magneto switch position
        /// </summary>
        KEY_MAGNETO3_DECR,
        /// <summary>
        /// Increase engine 3 magneto switch position
        /// </summary>
        KEY_MAGNETO3_INCR,
        /// <summary>
        /// Decrease engine 4 magneto switch position
        /// </summary>
        KEY_MAGNETO4_DECR,
        /// <summary>
        /// Increase engine 4 magneto switch position
        /// </summary>
        KEY_MAGNETO4_INCR,
        /// <summary>
        /// Set engine 1 magneto switch
        /// </summary>
        KEY_MAGNETO1_SET,
        /// <summary>
        /// Set engine 2 magneto switch
        /// </summary>
        KEY_MAGNETO2_SET,
        /// <summary>
        /// Set engine 3 magneto switch
        /// </summary>
        KEY_MAGNETO3_SET,
        /// <summary>
        /// Set engine 4 magneto switch
        /// </summary>
        KEY_MAGNETO4_SET,
        /// <summary>
        /// Sets anti-ice switches on
        /// </summary>
        KEY_ANTI_ICE_ON,
        /// <summary>
        /// Sets anti-ice switches off
        /// </summary>
        KEY_ANTI_ICE_OFF,
        /// <summary>
        /// Sets anti-ice switches from argument (0,1)
        /// </summary>
        KEY_ANTI_ICE_SET,
        /// <summary>
        /// Toggle anti-ice switches
        /// </summary>
        KEY_ANTI_ICE_TOGGLE,
        /// <summary>
        /// Toggle engine 1 anti-ice switch
        /// </summary>
        KEY_ANTI_ICE_TOGGLE_ENG1,
        /// <summary>
        /// Toggle engine 2 anti-ice switch
        /// </summary>
        KEY_ANTI_ICE_TOGGLE_ENG2,
        /// <summary>
        /// Toggle engine 3 anti-ice switch
        /// </summary>
        KEY_ANTI_ICE_TOGGLE_ENG3,
        /// <summary>
        /// Toggle engine 4 anti-ice switch
        /// </summary>
        KEY_ANTI_ICE_TOGGLE_ENG4,
        /// <summary>
        /// Sets engine 1 anti-ice switch (0,1)
        /// </summary>
        KEY_ANTI_ICE_SET_ENG1,
        /// <summary>
        /// Sets engine 2 anti-ice switch (0,1)
        /// </summary>
        KEY_ANTI_ICE_SET_ENG2,
        /// <summary>
        /// Sets engine 3 anti-ice switch (0,1)
        /// </summary>
        KEY_ANTI_ICE_SET_ENG3,
        /// <summary>
        /// Sets engine 4 anti-ice switch (0,1)
        /// </summary>
        KEY_ANTI_ICE_SET_ENG4,
        /// <summary>
        /// Toggle engine fuel valves
        /// </summary>
        KEY_TOGGLE_FUEL_VALVE_ALL,
        /// <summary>
        /// Toggle engine 1 fuel valve
        /// </summary>
        KEY_TOGGLE_FUEL_VALVE_ENG1,
        /// <summary>
        /// Toggle engine 2 fuel valve
        /// </summary>
        KEY_TOGGLE_FUEL_VALVE_ENG2,
        /// <summary>
        /// Toggle engine 3 fuel valve
        /// </summary>
        KEY_TOGGLE_FUEL_VALVE_ENG3,
        /// <summary>
        /// Toggle engine 4 fuel valve
        /// </summary>
        KEY_TOGGLE_FUEL_VALVE_ENG4,
        /// <summary>
        /// Sets engine 1 cowl flap lever position (0 to 16383)
        /// </summary>
        KEY_COWLFLAP1_SET,
        /// <summary>
        /// Sets engine 2 cowl flap lever position (0 to 16383)
        /// </summary>
        KEY_COWLFLAP2_SET,
        /// <summary>
        /// Sets engine 3 cowl flap lever position (0 to 16383)
        /// </summary>
        KEY_COWLFLAP3_SET,
        /// <summary>
        /// Sets engine 4 cowl flap lever position (0 to 16383)
        /// </summary>
        KEY_COWLFLAP4_SET,
        /// <summary>
        /// Increment cowl flap levers
        /// </summary>
        KEY_INC_COWL_FLAPS,
        /// <summary>
        /// Decrement cowl flap levers
        /// </summary>
        KEY_DEC_COWL_FLAPS,
        /// <summary>
        /// Increment engine 1 cowl flap lever
        /// </summary>
        KEY_INC_COWL_FLAPS1,
        /// <summary>
        /// Decrement engine 1 cowl flap lever
        /// </summary>
        KEY_DEC_COWL_FLAPS1,
        /// <summary>
        /// Increment engine 2 cowl flap lever
        /// </summary>
        KEY_INC_COWL_FLAPS2,
        /// <summary>
        /// Decrement engine 2 cowl flap lever
        /// </summary>
        KEY_DEC_COWL_FLAPS2,
        /// <summary>
        /// Increment engine 3 cowl flap lever
        /// </summary>
        KEY_INC_COWL_FLAPS3,
        /// <summary>
        /// Decrement engine 3 cowl flap lever
        /// </summary>
        KEY_DEC_COWL_FLAPS3,
        /// <summary>
        /// Increment engine 4 cowl flap lever
        /// </summary>
        KEY_INC_COWL_FLAPS4,
        /// <summary>
        /// Decrement engine 4 cowl flap lever
        /// </summary>
        KEY_DEC_COWL_FLAPS4,
        /// <summary>
        /// Toggle electric fuel pumps
        /// </summary>
        KEY_FUEL_PUMP,
        /// <summary>
        /// Toggle electric fuel pumps
        /// </summary>
        KEY_TOGGLE_ELECT_FUEL_PUMP,
        /// <summary>
        /// Toggle engine 1 electric fuel pump
        /// </summary>
        KEY_TOGGLE_ELECT_FUEL_PUMP1,
        /// <summary>
        /// Toggle engine 2 electric fuel pump
        /// </summary>
        KEY_TOGGLE_ELECT_FUEL_PUMP2,
        /// <summary>
        /// Toggle engine 3 electric fuel pump
        /// </summary>
        KEY_TOGGLE_ELECT_FUEL_PUMP3,
        /// <summary>
        /// Toggle engine 4 electric fuel pump
        /// </summary>
        KEY_TOGGLE_ELECT_FUEL_PUMP4,
        /// <summary>
        /// Trigger engine primers
        /// </summary>
        KEY_ENGINE_PRIMER,
        /// <summary>
        /// Trigger engine primers
        /// </summary>
        KEY_TOGGLE_PRIMER,
        /// <summary>
        /// Trigger engine 1 primer
        /// </summary>
        KEY_TOGGLE_PRIMER1,
        /// <summary>
        /// Trigger engine 2 primer
        /// </summary>
        KEY_TOGGLE_PRIMER2,
        /// <summary>
        /// Trigger engine 3 primer
        /// </summary>
        KEY_TOGGLE_PRIMER3,
        /// <summary>
        /// Trigger engine 4 primer
        /// </summary>
        KEY_TOGGLE_PRIMER4,
        /// <summary>
        /// Trigger propeller switches
        /// </summary>
        KEY_TOGGLE_FEATHER_SWITCHES,
        /// <summary>
        /// Trigger propeller 1 switch
        /// </summary>
        KEY_TOGGLE_FEATHER_SWITCH_1,
        /// <summary>
        /// Trigger propeller 2 switch
        /// </summary>
        KEY_TOGGLE_FEATHER_SWITCH_2,
        /// <summary>
        /// Trigger propeller 3 switch
        /// </summary>
        KEY_TOGGLE_FEATHER_SWITCH_3,
        /// <summary>
        /// Trigger propeller 4 switch
        /// </summary>
        KEY_TOGGLE_FEATHER_SWITCH_4,
        /// <summary>
        /// Turns propeller synchronization switch on
        /// </summary>
        KEY_TOGGLE_PROP_SYNC,
        /// <summary>
        /// Turns auto-feather arming switch on.
        /// </summary>
        KEY_TOGGLE_ARM_AUTOFEATHER,
        /// <summary>
        /// Toggles afterburners
        /// </summary>
        KEY_TOGGLE_AFTERBURNER,
        /// <summary>
        /// Toggles engine 1 afterburner
        /// </summary>
        KEY_TOGGLE_AFTERBURNER1,
        /// <summary>
        /// Toggles engine 2 afterburner
        /// </summary>
        KEY_TOGGLE_AFTERBURNER2,
        /// <summary>
        /// Toggles engine 3 afterburner
        /// </summary>
        KEY_TOGGLE_AFTERBURNER3,
        /// <summary>
        /// Toggles engine 4 afterburner
        /// </summary>
        KEY_TOGGLE_AFTERBURNER4,
        /// <summary>
        /// Sets engines for 1,2,3,4 selection (to be followed by SELECT_n)
        /// </summary>
        KEY_ENGINE,
        /// <summary>
        /// Toggles spoiler handle
        /// </summary>
        KEY_SPOILERS_TOGGLE,
        /// <summary>
        /// Sets flap handle to full retract position
        /// </summary>
        KEY_FLAPS_UP,
        /// <summary>
        /// Sets flap handle to first extension position
        /// </summary>
        KEY_FLAPS_1,
        /// <summary>
        /// Sets flap handle to second extension position
        /// </summary>
        KEY_FLAPS_2,
        /// <summary>
        /// Sets flap handle to third extension position
        /// </summary>
        KEY_FLAPS_3,
        /// <summary>
        /// Sets flap handle to full extension position
        /// </summary>
        KEY_FLAPS_DOWN,
        /// <summary>
        /// Increments elevator trim down
        /// </summary>
        KEY_ELEV_TRIM_DN,
        /// <summary>
        /// Increments elevator down
        /// </summary>
        KEY_ELEV_DOWN,
        /// <summary>
        /// Increments ailerons left
        /// </summary>
        KEY_AILERONS_LEFT,
        /// <summary>
        /// Centers aileron and rudder positions
        /// </summary>
        KEY_CENTER_AILER_RUDDER,
        /// <summary>
        /// Increments ailerons right
        /// </summary>
        KEY_AILERONS_RIGHT,
        /// <summary>
        /// Increment elevator trim up
        /// </summary>
        KEY_ELEV_TRIM_UP,
        /// <summary>
        /// Increments elevator up
        /// </summary>
        KEY_ELEV_UP,
        /// <summary>
        /// Increments rudder left
        /// </summary>
        KEY_RUDDER_LEFT,
        /// <summary>
        /// Centers rudder position
        /// </summary>
        KEY_RUDDER_CENTER,
        /// <summary>
        /// Increments rudder right
        /// </summary>
        KEY_RUDDER_RIGHT,
        /// <summary>
        /// Sets elevator position (-16383 - +16383)
        /// </summary>
        KEY_ELEVATOR_SET,
        /// <summary>
        /// Sets aileron position (-16383 - +16383)
        /// </summary>
        KEY_AILERON_SET,
        /// <summary>
        /// Sets rudder position (-16383 - +16383)
        /// </summary>
        KEY_RUDDER_SET,
        /// <summary>
        /// Increments flap handle position
        /// </summary>
        KEY_FLAPS_INCR,
        /// <summary>
        /// Decrements flap handle position
        /// </summary>
        KEY_FLAPS_DECR,
        /// <summary>
        /// Sets elevator position (-16383 - +16383)
        /// </summary>
        KEY_AXIS_ELEVATOR_SET,
        /// <summary>
        /// Sets aileron position (-16383 - +16383)
        /// </summary>
        KEY_AXIS_AILERONS_SET,
        /// <summary>
        /// Sets rudder position (-16383 - +16383)
        /// </summary>
        KEY_AXIS_RUDDER_SET,
        /// <summary>
        /// Sets elevator trim position (-16383 - +16383)
        /// </summary>
        KEY_AXIS_ELEV_TRIM_SET,
        /// <summary>
        /// Sets spoiler handle position (0 to 16383)
        /// </summary>
        KEY_SPOILERS_SET,
        /// <summary>
        /// Toggles arming of auto-spoilers
        /// </summary>
        KEY_SPOILERS_ARM_TOGGLE,
        /// <summary>
        /// Sets spoiler handle to full extend position
        /// </summary>
        KEY_SPOILERS_ON,
        /// <summary>
        /// Sets spoiler handle to full retract position
        /// </summary>
        KEY_SPOILERS_OFF,
        /// <summary>
        /// Sets auto-spoiler arming on
        /// </summary>
        KEY_SPOILERS_ARM_ON,
        /// <summary>
        /// Sets auto-spoiler arming off
        /// </summary>
        KEY_SPOILERS_ARM_OFF,
        /// <summary>
        /// Sets auto-spoiler arming (0,1)
        /// </summary>
        KEY_SPOILERS_ARM_SET,
        /// <summary>
        /// Increments aileron trim left
        /// </summary>
        KEY_AILERON_TRIM_LEFT,
        /// <summary>
        /// Increments aileron trim right
        /// </summary>
        KEY_AILERON_TRIM_RIGHT,
        /// <summary>
        /// Increments rudder trim left
        /// </summary>
        KEY_RUDDER_TRIM_LEFT,
        /// <summary>
        /// Increments aileron trim right
        /// </summary>
        KEY_RUDDER_TRIM_RIGHT,
        /// <summary>
        /// Sets spoiler handle position (-16383 - +16383)
        /// </summary>
        KEY_AXIS_SPOILER_SET,
        /// <summary>
        /// Sets flap handle to closest increment (0 to 16383)
        /// </summary>
        KEY_FLAPS_SET,
        /// <summary>
        /// Sets elevator trim position (0 to 16383)
        /// </summary>
        KEY_ELEVATOR_TRIM_SET,
        /// <summary>
        /// Sets flap handle to closest increment (-16383 - +16383)
        /// </summary>
        KEY_AXIS_FLAPS_SET,
        /// <summary>
        /// Toggles AP on/off
        /// </summary>
        KEY_AP_MASTER,
        /// <summary>
        /// Turns AP off
        /// </summary>
        KEY_AUTOPILOT_OFF,
        /// <summary>
        /// Turns AP on
        /// </summary>
        KEY_AUTOPILOT_ON,
        /// <summary>
        /// Toggles yaw damper on/off
        /// </summary>
        KEY_YAW_DAMPER_TOGGLE,
        /// <summary>
        /// Toggles heading hold mode on/off
        /// </summary>
        KEY_AP_PANEL_HEADING_HOLD,
        /// <summary>
        /// Toggles altitude hold mode on/off
        /// </summary>
        KEY_AP_PANEL_ALTITUDE_HOLD,
        /// <summary>
        /// Turns on AP wing leveler and pitch hold mode
        /// </summary>
        KEY_AP_ATT_HOLD_ON,
        /// <summary>
        /// Turns AP localizer hold on/armed and glide-slope hold mode off
        /// </summary>
        KEY_AP_LOC_HOLD_ON,
        /// <summary>
        /// Turns both AP localizer and glide-slope modes on/armed
        /// </summary>
        KEY_AP_APR_HOLD_ON,
        /// <summary>
        /// Turns heading hold mode on
        /// </summary>
        KEY_AP_HDG_HOLD_ON,
        /// <summary>
        /// Turns altitude hold mode on
        /// </summary>
        KEY_AP_ALT_HOLD_ON,
        /// <summary>
        /// Turns wing leveler mode on
        /// </summary>
        KEY_AP_WING_LEVELER_ON,
        /// <summary>
        /// Turns localizer back course hold mode on/armed
        /// </summary>
        KEY_AP_BC_HOLD_ON,
        /// <summary>
        /// Turns lateral hold mode on
        /// </summary>
        KEY_AP_NAV1_HOLD_ON,
        /// <summary>
        /// Turns off attitude hold mode
        /// </summary>
        KEY_AP_ATT_HOLD_OFF,
        /// <summary>
        /// Turns off localizer hold mode
        /// </summary>
        KEY_AP_LOC_HOLD_OFF,
        /// <summary>
        /// Turns off approach hold mode
        /// </summary>
        KEY_AP_APR_HOLD_OFF,
        /// <summary>
        /// Turns off heading hold mode
        /// </summary>
        KEY_AP_HDG_HOLD_OFF,
        /// <summary>
        /// Turns off altitude hold mode
        /// </summary>
        KEY_AP_ALT_HOLD_OFF,
        /// <summary>
        /// Turns off wing leveler mode
        /// </summary>
        KEY_AP_WING_LEVELER_OFF,
        /// <summary>
        /// Turns off backcourse mode for localizer hold
        /// </summary>
        KEY_AP_BC_HOLD_OFF,
        /// <summary>
        /// Turns off nav hold mode
        /// </summary>
        KEY_AP_NAV1_HOLD_OFF,
        /// <summary>
        /// Toggles airspeed hold mode
        /// </summary>
        KEY_AP_AIRSPEED_HOLD,
        /// <summary>
        /// Toggles autothrottle arming mode
        /// </summary>
        KEY_AUTO_THROTTLE_ARM,
        /// <summary>
        /// Toggles Takeoff/Go Around mode
        /// </summary>
        KEY_AUTO_THROTTLE_TO_GA,
        /// <summary>
        /// Increments heading hold reference bug
        /// </summary>
        KEY_HEADING_BUG_INC,
        /// <summary>
        /// Decrements heading hold reference bug
        /// </summary>
        KEY_HEADING_BUG_DEC,
        /// <summary>
        /// Set heading hold reference bug (degrees)
        /// </summary>
        KEY_HEADING_BUG_SET,
        /// <summary>
        /// Toggles airspeed hold mode
        /// </summary>
        KEY_AP_PANEL_SPEED_HOLD,
        /// <summary>
        /// Increments reference altitude
        /// </summary>
        KEY_AP_ALT_VAR_INC,
        /// <summary>
        /// Decrements reference altitude
        /// </summary>
        KEY_AP_ALT_VAR_DEC,
        /// <summary>
        /// Increments vertical speed reference
        /// </summary>
        KEY_AP_VS_VAR_INC,
        /// <summary>
        /// Decrements vertical speed reference
        /// </summary>
        KEY_AP_VS_VAR_DEC,
        /// <summary>
        /// Increments airspeed hold reference
        /// </summary>
        KEY_AP_SPD_VAR_INC,
        /// <summary>
        /// Decrements airspeed hold reference
        /// </summary>
        KEY_AP_SPD_VAR_DEC,
        /// <summary>
        /// Toggles mach hold
        /// </summary>
        KEY_AP_PANEL_MACH_HOLD,
        /// <summary>
        /// Increments reference mach
        /// </summary>
        KEY_AP_MACH_VAR_INC,
        /// <summary>
        /// Decrements reference mach
        /// </summary>
        KEY_AP_MACH_VAR_DEC,
        /// <summary>
        /// Toggles mach hold
        /// </summary>
        KEY_AP_MACH_HOLD,
        /// <summary>
        /// Sets reference altitude in meters
        /// </summary>
        KEY_AP_ALT_VAR_SET_METRIC,
        /// <summary>
        /// Sets reference vertical speed in feet per minute
        /// </summary>
        KEY_AP_VS_VAR_SET_ENGLISH,
        /// <summary>
        /// Sets airspeed reference in knots
        /// </summary>
        KEY_AP_SPD_VAR_SET,
        /// <summary>
        /// Sets mach reference
        /// </summary>
        KEY_AP_MACH_VAR_SET,
        /// <summary>
        /// Turns yaw damper on
        /// </summary>
        KEY_YAW_DAMPER_ON,
        /// <summary>
        /// Turns yaw damper off
        /// </summary>
        KEY_YAW_DAMPER_OFF,
        /// <summary>
        /// Sets yaw damper on/off (1,0)
        /// </summary>
        KEY_YAW_DAMPER_SET,
        /// <summary>
        /// Turns airspeed hold on
        /// </summary>
        KEY_AP_AIRSPEED_ON,
        /// <summary>
        /// Turns airspeed hold off
        /// </summary>
        KEY_AP_AIRSPEED_OFF,
        /// <summary>
        /// Sets airspeed hold on/off (1,0)
        /// </summary>
        KEY_AP_AIRSPEED_SET,
        /// <summary>
        /// Turns mach hold on
        /// </summary>
        KEY_AP_MACH_ON,
        /// <summary>
        /// Turns mach hold off
        /// </summary>
        KEY_AP_MACH_OFF,
        /// <summary>
        /// Sets mach hold on/off (1,0)
        /// </summary>
        KEY_AP_MACH_SET,
        /// <summary>
        /// Turns altitude hold mode on (without capturing current altitude)
        /// </summary>
        KEY_AP_PANEL_ALTITUDE_ON,
        /// <summary>
        /// Turns altitude hold mode off
        /// </summary>
        KEY_AP_PANEL_ALTITUDE_OFF,
        /// <summary>
        /// Sets altitude hold mode on/off (1,0)
        /// </summary>
        KEY_AP_PANEL_ALTITUDE_SET,
        /// <summary>
        /// Turns heading mode on (without capturing current heading)
        /// </summary>
        KEY_AP_PANEL_HEADING_ON,
        /// <summary>
        /// Turns heading mode off
        /// </summary>
        KEY_AP_PANEL_HEADING_OFF,
        /// <summary>
        /// Set heading mode on/off (1,0)
        /// </summary>
        KEY_AP_PANEL_HEADING_SET,
        /// <summary>
        /// Turns on mach hold
        /// </summary>
        KEY_AP_PANEL_MACH_ON,
        /// <summary>
        /// Turns off mach hold
        /// </summary>
        KEY_AP_PANEL_MACH_OFF,
        /// <summary>
        /// Sets mach hold on/off (1,0)
        /// </summary>
        KEY_AP_PANEL_MACH_SET,
        /// <summary>
        /// Turns on speed hold mode
        /// </summary>
        KEY_AP_PANEL_SPEED_ON,
        /// <summary>
        /// Turns off speed hold mode
        /// </summary>
        KEY_AP_PANEL_SPEED_OFF,
        /// <summary>
        /// Set speed hold mode on/off (1,0)
        /// </summary>
        KEY_AP_PANEL_SPEED_SET,
        /// <summary>
        /// Sets altitude reference in feet
        /// </summary>
        KEY_AP_ALT_VAR_SET_ENGLISH,
        /// <summary>
        /// Sets vertical speed reference in meters per minute
        /// </summary>
        KEY_AP_VS_VAR_SET_METRIC,
        /// <summary>
        /// Toggles flight director on/off
        /// </summary>
        KEY_TOGGLE_FLIGHT_DIRECTOR,
        /// <summary>
        /// Synchronizes flight director pitch with current aircraft pitch
        /// </summary>
        KEY_SYNC_FLIGHT_DIRECTOR_PITCH,
        /// <summary>
        /// Increments autobrake level
        /// </summary>
        KEY_INC_AUTOBRAKE_CONTROL,
        /// <summary>
        /// Decrements autobrake level
        /// </summary>
        KEY_DEC_AUTOBRAKE_CONTROL,
        /// <summary>
        /// Turns airspeed hold mode on with current airspeed
        /// </summary>
        KEY_AUTOPILOT_AIRSPEED_HOLD_CURRENT,
        /// <summary>
        /// Sets mach hold reference to current mach
        /// </summary>
        KEY_AUTOPILOT_MACH_HOLD_CURRENT,
        /// <summary>
        /// Sets the nav (1 or 2) which is used by the Nav hold modes
        /// </summary>
        KEY_AP_NAV_SELECT_SET,
        /// <summary>
        /// Selects the heading bug for use with +/-
        /// </summary>
        KEY_HEADING_BUG_SELECT,
        /// <summary>
        /// Selects the altitude reference for use with +/-
        /// </summary>
        KEY_ALTITUDE_BUG_SELECT,
        /// <summary>
        /// Selects the vertical speed reference for use with +/-
        /// </summary>
        KEY_VSI_BUG_SELECT,
        /// <summary>
        /// Selects the airspeed reference for use with +/-
        /// </summary>
        KEY_AIRSPEED_BUG_SELECT,
        /// <summary>
        /// Increments the pitch reference for pitch hold mode
        /// </summary>
        KEY_AP_PITCH_REF_INC_UP,
        /// <summary>
        /// Decrements the pitch reference for pitch hold mode
        /// </summary>
        KEY_AP_PITCH_REF_INC_DN,
        /// <summary>
        /// Selects pitch reference for use with +/-
        /// </summary>
        KEY_AP_PITCH_REF_SELECT,
        /// <summary>
        /// Toggle attitude hold mode
        /// </summary>
        KEY_AP_ATT_HOLD,
        /// <summary>
        /// Toggles localizer (only) hold mode
        /// </summary>
        KEY_AP_LOC_HOLD,
        /// <summary>
        /// Toggles approach hold (localizer and glide-slope)
        /// </summary>
        KEY_AP_APR_HOLD,
        /// <summary>
        /// Toggles heading hold mode
        /// </summary>
        KEY_AP_HDG_HOLD,
        /// <summary>
        /// Toggles altitude hold mode
        /// </summary>
        KEY_AP_ALT_HOLD,
        /// <summary>
        /// Toggles wing leveler mode
        /// </summary>
        KEY_AP_WING_LEVELER,
        /// <summary>
        /// Toggles the backcourse mode for the localizer hold
        /// </summary>
        KEY_AP_BC_HOLD,
        /// <summary>
        /// Toggles the nav hold mode
        /// </summary>
        KEY_AP_NAV1_HOLD,
        /// <summary>
        /// Autopilot max bank angle increment.
        /// </summary>
        KEY_AP_MAX_BANK_INC,
        /// <summary>
        /// Autopilot max bank angle decrement.
        /// </summary>
        KEY_AP_MAX_BANK_DEC,
        /// <summary>
        /// Autopilot, hold the N1 percentage at its current level.
        /// </summary>
        KEY_AP_N1_HOLD,
        /// <summary>
        /// Increment the autopilot N1 reference.
        /// </summary>
        KEY_AP_N1_REF_INC,
        /// <summary>
        /// Decrement the autopilot N1 reference.
        /// </summary>
        KEY_AP_N1_REF_DEC,
        /// <summary>
        /// Sets the autopilot N1 reference.
        /// </summary>
        KEY_AP_N1_REF_SET,
        /// <summary>
        /// Turn on or off the fly by wire Elevators and Ailerons computer.
        /// </summary>
        KEY_FLY_BY_WIRE_ELAC_TOGGLE,
        /// <summary>
        /// Turn on or off the fly by wire Flight Augmentation computer.
        /// </summary>
        KEY_FLY_BY_WIRE_FAC_TOGGLE,
        /// <summary>
        /// Turn on or off the fly by wire Spoilers and Elevators computer.
        /// </summary>
        KEY_FLY_BY_WIRE_SEC_TOGGLE,
        /// <summary>
        /// The primary flight display (PFD) should display its current flight plan.
        /// </summary>
        KEY_G1000_PFD_FLIGHTPLAN_BUTTON,
        /// <summary>
        /// Turn to the Procedure page.
        /// </summary>
        KEY_G1000_PFD_PROCEDURE_BUTTON,
        /// <summary>
        /// Zoom in on the current map.
        /// </summary>
        KEY_G1000_PFD_ZOOMIN_BUTTON,
        /// <summary>
        /// Zoom out on the current map.
        /// </summary>
        KEY_G1000_PFD_ZOOMOUT_BUTTON,
        /// <summary>
        /// Turn to the Direct To page.
        /// </summary>
        KEY_G1000_PFD_DIRECTTO_BUTTON,
        /// <summary>
        /// If a segmented flight plan is highlighted, activates the associated menu.
        /// </summary>
        KEY_G1000_PFD_MENU_BUTTON,
        /// <summary>
        /// Clears the current input.
        /// </summary>
        KEY_G1000_PFD_CLEAR_BUTTON,
        /// <summary>
        /// Enters the current input.
        /// </summary>
        KEY_G1000_PFD_ENTER_BUTTON,
        /// <summary>
        /// Turns on or off a screen cursor.
        /// </summary>
        KEY_G1000_PFD_CURSOR_BUTTON,
        /// <summary>
        /// Step up through the page groups.
        /// </summary>
        KEY_G1000_PFD_GROUP_KNOB_INC,
        /// <summary>
        /// Step down through the page groups.
        /// </summary>
        KEY_G1000_PFD_GROUP_KNOB_DEC,
        /// <summary>
        /// Step up through the individual pages.
        /// </summary>
        KEY_G1000_PFD_PAGE_KNOB_INC,
        /// <summary>
        /// Step down through the individual pages.
        /// </summary>
        KEY_G1000_PFD_PAGE_KNOB_DEC,
        /// <summary>
        /// Initiate the action for the icon displayed in the softkey position.
        /// </summary>
        KEY_G1000_PFD_SOFTKEY1,
        /// <summary>
        /// The multi-function display (MFD) should display its current flight plan.
        /// </summary>
        KEY_G1000_MFD_FLIGHTPLAN_BUTTON,
        /// <summary>
        /// Turn to the Procedure page.
        /// </summary>
        KEY_G1000_MFD_PROCEDURE_BUTTON,
        /// <summary>
        /// Zoom in on the current map.
        /// </summary>
        KEY_G1000_MFD_ZOOMIN_BUTTON,
        /// <summary>
        /// Zoom out on the current map.
        /// </summary>
        KEY_G1000_MFD_ZOOMOUT_BUTTON,
        /// <summary>
        /// Turn to the Direct To page.
        /// </summary>
        KEY_G1000_MFD_DIRECTTO_BUTTON,
        /// <summary>
        /// If a segmented flight plan is highlighted, activates the associated menu.
        /// </summary>
        KEY_G1000_MFD_MENU_BUTTON,
        /// <summary>
        /// Clears the current input.
        /// </summary>
        KEY_G1000_MFD_CLEAR_BUTTON,
        /// <summary>
        /// Enters the current input.
        /// </summary>
        KEY_G1000_MFD_ENTER_BUTTON,
        /// <summary>
        /// Turns on or off a screen cursor.
        /// </summary>
        KEY_G1000_MFD_CURSOR_BUTTON,
        /// <summary>
        /// Step up through the page groups.
        /// </summary>
        KEY_G1000_MFD_GROUP_KNOB_INC,
        /// <summary>
        /// Step down through the page groups.
        /// </summary>
        KEY_G1000_MFD_GROUP_KNOB_DEC,
        /// <summary>
        /// Step up through the individual pages.
        /// </summary>
        KEY_G1000_MFD_PAGE_KNOB_INC,
        /// <summary>
        /// Step down through the individual pages.
        /// </summary>
        KEY_G1000_MFD_PAGE_KNOB_DEC,
        /// <summary>
        /// Initiate the action for the icon displayed in the softkey position.
        /// </summary>
        KEY_G1000_MFD_SOFTKEY1,
        /// <summary>
        /// Turns selector 1 to OFF position
        /// </summary>
        KEY_FUEL_SELECTOR_OFF,
        /// <summary>
        /// Turns selector 1 to ALL position
        /// </summary>
        KEY_FUEL_SELECTOR_ALL,
        /// <summary>
        /// Turns selector 1 to LEFT position (burns from tip then aux then main)
        /// </summary>
        KEY_FUEL_SELECTOR_LEFT,
        /// <summary>
        /// Turns selector 1 to RIGHT position (burns from tip then aux then main)
        /// </summary>
        KEY_FUEL_SELECTOR_RIGHT,
        /// <summary>
        /// Turns selector 1 to LEFT AUX position
        /// </summary>
        KEY_FUEL_SELECTOR_LEFT_AUX,
        /// <summary>
        /// Turns selector 1 to RIGHT AUX position
        /// </summary>
        KEY_FUEL_SELECTOR_RIGHT_AUX,
        /// <summary>
        /// Turns selector 1 to CENTER position
        /// </summary>
        KEY_FUEL_SELECTOR_CENTER,
        /// <summary>
        /// Sets selector 1 position (see code list below)
        /// </summary>
        KEY_FUEL_SELECTOR_SET,
        /// <summary>
        /// Turns selector 2 to OFF position
        /// </summary>
        KEY_FUEL_SELECTOR_2_OFF,
        /// <summary>
        /// Turns selector 2 to ALL position
        /// </summary>
        KEY_FUEL_SELECTOR_2_ALL,
        /// <summary>
        /// Turns selector 2 to LEFT position (burns from tip then aux then main)
        /// </summary>
        KEY_FUEL_SELECTOR_2_LEFT,
        /// <summary>
        /// Turns selector 2 to RIGHT position (burns from tip then aux then main)
        /// </summary>
        KEY_FUEL_SELECTOR_2_RIGHT,
        /// <summary>
        /// Turns selector 2 to LEFT AUX position
        /// </summary>
        KEY_FUEL_SELECTOR_2_LEFT_AUX,
        /// <summary>
        /// Turns selector 2 to RIGHT AUX position
        /// </summary>
        KEY_FUEL_SELECTOR_2_RIGHT_AUX,
        /// <summary>
        /// Turns selector 2 to CENTER position
        /// </summary>
        KEY_FUEL_SELECTOR_2_CENTER,
        /// <summary>
        /// Sets selector 2 position (see code list below)
        /// </summary>
        KEY_FUEL_SELECTOR_2_SET,
        /// <summary>
        /// Turns selector 3 to OFF position
        /// </summary>
        KEY_FUEL_SELECTOR_3_OFF,
        /// <summary>
        /// Turns selector 3 to ALL position
        /// </summary>
        KEY_FUEL_SELECTOR_3_ALL,
        /// <summary>
        /// Turns selector 3 to LEFT position (burns from tip then aux then main)
        /// </summary>
        KEY_FUEL_SELECTOR_3_LEFT,
        /// <summary>
        /// Turns selector 3 to RIGHT position (burns from tip then aux then main)
        /// </summary>
        KEY_FUEL_SELECTOR_3_RIGHT,
        /// <summary>
        /// Turns selector 3 to LEFT AUX position
        /// </summary>
        KEY_FUEL_SELECTOR_3_LEFT_AUX,
        /// <summary>
        /// Turns selector 3 to RIGHT AUX position
        /// </summary>
        KEY_FUEL_SELECTOR_3_RIGHT_AUX,
        /// <summary>
        /// Turns selector 3 to CENTER position
        /// </summary>
        KEY_FUEL_SELECTOR_3_CENTER,
        /// <summary>
        /// Sets selector 3 position (see code list below)
        /// </summary>
        KEY_FUEL_SELECTOR_3_SET,
        /// <summary>
        /// Turns selector 4 to OFF position
        /// </summary>
        KEY_FUEL_SELECTOR_4_OFF,
        /// <summary>
        /// Turns selector 4 to ALL position
        /// </summary>
        KEY_FUEL_SELECTOR_4_ALL,
        /// <summary>
        /// Turns selector 4 to LEFT position (burns from tip then aux then main)
        /// </summary>
        KEY_FUEL_SELECTOR_4_LEFT,
        /// <summary>
        /// Turns selector 4 to RIGHT position (burns from tip then aux then main)
        /// </summary>
        KEY_FUEL_SELECTOR_4_RIGHT,
        /// <summary>
        /// Turns selector 4 to LEFT AUX position
        /// </summary>
        KEY_FUEL_SELECTOR_4_LEFT_AUX,
        /// <summary>
        /// Turns selector 4 to RIGHT AUX position
        /// </summary>
        KEY_FUEL_SELECTOR_4_RIGHT_AUX,
        /// <summary>
        /// Turns selector 4 to CENTER position
        /// </summary>
        KEY_FUEL_SELECTOR_4_CENTER,
        /// <summary>
        /// Sets selector 4 position (see code list below)
        /// </summary>
        KEY_FUEL_SELECTOR_4_SET,
        /// <summary>
        /// "Opens cross feed valve (when used in conjunction with ""isolate"" tank)"
        /// </summary>
        KEY_CROSS_FEED_OPEN,
        /// <summary>
        /// "Toggles crossfeed valve (when used in conjunction with ""isolate"" tank)"
        /// </summary>
        KEY_CROSS_FEED_TOGGLE,
        /// <summary>
        /// "Closes crossfeed valve (when used in conjunction with ""isolate"" tank)"
        /// </summary>
        KEY_CROSS_FEED_OFF,
        /// <summary>
        /// Set to True or False. The switch can only be set to True if fuel_dump_rate is specified in the aircraft configuration file, which indicates that a fuel dump system exists.
        /// </summary>
        KEY_FUEL_DUMP_SWITCH_SET,
        /// <summary>
        /// Toggle the anti-detonation valve. Pass a value to determine which tank, if there are multiple tanks, to use. Tanks are indexed from 1. Refer to the document Notes on Aircraft Systems.
        /// </summary>
        KEY_TOGGLE_ANTIDETONATION_TANK_VALVE,
        /// <summary>
        /// Toggle the nitrous valve. Pass a value to determine which tank, if there are multiple tanks, to use. Tanks are indexed from 1.
        /// </summary>
        KEY_TOGGLE_NITROUS_TANK_VALVE,
        /// <summary>
        /// Fully repair and refuel the user aircraft. Ignored if flight realism is enforced.
        /// </summary>
        KEY_REPAIR_AND_REFUEL,
        /// <summary>
        /// Turns on or off the fuel dump switch.
        /// </summary>
        KEY_FUEL_DUMP_TOGGLE,
        /// <summary>
        /// Request a fuel truck. The aircraft must be in a parking spot for this to be successful.
        /// </summary>
        KEY_REQUEST_FUEL,
        /// <summary>
        /// Sets the fuel selector. Fuel will be taken in the order left tip, left aux,then main fuel tanks.
        /// </summary>
        KEY_FUEL_SELECTOR_LEFT_MAIN,
        /// <summary>
        /// Sets the fuel selector for engine 2.
        /// </summary>
        KEY_FUEL_SELECTOR_2_LEFT_MAIN,
        /// <summary>
        /// Sets the fuel selector for engine 3.
        /// </summary>
        KEY_FUEL_SELECTOR_3_LEFT_MAIN,
        /// <summary>
        /// Sets the fuel selector for engine 4.
        /// </summary>
        KEY_FUEL_SELECTOR_4_LEFT_MAIN,
        /// <summary>
        /// Sets the fuel selector. Fuel will be taken in the order right tip, right aux,then main fuel tanks.
        /// </summary>
        KEY_FUEL_SELECTOR_RIGHT_MAIN,
        /// <summary>
        /// Sets the fuel selector for engine 2.
        /// </summary>
        KEY_FUEL_SELECTOR_2_RIGHT_MAIN,
        /// <summary>
        /// Sets the fuel selector for engine 3.
        /// </summary>
        KEY_FUEL_SELECTOR_3_RIGHT_MAIN,
        /// <summary>
        /// Sets the fuel selector for engine 4.
        /// </summary>
        KEY_FUEL_SELECTOR_4_RIGHT_MAIN,
        /// <summary>
        /// Sequentially selects the transponder digits for use with +/-.
        /// </summary>
        KEY_XPNDR,
        /// <summary>
        /// Sequentially selects the ADF tuner digits for use with +/-. Follow byKEY_SELECT_2 for ADF 2.
        /// </summary>
        KEY_ADF,
        /// <summary>
        /// Selects the DME for use with +/-
        /// </summary>
        KEY_DME,
        /// <summary>
        /// Sequentially selects the COM tuner digits for use with +/-. Follow byKEY_SELECT_2 for COM 2.
        /// </summary>
        KEY_COM_RADIO,
        /// <summary>
        /// Sequentially selects the VOR OBS for use with +/-. Follow by KEY_SELECT_2 for VOR 2.
        /// </summary>
        KEY_VOR_OBS,
        /// <summary>
        /// Sequentially selects the NAV tuner digits for use with +/-. Follow byKEY_SELECT_2 for NAV 2.
        /// </summary>
        KEY_NAV_RADIO,
        /// <summary>
        /// Decrements COM by one MHz
        /// </summary>
        KEY_COM_RADIO_WHOLE_DEC,
        /// <summary>
        /// Increments COM by one MHz
        /// </summary>
        KEY_COM_RADIO_WHOLE_INC,
        /// <summary>
        /// Decrements COM by 25 KHz
        /// </summary>
        KEY_COM_RADIO_FRACT_DEC,
        /// <summary>
        /// Increments COM by 25 KHz
        /// </summary>
        KEY_COM_RADIO_FRACT_INC,
        /// <summary>
        /// Decrements Nav 1 by one MHz
        /// </summary>
        KEY_NAV1_RADIO_WHOLE_DEC,
        /// <summary>
        /// Increments Nav 1 by one MHz
        /// </summary>
        KEY_NAV1_RADIO_WHOLE_INC,
        /// <summary>
        /// Decrements Nav 1 by 25 KHz
        /// </summary>
        KEY_NAV1_RADIO_FRACT_DEC,
        /// <summary>
        /// Increments Nav 1 by 25 KHz
        /// </summary>
        KEY_NAV1_RADIO_FRACT_INC,
        /// <summary>
        /// Decrements Nav 2 by one MHz
        /// </summary>
        KEY_NAV2_RADIO_WHOLE_DEC,
        /// <summary>
        /// Increments Nav 2 by one MHz
        /// </summary>
        KEY_NAV2_RADIO_WHOLE_INC,
        /// <summary>
        /// Decrements Nav 2 by 25 KHz
        /// </summary>
        KEY_NAV2_RADIO_FRACT_DEC,
        /// <summary>
        /// Increments Nav 2 by 25 KHz
        /// </summary>
        KEY_NAV2_RADIO_FRACT_INC,
        /// <summary>
        /// Increments ADF by 100 KHz
        /// </summary>
        KEY_ADF_100_INC,
        /// <summary>
        /// Increments ADF by 10 KHz
        /// </summary>
        KEY_ADF_10_INC,
        /// <summary>
        /// Increments ADF by 1 KHz
        /// </summary>
        KEY_ADF_1_INC,
        /// <summary>
        /// Increments first digit of transponder
        /// </summary>
        KEY_XPNDR_1000_INC,
        /// <summary>
        /// Increments second digit of transponder
        /// </summary>
        KEY_XPNDR_100_INC,
        /// <summary>
        /// Increments third digit of transponder
        /// </summary>
        KEY_XPNDR_10_INC,
        /// <summary>
        /// Increments fourth digit of transponder
        /// </summary>
        KEY_XPNDR_1_INC,
        /// <summary>
        /// Decrements the VOR 1 OBS setting
        /// </summary>
        KEY_VOR1_OBI_DEC,
        /// <summary>
        /// Increments the VOR 1 OBS setting
        /// </summary>
        KEY_VOR1_OBI_INC,
        /// <summary>
        /// Decrements the VOR 2 OBS setting
        /// </summary>
        KEY_VOR2_OBI_DEC,
        /// <summary>
        /// Increments the VOR 2 OBS setting
        /// </summary>
        KEY_VOR2_OBI_INC,
        /// <summary>
        /// Decrements ADF by 100 KHz
        /// </summary>
        KEY_ADF_100_DEC,
        /// <summary>
        /// Decrements ADF by 10 KHz
        /// </summary>
        KEY_ADF_10_DEC,
        /// <summary>
        /// Decrements ADF by 1 KHz
        /// </summary>
        KEY_ADF_1_DEC,
        /// <summary>
        /// Sets COM frequency (BCD Hz)
        /// </summary>
        KEY_COM_RADIO_SET,
        /// <summary>
        /// Sets NAV 1 frequency (BCD Hz)
        /// </summary>
        KEY_NAV1_RADIO_SET,
        /// <summary>
        /// Sets NAV 2 frequency (BCD Hz)
        /// </summary>
        KEY_NAV2_RADIO_SET,
        /// <summary>
        /// Sets ADF frequency (BCD Hz)
        /// </summary>
        KEY_ADF_SET,
        /// <summary>
        /// Sets transponder code (BCD)
        /// </summary>
        KEY_XPNDR_SET,
        /// <summary>
        /// Sets OBS 1 (0 to 360)
        /// </summary>
        KEY_VOR1_SET,
        /// <summary>
        /// Sets OBS 2 (0 to 360)
        /// </summary>
        KEY_VOR2_SET,
        /// <summary>
        /// Sets DME display to Nav 1
        /// </summary>
        KEY_DME1_TOGGLE,
        /// <summary>
        /// Sets DME display to Nav 2
        /// </summary>
        KEY_DME2_TOGGLE,
        /// <summary>
        /// Turns NAV 1 ID off
        /// </summary>
        KEY_RADIO_VOR1_IDENT_DISABLE,
        /// <summary>
        /// Turns NAV 2 ID off
        /// </summary>
        KEY_RADIO_VOR2_IDENT_DISABLE,
        /// <summary>
        /// Turns DME 1 ID off
        /// </summary>
        KEY_RADIO_DME1_IDENT_DISABLE,
        /// <summary>
        /// Turns DME 2 ID off
        /// </summary>
        KEY_RADIO_DME2_IDENT_DISABLE,
        /// <summary>
        /// Turns ADF 1 ID off
        /// </summary>
        KEY_RADIO_ADF_IDENT_DISABLE,
        /// <summary>
        /// Turns NAV 1 ID on
        /// </summary>
        KEY_RADIO_VOR1_IDENT_ENABLE,
        /// <summary>
        /// Turns NAV 2 ID on
        /// </summary>
        KEY_RADIO_VOR2_IDENT_ENABLE,
        /// <summary>
        /// Turns DME 1 ID on
        /// </summary>
        KEY_RADIO_DME1_IDENT_ENABLE,
        /// <summary>
        /// Turns DME 2 ID on
        /// </summary>
        KEY_RADIO_DME2_IDENT_ENABLE,
        /// <summary>
        /// Turns ADF 1 ID on
        /// </summary>
        KEY_RADIO_ADF_IDENT_ENABLE,
        /// <summary>
        /// Toggles NAV 1 ID
        /// </summary>
        KEY_RADIO_VOR1_IDENT_TOGGLE,
        /// <summary>
        /// Toggles NAV 2 ID
        /// </summary>
        KEY_RADIO_VOR2_IDENT_TOGGLE,
        /// <summary>
        /// Toggles DME 1 ID
        /// </summary>
        KEY_RADIO_DME1_IDENT_TOGGLE,
        /// <summary>
        /// Toggles DME 2 ID
        /// </summary>
        KEY_RADIO_DME2_IDENT_TOGGLE,
        /// <summary>
        /// Toggles ADF 1 ID
        /// </summary>
        KEY_RADIO_ADF_IDENT_TOGGLE,
        /// <summary>
        /// Sets NAV 1 ID (on/off)
        /// </summary>
        KEY_RADIO_VOR1_IDENT_SET,
        /// <summary>
        /// Sets NAV 2 ID (on/off)
        /// </summary>
        KEY_RADIO_VOR2_IDENT_SET,
        /// <summary>
        /// Sets DME 1 ID (on/off)
        /// </summary>
        KEY_RADIO_DME1_IDENT_SET,
        /// <summary>
        /// Sets DME 2 ID (on/off)
        /// </summary>
        KEY_RADIO_DME2_IDENT_SET,
        /// <summary>
        /// Sets ADF 1 ID (on/off)
        /// </summary>
        KEY_RADIO_ADF_IDENT_SET,
        /// <summary>
        /// Increments ADF card
        /// </summary>
        KEY_ADF_CARD_INC,
        /// <summary>
        /// Decrements ADF card
        /// </summary>
        KEY_ADF_CARD_DEC,
        /// <summary>
        /// Sets ADF card (0-360)
        /// </summary>
        KEY_ADF_CARD_SET,
        /// <summary>
        /// Toggles between NAV 1 and NAV 2
        /// </summary>
        KEY_DME_TOGGLE,
        /// <summary>
        /// Sets the avionics master switch
        /// </summary>
        KEY_AVIONICS_MASTER_SET,
        /// <summary>
        /// Toggles the avionics master switch
        /// </summary>
        KEY_TOGGLE_AVIONICS_MASTER,
        /// <summary>
        /// Sets COM 1 standby frequency (BCD Hz)
        /// </summary>
        KEY_COM_STBY_RADIO_SET,
        /// <summary>
        /// Swaps COM 1 frequency with standby
        /// </summary>
        KEY_COM_STBY_RADIO_SWITCH_TO,
        /// <summary>
        /// Decrement COM 1 frequency by 25 KHz, and carry when digit wraps
        /// </summary>
        KEY_COM_RADIO_FRACT_DEC_CARRY,
        /// <summary>
        /// Increment COM 1 frequency by 25 KHz, and carry when digit wraps
        /// </summary>
        KEY_COM_RADIO_FRACT_INC_CARRY,
        /// <summary>
        /// Decrement COM 2 frequency by 1 MHz, with no carry when digit wraps
        /// </summary>
        KEY_COM2_RADIO_WHOLE_DEC,
        /// <summary>
        /// Increment COM 2 frequency by 1 MHz, with no carry when digit wraps
        /// </summary>
        KEY_COM2_RADIO_WHOLE_INC,
        /// <summary>
        /// Decrement COM 2 frequency by 25 KHz, with no carry when digit wraps
        /// </summary>
        KEY_COM2_RADIO_FRACT_DEC,
        /// <summary>
        /// Decrement COM 2 frequency by 25 KHz, and carry when digit wraps
        /// </summary>
        KEY_COM2_RADIO_FRACT_DEC_CARRY,
        /// <summary>
        /// Increment COM 2 frequency by 25 KHz, with no carry when digit wraps
        /// </summary>
        KEY_COM2_RADIO_FRACT_INC,
        /// <summary>
        /// Increment COM 2 frequency by 25 KHz, and carry when digit wraps
        /// </summary>
        KEY_COM2_RADIO_FRACT_INC_CARRY,
        /// <summary>
        /// Sets COM 2 frequency (BCD Hz)
        /// </summary>
        KEY_COM2_RADIO_SET,
        /// <summary>
        /// Sets COM 2 standby frequency (BCD Hz)
        /// </summary>
        KEY_COM2_STBY_RADIO_SET,
        /// <summary>
        /// Swaps COM 2 frequency with standby
        /// </summary>
        KEY_COM2_RADIO_SWAP,
        /// <summary>
        /// Decrement NAV 1 frequency by 50 KHz, and carry when digit wraps
        /// </summary>
        KEY_NAV1_RADIO_FRACT_DEC_CARRY,
        /// <summary>
        /// Increment NAV 1 frequency by 50 KHz, and carry when digit wraps
        /// </summary>
        KEY_NAV1_RADIO_FRACT_INC_CARRY,
        /// <summary>
        /// Sets NAV 1 standby frequency (BCD Hz)
        /// </summary>
        KEY_NAV1_STBY_SET,
        /// <summary>
        /// Swaps NAV 1 frequency with standby
        /// </summary>
        KEY_NAV1_RADIO_SWAP,
        /// <summary>
        /// Decrement NAV 2 frequency by 50 KHz, and carry when digit wraps
        /// </summary>
        KEY_NAV2_RADIO_FRACT_DEC_CARRY,
        /// <summary>
        /// Increment NAV 2 frequency by 50 KHz, and carry when digit wraps
        /// </summary>
        KEY_NAV2_RADIO_FRACT_INC_CARRY,
        /// <summary>
        /// Sets NAV 2 standby frequency (BCD Hz)
        /// </summary>
        KEY_NAV2_STBY_SET,
        /// <summary>
        /// Swaps NAV 2 frequency with standby
        /// </summary>
        KEY_NAV2_RADIO_SWAP,
        /// <summary>
        /// Decrements ADF 1 by 0.1 KHz.
        /// </summary>
        KEY_ADF1_RADIO_TENTHS_DEC,
        /// <summary>
        /// Increments ADF 1 by 0.1 KHz.
        /// </summary>
        KEY_ADF1_RADIO_TENTHS_INC,
        /// <summary>
        /// Decrements first digit of transponder
        /// </summary>
        KEY_XPNDR_1000_DEC,
        /// <summary>
        /// Decrements second digit of transponder
        /// </summary>
        KEY_XPNDR_100_DEC,
        /// <summary>
        /// Decrements third digit of transponder
        /// </summary>
        KEY_XPNDR_10_DEC,
        /// <summary>
        /// Decrements fourth digit of transponder
        /// </summary>
        KEY_XPNDR_1_DEC,
        /// <summary>
        /// Decrements fourth digit of transponder, and with carry.
        /// </summary>
        KEY_XPNDR_DEC_CARRY,
        /// <summary>
        /// Increments fourth digit of transponder, and with carry.
        /// </summary>
        KEY_XPNDR_INC_CARRY,
        /// <summary>
        /// Decrements ADF 1 frequency by 0.1 KHz, with carry
        /// </summary>
        KEY_ADF_FRACT_DEC_CARRY,
        /// <summary>
        /// Increments ADF 1 frequency by 0.1 KHz, with carry
        /// </summary>
        KEY_ADF_FRACT_INC_CARRY,
        /// <summary>
        /// Selects COM 1 to transmit
        /// </summary>
        KEY_COM1_TRANSMIT_SELECT,
        /// <summary>
        /// Selects COM 2 to transmit
        /// </summary>
        KEY_COM2_TRANSMIT_SELECT,
        /// <summary>
        /// Toggles all COM radios to receive on
        /// </summary>
        KEY_COM_RECEIVE_ALL_TOGGLE,
        /// <summary>
        /// Sets whether to receive on all COM radios (1,0)
        /// </summary>
        KEY_COM_RECEIVE_ALL_SET,
        /// <summary>
        /// Toggles marker beacon sound on/off
        /// </summary>
        KEY_MARKER_SOUND_TOGGLE,
        /// <summary>
        /// Sets ADF 1 frequency (BCD Hz)
        /// </summary>
        KEY_ADF_COMPLETE_SET,
        /// <summary>
        /// Increments ADF 1 by 1 KHz, with carry as digits wrap.
        /// </summary>
        KEY_ADF_WHOLE_INC,
        /// <summary>
        /// Decrements ADF 1 by 1 KHz, with carry as digits wrap.
        /// </summary>
        KEY_ADF_WHOLE_DEC,
        /// <summary>
        /// Increments the ADF 2 frequency 100 digit, with wrapping
        /// </summary>
        KEY_ADF2_100_INC,
        /// <summary>
        /// Increments the ADF 2 frequency 10 digit, with wrapping
        /// </summary>
        KEY_ADF2_10_INC,
        /// <summary>
        /// Increments the ADF 2 frequency 1 digit, with wrapping
        /// </summary>
        KEY_ADF2_1_INC,
        /// <summary>
        /// Increments ADF 2 frequency 1/10 digit, with wrapping
        /// </summary>
        KEY_ADF2_RADIO_TENTHS_INC,
        /// <summary>
        /// Decrements the ADF 2 frequency 100 digit, with wrapping
        /// </summary>
        KEY_ADF2_100_DEC,
        /// <summary>
        /// Decrements the ADF 2 frequency 10 digit, with wrapping
        /// </summary>
        KEY_ADF2_10_DEC,
        /// <summary>
        /// Decrements the ADF 2 frequency 1 digit, with wrapping
        /// </summary>
        KEY_ADF2_1_DEC,
        /// <summary>
        /// Decrements ADF 2 frequency 1/10 digit, with wrapping
        /// </summary>
        KEY_ADF2_RADIO_TENTHS_DEC,
        /// <summary>
        /// Increments ADF 2 by 1 KHz, with carry as digits wrap.
        /// </summary>
        KEY_ADF2_WHOLE_INC,
        /// <summary>
        /// Decrements ADF 2 by 1 KHz, with carry as digits wrap.
        /// </summary>
        KEY_ADF2_WHOLE_DEC,
        /// <summary>
        /// Decrements ADF 2 frequency by 0.1 KHz, with carry
        /// </summary>
        KEY_ADF2_FRACT_INC_CARRY,
        /// <summary>
        /// Increments ADF 2 frequency by 0.1 KHz, with carry
        /// </summary>
        KEY_ADF2_FRACT_DEC_CARRY,
        /// <summary>
        /// Sets ADF 1 frequency (BCD Hz)
        /// </summary>
        KEY_ADF2_COMPLETE_SET,
        /// <summary>
        /// Turns ADF 2 ID off
        /// </summary>
        KEY_RADIO_ADF2_IDENT_DISABLE,
        /// <summary>
        /// Turns ADF 2 ID on
        /// </summary>
        KEY_RADIO_ADF2_IDENT_ENABLE,
        /// <summary>
        /// Toggles ADF 2 ID
        /// </summary>
        KEY_RADIO_ADF2_IDENT_TOGGLE,
        /// <summary>
        /// Sets ADF 2 ID on/off (1,0)
        /// </summary>
        KEY_RADIO_ADF2_IDENT_SET,
        /// <summary>
        /// Swaps frequency with standby on whichever NAV or COM radio is selected.
        /// </summary>
        KEY_FREQUENCY_SWAP,
        /// <summary>
        /// Toggles between GPS and NAV 1 driving NAV 1 OBS display (and AP)
        /// </summary>
        KEY_TOGGLE_GPS_DRIVES_NAV1,
        /// <summary>
        /// Toggles power button
        /// </summary>
        KEY_GPS_POWER_BUTTON,
        /// <summary>
        /// Selects Nearest Airport Page
        /// </summary>
        KEY_GPS_NEAREST_BUTTON,
        /// <summary>
        /// Toggles automatic sequencing of waypoints
        /// </summary>
        KEY_GPS_OBS_BUTTON,
        /// <summary>
        /// Toggles the Message Page
        /// </summary>
        KEY_GPS_MSG_BUTTON,
        /// <summary>
        /// Triggers the pressing of the message button.
        /// </summary>
        KEY_GPS_MSG_BUTTON_DOWN,
        /// <summary>
        /// Triggers the release of the message button
        /// </summary>
        KEY_GPS_MSG_BUTTON_UP,
        /// <summary>
        /// Displays the programmed flightplan.
        /// </summary>
        KEY_GPS_FLIGHTPLAN_BUTTON,
        /// <summary>
        /// Displays terrain information on default display
        /// </summary>
        KEY_GPS_TERRAIN_BUTTON,
        /// <summary>
        /// Displays the approach procedure page.
        /// </summary>
        KEY_GPS_PROCEDURE_BUTTON,
        /// <summary>
        /// Zooms in default display
        /// </summary>
        KEY_GPS_ZOOMIN_BUTTON,
        /// <summary>
        /// Zooms out default display
        /// </summary>
        KEY_GPS_ZOOMOUT_BUTTON,
        /// <summary>
        /// "Brings up the ""Direct To"" page"
        /// </summary>
        KEY_GPS_DIRECTTO_BUTTON,
        /// <summary>
        /// Brings up page to select active legs in a flightplan.
        /// </summary>
        KEY_GPS_MENU_BUTTON,
        /// <summary>
        /// Clears entered data on a page
        /// </summary>
        KEY_GPS_CLEAR_BUTTON,
        /// <summary>
        /// Clears all data immediately
        /// </summary>
        KEY_GPS_CLEAR_ALL_BUTTON,
        /// <summary>
        /// Triggers the pressing of the Clear button
        /// </summary>
        KEY_GPS_CLEAR_BUTTON_DOWN,
        /// <summary>
        /// Triggers the release of the Clear button.
        /// </summary>
        KEY_GPS_CLEAR_BUTTON_UP,
        /// <summary>
        /// Approves entered data.
        /// </summary>
        KEY_GPS_ENTER_BUTTON,
        /// <summary>
        /// Selects GPS cursor
        /// </summary>
        KEY_GPS_CURSOR_BUTTON,
        /// <summary>
        /// Increments cursor
        /// </summary>
        KEY_GPS_GROUP_KNOB_INC,
        /// <summary>
        /// Decrements cursor
        /// </summary>
        KEY_GPS_GROUP_KNOB_DEC,
        /// <summary>
        /// Increments through pages
        /// </summary>
        KEY_GPS_PAGE_KNOB_INC,
        /// <summary>
        /// Decrements through pages
        /// </summary>
        KEY_GPS_PAGE_KNOB_DEC,
        /// <summary>
        /// Selects one of the two DME systems (1,2).
        /// </summary>
        KEY_DME_SELECT,
        /// <summary>
        /// Turns on the identification sound for the selected DME.
        /// </summary>
        KEY_RADIO_SELECTED_DME_IDENT_ENABLE,
        /// <summary>
        /// Turns off the identification sound for the selected DME.
        /// </summary>
        KEY_RADIO_SELECTED_DME_IDENT_DISABLE,
        /// <summary>
        /// Sets the DME identification sound to the given filename.
        /// </summary>
        KEY_RADIO_SELECTED_DME_IDENT_SET,
        /// <summary>
        /// Turns on or off the identification sound for the selected DME.
        /// </summary>
        KEY_RADIO_SELECTED_DME_IDENT_TOGGLE,
        /// <summary>
        /// Selects EGT bug for +/-
        /// </summary>
        KEY_EGT,
        /// <summary>
        /// Increments EGT bugs
        /// </summary>
        KEY_EGT_INC,
        /// <summary>
        /// Decrements EGT bugs
        /// </summary>
        KEY_EGT_DEC,
        /// <summary>
        /// Sets EGT bugs (0 to 32767)
        /// </summary>
        KEY_EGT_SET,
        /// <summary>
        /// Syncs altimeter setting to sea level pressure, or 29.92 if above 18000 feet
        /// </summary>
        KEY_BAROMETRIC,
        /// <summary>
        /// Increments heading indicator
        /// </summary>
        KEY_GYRO_DRIFT_INC,
        /// <summary>
        /// Decrements heading indicator
        /// </summary>
        KEY_GYRO_DRIFT_DEC,
        /// <summary>
        /// Increments altimeter setting
        /// </summary>
        KEY_KOHLSMAN_INC,
        /// <summary>
        /// Decrements altimeter setting
        /// </summary>
        KEY_KOHLSMAN_DEC,
        /// <summary>
        /// Sets altimeter setting (Millibars * 16)
        /// </summary>
        KEY_KOHLSMAN_SET,
        /// <summary>
        /// Increments airspeed indicators true airspeed reference card
        /// </summary>
        KEY_TRUE_AIRSPEED_CALIBRATE_INC,
        /// <summary>
        /// Decrements airspeed indicators true airspeed reference card
        /// </summary>
        KEY_TRUE_AIRSPEED_CALIBRATE_DEC,
        /// <summary>
        /// Sets airspeed indicators true airspeed reference card (degrees, where 0 is standard sea level conditions)
        /// </summary>
        KEY_TRUE_AIRSPEED_CAL_SET,
        /// <summary>
        /// Increments EGT bug 1
        /// </summary>
        KEY_EGT1_INC,
        /// <summary>
        /// Decrements EGT bug 1
        /// </summary>
        KEY_EGT1_DEC,
        /// <summary>
        /// Sets EGT bug 1 (0 to 32767)
        /// </summary>
        KEY_EGT1_SET,
        /// <summary>
        /// Increments EGT bug 2
        /// </summary>
        KEY_EGT2_INC,
        /// <summary>
        /// Decrements EGT bug 2
        /// </summary>
        KEY_EGT2_DEC,
        /// <summary>
        /// Sets EGT bug 2 (0 to 32767)
        /// </summary>
        KEY_EGT2_SET,
        /// <summary>
        /// Increments EGT bug 3
        /// </summary>
        KEY_EGT3_INC,
        /// <summary>
        /// Decrements EGT bug 3
        /// </summary>
        KEY_EGT3_DEC,
        /// <summary>
        /// Sets EGT bug 3 (0 to 32767)
        /// </summary>
        KEY_EGT3_SET,
        /// <summary>
        /// Increments EGT bug 4
        /// </summary>
        KEY_EGT4_INC,
        /// <summary>
        /// Decrements EGT bug 4
        /// </summary>
        KEY_EGT4_DEC,
        /// <summary>
        /// Sets EGT bug 4 (0 to 32767)
        /// </summary>
        KEY_EGT4_SET,
        /// <summary>
        /// Increments attitude indicator pitch reference bars
        /// </summary>
        KEY_ATTITUDE_BARS_POSITION_INC,
        /// <summary>
        /// Decrements attitude indicator pitch reference bars
        /// </summary>
        KEY_ATTITUDE_BARS_POSITION_DEC,
        /// <summary>
        /// Cages attitude indicator at 0 pitch and bank
        /// </summary>
        KEY_TOGGLE_ATTITUDE_CAGE,
        /// <summary>
        /// Resets max/min indicated G force to 1.0.
        /// </summary>
        KEY_RESET_G_FORCE_INDICATOR,
        /// <summary>
        /// Reset max indicated engine rpm to 0.
        /// </summary>
        KEY_RESET_MAX_RPM_INDICATOR,
        /// <summary>
        /// Sets heading indicator to 0 drift error.
        /// </summary>
        KEY_HEADING_GYRO_SET,
        /// <summary>
        /// Sets heading indicator drift angle (degrees).
        /// </summary>
        KEY_GYRO_DRIFT_SET,
        /// <summary>
        /// Toggle strobe lights
        /// </summary>
        KEY_STROBES_TOGGLE,
        /// <summary>
        /// Toggle all lights
        /// </summary>
        KEY_ALL_LIGHTS_TOGGLE,
        /// <summary>
        /// Toggle panel lights
        /// </summary>
        KEY_PANEL_LIGHTS_TOGGLE,
        /// <summary>
        /// Toggle landing lights
        /// </summary>
        KEY_LANDING_LIGHTS_TOGGLE,
        /// <summary>
        /// Rotate landing light up
        /// </summary>
        KEY_LANDING_LIGHT_UP,
        /// <summary>
        /// Rotate landing light down
        /// </summary>
        KEY_LANDING_LIGHT_DOWN,
        /// <summary>
        /// Rotate landing light left
        /// </summary>
        KEY_LANDING_LIGHT_LEFT,
        /// <summary>
        /// Rotate landing light right
        /// </summary>
        KEY_LANDING_LIGHT_RIGHT,
        /// <summary>
        /// Return landing light to default position
        /// </summary>
        KEY_LANDING_LIGHT_HOME,
        /// <summary>
        /// Turn strobe lights on
        /// </summary>
        KEY_STROBES_ON,
        /// <summary>
        /// Turn strobe light off
        /// </summary>
        KEY_STROBES_OFF,
        /// <summary>
        /// Set strobe lights on/off (1,0)
        /// </summary>
        KEY_STROBES_SET,
        /// <summary>
        /// Turn panel lights on
        /// </summary>
        KEY_PANEL_LIGHTS_ON,
        /// <summary>
        /// Turn panel lights off
        /// </summary>
        KEY_PANEL_LIGHTS_OFF,
        /// <summary>
        /// Set panel lights on/off (1,0)
        /// </summary>
        KEY_PANEL_LIGHTS_SET,
        /// <summary>
        /// Turn landing lights on
        /// </summary>
        KEY_LANDING_LIGHTS_ON,
        /// <summary>
        /// Turn landing lights off
        /// </summary>
        KEY_LANDING_LIGHTS_OFF,
        /// <summary>
        /// Set landing lights on/off (1,0)
        /// </summary>
        KEY_LANDING_LIGHTS_SET,
        /// <summary>
        /// Toggle beacon lights
        /// </summary>
        KEY_TOGGLE_BEACON_LIGHTS,
        /// <summary>
        /// Toggle taxi lights
        /// </summary>
        KEY_TOGGLE_TAXI_LIGHTS,
        /// <summary>
        /// Toggle logo lights
        /// </summary>
        KEY_TOGGLE_LOGO_LIGHTS,
        /// <summary>
        /// Toggle recognition lights
        /// </summary>
        KEY_TOGGLE_RECOGNITION_LIGHTS,
        /// <summary>
        /// Toggle wing lights
        /// </summary>
        KEY_TOGGLE_WING_LIGHTS,
        /// <summary>
        /// Toggle navigation lights
        /// </summary>
        KEY_TOGGLE_NAV_LIGHTS,
        /// <summary>
        /// Toggle cockpit/cabin lights
        /// </summary>
        KEY_TOGGLE_CABIN_LIGHTS,
        /// <summary>
        /// Toggle vacuum system failure
        /// </summary>
        KEY_TOGGLE_VACUUM_FAILURE,
        /// <summary>
        /// Toggle electrical system failure
        /// </summary>
        KEY_TOGGLE_ELECTRICAL_FAILURE,
        /// <summary>
        /// Toggles blocked pitot tube
        /// </summary>
        KEY_TOGGLE_PITOT_BLOCKAGE,
        /// <summary>
        /// Toggles blocked static port
        /// </summary>
        KEY_TOGGLE_STATIC_PORT_BLOCKAGE,
        /// <summary>
        /// Toggles hydraulic system failure
        /// </summary>
        KEY_TOGGLE_HYDRAULIC_FAILURE,
        /// <summary>
        /// Toggles brake failure (both)
        /// </summary>
        KEY_TOGGLE_TOTAL_BRAKE_FAILURE,
        /// <summary>
        /// Toggles left brake failure
        /// </summary>
        KEY_TOGGLE_LEFT_BRAKE_FAILURE,
        /// <summary>
        /// Toggles right brake failure
        /// </summary>
        KEY_TOGGLE_RIGHT_BRAKE_FAILURE,
        /// <summary>
        /// Toggle engine 1 failure
        /// </summary>
        KEY_TOGGLE_ENGINE1_FAILURE,
        /// <summary>
        /// Toggle engine 2 failure
        /// </summary>
        KEY_TOGGLE_ENGINE2_FAILURE,
        /// <summary>
        /// Toggle engine 3 failure
        /// </summary>
        KEY_TOGGLE_ENGINE3_FAILURE,
        /// <summary>
        /// Toggle engine 4 failure
        /// </summary>
        KEY_TOGGLE_ENGINE4_FAILURE,
        /// <summary>
        /// Toggle smoke system switch
        /// </summary>
        KEY_SMOKE_TOGGLE,
        /// <summary>
        /// Toggle gear handle
        /// </summary>
        KEY_GEAR_TOGGLE,
        /// <summary>
        /// Increment brake pressure
        /// </summary>
        KEY_BRAKES,
        /// <summary>
        /// Sets gear handle position up/down (0,1)
        /// </summary>
        KEY_GEAR_SET,
        /// <summary>
        /// Increments left brake pressure
        /// </summary>
        KEY_BRAKES_LEFT,
        /// <summary>
        /// Increments right brake pressure
        /// </summary>
        KEY_BRAKES_RIGHT,
        /// <summary>
        /// Toggles parking brake on/off
        /// </summary>
        KEY_PARKING_BRAKES,
        /// <summary>
        /// Increments emergency gear extension
        /// </summary>
        KEY_GEAR_PUMP,
        /// <summary>
        /// Toggles pitot heat switch
        /// </summary>
        KEY_PITOT_HEAT_TOGGLE,
        /// <summary>
        /// Turns smoke system on
        /// </summary>
        KEY_SMOKE_ON,
        /// <summary>
        /// Turns smoke system off
        /// </summary>
        KEY_SMOKE_OFF,
        /// <summary>
        /// Sets smoke system on/off (1,0)
        /// </summary>
        KEY_SMOKE_SET,
        /// <summary>
        /// Turns pitot heat switch on
        /// </summary>
        KEY_PITOT_HEAT_ON,
        /// <summary>
        /// Turns pitot heat switch off
        /// </summary>
        KEY_PITOT_HEAT_OFF,
        /// <summary>
        /// Sets pitot heat switch on/off (1,0)
        /// </summary>
        KEY_PITOT_HEAT_SET,
        /// <summary>
        /// Sets gear handle in UP position
        /// </summary>
        KEY_GEAR_UP,
        /// <summary>
        /// Sets gear handle in DOWN position
        /// </summary>
        KEY_GEAR_DOWN,
        /// <summary>
        /// Toggles main battery switch
        /// </summary>
        KEY_TOGGLE_MASTER_BATTERY,
        /// <summary>
        /// Toggles main alternator/generator switch
        /// </summary>
        KEY_TOGGLE_MASTER_ALTERNATOR,
        /// <summary>
        /// Toggles backup electric vacuum pump
        /// </summary>
        KEY_TOGGLE_ELECTRIC_VACUUM_PUMP,
        /// <summary>
        /// Toggles alternate static pressure port
        /// </summary>
        KEY_TOGGLE_ALTERNATE_STATIC,
        /// <summary>
        /// Decrements decision height reference
        /// </summary>
        KEY_DECISION_HEIGHT_DEC,
        /// <summary>
        /// Increments decision height reference
        /// </summary>
        KEY_DECISION_HEIGHT_INC,
        /// <summary>
        /// Toggles structural deice switch
        /// </summary>
        KEY_TOGGLE_STRUCTURAL_DEICE,
        /// <summary>
        /// Toggles propeller deice switch
        /// </summary>
        KEY_TOGGLE_PROPELLER_DEICE,
        /// <summary>
        /// Toggles alternator/generator 1 switch
        /// </summary>
        KEY_TOGGLE_ALTERNATOR1,
        /// <summary>
        /// Toggles alternator/generator 2 switch
        /// </summary>
        KEY_TOGGLE_ALTERNATOR2,
        /// <summary>
        /// Toggles alternator/generator 3 switch
        /// </summary>
        KEY_TOGGLE_ALTERNATOR3,
        /// <summary>
        /// Toggles alternator/generator 4 switch
        /// </summary>
        KEY_TOGGLE_ALTERNATOR4,
        /// <summary>
        /// Toggles master battery and alternator switch
        /// </summary>
        KEY_TOGGLE_MASTER_BATTERY_ALTERNATOR,
        /// <summary>
        /// Sets left brake position from axis controller (e.g. joystick). -16383 (0brakes) to +16383 (max brakes)
        /// </summary>
        KEY_AXIS_LEFT_BRAKE_SET,
        /// <summary>
        /// Sets right brake position from axis controller (e.g. joystick). -16383 (0brakes) to +16383 (max brakes)
        /// </summary>
        KEY_AXIS_RIGHT_BRAKE_SET,
        /// <summary>
        /// Toggles primary door open/close. Follow by KEY_SELECT_2, etc for subsequent doors.
        /// </summary>
        KEY_TOGGLE_AIRCRAFT_EXIT,
        /// <summary>
        /// Toggles wing folding
        /// </summary>
        KEY_TOGGLE_WING_FOLD,
        /// <summary>
        /// Sets the wings into the folded position suitable for storage, typically on a carrier. Takes a value:1 -fold wings, 0 - unfold wings
        /// </summary>
        KEY_SET_WING_FOLD,
        /// <summary>
        /// Toggles tail hook
        /// </summary>
        KEY_TOGGLE_TAIL_HOOK_HANDLE,
        /// <summary>
        /// Sets the tail hook handle. Takes a value: 1 - set tail hook, 0 - retract tail hook
        /// </summary>
        KEY_SET_TAIL_HOOK_HANDLE,
        /// <summary>
        /// Toggles water rudders
        /// </summary>
        KEY_TOGGLE_WATER_RUDDER,
        /// <summary>
        /// Toggles pushback.
        /// </summary>
        KEY_PUSHBACK_SET,
        /// <summary>
        /// Triggers tug and sets the desired heading. The units are a 32 bit integer (0 to4294967295) which represent 0 to 360 degrees. To set a 45 degree angle, for example, set the value to 4294967295 / 8.
        /// </summary>
        KEY_TUG_HEADING,
        /// <summary>
        /// Triggers tug, and sets desired speed, in feet per second. The speed can be bothpositive (forward movement) and negative (backward movement).
        /// </summary>
        KEY_TUG_SPEED,
        /// <summary>
        /// Disables tug
        /// </summary>
        KEY_TUG_DISABLE,
        /// <summary>
        /// Toggles master ignition switch
        /// </summary>
        KEY_TOGGLE_MASTER_IGNITION_SWITCH,
        /// <summary>
        /// Toggles tail wheel lock
        /// </summary>
        KEY_TOGGLE_TAILWHEEL_LOCK,
        /// <summary>
        /// Adds fuel to the aircraft, 25% of capacity by default. 0 to 65535 (max fuel) canbe passed.
        /// </summary>
        KEY_ADD_FUEL_QUANTITY,
        /// <summary>
        /// Release a towed aircraft, usually a glider.
        /// </summary>
        KEY_TOW_PLANE_RELEASE,
        /// <summary>
        /// Request a tow plane. The user aircraft must be tow-able, stationary, on the ground and not already attached for this to succeed.
        /// </summary>
        KEY_REQUEST_TOW_PLANE,
        /// <summary>
        /// Release one droppable object. Multiple key events will release multiple objects.
        /// </summary>
        KEY_RELEASE_DROPPABLE_OBJECTS,
        /// <summary>
        /// If the plane has retractable floats, moves the retract position from Extend to Neutral, or Neutral to Retract.
        /// </summary>
        KEY_RETRACT_FLOAT_SWITCH_DEC,
        /// <summary>
        /// If the plane has retractable floats, moves the retract position from Retract to Neutral, or Neutral to Extend.
        /// </summary>
        KEY_RETRACT_FLOAT_SWITCH_INC,
        /// <summary>
        /// Turn the water ballast valve on or off.
        /// </summary>
        KEY_TOGGLE_WATER_BALLAST_VALVE,
        /// <summary>
        /// Turn the variometer on or off.
        /// </summary>
        KEY_TOGGLE_VARIOMETER_SWITCH,
        /// <summary>
        /// Turn the turn indicator on or off.
        /// </summary>
        KEY_TOGGLE_TURN_INDICATOR_SWITCH,
        /// <summary>
        /// Start up the auxiliary power unit (APU).
        /// </summary>
        KEY_APU_STARTER,
        /// <summary>
        /// Turn the APU off.
        /// </summary>
        KEY_APU_OFF_SWITCH,
        /// <summary>
        /// Turn the auxiliary generator on or off.
        /// </summary>
        KEY_APU_GENERATOR_SWITCH_TOGGLE,
        /// <summary>
        /// Set the auxiliary generator switch (0,1).
        /// </summary>
        KEY_APU_GENERATOR_SWITCH_SET,
        /// <summary>
        /// Takes a two digit argument.The first digit represents the fire extinguisher index, and the second represents the engine index.For example,11 would represent using bottle 1 on engine 1.21 would represent using bottle 2 on engine 1.Typical entries for a twin engine aircraft would be 11 and 22.
        /// </summary>
        KEY_EXTINGUISH_ENGINE_FIRE,
        /// <summary>
        /// Turn the hydraulic switch on or off.
        /// </summary>
        KEY_HYDRAULIC_SWITCH_TOGGLE,
        /// <summary>
        /// Increases the bleed air source control.
        /// </summary>
        KEY_BLEED_AIR_SOURCE_CONTROL_INC,
        /// <summary>
        /// Decreases the bleed air source control.
        /// </summary>
        KEY_BLEED_AIR_SOURCE_CONTROL_DEC,
        /// <summary>
        /// Set to one of: 0: auto1: off2: apu3: engines
        /// </summary>
        KEY_BLEED_AIR_SOURCE_CONTROL_SET,
        /// <summary>
        /// Turn the turbine ignition switch on or off.
        /// </summary>
        KEY_TURBINE_IGNITION_SWITCH_TOGGLE,
        /// <summary>
        /// "Turn the ""No smoking"" alert on or off."
        /// </summary>
        KEY_CABIN_NO_SMOKING_ALERT_,
        /// <summary>
        /// "Turn the ""Fasten seatbelts"" alert on or off."
        /// </summary>
        KEY_CABIN_SEATBELTS_ALERT_,
        /// <summary>
        /// Turn the anti-skid braking system on or off.
        /// </summary>
        KEY_ANTISKID_BRAKES_TOGGLE,
        /// <summary>
        /// Turn the g round proximity warning system (GPWS) on or off.
        /// </summary>
        KEY_GPWS_SWITCH_TOGGLE,
        /// <summary>
        /// Activate the manual fuel pressure pump.
        /// </summary>
        KEY_MANUAL_FUEL_PRESSURE_PUMP,
        /// <summary>
        /// Togles the annunciator switch.
        /// </summary>
        KEY_ANNUNCIATOR_SWITCH_TOGGLE,
        /// <summary>
        /// Turns on the annunciator switch.
        /// </summary>
        KEY_ANNUNCIATOR_SWITCH_ON,
        /// <summary>
        /// Turns off the annunciator switch.
        /// </summary>
        KEY_ANNUNCIATOR_SWITCH_OFF,
        /// <summary>
        /// Increments the nose wheel steering position by 5 percent.
        /// </summary>
        KEY_STEERING_INC,
        /// <summary>
        /// Decrements the nose wheel steering position by 5 percent.
        /// </summary>
        KEY_STEERING_DEC,
        /// <summary>
        /// Sets the value of the nose wheel steering position. Zero is straight ahead(-16383, far left +16383, far right).
        /// </summary>
        KEY_STEERING_SET,
        /// <summary>
        /// Increases the altitude that the cabin is pressurized to.
        /// </summary>
        KEY_PRESSURIZATION_PRESSURE_ALT_INC,
        /// <summary>
        /// Decreases the altitude that the cabin is pressurized to.
        /// </summary>
        KEY_PRESSURIZATION_PRESSURE_ALT_DEC,
        /// <summary>
        /// Sets the rate at which cabin pressurization is increased.
        /// </summary>
        KEY_PRESSURIZATION_CLIMB_RATE_INC,
        /// <summary>
        /// Sets the rate at which cabin pressurization is decreased.
        /// </summary>
        KEY_PRESSURIZATION_CLIMB_RATE_DEC,
        /// <summary>
        /// Sets the cabin pressure to the outside air pressure.
        /// </summary>
        KEY_PRESSURIZATION_PRESSURE_DUMP,
        /// <summary>
        /// Deploy or remove the assist arm. Refer to the document Notes on Aircraft Systems.
        /// </summary>
        KEY_TAKEOFF_ASSIST_ARM_TOGGLE,
        /// <summary>
        /// Value: TRUE request set FALSE request unset
        /// </summary>
        KEY_TAKEOFF_ASSIST_ARM_SET,
        /// <summary>
        /// If everything is set up correctly. Launch from the catapult.
        /// </summary>
        KEY_TAKEOFF_ASSIST_FIRE,
        /// <summary>
        /// Toggle the request for the launch bar to be installed or removed.
        /// </summary>
        KEY_TOGGLE_LAUNCH_BAR_SWITCH,
        /// <summary>
        /// Value: TRUE request set FALSE request unset
        /// </summary>
        KEY_SET_LAUNCHBAR_SWITCH,
        /// <summary>
        /// Triggers rotor braking input
        /// </summary>
        KEY_ROTOR_BRAKE,
        /// <summary>
        /// Toggles on electric rotor clutch switch
        /// </summary>
        KEY_ROTOR_CLUTCH_SWITCH_TOGGLE,
        /// <summary>
        /// Sets electric rotor clutch switch on/off (1,0)
        /// </summary>
        KEY_ROTOR_CLUTCH_SWITCH_SET,
        /// <summary>
        /// Toggles the electric rotor governor switch
        /// </summary>
        KEY_ROTOR_GOV_SWITCH_TOGGLE,
        /// <summary>
        /// Sets the electric rotor governor switch on/off (1,0)
        /// </summary>
        KEY_ROTOR_GOV_SWITCH_SET,
        /// <summary>
        /// Increments the lateral (right) rotor trim
        /// </summary>
        KEY_ROTOR_LATERAL_TRIM_INC,
        /// <summary>
        /// Decrements the lateral (right) rotor trim
        /// </summary>
        KEY_ROTOR_LATERAL_TRIM_DEC,
        /// <summary>
        /// Sets the lateral (right) rotor trim (0 to 16383)
        /// </summary>
        KEY_ROTOR_LATERAL_TRIM_SET,
        /// <summary>
        /// Toggle between pickup and release mode. Hold mode is automatic and cannot be selected. Refer to the document Notes on Aircraft Systems.
        /// </summary>
        KEY_SLING_PICKUP_RELEASE,
        /// <summary>
        /// The rate at which a hoist cable extends is set in the Aircraft Configuration File.
        /// </summary>
        KEY_HOIST_SWITCH_EXTEND,
        /// <summary>
        /// The rate at which a hoist cable retracts is set in the Aircraft Configuration File.
        /// </summary>
        KEY_HOIST_SWITCH_RETRACT,
        /// <summary>
        /// The data value should be set to one of: <0 up=0 off >0 down
        /// </summary>
        KEY_HOIST_SWITCH_SET,
        /// <summary>
        /// Toggles the hoist arm switch, extend or retract.
        /// </summary>
        KEY_HOIST_DEPLOY_TOGGLE,
        /// <summary>
        /// The data value should be set to: 0 - set hoist switch to retract the arm1 - set hoist switch to extend the arm
        /// </summary>
        KEY_HOIST_DEPLOY_SET,
        /// <summary>
        /// Toggles slew on/off
        /// </summary>
        KEY_SLEW_TOGGLE,
        /// <summary>
        /// Turns slew off
        /// </summary>
        KEY_SLEW_OFF,
        /// <summary>
        /// Turns slew on
        /// </summary>
        KEY_SLEW_ON,
        /// <summary>
        /// Sets slew on/off (1,0)
        /// </summary>
        KEY_SLEW_SET,
        /// <summary>
        /// Stop slew and reset pitch, bank, and heading all to zero.
        /// </summary>
        KEY_SLEW_RESET,
        /// <summary>
        /// Slew upward fast
        /// </summary>
        KEY_SLEW_ALTIT_UP_FAST,
        /// <summary>
        /// Slew upward slow
        /// </summary>
        KEY_SLEW_ALTIT_UP_SLOW,
        /// <summary>
        /// Stop vertical slew
        /// </summary>
        KEY_SLEW_ALTIT_FREEZE,
        /// <summary>
        /// Slew downward slow
        /// </summary>
        KEY_SLEW_ALTIT_DN_SLOW,
        /// <summary>
        /// Slew downward fast
        /// </summary>
        KEY_SLEW_ALTIT_DN_FAST,
        /// <summary>
        /// Increase upward slew
        /// </summary>
        KEY_SLEW_ALTIT_PLUS,
        /// <summary>
        /// Decrease upward slew
        /// </summary>
        KEY_SLEW_ALTIT_MINUS,
        /// <summary>
        /// Slew pitch downward fast
        /// </summary>
        KEY_SLEW_PITCH_DN_FAST,
        /// <summary>
        /// Slew pitch downward slow
        /// </summary>
        KEY_SLEW_PITCH_DN_SLOW,
        /// <summary>
        /// Stop pitch slew
        /// </summary>
        KEY_SLEW_PITCH_FREEZE,
        /// <summary>
        /// Slew pitch up slow
        /// </summary>
        KEY_SLEW_PITCH_UP_SLOW,
        /// <summary>
        /// Slew pitch upward fast
        /// </summary>
        KEY_SLEW_PITCH_UP_FAST,
        /// <summary>
        /// Increase pitch up slew
        /// </summary>
        KEY_SLEW_PITCH_PLUS,
        /// <summary>
        /// Decrease pitch up slew
        /// </summary>
        KEY_SLEW_PITCH_MINUS,
        /// <summary>
        /// Increase left bank slew
        /// </summary>
        KEY_SLEW_BANK_MINUS,
        /// <summary>
        /// Increase forward slew
        /// </summary>
        KEY_SLEW_AHEAD_PLUS,
        /// <summary>
        /// Increase right bank slew
        /// </summary>
        KEY_SLEW_BANK_PLUS,
        /// <summary>
        /// Slew to the left
        /// </summary>
        KEY_SLEW_LEFT,
        /// <summary>
        /// Stop all slew
        /// </summary>
        KEY_SLEW_FREEZE,
        /// <summary>
        /// Slew to the right
        /// </summary>
        KEY_SLEW_RIGHT,
        /// <summary>
        /// Increase slew heading to the left
        /// </summary>
        KEY_SLEW_HEADING_MINUS,
        /// <summary>
        /// Decrease forward slew
        /// </summary>
        KEY_SLEW_AHEAD_MINUS,
        /// <summary>
        /// Increase slew heading to the right
        /// </summary>
        KEY_SLEW_HEADING_PLUS,
        /// <summary>
        /// Sets forward slew (+/- 16383)
        /// </summary>
        KEY_AXIS_SLEW_AHEAD_SET,
        /// <summary>
        /// Sets sideways slew (+/- 16383)
        /// </summary>
        KEY_AXIS_SLEW_SIDEWAYS_SET,
        /// <summary>
        /// Sets heading slew (+/- 16383)
        /// </summary>
        KEY_AXIS_SLEW_HEADING_SET,
        /// <summary>
        /// Sets vertical slew (+/- 16383)
        /// </summary>
        KEY_AXIS_SLEW_ALT_SET,
        /// <summary>
        /// Sets roll slew (+/- 16383)
        /// </summary>
        KEY_AXIS_SLEW_BANK_SET,
        /// <summary>
        /// Sets pitch slew (+/- 16383)
        /// </summary>
        KEY_AXIS_SLEW_PITCH_SET,
        /// <summary>
        /// Selects next view
        /// </summary>
        KEY_VIEW_MODE,
        /// <summary>
        /// Sets active window to front
        /// </summary>
        KEY_VIEW_WINDOW_TO_FRONT,
        /// <summary>
        /// Resets the view to the default
        /// </summary>
        KEY_VIEW_RESET,
        /// <summary>
        /// 
        /// </summary>
        KEY_VIEW_ALWAYS_PAN_UP,
        /// <summary>
        /// 
        /// </summary>
        KEY_VIEW_ALWAYS_PAN_DOWN,
        /// <summary>
        /// 
        /// </summary>
        KEY_NEXT_SUB_VIEW,
        /// <summary>
        /// 
        /// </summary>
        KEY_PREV_SUB_VIEW,
        /// <summary>
        /// 
        /// </summary>
        KEY_VIEW_TRACK_PAN_TOGGLE,
        /// <summary>
        /// 
        /// </summary>
        KEY_VIEW_PREVIOUS_TOGGLE,
        /// <summary>
        /// 
        /// </summary>
        KEY_VIEW_CAMERA_SELECT_STARTING,
        /// <summary>
        /// 
        /// </summary>
        KEY_PANEL_HUD_NEXT,
        /// <summary>
        /// 
        /// </summary>
        KEY_PANEL_HUD_PREVIOUS,
        /// <summary>
        /// Zooms view in
        /// </summary>
        KEY_ZOOM_IN,
        /// <summary>
        /// Zooms view out
        /// </summary>
        KEY_ZOOM_OUT,
        /// <summary>
        /// Fine zoom in map view
        /// </summary>
        KEY_MAP_ZOOM_FINE_IN,
        /// <summary>
        /// Pans view left
        /// </summary>
        KEY_PAN_LEFT,
        /// <summary>
        /// Pans view right
        /// </summary>
        KEY_PAN_RIGHT,
        /// <summary>
        /// Fine zoom out in map view
        /// </summary>
        KEY_MAP_ZOOM_FINE_OUT,
        /// <summary>
        /// Sets view direction forward
        /// </summary>
        KEY_VIEW_FORWARD,
        /// <summary>
        /// Sets view direction forward and right
        /// </summary>
        KEY_VIEW_FORWARD_RIGHT,
        /// <summary>
        /// Sets view direction to the right
        /// </summary>
        KEY_VIEW_RIGHT,
        /// <summary>
        /// Sets view direction to the rear and right
        /// </summary>
        KEY_VIEW_REAR_RIGHT,
        /// <summary>
        /// Sets view direction to the rear
        /// </summary>
        KEY_VIEW_REAR,
        /// <summary>
        /// Sets view direction to the rear and left
        /// </summary>
        KEY_VIEW_REAR_LEFT,
        /// <summary>
        /// Sets view direction to the left
        /// </summary>
        KEY_VIEW_LEFT,
        /// <summary>
        /// Sets view direction forward and left
        /// </summary>
        KEY_VIEW_FORWARD_LEFT,
        /// <summary>
        /// Sets view direction down
        /// </summary>
        KEY_VIEW_DOWN,
        /// <summary>
        /// Decreases zoom
        /// </summary>
        KEY_ZOOM_MINUS,
        /// <summary>
        /// Increase zoom
        /// </summary>
        KEY_ZOOM_PLUS,
        /// <summary>
        /// Pan view up
        /// </summary>
        KEY_PAN_UP,
        /// <summary>
        /// Pan view down
        /// </summary>
        KEY_PAN_DOWN,
        /// <summary>
        /// Reverse view cycle
        /// </summary>
        KEY_VIEW_MODE_REV,
        /// <summary>
        /// Zoom in fine
        /// </summary>
        KEY_ZOOM_IN_FINE,
        /// <summary>
        /// Zoom out fine
        /// </summary>
        KEY_ZOOM_OUT_FINE,
        /// <summary>
        /// Close current view
        /// </summary>
        KEY_CLOSE_VIEW,
        /// <summary>
        /// Open new view
        /// </summary>
        KEY_NEW_VIEW,
        /// <summary>
        /// Select next view
        /// </summary>
        KEY_NEXT_VIEW,
        /// <summary>
        /// Select previous view
        /// </summary>
        KEY_PREV_VIEW,
        /// <summary>
        /// Pan view left
        /// </summary>
        KEY_PAN_LEFT_UP,
        /// <summary>
        /// Pan view left and down
        /// </summary>
        KEY_PAN_LEFT_DOWN,
        /// <summary>
        /// Pan view right and up
        /// </summary>
        KEY_PAN_RIGHT_UP,
        /// <summary>
        /// Pan view right and down
        /// </summary>
        KEY_PAN_RIGHT_DOWN,
        /// <summary>
        /// Tilt view left
        /// </summary>
        KEY_PAN_TILT_LEFT,
        /// <summary>
        /// Tilt view right
        /// </summary>
        KEY_PAN_TILT_RIGHT,
        /// <summary>
        /// Reset view to forward
        /// </summary>
        KEY_PAN_RESET,
        /// <summary>
        /// Sets view forward and up
        /// </summary>
        KEY_VIEW_FORWARD_UP,
        /// <summary>
        /// Sets view forward, right, and up
        /// </summary>
        KEY_VIEW_FORWARD_RIGHT_UP,
        /// <summary>
        /// Sets view right and up
        /// </summary>
        KEY_VIEW_RIGHT_UP,
        /// <summary>
        /// Sets view rear, right, and up
        /// </summary>
        KEY_VIEW_REAR_RIGHT_UP,
        /// <summary>
        /// Sets view rear and up
        /// </summary>
        KEY_VIEW_REAR_UP,
        /// <summary>
        /// Sets view rear left and up
        /// </summary>
        KEY_VIEW_REAR_LEFT_UP,
        /// <summary>
        /// Sets view left and up
        /// </summary>
        KEY_VIEW_LEFT_UP,
        /// <summary>
        /// Sets view forward left and up
        /// </summary>
        KEY_VIEW_FORWARD_LEFT_UP,
        /// <summary>
        /// Sets view up
        /// </summary>
        KEY_VIEW_UP,
        /// <summary>
        /// Reset panning to forward, if in cockpit view
        /// </summary>
        KEY_PAN_RESET_COCKPIT,
        /// <summary>
        /// Cycle view to next target
        /// </summary>
        KEY_CHASE_VIEW_NEXT,
        /// <summary>
        /// Cycle view to previous target
        /// </summary>
        KEY_CHASE_VIEW_PREV,
        /// <summary>
        /// Toggles chase view on/off
        /// </summary>
        KEY_CHASE_VIEW_TOGGLE,
        /// <summary>
        /// Move eyepoint up
        /// </summary>
        KEY_EYEPOINT_UP,
        /// <summary>
        /// Move eyepoint down
        /// </summary>
        KEY_EYEPOINT_DOWN,
        /// <summary>
        /// Move eyepoint right
        /// </summary>
        KEY_EYEPOINT_RIGHT,
        /// <summary>
        /// Move eyepoint left
        /// </summary>
        KEY_EYEPOINT_LEFT,
        /// <summary>
        /// Move eyepoint forward
        /// </summary>
        KEY_EYEPOINT_FORWARD,
        /// <summary>
        /// Move eyepoint backward
        /// </summary>
        KEY_EYEPOINT_BACK,
        /// <summary>
        /// Move eyepoint to default position
        /// </summary>
        KEY_EYEPOINT_RESET,
        /// <summary>
        /// Opens new map view
        /// </summary>
        KEY_NEW_MAP,
        /// <summary>
        /// Switch immediately to the forward view, in 2D mode.
        /// </summary>
        KEY_VIEW_COCKPIT_FORWARD,
        /// <summary>
        /// Switch immediately to the forward view, in virtual cockpit mode.
        /// </summary>
        KEY_VIEW_VIRTUAL_COCKPIT_FORWARD,
        /// <summary>
        /// Sets the alpha-blending value for the panel. Takes a parameter in the range 0to 255. The alpha-blending can be changed from the keyboard using Ctrl-Shift-T,and the plus and minus keys.
        /// </summary>
        KEY_VIEW_PANEL_ALPHA_SET,
        /// <summary>
        /// Sets the mode to change the alpha-blending, so the keys KEY_PLUS and KEY_MINUS increment and decrement the value.
        /// </summary>
        KEY_VIEW_PANEL_ALPHA_SELECT,
        /// <summary>
        /// Increment alpha-blending for the panel.
        /// </summary>
        KEY_VIEW_PANEL_ALPHA_INC,
        /// <summary>
        /// Decrement alpha-blending for the panel.
        /// </summary>
        KEY_VIEW_PANEL_ALPHA_DEC,
        /// <summary>
        /// Links all the views from one camera together, so that panning the view will change the view of all the linked cameras.
        /// </summary>
        KEY_VIEW_LINKING_SET,
        /// <summary>
        /// Turns view linking on or off.
        /// </summary>
        KEY_VIEW_LINKING_TOGGLE,
        /// <summary>
        /// Increments the distance of the view camera from the chase object (such as in Spot Plane view, or viewing an AI controlled aircraft).
        /// </summary>
        KEY_VIEW_CHASE_DISTANCE_ADD,
        /// <summary>
        /// Decrements the distance of the view camera from the chase object.
        /// </summary>
        KEY_VIEW_CHASE_DISTANCE_SUB,
        /// <summary>
        /// Toggles pause on/off
        /// </summary>
        KEY_PAUSE_TOGGLE,
        /// <summary>
        /// Turns pause on
        /// </summary>
        KEY_PAUSE_ON,
        /// <summary>
        /// Turns pause off
        /// </summary>
        KEY_PAUSE_OFF,
        /// <summary>
        /// Sets pause on/off (1,0)
        /// </summary>
        KEY_PAUSE_SET,
        /// <summary>
        /// Stops demo system playback
        /// </summary>
        KEY_DEMO_STOP,
        /// <summary>
        /// "Sets ""selected"" index (for other events) to 1"
        /// </summary>
        KEY_SELECT_1,
        /// <summary>
        /// "Sets ""selected"" index (for other events) to 2"
        /// </summary>
        KEY_SELECT_2,
        /// <summary>
        /// "Sets ""selected"" index (for other events) to 3"
        /// </summary>
        KEY_SELECT_3,
        /// <summary>
        /// "Sets ""selected"" index (for other events) to 4"
        /// </summary>
        KEY_SELECT_4,
        /// <summary>
        /// "Used in conjunction with ""selected"" parameters to decrease their value (e.g.,radio frequency)"
        /// </summary>
        KEY_MINUS,
        /// <summary>
        /// "Used in conjunction with ""selected"" parameters to increase their value (e.g.,radio frequency)"
        /// </summary>
        KEY_PLUS,
        /// <summary>
        /// Sets zoom level to 1
        /// </summary>
        KEY_ZOOM_1X,
        /// <summary>
        /// Toggles sound on/off
        /// </summary>
        KEY_SOUND_TOGGLE,
        /// <summary>
        /// Selects simulation rate (use KEY_MINUS, KEY_PLUS to change)
        /// </summary>
        KEY_SIM_RATE,
        /// <summary>
        /// Toggles joystick on/off
        /// </summary>
        KEY_JOYSTICK_CALIBRATE,
        /// <summary>
        /// Saves flight situation
        /// </summary>
        KEY_SITUATION_SAVE,
        /// <summary>
        /// Resets flight situation
        /// </summary>
        KEY_SITUATION_RESET,
        /// <summary>
        /// Sets sound on/off (1,0)
        /// </summary>
        KEY_SOUND_SET,
        /// <summary>
        /// Quit ESP with a message
        /// </summary>
        KEY_EXIT,
        /// <summary>
        /// Quit ESP without a message
        /// </summary>
        KEY_ABORT,
        /// <summary>
        /// Cycle through information readouts while in slew
        /// </summary>
        KEY_READOUTS_SLEW,
        /// <summary>
        /// Cycle through information readouts
        /// </summary>
        KEY_READOUTS_FLIGHT,
        /// <summary>
        /// Used with other events
        /// </summary>
        KEY_MINUS_SHIFT,
        /// <summary>
        /// Used with other events
        /// </summary>
        KEY_PLUS_SHIFT,
        /// <summary>
        /// Increase sim rate
        /// </summary>
        KEY_SIM_RATE_INCR,
        /// <summary>
        /// Decrease sim rate
        /// </summary>
        KEY_SIM_RATE_DECR,
        /// <summary>
        /// Toggles kneeboard
        /// </summary>
        KEY_KNEEBOARD,
        /// <summary>
        /// Toggles panel 1
        /// </summary>
        KEY_PANEL_1,
        /// <summary>
        /// Toggles panel 2
        /// </summary>
        KEY_PANEL_2,
        /// <summary>
        /// Toggles panel 3
        /// </summary>
        KEY_PANEL_3,
        /// <summary>
        /// Toggles panel 4
        /// </summary>
        KEY_PANEL_4,
        /// <summary>
        /// Toggles panel 5
        /// </summary>
        KEY_PANEL_5,
        /// <summary>
        /// Toggles panel 6
        /// </summary>
        KEY_PANEL_6,
        /// <summary>
        /// Toggles panel 7
        /// </summary>
        KEY_PANEL_7,
        /// <summary>
        /// Toggles panel 8
        /// </summary>
        KEY_PANEL_8,
        /// <summary>
        /// Toggles panel 9
        /// </summary>
        KEY_PANEL_9,
        /// <summary>
        /// Turns sound on
        /// </summary>
        KEY_SOUND_ON,
        /// <summary>
        /// Turns sound off
        /// </summary>
        KEY_SOUND_OFF,
        /// <summary>
        /// Brings up Help system
        /// </summary>
        KEY_INVOKE_HELP,
        /// <summary>
        /// Toggles aircraft labels
        /// </summary>
        KEY_TOGGLE_AIRCRAFT_LABELS,
        /// <summary>
        /// Brings up flight map
        /// </summary>
        KEY_FLIGHT_MAP,
        /// <summary>
        /// Reload panel data
        /// </summary>
        KEY_RELOAD_PANELS,
        /// <summary>
        /// Toggles indexed panel (1 to 9)
        /// </summary>
        KEY_PANEL_ID_TOGGLE,
        /// <summary>
        /// Opens indexed panel (1 to 9)
        /// </summary>
        KEY_PANEL_ID_OPEN,
        /// <summary>
        /// Closes indexed panel (1 to 9)
        /// </summary>
        KEY_PANEL_ID_CLOSE,
        /// <summary>
        /// Reloads the user aircraft data (from cache if same type loaded as an AI,otherwise from disk)
        /// </summary>
        KEY_CONTROL_RELOAD_USER_AIRCRAFT,
        /// <summary>
        /// Resets aircraft state
        /// </summary>
        KEY_SIM_RESET,
        /// <summary>
        /// Turns Flying Tips on/off
        /// </summary>
        KEY_VIRTUAL_COPILOT_TOGGLE,
        /// <summary>
        /// Sets Flying Tips on/off (1,0)
        /// </summary>
        KEY_VIRTUAL_COPILOT_SET,
        /// <summary>
        /// Triggers action noted in Flying Tips
        /// </summary>
        KEY_VIRTUAL_COPILOT_ACTION,
        /// <summary>
        /// Reloads scenery
        /// </summary>
        KEY_REFRESH_SCENERY,
        /// <summary>
        /// Decrements time by hours
        /// </summary>
        KEY_CLOCK_HOURS_DEC,
        /// <summary>
        /// Increments time by hours
        /// </summary>
        KEY_CLOCK_HOURS_INC,
        /// <summary>
        /// Decrements time by minutes
        /// </summary>
        KEY_CLOCK_MINUTES_DEC,
        /// <summary>
        /// Increments time by minutes
        /// </summary>
        KEY_CLOCK_MINUTES_INC,
        /// <summary>
        /// Zeros seconds
        /// </summary>
        KEY_CLOCK_SECONDS_ZERO,
        /// <summary>
        /// Sets hour of day
        /// </summary>
        KEY_CLOCK_HOURS_SET,
        /// <summary>
        /// Sets minutes of the hour
        /// </summary>
        KEY_CLOCK_MINUTES_SET,
        /// <summary>
        /// Sets hours, zulu time
        /// </summary>
        KEY_ZULU_HOURS_SET,
        /// <summary>
        /// Sets minutes, in zulu time
        /// </summary>
        KEY_ZULU_MINUTES_SET,
        /// <summary>
        /// Sets day, in zulu time
        /// </summary>
        KEY_ZULU_DAY_SET,
        /// <summary>
        /// Sets year, in zulu time
        /// </summary>
        KEY_ZULU_YEAR_SET,
        /// <summary>
        /// Enables a keystroke to be sent to a gauge that is in focus. The keystrokes can only be in the range 0 to 9, A to Z, and the four keys: plus, minus, comma and period. This is typically used to allow some keyboard entry to a complex device such as a GPS to enter such things as ICAO codes using the keyboard, rather than turning dials.
        /// </summary>
        KEY_GAUGE_KEYSTROKE,
        /// <summary>
        /// Display the ATC window.
        /// </summary>
        KEY_SIMUI_WINDOW_HIDESHOW,
        /// <summary>
        /// Turn window titles on or off.
        /// </summary>
        KEY_WINDOW_TITLES_TOGGLE,
        /// <summary>
        /// Sets the pitch of the axis. Requires an angle.
        /// </summary>
        KEY_AXIS_PAN_PITCH,
        /// <summary>
        /// Sets the heading of the axis. Requires an angle.
        /// </summary>
        KEY_AXIS_PAN_HEADING,
        /// <summary>
        /// Sets the tilt of the axis. Requires an angle.
        /// </summary>
        KEY_AXIS_PAN_TILT,
        /// <summary>
        /// Step through the view axes.
        /// </summary>
        KEY_AXIS_INDICATOR_CYCLE,
        /// <summary>
        /// Step through the map orientations.
        /// </summary>
        KEY_MAP_ORIENTATION_CYCLE,
        /// <summary>
        /// Requests a jetway, which will only be answered if the aircraft is at a parking spot.
        /// </summary>
        KEY_TOGGLE_JETWAY,
        /// <summary>
        /// Turn on or off the video recording feature. This records uncompressed AVI format files to: My Documents\Videos\
        /// </summary>
        KEY_VIDEO_RECORD_TOGGLE,
        /// <summary>
        /// Turn on or off the airport name.
        /// </summary>
        KEY_TOGGLE_AIRPORT_NAME_DISPLAY,
        /// <summary>
        /// Capture the current view as a screenshot. Which will be saved to a bmp file in: My Documents\Pictures\
        /// </summary>
        KEY_CAPTURE_SCREENSHOT,
        /// <summary>
        /// Switch Mouse Look mode on or off. Mouse Look mode enables a user to control their view using the mouse, and holding down the space bar.
        /// </summary>
        KEY_MOUSE_LOOK_TOGGLE,
        /// <summary>
        /// Switch inversion of Y axis controls on or off.
        /// </summary>
        KEY_YAXIS_INVERT_TOGGLE,
        /// <summary>
        /// Turn the automatic rudder control feature on or off.
        /// </summary>
        KEY_AUTOCOORD_TOGGLE,
        /// <summary>
        /// Turns the freezing of the lat/lon position of the aircraft (either user or AI controlled) on or off. If this key event is set, it means that the latitude and longitude of the aircraft are not being controlled by ESP, so enabling, for example, a SimConnect client to control the position of the aircraft. This can also apply to altitude and attitude. Refer to the simulation variables: IS LATITUDE LONGITUDE FREEZE ON, IS ALTITUDE FREEZE ON, and IS ATTITUDE FREEZE ON Refer also to the SimConnect_AIReleaseControl function.
        /// </summary>
        KEY_FREEZE_LATITUDE_LONGITUDE_TOGGLE,
        /// <summary>
        /// Freezes the lat/lon position of the aircraft.
        /// </summary>
        KEY_FREEZE_LATITUDE_LONGITUDE_SET,
        /// <summary>
        /// Turns the freezing of the altitude of the aircraft on or off.
        /// </summary>
        KEY_FREEZE_ALTITUDE_TOGGLE,
        /// <summary>
        /// Freezes the altitude of the aircraft.
        /// </summary>
        KEY_FREEZE_ALTITUDE_SET,
        /// <summary>
        /// Turns the freezing of the attitude (pitch, bank and heading) of the aircraft on or off.
        /// </summary>
        KEY_FREEZE_ATTITUDE_TOGGLE,
        /// <summary>
        /// Freezes the attitude (pitch, bank and heading) of the aircraft.
        /// </summary>
        KEY_FREEZE_ATTITUDE_SET,
        /// <summary>
        /// Turn the point-of-interest indicator (often a light beam) on or off. Refer to the Missions system documentation.
        /// </summary>
        KEY_POINT_OF_INTEREST_TOGGLE_POINTER,
        /// <summary>
        /// Change the current point-of-interest to the previous point-of-interest.
        /// </summary>
        KEY_POINT_OF_INTEREST_CYCLE_PREVIOUS,
        /// <summary>
        /// Change the current point-of-interest to the next point-of-interest.
        /// </summary>
        KEY_POINT_OF_INTEREST_CYCLE_NEXT,
        /// <summary>
        /// Activates ATC window
        /// </summary>
        KEY_ATC,
        /// <summary>
        /// Selects ATC option 1
        /// </summary>
        KEY_ATC_MENU_1,
        /// <summary>
        /// Selects ATC option 2
        /// </summary>
        KEY_ATC_MENU_2,
        /// <summary>
        /// Selects ATC option 3
        /// </summary>
        KEY_ATC_MENU_3,
        /// <summary>
        /// Selects ATC option 4
        /// </summary>
        KEY_ATC_MENU_4,
        /// <summary>
        /// Selects ATC option 5
        /// </summary>
        KEY_ATC_MENU_5,
        /// <summary>
        /// Selects ATC option 6
        /// </summary>
        KEY_ATC_MENU_6,
        /// <summary>
        /// Selects ATC option 7
        /// </summary>
        KEY_ATC_MENU_7,
        /// <summary>
        /// Selects ATC option 8
        /// </summary>
        KEY_ATC_MENU_8,
        /// <summary>
        /// Selects ATC option 9
        /// </summary>
        KEY_ATC_MENU_9,
        /// <summary>
        /// Selects ATC option 10
        /// </summary>
        KEY_ATC_MENU_0,
        /// <summary>
        /// Toggle to the next player to track
        /// </summary>
        KEY_MULTIPLAYER_TRANSFER_CONTROL,
        /// <summary>
        /// Cycle through the current user aircraft.
        /// </summary>
        KEY_MULTIPLAYER_PLAYER_CYCLE,
        /// <summary>
        /// Set the view to follow the selected user aircraft.
        /// </summary>
        KEY_MULTIPLAYER_PLAYER_FOLLOW,
        /// <summary>
        /// Toggles chat window visible/invisible
        /// </summary>
        KEY_MULTIPLAYER_CHAT,
        /// <summary>
        /// Activates chat window
        /// </summary>
        KEY_MULTIPLAYER_ACTIVATE_CHAT,
        /// <summary>
        /// Start capturing audio from the users computer and transmitting it to all other players in the multiplayer session who are turned to the same radio frequency.
        /// </summary>
        KEY_MULTIPLAYER_VOICE_CAPTURE_START,
        /// <summary>
        /// Stop capturing radio audio.
        /// </summary>
        KEY_MULTIPLAYER_VOICE_CAPTURE_STOP,
        /// <summary>
        /// Start capturing audio from the users computer and transmitting it to all other players in the multiplayer session.
        /// </summary>
        KEY_MULTIPLAYER_BROADCAST_VOICE_,
        /// <summary>
        /// Show or hide multi-player race results.
        /// </summary>
        KEY_TOGGLE_RACERESULTS_WINDOW,
    };

    internal static class FsEventNameLookup
    {
        private static string[] _fsEventName = new string[] {
            "KEY_THROTTLE_FULL",
            "KEY_THROTTLE_INCR",
            "KEY_THROTTLE_INCR_SMALL",
            "KEY_THROTTLE_DECR",
            "KEY_THROTTLE_DECR_SMALL",
            "KEY_THROTTLE_CUT",
            "KEY_INCREASE_THROTTLE",
            "KEY_DECREASE_THROTTLE",
            "KEY_THROTTLE_SET",
            "KEY_AXIS_THROTTLE_SET",
            "KEY_THROTTLE1_SET",
            "KEY_THROTTLE2_SET",
            "KEY_THROTTLE3_SET",
            "KEY_THROTTLE4_SET",
            "KEY_THROTTLE1_FULL",
            "KEY_THROTTLE1_INCR",
            "KEY_THROTTLE1_INCR_SMALL",
            "KEY_THROTTLE1_DECR",
            "KEY_THROTTLE1_CUT",
            "KEY_THROTTLE2_FULL",
            "KEY_THROTTLE2_INCR",
            "KEY_THROTTLE2_INCR_SMALL",
            "KEY_THROTTLE2_DECR",
            "KEY_THROTTLE2_CUT",
            "KEY_THROTTLE3_FULL",
            "KEY_THROTTLE3_INCR",
            "KEY_THROTTLE3_INCR_SMALL",
            "KEY_THROTTLE3_DECR",
            "KEY_THROTTLE3_CUT",
            "KEY_THROTTLE4_FULL",
            "KEY_THROTTLE4_INCR",
            "KEY_THROTTLE4_INCR_SMALL",
            "KEY_THROTTLE4_DECR",
            "KEY_THROTTLE4_CUT",
            "KEY_THROTTLE_10",
            "KEY_THROTTLE_20",
            "KEY_THROTTLE_30",
            "KEY_THROTTLE_40",
            "KEY_THROTTLE_50",
            "KEY_THROTTLE_60",
            "KEY_THROTTLE_70",
            "KEY_THROTTLE_80",
            "KEY_THROTTLE_90",
            "KEY_AXIS_THROTTLE1_SET",
            "KEY_AXIS_THROTTLE2_SET",
            "KEY_AXIS_THROTTLE3_SET",
            "KEY_AXIS_THROTTLE4_SET",
            "KEY_THROTTLE1_DECR_SMALL",
            "KEY_THROTTLE2_DECR_SMALL",
            "KEY_THROTTLE3_DECR_SMALL",
            "KEY_THROTTLE4_DECR_SMALL",
            "KEY_PROP_PITCH_DECR_SMALL",
            "KEY_PROP_PITCH1_DECR_SMALL",
            "KEY_PROP_PITCH2_DECR_SMALL",
            "KEY_PROP_PITCH3_DECR_SMALL",
            "KEY_PROP_PITCH4_DECR_SMALL",
            "KEY_MIXTURE1_RICH",
            "KEY_MIXTURE1_INCR",
            "KEY_MIXTURE1_INCR_SMALL",
            "KEY_MIXTURE1_DECR",
            "KEY_MIXTURE1_LEAN",
            "KEY_MIXTURE2_RICH",
            "KEY_MIXTURE2_INCR",
            "KEY_MIXTURE2_INCR_SMALL",
            "KEY_MIXTURE2_DECR",
            "KEY_MIXTURE2_LEAN",
            "KEY_MIXTURE3_RICH",
            "KEY_MIXTURE3_INCR",
            "KEY_MIXTURE3_INCR_SMALL",
            "KEY_MIXTURE3_DECR",
            "KEY_MIXTURE3_LEAN",
            "KEY_MIXTURE4_RICH",
            "KEY_MIXTURE4_INCR",
            "KEY_MIXTURE4_INCR_SMALL",
            "KEY_MIXTURE4_DECR",
            "KEY_MIXTURE4_LEAN",
            "KEY_MIXTURE_SET",
            "KEY_MIXTURE_RICH",
            "KEY_MIXTURE_INCR",
            "KEY_MIXTURE_INCR_SMALL",
            "KEY_MIXTURE_DECR",
            "KEY_MIXTURE_LEAN",
            "KEY_MIXTURE1_SET",
            "KEY_MIXTURE2_SET",
            "KEY_MIXTURE3_SET",
            "KEY_MIXTURE4_SET",
            "KEY_AXIS_MIXTURE_SET",
            "KEY_AXIS_MIXTURE1_SET",
            "KEY_AXIS_MIXTURE2_SET",
            "KEY_AXIS_MIXTURE3_SET",
            "KEY_AXIS_MIXTURE4_SET",
            "KEY_MIXTURE_SET_BEST",
            "KEY_MIXTURE_DECR_SMALL",
            "KEY_MIXTURE1_DECR_SMALL",
            "KEY_MIXTURE2_DECR_SMALL",
            "KEY_MIXTURE3_DECR_SMALL",
            "KEY_MIXTURE4_DECR_SMALL",
            "KEY_PROP_PITCH_SET",
            "KEY_PROP_PITCH_LO",
            "KEY_PROP_PITCH_INCR",
            "KEY_PROP_PITCH_INCR_SMALL",
            "KEY_PROP_PITCH_DECR",
            "KEY_PROP_PITCH_HI",
            "KEY_PROP_PITCH1_SET",
            "KEY_PROP_PITCH2_SET",
            "KEY_PROP_PITCH3_SET",
            "KEY_PROP_PITCH4_SET",
            "KEY_PROP_PITCH1_LO",
            "KEY_PROP_PITCH1_INCR",
            "KEY_PROP_PITCH1_INCR_SMALL",
            "KEY_PROP_PITCH1_DECR",
            "KEY_PROP_PITCH1_HI",
            "KEY_PROP_PITCH2_LO",
            "KEY_PROP_PITCH2_INCR",
            "KEY_PROP_PITCH2_INCR_SMALL",
            "KEY_PROP_PITCH2_DECR",
            "KEY_PROP_PITCH2_HI",
            "KEY_PROP_PITCH3_LO",
            "KEY_PROP_PITCH3_INCR",
            "KEY_PROP_PITCH3_INCR_SMALL",
            "KEY_PROP_PITCH3_DECR",
            "KEY_PROP_PITCH3_HI",
            "KEY_PROP_PITCH4_LO",
            "KEY_PROP_PITCH4_INCR",
            "KEY_PROP_PITCH4_INCR_SMALL",
            "KEY_PROP_PITCH4_DECR",
            "KEY_PROP_PITCH4_HI",
            "KEY_AXIS_PROPELLER_SET",
            "KEY_AXIS_PROPELLER1_SET",
            "KEY_AXIS_PROPELLER2_SET",
            "KEY_AXIS_PROPELLER3_SET",
            "KEY_AXIS_PROPELLER4_SET",
            "KEY_JET_STARTER",
            "KEY_STARTER_SET",
            "KEY_TOGGLE_STARTER1",
            "KEY_TOGGLE_STARTER2",
            "KEY_TOGGLE_STARTER3",
            "KEY_TOGGLE_STARTER4",
            "KEY_TOGGLE_ALL_STARTERS",
            "KEY_ENGINE_AUTO_START",
            "KEY_ENGINE_AUTO_SHUTDOWN",
            "KEY_MAGNETO",
            "KEY_MAGNETO_DECR",
            "KEY_MAGNETO_INCR",
            "KEY_MAGNETO1_OFF",
            "KEY_MAGNETO1_RIGHT",
            "KEY_MAGNETO1_LEFT",
            "KEY_MAGNETO1_BOTH",
            "KEY_MAGNETO1_START",
            "KEY_MAGNETO2_OFF",
            "KEY_MAGNETO2_RIGHT",
            "KEY_MAGNETO2_LEFT",
            "KEY_MAGNETO2_BOTH",
            "KEY_MAGNETO2_START",
            "KEY_MAGNETO3_OFF",
            "KEY_MAGNETO3_RIGHT",
            "KEY_MAGNETO3_LEFT",
            "KEY_MAGNETO3_BOTH",
            "KEY_MAGNETO3_START",
            "KEY_MAGNETO4_OFF",
            "KEY_MAGNETO4_RIGHT",
            "KEY_MAGNETO4_LEFT",
            "KEY_MAGNETO4_BOTH",
            "KEY_MAGNETO4_START",
            "KEY_MAGNETO_OFF",
            "KEY_MAGNETO_RIGHT",
            "KEY_MAGNETO_LEFT",
            "KEY_MAGNETO_BOTH",
            "KEY_MAGNETO_START",
            "KEY_MAGNETO1_DECR",
            "KEY_MAGNETO1_INCR",
            "KEY_MAGNETO2_DECR",
            "KEY_MAGNETO2_INCR",
            "KEY_MAGNETO3_DECR",
            "KEY_MAGNETO3_INCR",
            "KEY_MAGNETO4_DECR",
            "KEY_MAGNETO4_INCR",
            "KEY_MAGNETO1_SET",
            "KEY_MAGNETO2_SET",
            "KEY_MAGNETO3_SET",
            "KEY_MAGNETO4_SET",
            "KEY_ANTI_ICE_ON",
            "KEY_ANTI_ICE_OFF",
            "KEY_ANTI_ICE_SET",
            "KEY_ANTI_ICE_TOGGLE",
            "KEY_ANTI_ICE_TOGGLE_ENG1",
            "KEY_ANTI_ICE_TOGGLE_ENG2",
            "KEY_ANTI_ICE_TOGGLE_ENG3",
            "KEY_ANTI_ICE_TOGGLE_ENG4",
            "KEY_ANTI_ICE_SET_ENG1",
            "KEY_ANTI_ICE_SET_ENG2",
            "KEY_ANTI_ICE_SET_ENG3",
            "KEY_ANTI_ICE_SET_ENG4",
            "KEY_TOGGLE_FUEL_VALVE_ALL",
            "KEY_TOGGLE_FUEL_VALVE_ENG1",
            "KEY_TOGGLE_FUEL_VALVE_ENG2",
            "KEY_TOGGLE_FUEL_VALVE_ENG3",
            "KEY_TOGGLE_FUEL_VALVE_ENG4",
            "KEY_COWLFLAP1_SET",
            "KEY_COWLFLAP2_SET",
            "KEY_COWLFLAP3_SET",
            "KEY_COWLFLAP4_SET",
            "KEY_INC_COWL_FLAPS",
            "KEY_DEC_COWL_FLAPS",
            "KEY_INC_COWL_FLAPS1",
            "KEY_DEC_COWL_FLAPS1",
            "KEY_INC_COWL_FLAPS2",
            "KEY_DEC_COWL_FLAPS2",
            "KEY_INC_COWL_FLAPS3",
            "KEY_DEC_COWL_FLAPS3",
            "KEY_INC_COWL_FLAPS4",
            "KEY_DEC_COWL_FLAPS4",
            "KEY_FUEL_PUMP",
            "KEY_TOGGLE_ELECT_FUEL_PUMP",
            "KEY_TOGGLE_ELECT_FUEL_PUMP1",
            "KEY_TOGGLE_ELECT_FUEL_PUMP2",
            "KEY_TOGGLE_ELECT_FUEL_PUMP3",
            "KEY_TOGGLE_ELECT_FUEL_PUMP4",
            "KEY_ENGINE_PRIMER",
            "KEY_TOGGLE_PRIMER",
            "KEY_TOGGLE_PRIMER1",
            "KEY_TOGGLE_PRIMER2",
            "KEY_TOGGLE_PRIMER3",
            "KEY_TOGGLE_PRIMER4",
            "KEY_TOGGLE_FEATHER_SWITCHES",
            "KEY_TOGGLE_FEATHER_SWITCH_1",
            "KEY_TOGGLE_FEATHER_SWITCH_2",
            "KEY_TOGGLE_FEATHER_SWITCH_3",
            "KEY_TOGGLE_FEATHER_SWITCH_4",
            "KEY_TOGGLE_PROP_SYNC",
            "KEY_TOGGLE_ARM_AUTOFEATHER",
            "KEY_TOGGLE_AFTERBURNER",
            "KEY_TOGGLE_AFTERBURNER1",
            "KEY_TOGGLE_AFTERBURNER2",
            "KEY_TOGGLE_AFTERBURNER3",
            "KEY_TOGGLE_AFTERBURNER4",
            "KEY_ENGINE",
            "KEY_SPOILERS_TOGGLE",
            "KEY_FLAPS_UP",
            "KEY_FLAPS_1",
            "KEY_FLAPS_2",
            "KEY_FLAPS_3",
            "KEY_FLAPS_DOWN",
            "KEY_ELEV_TRIM_DN",
            "KEY_ELEV_DOWN",
            "KEY_AILERONS_LEFT",
            "KEY_CENTER_AILER_RUDDER",
            "KEY_AILERONS_RIGHT",
            "KEY_ELEV_TRIM_UP",
            "KEY_ELEV_UP",
            "KEY_RUDDER_LEFT",
            "KEY_RUDDER_CENTER",
            "KEY_RUDDER_RIGHT",
            "KEY_ELEVATOR_SET",
            "KEY_AILERON_SET",
            "KEY_RUDDER_SET",
            "KEY_FLAPS_INCR",
            "KEY_FLAPS_DECR",
            "KEY_AXIS_ELEVATOR_SET",
            "KEY_AXIS_AILERONS_SET",
            "KEY_AXIS_RUDDER_SET",
            "KEY_AXIS_ELEV_TRIM_SET",
            "KEY_SPOILERS_SET",
            "KEY_SPOILERS_ARM_TOGGLE",
            "KEY_SPOILERS_ON",
            "KEY_SPOILERS_OFF",
            "KEY_SPOILERS_ARM_ON",
            "KEY_SPOILERS_ARM_OFF",
            "KEY_SPOILERS_ARM_SET",
            "KEY_AILERON_TRIM_LEFT",
            "KEY_AILERON_TRIM_RIGHT",
            "KEY_RUDDER_TRIM_LEFT",
            "KEY_RUDDER_TRIM_RIGHT",
            "KEY_AXIS_SPOILER_SET",
            "KEY_FLAPS_SET",
            "KEY_ELEVATOR_TRIM_SET",
            "KEY_AXIS_FLAPS_SET",
            "KEY_AP_MASTER",
            "KEY_AUTOPILOT_OFF",
            "KEY_AUTOPILOT_ON",
            "KEY_YAW_DAMPER_TOGGLE",
            "KEY_AP_PANEL_HEADING_HOLD",
            "KEY_AP_PANEL_ALTITUDE_HOLD",
            "KEY_AP_ATT_HOLD_ON",
            "KEY_AP_LOC_HOLD_ON",
            "KEY_AP_APR_HOLD_ON",
            "KEY_AP_HDG_HOLD_ON",
            "KEY_AP_ALT_HOLD_ON",
            "KEY_AP_WING_LEVELER_ON",
            "KEY_AP_BC_HOLD_ON",
            "KEY_AP_NAV1_HOLD_ON",
            "KEY_AP_ATT_HOLD_OFF",
            "KEY_AP_LOC_HOLD_OFF",
            "KEY_AP_APR_HOLD_OFF",
            "KEY_AP_HDG_HOLD_OFF",
            "KEY_AP_ALT_HOLD_OFF",
            "KEY_AP_WING_LEVELER_OFF",
            "KEY_AP_BC_HOLD_OFF",
            "KEY_AP_NAV1_HOLD_OFF",
            "KEY_AP_AIRSPEED_HOLD",
            "KEY_AUTO_THROTTLE_ARM",
            "KEY_AUTO_THROTTLE_TO_GA",
            "KEY_HEADING_BUG_INC",
            "KEY_HEADING_BUG_DEC",
            "KEY_HEADING_BUG_SET",
            "KEY_AP_PANEL_SPEED_HOLD",
            "KEY_AP_ALT_VAR_INC",
            "KEY_AP_ALT_VAR_DEC",
            "KEY_AP_VS_VAR_INC",
            "KEY_AP_VS_VAR_DEC",
            "KEY_AP_SPD_VAR_INC",
            "KEY_AP_SPD_VAR_DEC",
            "KEY_AP_PANEL_MACH_HOLD",
            "KEY_AP_MACH_VAR_INC",
            "KEY_AP_MACH_VAR_DEC",
            "KEY_AP_MACH_HOLD",
            "KEY_AP_ALT_VAR_SET_METRIC",
            "KEY_AP_VS_VAR_SET_ENGLISH",
            "KEY_AP_SPD_VAR_SET",
            "KEY_AP_MACH_VAR_SET",
            "KEY_YAW_DAMPER_ON",
            "KEY_YAW_DAMPER_OFF",
            "KEY_YAW_DAMPER_SET",
            "KEY_AP_AIRSPEED_ON",
            "KEY_AP_AIRSPEED_OFF",
            "KEY_AP_AIRSPEED_SET",
            "KEY_AP_MACH_ON",
            "KEY_AP_MACH_OFF",
            "KEY_AP_MACH_SET",
            "KEY_AP_PANEL_ALTITUDE_ON",
            "KEY_AP_PANEL_ALTITUDE_OFF",
            "KEY_AP_PANEL_ALTITUDE_SET",
            "KEY_AP_PANEL_HEADING_ON",
            "KEY_AP_PANEL_HEADING_OFF",
            "KEY_AP_PANEL_HEADING_SET",
            "KEY_AP_PANEL_MACH_ON",
            "KEY_AP_PANEL_MACH_OFF",
            "KEY_AP_PANEL_MACH_SET",
            "KEY_AP_PANEL_SPEED_ON",
            "KEY_AP_PANEL_SPEED_OFF",
            "KEY_AP_PANEL_SPEED_SET",
            "KEY_AP_ALT_VAR_SET_ENGLISH",
            "KEY_AP_VS_VAR_SET_METRIC",
            "KEY_TOGGLE_FLIGHT_DIRECTOR",
            "KEY_SYNC_FLIGHT_DIRECTOR_PITCH",
            "KEY_INC_AUTOBRAKE_CONTROL",
            "KEY_DEC_AUTOBRAKE_CONTROL",
            "KEY_AUTOPILOT_AIRSPEED_HOLD_CURRENT",
            "KEY_AUTOPILOT_MACH_HOLD_CURRENT",
            "KEY_AP_NAV_SELECT_SET",
            "KEY_HEADING_BUG_SELECT",
            "KEY_ALTITUDE_BUG_SELECT",
            "KEY_VSI_BUG_SELECT",
            "KEY_AIRSPEED_BUG_SELECT",
            "KEY_AP_PITCH_REF_INC_UP",
            "KEY_AP_PITCH_REF_INC_DN",
            "KEY_AP_PITCH_REF_SELECT",
            "KEY_AP_ATT_HOLD",
            "KEY_AP_LOC_HOLD",
            "KEY_AP_APR_HOLD",
            "KEY_AP_HDG_HOLD",
            "KEY_AP_ALT_HOLD",
            "KEY_AP_WING_LEVELER",
            "KEY_AP_BC_HOLD",
            "KEY_AP_NAV1_HOLD",
            "KEY_AP_MAX_BANK_INC",
            "KEY_AP_MAX_BANK_DEC",
            "KEY_AP_N1_HOLD",
            "KEY_AP_N1_REF_INC",
            "KEY_AP_N1_REF_DEC",
            "KEY_AP_N1_REF_SET",
            "KEY_FLY_BY_WIRE_ELAC_TOGGLE",
            "KEY_FLY_BY_WIRE_FAC_TOGGLE",
            "KEY_FLY_BY_WIRE_SEC_TOGGLE",
            "KEY_G1000_PFD_FLIGHTPLAN_BUTTON",
            "KEY_G1000_PFD_PROCEDURE_BUTTON",
            "KEY_G1000_PFD_ZOOMIN_BUTTON",
            "KEY_G1000_PFD_ZOOMOUT_BUTTON",
            "KEY_G1000_PFD_DIRECTTO_BUTTON",
            "KEY_G1000_PFD_MENU_BUTTON",
            "KEY_G1000_PFD_CLEAR_BUTTON",
            "KEY_G1000_PFD_ENTER_BUTTON",
            "KEY_G1000_PFD_CURSOR_BUTTON",
            "KEY_G1000_PFD_GROUP_KNOB_INC",
            "KEY_G1000_PFD_GROUP_KNOB_DEC",
            "KEY_G1000_PFD_PAGE_KNOB_INC",
            "KEY_G1000_PFD_PAGE_KNOB_DEC",
            "KEY_G1000_PFD_SOFTKEY1",
            "KEY_G1000_MFD_FLIGHTPLAN_BUTTON",
            "KEY_G1000_MFD_PROCEDURE_BUTTON",
            "KEY_G1000_MFD_ZOOMIN_BUTTON",
            "KEY_G1000_MFD_ZOOMOUT_BUTTON",
            "KEY_G1000_MFD_DIRECTTO_BUTTON",
            "KEY_G1000_MFD_MENU_BUTTON",
            "KEY_G1000_MFD_CLEAR_BUTTON",
            "KEY_G1000_MFD_ENTER_BUTTON",
            "KEY_G1000_MFD_CURSOR_BUTTON",
            "KEY_G1000_MFD_GROUP_KNOB_INC",
            "KEY_G1000_MFD_GROUP_KNOB_DEC",
            "KEY_G1000_MFD_PAGE_KNOB_INC",
            "KEY_G1000_MFD_PAGE_KNOB_DEC",
            "KEY_G1000_MFD_SOFTKEY1",
            "KEY_FUEL_SELECTOR_OFF",
            "KEY_FUEL_SELECTOR_ALL",
            "KEY_FUEL_SELECTOR_LEFT",
            "KEY_FUEL_SELECTOR_RIGHT",
            "KEY_FUEL_SELECTOR_LEFT_AUX",
            "KEY_FUEL_SELECTOR_RIGHT_AUX",
            "KEY_FUEL_SELECTOR_CENTER",
            "KEY_FUEL_SELECTOR_SET",
            "KEY_FUEL_SELECTOR_2_OFF",
            "KEY_FUEL_SELECTOR_2_ALL",
            "KEY_FUEL_SELECTOR_2_LEFT",
            "KEY_FUEL_SELECTOR_2_RIGHT",
            "KEY_FUEL_SELECTOR_2_LEFT_AUX",
            "KEY_FUEL_SELECTOR_2_RIGHT_AUX",
            "KEY_FUEL_SELECTOR_2_CENTER",
            "KEY_FUEL_SELECTOR_2_SET",
            "KEY_FUEL_SELECTOR_3_OFF",
            "KEY_FUEL_SELECTOR_3_ALL",
            "KEY_FUEL_SELECTOR_3_LEFT",
            "KEY_FUEL_SELECTOR_3_RIGHT",
            "KEY_FUEL_SELECTOR_3_LEFT_AUX",
            "KEY_FUEL_SELECTOR_3_RIGHT_AUX",
            "KEY_FUEL_SELECTOR_3_CENTER",
            "KEY_FUEL_SELECTOR_3_SET",
            "KEY_FUEL_SELECTOR_4_OFF",
            "KEY_FUEL_SELECTOR_4_ALL",
            "KEY_FUEL_SELECTOR_4_LEFT",
            "KEY_FUEL_SELECTOR_4_RIGHT",
            "KEY_FUEL_SELECTOR_4_LEFT_AUX",
            "KEY_FUEL_SELECTOR_4_RIGHT_AUX",
            "KEY_FUEL_SELECTOR_4_CENTER",
            "KEY_FUEL_SELECTOR_4_SET",
            "KEY_CROSS_FEED_OPEN",
            "KEY_CROSS_FEED_TOGGLE",
            "KEY_CROSS_FEED_OFF",
            "KEY_FUEL_DUMP_SWITCH_SET",
            "KEY_TOGGLE_ANTIDETONATION_TANK_VALVE",
            "KEY_TOGGLE_NITROUS_TANK_VALVE",
            "KEY_REPAIR_AND_REFUEL",
            "KEY_FUEL_DUMP_TOGGLE",
            "KEY_REQUEST_FUEL",
            "KEY_FUEL_SELECTOR_LEFT_MAIN",
            "KEY_FUEL_SELECTOR_2_LEFT_MAIN",
            "KEY_FUEL_SELECTOR_3_LEFT_MAIN",
            "KEY_FUEL_SELECTOR_4_LEFT_MAIN",
            "KEY_FUEL_SELECTOR_RIGHT_MAIN",
            "KEY_FUEL_SELECTOR_2_RIGHT_MAIN",
            "KEY_FUEL_SELECTOR_3_RIGHT_MAIN",
            "KEY_FUEL_SELECTOR_4_RIGHT_MAIN",
            "KEY_XPNDR",
            "KEY_ADF",
            "KEY_DME",
            "KEY_COM_RADIO",
            "KEY_VOR_OBS",
            "KEY_NAV_RADIO",
            "KEY_COM_RADIO_WHOLE_DEC",
            "KEY_COM_RADIO_WHOLE_INC",
            "KEY_COM_RADIO_FRACT_DEC",
            "KEY_COM_RADIO_FRACT_INC",
            "KEY_NAV1_RADIO_WHOLE_DEC",
            "KEY_NAV1_RADIO_WHOLE_INC",
            "KEY_NAV1_RADIO_FRACT_DEC",
            "KEY_NAV1_RADIO_FRACT_INC",
            "KEY_NAV2_RADIO_WHOLE_DEC",
            "KEY_NAV2_RADIO_WHOLE_INC",
            "KEY_NAV2_RADIO_FRACT_DEC",
            "KEY_NAV2_RADIO_FRACT_INC",
            "KEY_ADF_100_INC",
            "KEY_ADF_10_INC",
            "KEY_ADF_1_INC",
            "KEY_XPNDR_1000_INC",
            "KEY_XPNDR_100_INC",
            "KEY_XPNDR_10_INC",
            "KEY_XPNDR_1_INC",
            "KEY_VOR1_OBI_DEC",
            "KEY_VOR1_OBI_INC",
            "KEY_VOR2_OBI_DEC",
            "KEY_VOR2_OBI_INC",
            "KEY_ADF_100_DEC",
            "KEY_ADF_10_DEC",
            "KEY_ADF_1_DEC",
            "KEY_COM_RADIO_SET",
            "KEY_NAV1_RADIO_SET",
            "KEY_NAV2_RADIO_SET",
            "KEY_ADF_SET",
            "KEY_XPNDR_SET",
            "KEY_VOR1_SET",
            "KEY_VOR2_SET",
            "KEY_DME1_TOGGLE",
            "KEY_DME2_TOGGLE",
            "KEY_RADIO_VOR1_IDENT_DISABLE",
            "KEY_RADIO_VOR2_IDENT_DISABLE",
            "KEY_RADIO_DME1_IDENT_DISABLE",
            "KEY_RADIO_DME2_IDENT_DISABLE",
            "KEY_RADIO_ADF_IDENT_DISABLE",
            "KEY_RADIO_VOR1_IDENT_ENABLE",
            "KEY_RADIO_VOR2_IDENT_ENABLE",
            "KEY_RADIO_DME1_IDENT_ENABLE",
            "KEY_RADIO_DME2_IDENT_ENABLE",
            "KEY_RADIO_ADF_IDENT_ENABLE",
            "KEY_RADIO_VOR1_IDENT_TOGGLE",
            "KEY_RADIO_VOR2_IDENT_TOGGLE",
            "KEY_RADIO_DME1_IDENT_TOGGLE",
            "KEY_RADIO_DME2_IDENT_TOGGLE",
            "KEY_RADIO_ADF_IDENT_TOGGLE",
            "KEY_RADIO_VOR1_IDENT_SET",
            "KEY_RADIO_VOR2_IDENT_SET",
            "KEY_RADIO_DME1_IDENT_SET",
            "KEY_RADIO_DME2_IDENT_SET",
            "KEY_RADIO_ADF_IDENT_SET",
            "KEY_ADF_CARD_INC",
            "KEY_ADF_CARD_DEC",
            "KEY_ADF_CARD_SET",
            "KEY_DME_TOGGLE",
            "KEY_AVIONICS_MASTER_SET",
            "KEY_TOGGLE_AVIONICS_MASTER",
            "KEY_COM_STBY_RADIO_SET",
            "KEY_COM_STBY_RADIO_SWITCH_TO",
            "KEY_COM_RADIO_FRACT_DEC_CARRY",
            "KEY_COM_RADIO_FRACT_INC_CARRY",
            "KEY_COM2_RADIO_WHOLE_DEC",
            "KEY_COM2_RADIO_WHOLE_INC",
            "KEY_COM2_RADIO_FRACT_DEC",
            "KEY_COM2_RADIO_FRACT_DEC_CARRY",
            "KEY_COM2_RADIO_FRACT_INC",
            "KEY_COM2_RADIO_FRACT_INC_CARRY",
            "KEY_COM2_RADIO_SET",
            "KEY_COM2_STBY_RADIO_SET",
            "KEY_COM2_RADIO_SWAP",
            "KEY_NAV1_RADIO_FRACT_DEC_CARRY",
            "KEY_NAV1_RADIO_FRACT_INC_CARRY",
            "KEY_NAV1_STBY_SET",
            "KEY_NAV1_RADIO_SWAP",
            "KEY_NAV2_RADIO_FRACT_DEC_CARRY",
            "KEY_NAV2_RADIO_FRACT_INC_CARRY",
            "KEY_NAV2_STBY_SET",
            "KEY_NAV2_RADIO_SWAP",
            "KEY_ADF1_RADIO_TENTHS_DEC",
            "KEY_ADF1_RADIO_TENTHS_INC",
            "KEY_XPNDR_1000_DEC",
            "KEY_XPNDR_100_DEC",
            "KEY_XPNDR_10_DEC",
            "KEY_XPNDR_1_DEC",
            "KEY_XPNDR_DEC_CARRY",
            "KEY_XPNDR_INC_CARRY",
            "KEY_ADF_FRACT_DEC_CARRY",
            "KEY_ADF_FRACT_INC_CARRY",
            "KEY_COM1_TRANSMIT_SELECT",
            "KEY_COM2_TRANSMIT_SELECT",
            "KEY_COM_RECEIVE_ALL_TOGGLE",
            "KEY_COM_RECEIVE_ALL_SET",
            "KEY_MARKER_SOUND_TOGGLE",
            "KEY_ADF_COMPLETE_SET",
            "KEY_ADF_WHOLE_INC",
            "KEY_ADF_WHOLE_DEC",
            "KEY_ADF2_100_INC",
            "KEY_ADF2_10_INC",
            "KEY_ADF2_1_INC",
            "KEY_ADF2_RADIO_TENTHS_INC",
            "KEY_ADF2_100_DEC",
            "KEY_ADF2_10_DEC",
            "KEY_ADF2_1_DEC",
            "KEY_ADF2_RADIO_TENTHS_DEC",
            "KEY_ADF2_WHOLE_INC",
            "KEY_ADF2_WHOLE_DEC",
            "KEY_ADF2_FRACT_INC_CARRY",
            "KEY_ADF2_FRACT_DEC_CARRY",
            "KEY_ADF2_COMPLETE_SET",
            "KEY_RADIO_ADF2_IDENT_DISABLE",
            "KEY_RADIO_ADF2_IDENT_ENABLE",
            "KEY_RADIO_ADF2_IDENT_TOGGLE",
            "KEY_RADIO_ADF2_IDENT_SET",
            "KEY_FREQUENCY_SWAP",
            "KEY_TOGGLE_GPS_DRIVES_NAV1",
            "KEY_GPS_POWER_BUTTON",
            "KEY_GPS_NEAREST_BUTTON",
            "KEY_GPS_OBS_BUTTON",
            "KEY_GPS_MSG_BUTTON",
            "KEY_GPS_MSG_BUTTON_DOWN",
            "KEY_GPS_MSG_BUTTON_UP",
            "KEY_GPS_FLIGHTPLAN_BUTTON",
            "KEY_GPS_TERRAIN_BUTTON",
            "KEY_GPS_PROCEDURE_BUTTON",
            "KEY_GPS_ZOOMIN_BUTTON",
            "KEY_GPS_ZOOMOUT_BUTTON",
            "KEY_GPS_DIRECTTO_BUTTON",
            "KEY_GPS_MENU_BUTTON",
            "KEY_GPS_CLEAR_BUTTON",
            "KEY_GPS_CLEAR_ALL_BUTTON",
            "KEY_GPS_CLEAR_BUTTON_DOWN",
            "KEY_GPS_CLEAR_BUTTON_UP",
            "KEY_GPS_ENTER_BUTTON",
            "KEY_GPS_CURSOR_BUTTON",
            "KEY_GPS_GROUP_KNOB_INC",
            "KEY_GPS_GROUP_KNOB_DEC",
            "KEY_GPS_PAGE_KNOB_INC",
            "KEY_GPS_PAGE_KNOB_DEC",
            "KEY_DME_SELECT",
            "KEY_RADIO_SELECTED_DME_IDENT_ENABLE",
            "KEY_RADIO_SELECTED_DME_IDENT_DISABLE",
            "KEY_RADIO_SELECTED_DME_IDENT_SET",
            "KEY_RADIO_SELECTED_DME_IDENT_TOGGLE",
            "KEY_EGT",
            "KEY_EGT_INC",
            "KEY_EGT_DEC",
            "KEY_EGT_SET",
            "KEY_BAROMETRIC",
            "KEY_GYRO_DRIFT_INC",
            "KEY_GYRO_DRIFT_DEC",
            "KEY_KOHLSMAN_INC",
            "KEY_KOHLSMAN_DEC",
            "KEY_KOHLSMAN_SET",
            "KEY_TRUE_AIRSPEED_CALIBRATE_INC",
            "KEY_TRUE_AIRSPEED_CALIBRATE_DEC",
            "KEY_TRUE_AIRSPEED_CAL_SET",
            "KEY_EGT1_INC",
            "KEY_EGT1_DEC",
            "KEY_EGT1_SET",
            "KEY_EGT2_INC",
            "KEY_EGT2_DEC",
            "KEY_EGT2_SET",
            "KEY_EGT3_INC",
            "KEY_EGT3_DEC",
            "KEY_EGT3_SET",
            "KEY_EGT4_INC",
            "KEY_EGT4_DEC",
            "KEY_EGT4_SET",
            "KEY_ATTITUDE_BARS_POSITION_INC",
            "KEY_ATTITUDE_BARS_POSITION_DEC",
            "KEY_TOGGLE_ATTITUDE_CAGE",
            "KEY_RESET_G_FORCE_INDICATOR",
            "KEY_RESET_MAX_RPM_INDICATOR",
            "KEY_HEADING_GYRO_SET",
            "KEY_GYRO_DRIFT_SET",
            "KEY_STROBES_TOGGLE",
            "KEY_ALL_LIGHTS_TOGGLE",
            "KEY_PANEL_LIGHTS_TOGGLE",
            "KEY_LANDING_LIGHTS_TOGGLE",
            "KEY_LANDING_LIGHT_UP",
            "KEY_LANDING_LIGHT_DOWN",
            "KEY_LANDING_LIGHT_LEFT",
            "KEY_LANDING_LIGHT_RIGHT",
            "KEY_LANDING_LIGHT_HOME",
            "KEY_STROBES_ON",
            "KEY_STROBES_OFF",
            "KEY_STROBES_SET",
            "KEY_PANEL_LIGHTS_ON",
            "KEY_PANEL_LIGHTS_OFF",
            "KEY_PANEL_LIGHTS_SET",
            "KEY_LANDING_LIGHTS_ON",
            "KEY_LANDING_LIGHTS_OFF",
            "KEY_LANDING_LIGHTS_SET",
            "KEY_TOGGLE_BEACON_LIGHTS",
            "KEY_TOGGLE_TAXI_LIGHTS",
            "KEY_TOGGLE_LOGO_LIGHTS",
            "KEY_TOGGLE_RECOGNITION_LIGHTS",
            "KEY_TOGGLE_WING_LIGHTS",
            "KEY_TOGGLE_NAV_LIGHTS",
            "KEY_TOGGLE_CABIN_LIGHTS",
            "KEY_TOGGLE_VACUUM_FAILURE",
            "KEY_TOGGLE_ELECTRICAL_FAILURE",
            "KEY_TOGGLE_PITOT_BLOCKAGE",
            "KEY_TOGGLE_STATIC_PORT_BLOCKAGE",
            "KEY_TOGGLE_HYDRAULIC_FAILURE",
            "KEY_TOGGLE_TOTAL_BRAKE_FAILURE",
            "KEY_TOGGLE_LEFT_BRAKE_FAILURE",
            "KEY_TOGGLE_RIGHT_BRAKE_FAILURE",
            "KEY_TOGGLE_ENGINE1_FAILURE",
            "KEY_TOGGLE_ENGINE2_FAILURE",
            "KEY_TOGGLE_ENGINE3_FAILURE",
            "KEY_TOGGLE_ENGINE4_FAILURE",
            "KEY_SMOKE_TOGGLE",
            "KEY_GEAR_TOGGLE",
            "KEY_BRAKES",
            "KEY_GEAR_SET",
            "KEY_BRAKES_LEFT",
            "KEY_BRAKES_RIGHT",
            "KEY_PARKING_BRAKES",
            "KEY_GEAR_PUMP",
            "KEY_PITOT_HEAT_TOGGLE",
            "KEY_SMOKE_ON",
            "KEY_SMOKE_OFF",
            "KEY_SMOKE_SET",
            "KEY_PITOT_HEAT_ON",
            "KEY_PITOT_HEAT_OFF",
            "KEY_PITOT_HEAT_SET",
            "KEY_GEAR_UP",
            "KEY_GEAR_DOWN",
            "KEY_TOGGLE_MASTER_BATTERY",
            "KEY_TOGGLE_MASTER_ALTERNATOR",
            "KEY_TOGGLE_ELECTRIC_VACUUM_PUMP",
            "KEY_TOGGLE_ALTERNATE_STATIC",
            "KEY_DECISION_HEIGHT_DEC",
            "KEY_DECISION_HEIGHT_INC",
            "KEY_TOGGLE_STRUCTURAL_DEICE",
            "KEY_TOGGLE_PROPELLER_DEICE",
            "KEY_TOGGLE_ALTERNATOR1",
            "KEY_TOGGLE_ALTERNATOR2",
            "KEY_TOGGLE_ALTERNATOR3",
            "KEY_TOGGLE_ALTERNATOR4",
            "KEY_TOGGLE_MASTER_BATTERY_ALTERNATOR",
            "KEY_AXIS_LEFT_BRAKE_SET",
            "KEY_AXIS_RIGHT_BRAKE_SET",
            "KEY_TOGGLE_AIRCRAFT_EXIT",
            "KEY_TOGGLE_WING_FOLD",
            "KEY_SET_WING_FOLD",
            "KEY_TOGGLE_TAIL_HOOK_HANDLE",
            "KEY_SET_TAIL_HOOK_HANDLE",
            "KEY_TOGGLE_WATER_RUDDER",
            "KEY_PUSHBACK_SET",
            "KEY_TUG_HEADING",
            "KEY_TUG_SPEED",
            "KEY_TUG_DISABLE",
            "KEY_TOGGLE_MASTER_IGNITION_SWITCH",
            "KEY_TOGGLE_TAILWHEEL_LOCK",
            "KEY_ADD_FUEL_QUANTITY",
            "KEY_TOW_PLANE_RELEASE",
            "KEY_REQUEST_TOW_PLANE",
            "KEY_RELEASE_DROPPABLE_OBJECTS",
            "KEY_RETRACT_FLOAT_SWITCH_DEC",
            "KEY_RETRACT_FLOAT_SWITCH_INC",
            "KEY_TOGGLE_WATER_BALLAST_VALVE",
            "KEY_TOGGLE_VARIOMETER_SWITCH",
            "KEY_TOGGLE_TURN_INDICATOR_SWITCH",
            "KEY_APU_STARTER",
            "KEY_APU_OFF_SWITCH",
            "KEY_APU_GENERATOR_SWITCH_TOGGLE",
            "KEY_APU_GENERATOR_SWITCH_SET",
            "KEY_EXTINGUISH_ENGINE_FIRE",
            "KEY_HYDRAULIC_SWITCH_TOGGLE",
            "KEY_BLEED_AIR_SOURCE_CONTROL_INC",
            "KEY_BLEED_AIR_SOURCE_CONTROL_DEC",
            "KEY_BLEED_AIR_SOURCE_CONTROL_SET",
            "KEY_TURBINE_IGNITION_SWITCH_TOGGLE",
            "KEY_CABIN_NO_SMOKING_ALERT_",
            "KEY_CABIN_SEATBELTS_ALERT_",
            "KEY_ANTISKID_BRAKES_TOGGLE",
            "KEY_GPWS_SWITCH_TOGGLE",
            "KEY_MANUAL_FUEL_PRESSURE_PUMP",
            "KEY_ANNUNCIATOR_SWITCH_TOGGLE",
            "KEY_ANNUNCIATOR_SWITCH_ON",
            "KEY_ANNUNCIATOR_SWITCH_OFF",
            "KEY_STEERING_INC",
            "KEY_STEERING_DEC",
            "KEY_STEERING_SET",
            "KEY_PRESSURIZATION_PRESSURE_ALT_INC",
            "KEY_PRESSURIZATION_PRESSURE_ALT_DEC",
            "KEY_PRESSURIZATION_CLIMB_RATE_INC",
            "KEY_PRESSURIZATION_CLIMB_RATE_DEC",
            "KEY_PRESSURIZATION_PRESSURE_DUMP",
            "KEY_TAKEOFF_ASSIST_ARM_TOGGLE",
            "KEY_TAKEOFF_ASSIST_ARM_SET",
            "KEY_TAKEOFF_ASSIST_FIRE",
            "KEY_TOGGLE_LAUNCH_BAR_SWITCH",
            "KEY_SET_LAUNCHBAR_SWITCH",
            "KEY_ROTOR_BRAKE",
            "KEY_ROTOR_CLUTCH_SWITCH_TOGGLE",
            "KEY_ROTOR_CLUTCH_SWITCH_SET",
            "KEY_ROTOR_GOV_SWITCH_TOGGLE",
            "KEY_ROTOR_GOV_SWITCH_SET",
            "KEY_ROTOR_LATERAL_TRIM_INC",
            "KEY_ROTOR_LATERAL_TRIM_DEC",
            "KEY_ROTOR_LATERAL_TRIM_SET",
            "KEY_SLING_PICKUP_RELEASE",
            "KEY_HOIST_SWITCH_EXTEND",
            "KEY_HOIST_SWITCH_RETRACT",
            "KEY_HOIST_SWITCH_SET",
            "KEY_HOIST_DEPLOY_TOGGLE",
            "KEY_HOIST_DEPLOY_SET",
            "KEY_SLEW_TOGGLE",
            "KEY_SLEW_OFF",
            "KEY_SLEW_ON",
            "KEY_SLEW_SET",
            "KEY_SLEW_RESET",
            "KEY_SLEW_ALTIT_UP_FAST",
            "KEY_SLEW_ALTIT_UP_SLOW",
            "KEY_SLEW_ALTIT_FREEZE",
            "KEY_SLEW_ALTIT_DN_SLOW",
            "KEY_SLEW_ALTIT_DN_FAST",
            "KEY_SLEW_ALTIT_PLUS",
            "KEY_SLEW_ALTIT_MINUS",
            "KEY_SLEW_PITCH_DN_FAST",
            "KEY_SLEW_PITCH_DN_SLOW",
            "KEY_SLEW_PITCH_FREEZE",
            "KEY_SLEW_PITCH_UP_SLOW",
            "KEY_SLEW_PITCH_UP_FAST",
            "KEY_SLEW_PITCH_PLUS",
            "KEY_SLEW_PITCH_MINUS",
            "KEY_SLEW_BANK_MINUS",
            "KEY_SLEW_AHEAD_PLUS",
            "KEY_SLEW_BANK_PLUS",
            "KEY_SLEW_LEFT",
            "KEY_SLEW_FREEZE",
            "KEY_SLEW_RIGHT",
            "KEY_SLEW_HEADING_MINUS",
            "KEY_SLEW_AHEAD_MINUS",
            "KEY_SLEW_HEADING_PLUS",
            "KEY_AXIS_SLEW_AHEAD_SET",
            "KEY_AXIS_SLEW_SIDEWAYS_SET",
            "KEY_AXIS_SLEW_HEADING_SET",
            "KEY_AXIS_SLEW_ALT_SET",
            "KEY_AXIS_SLEW_BANK_SET",
            "KEY_AXIS_SLEW_PITCH_SET",
            "KEY_VIEW_MODE",
            "KEY_VIEW_WINDOW_TO_FRONT",
            "KEY_VIEW_RESET",
            "KEY_VIEW_ALWAYS_PAN_UP",
            "KEY_VIEW_ALWAYS_PAN_DOWN",
            "KEY_NEXT_SUB_VIEW",
            "KEY_PREV_SUB_VIEW",
            "KEY_VIEW_TRACK_PAN_TOGGLE",
            "KEY_VIEW_PREVIOUS_TOGGLE",
            "KEY_VIEW_CAMERA_SELECT_STARTING",
            "KEY_PANEL_HUD_NEXT",
            "KEY_PANEL_HUD_PREVIOUS",
            "KEY_ZOOM_IN",
            "KEY_ZOOM_OUT",
            "KEY_MAP_ZOOM_FINE_IN",
            "KEY_PAN_LEFT",
            "KEY_PAN_RIGHT",
            "KEY_MAP_ZOOM_FINE_OUT",
            "KEY_VIEW_FORWARD",
            "KEY_VIEW_FORWARD_RIGHT",
            "KEY_VIEW_RIGHT",
            "KEY_VIEW_REAR_RIGHT",
            "KEY_VIEW_REAR",
            "KEY_VIEW_REAR_LEFT",
            "KEY_VIEW_LEFT",
            "KEY_VIEW_FORWARD_LEFT",
            "KEY_VIEW_DOWN",
            "KEY_ZOOM_MINUS",
            "KEY_ZOOM_PLUS",
            "KEY_PAN_UP",
            "KEY_PAN_DOWN",
            "KEY_VIEW_MODE_REV",
            "KEY_ZOOM_IN_FINE",
            "KEY_ZOOM_OUT_FINE",
            "KEY_CLOSE_VIEW",
            "KEY_NEW_VIEW",
            "KEY_NEXT_VIEW",
            "KEY_PREV_VIEW",
            "KEY_PAN_LEFT_UP",
            "KEY_PAN_LEFT_DOWN",
            "KEY_PAN_RIGHT_UP",
            "KEY_PAN_RIGHT_DOWN",
            "KEY_PAN_TILT_LEFT",
            "KEY_PAN_TILT_RIGHT",
            "KEY_PAN_RESET",
            "KEY_VIEW_FORWARD_UP",
            "KEY_VIEW_FORWARD_RIGHT_UP",
            "KEY_VIEW_RIGHT_UP",
            "KEY_VIEW_REAR_RIGHT_UP",
            "KEY_VIEW_REAR_UP",
            "KEY_VIEW_REAR_LEFT_UP",
            "KEY_VIEW_LEFT_UP",
            "KEY_VIEW_FORWARD_LEFT_UP",
            "KEY_VIEW_UP",
            "KEY_PAN_RESET_COCKPIT",
            "KEY_CHASE_VIEW_NEXT",
            "KEY_CHASE_VIEW_PREV",
            "KEY_CHASE_VIEW_TOGGLE",
            "KEY_EYEPOINT_UP",
            "KEY_EYEPOINT_DOWN",
            "KEY_EYEPOINT_RIGHT",
            "KEY_EYEPOINT_LEFT",
            "KEY_EYEPOINT_FORWARD",
            "KEY_EYEPOINT_BACK",
            "KEY_EYEPOINT_RESET",
            "KEY_NEW_MAP",
            "KEY_VIEW_COCKPIT_FORWARD",
            "KEY_VIEW_VIRTUAL_COCKPIT_FORWARD",
            "KEY_VIEW_PANEL_ALPHA_SET",
            "KEY_VIEW_PANEL_ALPHA_SELECT",
            "KEY_VIEW_PANEL_ALPHA_INC",
            "KEY_VIEW_PANEL_ALPHA_DEC",
            "KEY_VIEW_LINKING_SET",
            "KEY_VIEW_LINKING_TOGGLE",
            "KEY_VIEW_CHASE_DISTANCE_ADD",
            "KEY_VIEW_CHASE_DISTANCE_SUB",
            "KEY_PAUSE_TOGGLE",
            "KEY_PAUSE_ON",
            "KEY_PAUSE_OFF",
            "KEY_PAUSE_SET",
            "KEY_DEMO_STOP",
            "KEY_SELECT_1",
            "KEY_SELECT_2",
            "KEY_SELECT_3",
            "KEY_SELECT_4",
            "KEY_MINUS",
            "KEY_PLUS",
            "KEY_ZOOM_1X",
            "KEY_SOUND_TOGGLE",
            "KEY_SIM_RATE",
            "KEY_JOYSTICK_CALIBRATE",
            "KEY_SITUATION_SAVE",
            "KEY_SITUATION_RESET",
            "KEY_SOUND_SET",
            "KEY_EXIT",
            "KEY_ABORT",
            "KEY_READOUTS_SLEW",
            "KEY_READOUTS_FLIGHT",
            "KEY_MINUS_SHIFT",
            "KEY_PLUS_SHIFT",
            "KEY_SIM_RATE_INCR",
            "KEY_SIM_RATE_DECR",
            "KEY_KNEEBOARD",
            "KEY_PANEL_1",
            "KEY_PANEL_2",
            "KEY_PANEL_3",
            "KEY_PANEL_4",
            "KEY_PANEL_5",
            "KEY_PANEL_6",
            "KEY_PANEL_7",
            "KEY_PANEL_8",
            "KEY_PANEL_9",
            "KEY_SOUND_ON",
            "KEY_SOUND_OFF",
            "KEY_INVOKE_HELP",
            "KEY_TOGGLE_AIRCRAFT_LABELS",
            "KEY_FLIGHT_MAP",
            "KEY_RELOAD_PANELS",
            "KEY_PANEL_ID_TOGGLE",
            "KEY_PANEL_ID_OPEN",
            "KEY_PANEL_ID_CLOSE",
            "KEY_CONTROL_RELOAD_USER_AIRCRAFT",
            "KEY_SIM_RESET",
            "KEY_VIRTUAL_COPILOT_TOGGLE",
            "KEY_VIRTUAL_COPILOT_SET",
            "KEY_VIRTUAL_COPILOT_ACTION",
            "KEY_REFRESH_SCENERY",
            "KEY_CLOCK_HOURS_DEC",
            "KEY_CLOCK_HOURS_INC",
            "KEY_CLOCK_MINUTES_DEC",
            "KEY_CLOCK_MINUTES_INC",
            "KEY_CLOCK_SECONDS_ZERO",
            "KEY_CLOCK_HOURS_SET",
            "KEY_CLOCK_MINUTES_SET",
            "KEY_ZULU_HOURS_SET",
            "KEY_ZULU_MINUTES_SET",
            "KEY_ZULU_DAY_SET",
            "KEY_ZULU_YEAR_SET",
            "KEY_GAUGE_KEYSTROKE",
            "KEY_SIMUI_WINDOW_HIDESHOW",
            "KEY_WINDOW_TITLES_TOGGLE",
            "KEY_AXIS_PAN_PITCH",
            "KEY_AXIS_PAN_HEADING",
            "KEY_AXIS_PAN_TILT",
            "KEY_AXIS_INDICATOR_CYCLE",
            "KEY_MAP_ORIENTATION_CYCLE",
            "KEY_TOGGLE_JETWAY",
            "KEY_VIDEO_RECORD_TOGGLE",
            "KEY_TOGGLE_AIRPORT_NAME_DISPLAY",
            "KEY_CAPTURE_SCREENSHOT",
            "KEY_MOUSE_LOOK_TOGGLE",
            "KEY_YAXIS_INVERT_TOGGLE",
            "KEY_AUTOCOORD_TOGGLE",
            "KEY_FREEZE_LATITUDE_LONGITUDE_TOGGLE",
            "KEY_FREEZE_LATITUDE_LONGITUDE_SET",
            "KEY_FREEZE_ALTITUDE_TOGGLE",
            "KEY_FREEZE_ALTITUDE_SET",
            "KEY_FREEZE_ATTITUDE_TOGGLE",
            "KEY_FREEZE_ATTITUDE_SET",
            "KEY_POINT_OF_INTEREST_TOGGLE_POINTER",
            "KEY_POINT_OF_INTEREST_CYCLE_PREVIOUS",
            "KEY_POINT_OF_INTEREST_CYCLE_NEXT",
            "KEY_ATC",
            "KEY_ATC_MENU_1",
            "KEY_ATC_MENU_2",
            "KEY_ATC_MENU_3",
            "KEY_ATC_MENU_4",
            "KEY_ATC_MENU_5",
            "KEY_ATC_MENU_6",
            "KEY_ATC_MENU_7",
            "KEY_ATC_MENU_8",
            "KEY_ATC_MENU_9",
            "KEY_ATC_MENU_0",
            "KEY_MULTIPLAYER_TRANSFER_CONTROL",
            "KEY_MULTIPLAYER_PLAYER_CYCLE",
            "KEY_MULTIPLAYER_PLAYER_FOLLOW",
            "KEY_MULTIPLAYER_CHAT",
            "KEY_MULTIPLAYER_ACTIVATE_CHAT",
            "KEY_MULTIPLAYER_VOICE_CAPTURE_START",
            "KEY_MULTIPLAYER_VOICE_CAPTURE_STOP",
            "KEY_MULTIPLAYER_BROADCAST_VOICE_",
            "KEY_TOGGLE_RACERESULTS_WINDOW",
        };

        public static string GetFsEventName(FsEventId id)
        {
            return _fsEventName[(int)id];
        }
    }
}
