using carpark.CarParkManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
        private int CurrentlySelectedBay;

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
            if (id != null)
            {
                Space space = CarparkManager.Instance.GetCarpark(3).GetSpace(id);

                if (space != null)
                {
                    space.SetAllocated(false);
                    txtBlcks[space.GetId()].Text = "Free";
                }
            }
        }

        private void UpdateSpaces()
        {
            txt_spacesAvailable1.Text = LocalInterface.Instance.GetSpaces() + " spaces available.";
        }

        private void btn_enterACar1_Click(object sender, RoutedEventArgs e)
        {
            txt_spacesAvailable1.Text = CarparkManager.Instance.GetCarpark(3).GetEmptySpaces().ToString() + " spaces are available";
            AllocateNewSpace();
        }

        private void Combobx_Prices_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        #region Bay Submit Buttons
        private void btn_submit2_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg(pass_reg1) && CheckPassword(pass_bay1))
            {
                if (!CarparkManager.Instance.GetCarpark(3).GetSpace(0).IsAllocated())
                {
                    CarparkManager.Instance.GetCarpark(3).GetSpace(0).SetAllocated(true);
                    txt_space1.Text = "Locked";
                }
            }
        }

        private void btn_bay1submit1_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg(pass_reg2) && CheckPassword(pass_bay2))
            {
                if (!CarparkManager.Instance.GetCarpark(3).GetSpace(1).IsAllocated())
                {
                    CarparkManager.Instance.GetCarpark(3).GetSpace(1).SetAllocated(true);
                    txt_space1.Text = "Locked";
                }
            }
        }

        private void btn_submit_Copy4_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg(pass_reg3) && CheckPassword(pass_bay3))
            {
                if (!CarparkManager.Instance.GetCarpark(3).GetSpace(2).IsAllocated())
                {
                    CarparkManager.Instance.GetCarpark(3).GetSpace(2).SetAllocated(true);
                    txt_space1.Text = "Locked";
                }
            }
        }

        private void btn_submit_Copy5_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg(pass_reg4) && CheckPassword(pass_bay4))
            {
                if (!CarparkManager.Instance.GetCarpark(3).GetSpace(3).IsAllocated())
                {
                    CarparkManager.Instance.GetCarpark(3).GetSpace(3).SetAllocated(true);
                    txt_space1.Text = "Locked";
                }
            }
        }

        private void btn_submit_Copy6_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg(pass_reg5) && CheckPassword(pass_bay5))
            {
                if (!CarparkManager.Instance.GetCarpark(3).GetSpace(4).IsAllocated())
                {
                    CarparkManager.Instance.GetCarpark(3).GetSpace(4).SetAllocated(true);
                    txt_space1.Text = "Locked";
                }
            }
        }
        #endregion
        #region Bay Unlock Buttons
        private void btn_unlock1_Click(object sender, RoutedEventArgs e)
        {
            txt_space1.Text = "Pay!";
            txt_AmountDue1.Text = "£6.00";
            CurrentlySelectedBay = 0;
        }

        private void btn_unlock_Copy4_Click(object sender, RoutedEventArgs e)
        {
            txt_space2.Text = "Pay!";
            txt_AmountDue1.Text = "£10.00";
            CurrentlySelectedBay = 1;
        }

        private void btn_unlock_Copy5_Click(object sender, RoutedEventArgs e)
        {
            txt_space3.Text = "Pay!";
            txt_AmountDue1.Text = "£2.00";
            CurrentlySelectedBay = 2;
        }

        private void btn_unlock_Copy6_Click(object sender, RoutedEventArgs e)
        {
            txt_space4.Text = "Pay!";
            txt_AmountDue1.Text = "£15.00";
            CurrentlySelectedBay = 3;
        }

        private void btn_unlock_Copy7_Click(object sender, RoutedEventArgs e)
        {
            txt_space5.Text = "Pay!";
            txt_AmountDue1.Text = "£6.00";
            CurrentlySelectedBay = 4;
        }
        #endregion

        private bool CheckReg(PasswordBox pass)
        {
            if (pass.Password.Length == 0)
            {
                txt_paymentDone.Text = "The registration field cannot be left empty";
                return false;
            }
            else if (pass.Password.Length <= 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckPassword(PasswordBox pass)
        {
            if (pass.Password == "Password")
            {
                txt_paymentDone.Text = " 'Password' is not allowed to be set as a password";
                return false;
            }
            else if (pass.Password.Length == 0)
            {
                txt_paymentDone.Text = "The password field cannot be left empty";
                return false;
            }
            else if (pass.Password.Length <= 16)
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
            PasswordBox[] passes = new PasswordBox[] { pass_bay1, pass_bay2, pass_bay3, pass_bay4, pass_bay5 };

            for (int i = 0; i < passes.Length; i++)
            {
                if(passes[i].Password == pass_coin.Password)
                {
                    DeterminePayment(i);
                    txt_paymentDone.Text = "Continue to pay";
                    return;
                }
            }

            txt_paymentDone.Text = "Password for forgotten coin does not match";
        }

        private void txt_forgotPass1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txt_proceedToPay1.Text = "Validation sucessful. Continue to payment.";
        }

        private void txt_forgotPass1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        #region Emergency buttons
        private void btn_emergencyFire_Copy_Click(object sender, RoutedEventArgs e)
        {
            grid_background.Background = new SolidColorBrush(Color.FromArgb(255, 255, 60, 60));
            txt_space1.Text = "Unlocked!";
            txt_space2.Text = "Unlocked!";
            txt_space3.Text = "Unlocked!";
            txt_space4.Text = "Unlocked!";
            txt_space5.Text = "Unlocked!";
        }

        private void btn_emergencyTheft_Click(object sender, RoutedEventArgs e)
        {
            grid_background.Background = new SolidColorBrush(Color.FromArgb(255, 60, 60, 255));
            txt_space1.Text = "Locked!";
            txt_space2.Text = "Locked!";
            txt_space3.Text = "Locked!";
            txt_space4.Text = "Locked!";
            txt_space5.Text = "Locked!";
        }

        private void btn_emergencyStop_Click(object sender, RoutedEventArgs e)
        {
            grid_background.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            txt_space1.Text = "Space 1";
            txt_space2.Text = "Space 2";
            txt_space3.Text = "Space 3";
            txt_space4.Text = "Space 4";
            txt_space5.Text = "Space 5";
        }
        #endregion

        private void btn_submit3_Click(object sender, RoutedEventArgs e)
        {
            if (CarparkManager.Instance.ValidateDiscountCode(pass_DiscountCode.Password))
            {
                if(txt_AmountDue1.Text.Length > 0)
                {
                    double price = double.Parse(txt_AmountDue1.Text.TrimStart('£'));
                    price *= 0.8;
                    txt_AmountDue1.Text = "£" + Math.Round(price, 2).ToString();
                }
                else
                {
                    txt_AmountDue1.Text = "Please unlock a pay before payment";
                }
            }
        }

        private void btn_exitCar1_Click(object sender, RoutedEventArgs e)
        {
            DeallocateSpace();
            txt_spacesAvailable1.Text = CarparkManager.Instance.GetCarpark(3).GetEmptySpaces().ToString();
        }

        private void txt_space1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txt_coinDispensed1.Text = "Coin Collected";
        }

        private void txt_space2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txt_bay1coinDispensed1.Text = "Coin Collected";
        }

        private void txt_space3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txt_coinDispensed_Copy4.Text = "Coin Collected";
        }

        private void txt_space4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txt_coinDispensed_Copy5.Text = "Coin Collected";
        }

        private void txt_space5_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txt_coinDispensed_Copy6.Text = "Coin Collected";
        }

        private void pic_android_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (txt_AmountDue1.Text.Contains("£"))
            {
                txt_paymentDone.Text = "You Have Paid. Exit Through Ground FLoor - Exit 1";
                ClearFields(CurrentlySelectedBay);
            }
        }

        private void pic_apple_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (txt_AmountDue1.Text.Contains("£"))
            {
                txt_paymentDone.Text = "You Have Paid. Exit Through Ground FLoor - Exit 2";
                ClearFields(CurrentlySelectedBay);
            }
        }

        private void pic_contactless_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (txt_AmountDue1.Text.Contains("£"))
            {
                txt_paymentDone.Text = "You Have Paid. Exit Through Ground FLoor - Exit 1";
                ClearFields(CurrentlySelectedBay);
            }
        }

        
        private void pic_card_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (txt_AmountDue1.Text.Contains("£"))
            {
                txt_paymentDone.Text = "You Have Paid. Exit Through Ground FLoor - Exit 2";
                ClearFields(CurrentlySelectedBay);
            }
        }

        private void ClearFields(int currentlySelectedBay)
        {
            if (currentlySelectedBay == -1)
            {
                return;
            }

            txt_AmountDue1.Text = "";
            pass_DiscountCode.Password = "";
            pass_coin.Password = "";

            switch (currentlySelectedBay)
            {
                case 0:
                    pass_bay1.Password = "";
                    pass_reg1.Password = "";
                    break;
                case 1:
                    pass_bay2.Password = "";
                    pass_reg2.Password = "";
                    break;
                case 2:
                    pass_bay3.Password = "";
                    pass_reg3.Password = "";
                    break;
                case 3:
                    pass_bay4.Password = "";
                    pass_reg4.Password = "";
                    break;
                case 4:
                    pass_bay5.Password = "";
                    pass_reg5.Password = "";
                    break;
                default:
                    txt_AmountDue1.Text = "Failed to determine bay";
                    break;
            }

            currentlySelectedBay = -1;
        }

        private void DeterminePayment(int i)
        {
            switch (i)
            {
                case 0:
                    btn_unlock1_Click(this, null);
                    break;
                case 1:
                    btn_unlock_Copy4_Click(this, null);
                    break;
                case 2:
                    btn_unlock_Copy5_Click(this, null);
                    break;
                case 3:
                    btn_unlock_Copy6_Click(this, null);
                    break;
                case 4:
                    btn_unlock_Copy7_Click(this, null);
                    break;
                default:
                    txt_AmountDue1.Text = "Failed to determine bay";
                    break;
            }
        }
    }
}
