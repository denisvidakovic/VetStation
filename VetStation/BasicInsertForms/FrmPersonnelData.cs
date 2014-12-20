using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Castle.ActiveRecord;
using Model;

namespace VetStation.BasicInsertForms
{
    public partial class FrmPersonnelData : Form
    {
        public FrmPersonnelData()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SessionScope sc = new SessionScope())
            {
                using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                {
                    Personnel p = new Personnel();
                    p.FirstName = txtFirstName.Text;
                    p.LastName = txtLastName.Text;
                    p.Title = txtTitle.Text;
                    p.Save();

                    ts.VoteCommit();

                    label1.Visible = true;
                }
            }
        }
    }
}
