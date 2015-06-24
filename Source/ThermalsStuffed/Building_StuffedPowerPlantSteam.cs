using System;
using Verse;
using RimWorld;
namespace ThermalsStuffed
{
    internal class Building_StuffedPowerPlantSteam : Building_PowerPlantSteam
    {
        private float steamPower;
        public override void SpawnSetup()
        {
            base.SpawnSetup();
            if (this.def.MadeFromStuff)
            {
                switch (this.Stuff.defName)
                {
                    case "Silver":
                        steamPower = 4200f;
                        break;
                    case "Gold":
                        steamPower = 5000f;
                        break;
                    case "Steel":
                        steamPower = 3600f;
                        break;
                    case "Plasteel":
                        steamPower = 5200f;
                        break;
                    case "Uranium":
                        steamPower = 6000f;
                        break;
                    default:
                        steamPower = 3600f;
                        break;
                }
            }
        }
        public override void Tick()
        {
            base.Tick();
            this.powerComp.PowerOutput = steamPower;
        }
    }
}
