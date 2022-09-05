using AmadeoApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmadeoAPP__Gui_Desktop
{
    public partial class Form1 : Form
    {
        DatabaseManager dbManager = new DatabaseManager();
        public Form1()
        {
            InitializeComponent();
            InitIds();
            InitDatabases();

        }
        private void InitIds()
        {
            string[] listId = QueryBuilder.GetIds(@"C:\amadeo_helpdesk\AmadeoHelper\AmadeoApp\IdFiles\IdMerchandise.txt");
            this.listBox1.DataSource = listId;
        }

        private void InitDatabases()
        {
            var databases = dbManager.Databases;
            var keys = databases.Keys.Select(x => x.ToString()).ToList();
            this.comboBox1.DataSource = keys;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = QueryBuilder.UnlockSpecialPrice();
            string result = dbManager.UpdateForOneDatabase(query, "MP_CENTRALA");
            MessageBox.Show(result);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = QueryBuilder.ResetLock();
            var directDb = this.comboBox1.SelectedItem.ToString();
            var result = dbManager.UpdateForOneDatabase(query, directDb);
            MessageBox.Show(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var query = QueryBuilder.UncheckBuffor();
            var result = dbManager.ExecuteForLocalMPShop(query);
            this.listBox2.DataSource = result;
        }

    }
}
