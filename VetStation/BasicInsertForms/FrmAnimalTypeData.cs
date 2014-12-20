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
    public partial class FrmAnimalTypeData : Form
    {
        public FrmAnimalTypeData()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            using (SessionScope sc = new SessionScope())
            {
                using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                {
                    try
                    {
                        AnimalType animalType = new AnimalType();
                        animalType.Name = txtName.Text;

                        animalType.Save();

                        ts.VoteCommit();

                        lblInfo.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        lblInfo.Text = "Nemoguće snimiti podatak";
                    }
                }
            }
        }
    }
}
