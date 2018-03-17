using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessModder;
using Updating;

namespace UnitViewer
{
    public partial class UnitViewerGUI : Form, IUpdatable
    {
        private ProcessMod p = null;
        private Updater updater = null;
        private TreeNode treeAllUnits = null;
        private TreeNode[] treePlayers = null;
        private TreeNode treePlayer13to256 = null;
        private TreeNode[] treeSelPlayers = null;
        private TreeNode[] treeDeaths = null;
        private TreeNode[][] treePlayerDeaths = null;
        private SortedDictionary<ushort, UnitView> unitViews = null;
        private SortedDictionary<UInt32, UnitView> customViews = null;
        private List<ushort> usedIndices = null;
        private bool scFrozen = false;

        /// <summary>
        /// Default constructor for Forms
        /// </summary>
        public UnitViewerGUI()
        {
            InitializeComponent();
        }

        /// <summary>The load method called to initialize this GUI</summary>
        /// <param name="sender">unused</param>
        /// <param name="e">unused</param>
        private void UnitViewerGUI_Load(object sender, EventArgs e)
        {
            SetDoubleBuffered(treeViewUnits);
            SetDoubleBuffered(treeViewDeaths);
            treePlayers = new TreeNode[12];
            treeSelPlayers = new TreeNode[8];
            treeDeaths = new TreeNode[228];
            treePlayerDeaths = new TreeNode[228][];
            treeAllUnits = treeViewUnits.Nodes.Add("AllUnits", "All Units");
            TreeNode treeByPlayers = treeViewUnits.Nodes.Add("TreeByPlayers", "Players' Units");
            for (uint i = 0; i < 12; i++)
            {
                string playerKey = string.Format("Player{0}", i + 1);
                string playerText = string.Format("Player {0}", i + 1);
                treePlayers[i] = treeByPlayers.Nodes.Add(playerKey, playerText);
            }
            treePlayer13to256 = treeByPlayers.Nodes.Add("Player13-256", "Player 13-256");
            TreeNode treeBySelections = treeViewUnits.Nodes.Add("TreeByPlayerSel", "Selections");
            for (uint i = 0; i < 8; i++)
            {
                string playerKey = string.Format("selPlayer{0}", i + 1);
                string playerText = string.Format("Player {0}", i + 1);
                treeSelPlayers[i] = treeBySelections.Nodes.Add(playerKey, playerText);
            }
            String[] unitNames = UnitNames.get();
            for (uint unitId = 0; unitId < 228; unitId++)
            {
                string unitKey = string.Format("unit{0}", unitId);
                treeDeaths[unitId] = treeViewDeaths.Nodes.Add(unitKey, string.Format("[{0}] {1}", unitId.ToString("000"), unitNames[unitId]));
                treePlayerDeaths[unitId] = new TreeNode[12];
                for (uint playerId = 0; playerId < 12; playerId++)
                {
                    string playerDeathsKey = string.Format("player{0}", playerId + 1);
                    string playerDeathsText = string.Format("Player {0}:     {1}", (playerId + 1).ToString("00"), 0.ToString());
                    treePlayerDeaths[unitId][playerId] = treeDeaths[unitId].Nodes.Add(playerDeathsKey, playerDeathsText);
                }
            }

            p = new ProcessMod();
            updater = new Updater(this);
            updater.StartTimedUpdates(1000);
            unitViews = new SortedDictionary<ushort, UnitView>();
            customViews = new SortedDictionary<UInt32, UnitView>();
            usedIndices = new List<ushort>();
            RefreshWindow();
        }

        private unsafe ushort unitPtrToIndex(UInt32 unitPtr)
        {
            uint addr = unitPtr;
            if (addr < 0x59CCA8)
                return ushort.MaxValue;
            if (addr >= 0x59CCA8 && addr <= 0x59CDF7)
                return 0;
            else if (addr >= 0x59CDF8 && addr <= 0x6283E7)
                return (ushort)((0x6283E8 - addr) / 336);
            else // if (addr >= 0x6283E8)
                return ushort.MaxValue;
        }

        private unsafe UInt32 unitIndexToPtr(ushort unitIndex)
        {
            if (unitIndex == 0)
                return 5885096;
            else
                return 6456296 - 336 * ((UInt32)unitIndex);
        }

        private unsafe UInt16 unitId(CUnit* unit)
        {
            return p.val<UInt16>((uint)&unit->unitType);
        }

        private unsafe byte unitPlayer(CUnit* unit)
        {
            return p.val<byte>((uint)&unit->playerID);
        }

        private void unitRemoved(ushort index)
        {
            UnitView toClose;
            if (unitViews.TryGetValue(index, out toClose))
            {
                toClose.Close();
                unitViews.Remove(index);
            }
        }

        private unsafe void PopulateUnitList()
        {
            List<ushort> currentlyUsedIndices = new List<ushort>();
            UnitView unitView;

            CUnit unit = new CUnit();
            UInt32 unitPtr = p.val<uint>(0x00628430);
            while (unitPtr != 0)
            {
                unit = p.val<CUnit>(unitPtr);
                ushort unitIndex = unitPtrToIndex(unitPtr);
                currentlyUsedIndices.Add(unitIndex);

                string unitString = string.Format("[{0}] (p{1}) {2} {{{3}}}", unitIndex.ToString("0000"),
                    unit.playerID + 1, UnitNames.get(unit.unitType), unit.unitType);

                treeAllUnits.Nodes.Add(unitIndex.ToString(), unitString);

                if (unit.playerID > 11) // Player 13-256
                    treePlayer13to256.Nodes.Add("ext" + unitIndex.ToString(), unitString);
                else // Player 1-12
                    treePlayers[unit.playerID].Nodes.Add("p" + unitIndex.ToString(), unitString);

                if (unitViews.TryGetValue(unitIndex, out unitView))
                {
                    if (unitView.IsDisposed)
                        unitViews.Remove(unitIndex);
                    else
                        unitView.Update(ref unit);
                }

                unitPtr = unit.next;
            }

            for (uint player = 0; player < 8; player++)
            {
                treeSelPlayers[player].Nodes.Clear();
                for (uint sel = 0; sel < 12; sel++)
                {
                    unitPtr = p.val<UInt32>(0x006284E8 + player * 48 + sel * 4);
                    ushort unitIndex = unitPtrToIndex(unitPtr);
                    if (unitIndex != ushort.MaxValue)
                    {
                        unit = p.val<CUnit>(unitPtr);

                        string unitString = string.Format("[{0}] (p{1}) {2} {{{3}}}", unitIndex.ToString("0000"),
                            unit.playerID + 1, UnitNames.get(unit.unitType), unit.unitType);

                        treeSelPlayers[player].Nodes.Add("s" + unitIndex.ToString(), unitString);
                    }
                }
            }

            List<uint> toRemove = null;
            foreach (var item in customViews)
            {
                unit = p.val<CUnit>(item.Key);
                if (item.Value.IsDisposed)
                {
                    if (toRemove == null)
                        toRemove = new List<uint>();

                    toRemove.Add(item.Key);
                }
                else
                    item.Value.Update(ref unit);
            }
            if (toRemove != null)
            {
                foreach (uint key in toRemove)
                    customViews.Remove(key);
            }

            foreach (ushort unitIndex in usedIndices)
            {
                if (!currentlyUsedIndices.Contains(unitIndex))
                    unitRemoved(unitIndex);
            }

            usedIndices = currentlyUsedIndices;
        }

        private void RefreshUnitList()
        {
            /*  Windows Forms Bug: cannot set TreeView::TopNode prior to calling TreeView::EndUpdate
                Problem: Setting it after causes flicker
                Solution: Embed TreeView in a panel, prevent panel from redrawing, do first round of
                updates, set top index, and within a second round of updates, let panel be redrawn */

            SetRedraw(unitTreeFixPanel, false);
            treeViewUnits.BeginUpdate();
            String topKey = treeViewUnits.TopNode.Name;
            String selectedKey = "";
            if (treeViewUnits.SelectedNode != null)
                selectedKey = treeViewUnits.SelectedNode.Name;

            treeAllUnits.Nodes.Clear();
            foreach (TreeNode tree in treePlayers)
                tree.Nodes.Clear();
            treePlayer13to256.Nodes.Clear();

            PopulateUnitList();

            TreeNode newTop = null, newSelect = null;
            TreeNode[] foundNodes = treeViewUnits.Nodes.Find(topKey, true);
            if (foundNodes.Length > 0)
                newTop = foundNodes[0];
            foundNodes = treeViewUnits.Nodes.Find(selectedKey, true);
            if (foundNodes.Length > 0)
                newSelect = foundNodes[0];

            treeViewUnits.SelectedNode = newSelect;
            treeViewUnits.EndUpdate(); // If the TopNode is set prior to this call, it will not work
            treeViewUnits.TopNode = newTop;
            treeViewUnits.BeginUpdate();
            SetRedraw(unitTreeFixPanel, true);
            treeViewUnits.EndUpdate();
        }

        private void RefreshDeathsList()
        {
            /*  Windows Forms Bug: cannot set TreeView::TopNode prior to calling TreeView::EndUpdate
    Problem: Setting it after causes flicker
    Solution: Embed TreeView in a panel, prevent panel from redrawing, do first round of
    updates, set top index, and within a second round of updates, let panel be redrawn */

            SetRedraw(deathsTreeFixPanel, false);
            treeViewDeaths.BeginUpdate();

            for (uint unitId = 0; unitId < 228; unitId++)
            {
                for (uint playerId = 0; playerId < 12; playerId++)
                {
                    uint address = 0x0058A364 + 48 * unitId + 4 * playerId;
                    uint currNumDeaths = p.val<uint>(address);
                    treePlayerDeaths[unitId][playerId].Text = string.Format("Player {0}:     {1}", (playerId + 1).ToString("00"), currNumDeaths.ToString());
                }
            }

            SetRedraw(deathsTreeFixPanel, true);
            treeViewDeaths.EndUpdate();
        }

        private void RefreshWindow()
        {
            if ( !p.isOpen() )
            {
                this.Text = "Unit Viewer - Waiting for StarCraft";
                if ( p.openWithProcessName("StarCraft.exe") )
                    this.Text = "Unit Viewer - Active";
            }

            if ( p.isOpen() )
            {
                RefreshUnitList();
                RefreshDeathsList();
            }
        }

        /// <summary>
        /// Called by the updater in the assigned intervals
        /// </summary>
        public void TimedUpdate()
        {
            if ( !this.IsDisposed )
            {
                this.Invoke((MethodInvoker)delegate
                {
                    RefreshWindow();
                });
            }
        }

        void treeViewUnits_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            UInt16 unitIndex = UInt16.MaxValue;
            try
            {
                if ( e.Node.Name.Length > 0 && e.Node.Name[0] == 'p' )
                    unitIndex = Convert.ToUInt16(e.Node.Name.Substring(1));
                else if ( e.Node.Name.Length > 0 && e.Node.Name[0] == 's' )
                    unitIndex = Convert.ToUInt16(e.Node.Name.Substring(1));
                else
                    unitIndex = Convert.ToUInt16(e.Node.Name.Substring(0));
            }
            catch { unitIndex = UInt16.MaxValue; }

            if ( unitIndex != UInt16.MaxValue && !unitViews.ContainsKey(unitIndex) )
            {
                UnitView unitView = new UnitView(unitIndex, unitIndexToPtr(unitIndex));
                unitViews.Add(unitIndex, unitView);
                unitView.Show();
            }
        }

        /// <summary>
        /// Attempts to change the specified control to double buffered
        /// (reduces flicker) this change will not occur if in a terminal
        /// server session
        /// </summary>
        /// <param name="control">The control to be set to double buffered</param>
        public static void SetDoubleBuffered(Control control)
        {
            if ( SystemInformation.TerminalServerSession )
                return;

            System.Reflection.BindingFlags flags =
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance;

            try
            {
                System.Reflection.PropertyInfo prop =
                    typeof(Control).GetProperty("DoubleBuffered", flags);

                if ( prop != null )
                    prop.SetValue(control, true, null);
            }
            catch
            {
                /*  - Documented: AmbiguousMatchException, ArgumentNullException,
                                  ArgumentException, TargetException,
                                  TargetParameterCountException, MethodAccessException,
                                  TargetInvocationException
                    - Notes: For some applications, TargetException requires a general
                             catch, keep general to prevent unnecessary crashes
                    - No critical exceptions documented. */
            }
        }

        public static void SetRedraw(Control control, bool redraw)
        {
            if ( redraw )
                SendMessage(control.Handle, WM_SETREDRAW, true, 0);
            else
                SendMessage(control.Handle, WM_SETREDRAW, false, 0);
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 msg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        private void buttonFreeze_Click(object sender, EventArgs e)
        {
            if ( scFrozen )
                scFrozen = !p.unfreezeProcess();
            else
                scFrozen = p.freezeProcess();

            if ( scFrozen )
                buttonFreeze.Text = "Unfreeze SC";
            else
                buttonFreeze.Text = "Freeze SC";
        }

        private void viewByAddress_Click(object sender, EventArgs e)
        {
            uint address = 0;
            string addressText = addressInput.Text;
            try
            {
                if ( addressText.Length > 2 && addressText.Substring(0, 2) == "0x" )
                    address = Convert.ToUInt32(addressText, 16);
                else
                    address = Convert.ToUInt32(addressText);
            }
            catch
            {
                address = 0;
            }

            if ( address > 0 )
            {
                UnitView unitView = new UnitView(ushort.MaxValue, address);
                customViews.Add(address, unitView);
                unitView.Show();
            }
            else
                MessageBox.Show("Invalid Address.");
        }
    }
}
