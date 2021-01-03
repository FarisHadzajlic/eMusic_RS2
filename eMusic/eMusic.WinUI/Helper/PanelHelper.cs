using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMusic.WinUI.Helper
{
    public class PanelHelper
    {
        public static void AddPanel(Control panelContainer, UserControl userControl)
        {
            if (!panelContainer.Controls.Contains(userControl))
            {
                panelContainer.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
            }

            userControl.BringToFront();
        }

        public static void RemovePanel(Control panelContainer, UserControl userControl)
        {
            panelContainer.Controls.Remove(userControl);
        }

        public static void RemovePanels(Control panelContainer)
        {
            panelContainer.Controls.Clear();
        }

        public static void SwapPanels(Control panelContainer, UserControl oldUserControl, UserControl newUserControl)
        {
            AddPanel(panelContainer, newUserControl);
            RemovePanel(panelContainer, oldUserControl);
        }
    }
}
