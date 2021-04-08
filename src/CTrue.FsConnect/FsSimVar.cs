﻿using System;
using System.Collections.Generic;

namespace CTrue.FsConnect
{
	/// <summary>
	/// The <see cref="FsSimVar"/> enum contains all known simulation variables.
	/// </summary>
	public enum FsSimVar
	{
		None,
		AbsoluteTime,
		ZuluTime,
		ZuluDayOfWeek,
		ZuluDayOfMonth,
		ZuluMonthOfYear,
		ZuluDayOfYear,
		ZuluYear,
		LocalTime,
		LocalDayOfWeek,
		LocalDayOfMonth,
		LocalMonthOfYear,
		LocalDayOfYear,
		LocalYear,
		TimeZoneOffset,
		TimeOfday,
		SimulationRate,
		UnitsOfMeasure,
		AngleOfAttackIndicator,
		GunAmmo,
		CannonAmmo,
		RocketAmmo,
		BombAmmo,
		LightOnStates,
		LightStates,
		LightPanel,
		LightStrobe,
		LightLanding,
		StrobeFlash,
		LightTaxi,
		LightBeacon,
		LightNav,
		LightLogo,
		LightWing,
		LightRecognition,
		LightCabin,
		LandingLightPbh,
		LightNavOn,
		LightBeaconOn,
		LightLandingOn,
		LightTaxiOn,
		LightStrobeOn,
		LightPanelOn,
		LightRecognitionOn,
		LightWingOn,
		LightLogoOn,
		LightCabinOn,
		LightHeadOn,
		LightBrakeOn,
		WheelRpm,
		CenterWheelRpm,
		LeftWheelRpm,
		RightWheelRpm,
		AuxWheelRpm,
		WheelRotationAngle,
		CenterWheelRotationAngle,
		LeftWheelRotationAngle,
		RightWheelRotationAngle,
		AuxWheelRotationAngle,
		SigmaSqrt,
		DynamicPressure,
		TotalVelocity,
		TotalWorldVelocity,
		GroundVelocity,
		SurfaceRelativeGroundSpeed,
		AirspeedTrue,
		AirspeedIndicated,
		AirspeedSelectIndicatedOrTrue,
		AirspeedTrueCalibrate,
		AirspeedBarberPole,
		AirspeedMach,
		VerticalSpeed,
		VariometerRate,
		VariometerSwitch,
		MachMaxOperate,
		StallWarning,
		OverspeedWarning,
		BarberPoleMach,
		VelocityBodyX,
		VelocityBodyY,
		VelocityBodyZ,
		VelocityWorldX,
		VelocityWorldY,
		VelocityWorldZ,
		RelativeWindVelocityBodyX,
		RelativeWindVelocityBodyY,
		RelativeWindVelocityBodyZ,
		AccelerationWorldX,
		AccelerationWorldY,
		AccelerationWorldZ,
		AccelerationBodyX,
		AccelerationBodyY,
		AccelerationBodyZ,
		RotationVelocityBodyX,
		RotationVelocityBodyY,
		RotationVelocityBodyZ,
		DesignSpeedVs0,
		DesignSpeedVs1,
		DesignSpeedVc,
		DesignSpeedMinRotation,
		DesignSpeedClimb,
		DesignCruiseAlt,
		DesignTakeoffSpeed,
		AiControls,
		DelegateControlsToAi,
		MinDragVelocity,
		PlaneLatitude,
		PlaneLongitude,
		PlaneAltitude,
		PlaneAltitudeAboveGround,
		PlanePitchDegrees,
		PlaneBankDegrees,
		PlaneHeadingDegreesMagnetic,
		PlaneHeadingDegreesTrue,
		IndicatedAltitude,
		PressureAltitude,
		KohlsmanSettingMb,
		KohlsmanSettingHg,
		AttitudeIndicatorPitchDegrees,
		AttitudeIndicatorBankDegrees,
		AttitudeBarsPosition,
		AttitudeCage,
		Magvar,
		WiskeyCompassIndicationDegrees,
		MagneticCompass,
		PlaneHeadingDegreesGyro,
		GyroDriftError,
		DeltaHeadingRate,
		TurnIndicatorRate,
		TurnIndicatorSwitch,
		GroundAltitude,
		SimOnGround,
		SimShouldSetOnGround,
		TurnCoordinatorBall,
		YokeYPosition,
		YokeYIndicator,
		YokeXPosition,
		YokeXInidicator,
		YokeXIndicator,
		AileronPosition,
		RudderPedalPosition,
		RudderPedalIndicator,
		RudderPosition,
		ElevatorPosition,
		ElevatorTrimPosition,
		ElevatorTrimIndicator,
		ElevatorTrimPct,
		BrakeLeftPosition,
		BrakeRightPosition,
		BrakeIndicator,
		BrakeParkingPosition,
		BrakeParkingIndicator,
		BrakeDependentHydraulicPressure,
		SpoilersArmed,
		SpoilersHandlePosition,
		SpoilersLeftPosition,
		SpoilersRightPosition,
		FlyByWireElacSwitch,
		FlyByWireFacSwitch,
		FlyByWireSecSwitch,
		FlyByWireElacFailed,
		FlyByWireFacFailed,
		FlyByWireSecFailed,
		FlyByWireAlphaProtection,
		FlapsNumHandlePositions,
		FlapsHandlePercent,
		FlapsHandleIndex,
		TrailingEdgeFlapsLeftPercent,
		TrailingEdgeFlapsRightPercent,
		LeadingEdgeFlapsLeftPercent,
		LeadingEdgeFlapsRightPercent,
		TrailingEdgeFlapsLeftAngle,
		TrailingEdgeFlapsRightAngle,
		LeadingEdgeFlapsLeftAngle,
		LeadingEdgeFlapsRightAngle,
		FlapPositionSet,
		IsGearRetractable,
		IsGearWheels,
		IsGearSkis,
		IsGearFloats,
		IsGearSkids,
		GearHandlePosition,
		GearEmergencyHandlePosition,
		GearCenterPosition,
		GearLeftPosition,
		GearRightPosition,
		GearTailPosition,
		GearAuxPosition,
		GearPosition,
		GearAnimationPosition,
		GearTotalPctExtended,
		GearWarning,
		TailwheelLockOn,
		NosewheelLockOn,
		CowlFlaps,
		AvionicsMasterSwitch,
		PanelAutoFeatherSwitch,
		PanelAntiIceSwitch,
		AutoBrakeSwitchCb,
		AntiskidBrakesActive,
		WaterRudderHandlePosition,
		WaterLeftRudderExtended,
		WaterRightRudderExtended,
		RetractFloatSwitch,
		RetractLeftFloatExtended,
		RetractRightFloatExtended,
		GearCenterSteerAngle,
		GearLeftSteerAngle,
		GearRightSteerAngle,
		GearAuxSteerAngle,
		GearSteerAngle,
		WaterLeftRudderSteerAngle,
		WaterRightRudderSteerAngle,
		GearCenterSteerAnglePct,
		GearLeftSteerAnglePct,
		GearRightSteerAnglePct,
		GearAuxSteerAnglePct,
		GearSteerAnglePct,
		WaterLeftRudderSteerAnglePct,
		WaterRightRudderSteerAnglePct,
		SteerInputControl,
		ElevatorDeflection,
		ElevatorDeflectionPct,
		AileronLeftDeflection,
		AileronLeftDeflectionPct,
		AileronRightDeflection,
		AileronRightDeflectionPct,
		AileronAverageDeflection,
		AileronTrim,
		AileronTrimPct,
		RudderDeflection,
		RudderDeflectionPct,
		RudderTrim,
		RudderTrimPct,
		WingFlexPct,
		WingArea,
		WingSpan,
		PropSyncActive,
		IncidenceAlpha,
		IncidenceBeta,
		BetaDot,
		LinearClAlpha,
		StallAlpha,
		ZeroLiftAlpha,
		CgPercent,
		CgPercentLateral,
		CgAftLimit,
		CgFwdLimit,
		CgMaxMach,
		CgMinMach,
		PayloadStationWeight,
		PayloadStationName,
		PayloadStationCount,
		PayloadStationObject,
		PayloadStationNumSimobjects,
		ElevonDeflection,
		FoldingWingLeftPercent,
		FoldingWingRightPercent,
		FoldingWingHandlePosition,
		CanopyOpen,
		TailhookPosition,
		TailhookHandle,
		LaunchbarPosition,
		LaunchbarSwitch,
		LaunchbarHeldExtended,
		ExitOpen,
		ExitType,
		ExitPosx,
		ExitPosy,
		ExitPosz,
		RadioHeight,
		DecisionHeight,
		DecisionAltitudeMsl,
		TotalWeight,
		MaxGrossWeight,
		EmptyWeight,
		EmptyWeightPitchMoi,
		EmptyWeightRollMoi,
		EmptyWeightYawMoi,
		EmptyWeightCrossCoupledMoi,
		TotalWeightPitchMoi,
		TotalWeightRollMoi,
		TotalWeightYawMoi,
		TotalWeightCrossCoupledMoi,
		WaterBallastValve,
		AutopilotMaster,
		AutopilotWingLeveler,
		AutopilotNav1Lock,
		AutopilotHeadingLock,
		AutopilotHeadingLockDir,
		AutopilotAltitudeLock,
		AutopilotAltitudeLockVar,
		AutopilotAttitudeHold,
		AutopilotGlideslopeHold,
		AutopilotApproachHold,
		AutopilotBackcourseHold,
		AutopilotYawDamper,
		AutopilotAirspeedHold,
		AutopilotAirspeedHoldVar,
		AutopilotMachHold,
		AutopilotMachHoldVar,
		AutopilotVerticalHold,
		AutopilotVerticalHoldVar,
		AutopilotAltitudeManuallyTunable,
		AutopilotHeadingManuallyTunable,
		AutopilotThrottleArm,
		AutopilotTakeoffPowerActive,
		AutopilotRpmHold,
		AutopilotRpmHoldVar,
		AutopilotSpeedSetting,
		AutopilotAirspeedAcquisition,
		AutopilotAirspeedHoldCurrent,
		AutopilotMaxSpeedHold,
		AutopilotCruiseSpeedHold,
		AutopilotFlightDirectorActive,
		AutopilotFlightDirectorPitch,
		AutopilotFlightDirectorBank,
		AutopilotPitchHold,
		AutopilotPitchHoldRef,
		AutopilotNavSelected,
		GpsDrivesNav1,
		AutothrottleActive,
		AutopilotMaxBank,
		NumberOfCatapults,
		HoldbackBarInstalled,
		BlastShieldPosition,
		CatapultStrokePosition,
		EngineControlSelect,
		NumberOfEngines,
		MaxRatedEngineRpm,
		PropellerAdvancedSelection,
		ThrottleLowerLimit,
		OilAmount,
		EnginePrimer,
		EngineType,
		EngRpmAnimationPercent,
		FullThrottleThrustToWeightRatio,
		PropRpm,
		PropMaxRpmPercent,
		PropThrust,
		PropBeta,
		PropFeatheringInhibit,
		PropFeathered,
		PropSyncDeltaLever,
		PropAutoFeatherArmed,
		PropFeatherSwitch,
		PropAutoCruiseActive,
		PropRotationAngle,
		PropBetaMax,
		PropBetaMin,
		PropBetaMinReverse,
		MasterIgnitionSwitch,
		EngCombustion,
		OldEngStarter,
		EngN1Rpm,
		EngN2Rpm,
		EngFuelFlowGph,
		EngFuelFlowPph,
		EngFuelFlowPphSsl,
		EngTorque,
		EngAntiIce,
		EngPressureRatio,
		EngPressureRatioGes,
		EngExhaustGasTemperature,
		EngExhaustGasTemperatureGes,
		EngCylinderHeadTemperature,
		EngOilTemperature,
		EngOilPressure,
		EngOilQuantity,
		EngHydraulicPressure,
		EngHydraulicQuantity,
		EngManifoldPressure,
		EngVibration,
		EngRpmScaler,
		EngTurbineTemperature,
		EngTorquePercent,
		EngFuelPressure,
		EngElectricalLoad,
		EngTransmissionPressure,
		EngTransmissionTemperature,
		EngRotorRpm,
		EngFuelFlowBugPosition,
		EngMaxRpm,
		EngOnFire,
		GeneralEngCombustion,
		GeneralEngMasterAlternator,
		GeneralEngFuelPumpSwitch,
		GeneralEngFuelPumpOn,
		GeneralEngRpm,
		GeneralEngPctMaxRpm,
		GeneralEngMaxReachedRpm,
		GeneralEngThrottleLeverPosition,
		GeneralEngMixtureLeverPosition,
		GeneralEngPropellerLeverPosition,
		GeneralEngStarter,
		GeneralEngStarterActive,
		GeneralEngExhaustGasTemperature,
		GeneralEngOilPressure,
		GeneralEngOilLeakedPercent,
		GeneralEngCombustionSoundPercent,
		GeneralEngDamagePercent,
		GeneralEngOilTemperature,
		GeneralEngFailed,
		GeneralEngGeneratorSwitch,
		GeneralEngGeneratorActive,
		GeneralEngAntiIcePosition,
		GeneralEngFuelValve,
		GeneralEngFuelPressure,
		GeneralEngElapsedTime,
		GeneralEngFireDetected,
		GeneralEngFuelUsedSinceStart,
		RecipEngCowlFlapPosition,
		RecipEngPrimer,
		RecipEngManifoldPressure,
		RecipEngAlternateAirPosition,
		RecipEngCoolantReservoirPercent,
		RecipEngLeftMagneto,
		RecipEngRightMagneto,
		RecipEngBrakePower,
		RecipEngStarterTorque,
		RecipEngTurbochargerFailed,
		RecipEngEmergencyBoostActive,
		RecipEngEmergencyBoostElapsedTime,
		RecipEngWastegatePosition,
		RecipEngTurbineInletTemperature,
		RecipEngCylinderHeadTemperature,
		RecipEngRadiatorTemperature,
		RecipEngFuelAvailable,
		RecipEngFuelFlow,
		RecipEngFuelTankSelector,
		RecipEngFuelTanksUsed,
		RecipEngFuelNumberTanksUsed,
		RecipEngDetonating,
		RecipEngCylinderHealth,
		RecipEngNumCylinders,
		RecipEngNumCylindersFailed,
		RecipCarburetorTemperature,
		RecipMixtureRatio,
		RecipEngAntidetonationTankValve,
		RecipEngAntidetonationTankQuantity,
		RecipEngAntidetonationTankMaxQuantity,
		RecipEngNitrousTankValve,
		RecipEngNitrousTankQuantity,
		RecipEngNitrousTankMaxQuantity,
		TurbEngN1,
		TurbEngN2,
		TurbEngCorrectedN1,
		TurbEngCorrectedN2,
		TurbEngCorrectedFf,
		TurbEngMaxTorquePercent,
		TurbEngPressureRatio,
		TurbEngItt,
		TurbEngAfterburner,
		TurbEngAfterburnerStageActive,
		TurbEngAfterburnerPctActive,
		TurbEngJetThrust,
		TurbEngBleedAir,
		TurbEngTankSelector,
		TurbEngTanksUsed,
		TurbEngNumTanksUsed,
		TurbEngFuelFlowPph,
		TurbEngFuelAvailable,
		TurbEngPrimaryNozzlePercent,
		TurbEngReverseNozzlePercent,
		TurbEngVibration,
		TurbEngIgnitionSwitch,
		TurbEngMasterStarterSwitch,
		EngFailed,
		PartialPanelAdf,
		PartialPanelAirspeed,
		PartialPanelAltimeter,
		PartialPanelAttitude,
		PartialPanelComm,
		PartialPanelCompass,
		PartialPanelElectrical,
		PartialPanelAvionics,
		PartialPanelEngine,
		PartialPanelFuelIndicator,
		PartialPanelHeading,
		PartialPanelVerticalVelocity,
		PartialPanelTransponder,
		PartialPanelNav,
		PartialPanelPitot,
		PartialPanelTurnCoordinator,
		PartialPanelVacuum,
		FuelTankCenterLevel,
		FuelTankCenterCapacity,
		FuelTankCenterQuantity,
		FuelTankCenter2Level,
		FuelTankCenter2Capacity,
		FuelTankCenter2Quantity,
		FuelTankCenter3Level,
		FuelTankCenter3Capacity,
		FuelTankCenter3Quantity,
		FuelTankLeftMainLevel,
		FuelTankLeftMainCapacity,
		FuelTankLeftMainQuantity,
		FuelTankLeftAuxLevel,
		FuelTankLeftAuxCapacity,
		FuelTankLeftAuxQuantity,
		FuelTankLeftTipLevel,
		FuelTankLeftTipCapacity,
		FuelTankLeftTipQuantity,
		FuelLeftQuantity,
		FuelTankRightMainLevel,
		FuelTankRightMainCapacity,
		FuelTankRightMainQuantity,
		FuelTankRightAuxLevel,
		FuelTankRightAuxCapacity,
		FuelTankRightAuxQuantity,
		FuelTankRightTipLevel,
		FuelTankRightTipCapacity,
		FuelTankRightTipQuantity,
		FuelRightQuantity,
		FuelTankExternal1Level,
		FuelTankExternal1Capacity,
		FuelTankExternal1Quantity,
		FuelTankExternal2Level,
		FuelTankExternal2Capacity,
		FuelTankExternal2Quantity,
		FuelTotalQuantity,
		FuelTotalCapacity,
		FuelLeftCapacity,
		FuelRightCapacity,
		FuelWeightPerGallon,
		FuelTankSelector,
		FuelCrossFeed,
		NumFuelSelectors,
		FuelSelectedQuantityPercent,
		FuelSelectedQuantity,
		FuelTotalQuantityWeight,
		FuelSelectedTransferMode,
		FuelDumpSwitch,
		FuelDumpActive,
		DroppableObjectsCount,
		DroppableObjectsType,
		DroppableObjectsUiName,
		WarningFuel,
		WarningFuelLeft,
		WarningFuelRight,
		WarningVacuum,
		WarningVacuumLeft,
		WarningVacuumRight,
		WarningOilPressure,
		WarningVoltage,
		WarningLowHeight,
		AutopilotAvailable,
		FlapsAvailable,
		StallHornAvailable,
		EngineMixureAvailable,
		CarbHeatAvailable,
		SpoilerAvailable,
		StrobesAvailable,
		PropTypeAvailable,
		ToeBrakesAvailable,
		IsTailDragger,
		SystemsAvailable,
		InstrumentsAvailable,
		FuelPump,
		ManualFuelPumpHandle,
		AlternateStaticSourceOpen,
		BleedAirSourceControl,
		ElectricalMasterBattery,
		ElectricalOldChargingAmps,
		ElectricalTotalLoadAmps,
		ElectricalBatteryLoad,
		ElectricalBatteryVoltage,
		ElectricalMainBusVoltage,
		ElectricalMainBusAmps,
		ElectricalAvionicsBusVoltage,
		ElectricalAvionicsBusAmps,
		ElectricalHotBatteryBusVoltage,
		ElectricalHotBatteryBusAmps,
		ElectricalBatteryBusVoltage,
		ElectricalBatteryBusAmps,
		ElectricalGenaltBusVoltage,
		ElectricalGenaltBusAmps,
		CircuitGeneralPanelOn,
		CircuitFlapMotorOn,
		CircuitGearMotorOn,
		CircuitAutopilotOn,
		CircuitAvionicsOn,
		CircuitPitotHeatOn,
		CircuitPropSyncOn,
		CircuitAutoFeatherOn,
		CircuitAutoBrakesOn,
		CircuitStandyVacuumOn,
		CircuitStandbyVacuumOn,
		CircuitMarkerBeaconOn,
		CircuitGearWarningOn,
		CircuitHydraulicPumpOn,
		AmbientDensity,
		AmbientTemperature,
		AmbientPressure,
		AmbientWindVelocity,
		AmbientWindDirection,
		AmbientWindX,
		AmbientWindY,
		AmbientWindZ,
		AmbientPrecipState,
		AmbientInCloud,
		AmbientVisibility,
		BarometerPressure,
		SeaLevelPressure,
		TotalAirTemperature,
		StandardAtmTemperature,
		AircraftWindX,
		AircraftWindY,
		AircraftWindZ,
		HydraulicPressure,
		HydraulicReservoirPercent,
		HydraulicSystemIntegrity,
		HydraulicSwitch,
		GearHydraulicPressure,
		ConcordeVisorNoseHandle,
		ConcordeVisorPositionPercent,
		ConcordeNoseAngle,
		RadiosAvailable,
		ComTransmit,
		ComReceiveAll,
		ComRecieveAll,
		NavSound,
		DmeSound,
		AdfSound,
		AdfCard,
		MarkerSound,
		ComAvailable,
		ComActiveFrequency,
		ComStandbyFrequency,
		ComStatus,
		ComTest,
		TransponderAvailable,
		TransponderCode,
		AdfAvailable,
		AdfFrequency,
		AdfExtFrequency,
		AdfActiveFrequency,
		AdfStandbyFrequency,
		AdfLatlonalt,
		AdfSignal,
		AdfRadial,
		AdfIdent,
		AdfName,
		NavAvailable,
		NavActiveFrequency,
		NavStandbyFrequency,
		NavSignal,
		NavIdent,
		NavName,
		NavCodes,
		NavHasNav,
		NavHasLocalizer,
		NavHasDme,
		NavHasGlideSlope,
		NavBackCourseFlags,
		NavMagvar,
		NavRadial,
		NavRadialError,
		NavLocalizer,
		NavGlideSlope,
		NavGlideSlopeError,
		NavCdi,
		NavGsi,
		NavTofrom,
		NavGsFlag,
		NavObs,
		NavDme,
		NavDmespeed,
		NavVorLatlonalt,
		NavGsLatlonalt,
		NavDmeLatlonalt,
		NavRelativeBearingToStation,
		MarkerBeaconState,
		InnerMarker,
		MiddleMarker,
		OuterMarker,
		InnerMarkerLatlonalt,
		MiddleMarkerLatlonalt,
		OuterMarkerLatlonalt,
		SelectedDme,
		Realism,
		AutoCoordination,
		UnlimitedFuel,
		RealismCrashWithOthers,
		RealismCrashDetection,
		ManualInstrumentLights,
		TrueAirspeedSelected,
		AtcType,
		AtcModel,
		AtcHeavy,
		AtcId,
		AtcAirline,
		AtcFlightNumber,
		StructLatlonalt,
		StructLatlonaltpbh,
		StructPbh32,
		StructDamagevisible,
		StructSurfaceRelativeVelocity,
		StructWorldvelocity,
		StructWorldRotationVelocity,
		StructBodyVelocity,
		StructBodyRotationVelocity,
		StructBodyRotationAcceleration,
		StructWorldAcceleration,
		StructEnginePosition,
		StructAmbientWind,
		StructRealismVars,
		StrucHeadingHoldPidConsts,
		StrucAirspeedHoldPidConsts,
		StructEyepointDynamicAngle,
		StructEyepointDynamicOffset,
		PitotHeat,
		PitotIcePct,
		SmokeEnable,
		SmokesystemAvailable,
		GForce,
		SemibodyLoadfactorX,
		SemibodyLoadfactorY,
		SemibodyLoadfactorZ,
		SemibodyLoadfactorYdot,
		MaxGForce,
		MinGForce,
		SuctionPressure,
		RadInsSwitch,
		TypicalDescentRate,
		VisualModelRadius,
		SimulatedRadius,
		IsUserSim,
		Controllable,
		HeadingIndicator,
		Title,
		Category,
		SimDisabled,
		PropDeiceSwitch,
		StructuralDeiceSwitch,
		StructuralIcePct,
		ArtificialGroundElevation,
		SurfaceInfoValid,
		SurfaceType,
		SurfaceCondition,
		PushbackState,
		PushbackAngle,
		PushbackContactx,
		PushbackContacty,
		PushbackContactz,
		PushbackWait,
		HsiCdiNeedle,
		HsiGsiNeedle,
		HsiCdiNeedleValid,
		HsiGsiNeedleValid,
		HsiTfFlags,
		HsiBearing,
		HsiBearingValid,
		HsiHasLocalizer,
		HsiSpeed,
		HsiDistance,
		HsiStationIdent,
		IsSlewActive,
		IsSlewAllowed,
		AtcSuggestedMinRwyTakeoff,
		AtcSuggestedMinRwyLanding,
		YawStringAngle,
		YawStringPctExtended,
		InductorCompassPercentDeviation,
		InductorCompassHeadingRef,
		AnemometerPctRpm,
		GpsPositionLat,
		GpsPositionLon,
		GpsPositionAlt,
		GpsMagvar,
		GpsIsActiveFlightPlan,
		GpsIsActiveWayPoint,
		GpsIsArrived,
		GpsIsDirecttoFlightplan,
		GpsGroundSpeed,
		GpsGroundTrueHeading,
		GpsGroundMagneticTrack,
		GpsGroundTrueTrack,
		GpsEte,
		GpsEta,
		GpsWpDistance,
		GpsWpBearing,
		GpsWpTrueBearing,
		GpsWpCrossTrk,
		GpsWpDesiredTrack,
		GpsWpTrueReqHdg,
		GpsWpVerticalSpeed,
		GpsWpTrackAngleError,
		GpsWpNextId,
		GpsWpNextLat,
		GpsWpNextLon,
		GpsWpNextAlt,
		GpsWpPrevValid,
		GpsWpPrevId,
		GpsWpPrevLat,
		GpsWpPrevLon,
		GpsWpPrevAlt,
		GpsWpEte,
		GpsWpEta,
		GpsCourseToSteer,
		GpsFlightPlanWpIndex,
		GpsFlightPlanWpCount,
		GpsIsActiveWpLocked,
		GpsIsApproachLoaded,
		GpsIsApproachActive,
		GpsApproachMode,
		GpsApproachWpType,
		GpsApproachIsWpRunway,
		GpsApproachSegmentType,
		GpsApproachAirportId,
		GpsApproachApproachIndex,
		GpsApproachApproachId,
		GpsApproachApproachType,
		GpsApproachTransitionIndex,
		GpsApproachTransitionId,
		GpsApproachIsFinal,
		GpsApproachIsMissed,
		GpsApproachTimezoneDeviation,
		GpsApproachWpIndex,
		GpsApproachWpCount,
		GpsTargetDistance,
		GpsTargetAltitude,
		UserInputEnabled,
		RotorBrakeHandlePos,
		RotorBrakeActive,
		RotorClutchSwitchPos,
		RotorClutchActive,
		RotorTemperature,
		RotorChipDetected,
		RotorGovSwitchPos,
		RotorGovActive,
		RotorLateralTrimPct,
		RotorRpmPct,
		RotorRotationAngle,
		CollectivePosition,
		DiskPitchAngle,
		DiskBankAngle,
		DiskPitchPct,
		DiskBankPct,
		DiskConingPct,
		GearDamageBySpeed,
		GearSpeedExceeded,
		FlapDamageBySpeed,
		FlapSpeedExceeded,
		EstimatedCruiseSpeed,
		EstimatedFuelFlow,
		EyepointPosition,
		NavVorLlaf64,
		NavGsLlaf64,
		NavRawGlideSlope,
		WindshieldRainEffectAvailable,
		StaticCgToGround,
		StaticPitch,
		CrashSequence,
		CrashFlag,
		ApplyHeatToSystems,
		TowReleaseHandle,
		TowConnection,
		ApuPctRpm,
		ApuPctStarter,
		ApuVolts,
		ApuGeneratorSwitch,
		ApuGeneratorActive,
		ApuOnFireDetected,
		PressurizationCabinAltitude,
		PressurizationCabinAltitudeGoal,
		PressurizationCabinAltitudeRate,
		PressurizationPressureDifferential,
		PressurizationDumpSwitch,
		FireBottleSwitch,
		FireBottleDischarged,
		CabinNoSmokingAlertSwitch,
		CabinSeatbeltsAlertSwitch,
		GpwsWarning,
		GpwsSystemActive,
		IsLatitudeLongitudeFreezeOn,
		IsAltitudeFreezeOn,
		IsAttitudeFreezeOn,
		NumSlingCables,
		SlingObjectAttached,
		SlingCableBroken,
		SlingCableExtendedLength,
		SlingActivePayloadStation,
		SlingHoistPercentDeployed,
		SlingHoistSwitch,
		SlingHookInPickupMode,
		IsAttachedToSling,
		CableCaughtByTailhook,
		ExternalSystemValue,
		AnnunciatorSwitch,
		AutobrakesActive,
		RejectedTakeoffBrakesActive,
		ShutoffValvePulled,
		LightPotentiometer,
		FakeAcLwr,
		FakeAcUpr,
		FakeAcTrimL,
		FakeAcTrimR,
		FakeWindowHeatL,
		FakeWindowHeatR,
		FakeBusTie,
		FakeExtPwr,
		FakeGenCont,
		FakeUtilPwrL,
		FakeUtilPwrR,
		FakeCrtTankPumpL,
		FakeCrtTankPumpR,
		FakeFuelMainAft,
		FakeFuelMainFwd,
		FakeFuelOvrdAft,
		FakeFuelOvrdFwd,
		FakeStabTankPumpL,
		FakeStabTankPumpR,
		FakeHydPumpSwitch,
		FakeO2YdLower,
		FakeO2YdUpper,
		FakeApuBleed,
		FakeBleed,
		FakeIsolationValveL,
		FakeIsolationValveR,
		FakeAcFltDeck,
		FakeAcPassTemp,
		FakeStandbyPower,
		FakeDemandPumpSel,
		FakeIrsC,
		FakeIrsL,
		FakeIrsR,
		FakeAntiIceNacelle,
		FakeAntiIceWing,
		FakeOutflowValves,
		FakeXfeed,
		FakeEec,
		FakePack,
		FakeEmergLights,
		FakeTrimStab,
		FakeCargoArmAft,
		FakeXpndr,
		FakeIdent,
		FakeNoSmoking,
		FakeSeatbelts,
		FakeCargoTemp,
		FakeEmergencyLight,
		AutopilotDisengaged,
		FakeApuGenSwitch,
		BreakerAvnfan,
		BreakerAutopilot,
		BreakerGps,
		BreakerNavcom1,
		BreakerNavcom2,
		BreakerNavcom3,
		BreakerAdf,
		BreakerXpndr,
		BreakerFlap,
		BreakerInst,
		BreakerAvnbus1,
		BreakerAvnbus2,
		BreakerTurncoord,
		BreakerInstlts,
		BreakerAltfld,
		BreakerWarn,
		BreakerLtsPwr,
		PilotTransmitterType,
		CopilotTransmitterType,
		PilotTransmitting,
		CopilotTransmitting,
		SpeakerActive,
		IntercomSystemActive,
		AudioPanelVolume,
		MarkerBeaconSensitivityHigh,
		MarkerBeaconTestMute,
		IntercomMode,
		ComReceive,
		AutopilotAltitudeArm,
		ComVolume,
		NavVolume,
		AtcClearedIfr,
		AtcIfrFpToRequest,
		AtcRunwaySelected,
		AtcTaxipathDistance,
		AtcRunwayStartDistance,
		AtcRunwayEndDistance,
		AtcRunwayDistance,
		AtcRunwayRelativePositionX,
		AtcRunwayRelativePositionY,
		AtcRunwayRelativePositionZ,
		AtcRunwayTdpointRelativePositionX,
		AtcRunwayTdpointRelativePositionY,
		AtcRunwayTdpointRelativePositionZ,
		AtcRunwayHeadingDegreesTrue,
		AtcRunwayLength,
		AtcRunwayWidth,
		AtcRunwayAirportName,
		SlopeToAtcRunway,
		AtcClearedTakeoff,
		AtcClearedLanding,
		AtcClearedTaxi,
		OnAnyRunway,
		AtcFlightplanDiffHeading,
		AtcFlightplanDiffAlt,
		AtcFlightplanDiffDistance,
		AtcPreviousWaypointAltitude,
		AtcCurrentWaypointAltitude,
		AssistanceLandingEnabled,
		Com1StoredFrequency,
		Com2StoredFrequency,
		Com3StoredFrequency,
		RudderTrimDisabled,
		AileronTrimDisabled,
		ElevatorTrimDisabled,
		PlaneTouchdownLatitude,
		PlaneTouchdownLongitude,
		PlaneTouchdownPitchDegrees,
		PlaneTouchdownBankDegrees,
		PlaneTouchdownHeadingDegreesMagnetic,
		PlaneTouchdownHeadingDegreesTrue,
		PlaneTouchdownNormalVelocity,
		TurbEngIgnitionSwitchEx1,
		TurbEngIsIgniting,
		PlaneInParkingState,
		EltActivated,
		RecipEngEngineMasterSwitch,
		RecipEngGlowPlugActive,
		LightGlareshield,
		LightPedestral,
		LightGlareshieldOn,
		LightPedestralOn,
		CircuitNavcom1On,
		CircuitNavcom2On,
		CircuitNavcom3On,
		AirspeedTrueRaw,
		GeneralEngFuelPumpSwitchEx1,
		FuelTransferPumpOn,
		IsAnyInteriorLightOn,
		GpsFlightplanTotalDistance,
		CircuitOn,
		CircuitSwitchOn,
		BusLookupIndex,
		BusConnectionOn,
		BatteryConnectionOn,
		AlternatorConnectionOn,
		CircuitConnectionOn,
		BusBreakerPulled,
		BatteryBreakerPulled,
		AlternatorBreakerPulled,
		CircuitBreakerPulled,
		CameraState,
		CameraSubstate,
		SmartCameraActive,
		CameraRequestAction,
		AdfVolume,
		BleedAirApu,
		BleedAirEngine,
		ApuBleedToEngine,
		ExternalPowerConnectionOn,
		ExternalPowerBreakerPulled,
		ExternalPowerAvailable,
		ExternalPowerOn,
	};
}