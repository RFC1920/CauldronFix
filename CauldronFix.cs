#region License (GPL v3)
/*
    DESCRIPTION
    Copyright (c) 2021 RFC1920 <desolationoutpostpve@gmail.com>

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/
#endregion License Information (GPL v3)

namespace Oxide.Plugins
{
    [Info("CauldronFix", "RFC1920", "1.0.1")]
    [Description("Fix CursedCauldron output slots")]
    internal class CauldronFix : RustPlugin
    {
        private const string cauldron = "cursedcauldron.deployed";

        private void OnEntitySpawned(BaseOven oven)
        {
            if (oven.ShortPrefabName.Equals(cauldron))
            {
                oven.outputSlots = 2;
                oven.inventorySlots = oven.fuelSlots + oven.inputSlots + oven.outputSlots;
                oven.CreateInventory(false);

                ItemContainer container1 = oven.inventory;
                Item addfuel = ItemManager.CreateByName("wood", 50);
                container1.itemList.Add(addfuel);
                addfuel.parent = container1;
                addfuel.MarkDirty();
            }
        }
    }
}
