using System;
using System.Runtime.InteropServices;

namespace UnitViewer
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct CUnit
    {
        [FieldOffset(0x000)] public /*(CUnit*)*/UInt32 prev;
        [FieldOffset(0x004)] public /*(CUnit*)*/UInt32 next; // Pointer to next unit in the unit linked list
        [FieldOffset(0x008)] public Int32 hitPoints; // Hit points of unit, note that the displayed value in broodwar is ceil(healthPoints/256)
        [FieldOffset(0x00C)] public /*(CSprite*)*/UInt32 sprite;
        [FieldOffset(0x010)] public /*(TargetStructLow)*/UInt32 moveTargetA; // The position or unit to move to. It is NOT an order target.
        [FieldOffset(0x014)] public /*(TargetStructHigh)*/UInt32 moveTargetB;
        [FieldOffset(0x018)] public UInt32 nextMovementWaypoint; /* The next way point in the path the unit is following to get
                                                           to its destination. Equal to moveToPos for air units since they
                                                           don't need to navigate around buildings or other units.*/
        [FieldOffset(0x01C)] public UInt32 nextTargetWaypoint; // The desired position
        [FieldOffset(0x020)] public byte movementFlags; // Flags specifying movement type - defined in BW#MovementFlags.
        [FieldOffset(0x021)] public byte currentDirection1; // The current direction the unit is facing
        [FieldOffset(0x022)] public byte flingyTurnRadius;
        [FieldOffset(0x023)] public byte velocityDirection1; /* This usually only differs from the currentDirection field for units that can accelerate
												    and travel in a different direction than they are facing. For example Mutalisks can change
												    the direction they are facing faster than then can change the direction they are moving.*/
        [FieldOffset(0x024)] public UInt16 flingyID;
        [FieldOffset(0x026)] public byte _unknown_0x026;
        [FieldOffset(0x027)] public byte flingyMovementType;
        [FieldOffset(0x028)] public UInt32 position; // Current position of the unit
        [FieldOffset(0x02C)] public UInt32 haltX;
        [FieldOffset(0x030)] public UInt32 haltY;
        [FieldOffset(0x034)] public UInt32 flingyTopSpeed;
        [FieldOffset(0x038)] public Int32 current_speed1;
        [FieldOffset(0x03C)] public Int32 current_speed2;
        [FieldOffset(0x040)] public UInt32 current_speedX;
        [FieldOffset(0x044)] public UInt32 current_speedY;
        [FieldOffset(0x048)] public UInt16 flingyAcceleration;
        [FieldOffset(0x04A)] public byte currentDirection2;
        [FieldOffset(0x04B)] public byte velocityDirection; // pathing related, gets this value from Path::unk_1A?
        [FieldOffset(0x04C)] public byte playerID; // Specification of owner of this unit.
        [FieldOffset(0x04D)] public byte orderID; // Specification of type of order currently given.
        [FieldOffset(0x04E)] public byte orderState; //< Additional order info (mostly unknown, wander property investigated so far)  // officially "ubActionState"
                                /*  0x01  Moving/Following Order
                                0x02  No collide (Larva)?
                                0x04  Harvesting? Working?
                                0x08  Constructing Stationary
                                Note: I don't actually think these are flags
                                */
        [FieldOffset(0x04F)] public byte orderSignal;  /*  0x01  Update building graphic/state
										  0x02  Casting spell
										  0x04  Reset collision? Always enabled for hallucination...
										  0x10  Lift/Land state
										  */
        [FieldOffset(0x050)] public UInt16 orderUnitType; // officially "uwFoggedTarget"
        [FieldOffset(0x052)] public UInt16 __0x52; // 2-byte padding
        [FieldOffset(0x054)] public byte mainOrderTimer; // A timer for orders, example: time left before minerals are harvested
        [FieldOffset(0x055)] public byte groundWeaponCooldown;
        [FieldOffset(0x056)] public byte airWeaponCooldown;
        [FieldOffset(0x057)] public byte spellCooldown;
        [FieldOffset(0x058)] public UInt32 orderTargetX;
        [FieldOffset(0x05C)] public UInt32 orderTargetY;
        [FieldOffset(0x060)] public UInt32 shieldPoints; // BW shows this value/256, possibly not u32?
        [FieldOffset(0x064)] public UInt16 unitType; // Specifies the type of unit.
        [FieldOffset(0x066)] public UInt16 __0x66; // 2-byte padding

        // CLink<CUnit> player_link;
        [FieldOffset(0x068)] public /*(CUnit*)*/UInt32 previousPlayerUnit;
        [FieldOffset(0x06C)] public /*(CUnit*)*/UInt32 nextPlayerUnit;
        [FieldOffset(0x070)] public /*(CUnit*)*/UInt32 subUnit;

        // CLink<COrder> orderQueue_link;
        [FieldOffset(0x074)] public /*(COrder*)*/ UInt32 orderQueueHead;
        [FieldOffset(0x078)] public /*(COrder*)*/ UInt32 orderQueueTail;

        [FieldOffset(0x07C)] public /*(CUnit*)*/ UInt32 autoTargetUnit; // The auto-acquired target (Note: This field is actually used for different targets internally, especially by the AI)
        [FieldOffset(0x080)] public /*(CUnit*)*/ UInt32 connectedUnit; // Addon is connected to building (addon has conntected building, but not in other direction  (officially "pAttached")
        [FieldOffset(0x084)] public byte orderQueueCount; // @todo Verify   // officially "ubQueuedOrders"
        [FieldOffset(0x085)] public byte orderQueueTimer; // counts/cycles down from from 8 to 0 (inclusive). See also 0x122.
        [FieldOffset(0x086)] public byte _unknown_0x086; // pathing related?
        [FieldOffset(0x087)] public byte attackNotifyTimer; // Prevent "Your forces are under attack." on every attack
        [FieldOffset(0x088)] public UInt16 displayedUnitID;
        [FieldOffset(0x08A)] public byte lastEventTimer; // countdown that stops being recent when it hits 0 
        [FieldOffset(0x08B)] public byte lastEventColor; // 17 = was completed (train, morph), 174 = was attacked
        [FieldOffset(0x08C)] public UInt16 _unused_0x08C; // might have originally been RGB from lastEventColor
        [FieldOffset(0x08E)] public byte rankIncrease; // Adds this value to the unit's base rank
        [FieldOffset(0x08F)] public byte killCount; // Killcount
        [FieldOffset(0x090)] public byte lastAttackingPlayer; // the player that last attacked this unit
        [FieldOffset(0x091)] public byte secondaryOrderTimer;
        [FieldOffset(0x092)] public byte AIActionFlag; // Internal use by AI only
        [FieldOffset(0x093)] public byte userActionFlags; // some flags that change when the user interacts with the unit
                                   // 2 = issued an order, 3 = interrupted an order, 4 = self destructing

        [FieldOffset(0x094)] public UInt16 currentButtonSet; // The u16 is a guess, used to be u8
        [FieldOffset(0x096)] public byte isCloaked;
        [FieldOffset(0x097)] public byte movementState; // A value based on conditions related to pathing, see Path.h for info
        [FieldOffset(0x098)] public fixed UInt16 buildQueue[5]; //< Queue of units to build. Note that it doesn't begin with index 0, but with #buildQueueSlot index. 
        [FieldOffset(0x0A2)] public UInt16 energy; //< Energy Points   // officially "xwMagic"
        [FieldOffset(0x0A4)] public byte buildQueueSlot; //< Index of active unit in #buildQueue. 
        [FieldOffset(0x0A5)] public byte targetOrderSpecial; //< A byte used to determine the target ID for the unit 
        [FieldOffset(0x0A6)] public byte secondaryOrderID; //< (Build addon verified) @todo verify (Cloak, Build, ExpandCreep suggested by EUDDB) 
        [FieldOffset(0x0A7)] public byte buildingOverlayState; // 0 means the building has the largest amount of fire/blood
        [FieldOffset(0x0A8)] public UInt16 hpGainDuringRepair; //< @todo Verify 
        [FieldOffset(0x0AA)] public UInt16 _unknown_0x0AA;
        [FieldOffset(0x0AC)] public UInt16 remainingBuildTime; //< Remaining bulding time; This is also the timer for powerups (flags) to return to their original location.
        [FieldOffset(0x0AE)] public UInt16 previousHP; // The HP of the unit before it changed (example Drone->Hatchery, the Drone's HP will be stored here)
        [FieldOffset(0x0B0)] public fixed UInt16 loadedUnitIndex[8]; // officially called "uwTransport[8]"
        
        // Start union
        // Vulture
        [FieldOffset(0x0C0)] public byte spiderMineCount;

        // Carrier
        [FieldOffset(0x0C0)] public /*(CUnit*)*/UInt32 pInHanger; // first child inside the hanger
        [FieldOffset(0x0C4)] public /*(CUnit*)*/UInt32 pOutHanger; // first child outside the hanger
        [FieldOffset(0x0C8)] public byte inHangerCount; // number inside the hanger
        [FieldOffset(0x0C9)] public byte outHangerCount; // number outside the hanger

        // Fighter
        [FieldOffset(0x0C0)] public /*(CUnit*)*/UInt32 parent;
        [FieldOffset(0x0C4)] public /*(CUnit*)*/UInt32 fighterPrev;
        [FieldOffset(0x0C8)] public /*(CUnit*)*/UInt32 fighterNext;
        [FieldOffset(0x0CC)] public /*(bool)*/byte inHanger;

        // Beacon
        [FieldOffset(0x0C0)] public UInt32 _unknown_00;
        [FieldOffset(0x0C4)] public UInt32 _unknown_04;
        [FieldOffset(0x0C8)] public UInt32 flagSpawnFrame; // flag beacons, the frame that the flag will spawn

        // Building
        [FieldOffset(0x0C0)] public /*(CUnit*)*/UInt32 addon;
        [FieldOffset(0x0C4)] public UInt16 addonBuildType;
        [FieldOffset(0x0C6)] public UInt16 upgradeResearchTime;
        [FieldOffset(0x0C8)] public byte techType;
        [FieldOffset(0x0C9)] public byte upgradeType;
        [FieldOffset(0x0CA)] public byte larvaTimer;
        [FieldOffset(0x0CB)] public byte landingTimer;
        [FieldOffset(0x0CC)] public byte creepTimer;
        [FieldOffset(0x0CD)] public byte upgradeLevel;
        [FieldOffset(0x0CE)] public UInt16 __E; // 2-byte padding

        // Start nested union
        // Building?_Resource (when the unit is a resource container)
        [FieldOffset(0x0D0)] public UInt16 resourceCount; // amount of resources
        [FieldOffset(0x0D2)] public byte resourceIScript;
        [FieldOffset(0x0D3)] public byte gatherQueueCount;
        [FieldOffset(0x0D4)] public /*(CUnit*)*/UInt32 nextGatherer; // pointer to the next workerunit waiting in line to gather
        [FieldOffset(0x0D8)] public byte resourceGroup;
        [FieldOffset(0x0D9)] public byte resourceBelongsToAI;

        // Building?_Nydus
        [FieldOffset(0x0D0)] public /*(CUnit*)*/UInt32 nydus; // connected nydus canal

        // Building?_Ghost
        [FieldOffset(0x0D0)] public /*(CSprite*)*/UInt32 nukeDot;

        // Building?_Pylon
        [FieldOffset(0x0D0)] public /*(CSprite*)*/UInt32 pylonAura;

        // Building?_Silo
        [FieldOffset(0x0D0)] public /*(CUnit*)*/UInt32 pNuke;
        [FieldOffset(0x0D4)] public /*(bool)*/byte bReady;

        // Building?_Hatchery
        [FieldOffset(0x0D0)] public UInt16 harvestValueLeft;
        [FieldOffset(0x0D2)] public UInt16 harvestValueTop;
        [FieldOffset(0x0D4)] public UInt16 harvestValueRight;
        [FieldOffset(0x0D6)] public UInt16 harvestValueBottom;

        // Building?_Powerup
        [FieldOffset(0x0D0)] public UInt16 originX;
        [FieldOffset(0x0D2)] public UInt16 originY;
        // End nested union

        // Worker
        [FieldOffset(0x0C0)] public /*(CUnit*)*/UInt32 pPowerup;
        [FieldOffset(0x0C4)] public UInt16 targetResourceX;
        [FieldOffset(0x0C6)] public UInt16 targetResourceY;
        [FieldOffset(0x0C8)] public /*(CUnit*)*/UInt32 targetResourceUnit;
        [FieldOffset(0x0CC)] public UInt16 repairResourceLossTimer;
        [FieldOffset(0x0CE)] public /*(bool)*/ byte isCarryingSomething;
        [FieldOffset(0x0CF)] public byte resourceCarryCount;
        [FieldOffset(0x0D0)] public /*(CUnit*)*/UInt32 harvestTarget;
        [FieldOffset(0x0D4)] public /*(CUnit*)*/UInt32 prevHarvestUnit;
        [FieldOffset(0x0D8)] public /*(CUnit*)*/UInt32 nextHarvestUnit;
        // End union

	    [FieldOffset(0x0DC)] public UInt32 statusFlags;
        [FieldOffset(0x0E0)] public byte resourceType; // Resource being held by worker: 1 = gas, 2 = ore
        [FieldOffset(0x0E1)] public byte wireframeRandomizer;
        [FieldOffset(0x0E2)] public byte secondaryOrderState;
        [FieldOffset(0x0E3)] public byte recentOrderTimer; // Counts down from 15 to 0 when most orders are given,
                         // or when the unit moves after reaching a patrol location
        [FieldOffset(0x0E4)] public Int32 visibilityStatus; // Flags specifying which players can detect this unit (cloaked/burrowed)
        [FieldOffset(0x0E8)] public UInt16 _unknown_0x0E8; // Secondary order related (x?)
        [FieldOffset(0x0EA)] public UInt16 _unknown_0x0EA; // Secondary order related (y?)
        [FieldOffset(0x0EC)] public /*(CUnit*)*/UInt32 currentBuildUnit;

        // CLink<CUnit> burrow_link;
        [FieldOffset(0x0F0)] public /*(CUnit*)*/UInt32 previousBurrowedUnit;
        [FieldOffset(0x0F4)] public /*(CUnit*)*/UInt32 nextBurrowedUnit;

        // Begin union
        // Rally (if the unit is rally type)
        [FieldOffset(0x0F8)] public UInt16 positionX;
        [FieldOffset(0x0FA)] public UInt16 positionY;
        [FieldOffset(0x0FC)] public /*(CUnit*)*/UInt32 unit;

        // Pylon
        [FieldOffset(0x0F8)] public /*(CUnit*)*/UInt32 prevPsiProvider;
        [FieldOffset(0x0FC)] public /*(CUnit*)*/UInt32 nextPsiProvider;
        // End union

        [FieldOffset(0x100)] public /*(UInt32*)*/UInt32 path;
        [FieldOffset(0x104)] public byte pathingCollisionInterval; // unknown
        [FieldOffset(0x105)] public byte pathingFlags; // 0x01 = uses pathing; 0x02 = ?; 0x04 = ?
        [FieldOffset(0x106)] public byte _unused_0x106;
        [FieldOffset(0x107)] public /*(bool)*/byte isBeingHealed; // 1 if a medic is currently healing this unit
        [FieldOffset(0x108)] public UInt16 contourBoundsLeft;
        [FieldOffset(0x10A)] public UInt16 contourBoundsTop;
        [FieldOffset(0x10C)] public UInt16 contourBoundsRight;
        [FieldOffset(0x10E)] public UInt16 contourBoundsBottom;

        // Status
        [FieldOffset(0x110)] public UInt16 removeTimer; // does not apply to scanner sweep
        [FieldOffset(0x112)] public UInt16 defenseMatrixDamage;
        [FieldOffset(0x114)] public byte defenseMatrixTimer;
        [FieldOffset(0x115)] public byte stimTimer;
        [FieldOffset(0x116)] public byte ensnareTimer;
        [FieldOffset(0x117)] public byte lockdownTimer;
        [FieldOffset(0x118)] public byte irradiateTimer;
        [FieldOffset(0x119)] public byte stasisTimer;
        [FieldOffset(0x11A)] public byte plagueTimer;
        [FieldOffset(0x11B)] public byte stormTimer;
        [FieldOffset(0x11C)] public /*(CUnit*)*/UInt32 irradiatedBy;
        [FieldOffset(0x120)] public byte irradiatePlayerID;
        [FieldOffset(0x121)] public byte parasiteFlags;
        [FieldOffset(0x122)] public byte cycleCounter; // counts/cycles up from 0 to 7 (inclusive). See also 0x85.
        [FieldOffset(0x123)] public /*(bool)*/byte isBlind;
        [FieldOffset(0x124)] public byte maelstromTimer;
        [FieldOffset(0x125)] public byte _unused_0x125; // ?? Might be afterburner timer or ultralisk roar timer
        [FieldOffset(0x126)] public byte acidSporeCount;
        [FieldOffset(0x127)] public fixed byte acidSporeTime[9];
	    [FieldOffset(0x130)] public UInt16 bulletBehaviour3by3AttackSequence; // Counts up for the number of bullets shot by a unit using
                                                      // this weapon behaviour and resets after it reaches 12

        [FieldOffset(0x132)] public UInt16 _padding_0x132; // 2-byte padding

        [FieldOffset(0x134)] public /*(void*)*/UInt32 pAI; // pointer to AI class, we're not using this though  // official name
        [FieldOffset(0x138)] public UInt16 airStrength;
        [FieldOffset(0x13A)] public UInt16 groundStrength;

        // Finder
        [FieldOffset(0x13C)] public UInt32 left;
        [FieldOffset(0x140)] public UInt32 right;
        [FieldOffset(0x144)] public UInt32 top;
        [FieldOffset(0x148)] public UInt32 bottom; // Ordering for unit boundries in unit finder for binary search

        [FieldOffset(0x14C)] public byte _repulseUnknown; // @todo Unknown
        [FieldOffset(0x14D)] public byte repulseAngle; // updated only when air unit is being pushed
        [FieldOffset(0x14E)] public byte driftPosX; //  (mapsizex/1.5 max)    // officially "bRepMtxX"   // repulse matrix X/Y
        [FieldOffset(0x14F)] public byte driftPosY; //  (mapsizex/1.5 max)    // "bRepMtxY"
    }
}
