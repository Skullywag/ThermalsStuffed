using System;
using Verse;
using RimWorld;

namespace ThermalsStuffed
{
    public class CompPowerPlantSteam : CompPowerPlant
    {
        private IntermittentSteamSprayer steamSprayer;

        private Building_SteamGeyser geyser;

        private float steamPower;

        public override void PostSpawnSetup()
        {
            base.PostSpawnSetup();
            this.steamSprayer = new IntermittentSteamSprayer(this.parent);
            if (this.parent.def.MadeFromStuff)
            {
                switch (this.parent.Stuff.defName)
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

        public override void CompTick()
        {
            base.CompTick();
            if (this.geyser == null)
            {
                this.geyser = (Building_SteamGeyser)Find.ThingGrid.ThingAt(this.parent.Position, ThingDefOf.SteamGeyser);
            }
            if (this.geyser != null)
            {
                this.geyser.harvester = (Building)this.parent;
                this.steamSprayer.SteamSprayerTick();
            }
            base.PowerOutput = steamPower;
        }

        public override void PostDeSpawn()
        {
            base.PostDeSpawn();
            if (this.geyser != null)
            {
                this.geyser.harvester = null;
            }
        }
    }
}
