using System.Windows.Forms;
using Castle.ActiveRecord;
using Model;

namespace VetStation
{
    public partial class FrmOwnerData : Form
    {
        public FrmOwnerData()
        {
            InitializeComponent();
            
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (SessionScope sc = new SessionScope())
                {
                    using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                    {
                        Model.Owner o = new Owner
                                            {
                                                FirstName = txtFirstName.Text,
                                                LastName = txtLastName.Text,
                                                Jmbg = txtUniquePersonalID.Text,
                                                RegistrationNumberOfProperty = txtRegNumber_Owner.Text,
                                                PhoneNumber = txtPhone.Text,
                                                Address = txtAdress.Text,
                                                DateOfEntry = clOwner.SelectionStart,
                                                Email = txtEmail.Text,
                                                Visible = 1
                                            };

                        o.Save();

                        ts.VoteCommit();
                        lblInfo.Visible = true;
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUniquePersonalID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
