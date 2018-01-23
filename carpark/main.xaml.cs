using carpark.CarParkManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace carpark
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class main : Page
    {
        TextBlock[] txtBlcks;

        string password1 = "";

        public main()
        {
            this.InitializeComponent();

            LocalInterface.LoadCarpark("Wheatfield");

            txtBlcks = new TextBlock[] { txt_space1, txt_space2, txt_space3, txt_space4, txt_space5 };
            UpdateSpaces();
        }

        private void AllocateNewSpace()
        {
            Space space = CarparkManager.Instance.GetCarpark(3).nextAvailableCarParkingSpace();
            space.SetAllocated(true);
            txtBlcks[space.GetId()].Text = "Allocated";
        }

        private void DeallocateSpace()
        {
            int id = CarparkManager.Instance.GetCarpark(3).getAllocatedSpaces();
            Space space = CarparkManager.Instance.GetCarpark(3).GetSpace(id);

            if (space != null)
            {
                space.SetAllocated(false);
                txtBlcks[space.GetId()].Text = "Deallocate";
            }
        }

        private void UpdateSpaces()
        {
            txt_spacesAvailable1.Text = LocalInterface.Instance.GetSpaces() + " spaces available.";
        }

        private void btn_enterACar1_Click(object sender, RoutedEventArgs e)
        {
            txt_spacesAvailable1.Text = CarparkManager.Instance.GetCarpark(3).GetEmptySpaces().ToString();
            AllocateNewSpace();
        }

        private void Combobx_Prices_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void btn_submit2_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg())
            {
                if (txt_space1.Text != "Allocated" && txt_space1.Text == "Space 1")
                {
                    txt_space1.Text = "Space 1";
                }
                else
                {
                    txt_space1.Text = "Locked";
                }
            }
        }

        private void btn_bay1submit1_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg())
            {
                if (txt_space2.Text != "Allocated" && txt_space2.Text == "Space 2")
                {
                    txt_space2.Text = "Space 2";
                }
                else
                {
                    txt_space2.Text = "Locked";
                }
            }

            if (txt_space2.Text != "Allocated")
            {
                txt_space2.Text = "Space 2";
            }
            else
            {
                txt_space2.Text = "Locked";
            }
        }

        private void btn_submit_Copy4_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg())
            {
                if (txt_space3.Text != "Allocated" && txt_space3.Text == "Space 3")
                {
                    txt_space3.Text = "Space 3";
                }
                else
                {
                    txt_space3.Text = "Locked";
                }
            }

            if (txt_space3.Text != "Allocated")
            {
                txt_space3.Text = "Space 3";
            }
            else
            {
                txt_space3.Text = "Locked";
            }
        }

        private void btn_submit_Copy5_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg())
            {
                if (txt_space4.Text != "Allocated" && txt_space4.Text == "Space 4")
                {
                    txt_space4.Text = "Space 4";
                }
                else
                {
                    txt_space4.Text = "Locked";
                }
            }

            if (txt_space4.Text != "Allocated")
            {
                txt_space4.Text = "Space 4";
            }
            else
            {
                txt_space4.Text = "Locked";
            }
        }

        private void btn_submit_Copy6_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg())
            {
                if (txt_space5.Text != "Allocated" && txt_space5.Text == "Space 5")
                {
                    txt_space5.Text = "Space 5";
                }
                else
                {
                    txt_space5.Text = "Locked";
                }
            }

            if (txt_space5.Text != "Allocated")
            {
                txt_space5.Text = "Space 5";
            }
            else
            {
                txt_space5.Text = "Locked";
            }
        }

        private void btn_unlock1_Click(object sender, RoutedEventArgs e)
        {
            txt_space1.Text = "Pay!";
            txt_AmountDue1.Text = "£6.00";
        }

        private void btn_unlock_Copy4_Click(object sender, RoutedEventArgs e)
        {
            txt_space2.Text = "Pay!";
            txt_AmountDue1.Text = "£10.00";
        }

        private void btn_unlock_Copy5_Click(object sender, RoutedEventArgs e)
        {
            txt_space3.Text = "Pay!";
            txt_AmountDue1.Text = "£2.00";
        }

        private void btn_unlock_Copy6_Click(object sender, RoutedEventArgs e)
        {
            txt_space4.Text = "Pay!";
            txt_AmountDue1.Text = "£15.00";
        }

        private void btn_unlock_Copy7_Click(object sender, RoutedEventArgs e)
        {
            txt_space5.Text = "Pay!";
            txt_AmountDue1.Text = "£6.00";
        }

        private void pass_enterReg1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string pword1, reg1;

            //get int reg into reg 1
            //get int reg into pword 1

            CheckReg();
        }

        private bool CheckReg()
        {
            if (pass_enterReg1.Password.Length == 0)
            {
                txt_paymentDone.Text = "The registration field cannot be left empty";
                return false;
            }
            else if (pass_enterReg1.Password.Length <= 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_submitPassForCoin1_Click(object sender, RoutedEventArgs e)
        {
            if (pass_reEnterPassForCoin1.Password != password1)
            {
                txt_paymentDone.Text = "Password does not match";
            }
            else
            {
                txt_paymentDone.Text = "Continue";
            }
        }

        private void txt_forgotPass1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txt_proceedToPay1.Text = "Validation sucessful. Continue to payment.";
        }

        private void txt_forgotPass1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void btn_emergencyFire_Copy_Click(object sender, RoutedEventArgs e)
        {
            txt_space1.Text = "Unlocked!";
            txt_space2.Text = "Unlocked!";
            txt_space3.Text = "Unlocked!";
            txt_space4.Text = "Unlocked!";
            txt_space5.Text = "Unlocked!";
        }

        private void btn_emergencyTheft_Click(object sender, RoutedEventArgs e)
        {
            txt_space1.Text = "Locked!";
            txt_space2.Text = "Locked!";
            txt_space3.Text = "Locked!";
            txt_space4.Text = "Locked!";
            txt_space5.Text = "Locked!";
        }

        private void btn_emergencyStop_Click(object sender, RoutedEventArgs e)
        {
            txt_space1.Text = "Space 1";
            txt_space2.Text = "Space 2";
            txt_space3.Text = "Space 3";
            txt_space4.Text = "Space 4";
            txt_space5.Text = "Space 5";
        }

        private bool CheckDiscountCode()
        {
            if (pass_enterDiscount1.Password == "BN123")
            {
                return true;
            }
            else if (pass_enterDiscount1.Password == "TH589")
            {
                return true;
            }
            else if (pass_enterDiscount1.Password == "CK490")
            {
                return true;
            }
            else
            {
                txt_paymentDone.Text = "This discount code is invalid";
                return false;
            }
        }

        private void btn_submit3_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_exitCar1_Click(object sender, RoutedEventArgs e)
        {
            DeallocateSpace();
            txt_spacesAvailable1.Text = CarparkManager.Instance.GetCarpark(3).GetEmptySpaces().ToString();
        }
    }
}
