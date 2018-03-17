using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitViewer
{
    public partial class UnitView : Form
    {
        private bool addedRows;
        private ushort unitIndex = ushort.MaxValue;
        private UInt32 unitAddress = 0;

        public UnitView(ushort unitIndex, UInt32 unitAddress)
        {
            addedRows = false;
            InitializeComponent();
            this.unitIndex = unitIndex;
            this.unitAddress = unitAddress;
        }

        public void AddRows()
        {
            for ( int i=0; i<201; i++ )
                unitPropSheet.Rows.Add("", "", "");

            addedRows = true;
        }

        public string addr(uint offset)
        {
            return string.Format("0x{0}",(offset + unitAddress).ToString("X8"));
        }

        public void setRow<T>(ref int index, string title, T prop, uint offset)
        {
            unitPropSheet.Rows[index].SetValues(addr(offset), title, prop);
            index++;
        }

        public unsafe void SetValues(ref CUnit unit)
        {
            int i = 0;
            setRow(ref i, "prev", unit.prev, 0x000);
            setRow(ref i, "next", unit.next, 0x004);
            setRow(ref i, "hitPoints", unit.hitPoints, 0x008);
            setRow(ref i, "sprite", unit.sprite, 0x00C);
            setRow(ref i, "moveTargetA", unit.moveTargetA, 0x010);
            setRow(ref i, "moveTargetB", unit.moveTargetB, 0x014);
            setRow(ref i, "nextMovementWaypoint", unit.nextMovementWaypoint, 0x018);
            setRow(ref i, "nextTargetWaypoint", unit.nextTargetWaypoint, 0x01C);
            setRow(ref i, "movementFlags", unit.movementFlags, 0x020);
            setRow(ref i, "currentDirection1", unit.currentDirection1, 0x021);
            setRow(ref i, "flingyTurnRadius", unit.flingyTurnRadius, 0x022);
            setRow(ref i, "velocityDirection1", unit.velocityDirection1, 0x023);
            setRow(ref i, "flingyID", unit.flingyID, 0x024);
            setRow(ref i, "_unknown_0x026", unit._unknown_0x026, 0x026);
            setRow(ref i, "flingyMovementType", unit.flingyMovementType, 0x027);
            setRow(ref i, "position", unit.position, 0x028);
            setRow(ref i, "haltX", unit.haltX, 0x02C);
            setRow(ref i, "haltY", unit.haltY, 0x030);
            setRow(ref i, "flingyTopSpeed", unit.flingyTopSpeed, 0x034);
            setRow(ref i, "current_speed1", unit.current_speed1, 0x038);
            setRow(ref i, "current_speed2", unit.current_speed2, 0x03C);
            setRow(ref i, "current_speedX", unit.current_speedX, 0x040);
            setRow(ref i, "current_speedY", unit.current_speedY, 0x044);
            setRow(ref i, "flingyAcceleration", unit.flingyAcceleration, 0x048);
            setRow(ref i, "currentDirection2", unit.currentDirection2, 0x04A);
            setRow(ref i, "veclocityDirection2", unit.velocityDirection, 0x04B);
            setRow(ref i, "playerID", unit.playerID, 0x04C);
            setRow(ref i, "orderID", unit.orderID, 0x04D);
            setRow(ref i, "orderState", unit.orderState, 0x04E);
            setRow(ref i, "orderSignal", unit.orderSignal, 0x04F);
            setRow(ref i, "orderUnitType", unit.orderUnitType, 0x050);
            setRow(ref i, "__0x52", unit.__0x52, 0x052);
            setRow(ref i, "mainOrderTimer", unit.mainOrderTimer, 0x054);
            setRow(ref i, "groundWeaponCooldown", unit.groundWeaponCooldown, 0x055);
            setRow(ref i, "airWeaponCooldown", unit.airWeaponCooldown, 0x056);
            setRow(ref i, "spellCooldown", unit.spellCooldown, 0x057);
            setRow(ref i, "orderTargetX", unit.orderTargetX, 0x058);
            setRow(ref i, "orderTargetY", unit.orderTargetY, 0x05C);
            setRow(ref i, "shieldPoints", unit.shieldPoints, 0x060);
            setRow(ref i, "unitType", unit.unitType, 0x064);
            setRow(ref i, "__0x66", unit.__0x66, 0x066);
            setRow(ref i, "previousPlayerUnit", unit.previousPlayerUnit, 0x068);
            setRow(ref i, "nextPlayerUnit", unit.nextPlayerUnit, 0x06C);
            setRow(ref i, "subUnit", unit.subUnit, 0x070);
            setRow(ref i, "orderQueueHead", unit.orderQueueHead, 0x074);
            setRow(ref i, "orderQueueTail", unit.orderQueueTail, 0x078);
            setRow(ref i, "autoTargetUnit", unit.autoTargetUnit, 0x07C);
            setRow(ref i, "connectedUnit", unit.connectedUnit, 0x080);
            setRow(ref i, "orderQueueTail", unit.orderQueueTail, 0x084);
            setRow(ref i, "orderQueueTimer", unit.orderQueueTimer, 0x085);
            setRow(ref i, "_unknown_0x086", unit._unknown_0x086, 0x086);
            setRow(ref i, "attackNotifyTimer", unit.attackNotifyTimer, 0x087);
            setRow(ref i, "displayedUnitID", unit.displayedUnitID, 0x088);
            setRow(ref i, "lastEventtimer", unit.lastEventTimer, 0x08A);
            setRow(ref i, "lastEventColor", unit.lastEventColor, 0x08B);
            setRow(ref i, "_unused_0x08C", unit._unused_0x08C, 0x08C);
            setRow(ref i, "rankIncrease", unit.rankIncrease, 0x08E);
            setRow(ref i, "killCount", unit.killCount, 0x08F);
            setRow(ref i, "lastAttackingPlayer", unit.lastAttackingPlayer, 0x090);
            setRow(ref i, "secondaryOrderTimer", unit.secondaryOrderTimer, 0x091);
            setRow(ref i, "AIActionFlag", unit.AIActionFlag, 0x092);
            setRow(ref i, "userActionFlags", unit.userActionFlags, 0x093);
            setRow(ref i, "currentButtonSet", unit.currentButtonSet, 0x094);
            setRow(ref i, "isCloaked", unit.isCloaked, 0x096);
            setRow(ref i, "movementState", unit.movementState, 0x097);
            fixed ( CUnit* u = &unit ) { setRow(ref i, "buildQueue[0]", u->buildQueue[0], 0x098); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "buildQueue[1]", u->buildQueue[1], 0x09A); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "buildQueue[2]", u->buildQueue[2], 0x09C); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "buildQueue[3]", u->buildQueue[3], 0x09E); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "buildQueue[4]", u->buildQueue[4], 0x0A0); }
            setRow(ref i, "energy", unit.energy, 0x0A2);
            setRow(ref i, "buildQueueSlot", unit.buildQueueSlot, 0x0A4);
            setRow(ref i, "targetOrderSpecial", unit.targetOrderSpecial, 0x0A5);
            setRow(ref i, "secondaryOrderID", unit.secondaryOrderID, 0x0A6);
            setRow(ref i, "buildingOverlayState", unit.buildingOverlayState, 0x0A7);
            setRow(ref i, "hpGainduringRepair", unit.hpGainDuringRepair, 0x0A8);
            setRow(ref i, "_unknown_0x0AA", unit._unknown_0x0AA, 0x0AA);
            setRow(ref i, "remainingBuildTime", unit.remainingBuildTime, 0x0AC);
            setRow(ref i, "previousHP", unit.previousHP, 0x0AE);
            fixed ( CUnit* u = &unit ) { setRow(ref i, "loadedUnitIndex[0]", u->loadedUnitIndex[0], 0x0B0); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "loadedUnitIndex[1]", u->loadedUnitIndex[1], 0x0B2); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "loadedUnitIndex[2]", u->loadedUnitIndex[2], 0x0B4); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "loadedUnitIndex[3]", u->loadedUnitIndex[3], 0x0B6); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "loadedUnitIndex[4]", u->loadedUnitIndex[4], 0x0B8); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "loadedUnitIndex[5]", u->loadedUnitIndex[5], 0x0BA); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "loadedUnitIndex[6]", u->loadedUnitIndex[6], 0x0BC); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "loadedUnitIndex[7]", u->loadedUnitIndex[7], 0x0BE); }
            setRow(ref i, "VULTURE:spiderMineCount", unit.spiderMineCount, 0x0C0);
            setRow(ref i, "CARRIER:pInHanger", unit.pInHanger, 0x0C0);
            setRow(ref i, "CARRIER:pOutHanger", unit.pOutHanger, 0x0C4);
            setRow(ref i, "CARRIER:inHangerCount", unit.inHangerCount, 0x0C8);
            setRow(ref i, "CARRIER:outHangerCount", unit.outHangerCount, 0x0C9);
            setRow(ref i, "FIGHTER:parent", unit.parent, 0x0C0);
            setRow(ref i, "FIGHTER:fighterPrev", unit.fighterPrev, 0x0C4);
            setRow(ref i, "FIGHTER:fighterNext", unit.fighterNext, 0x0C8);
            setRow(ref i, "FIGHTER:inHanger", unit.inHanger, 0x0CC);
            setRow(ref i, "BEACON:_unknown_00", unit._unknown_00, 0x0C0);
            setRow(ref i, "BEACON:_unknown_04", unit._unknown_04, 0x0C4);
            setRow(ref i, "BEACON:flagSpawnFrame", unit.flagSpawnFrame, 0x0C8);
            setRow(ref i, "BUILDING:addon", unit.addon, 0x0C0);
            setRow(ref i, "BUILDING:addonBuildType", unit.addonBuildType, 0x0C4);
            setRow(ref i, "BUILDING:upgradeResearchTime", unit.upgradeResearchTime, 0x0C6);
            setRow(ref i, "BUILDING:techType", unit.techType, 0x0C8);
            setRow(ref i, "BUILDING:upgradeType", unit.upgradeType, 0x0C9);
            setRow(ref i, "BUILDING:larvaTimer", unit.larvaTimer, 0x0CA);
            setRow(ref i, "BUILDING:landingTimer", unit.landingTimer, 0x0CB);
            setRow(ref i, "BUILDING:creepTimer", unit.creepTimer, 0x0CC);
            setRow(ref i, "BUILDING:upgradeLevel", unit.upgradeLevel, 0x0CD);
            setRow(ref i, "BUILDING:__E", unit.__E, 0x0CE);
            setRow(ref i, "BUILDING:RESOURCE:resourceCount", unit.resourceCount, 0x0D0);
            setRow(ref i, "BUILDING:RESOURCE:resourceIScript", unit.resourceIScript, 0x0D2);
            setRow(ref i, "BUILDING:RESOURCE:gatherQueueCount", unit.gatherQueueCount, 0x0D3);
            setRow(ref i, "BUILDING:RESOURCE:nextGatherer", unit.nextGatherer, 0x0D4);
            setRow(ref i, "BUILDING:RESOURCE:resourceGroup", unit.resourceGroup, 0x0D8);
            setRow(ref i, "BUILDING:RESOURCE:resourceBelongsToAI", unit.resourceBelongsToAI, 0x0D9);
            setRow(ref i, "BUILDING:NYDUS:nydus", unit.nydus, 0x0D0);
            setRow(ref i, "BUILDING:GHOST:nukeDot", unit.nukeDot, 0x0D0);
            setRow(ref i, "BUILDING:PYLON:pylonAura", unit.pylonAura, 0x0D0);
            setRow(ref i, "BUILDING:SILO:pNuke", unit.pNuke, 0x0D0);
            setRow(ref i, "BUILDING:SILO:bReady", unit.bReady, 0x0D4);
            setRow(ref i, "BUILDING:HATCHERY:harvestValueLeft", unit.harvestValueLeft, 0x0D0);
            setRow(ref i, "BUILDING:HATCHERY:harvestValueTop", unit.harvestValueTop, 0x0D2);
            setRow(ref i, "BUILDING:HATCHERY:harvestValueRight", unit.harvestValueRight, 0x0D4);
            setRow(ref i, "BUILDING:HATCHERY:harvestValueBottom", unit.harvestValueBottom, 0x0D6);
            setRow(ref i, "BUILDING:POWERUP:originX", unit.originX, 0x0D0);
            setRow(ref i, "BUILDING:POWERUP:originY", unit.originY, 0x0D2);
            setRow(ref i, "WORKER:pPowerup", unit.pPowerup, 0x0C0);
            setRow(ref i, "WORKER:targetResourceX", unit.targetResourceX, 0x0C4);
            setRow(ref i, "WORKER:targetResourceY", unit.targetResourceY, 0x0C6);
            setRow(ref i, "WORKER:targetResourceUnit", unit.targetResourceUnit, 0x0C8);
            setRow(ref i, "WORKER:repairResourceLossTimer", unit.repairResourceLossTimer, 0x0CC);
            setRow(ref i, "WORKER:isCarryingSomething", unit.isCarryingSomething, 0x0CE);
            setRow(ref i, "WORKER:resourceCarryCount", unit.resourceCarryCount, 0x0CF);
            setRow(ref i, "WORKER:harvestTarget", unit.harvestTarget, 0x0D0);
            setRow(ref i, "WORKER:prevHarvestUnit", unit.prevHarvestUnit, 0x0D4);
            setRow(ref i, "WORKER:nextHarvestUnit", unit.nextHarvestUnit, 0x0D8);
            setRow(ref i, "statusFlags", unit.statusFlags, 0x0DC);
            setRow(ref i, "resourceType", unit.resourceType, 0x0E0);
            setRow(ref i, "wireframeRandomizer", unit.wireframeRandomizer, 0x0E1);
            setRow(ref i, "secondaryOrderState", unit.secondaryOrderState, 0x0E2);
            setRow(ref i, "recentOrderTimer", unit.recentOrderTimer, 0x0E3);
            setRow(ref i, "visibilityStatus", unit.visibilityStatus, 0x0E4);
            setRow(ref i, "_unknown_0x0E8", unit._unknown_0x0E8, 0x0E8);
            setRow(ref i, "_unknown_0x0EA", unit._unknown_0x0EA, 0x0EA);
            setRow(ref i, "currentBuildUnit", unit.currentBuildUnit, 0x0C);
            setRow(ref i, "previousBurrowedUnit", unit.previousBurrowedUnit, 0x0F0);
            setRow(ref i, "nextBurrowedUnit", unit.nextBurrowedUnit, 0x0F4);
            setRow(ref i, "RALLY:positionX", unit.positionX, 0x0F8);
            setRow(ref i, "RALLY:positionY", unit.positionY, 0x0FA);
            setRow(ref i, "RALLY:unit", unit.unit, 0x0FC);
            setRow(ref i, "PYLON:prevPsiProvider", unit.prevPsiProvider, 0x0F8);
            setRow(ref i, "PYLON:nextPsiProvider", unit.nextPsiProvider, 0x0FC);
            setRow(ref i, "path", unit.path, 0x100);
            setRow(ref i, "pathCollisionInterval", unit.pathingCollisionInterval, 0x104);
            setRow(ref i, "pathingFlags", unit.pathingFlags, 0x105);
            setRow(ref i, "_unused_0x106", unit._unused_0x106, 0x106);
            setRow(ref i, "isBeingHealed", unit.isBeingHealed, 0x107);
            setRow(ref i, "contourBoundsLeft", unit.contourBoundsLeft, 0x108);
            setRow(ref i, "contourBoundsTop", unit.contourBoundsTop, 0x10A);
            setRow(ref i, "contourBoundsRight", unit.contourBoundsRight, 0x10C);
            setRow(ref i, "contourBoundsBottom", unit.contourBoundsBottom, 0x10E);
            setRow(ref i, "STATUS:removeTimer", unit.removeTimer, 0x110);
            setRow(ref i, "STATUS:defenseMatrixDamage", unit.defenseMatrixDamage, 0x112);
            setRow(ref i, "STATUS:defenseMatrixTimer", unit.defenseMatrixTimer, 0x114);
            setRow(ref i, "STATUS:stimTimer", unit.stimTimer, 0x115);
            setRow(ref i, "STATUS:ensnareTimer", unit.ensnareTimer, 0x116);
            setRow(ref i, "STATUS:lockdownTimer", unit.lockdownTimer, 0x117);
            setRow(ref i, "STATUS:irradiateTimer", unit.irradiateTimer, 0x118);
            setRow(ref i, "STATUS:stasisTimer", unit.stasisTimer, 0x119);
            setRow(ref i, "STATUS:plagueTimer", unit.plagueTimer, 0x11A);
            setRow(ref i, "STATUS:stormTimer", unit.stormTimer, 0x11B);
            setRow(ref i, "STATUS:irradiatedBy", unit.irradiatedBy, 0x11C);
            setRow(ref i, "STATUS:irradiatePlayerID", unit.irradiatePlayerID, 0x120);
            setRow(ref i, "STATUS:parasiteFlags", unit.parasiteFlags, 0x121);
            setRow(ref i, "STATUS:cycleCounter", unit.cycleCounter, 0x122);
            setRow(ref i, "STATUS:isBlind", unit.isBlind, 0x123);
            setRow(ref i, "STATUS:maelstromTimer", unit.maelstromTimer, 0x124);
            setRow(ref i, "STATUS:_unused_0x125", unit._unused_0x125, 0x125);
            setRow(ref i, "STATUS:acidSporeCount", unit.acidSporeCount, 0x126);
            fixed ( CUnit* u = &unit ) { setRow(ref i, "STATUS:acidSporeTime[0]", u->acidSporeTime[0], 0x127); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "STATUS:acidSporeTime[1]", u->acidSporeTime[1], 0x128); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "STATUS:acidSporeTime[2]", u->acidSporeTime[2], 0x129); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "STATUS:acidSporeTime[3]", u->acidSporeTime[3], 0x12A); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "STATUS:acidSporeTime[4]", u->acidSporeTime[4], 0x12B); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "STATUS:acidSporeTime[5]", u->acidSporeTime[5], 0x12C); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "STATUS:acidSporeTime[6]", u->acidSporeTime[6], 0x12D); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "STATUS:acidSporeTime[7]", u->acidSporeTime[7], 0x12E); }
            fixed ( CUnit* u = &unit ) { setRow(ref i, "STATUS:acidSporeTime[8]", u->acidSporeTime[8], 0x12F); }
            setRow(ref i, "STATUS:bulletBehaviour3by3AttackSequence", unit.bulletBehaviour3by3AttackSequence, 0x130);
            setRow(ref i, "_padding_0x132", unit._padding_0x132, 0x132);
            setRow(ref i, "pAI", unit.pAI, 0x134);
            setRow(ref i, "airStrength", unit.airStrength, 0x138);
            setRow(ref i, "groundStrength", unit.groundStrength, 0x13A);
            setRow(ref i, "FINDER:left", unit.left, 0x13C);
            setRow(ref i, "FINDER:right", unit.right, 0x140);
            setRow(ref i, "FINDER:top", unit.top, 0x144);
            setRow(ref i, "FINDER:bottom", unit.bottom, 0x148);
            setRow(ref i, "_repulseUnknown", unit._repulseUnknown, 0x14C);
            setRow(ref i, "repulseAngle", unit.repulseAngle, 0x14D);
            setRow(ref i, "driftPosX", unit.driftPosX, 0x14E);
            setRow(ref i, "driftPosY", unit.driftPosY, 0x14F);
        }

        public void Update(ref CUnit unit)
        {
            if ( !addedRows )
                AddRows();

            if ( unitPropSheet.RowCount >= 50 )
                SetValues(ref unit);
            
            this.Text = string.Format("[{0}] (p{1}) {2} {{{3}}}", unitIndex.ToString("0000"),
                    unit.playerID + 1, UnitNames.get(unit.unitType), unit.unitType);
        }

        private void UnitView_Load(object sender, EventArgs e)
        {

        }
    }
}
