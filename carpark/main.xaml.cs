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

        #region Spaces
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
        #endregion

        private void btn_enterACar1_Click(object sender, RoutedEventArgs e)
        {
            txt_spacesAvailable1.Text = CarparkManager.Instance.GetCarpark(3).GetEmptySpaces().ToString() + " spaces are available";
            txt_displayBarriers.Text = "Carpark Barrier Lifted";
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
                CheckIfSpace1IsAllocated();
                txt_displayBarriers.Text = "Barrier on Bay 1 Locked";
                /*if (!CarparkManager.Instance.GetCarpark(3).GetSpace(0).IsAllocated())
                {
                    CarparkManager.Instance.GetCarpark(3).GetSpace(0).SetAllocated(true);
                    txt_space1.Text = "Locked";
                }*/
            }
        }

        private void btn_bay1submit1_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg(pass_reg2) && CheckPassword(pass_bay2))
            {
                txt_displayBarriers.Text = "Barrier on Bay 2 Locked";
                CheckIfSpace2IsAllocated();
                /*if (!CarparkManager.Instance.GetCarpark(3).GetSpace(1).IsAllocated())
                {
                    CarparkManager.Instance.GetCarpark(3).GetSpace(1).SetAllocated(true);
                    txt_space2.Text = "Locked";
                }*/
            }
        }

        private void btn_submit_Copy4_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg(pass_reg3) && CheckPassword(pass_bay3))
            {
                CheckIfSpace3IsAllocated();
                txt_displayBarriers.Text = "Barrier on Bay 3 Locked";
                /*if (!CarparkManager.Instance.GetCarpark(3).GetSpace(2).IsAllocated())
                {
                    CarparkManager.Instance.GetCarpark(3).GetSpace(2).SetAllocated(true);
                    txt_space3.Text = "Locked";
                }*/
            }
        }

        private void btn_submit_Copy5_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg(pass_reg4) && CheckPassword(pass_bay4))
            {
                CheckIfSpace4IsAllocated();
                txt_displayBarriers.Text = "Barrier on Bay 4 Locked";
                /*if (!CarparkManager.Instance.GetCarpark(3).GetSpace(3).IsAllocated())
                {
                    CarparkManager.Instance.GetCarpark(3).GetSpace(3).SetAllocated(true);
                    txt_space4.Text = "Locked";
                }*/
            }
        }

        private void btn_submit_Copy6_Click(object sender, RoutedEventArgs e)
        {
            if (CheckReg(pass_reg5) && CheckPassword(pass_bay5))
            {
                CheckIfSpace5IsAllocated();
                txt_displayBarriers.Text = "Barrier on Bay 5 Locked";
                /*if (!CarparkManager.Instance.GetCarpark(3).GetSpace(4).IsAllocated())
                {
                        CarparkManager.Instance.GetCarpark(3).GetSpace(4).SetAllocated(true);
                        txt_space5.Text = "Locked";
                }*/
            }
        }
        #endregion
        #region Bay Unlock Buttons
        private void btn_unlock1_Click(object sender, RoutedEventArgs e)
        {
            txt_space1.Text = "Pay!";
            txt_AmountDue1.Text = "£6.00";
            CurrentlySelectedBay = 0;

            txt_displayBarriers.Text = "Barrier on bay 1 will be raised after payment";
            txt_Payment1.Text = "Please pay at the machine located at Space 1";
        }

        private void btn_unlock_Copy4_Click(object sender, RoutedEventArgs e)
        {
            txt_space2.Text = "Pay!";
            txt_AmountDue1.Text = "£10.00";
            CurrentlySelectedBay = 1;

            txt_displayBarriers.Text = "Barrier on bay 2 will be raised after payment";
            txt_Payment1.Text = "Please pay at the machine located at Space 2";
        }

        private void btn_unlock_Copy5_Click(object sender, RoutedEventArgs e)
        {
            txt_space3.Text = "Pay!";
            txt_AmountDue1.Text = "£2.00";
            CurrentlySelectedBay = 2;

            txt_displayBarriers.Text = "Barrier on bay 3 will be raised after payment";
            txt_Payment1.Text = "Please pay at the machine located at Space 3";
        }

        private void btn_unlock_Copy6_Click(object sender, RoutedEventArgs e)
        {
            txt_space4.Text = "Pay!";
            txt_AmountDue1.Text = "£15.00";
            CurrentlySelectedBay = 3;

            txt_displayBarriers.Text = "Barrier on bay 4 will be raised after payment";
            txt_Payment1.Text = "Please pay at the machine located at Space 4";
        }

        private void btn_unlock_Copy7_Click(object sender, RoutedEventArgs e)
        {
            txt_space5.Text = "Pay!";
            txt_AmountDue1.Text = "£6.00";
            CurrentlySelectedBay = 4;

            txt_displayBarriers.Text = "Barrier on bay 5 will be raised after payment";
            txt_Payment1.Text = "Please pay at the machine located at Space 5";
        }
        #endregion
        #region Check If Spaces Are Allocated
        private bool CheckIfSpace5IsAllocated()
        {
            if (txt_space5.Text == "Allocated")
            {
                txt_space5.Text = "Locked";
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfSpace4IsAllocated()
        {
            if (txt_space4.Text == "Allocated")
            {
                txt_space4.Text = "Locked";
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfSpace3IsAllocated()
        {
            if (txt_space3.Text == "Allocated")
            {
                txt_space3.Text = "Locked";
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfSpace2IsAllocated()
        {
            if (txt_space2.Text == "Allocated")
            {
                txt_space2.Text = "Locked";
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfSpace1IsAllocated()
        {
            if (txt_space1.Text == "Allocated")
            {
                txt_space1.Text = "Locked";
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region CheckReg and CheckPassword
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
        #endregion

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
            txt_paymentDone.Text = "Emergency Vehicles are on the way.  Please exit through exit 2 and 3 only.";
            txt_EmergencyVehicles.Text = "Emergency Vehicles enter through Entry 1 and use Exit 1. Please keep these entry and exit points clear";
            txt_displayBarriers.Text = "Carpark Barrier Lifted, Fire In Progress";
        }

        private void btn_emergencyTheft_Click(object sender, RoutedEventArgs e)
        {
            grid_background.Background = new SolidColorBrush(Color.FromArgb(255, 60, 60, 255));
            txt_space1.Text = "Locked!";
            txt_space2.Text = "Locked!";
            txt_space3.Text = "Locked!";
            txt_space4.Text = "Locked!";
            txt_space5.Text = "Locked!";

            txt_paymentDone.Text = "Police are on their way.  All cars locked in until further notice.";
            txt_EmergencyVehicles.Text = "Police will enter through Entry 1 and use Exit 1.";
            txt_displayBarriers.Text = "Carpark Barrier Lowered. Will Only Raise For Police Vehicles.";
        }

        private void btn_emergencyStop_Click(object sender, RoutedEventArgs e)
        {
            grid_background.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            txt_space1.Text = "Space 1";
            txt_space2.Text = "Space 2";
            txt_space3.Text = "Space 3";
            txt_space4.Text = "Space 4";
            txt_space5.Text = "Space 5";

            txt_paymentDone.Text = "";
            txt_EmergencyVehicles.Text = "";
            txt_displayBarriers.Text = "";

            txt_coinDispensed1.Text = "";
            txt_coinDispensed2.Text = "";
            txt_coinDispensed3.Text = "";
            txt_coinDispensed4.Text = "";
            txt_coinDispensed5.Text = "";

            ResetAllocatedSpaces();
        }
        #endregion

        private bool ResetAllocatedSpaces()
        {
            int id = CarparkManager.Instance.GetCarpark(3).GetEmptySpaces();
            Space space1 = CarparkManager.Instance.GetCarpark(3).GetSpace(id);

            //Space space = CarparkManager.Instance.GetCarpark(3).nextAvailableCarParkingSpace();
            space1.SetAllocated(true);
            UpdateSpaces();
            return true;
        }

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
            if (IsCoinCollected())
            {
                DeallocateSpace();
                txt_spacesAvailable1.Text = CarparkManager.Instance.GetCarpark(3).GetEmptySpaces().ToString();
                txt_displayBarriers.Text = "Carpark Barrier Lifted";
            }
        }

        #region Coin Collected Buttons
        private void txt_space1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txt_coinDispensed1.Text = "Coin Collected";
        }

        private void txt_space2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txt_coinDispensed2.Text = "Coin Collected";
        }

        private void txt_space3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txt_coinDispensed3.Text = "Coin Collected";
        }

        private void txt_space4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txt_coinDispensed4.Text = "Coin Collected";
        }

        private void txt_space5_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txt_coinDispensed5.Text = "Coin Collected";
        }

        private bool IsCoinCollected()
        {
            if (txt_space1.Text == "Pay!")
            {
                txt_coinDispensed1.Text = "";
                return true;
            }
            else if (txt_space2.Text == "Pay!")
            {
                txt_coinDispensed2.Text = "";
                return true;
            }
            else if (txt_space3.Text == "Pay!")
            {
                txt_coinDispensed3.Text = "";
                return true;
            }
            else if (txt_space4.Text == "Pay!")
            {
                txt_coinDispensed4.Text = "";
                return true;
            }
            else if (txt_space5.Text == "Pay!")
            {
                txt_coinDispensed5.Text = "";
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region You Have Paid
        private void pic_android_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (txt_AmountDue1.Text.Contains("£"))
            {
                txt_paymentDone.Text = "You Have Paid. Exit Through Ground FLoor - Exit 1";
                txt_displayBarriers.Text = "Barrier Raised, You Are Free To Exit.";
                txt_Payment1.Text = "";
                ClearFields(CurrentlySelectedBay);
            }
        }

        private void pic_apple_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (txt_AmountDue1.Text.Contains("£"))
            {
                txt_paymentDone.Text = "You Have Paid. Exit Through Ground FLoor - Exit 2";
                txt_displayBarriers.Text = "Barrier Raised, You Are Free To Exit.";
                txt_Payment1.Text = "";
                ClearFields(CurrentlySelectedBay);
            }
        }

        private void pic_contactless_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (txt_AmountDue1.Text.Contains("£"))
            {
                txt_paymentDone.Text = "You Have Paid. Exit Through Ground FLoor - Exit 1";
                txt_displayBarriers.Text = "Barrier Raised, You Are Free To Exit.";
                txt_Payment1.Text = "";
                ClearFields(CurrentlySelectedBay);
            }
        }

        private void pic_card_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (txt_AmountDue1.Text.Contains("£"))
            {
                txt_paymentDone.Text = "You Have Paid. Exit Through Ground FLoor - Exit 2";
                txt_displayBarriers.Text = "Barrier Raised, You Are Free To Exit.";
                txt_Payment1.Text = "";
                ClearFields(CurrentlySelectedBay);
            }
        }
        #endregion

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

        private void txt_spacesAvailable1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
