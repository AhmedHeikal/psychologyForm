using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

//TODO Finish the reports: rebuild them from scratch like the first detailed Reports 
//TODO Finish the meeting page, saving >> editing >> deleting >> Reports 

namespace phsycologyForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap orangeSave = new Bitmap(phsycologyForm.Properties.Resources.daf_orange);
        Bitmap whiteSave = new Bitmap(phsycologyForm.Properties.Resources.fds);
        Bitmap orangeNext = new Bitmap(phsycologyForm.Properties.Resources.fdff);
        Bitmap whiteNext = new Bitmap(phsycologyForm.Properties.Resources.d);
        Bitmap orangeReport = new Bitmap(phsycologyForm.Properties.Resources.OR);
        Bitmap whiteReport = new Bitmap(phsycologyForm.Properties.Resources.WR);
        Bitmap whiteBrush = new Bitmap(phsycologyForm.Properties.Resources.brushWhite);
        Bitmap orangeBrush = new Bitmap(phsycologyForm.Properties.Resources.brushOrange);
        Bitmap whiteWW = new Bitmap(phsycologyForm.Properties.Resources.WWWhite);
        Bitmap orangeWW = new Bitmap(phsycologyForm.Properties.Resources.WWOrange);
        Bitmap whiteTide = new Bitmap(phsycologyForm.Properties.Resources.TideWhite);
        Bitmap orangeTide = new Bitmap(phsycologyForm.Properties.Resources.TideOrange);
        Bitmap meetingWhite = new Bitmap(phsycologyForm.Properties.Resources.reportMeetingWhite);
        Bitmap meetingOrange = new Bitmap(phsycologyForm.Properties.Resources.reportMeetingOrange);

        private void roundedButton1_MouseHover_1(object sender, EventArgs e)
        {
            roundedButton1.Image = orangeTide;
        }
        
        private void roundedButton1_MouseLeave_1(object sender, EventArgs e)
        {
            roundedButton1.Image = whiteTide;
        }

        private void roundedButton1_MouseHover(object sender, EventArgs e)
        {
            saveButton.Image = orangeSave;
        }

        private void roundedButton1_MouseLeave(object sender, EventArgs e)
        {
            saveButton.Image = whiteSave;
        }

        private void nextPageButton_MouseHover(object sender, EventArgs e)
        {
            nextPageButton.Image = orangeNext;
        }

        private void nextPageButton_MouseLeave(object sender, EventArgs e)
        {
            nextPageButton.Image = whiteNext;
        }

        private void roundedButton2_MouseHover(object sender, EventArgs e)
        {
            patientReportButton.Image = orangeReport;
        }

        private void roundedButton2_MouseLeave(object sender, EventArgs e)
        {
            patientReportButton.Image = whiteReport;
        }

        private void roundedButton3_MouseHover(object sender, EventArgs e)
        {
            meetingsReportButton.Image = meetingOrange;
        }

        private void roundedButton3_MouseLeave(object sender, EventArgs e)
        {
            meetingsReportButton.Image = meetingWhite;
        }

        private void clearPageDataButton_MouseHover(object sender, EventArgs e)
        {
            clearPageDataButton.Image = orangeWW;
        }

        private void clearPageDataButton_MouseLeave(object sender, EventArgs e)
        {
            clearPageDataButton.Image = whiteWW;
        }

        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["psychologyDBConnectionString"].ConnectionString;

        //====> Static to be used across the application <====

        string patientSex;
        string patientType;
        string patientStatus;
        string patientWorkNature;
        string reasonsToQuitSchool = "";
        string SuicideAttempts = "";
        string drugAbuse = "";


        void dynamicChildrenCalculator(TextBox first, TextBox second, TextBox TotalTextBox)
        {
            int parsedValue;
            if (int.TryParse(first.Text, out parsedValue))
            {
                if (int.TryParse(second.Text, out parsedValue))
                {
                    TotalTextBox.Text = (Int32.Parse(first.Text) + (Int32.Parse(second.Text))).ToString();
                }
                else
                {
                    TotalTextBox.Text = (Int32.Parse(first.Text)).ToString();
                }
            }
            else
            {
                if (int.TryParse(second.Text, out parsedValue))
                {
                    TotalTextBox.Text = (Int32.Parse(second.Text)).ToString();
                }
                else
                {
                    TotalTextBox.Text = "0";
                }
            }
        }



        private void generalInformationsButton_Click(object sender, EventArgs e)
        {
            showSubMenus(generalInformationPanel);
        }

        private void characterAnalysisButton_Click(object sender, EventArgs e)
        {
            showSubMenus(characterAnalysisPanel);
        }

        private void enviromentAnalysisButton_Click(object sender, EventArgs e)
        {
            showSubMenus(enviromentAnalysisPanel);
        }

        private void teensButton_Click(object sender, EventArgs e)
        {
            showSubMenus(teensPanel);
        }


        private void personalCharactersticcsButton_Click(object sender, EventArgs e)
        {
            nextPageButton.Visible = true;
            tabControl1.SelectedTab = TabPage0_0;
            tabControl4.SelectedTab = TabPage0_1;
            normalizeButtonColorStatus();
            selectedTabButton(personalCharactersticcsButton, generalInformationsButton);
        }

        private void generalInformationButton_Click(object sender, EventArgs e)
        {
            nextPageButton.Visible = true;
            tabControl1.SelectedTab = TabPage0_0;
            tabControl4.SelectedTab = TabPage0_2;
            normalizeButtonColorStatus();
            selectedTabButton(generalInformationButton, generalInformationsButton);
        }

        private void socialCharacteristicsButton_Click(object sender, EventArgs e)
        {
            nextPageButton.Visible = true;
            tabControl1.SelectedTab = TabPage1_0;
            tabControl2.SelectedTab = TabPage1_1;
            normalizeButtonColorStatus();
            selectedTabButton(socialCharacteristicsButton, characterAnalysisButton);
        }

        private void illnessProblemsButton_Click(object sender, EventArgs e)
        {
            nextPageButton.Visible = true;
            tabControl1.SelectedTab = TabPage1_0;
            tabControl2.SelectedTab = TabPage1_2;
            normalizeButtonColorStatus();
            selectedTabButton(illnessProblemsButton, characterAnalysisButton);
        }

        private void socialStatusButton_Click(object sender, EventArgs e)
        {
            nextPageButton.Visible = true;
            tabControl1.SelectedTab = TabPage2_0;
            tabControl3.SelectedTab = TabPage2_1;
            normalizeButtonColorStatus();
            selectedTabButton(socialStatusButton, enviromentAnalysisButton);
        }

        private void bigFamilyButton_Click(object sender, EventArgs e)
        {
            nextPageButton.Visible = true;
            tabControl1.SelectedTab = TabPage2_0;
            tabControl3.SelectedTab = TabPage2_2;
            normalizeButtonColorStatus();
            selectedTabButton(bigFamilyButton, enviromentAnalysisButton);
        }

        private void socialDetailsButton_Click(object sender, EventArgs e)
        {
            nextPageButton.Visible = true;
            tabControl1.SelectedTab = TabPage3_0;
            tabControl5.SelectedTab = TabPage3_1;
            normalizeButtonColorStatus();
            selectedTabButton(socialDetailsButton, teensButton);

        }

        private void individualBehaviorButton_Click(object sender, EventArgs e)
        {
            nextPageButton.Visible = true;
            tabControl1.SelectedTab = TabPage3_0;
            tabControl5.SelectedTab = TabPage3_2;
            normalizeButtonColorStatus();
            selectedTabButton(individualBehaviorButton, teensButton);
        }

        private void meetingsButton_Click_1(object sender, EventArgs e)
        {
            nextPageButton.Visible = false;
            tabControl1.SelectedTab = TabPage4_0;
            normalizeButtonColorStatus();
            selectedTabButton(individualBehaviorButton, meetingsButton);
            hideSubMenus();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modifySSNRB.Checked)
                newCaseRB.Checked = true;
            if (editMeetingTitle.Checked)
                newMeetingRB.Checked = true;
        }

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modifySSNRB.Checked)
                newCaseRB.Checked = true;
        }

        private void SelectedTab()
        {
            if (tabControl1.SelectedTab == TabPage0_0 && tabControl4.SelectedTab == TabPage0_1)
            {
            }
            else if (tabControl1.SelectedTab == TabPage0_0 && tabControl4.SelectedTab == TabPage0_2)
            {
                normalizeButtonColorStatus();
                normalizeButtonColorStatus();
                selectedTabButton(personalCharactersticcsButton, generalInformationsButton);

            }
            else if (tabControl1.SelectedTab == TabPage1_0 && tabControl2.SelectedTab == TabPage1_1)
            {
                normalizeButtonColorStatus();
            }
            else if (tabControl1.SelectedTab == TabPage1_0 && tabControl2.SelectedTab == TabPage1_2)
            {
                normalizeButtonColorStatus();
            }
            else if (tabControl1.SelectedTab == TabPage2_0 && tabControl3.SelectedTab == TabPage2_1)
            {
                normalizeButtonColorStatus();
            }
            else if (tabControl1.SelectedTab == TabPage2_0 && tabControl3.SelectedTab == TabPage2_2)
            {
                normalizeButtonColorStatus();
            }
            else if (tabControl1.SelectedTab == TabPage3_0 && tabControl5.SelectedTab == TabPage3_1)
            {
                normalizeButtonColorStatus();
            }

            else if (tabControl1.SelectedTab == TabPage3_0 && tabControl5.SelectedTab == TabPage3_2)
            {
                normalizeButtonColorStatus();
            }
        }

        private void normalizeButtonColorStatus()
        {
            generalInformationsButton.BackColor = Color.FromArgb(11, 7, 17);
            personalCharactersticcsButton.BackColor = Color.FromArgb(41, 44, 51);
            generalInformationButton.BackColor = Color.FromArgb(41, 44, 51);
            characterAnalysisButton.BackColor = Color.FromArgb(11, 7, 17);
            socialCharacteristicsButton.BackColor = Color.FromArgb(41, 44, 51);
            illnessProblemsButton.BackColor = Color.FromArgb(41, 44, 51);
            enviromentAnalysisButton.BackColor = Color.FromArgb(11, 7, 17);
            socialStatusButton.BackColor = Color.FromArgb(41, 44, 51);
            bigFamilyButton.BackColor = Color.FromArgb(41, 44, 51);
            teensButton.BackColor = Color.FromArgb(11, 7, 17);
            socialDetailsButton.BackColor = Color.FromArgb(41, 44, 51);
            individualBehaviorButton.BackColor = Color.FromArgb(41, 44, 51);
            meetingsButton.BackColor = Color.FromArgb(11, 7, 17);
        }
        private void selectedTabButton(Button btnDetails, Button mainBar)
        {
            if (mainBar.Name != meetingsButton.Name)
                btnDetails.BackColor = Color.FromArgb(192, 27, 55);
            mainBar.BackColor = Color.FromArgb(55, 31, 98);
        }

        /// <summary>
        /// Pages are numbered from 1s to 5s respectfully to their order 
        /// 1s ==> General Information
        /// 2s ==> Personal Analysis ==> Social Charateristics
        /// 3s ==> Personal Analysis ==> Medical Issues
        /// 4s ==> Environmental Analysis ==> Social Status
        /// 5s ==> Environmental Analysis ==> Big Family
        /// </summary>

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.Text = "";
            }

            tabControl4.Appearance = TabAppearance.FlatButtons;
            tabControl4.ItemSize = new Size(0, 1);
            tabControl4.SizeMode = TabSizeMode.Fixed;
            foreach (TabPage tab in tabControl4.TabPages)
            {
                tab.Text = "";
            }

            tabControl2.Appearance = TabAppearance.FlatButtons;
            tabControl2.ItemSize = new Size(0, 1);
            tabControl2.SizeMode = TabSizeMode.Fixed;
            foreach (TabPage tab in tabControl2.TabPages)
            {
                tab.Text = "";
            }

            tabControl3.Appearance = TabAppearance.FlatButtons;
            tabControl3.ItemSize = new Size(0, 1);
            tabControl3.SizeMode = TabSizeMode.Fixed;
            foreach (TabPage tab in tabControl3.TabPages)
            {
                tab.Text = "";
            }

            tabControl5.Appearance = TabAppearance.FlatButtons;
            tabControl5.ItemSize = new Size(0, 1);
            tabControl5.SizeMode = TabSizeMode.Fixed;
            foreach (TabPage tab in tabControl5.TabPages)
            {
                tab.Text = "";
            }

            //==> 1s General Information Initialization
            // Initializing the RadioButtons and checkboxes
            maleRB.Checked = true;
            singleRB.Checked = true;
            adultRB.Checked = true;
            AtSingleRB.Checked = true;
            leftSchoolCB.Checked = true;
            wifeWorkingRB.Checked = true;
            LSrepitiveFailreRB.Checked = true;
            newCaseRB.Checked = true;
            residentRB.Checked = true;
            tactfulRB.Checked = true;
            convertedFromGeneralDoctorRB.Checked = true;
            purposeFamilyRB.Checked = true;
            deleteRecordButton.ImageIndex = 0;
            editSSNPanel.Visible = false;
            editMeetingTitlePanel.Visible = false;
            toolTip1.SetToolTip(nextPageButton, " التنقل للصفحة التالية والتأكد من صحة البيانات ");
            toolTip1.SetToolTip(saveButton, "حفظ البيانات ");
            toolTip1.SetToolTip(patientReportButton, "تقارير المرضى");
            toolTip1.SetToolTip(meetingsReportButton, "تقارير المقابلات");
            toolTip1.SetToolTip(clearPageDataButton, "إزالة اليانات للصفحة الحالية فقط");
            toolTip1.SetToolTip(roundedButton1, "إزالة اليانات لجميع الصفحات ");

            //deactivating the others group at the start
            deactivateOthersTextBoxAndLabelGroup(AtterndeOthersTextBox, label11);
            deactivateOthersTextBoxAndLabelGroup(LSothersTextBox, label12);
            deactivateTextBox(convertedFromOthersTextBox);
            deactivateTextBox(purposeOtherTextBox);
            //Disabling the injuries GB
            wnteredInstituteGB.Enabled = false;
            accidentsGB.Enabled = false;
            //Selecting the main menu button
            customizeSidePanel();
            generalInformationPanel.Visible = true;
            selectedTabButton(personalCharactersticcsButton, generalInformationsButton);


            //==> 2s Social Charicterstics Initialization
            // Initializing the RadioButtons and checkboxes
            poorEconimicRB.Checked = true;
            noAIRB.Checked = true;
            ownedRB.Checked = true;
            noFPRB.Checked = true;
            bossRelGoodRB.Checked = true;
            independentVillaRB.Checked = true;
            loneRoomRB.Checked = true;
            coworkersRelGoodRB.Checked = true;
            regulatedRB.Checked = true;
            officialHoursRB.Checked = true;
            //deactivating the others textBoxes at the start
            deactivateTextBox(otherHomeTextBox);
            deactivateTextBox(shareRoomWithTextBox);
            deactivateTextBox(behavioralTraitsOthersTextBox);
            deactivateTextBox(anotherIncomeTextBox);
            deactivateTextBox(financialProblemsTextBox);
            deactivateTextBox(miserableJobReasonTextBox);
            //Disabling the injuries GB
            accidentsGB.Enabled = false;

            // 3s ==> Personal Analysis Initialization
            noAttemptsRB.Checked = true;
            noUseRB.Checked = true;
            //Disabling the TextBoxes
            deactivateTextBox(warehouseCountsTextBox);
            deactivateTextBox(warehouseDetailsTextBox);
            deactivateTextBox(blackoutCountsTextBox);
            deactivateTextBox(blackoutDetailsTextBox);
            deactivateTextBox(familyIllnessDetailsTextBox);
            deactivateTextBox(workingNatureOthersTextBox);
            //Disabling the previous Treatment GB
            treatmentPlacesGB.Enabled = false;

            // 4s ==> Social Environmental Status Analysis Initialization
            noRelativeRB.Checked = true;
            patientMarriageSideComboBox.Items.Add("الأب");
            patientMarriageSideComboBox.Items.Add("الأم");
            fatherMarriageSideComboBox.Items.Add("الأب");
            fatherMarriageSideComboBox.Items.Add("الأم");
            motherMarriageSideComboBox.Items.Add("الأب");
            motherMarriageSideComboBox.Items.Add("الأم");
            smallFamilyRB.Checked = true;
            deactivateTextBox(otherResponsibilitiesTextBox);

            // 5s ==>  Big Family Environmental Analysis Initialization
            fatherWorkingRB.Checked = true;
            noFatherRelativeRB.Checked = true;
            motherWorkingRB.Checked = true;
            noMotherRelativeRB.Checked = true;

            // 6s ==>  Teen Analysis Initialization First Page
            schoolStageComboBox.Items.Add("الابتدائية");
            schoolStageComboBox.Items.Add("الإعدادية");
            schoolStageComboBox.Items.Add("الثانوية");
            pocketMoneyIsEnoughCB.Checked = true;
            badRelationsWithTeachersGB.Enabled = false;
            dailyPocketMoneyRB.Checked = true;
            fromFriendsRB.Checked = true;
            lovedSchoolRB.Checked = true;
            goodRelationWithStudentsRB.Checked = true;
            notCompehendRB.Checked = true;
            mediumStudentRB.Checked = true;
            deactivateTextBox(otherSourceTextBox);
            deactivateTextBox(hatedSchoolTextBox);
            deactivateTextBox(badRelationWithStudentsReasonTextBox);
            deactivateTextBox(otherReaonsBadTeacherRelationTextBox);

            // 7s ==>  Teen Analysis Initialization Second Page
            prayerAlwaysRB.Checked = true;
            quranAlwaysRB.Checked = true;
            fastingAlwaysRB.Checked = true;
            motivationsTextBox.Text = "خذ بعين الاعتبار موقف الحدث من الجنحة, هل يتحمل المسؤولية وتصرفاته وهل يتفهم خطورة سلوكه وتأثير ذلك على الضحية؟\nالنظر في أي دافع وأي تغيير وأي طموحات للمستقبل.\nتحديد أي عوامل إيجابية أو وقائية.";
            familyTextBox.Text = "خذ بعين الاعتبار موقف الأسرة من الحد بعد الجنحة.\nخذ بعين الاعتبار المنطقة السكنية للحدث.";
            convictedFamilyMemberGB.Enabled = false;
            dadConvictedRB.Checked = true;
            drugAbuseFamilyMemberGB.Enabled = false;
            dadDrugAbuseRB.Checked = true;
            emailPurposeGB.Enabled = false;
            deactivateTextBox(whichCountriesTextBox);
            deactivateTextBox(familyMemberConvictedTextBox);
            joinChatRoomsRB.Checked = true;
            socialSitesRB.Checked = true;
            familyZeroEvaluationRB.Checked = true;
            motivationsZeroEvaluationRB.Checked = true;



            // 8s ==>  Teen Analysis Initialization Second Page
            individualMeetingRB.Checked = true;


            // 9s ==>  Meetings Initialization Page
            meetingTitleTextBox.Visible = true;
            meetingTitleComboBox.Visible = false;
            newMeetingRB.Checked = true;
        }

        void customizeSidePanel()
        {

            generalInformationPanel.Visible = false;
            characterAnalysisPanel.Visible = false;
            enviromentAnalysisPanel.Visible = false;
            teensPanel.Visible = false;
        }
        void hideSubMenus()
        {
            if (generalInformationPanel.Visible == true)
                generalInformationPanel.Visible = false;
            if (characterAnalysisPanel.Visible == true)
                characterAnalysisPanel.Visible = false;
            if (characterAnalysisPanel.Visible == true)
                characterAnalysisPanel.Visible = false;
            if (enviromentAnalysisPanel.Visible == true)
                enviromentAnalysisPanel.Visible = false;
            if (teensPanel.Visible == true)
                teensPanel.Visible = false;
        }
        void showSubMenus(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubMenus();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            deleteRecordButton.ImageIndex = 1;
            deleteCaseRB.Checked = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            deleteRecordButton.ImageIndex = 0;
            if (ToggleConditionButton.IsOn)
            {
                newCaseRB.Checked = true;
            }
            else
            {
                editCaseRB.Checked = true;
            }
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFinalStep();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            ClearAll();
            clearingNinthPage();
        }

        void saveFinalStep()
        {
            if (tabControl1.SelectedTab != TabPage4_0)
            {

                if (newCaseRB.Checked)
                {
                    if (SaveNewPatient())
                    {
                        MessageBox.Show($"بنجاااح {SSNTextBox.Text} تم حفظ ملف الرقم الموحد", "عاااش", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearAll();
                    }
                }
                else if (editCaseRB.Checked)
                {
                    if (availableSSN())
                    {
                        string updateMessage = $"{SSNTextBox.Text} سيتم تعديل ملف الرقم الموحد ";

                        DialogResult dialogResult = MessageBox.Show(updateMessage, "تأكيد التعديل", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (validatePatient())
                            {
                                deleteSSN(SSNTextBox.Text);
                                SaveNewPatient();
                                MessageBox.Show($"بنجاااح {SSNTextBox.Text} تم تعديل ملف الرقم الموحد", "عاااش", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearAll();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("الرقم الموحد غير موجود بقواعد البيانات الرجاء التأكد من صحة الإدخال أو اختيار حالة جديدة بدلًا من تعديل الحالة", "حدث خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else if (deleteCaseRB.Checked)
                {
                    deleteSSNButton();
                }
                else if (modifySSNRB.Checked)
                {
                    MessageBox.Show($"يجب اتبع الإرشادات في تعديل الرقم الموحد لخطر العملية", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (tabControl1.SelectedTab == TabPage4_0)
            {
                if (newMeetingRB.Checked)
                {
                    if (SaveNewMeeting())
                    {
                        MessageBox.Show($"بنجاااح {meetingTitleTextBox.Text} تم حفظ المقابلة بعنوان", "عاااش", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearingNinthPage();
                    }
                }
                else if (editMeetingRB.Checked)
                {
                    string updateMessage = $"{meetingTitleComboBox.Text} سيتم تعديل ملف المقابلة بعنوان ";

                    DialogResult dialogResult = MessageBox.Show(updateMessage, "تأكيد التعديل", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (eigthPageTextBoxValidation())
                        {
                            deleteMeeting(meetingTitleComboBox.Text);
                            if (SaveNewMeeting())
                            {
                                MessageBox.Show($"بنجاااح {meetingTitleComboBox.Text} تم تعديل ملف المقابلة بعنوان", "عاااش", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearingNinthPage();
                            }
                        }
                    }
                }
                else if (deleteMeetingRB.Checked)
                {
                    deleteMeetingButton_();
                }
                else if (editMeetingTitle.Checked)
                {

                }

            }
        }

        private void deleteRecordButton_Click(object sender, EventArgs e)
        {
            deleteSSNButton();
        }

        void deleteSSNButton()
        {
            if (deleteCaseRB.Checked)
            {
                if (availableSSN())
                {
                    string updateMessage = $"{SSNTextBox.Text} سيتم حذف ملف الرقم الموحد ";

                    DialogResult dialogResult = MessageBox.Show(updateMessage, "تأكيد الحذف", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (validatePatient())
                        {
                            deleteSSN(SSNTextBox.Text);
                            MessageBox.Show($"بنجاح {SSNTextBox.Text} تم حذف ملف الرقم الموحد", "ليه كدا؟", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearAll();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                else
                {
                    MessageBox.Show("الرقم الموحد غير موجود بقواعد البيانات الرجاء التأكد من صحة الإدخال وإعادة المحاولة", "حدث خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("يرجى اختيار حذف الحالة من وصف حالة البيانات لإكمال العملية.", "إجراء احترازي", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        void deleteMeetingButton_()
        {
            if (deleteMeetingRB.Checked)
            {
                SqlConnection con;
                con = new SqlConnection(constring);

                con.Open();
                string name = new SqlCommand("IF EXISTS(Select 1 from periodicMeetings where meetingTitle=N'" + meetingTitleComboBox.Text + "' ) BEGIN Select 1 from periodicMeetings where meetingTitle=N'" + meetingTitleComboBox.Text + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
                if (name == "1")
                {
                    string updateMessage = $"{meetingTitleComboBox.Text} سيتم حذف ملف المقابلة بعنوان ";

                    DialogResult dialogResult = MessageBox.Show(updateMessage, "تأكيد الحذف", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        deleteMeeting(meetingTitleComboBox.Text);
                        MessageBox.Show($"بنجاح {meetingTitleComboBox.Text} تم حذف ملف المقابلة بعنوان", "ليه كدا؟", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearingNinthPage();
                    }
                }
                else
                {
                    MessageBox.Show("عنوان المقابلة غير موجود بقواعد البيانات الرجاء التأكد من صحة الإدخال وإعادة المحاولة", "حدث خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("يرجى اختيار حذف مقابلة سابقة من وصف حالة البيانات لإكمال العملية.", "إجراء احترازي", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void deleteSSN(string ssnText)
        {
            string Query;
            SqlConnection conDataBase;
            SqlDataAdapter adapter;
            SqlCommand command;

            Query = "DELETE FROM patientInfo where ssn =N'" + ssnText + "'";

            conDataBase = new SqlConnection(constring);
            adapter = new SqlDataAdapter();
            command = new SqlCommand(Query, conDataBase);
            conDataBase.Open();
            adapter.InsertCommand = new SqlCommand(Query, conDataBase);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            conDataBase.Close();
        }

        void deleteMeeting(string MeetingTitle)
        {
            string Query;
            SqlConnection conDataBase;
            SqlDataAdapter adapter;
            SqlCommand command;

            Query = "DELETE FROM periodicMeetings where meetingTitle =N'" + meetingTitleComboBox.Text + "'";

            conDataBase = new SqlConnection(constring);
            adapter = new SqlDataAdapter();
            command = new SqlCommand(Query, conDataBase);
            conDataBase.Open();
            adapter.InsertCommand = new SqlCommand(Query, conDataBase);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            conDataBase.Close();
        }

        private void newCaseRB_CheckedChanged(object sender, EventArgs e)
        {
            ToggleConditionButton.IsOn = true;
        }

        private void editCaseRB_CheckedChanged(object sender, EventArgs e)
        {
            ToggleConditionButton.IsOn = false;
        }

        private void deleteCaseRB_CheckedChanged(object sender, EventArgs e)
        {
            ToggleConditionButton.IsOn = false;
        }

        private void modifySSNRB_CheckedChanged(object sender, EventArgs e)
        {
            if (modifySSNRB.Checked)
            {

                editSSNPanel.Visible = true;
                oldSSN.Text = SSNTextBox.Text;
                newSSN.Text = "";
                ToggleConditionButton.IsOn = false;
                MessageBox.Show("ظهر مربع على يمين الشاشة .. يرجى إدخال الرقم المراد تغييره والرقم الجديد والضغط على حفظ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                editSSNPanel.Visible = false;
            }
        }

        private void tabPage6_Leave(object sender, EventArgs e)
        {
            if ((singleRB.Checked && adultRB.Checked) || (!adultRB.Checked))
            {
                haveSingleRoomGB.Enabled = true;
            }
            else
            {
                haveSingleRoomGB.Enabled = false;
            }
        }

        ///
        ///

        //!!!!!!!!!!!!!! =======> General Information Tab Control <======= !!!!!!!!!!!!!!

        ///
        //

        //====> Activation and Deactivation of the Conrollers <====
        void deactivateTextBox(TextBox t)
        {
            t.BackColor = Color.FromArgb(64, 64, 64);
            t.Enabled = false;
        }
        void reactivateTextBox(TextBox t)
        {
            t.BackColor = Color.FromArgb(41, 44, 51);
            t.Enabled = true;
        }
        void deactivateComboBox(ComboBox c)
        {
            c.BackColor = Color.FromArgb(64, 64, 64);
            c.Enabled = false;
        }
        void reactivateComboBox(ComboBox c)
        {
            c.BackColor = Color.FromArgb(41, 44, 51);
            c.Enabled = true;
        }

        void deactivateOthersTextBoxAndLabelGroup(TextBox t, Label l)
        {
            deactivateTextBox(t);
            l.Enabled = false;
        }

        void reactivateOthersTextBoxAndLabelGroup(TextBox t, Label l)
        {
            reactivateTextBox(t);
            l.Enabled = true;
        }

        //====> TextBox Watermark Signatures Functions <====
        void enterTextBox(TextBox t, string str)
        {
            if (t.Text == str)
            {
                t.Text = "";

                t.ForeColor = Color.White;
                t.TextAlign = HorizontalAlignment.Left;
            }
        }
        void leaveTextBox(TextBox t, string str)
        {
            if (t.Text == "")
            {
                t.Text = str;

                t.ForeColor = Color.Gray;
                t.TextAlign = HorizontalAlignment.Center;
            }
        }
        void textBoxFocusOn(TextBox t)
        {

            t.ForeColor = Color.White;
            t.TextAlign = HorizontalAlignment.Left;

        }
        void textBoxFocusOff(TextBox t)
        {

            t.ForeColor = Color.Gray;
            t.TextAlign = HorizontalAlignment.Center;

        }


        // Adjusting the app to the user choice on radio buttons

        // ==////==> SEX <==////==
        private void maleRB_CheckedChanged(object sender, EventArgs e)
        {
            if (maleRB.Checked)
            {
                patientSex = "ذكر";
                adultRB.Text = "بالغ";
                teenRB.Text = "مراهق";
                singleRB.Text = "أعزب";
                marriedRB.Text = "متزوج";
                separatedRB.Text = "منفصل";
                divorcedRB.Text = "مطلق";
                msSingleRB.Text = "أعزب";
                msMarriedRB.Text = "متزوج";
                msSeperatedRB.Text = "منفصل";
                msDivorcedRB.Text = "مطلق";
                AtWifeRB.Text = "الزوجة";
                AtSingleRB.Text = "وحده";
                label9.Text = "حاصل على";
                EDwifeGroupBox.Text = "الزوجة";
                forFemaleMarriageGB.Enabled = false;
            }
            else
            {
                patientSex = "أنثى";
                adultRB.Text = "بالغة";
                teenRB.Text = "قاصر";
                singleRB.Text = "عزباء";
                marriedRB.Text = "متزوجة";
                separatedRB.Text = "منفصلة";
                divorcedRB.Text = "مطلقة";
                msSingleRB.Text = "عزباء";
                msMarriedRB.Text = "متزوجة";
                msSeperatedRB.Text = "منفصلة";
                msDivorcedRB.Text = "مطلقة";
                AtWifeRB.Text = "الزوج";
                AtSingleRB.Text = "وحدها";
                label9.Text = "حاصلة على";
                EDwifeGroupBox.Text = "الزوج";
                forFemaleMarriageGB.Enabled = true;
            }
        }

        // ==////==> TYPE <==////==

        void transferredFrom()
        {
            if (adultRB.Checked && employeeRB.Checked)
            {
                convertedFromGeneralDoctorRB.Text = "موارد بشرية";
                convertedFromSpecialisedClinicRB.Text = "جهة إدارية";
                convertedFromSocialSupportRB.Text = "لجنة طبية";
                convertedFromAbuDhabiCourtsRB.Text = "جهة خارجية";
            }
            else if ((adultRB.Checked && residentRB.Checked) || (!adultRB.Checked))
            {
                convertedFromGeneralDoctorRB.Text = "طبيب عام";
                convertedFromSpecialisedClinicRB.Text = "عيادة تخصصية";
                convertedFromSocialSupportRB.Text = "الدعم الاجتماعي";
                convertedFromAbuDhabiCourtsRB.Text = "محاكم أبوظبي";
            }
        }

        private void adultRB_CheckedChanged(object sender, EventArgs e)
        {
            transferredFrom();
            if (adultRB.Checked)
            {
                patientType = (groupBox8.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;

                maritalStatusGB.Enabled = true;
                patientMaritalStatusGB.Enabled = true;
                maritalStausReasonsTextBox.Text = "أسباب الحالة الاجتماعية";
                reactivateTextBox(maritalStausReasonsTextBox);
                EDwifeGroupBox.Enabled = true;
                AtSonRB.Enabled = true;
                teensButton.Visible = false;
                //   professionalRelationshipsGB.Enabled = true;
                //   employersGB.Enabled = true;
                ownedRB.Checked = true;
                if (singleRB.Checked)
                {
                    haveSingleRoomGB.Enabled = true;
                }
                else
                {
                    haveSingleRoomGB.Enabled = false;
                }
            }
            else
            {
                patientType = (groupBox8.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                maritalStatusGB.Enabled = false;
                patientMaritalStatusGB.Enabled = false;
                deactivateTextBox(maritalStausReasonsTextBox);
                maritalStausReasonsTextBox.Text = "أعزب لأنه حدث/قاصر";
                msSingleRB.Checked = true;
                singleRB.Checked = true;
                EDwifeGroupBox.Enabled = false;
                AtSonRB.Enabled = false;
                teensButton.Visible = true;
                // professionalRelationshipsGB.Enabled = false;
                // employersGB.Enabled = false;
                familyHomeRB.Checked = true;
                haveSingleRoomGB.Enabled = true;
            }
        }

        private void residentRB_CheckedChanged(object sender, EventArgs e)
        {
            transferredFrom();
        }
        // ==////==> MARITIAL STATUS <==////==

        // ===== SINGLE WOLF =====
        private void singleRB_CheckedChanged(object sender, EventArgs e)
        {
            if (singleRB.Checked)
            {
                patientStatus = singleRB.Text;
                EDwifeGroupBox.Enabled = false;
                AtWifeRB.Enabled = false;
                AtSonRB.Enabled = false;
                InCaseOfMarriageGB.Enabled = false;
            }
            else
            {
                EDwifeGroupBox.Enabled = true;
                AtWifeRB.Enabled = true;
                AtSonRB.Enabled = true;
                InCaseOfMarriageGB.Enabled = true;

            }
        }
        private void msSingleRB_CheckedChanged(object sender, EventArgs e)
        {
            if (msSingleRB.Checked)
            {
                patientStatus = msSingleRB.Text;
                EDwifeGroupBox.Enabled = false;
                AtWifeRB.Enabled = false;
                AtSonRB.Enabled = false;
                InCaseOfMarriageGB.Enabled = false;
            }
            else
            {
                EDwifeGroupBox.Enabled = true;
                AtWifeRB.Enabled = true;
                AtSonRB.Enabled = true;
                InCaseOfMarriageGB.Enabled = true;

            }
        }

        private void marriedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (marriedRB.Checked)
            {
                patientStatus = marriedRB.Text;
            }
        }

        private void separatedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (separatedRB.Checked)
            {
                patientStatus = separatedRB.Text;
            }
        }

        private void divorcedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (divorcedRB.Checked)
            {
                patientStatus = divorcedRB.Text;
            }
        }



        private void msMarriedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (msMarriedRB.Checked)
            {
                patientStatus = msMarriedRB.Text;
            }
        }
        private void msSeperatedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (msSeperatedRB.Checked)
            {
                patientStatus = msSeperatedRB.Text;
            }
        }

        private void msDivorcedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (msDivorcedRB.Checked)
            {
                patientStatus = msDivorcedRB.Text;
            }
        }


        private void InitialPageTabPage_Enter(object sender, EventArgs e)
        {
            if (patientStatus == "أعزب" || patientStatus == "عزباء")
            {
                singleRB.Checked = true;
                msSingleRB.Checked = true;
            }
            else if (patientStatus == "متزوج" || patientStatus == "متزوجة")
            {
                marriedRB.Checked = true;
                msMarriedRB.Checked = true;
            }
            else if (patientStatus == "منفصل" || patientStatus == "منفصلة")
            {
                separatedRB.Checked = true;
                msSeperatedRB.Checked = true;
            }
            else if (patientStatus == "مطلق" || patientStatus == "مطلقة")
            {
                divorcedRB.Checked = true;
                msDivorcedRB.Checked = true;
            }
        }

        private void InitialPageTabPage_Leave(object sender, EventArgs e)
        {
            if (patientStatus == "أعزب" || patientStatus == "عزباء")
            {
                singleRB.Checked = true;
                msSingleRB.Checked = true;
            }
            else if (patientStatus == "متزوج" || patientStatus == "متزوجة")
            {
                marriedRB.Checked = true;
                msMarriedRB.Checked = true;
            }
            else if (patientStatus == "منفصل" || patientStatus == "منفصلة")
            {
                separatedRB.Checked = true;
                msSeperatedRB.Checked = true;
            }
            else if (patientStatus == "مطلق" || patientStatus == "مطلقة")
            {
                divorcedRB.Checked = true;
                msDivorcedRB.Checked = true;
            }
        }

        //====> Left School CheckBox to control the reasons group Box <====

        private void leftSchoolCB_CheckedChanged(object sender, EventArgs e)
        {
            if (leftSchoolCB.Checked)
            {
                leftSchoolGroupBox.Enabled = true;
            }
            else
            {
                leftSchoolGroupBox.Enabled = false;
            }
        }

        private void anyInjuriesCB_CheckedChanged(object sender, EventArgs e)
        {
            if (anyInjuriesCB.Checked)
            {
                accidentsGB.Enabled = true;
            }
            else
            {
                accidentsGB.Enabled = false;
            }
        }

        private void enteredInstituteCB_CheckedChanged(object sender, EventArgs e)
        {
            if (enteredInstituteCB.Checked)
            {
                wnteredInstituteGB.Enabled = true;
            }
            else
            {
                wnteredInstituteGB.Enabled = false;
            }
        }


        //====> Others textboxes activation Functions <====


        private void AtOthersRB_CheckedChanged(object sender, EventArgs e)
        {
            if (AtOthersRB.Checked)
            {

                reactivateOthersTextBoxAndLabelGroup(AtterndeOthersTextBox, label11);
            }
            else
            {
                deactivateOthersTextBoxAndLabelGroup(AtterndeOthersTextBox, label11);

            }
        }

        private void LSotheRB_CheckedChanged(object sender, EventArgs e)
        {
            if (LSotheRB.Checked)
            {
                reactivateOthersTextBoxAndLabelGroup(LSothersTextBox, label12);
            }
            else
            {
                deactivateOthersTextBoxAndLabelGroup(LSothersTextBox, label12);

            }
        }

        private void convertedFromOthersRB_CheckedChanged(object sender, EventArgs e)
        {
            if (convertedFromOthersRB.Checked)
            {
                reactivateTextBox(convertedFromOthersTextBox);
            }
            else
            {
                deactivateTextBox(convertedFromOthersTextBox);
            }
        }

        private void purposeOtherRB_CheckedChanged(object sender, EventArgs e)
        {
            if (purposeOtherRB.Checked)
            {
                reactivateTextBox(purposeOtherTextBox);
            }
            else
            {
                deactivateTextBox(purposeOtherTextBox);
            }
        }



        //====> Watermarks of the textboxes In 2S <====


        private void miserableJobReasonTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(miserableJobReasonTextBox, "التفاصيل");
        }

        private void miserableJobReasonTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(miserableJobReasonTextBox, "التفاصيل");
        }

        private void shareRoomWithTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(shareRoomWithTextBox, "مع من يشارك غرفته؟");
        }

        private void shareRoomWithTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(shareRoomWithTextBox, "مع من يشارك غرفته؟");
        }

        //////////////////////////////////////////////////
        //====> 1s Functionality and DB Connection <====//
        //////////////////////////////////////////////////


        bool firstPageTextBoxValidation()
        {
            string errorMessage = "";
            int counter = 0;

            if (String.IsNullOrEmpty(SSNTextBox.Text))
            {
                errorMessage += "الرقم الموحد, ";
                counter++;
            }
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                errorMessage += "الاسم, ";
                counter++;
            }
            if (String.IsNullOrEmpty(ageTextBox.Text))
            {
                errorMessage += "العمر, ";
                counter++;
            }
            if (String.IsNullOrEmpty(nationalityTextBox.Text))
            {
                errorMessage += "الجنسية, ";
                counter++;
            }
            if (String.IsNullOrEmpty(residencePlaceTextBox.Text))
            {
                errorMessage += "مكان الإقامة, ";
                counter++;
            }
            if (String.IsNullOrEmpty(phoneNumberTextBox.Text))
            {
                errorMessage += "رقم الهاتف, ";
                counter++;
            }
            if (String.IsNullOrEmpty(caseTextBox.Text))
            {
                errorMessage += "القضية, ";
                counter++;
            }
            if (String.IsNullOrEmpty(judgementTextBox.Text))
            {
                errorMessage += "الحكم, ";
                counter++;
            }
            if (String.IsNullOrEmpty(heightTextBox.Text))
            {
                errorMessage += "الطول, ";
                counter++;
            }
            if (String.IsNullOrEmpty(weightTextBox.Text))
            {
                errorMessage += "الوزن, ";
                counter++;
            }
            if (String.IsNullOrEmpty(waistTextBox.Text))
            {
                errorMessage += "الخصر, ";
                counter++;
            }
            if (String.IsNullOrEmpty(walkingTexBox.Text))
            {
                errorMessage += "المشي, ";
                counter++;
            }
            if (String.IsNullOrEmpty(musclesTextBox.Text))
            {
                errorMessage += "القوى العضلية, ";
                counter++;
            }

            if (enteredInstituteCB.Checked)
            {
                if (enteredInstituteDGV.Rows.Count - 1 == 0)
                {
                    errorMessage += "تفاصيل دخول المؤسسة سابقًا, ";
                    counter++;
                }
            }

            if (errorMessage != "")
            {
                if (counter <= 5)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "أكمل الصفات الشخصية في المعلومات الأساسية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "أكمل الصفات الشخصية في المعلومات الأساسية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;

        }

        bool firstPageSecondHalfValidation()
        {
            string errorMessage = "";
            int counter = 0;



            if (AtOthersRB.Checked)
            {
                if (String.IsNullOrEmpty(AtterndeOthersTextBox.Text))
                {
                    errorMessage += "حضر برفقة من؟, ";
                    counter++;
                }
            }
            if (String.IsNullOrEmpty(currentComplainTextBox.Text))
            {
                errorMessage += "الشكوى الحالية, ";
                counter++;
            }

            if (String.IsNullOrEmpty(educationalLevelTextBox.Text))
            {
                errorMessage += " المريض حاصل على, ";
                counter++;
            }

            if (String.IsNullOrEmpty(graduationAgeTextBox.Text))
            {
                errorMessage += "عمر تخرج المريض, ";
                counter++;
            }

            if (LSotheRB.Checked)
            {
                if (String.IsNullOrEmpty(LSothersTextBox.Text))
                {
                    errorMessage += "أسباب ترك الدراسة, ";
                    counter++;
                }
            }
            if (!(singleRB.Checked || teenRB.Checked))
            {
                if (String.IsNullOrEmpty(graduationAgeTextBox.Text))
                {
                    errorMessage += "زوج المريض حاصل على, ";
                    counter++;
                }

                if (String.IsNullOrEmpty(graduationAgeTextBox.Text))
                {
                    errorMessage += "عمر تخرج زوج المريض, ";
                    counter++;
                }
            }


            if (convertedFromOthersRB.Checked)
            {

                if (String.IsNullOrEmpty(convertedFromOthersTextBox.Text))
                {
                    errorMessage += "التحويل من؟, ";
                    counter++;
                }
            }

            if (purposeOtherRB.Checked)
            {

                if (String.IsNullOrEmpty(purposeOtherTextBox.Text))
                {
                    errorMessage += "غرض المقابلة, ";
                    counter++;
                }
            }
            if (anyInjuriesCB.Checked)
            {
                if (injuriesDGV.Rows.Count - 1 == 0)
                {
                    errorMessage += "تفاصيل الحوادث والإصابات, ";
                    counter++;
                }
            }



            if (errorMessage != "")
            {
                if (counter <= 5)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "أكمل المعلومات العامة في المعلومات الأساسية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "أكمل المعلومات العامة في المعلومات الأساسية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool previousInstitutionHistoryDGVValidatin_firstPAge()
        {
            string errorMessage = "";
            int counter = 0;


            if (String.IsNullOrEmpty(enteredInstituteYearTextBox.Text))
            {
                errorMessage += "السنة, ";
                counter++;
            }


            if (String.IsNullOrEmpty(enteredInstituteCaseTextBox.Text))
            {
                errorMessage += "القضية, ";
                counter++;
            }


            if (String.IsNullOrEmpty(enteredInstituteJudgementTextBox.Text))
            {
                errorMessage += "الحكم, ";
                counter++;
            }


            if (String.IsNullOrEmpty(enteredInstituteAgeTextBox.Text))
            {
                errorMessage += "عمر الدخول, ";
                counter++;
            }


            if (String.IsNullOrEmpty(enteredInstituteNotesTextBox.Text))
            {
                errorMessage += "ملاحظات, ";
                counter++;
            }




            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool previousInjuriesHistoryDGVValidatin_firstPAge()
        {
            string errorMessage = "";
            int counter = 0;


            if (String.IsNullOrEmpty(yearInjuredCB.Text))
            {
                errorMessage += "السنة, ";
                counter++;
            }

            if (String.IsNullOrEmpty(injuryDetailsTextBox.Text))
            {
                errorMessage += "التفاصيل, ";
                counter++;
            }


            if (String.IsNullOrEmpty(fracturesTextBox.Text))
            {
                errorMessage += "الإصابات والكسور, ";
                counter++;
            }


            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool secondPageTextBoxValidation()
        {
            string errorMessage = "";
            int counter = 0;

            if (othersTraitsCB.Checked)
            {
                if (String.IsNullOrEmpty(behavioralTraitsOthersTextBox.Text))
                {
                    errorMessage += "السمات السلوكية الأخرى, ";
                    counter++;
                }
            }
            if (yesAIRB.Checked)
            {
                if (String.IsNullOrEmpty(anotherIncomeTextBox.Text))
                {
                    errorMessage += "مصادر الدخل الأخرى, ";
                    counter++;
                }
            }

            if (otherHomeRB.Checked)
            {
                if (String.IsNullOrEmpty(otherHomeTextBox.Text))
                {
                    errorMessage += "ملكية السكن, ";
                    counter++;
                }
            }

            if (yesFPRB.Checked)
            {
                if (String.IsNullOrEmpty(financialProblemsTextBox.Text))
                {
                    errorMessage += "المشكلات المالية, ";
                    counter++;
                }
            }

            int parsedValue;
            if (String.IsNullOrEmpty(bedroomsCountTextBox.Text))
            {
                errorMessage += "عدد الغرف بالمنزل, ";
                counter++;
            }
            else if (!int.TryParse(bedroomsCountTextBox.Text, out parsedValue))
            {
                errorMessage += "عدد الغرف بالأرقام ليس بالحروف, ";
                counter++;
            }

            if (singleRB.Checked || teenRB.Checked)
            {
                if (noLoneRoomRB.Checked)
                {
                    if (shareRoomWithTextBox.Text == "مع من يشارك غرفته؟")
                    {
                        errorMessage += "مع من يشارك غرفته؟, ";
                        counter++;
                    }
                }
            }

            if (employeeRB.Checked)
            {
                if (workDGV.Rows.Count - 1 == 0)
                {
                    errorMessage += "جهة العمل, ";
                    counter++;
                }
            }


            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "أكمل الصفات الاجتماعية في تحليل الشخصية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "أكمل الصفات الاجتماعية في تحليل الشخصية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool employerDGVValidation_secondPage()
        {
            string errorMessage = "";
            int counter = 0;


            if (String.IsNullOrEmpty(entityWorkTextBox.Text))
            {
                errorMessage += "جهة العمل, ";
                counter++;
            }

            if (workingNatureOthersRB.Checked)
            {
                if (String.IsNullOrEmpty(workingNatureOthersTextBox.Text))
                {
                    errorMessage += "طبيعة العمل, ";
                    counter++;
                }
            }

            if (miserableJobCB.Checked)
            {
                if (miserableJobReasonTextBox.Text == "التفاصيل")
                {
                    errorMessage += "أسباب عدم الرضا عن العمل, ";
                    counter++;
                }

            }

            if (String.IsNullOrEmpty(workStartAgeTextBox.Text))
            {
                errorMessage += "عمر بداية العمل, ";
                counter++;
            }





            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool thirdPageTextBoxValidation()
        {
            string errorMessage = "";
            int counter = 0;

            if (!noAttemptsRB.Checked)
            {
                if (suicideWayTextBox.Text == "الطريقة التي فكر فيها")
                {
                    errorMessage += "طريقة الانتحار التي فكر بها, ";
                    counter++;
                }
                if (suicideDetailsTextBox.Text == "التفاصيل")
                {
                    errorMessage += "تفاصيل محاولة الانتحار, ";
                    counter++;
                }
                if (suicideNotesTextBox.Text == "ملاحظات")
                {
                    errorMessage += "ملاحظات محاولة الانتحار, ";
                    counter++;
                }
            }

            if (warehouseCB.Checked)
            {
                if (warehouseCountsTextBox.Text == "عدد مرات دخوله")
                {
                    errorMessage += "عدد مرات دخول العنبر, ";
                    counter++;
                }
                if (warehouseDetailsTextBox.Text == "التفاصيل")
                {
                    errorMessage += "تفاصيل دخول العنبر, ";
                    counter++;
                }
            }

            if (blackoutCB.Checked)
            {
                if (blackoutCountsTextBox.Text == "عدد مرات إصابته")
                {
                    errorMessage += "عدد مرات فقدان الوعي, ";
                    counter++;
                }
                if (blackoutDetailsTextBox.Text == "التفاصيل")
                {
                    errorMessage += "تفاصيل فقدان الوعي, ";
                    counter++;
                }
            }

            if (!noUseRB.Checked)
            {
                if (startingAgeTextBox.Text == "سن بداية التعاطي")
                {
                    errorMessage += "سن بداية التعاطي, ";
                    counter++;
                }
                if (TypesUsedTextBox.Text == "الأنواع التي يتعاطيها")
                {
                    errorMessage += "الأنواع التي يتعاطيها, ";
                    counter++;
                }
                if ((totalDurationTextBox.Text == "المدة الإجمالية بالشهور"))
                {
                    errorMessage += "مدة التعاطي, ";
                    counter++;
                }
                if (drugUsedDetailsTextBox.Text == "التفاصيل")
                {
                    errorMessage += "تفاصيل التعاطي, ";
                    counter++;
                }
            }

            if (previousTreatmentCB.Checked)
            {
                if (treatmentPlacesDGV.Rows.Count - 1 == 0)
                {
                    errorMessage += "تفاصيل العلاج سابقًا, ";
                    counter++;
                }
            }

            if (familyIllnessCB.Checked)
            {
                if (familyIllnessDetailsTextBox.Text == "التفاصيل")
                {
                    errorMessage += "تفاصيل التاريخ المرضي للعائلة, ";
                    counter++;
                }
            }

            if (previousPatientHistoryNotesTextBox.Text == "ملاحظات التاريخ المرضي السابق")
            {
                errorMessage += "أضف ملاحظات التاريخ المرضي السابق للمريض, ";
                counter++;
            }

            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "أكمل المشكلات المرضية في تحليل الشخصية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "أكمل المشكلات المرضية في تحليل الشخصية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool previousTreatmentDGVVAlidation_thirdPage()
        {
            string errorMessage = "";
            int counter = 0;


            if (hospitalTreatmentTextBox.Text == "المستشفى")
            {
                errorMessage += "المستشفى, ";
                counter++;
            }
            if (doctorTreatmentTextBox.Text == "الطبيب المعالج")
            {
                errorMessage += "الطبيب المعالج, ";
                counter++;
            }
            if (fileNumberTreatmentTextBox.Text == "رقم الملف الطبي")
            {
                errorMessage += "رقم الملف الطبي, ";
                counter++;
            }



            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        //4s Validations
        bool patientMarriageDGVValidation()
        {
            string errorMessage = "";
            int counter = 0;

            if (marriagePatientOrderTextBox.Text == "ترتيب الزواج بين زيجاته الأخرى")
            {
                errorMessage += "ترتيب الزواج بين زيجاته الأخرى, ";
                counter++;
            }

            if (yesRelativeRB.Checked)
            {
                if (String.IsNullOrEmpty(patientMarriageSideComboBox.Text))
                {
                    errorMessage += "جهة القرابة, ";
                    counter++;
                }
            }


            if (boysCountPatientsTextBox.Text == "عدد الأبناء")
            {
                errorMessage += "عدد الأبناء, ";
                counter++;
            }
            if (girlsCountPatientsTextBox.Text == "عدد البنات")
            {
                errorMessage += "عدد البنات, ";
                counter++;
            }
            if (totalSonsTextBox.Text == "العدد")
            {
                errorMessage += "العدد, ";
                counter++;
            }

            if (husbandNationalityTextBox.Text == "جنسية الزوج")
            {
                errorMessage += "جنسية الزوج, ";
                counter++;
            }

            if (marriageDurationTextBox.Text == "مدة الزواج")
            {
                errorMessage += "مدة الزواج, ";
                counter++;
            }

            int parsedValue;
            if (!(int.TryParse(totalPatientMarriageTextBox.Text, out parsedValue)))
            {
                errorMessage += "عدد الزيجات بالأرقام ليس بالحروف, ";
                counter++;
            }

            if (!(int.TryParse(marriageDurationTextBox.Text, out parsedValue)))
            {
                errorMessage += "مدة الزواج بالأرقام ليس بالحروف, ";
                counter++;
            }

            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool fourthPageTextBoxValidation()
        {

            string errorMessage = "";
            int counter = 0;

            if (maritalStausReasonsTextBox.Text == "أسباب الحالة الاجتماعية")
            {
                errorMessage += "أسباب الحالة الاجتماعية, ";
                counter++;
            }

            if (!msSingleRB.Checked)
            {
                if (patientMaritalStatusDGV.Rows.Count - 1 == 0)
                {
                    errorMessage += "أضف تفاصيل الزيجات, ";
                    counter++;
                }

                if (totalPatientMarriageTextBox.Text == "عدد مرات الزواج الكلية")
                {
                    errorMessage += "عدد مرات الزواج الكلية, ";
                    counter++;
                }

                if (!maleRB.Checked)
                {
                    if (ageAtMarriageFemaleTextBox.Text == "العمر عند الزواج")
                    {
                        errorMessage += "العمر عند الزواج, ";
                        counter++;
                    }
                    if (ageAtProcreationFemaleTextBox.Text == "العمر عند الإنجاب")
                    {
                        errorMessage += "العمر عند الإنجاب, ";
                        counter++;
                    }
                }

                int parsedValue;
                if (int.TryParse(totalPatientMarriageTextBox.Text, out parsedValue))
                {
                    if ((patientMaritalStatusDGV.Rows.Count - 1) != (parsedValue))
                    {
                        errorMessage += "تفاصيل كل الزيجات كما هو العدد المدخل, ";
                        counter++;
                    }
                }
                else
                {
                    errorMessage += "عدد الزيجات بالأرقام ليس بالحروف, ";
                    counter++;
                }
            }

            if (brothersCountTextBox.Text == "الأشقاء من جهة الأب والأم فقط")
            {
                errorMessage += "الأشقاء من جهة الأب والأم فقط, ";
                counter++;
            }

            if (patientOrderTextBox.Text == "ترتيب المفحوص بين أشقائه وشقيقاته")
            {
                errorMessage += "ترتيب المفحوص بين أشقائه وشقيقاته, ";
                counter++;
            }

            if (sistersCoutTextBox.Text == "الشقيقات من جهة الأب والأم فقط")
            {
                errorMessage += "الشقيقات من جهة الأب والأم فقط, ";
                counter++;
            }

            if (nearestFamilyMemberTextBox.Text == "أقرب شخص للمفحوص من العائلة")
            {
                errorMessage += "أقرب شخص للمفحوص من العائلة, ";
                counter++;
            }

            if (totalMembersTextBox.Text == "عدد الأشقاء والشقيقات الكلي")
            {
                errorMessage += "عدد الأشقاء والشقيقات الكلي, ";
                counter++;
            }

            if (responsibleForCoutTextBox.Text == "عدد الأفراد المسؤول عنهم")
            {
                errorMessage += "عدد الأفراد المسؤول عنهم, ";
                counter++;
            }

            if (responsibleForDescriptionTextBox.Text == "أعمار ووصف الأفراد المسؤول عنهم")
            {
                errorMessage += "أعمار ووصف الأفراد المسؤول عنهم, ";
                counter++;
            }

            if (otherResponsibilitiesRB.Checked)
            {
                if (otherResponsibilitiesTextBox.Text == "آخرين")
                {
                    errorMessage += "مسؤوليات الشخص اتجاه من؟ أكمل الآخرين, ";
                    counter++;
                }

            }

            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "أكمل الحالة الاجتماعية في تحليل البيئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "أكمل الحالة الاجتماعية في تحليل البيئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        //5s Validations
        bool fatherMarriageDGVValidation()
        {
            string errorMessage = "";
            int counter = 0;

            if (fatherMariiageOrderTextBox.Text == "ترتيب الزواج بين زيجاته الأخرى")
            {
                errorMessage += "ترتيب الزواج بين زيجاته الأخرى, ";
                counter++;
            }

            if (yesFatherRelativeRB.Checked)
            {
                if (String.IsNullOrEmpty(fatherMarriageSideComboBox.Text))
                {
                    errorMessage += "جهة القرابة, ";
                    counter++;
                }
            }

            if (fatherBoysCountTextBox.Text == "عدد الأبناء")
            {
                errorMessage += "عدد الأبناء, ";
                counter++;
            }
            if (fatherGirlsCountTextBox.Text == "عدد البنات")
            {
                errorMessage += "عدد البنات, ";
                counter++;
            }

            if (fatherTotalKidsTextBox.Text == "العدد")
            {
                errorMessage += "عدد الأبناء الكلي, ";
                counter++;
            }

            if (wifeFatherNationalityTextBox.Text == "جنسية الزوجة")
            {
                errorMessage += "جنسية الزوجة, ";
                counter++;
            }

            if (fatherMarriageDurationTextBox.Text == "مدة الزواج بالأعوام")
            {
                errorMessage += "مدة الزواج بالأعوام, ";
                counter++;
            }

            int parsedValue;
            if (!(int.TryParse(totalFatherMarriageTextBox.Text, out parsedValue)))
            {
                errorMessage += "عدد الزيجات بالأرقام ليس بالحروف, ";
                counter++;
            }

            if (!(int.TryParse(fatherMarriageDurationTextBox.Text, out parsedValue)))
            {
                errorMessage += "مدة الزواج بالأرقام ليس بالحروف, ";
                counter++;
            }

            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool motherMarriageDGVValidation()
        {
            string errorMessage = "";
            int counter = 0;

            if (motherMariiageOrderTextBox.Text == "ترتيب الزواج بين زيجاتها الأخرى")
            {
                errorMessage += "ترتيب الزواج بين زيجاتها الأخرى, ";
                counter++;
            }

            if (yesMotherRelativeRB.Checked)
            {
                if (String.IsNullOrEmpty(motherMarriageSideComboBox.Text))
                {
                    errorMessage += "جهة القرابة, ";
                    counter++;
                }
            }

            if (motherBoysCountTextBox.Text == "عدد الأبناء")
            {
                errorMessage += "عدد الأبناء, ";
                counter++;
            }
            if (motherGirlsCountTextBox.Text == "عدد البنات")
            {
                errorMessage += "عدد البنات, ";
                counter++;
            }

            if (motherTotalKidsTextBox.Text == "العدد")
            {
                errorMessage += "عدد الأبناء الكلي, ";
                counter++;
            }

            if (husbandMotherTextBox.Text == "جنسية الزوج")
            {
                errorMessage += "جنسية الزوج, ";
                counter++;
            }

            if (motherMarriageDurationTextBox.Text == "مدة الزواج بالأعوام")
            {
                errorMessage += "مدة الزواج بالأعوام, ";
                counter++;
            }

            int parsedValue;
            if (!(int.TryParse(totalMotherMarriageTextBox.Text, out parsedValue)))
            {
                errorMessage += "عدد الزيجات بالأرقام ليس بالحروف, ";
                counter++;
            }

            if (!(int.TryParse(motherMarriageDurationTextBox.Text, out parsedValue)))
            {
                errorMessage += "مدة الزواج بالأرقام ليس بالحروف, ";
                counter++;
            }


            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool fifthPageTextBoxValidation()
        {
            string errorMessage = "";
            int counter = 0;

            int parsedValue;
            if (int.TryParse(totalFatherMarriageTextBox.Text, out parsedValue))
            {
                if ((fatherDGV.Rows.Count - 1) != (parsedValue))
                {
                    errorMessage += "تفاصيل زيجات الأب جميعها, ";
                    counter++;
                }
            }
            else
            {
                errorMessage += "عدد زيجات الأب بالأرقام ليس بالحروف, ";
                counter++;
            }

            if (int.TryParse(totalMotherMarriageTextBox.Text, out parsedValue))
            {
                if ((motherDGV.Rows.Count - 1) != (parsedValue))
                {
                    errorMessage += "تفاصيل زيجات الأم جميعها, ";
                    counter++;
                }
            }
            else
            {
                errorMessage += "عدد زيجات الأم بالأرقام ليس بالحروف, ";
                counter++;
            }

            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "أكمل العائلة الكبيرة في تحليل البيئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "أكمل العائلة الكبيرة في تحليل البيئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool schoolStageValidation_sixthPage()
        {
            string errorMessage = "";
            int counter = 0;

            if (String.IsNullOrEmpty(schoolStageComboBox.Text))
            {
                errorMessage += "المرحلة التعليمية, ";
                counter++;
            }

            if (String.IsNullOrEmpty(schoolNameTextBox.Text))
            {
                errorMessage += "اسم المدرسة, ";
                counter++;
            }

            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool sixthPageTextBoxValidation()
        {
            string errorMessage = "";
            int counter = 0;


            if (pocketMoneyTextBox.Text == "بالدرهم")
            {
                errorMessage += "المصروف المخصص بالدرهم, ";
                counter++;
            }

            if (patientSocialStatusTextBox.Text == "النظر في عمر أصدقائه ومن هم وكيفية العلاقة بينه وبين أصدقاءه والنظر في القدرة على بناء علاقات والمحافظة عليها وإذا كان هنالك دليل على التعرض لاستغلال الأصدقاء في الوقت أو في الماضي.")
            {
                errorMessage += "القرناء والعلاقات الاجتماعية, ";
                counter++;
            }

            if (hatedSchoolRB.Checked)
            {
                if (hatedSchoolTextBox.Text == "الأسباب")
                {
                    errorMessage += "أسباب كره الذهاب للمدرسة, ";
                    counter++;
                }
            }
            if (badRelationWithStudentsRB.Checked)
            {
                if (badRelationWithStudentsReasonTextBox.Text == "الأسباب")
                {
                    errorMessage += "أسباب سوء العلاقة مع التلاميذ, ";
                    counter++;
                }
            }
            if (badRelationWithTeachersCB.Checked)
            {
                if (otherReaonsBadTeacherRelationRB.Checked)
                {
                    if (String.IsNullOrEmpty(graduationAgeTextBox.Text))
                    {
                        errorMessage += "أسباب سوء العلاقة مع المدرسين, ";
                        counter++;
                    }
                }
            }

            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "أكمل التفاصيل الاجتماعية في الأحداث والقاصرات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "أكمل التفاصيل الاجتماعية في الأحداث والقاصرات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool seventhPageTextBoxValidation()
        {
            string errorMessage = "";
            int counter = 0;

            if (convictedFamilyMemberCB.Checked)
            {
                if (familyMemberConvictedTextBox.Text == "ما نوع الجريمة وتفاصيلها")
                {
                    errorMessage += "ما نوع الجريمة وتفاصيلها, ";
                    counter++;
                }
            }

            if (travelledCB.Checked)
            {
                if (whichCountriesTextBox.Text == "ما الدول وتفاصيل السفر")
                {
                    errorMessage += "ما الدول وتفاصيل السفر, ";
                    counter++;
                }
            }

            if (familyTextBox.Text == "خذ بعين الاعتبار موقف الأسرة من الحد بعد الجنحة.\nخذ بعين الاعتبار المنطقة السكنية للحدث.")
            {
                errorMessage += "الأسرة والعلاقات الاجتماعية, ";
                counter++;
            }

            if (motivationsTextBox.Text == "خذ بعين الاعتبار موقف الحدث من الجنحة, هل يتحمل المسؤولية وتصرفاته وهل يتفهم خطورة سلوكه وتأثير ذلك على الضحية؟\nالنظر في أي دافع وأي تغيير وأي طموحات للمستقبل.\nتحديد أي عوامل إيجابية أو وقائية.")
            {
                errorMessage += "المواقف والدوافع للتغيير, ";
                counter++;
            }

            if (socialStatusAbstractRB.Text == "تشخيص حالة الحدث ويجب أن تشمل المخاطر الأساسية وعوامل الجنوح والتوصيات.")
            {
                errorMessage += "ملخص الوضع الاجتماعي, ";
                counter++;
            }

            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "أكمل سلوك الفرد في الأحداث والقاصرات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "أكمل سلوك الفرد في الأحداث والقاصرات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool eigthPageTextBoxValidation()
        {
            string errorMessage = "";
            int counter = 0;
            if (newMeetingRB.Checked)
            {
                if (String.IsNullOrEmpty(meetingTitleTextBox.Text))
                {
                    errorMessage += "عنوان المقابلة, ";
                    counter++;
                }
            }
            else
            {
                if (String.IsNullOrEmpty(meetingTitleComboBox.Text))
                {
                    errorMessage += "عنوان المقابلة, ";
                    counter++;
                }
            }

            if (String.IsNullOrEmpty(meetingPurposeTextBox.Text))
            {
                errorMessage += "أهداف المقابلة, ";
                counter++;
            }

            if (String.IsNullOrEmpty(meetingContentTextBox.Text))
            {
                errorMessage += "محتوى المقابلة, ";
                counter++;
            }

            if (String.IsNullOrEmpty(recommendationTextBox.Text))
            {
                errorMessage += "التوصيات والمقترحات, ";
                counter++;
            }

            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "أكمل المقابلات الدورية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "أكمل المقابلات الدورية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        bool targetOfMeeting_eightPage()
        {
            string errorMessage = "";
            int counter = 0;

            if (String.IsNullOrEmpty(ssnNumberTargetTextBox.Text))
            {
                errorMessage += "الرقم الموحد, ";
                counter++;
            }

            if (String.IsNullOrEmpty(nameTargetTextBox.Text))
            {
                errorMessage += "الاسم, ";
                counter++;
            }

            if (String.IsNullOrEmpty(nationalityTargetTextBox.Text))
            {
                errorMessage += "الجنسية, ";
                counter++;
            }

            if (String.IsNullOrEmpty(ageTargetTextBox.Text))
            {
                errorMessage += "العمر, ";
                counter++;
            }

            if (String.IsNullOrEmpty(caseTargetTextBox.Text))
            {
                errorMessage += "القضية, ";
                counter++;
            }

            if (errorMessage != "")
            {
                if (counter <= 3)
                {
                    MessageBox.Show("الرجاء إدخال " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("الرجاء إكمال البيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }



        ///
        ///

        //!!!!!!!!!!!!!! =======> Personally Analysis Tab Control <======= !!!!!!!!!!!!!!

        ///
        ///

        private void loneRoomRB_CheckedChanged(object sender, EventArgs e)
        {
            if (loneRoomRB.Checked)
            {
                deactivateTextBox(shareRoomWithTextBox);
            }
            else
            {
                reactivateTextBox(shareRoomWithTextBox);
            }
        }

        private void othersTraitsCB_CheckedChanged(object sender, EventArgs e)
        {
            if (othersTraitsCB.Checked)
            {
                reactivateTextBox(behavioralTraitsOthersTextBox);
            }
            else
            {
                deactivateTextBox(behavioralTraitsOthersTextBox);
            }
        }

        private void yesAIRB_CheckedChanged(object sender, EventArgs e)
        {
            if (yesAIRB.Checked)
            {
                reactivateTextBox(anotherIncomeTextBox);
            }
            else
            {
                deactivateTextBox(anotherIncomeTextBox);
            }
        }

        private void yesFPRB_CheckedChanged(object sender, EventArgs e)
        {
            if (yesFPRB.Checked)
            {
                reactivateTextBox(financialProblemsTextBox);
            }
            else
            {
                deactivateTextBox(financialProblemsTextBox);
            }
        }

        private void otherHomeRB_CheckedChanged(object sender, EventArgs e)
        {
            if (otherHomeRB.Checked)
            {
                reactivateTextBox(otherHomeTextBox);
            }
            else
            {
                deactivateTextBox(otherHomeTextBox);
            }
        }

        private void miserableJobCB_CheckedChanged(object sender, EventArgs e)
        {
            if (miserableJobCB.Checked)
            {
                reactivateTextBox(miserableJobReasonTextBox);
            }
            else
            {
                deactivateTextBox(miserableJobReasonTextBox);
            }
        }

        private void workingNatureOthersTextBox_Leave(object sender, EventArgs e)
        {
            if (workingNatureOthersRB.Checked)
            {
                patientWorkNature = workingNatureOthersTextBox.Text;
            }
        }

        ///
        ///

        //!!!!!!!!!!!!!! =======> Medical Issues Tab Control <======= !!!!!!!!!!!!!!

        ///
        ///

        // ==> Suicidial attempts
        private void noAttemptsRB_CheckedChanged(object sender, EventArgs e)
        {
            if (noAttemptsRB.Checked)
            {
                deactivateTextBox(suicideWayTextBox);
                deactivateTextBox(suicideDetailsTextBox);
                deactivateTextBox(suicideNotesTextBox);
                SuicideAttempts = noAttemptsRB.Text;
            }
            else
            {
                reactivateTextBox(suicideWayTextBox);
                reactivateTextBox(suicideDetailsTextBox);
                reactivateTextBox(suicideNotesTextBox);
            }
        }

        private void thinkingRB_CheckedChanged(object sender, EventArgs e)
        {
            if (thinkingRB.Checked)
            {
                SuicideAttempts = thinkingRB.Text;
            }
        }

        private void attemptRB_CheckedChanged(object sender, EventArgs e)
        {
            if (attemptRB.Checked)
            {
                SuicideAttempts = attemptRB.Text;
            }
        }

        private void warehouseCB_CheckedChanged(object sender, EventArgs e)
        {
            if (warehouseCB.Checked)
            {
                reactivateTextBox(warehouseCountsTextBox);
                reactivateTextBox(warehouseDetailsTextBox);
            }
            else
            {
                deactivateTextBox(warehouseCountsTextBox);
                deactivateTextBox(warehouseDetailsTextBox);
            }
        }

        private void blackoutCB_CheckedChanged(object sender, EventArgs e)
        {
            if (blackoutCB.Checked)
            {
                reactivateTextBox(blackoutCountsTextBox);
                reactivateTextBox(blackoutDetailsTextBox);
            }
            else
            {
                deactivateTextBox(blackoutCountsTextBox);
                deactivateTextBox(blackoutDetailsTextBox);
            }
        }

        private void noUseRB_CheckedChanged(object sender, EventArgs e)
        {
            if (noUseRB.Checked)
            {
                deactivateTextBox(startingAgeTextBox);
                deactivateTextBox(TypesUsedTextBox);
                deactivateTextBox(monthUsedTextBox);
                deactivateTextBox(totalDurationTextBox);
                deactivateTextBox(drugUsedDetailsTextBox);
                deactivateOthersTextBoxAndLabelGroup(yearsUsedTextBox, label24);
                drugAbuse = noUseRB.Text;

            }
            else
            {
                reactivateTextBox(startingAgeTextBox);
                reactivateTextBox(TypesUsedTextBox);
                reactivateTextBox(monthUsedTextBox);
                reactivateTextBox(totalDurationTextBox);
                reactivateTextBox(drugUsedDetailsTextBox);
                reactivateOthersTextBoxAndLabelGroup(yearsUsedTextBox, label24);
            }
        }
        private void useRB_CheckedChanged(object sender, EventArgs e)
        {
            if (useRB.Checked)
            {
                drugAbuse = useRB.Text;
            }
        }

        private void previousUseRB_CheckedChanged(object sender, EventArgs e)
        {
            if (useRB.Checked)
            {
                drugAbuse = previousUseRB.Text;
            }
        }

        private void previousTreatmentCB_CheckedChanged(object sender, EventArgs e)
        {
            if (previousTreatmentCB.Checked)
            {
                treatmentPlacesGB.Enabled = true;
            }
            else
            {
                treatmentPlacesGB.Enabled = false;

            }
        }

        private void familyIllnessCB_CheckedChanged(object sender, EventArgs e)
        {
            if (familyIllnessCB.Checked)
            {
                reactivateTextBox(familyIllnessDetailsTextBox);
            }
            else
            {
                deactivateTextBox(familyIllnessDetailsTextBox);
            }
        }

        private void monthUsedTextBox_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (int.TryParse(monthUsedTextBox.Text, out parsedValue))
            {
                if (int.TryParse(yearsUsedTextBox.Text, out parsedValue))
                {
                    totalDurationTextBox.Text = (Int32.Parse(monthUsedTextBox.Text) + (Int32.Parse(yearsUsedTextBox.Text) * 12)).ToString();
                }
                else
                {
                    totalDurationTextBox.Text = (Int32.Parse(monthUsedTextBox.Text)).ToString();
                }
            }
            else
            {
                if (int.TryParse(yearsUsedTextBox.Text, out parsedValue))
                {
                    totalDurationTextBox.Text = (Int32.Parse(yearsUsedTextBox.Text) * 12).ToString();

                }
                else
                {
                    totalDurationTextBox.Text = "0";
                }
            }
        }

        private void yearsUsedTextBox_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (int.TryParse(yearsUsedTextBox.Text, out parsedValue))
            {
                if (int.TryParse(monthUsedTextBox.Text, out parsedValue))
                {
                    totalDurationTextBox.Text = (Int32.Parse(monthUsedTextBox.Text) + (Int32.Parse(yearsUsedTextBox.Text) * 12)).ToString();
                }
                else
                {
                    totalDurationTextBox.Text = (Int32.Parse(yearsUsedTextBox.Text) * 12).ToString();
                }
            }
            else
            {
                if (int.TryParse(monthUsedTextBox.Text, out parsedValue))
                {
                    totalDurationTextBox.Text = (Int32.Parse(monthUsedTextBox.Text)).ToString();
                }
                else
                {
                    totalDurationTextBox.Text = "0";
                }
            }
        }
        //====> Watermarks of the textboxes In 3S <====


        private void suicideWayTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(suicideWayTextBox, "الطريقة التي فكر فيها");
        }

        private void suicideWayTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(suicideWayTextBox, "الطريقة التي فكر فيها");
        }

        private void suicideDetailsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(suicideDetailsTextBox, "التفاصيل");
        }

        private void suicideDetailsTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(suicideDetailsTextBox, "التفاصيل");
        }

        private void suicideNotesTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(suicideNotesTextBox, "ملاحظات");
        }

        private void suicideNotesTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(suicideNotesTextBox, "ملاحظات");
        }

        private void warehouseCountsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(warehouseCountsTextBox, "عدد مرات دخوله");
        }

        private void warehouseCountsTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(warehouseCountsTextBox, "عدد مرات دخوله");
        }

        private void warehouseDetailsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(warehouseDetailsTextBox, "التفاصيل");
        }

        private void warehouseDetailsTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(warehouseDetailsTextBox, "التفاصيل");
        }

        private void blackoutCountsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(blackoutCountsTextBox, "عدد مرات إصابته");
        }

        private void blackoutCountsTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(blackoutCountsTextBox, "عدد مرات إصابته");
        }

        private void blackoutDetailsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(blackoutDetailsTextBox, "التفاصيل");
        }

        private void blackoutDetailsTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(blackoutDetailsTextBox, "التفاصيل");
        }

        private void startingAgeTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(startingAgeTextBox, "سن بداية التعاطي");
        }

        private void startingAgeTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(startingAgeTextBox, "سن بداية التعاطي");
        }

        private void TypesUsedTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(TypesUsedTextBox, "الأنواع التي يتعاطيها");
        }

        private void TypesUsedTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(TypesUsedTextBox, "الأنواع التي يتعاطيها");
        }

        private void monthUsedTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(monthUsedTextBox, "شهر");
        }

        private void monthUsedTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(monthUsedTextBox, "شهر");
        }

        private void yearsUsedTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(yearsUsedTextBox, "سنة");
        }

        private void yearsUsedTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(yearsUsedTextBox, "سنة");
        }

        private void totalDurationTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(totalDurationTextBox, "المدة الإجمالية بالشهور");
        }

        private void totalDurationTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(totalDurationTextBox, "المدة الإجمالية بالشهور");
        }

        private void drugUsedDetailsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(drugUsedDetailsTextBox, "التفاصيل");
        }

        private void drugUsedDetailsTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(drugUsedDetailsTextBox, "التفاصيل");
        }

        private void hospitalTreatmentTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(hospitalTreatmentTextBox, "المستشفى");
        }

        private void hospitalTreatmentTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(hospitalTreatmentTextBox, "المستشفى");
        }

        private void doctorTreatmentTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(doctorTreatmentTextBox, "الطبيب المعالج");
        }

        private void doctorTreatmentTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(doctorTreatmentTextBox, "الطبيب المعالج");
        }

        private void fileNumberTreatmentTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(fileNumberTreatmentTextBox, "رقم الملف الطبي");
        }

        private void fileNumberTreatmentTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(fileNumberTreatmentTextBox, "رقم الملف الطبي");
        }

        private void notesTreatmentTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(notesTreatmentTextBox, "ملاحظات");
        }

        private void notesTreatmentTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(notesTreatmentTextBox, "ملاحظات");
        }

        private void familyIllnessDetailsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(familyIllnessDetailsTextBox, "التفاصيل");
        }

        private void familyIllnessDetailsTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(familyIllnessDetailsTextBox, "التفاصيل");
        }

        private void previousPatientHistoryNotesTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(previousPatientHistoryNotesTextBox, "ملاحظات التاريخ المرضي السابق");
        }

        private void previousPatientHistoryNotesTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(previousPatientHistoryNotesTextBox, "ملاحظات التاريخ المرضي السابق");
        }

        ///
        ///

        //!!!!!!!!!!!!!! =======> Social Environmental Status Analysis Tab Control <======= !!!!!!!!!!!!!!

        ///
        ///

        private void noRelativeRB_CheckedChanged(object sender, EventArgs e)
        {
            if (noRelativeRB.Checked)
            {
                deactivateComboBox(patientMarriageSideComboBox);
            }
            else
            {
                reactivateComboBox(patientMarriageSideComboBox);
            }
        }

        //====> Watermarks of the textboxes In 4S <====

        private void maritalStausReasonsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(maritalStausReasonsTextBox, "أسباب الحالة الاجتماعية");
        }

        private void maritalStausReasonsTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(maritalStausReasonsTextBox, "أسباب الحالة الاجتماعية");
        }

        private void totalPatientMarriageTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(totalPatientMarriageTextBox, "عدد مرات الزواج الكلية");
        }

        private void totalPatientMarriageTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(totalPatientMarriageTextBox, "عدد مرات الزواج الكلية");
        }

        private void ageAtMarriageFemaleTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(ageAtMarriageFemaleTextBox, "العمر عند الزواج");
        }

        private void ageAtMarriageFemaleTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(ageAtMarriageFemaleTextBox, "العمر عند الزواج");
        }

        private void ageAtProcreationFemaleTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(ageAtProcreationFemaleTextBox, "العمر عند الإنجاب");
        }

        private void ageAtProcreationFemaleTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(ageAtProcreationFemaleTextBox, "العمر عند الإنجاب");
        }

        private void marriagePatientOrderTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(marriagePatientOrderTextBox, "ترتيب الزواج بين زيجاته الأخرى");
        }

        private void marriagePatientOrderTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(marriagePatientOrderTextBox, "ترتيب الزواج بين زيجاته الأخرى");
        }

        private void boysCountPatientsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(boysCountPatientsTextBox, "عدد الأبناء");
        }

        private void boysCountPatientsTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(boysCountPatientsTextBox, "عدد الأبناء");
        }

        private void girlsCountPatientsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(girlsCountPatientsTextBox, "عدد البنات");
        }

        private void girlsCountPatientsTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(girlsCountPatientsTextBox, "عدد البنات");
        }

        private void totalSonsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(totalSonsTextBox, "العدد");
        }

        private void totalSonsTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(totalSonsTextBox, "العدد");
        }

        private void husbandNationalityTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(husbandNationalityTextBox, "جنسية الزوج");
        }

        private void husbandNationalityTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(husbandNationalityTextBox, "جنسية الزوج");
        }

        private void marriageDurationTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(marriageDurationTextBox, "مدة الزواج");
        }

        private void marriageDurationTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(marriageDurationTextBox, "مدة الزواج");
        }

        private void girlsCountPatientsTextBox_TextChanged(object sender, EventArgs e)
        {
            dynamicChildrenCalculator(girlsCountPatientsTextBox, boysCountPatientsTextBox, totalSonsTextBox);
        }

        private void boysCountPatientsTextBox_TextChanged(object sender, EventArgs e)
        {
            dynamicChildrenCalculator(boysCountPatientsTextBox, girlsCountPatientsTextBox, totalSonsTextBox);
        }

        private void otherResponsibilitiesRB_CheckedChanged(object sender, EventArgs e)
        {
            if (otherResponsibilitiesRB.Checked)
            {
                reactivateTextBox(otherResponsibilitiesTextBox);
            }
            else
            {
                deactivateTextBox(otherResponsibilitiesTextBox);
            }
        }

        ///
        ///

        //!!!!!!!!!!!!!! =======> The Big family Status Analysis Tab Control <======= !!!!!!!!!!!!!!

        ///
        ///

        private void noFatherRelativeRB_CheckedChanged(object sender, EventArgs e)
        {
            if (noFatherRelativeRB.Checked)
            {
                deactivateComboBox(fatherMarriageSideComboBox);
            }
            else
            {
                reactivateComboBox(fatherMarriageSideComboBox);
            }
        }

        private void noMotherRelativeRB_CheckedChanged(object sender, EventArgs e)
        {
            if (noMotherRelativeRB.Checked)
            {
                deactivateComboBox(motherMarriageSideComboBox);
            }
            else
            {
                reactivateComboBox(motherMarriageSideComboBox);
            }

        }

        private void totalFatherMarriageTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(totalFatherMarriageTextBox, "عدد مرات الزواج الكلية");
        }

        private void totalFatherMarriageTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(totalFatherMarriageTextBox, "عدد مرات الزواج الكلية");
        }

        private void fatherNationalityTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(fatherNationalityTextBox, "الجنسية");
        }

        private void fatherNationalityTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(fatherNationalityTextBox, "الجنسية");
        }

        private void fatherEducationLevelTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(fatherEducationLevelTextBox, "مستوى التعليم");
        }

        private void fatherEducationLevelTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(fatherEducationLevelTextBox, "مستوى التعليم");
        }

        private void fatherMariiageOrderTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(fatherMariiageOrderTextBox, "ترتيب الزواج بين زيجاته الأخرى");
        }

        private void fatherMariiageOrderTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(fatherMariiageOrderTextBox, "ترتيب الزواج بين زيجاته الأخرى");
        }

        private void fatherBoysCountTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(fatherBoysCountTextBox, "عدد الأبناء");
        }

        private void fatherBoysCountTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(fatherBoysCountTextBox, "عدد الأبناء");
        }

        private void fatherGirlsCountTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(fatherGirlsCountTextBox, "عدد البنات");
        }

        private void fatherGirlsCountTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(fatherGirlsCountTextBox, "عدد البنات");
        }

        private void fatherTotalKidsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(fatherTotalKidsTextBox, "العدد");
        }

        private void fatherTotalKidsTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(fatherTotalKidsTextBox, "العدد");
        }

        private void wifeFatherNationalityTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(wifeFatherNationalityTextBox, "جنسية الزوجة");
        }

        private void wifeFatherNationalityTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(wifeFatherNationalityTextBox, "جنسية الزوجة");
        }

        private void fatherMarriageDurationTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(fatherMarriageDurationTextBox, "مدة الزواج بالأعوام");
        }

        private void fatherMarriageDurationTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(fatherMarriageDurationTextBox, "مدة الزواج بالأعوام");
        }

        private void totalMotherMarriageTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(totalMotherMarriageTextBox, "عدد مرات الزواج الكلية");
        }

        private void totalMotherMarriageTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(totalMotherMarriageTextBox, "عدد مرات الزواج الكلية");
        }

        private void motherNationalityTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(motherNationalityTextBox, "الجنسية");
        }

        private void motherNationalityTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(motherNationalityTextBox, "الجنسية");
        }

        private void motherEducationLevelTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(motherEducationLevelTextBox, "مستوى التعليم");
        }

        private void motherEducationLevelTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(motherEducationLevelTextBox, "مستوى التعليم");
        }

        private void motherMariiageOrderTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(motherMariiageOrderTextBox, "ترتيب الزواج بين زيجاتها الأخرى");
        }

        private void motherMariiageOrderTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(motherMariiageOrderTextBox, "ترتيب الزواج بين زيجاتها الأخرى");
        }

        private void motherBoysCountTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(motherBoysCountTextBox, "عدد الأبناء");
        }

        private void motherBoysCountTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(motherBoysCountTextBox, "عدد الأبناء");
        }

        private void motherGirlsCountTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(motherGirlsCountTextBox, "عدد البنات");
        }

        private void motherGirlsCountTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(motherGirlsCountTextBox, "عدد البنات");
        }

        private void motherTotalKidsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(motherTotalKidsTextBox, "العدد");
        }

        private void motherTotalKidsTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(motherTotalKidsTextBox, "العدد");
        }

        private void husbandMotherTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(husbandMotherTextBox, "جنسية الزوج");
        }

        private void husbandMotherTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(husbandMotherTextBox, "جنسية الزوج");
        }

        private void motherMarriageDurationTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(motherMarriageDurationTextBox, "مدة الزواج بالأعوام");
        }

        private void motherMarriageDurationTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(motherMarriageDurationTextBox, "مدة الزواج بالأعوام");
        }

        private void brothersCountTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(brothersCountTextBox, "الأشقاء من جهة الأب والأم فقط");
        }

        private void brothersCountTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(brothersCountTextBox, "الأشقاء من جهة الأب والأم فقط");
        }

        private void patientOrderTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(patientOrderTextBox, "ترتيب المفحوص بين أشقائه وشقيقاته");
        }

        private void patientOrderTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(patientOrderTextBox, "ترتيب المفحوص بين أشقائه وشقيقاته");
        }

        private void sistersCoutTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(sistersCoutTextBox, "الشقيقات من جهة الأب والأم فقط");
        }

        private void sistersCoutTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(sistersCoutTextBox, "الشقيقات من جهة الأب والأم فقط");
        }

        private void nearestFamilyMemberTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(nearestFamilyMemberTextBox, "أقرب شخص للمفحوص من العائلة");
        }

        private void nearestFamilyMemberTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(nearestFamilyMemberTextBox, "أقرب شخص للمفحوص من العائلة");
        }

        private void totalMembersTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(totalMembersTextBox, "عدد الأشقاء والشقيقات الكلي");
        }

        private void totalMembersTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(totalMembersTextBox, "عدد الأشقاء والشقيقات الكلي");
        }

        private void responsibleForCoutTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(responsibleForCoutTextBox, "عدد الأفراد المسؤول عنهم");
        }

        private void responsibleForCoutTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(responsibleForCoutTextBox, "عدد الأفراد المسؤول عنهم");
        }

        private void responsibleForDescriptionTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(responsibleForDescriptionTextBox, "أعمار ووصف الأفراد المسؤول عنهم");
        }

        private void responsibleForDescriptionTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(responsibleForDescriptionTextBox, "أعمار ووصف الأفراد المسؤول عنهم");
        }

        private void otherResponsibilitiesTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(otherResponsibilitiesTextBox, "آخرين");
        }

        private void otherResponsibilitiesTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(otherResponsibilitiesTextBox, "آخرين");
        }


        // Dynamic children calcuation 
        private void fatherBoysCountTextBox_TextChanged(object sender, EventArgs e)
        {
            dynamicChildrenCalculator(fatherBoysCountTextBox, fatherGirlsCountTextBox, fatherTotalKidsTextBox);
        }

        private void fatherGirlsCountTextBox_TextChanged(object sender, EventArgs e)
        {
            dynamicChildrenCalculator(fatherGirlsCountTextBox, fatherBoysCountTextBox, fatherTotalKidsTextBox);
        }

        private void motherBoysCountTextBox_TextChanged(object sender, EventArgs e)
        {
            dynamicChildrenCalculator(motherBoysCountTextBox, motherGirlsCountTextBox, motherTotalKidsTextBox);
        }

        private void motherGirlsCountTextBox_TextChanged(object sender, EventArgs e)
        {
            dynamicChildrenCalculator(motherGirlsCountTextBox, motherBoysCountTextBox, motherTotalKidsTextBox);
        }

        ///
        ///

        //!!!!!!!!!!!!!! =======> Teen Social Details <======= !!!!!!!!!!!!!!

        ///
        ///

        private void pocketMoneyTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(pocketMoneyTextBox, "بالدرهم");
        }

        private void pocketMoneyTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(pocketMoneyTextBox, "بالدرهم");
        }

        private void patientSocialStatusTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(patientSocialStatusTextBox, "النظر في عمر أصدقائه ومن هم وكيفية العلاقة بينه وبين أصدقاءه والنظر في القدرة على بناء علاقات والمحافظة عليها وإذا كان هنالك دليل على التعرض لاستغلال الأصدقاء في الوقت أو في الماضي.");
        }

        private void patientSocialStatusTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(patientSocialStatusTextBox, "النظر في عمر أصدقائه ومن هم وكيفية العلاقة بينه وبين أصدقاءه والنظر في القدرة على بناء علاقات والمحافظة عليها وإذا كان هنالك دليل على التعرض لاستغلال الأصدقاء في الوقت أو في الماضي.");
        }

        private void hatedSchoolTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(hatedSchoolTextBox, "الأسباب");
        }

        private void hatedSchoolTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(hatedSchoolTextBox, "الأسباب");
        }

        private void badRelationWithStudentsReasonTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(badRelationWithStudentsReasonTextBox, "الأسباب");
        }

        private void badRelationWithStudentsReasonTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(badRelationWithStudentsReasonTextBox, "الأسباب");
        }

        private void familyMemberConvictedTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(familyMemberConvictedTextBox, "ما نوع الجريمة وتفاصيلها");
        }

        private void familyMemberConvictedTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(familyMemberConvictedTextBox, "ما نوع الجريمة وتفاصيلها");
        }

        private void freeTimeTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(freeTimeTextBox, "كيف تقضي وقت الفراغ");
        }

        private void freeTimeTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(freeTimeTextBox, "كيف تقضي وقت الفراغ");
        }

        private void whichCountriesTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(whichCountriesTextBox, "ما الدول وتفاصيل السفر");
        }

        private void whichCountriesTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(whichCountriesTextBox, "ما الدول وتفاصيل السفر");
        }

        private void familyTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(familyTextBox, "خذ بعين الاعتبار موقف الأسرة من الحد بعد الجنحة.\nخذ بعين الاعتبار المنطقة السكنية للحدث.");
        }

        private void familyTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(familyTextBox, "خذ بعين الاعتبار موقف الأسرة من الحد بعد الجنحة.\nخذ بعين الاعتبار المنطقة السكنية للحدث.");
        }

        private void motivationsTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(motivationsTextBox, "خذ بعين الاعتبار موقف الحدث من الجنحة, هل يتحمل المسؤولية وتصرفاته وهل يتفهم خطورة سلوكه وتأثير ذلك على الضحية؟\nالنظر في أي دافع وأي تغيير وأي طموحات للمستقبل.\nتحديد أي عوامل إيجابية أو وقائية.");
        }

        private void motivationsTextBox_Leave(object sender, EventArgs e)
        {

            leaveTextBox(motivationsTextBox, "خذ بعين الاعتبار موقف الحدث من الجنحة, هل يتحمل المسؤولية وتصرفاته وهل يتفهم خطورة سلوكه وتأثير ذلك على الضحية؟\nالنظر في أي دافع وأي تغيير وأي طموحات للمستقبل.\nتحديد أي عوامل إيجابية أو وقائية.");
        }

        private void socialStatusAbstractRB_Enter(object sender, EventArgs e)
        {
            enterTextBox(socialStatusAbstractRB, "تشخيص حالة الحدث ويجب أن تشمل المخاطر الأساسية وعوامل الجنوح والتوصيات.");
        }

        private void socialStatusAbstractRB_Leave(object sender, EventArgs e)
        {
            leaveTextBox(socialStatusAbstractRB, "تشخيص حالة الحدث ويجب أن تشمل المخاطر الأساسية وعوامل الجنوح والتوصيات.");
        }

        private void pocketMoneyIsEnoughCB_CheckedChanged(object sender, EventArgs e)
        {
            if (pocketMoneyIsEnoughCB.Checked)
            {
                shortcomingSourceGB.Enabled = false;
            }
            else
            {
                shortcomingSourceGB.Enabled = true;
            }
        }

        private void otherSourceRB_CheckedChanged(object sender, EventArgs e)
        {
            if (otherSourceRB.Checked)
            {
                reactivateTextBox(otherSourceTextBox);
            }
            else
            {
                deactivateTextBox(otherSourceTextBox);
            }
        }

        private void lovedSchoolRB_CheckedChanged(object sender, EventArgs e)
        {
            if (lovedSchoolRB.Checked)
            {
                deactivateTextBox(hatedSchoolTextBox);
            }
            else
            {
                reactivateTextBox(hatedSchoolTextBox);
            }
        }

        private void goodRelationWithStudentsRB_CheckedChanged(object sender, EventArgs e)
        {
            if (goodRelationWithStudentsRB.Checked)
            {
                deactivateTextBox(badRelationWithStudentsReasonTextBox);
            }
            else
            {
                reactivateTextBox(badRelationWithStudentsReasonTextBox);
            }
        }

        private void badRelationWithTeachersCB_CheckedChanged(object sender, EventArgs e)
        {
            if (badRelationWithTeachersCB.Checked)
            {
                badRelationsWithTeachersGB.Enabled = true;
            }
            else
            {
                badRelationsWithTeachersGB.Enabled = false;
            }
        }

        private void otherReaonsBadTeacherRelationRB_CheckedChanged(object sender, EventArgs e)
        {
            if (otherReaonsBadTeacherRelationRB.Checked)
            {
                reactivateTextBox(otherReaonsBadTeacherRelationTextBox);
            }
            else
            {
                deactivateTextBox(otherReaonsBadTeacherRelationTextBox);
            }
        }


        private void convictedFamilyMemberCB_CheckedChanged(object sender, EventArgs e)
        {
            if (convictedFamilyMemberCB.Checked)
            {
                reactivateTextBox(familyMemberConvictedTextBox);
                convictedFamilyMemberGB.Enabled = true;
            }
            else
            {
                deactivateTextBox(familyMemberConvictedTextBox);
                convictedFamilyMemberGB.Enabled = false;
            }
        }

        private void drugAbuseFamilyMemberCB_CheckedChanged(object sender, EventArgs e)
        {
            if (drugAbuseFamilyMemberCB.Checked)
            {
                drugAbuseFamilyMemberGB.Enabled = true;
            }
            else
            {
                drugAbuseFamilyMemberGB.Enabled = false;
            }
        }

        private void haveEmailCB_CheckedChanged(object sender, EventArgs e)
        {
            if (haveEmailCB.Checked)
            {
                emailPurposeGB.Enabled = true;
            }
            else
            {
                emailPurposeGB.Enabled = false;
            }
        }

        private void travelledCB_CheckedChanged(object sender, EventArgs e)
        {
            if (travelledCB.Checked)
            {
                reactivateTextBox(whichCountriesTextBox);
            }
            else
            {
                deactivateTextBox(whichCountriesTextBox);
            }

        }


        // 1s DB Information
        private void addInjuryButton_Click(object sender, EventArgs e)
        {
            if (previousInjuriesHistoryDGVValidatin_firstPAge())
            {
                string[] row = { yearInjuredCB.Text, injuryDetailsTextBox.Text, fracturesTextBox.Text };
                injuriesDGV.Rows.Add(row);
                clearingInjuriesDGV_2ndPage();
            }
        }

        private void addEnteredInstituteButton_Click(object sender, EventArgs e)
        {
            if (previousInstitutionHistoryDGVValidatin_firstPAge())
            {
                string[] row = { enteredInstituteYearTextBox.Text, enteredInstituteCaseTextBox.Text, enteredInstituteJudgementTextBox.Text, enteredInstituteAgeTextBox.Text, enteredInstituteNotesTextBox.Text };
                enteredInstituteDGV.Rows.Add(row);
                clearingRehabilationDGV_1stPage();
            }
        }



        void saveFirstPage()
        {
            if (firstPageTextBoxValidation())
            {
                try
                {
                    string linguistic = (linguisticGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    string adultType = (adultTypeGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;

                    string Query = "IF NOT EXISTS (select 1 FROM patientInfo where ssn=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO patientInfo(ssn,name,age,nationality,phoneNumber,residencePlace,length,weight,waist,languistics,walking,muscles,caseFile,judge,birthDay,maritalStatus,sex,type,adultType,canBeCalledAgain,signDate,previousTreatment,accidents)" +
                        " VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.nameTextBox.Text + "',N'" + this.ageTextBox.Text + "',N'" + this.nationalityTextBox.Text + "',N'" + this.phoneNumberTextBox.Text + "',N'" + this.residencePlaceTextBox.Text + "',N'" + this.heightTextBox.Text + "',N'" + this.weightTextBox.Text + "',N'" + this.waistTextBox.Text + "'" +
                        ",N'" + linguistic + "',N'" + this.walkingTexBox.Text + "',N'" + this.musclesTextBox.Text + "',N'" + this.caseTextBox.Text + "',N'" + this.judgementTextBox.Text + "'" +
                        ",N'" + this.birthDayTP.Value.ToString("MM/dd/yyyy") + "',N'" + patientStatus + "',N'" + patientSex + "',N'" + patientType + "',N'" + adultType + "',N'" + this.canBeCalledAgainCB.Checked + "',N'" + this.dateDTP.Value.ToString("MM/dd/yyyy") + "', 'FALSE',N'" + this.anyInjuriesCB.Checked + "') END ";

                    SqlConnection conDataBase = new SqlConnection(constring);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();

                    if (!leftSchoolCB.Checked)
                    {
                        reasonsToQuitSchool = null;
                    }
                    else
                    {
                        reasonsToQuitSchool = (leftSchoolGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                        if (reasonsToQuitSchool == "أخرى")
                        {
                            reasonsToQuitSchool = LSothersTextBox.Text;
                        }
                    }

                    if (enteredInstituteCB.Checked)
                    {
                        for (int i = 0; i < enteredInstituteDGV.Rows.Count - 1; i++)
                        {
                            Query = "INSERT INTO rehabilation(ssnPatient,year,caseFile,judgement,entranceAge,notes) " +
                            "VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.enteredInstituteDGV.Rows[i].Cells[0].Value.ToString() + "',N'" + this.enteredInstituteDGV.Rows[i].Cells[1].Value.ToString() + "'" +
                            ",N'" + this.enteredInstituteDGV.Rows[i].Cells[2].Value.ToString() + "',N'" + this.enteredInstituteDGV.Rows[i].Cells[3].Value.ToString() + "',N'" + enteredInstituteDGV.Rows[i].Cells[4].Value.ToString() + "')";

                            conDataBase = new SqlConnection(constring);
                            adapter = new SqlDataAdapter();
                            command = new SqlCommand(Query, conDataBase);
                            conDataBase.Open();
                            adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                            adapter.InsertCommand.ExecuteNonQuery();
                            command.Dispose();
                            conDataBase.Close();
                        }
                    }

                    if (teenRB.Checked || singleRB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM EducationInfo where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO EducationInfo(ssnPatient,degree,graduationAge,leftSchool,Reasons)" +
                            " VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.educationalLevelTextBox.Text + "',N'" + this.graduationAgeTextBox.Text + "',N'" + this.leftSchoolCB.Checked + "',N'" + reasonsToQuitSchool + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }
                    else
                    {
                        Query = "IF NOT EXISTS (select 1 FROM EducationInfo where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO EducationInfo(ssnPatient,degree,graduationAge,leftSchool,Reasons,wifeDegree,wifeGraduationAge,wifeWorking) " +
                            "VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.educationalLevelTextBox.Text + "',N'" + this.graduationAgeTextBox.Text + "',N'" + this.leftSchoolCB.Checked + "',N'" + reasonsToQuitSchool + "'" +
                            ",N'" + this.wifeEducationLevelTextBox.Text + "',N'" + this.wifeGraduationAgeTextBox.Text + "',N'" + wifeWorkingRB.Checked + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }

                    string attendedWith = (AttendedWithGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    if (attendedWith == "آخرين")
                    {
                        attendedWith = AtterndeOthersTextBox.Text;
                    }

                    string transferredFrom = (transferredFromGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    if (transferredFrom == "أخرى")
                    {
                        transferredFrom = convertedFromOthersTextBox.Text;
                    }

                    string purpose = (purposeGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    if (purpose == "أخرى")
                    {
                        purpose = purposeOtherTextBox.Text;
                    }

                    Query = "IF NOT EXISTS (select 1 FROM firstMeetingDetails where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO firstMeetingDetails(ssnPatient,attendedWith,currentComplain,convertedFrom,purpose)" +
                           " VALUES (N'" + this.SSNTextBox.Text + "',N'" + attendedWith + "',N'" + this.currentComplainTextBox.Text + "',N'" + transferredFrom + "',N'" + purpose + "') END ";

                    conDataBase = new SqlConnection(constring);
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();


                    if (anyInjuriesCB.Checked)
                    {
                        for (int i = 0; i < injuriesDGV.Rows.Count - 1; i++)
                        {
                            Query = "INSERT INTO accidents(ssnPatient,year,details,fractures) VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.injuriesDGV.Rows[i].Cells[0].Value.ToString() + "'" +
                                ",N'" + this.injuriesDGV.Rows[i].Cells[1].Value.ToString() + "',N'" + this.injuriesDGV.Rows[i].Cells[2].Value.ToString() + "')";
                            conDataBase = new SqlConnection(constring);
                            adapter = new SqlDataAdapter();
                            command = new SqlCommand(Query, conDataBase);
                            conDataBase.Open();
                            adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                            adapter.InsertCommand.ExecuteNonQuery();
                            command.Dispose();
                            conDataBase.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        void saveSecondPage()
        {
            if (secondPageTextBoxValidation())
            {
                try
                {
                    string Query;
                    SqlConnection conDataBase;
                    SqlDataAdapter adapter;
                    SqlCommand command;
                    string anotherIncome = "";
                    string loanProblems = "";
                    string jobSatisfacton = "";
                    if (yesAIRB.Checked)
                    {
                        anotherIncome = anotherIncomeTextBox.Text;
                    }

                    if (yesFPRB.Checked)
                    {
                        loanProblems = financialProblemsTextBox.Text;
                    }
                    if (miserableJobCB.Checked)
                    {
                        jobSatisfacton = miserableJobReasonTextBox.Text;
                    }

                    string othersString = "";
                    if (othersTraitsCB.Checked)
                    {
                        othersString = behavioralTraitsOthersTextBox.Text;
                    }

                    string patientBossRelation = "";
                    string patientCoworkerRelation = "";
                    string patientWorkRegularity = "";
                    string patientEconomicStatus = (economicStatusGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    string patientHome = (houseGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    string patientHomeType = (homeTypeGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    if (patientHome == "أخرى")
                    {
                        patientHome = otherHomeTextBox.Text;
                    }

                    bool hasOwnRoom;
                    string shareRoomWith = "";
                    if (loneRoomRB.Checked)
                    {
                        hasOwnRoom = true;
                        shareRoomWith = "";
                    }
                    else
                    {
                        hasOwnRoom = false;
                        shareRoomWith = shareRoomWithTextBox.Text;
                    }
                    if ((singleRB.Checked && adultRB.Checked) || (!adultRB.Checked))
                    {
                        shareRoomWith = "";
                    }

                    // if (adultRB.Checked)
                    // {
                    if (workDGV.Rows.Count - 1 > 0)
                    {
                        patientBossRelation = (relationsWithHeadsGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                        patientCoworkerRelation = (relationsWithCoworkersGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                        patientWorkRegularity = (regularityInjobGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    }

                    Query = "IF NOT EXISTS (select 1 FROM socialCharacteristics where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                        "socialCharacteristics(ssnPatient,aggressive,depressive,anixious,doubtful,otherCharacteristics,bossRelation,cooworkersRelations,jobRegularity,economicStatus,anotherIncome,home,homeType,roomCount,haveOwnRoom,shareRoomWith,loan) " +
                        "VALUES(N'" + this.SSNTextBox.Text + "',N'" + this.aggressiveCB.Checked + "',N'" + this.depressedCB.Checked + "',N'" + this.anixiousCB.Checked + "',N'" + this.doubtfullCB.Checked + "',N'" + othersString + "'" +
                        ",N'" + patientBossRelation + "',N'" + patientCoworkerRelation + "',N'" + patientWorkRegularity + "',N'" + patientEconomicStatus + "',N'" + anotherIncome + "',N'" + patientHome + "',N'" + patientHomeType + "',N'" + this.bedroomsCountTextBox.Text + "'" +
                        ",N'" + hasOwnRoom + "',N'" + shareRoomWith + "',N'" + loanProblems + "') END ";

                    conDataBase = new SqlConnection(constring);
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();

                    for (int i = 0; i < workDGV.Rows.Count - 1; i++)
                    {
                        Query = "INSERT INTO employerDetails(ssnPatient,employer,workNature,unsatisfied,unsatisfiedDetails,notes,workAge,fromDate,toDate) " +
                        "VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.workDGV.Rows[i].Cells[0].Value.ToString() + "',N'" + this.workDGV.Rows[i].Cells[1].Value.ToString() + "'" +
                        ",N'" + this.workDGV.Rows[i].Cells[2].Value.ToString() + "',N'" + this.workDGV.Rows[i].Cells[3].Value.ToString() + "',N'" + workDGV.Rows[i].Cells[4].Value.ToString() + "'" +
                        ",N'" + workDGV.Rows[i].Cells[5].Value.ToString() + "',N'" + workDGV.Rows[i].Cells[6].Value.ToString() + "',N'" + workDGV.Rows[i].Cells[7].Value.ToString() + "')";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        void saveThirdPage()
        {
            if (thirdPageTextBoxValidation())
            {
                try
                {
                    string Query;
                    SqlConnection conDataBase;
                    SqlDataAdapter adapter;
                    SqlCommand command;
                    if (!noAttemptsRB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM suicideAttempts where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO suicideAttempts(ssnPatient,attemptStatus,way,details,notes) VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.SuicideAttempts + "',N'" + this.suicideWayTextBox.Text + "',N'" + this.suicideDetailsTextBox.Text + "',N'" + this.suicideNotesTextBox.Text + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }
                    else if (noAttemptsRB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM suicideAttempts where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO suicideAttempts(ssnPatient,attemptStatus) VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.SuicideAttempts + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }

                    if (warehouseCB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM warehouse where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO warehouse(ssnPatient,entered,count,details) VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.warehouseCB.Checked + "',N'" + this.warehouseCountsTextBox.Text + "',N'" + this.warehouseDetailsTextBox.Text + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }
                    else if (!warehouseCB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM warehouse where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO warehouse(ssnPatient,entered) VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.warehouseCB.Checked + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }

                    if (blackoutCB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM unconsioussness where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO unconsioussness(ssnPatient,occurence,count,details) VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.blackoutCB.Checked + "',N'" + this.blackoutCountsTextBox.Text + "',N'" + this.blackoutDetailsTextBox.Text + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }
                    else if (!blackoutCB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM unconsioussness where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO unconsioussness(ssnPatient,occurence) VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.blackoutCB.Checked + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }


                    if (!noUseRB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM drugsAbuse where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO drugsAbuse(ssnPatient,currentStatus,startingAge,drugsType,duration,details) VALUES (N'" + this.SSNTextBox.Text + "',N'" + drugAbuse + "',N'" + this.startingAgeTextBox.Text + "',N'" + this.TypesUsedTextBox.Text + "',N'" + this.totalDurationTextBox.Text + "',N'" + this.drugUsedDetailsTextBox.Text + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }
                    else if (noUseRB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM drugsAbuse where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO drugsAbuse(ssnPatient,currentStatus) VALUES (N'" + this.SSNTextBox.Text + "',N'" + drugAbuse + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }
                    string previousTreatmentHistory = "";
                    if (previousPatientHistoryNotesTextBox.Text != "ملاحظات التاريخ المرضي السابق")
                    {
                        previousTreatmentHistory = previousPatientHistoryNotesTextBox.Text;
                    }
                    Query = "UPDATE patientInfo SET previousTreatment=N'" + this.previousTreatmentCB.Checked + "', previousTreatmentNotes= N'" + previousTreatmentHistory + "' where ssn=N'" + this.SSNTextBox.Text + "'";

                    conDataBase = new SqlConnection(constring);
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();

                    if (previousTreatmentCB.Checked)
                    {
                        for (int i = 0; i < treatmentPlacesDGV.Rows.Count - 1; i++)
                        {
                            Query = "INSERT INTO previousTreatment(ssnPatient,hospital,doctor,caseNo,notes) VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.treatmentPlacesDGV.Rows[i].Cells[0].Value.ToString() + "'" +
                                ",N'" + this.treatmentPlacesDGV.Rows[i].Cells[1].Value.ToString() + "',N'" + this.treatmentPlacesDGV.Rows[i].Cells[2].Value.ToString() + "',N'" + this.treatmentPlacesDGV.Rows[i].Cells[3].Value.ToString() + "')";
                            conDataBase = new SqlConnection(constring);
                            adapter = new SqlDataAdapter();
                            command = new SqlCommand(Query, conDataBase);
                            conDataBase.Open();
                            adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                            adapter.InsertCommand.ExecuteNonQuery();
                            command.Dispose();
                            conDataBase.Close();
                        }
                    }

                    Query = "IF NOT EXISTS (select 1 FROM familyPreviousHistory where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO familyPreviousHistory(ssnPatient,existenceOfFamilyHistory,details) VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.familyIllnessCB.Checked + "',N'" + this.familyIllnessDetailsTextBox.Text + "') END ";

                    conDataBase = new SqlConnection(constring);
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        void saveFourthPage()
        {
            if (fourthPageTextBoxValidation())
            {
                try
                {
                    string Query;
                    SqlConnection conDataBase;
                    SqlDataAdapter adapter;
                    SqlCommand command;

                    //Female Adult and not single
                    if (!msSingleRB.Checked && !maleRB.Checked && adultRB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM maritalStatus where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                                   "maritalStatus(ssnPatient,maritalStatusReason,totalMariageNumber,ageAtMarriage,ageAtProcreation) " +
                                   "VALUES(N'" + this.SSNTextBox.Text + "',N'" + this.maritalStausReasonsTextBox.Text + "',N'" + this.totalPatientMarriageTextBox.Text + "'" +
                                   ",N'" + this.ageAtMarriageFemaleTextBox.Text + "',N'" + this.ageAtProcreationFemaleTextBox.Text + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }
                    //Male Adult and not single
                    else if (!msSingleRB.Checked && maleRB.Checked && adultRB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM maritalStatus where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                                  "maritalStatus(ssnPatient,maritalStatusReason,totalMariageNumber) " +
                                  "VALUES(N'" + this.SSNTextBox.Text + "',N'" + this.maritalStausReasonsTextBox.Text + "',N'" + this.totalPatientMarriageTextBox.Text + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }
                    //Single or no Adult
                    else if ((msSingleRB.Checked || !adultRB.Checked))
                    {
                        Query = "IF NOT EXISTS (select 1 FROM maritalStatus where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                                  "maritalStatus(ssnPatient,maritalStatusReason) " +
                                  "VALUES(N'" + this.SSNTextBox.Text + "',N'" + this.maritalStausReasonsTextBox.Text + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }

                    //Patient Marriage Details Table for all not sngle adults

                    if (!msSingleRB.Checked && adultRB.Checked)
                    {
                        for (int i = 0; i < patientMaritalStatusDGV.Rows.Count - 1; i++)
                        {
                            Query = "INSERT INTO patientMarriageDetails(ssnPatient,marriageOrder,relativeMarriage,relativeSide,boys,girls,total,spouseNationality,duration,fromDate,toDate) VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.patientMaritalStatusDGV.Rows[i].Cells[0].Value.ToString() + "',N'" + this.patientMaritalStatusDGV.Rows[i].Cells[1].Value.ToString() + "',N'" + this.patientMaritalStatusDGV.Rows[i].Cells[2].Value.ToString() + "'" +
                                ",N'" + this.patientMaritalStatusDGV.Rows[i].Cells[3].Value.ToString() + "',N'" + this.patientMaritalStatusDGV.Rows[i].Cells[4].Value.ToString() + "',N'" + this.patientMaritalStatusDGV.Rows[i].Cells[5].Value.ToString() + "',N'" + this.patientMaritalStatusDGV.Rows[i].Cells[6].Value.ToString() + "',N'" + this.patientMaritalStatusDGV.Rows[i].Cells[7].Value.ToString() + "'" +
                                ",N'" + this.patientMaritalStatusDGV.Rows[i].Cells[8].Value.ToString() + "',N'" + this.patientMaritalStatusDGV.Rows[i].Cells[9].Value.ToString() + "')";
                            conDataBase = new SqlConnection(constring);
                            adapter = new SqlDataAdapter();
                            command = new SqlCommand(Query, conDataBase);
                            conDataBase.Open();
                            adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                            adapter.InsertCommand.ExecuteNonQuery();
                            command.Dispose();
                            conDataBase.Close();
                        }
                    }
                    // Siblings Query
                    string patientResponisibilityTowards = (familyResponsibilitiesGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    if (patientResponisibilityTowards == "آخرين")
                    {
                        patientResponisibilityTowards = otherResponsibilitiesTextBox.Text;
                    }
                    Query = "IF NOT EXISTS (select 1 FROM siblingsDetails where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                                   "siblingsDetails(ssnPatient,brothers,sisters,totalSiblings,patientOrder,nearestPerson,responsibleForCount,responsibleForDescription,responsiblitiesToward,pressuredFromResponsibility) " +
                                   "VALUES(N'" + this.SSNTextBox.Text + "',N'" + this.brothersCountTextBox.Text + "',N'" + this.sistersCoutTextBox.Text + "'" +
                                   ",N'" + this.totalMembersTextBox.Text + "',N'" + this.patientOrderTextBox.Text + "',N'" + this.nearestFamilyMemberTextBox.Text + "',N'" + this.responsibleForCoutTextBox.Text + "'" +
                                   ",N'" + this.responsibleForDescriptionTextBox.Text + "',N'" + patientResponisibilityTowards + "',N'" + this.pressureCheckBox.Checked + "') END ";

                    conDataBase = new SqlConnection(constring);
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        void saveFifthPage()
        {
            if (fifthPageTextBoxValidation())
            {
                try
                {
                    string Query;
                    SqlConnection conDataBase;
                    SqlDataAdapter adapter;
                    SqlCommand command;

                    string fatherStatus = (fatherStatusGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    string motherStatus = (motherStatusGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;

                    Query = "IF NOT EXISTS (select 1 FROM fatherMaritalStatus where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                                    "fatherMaritalStatus(ssnPatient,fatherStatus,totalMarriages,nationality,education) " +
                                    "VALUES(N'" + this.SSNTextBox.Text + "',N'" + fatherStatus + "',N'" + this.totalFatherMarriageTextBox.Text + "'" +
                                    ",N'" + this.fatherNationalityTextBox.Text + "',N'" + this.fatherEducationLevelTextBox.Text + "') END ";

                    conDataBase = new SqlConnection(constring);
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();

                    for (int i = 0; i < fatherDGV.Rows.Count - 1; i++)
                    {
                        Query = "INSERT INTO fatherMarriageDetails(ssnPatient,marriageOrder,fatherRelativeMarriage,fatherRelativeSide, boys,girls,total,spouseNationality,duration) " +
                            "VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.fatherDGV.Rows[i].Cells[0].Value.ToString() + "',N'" + this.fatherDGV.Rows[i].Cells[1].Value.ToString() + "',N'" + this.fatherDGV.Rows[i].Cells[2].Value.ToString() + "'" +
                            ",N'" + this.fatherDGV.Rows[i].Cells[3].Value.ToString() + "',N'" + this.fatherDGV.Rows[i].Cells[4].Value.ToString() + "',N'" + this.fatherDGV.Rows[i].Cells[5].Value.ToString() + "'" +
                            ",N'" + this.fatherDGV.Rows[i].Cells[6].Value.ToString() + "',N'" + this.fatherDGV.Rows[i].Cells[7].Value.ToString() + "')";
                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }

                    Query = "IF NOT EXISTS (select 1 FROM motherMaritalStatus where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                                    "motherMaritalStatus(ssnPatient,motherStatus,totalMarriages,nationality,education) " +
                                    "VALUES(N'" + this.SSNTextBox.Text + "',N'" + motherStatus + "',N'" + this.totalMotherMarriageTextBox.Text + "'" +
                                    ",N'" + this.motherNationalityTextBox.Text + "',N'" + this.motherEducationLevelTextBox.Text + "') END ";

                    conDataBase = new SqlConnection(constring);
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();

                    for (int i = 0; i < motherDGV.Rows.Count - 1; i++)
                    {
                        Query = "INSERT INTO motherMarriageDetails(ssnPatient,marriageOrder,motherRelativeMarriage, motherRelativeSide, boys,girls,total,spouseNationality,duration) " +
                            "VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.motherDGV.Rows[i].Cells[0].Value.ToString() + "',N'" + this.motherDGV.Rows[i].Cells[1].Value.ToString() + "',N'" + this.motherDGV.Rows[i].Cells[2].Value.ToString() + "'" +
                            ",N'" + this.motherDGV.Rows[i].Cells[3].Value.ToString() + "',N'" + this.motherDGV.Rows[i].Cells[4].Value.ToString() + "',N'" + this.motherDGV.Rows[i].Cells[5].Value.ToString() + "'" +
                            ",N'" + this.motherDGV.Rows[i].Cells[6].Value.ToString() + "',N'" + this.motherDGV.Rows[i].Cells[7].Value.ToString() + "')";
                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        void saveSixthPage()
        {
            if (sixthPageTextBoxValidation())
            {
                try
                {
                    string duration = (groupBox23.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    string shortcomingCoverage = (shortcomingSourceGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    if (shortcomingCoverage == "أخرى")
                    {
                        shortcomingCoverage = otherSourceTextBox.Text;
                    }

                    string Query;
                    SqlConnection conDataBase;
                    SqlDataAdapter adapter;
                    SqlCommand command;

                    Query = "IF NOT EXISTS (select 1 FROM teenEconomicStatus where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                                        "teenEconomicStatus(ssnPatient,amount,amountType,wasEnough,shortComeCoverage) " +
                                        "VALUES(N'" + this.SSNTextBox.Text + "',N'" + this.pocketMoneyTextBox.Text + "',N'" + duration + "'" +
                                        ",N'" + this.pocketMoneyIsEnoughCB.Checked + "',N'" + shortcomingCoverage + "') END ";

                    conDataBase = new SqlConnection(constring);
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();

                    for (int i = 0; i < schoolStageDGV.Rows.Count - 1; i++)
                    {
                        Query = "INSERT INTO teenStudyPhaseDetails(ssnPatient,stage,schoolName, failureYears, notes) " +
                            "VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.schoolStageDGV.Rows[i].Cells[0].Value.ToString() + "',N'" + this.schoolStageDGV.Rows[i].Cells[1].Value.ToString() + "',N'" + this.schoolStageDGV.Rows[i].Cells[2].Value.ToString() + "'" +
                            ",N'" + this.schoolStageDGV.Rows[i].Cells[3].Value.ToString() + "')";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }
                    string hatedSchoolReason = "";
                    string badStudentsRelationsReason = "";
                    string grades = (educationLevelGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    string badTeachersRelationsReasondes = (badRelationsWithTeachersGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;

                    if (hatedSchoolRB.Checked)
                    {
                        hatedSchoolReason = hatedSchoolTextBox.Text;
                    }
                    if (badRelationWithStudentsRB.Checked)
                    {
                        badStudentsRelationsReason = badRelationWithStudentsReasonTextBox.Text;
                    }
                    if (otherReaonsBadTeacherRelationRB.Checked)
                    {
                        badTeachersRelationsReasondes = otherReaonsBadTeacherRelationTextBox.Text;
                    }
                    Query = "IF NOT EXISTS (select 1 FROM teenSchoolGeneral where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                                        "teenSchoolGeneral(ssnPatient,likedScool,hatedSchoolReasons,realtionWithStudents,badStudentsRelationReasons,studentGrades,badRelationWithteachers,reasons) " +
                                        "VALUES(N'" + this.SSNTextBox.Text + "',N'" + this.lovedSchoolRB.Checked + "',N'" + hatedSchoolReason + "',N'" + this.goodRelationWithStudentsRB.Checked + "'" +
                                        ",N'" + badStudentsRelationsReason + "',N'" + grades + "',N'" + this.badRelationWithTeachersCB.Checked + "',N'" + badTeachersRelationsReasondes + "') END ";

                    conDataBase = new SqlConnection(constring);
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        void saveSeventhPage()
        {
            if (seventhPageTextBoxValidation())
            {
                string prayerValdation = (prayerGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                string quranValidation = (quranGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                string ramadanValidation = (ramadanGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                string convictedMember = "";
                string convictionDetails = "";
                if (convictedFamilyMemberCB.Checked)
                {
                    convictedMember = (convictedMemberGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                    convictionDetails = familyMemberConvictedTextBox.Text;
                }
                else
                {
                    convictedMember = "";
                    convictionDetails = "";
                }

                string drugAbuseMember = "";
                if (drugAbuseFamilyMemberCB.Checked)
                {
                    drugAbuseMember = (drugAbuseFamilyMemberGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                }
                else
                {
                    drugAbuseMember = "";
                }

                string emailPurpose = "";
                if (haveEmailCB.Checked)
                {
                    emailPurpose = (emailPurposeGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                }
                else
                {
                    emailPurpose = "";
                }

                string mostVisitedSites = (mostVisitedGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;

                string travelledOutside = "";
                if (travelledCB.Checked)
                {
                    travelledOutside = whichCountriesTextBox.Text;
                }
                else
                {
                    travelledOutside = "";
                }

                string socialRelationsValidation = (socialRelationsValidationGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                string motivationsThreeEvaluation = (motivationsThreeEvaluationGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;

                try
                {
                    string Query;
                    SqlConnection conDataBase;
                    SqlDataAdapter adapter;
                    SqlCommand command;

                    Query = "IF NOT EXISTS (select 1 FROM teenBehavior where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                                        "teenBehavior(ssnPatient,prayer,quran,fastingRamadan,convictedFamilyMember,whoConvictedMember,convictionDetails,drugsAddictedFamilyMember,whoDrugMember) " +
                                        "VALUES(N'" + this.SSNTextBox.Text + "',N'" + prayerValdation + "',N'" + quranValidation + "',N'" + ramadanValidation + "',N'" + this.convictedFamilyMemberCB.Checked + "'" +
                                        ",N'" + convictedMember + "',N'" + convictionDetails + "',N'" + this.drugAbuseFamilyMemberCB.Checked + "',N'" + drugAbuseMember + "') END ";

                    conDataBase = new SqlConnection(constring);
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();

                    Query = "IF NOT EXISTS (select 1 FROM teenFreeTime where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                                        "teenFreeTime(ssnPatient,timeSpent,haveEmail,emailReason,mostVisitedSites,traveledBefore,countriesVisited) " +
                                        "VALUES(N'" + this.SSNTextBox.Text + "',N'" + this.freeTimeTextBox.Text + "',N'" + this.haveEmailCB.Checked + "',N'" + emailPurpose + "',N'" + mostVisitedSites + "'" +
                                        ",N'" + this.travelledCB.Checked + "',N'" + travelledOutside + "') END ";

                    conDataBase = new SqlConnection(constring);
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();

                    Query = "IF NOT EXISTS (select 1 FROM teenRelation where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                                       "teenRelation(ssnPatient,socialRelations,familyRelations,familyEvaluation,chaningMotivation,motivationEvaluation,socialSituationSummary) " +
                                          "VALUES(N'" + this.SSNTextBox.Text + "',N'" + this.patientSocialStatusTextBox.Text + "',N'" + this.familyTextBox.Text + "',N'" + socialRelationsValidation + "',N'" + this.motivationsTextBox.Text + "'" +
                                       ",N'" + motivationsThreeEvaluation + "',N'" + this.socialStatusAbstractRB.Text + "') END ";

                    conDataBase = new SqlConnection(constring);
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        bool saveEigthPage()
        {
            if (eigthPageTextBoxValidation())
            {
                string meetingType = (meetingTypeGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                string meetingTitle;
                if (newMeetingRB.Checked)
                {
                    meetingTitle = meetingTitleTextBox.Text;
                }
                else
                {
                    meetingTitle = meetingTitleComboBox.Text;

                }

                SqlConnection con;
                con = new SqlConnection(constring);

                con.Open();
                string name = new SqlCommand("IF EXISTS(Select 1 from periodicMeetings where meetingTitle=N'" + meetingTitle + "' ) BEGIN Select 1 from periodicMeetings where meetingTitle=N'" + meetingTitle + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
                if (name == "0")
                {
                    string Query;
                    SqlConnection conDataBase;
                    SqlDataAdapter adapter;
                    SqlCommand command;

                    Query = "INSERT INTO periodicMeetings(meetingType,socialSide,socialMainProgram,socialAlterBehavior,psychologicalSide,psychologicalMainProgram,psychologicalAlterBehavior,religiousSide,meetingTitle,meetingDate,signingDate,meetingTarget,meetingContent,recommendations) " +
                                        "VALUES(N'" + meetingType + "',N'" + this.socialSideCB.Checked + "',N'" + this.mainProgramSocialCB.Checked + "',N'" + this.alterBehaviorSocialCB.Checked + "',N'" + this.psychologicalSideCB.Checked + "'" +
                                        ",N'" + this.mainProgramPsychologicalCB.Checked + "',N'" + this.alterBehaviorPsychologicalCB.Checked + "',N'" + this.religiousSideCB.Checked + "',N'" + meetingTitle + "',N'" + this.meetingDate.Value.ToString("MM/dd/yyyy") + "'" +
                                        ",N'" + this.registeringDate.Value.ToString("MM/dd/yyyy") + "',N'" + this.meetingPurposeTextBox.Text + "',N'" + this.meetingContentTextBox.Text + "',N'" + this.recommendationTextBox.Text + "')";
                    conDataBase = new SqlConnection(constring);
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand(Query, conDataBase);
                    conDataBase.Open();
                    adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();
                    conDataBase.Close();

                    conDataBase = new SqlConnection(constring);
                    conDataBase.Open();
                    string Id = new SqlCommand("Select Id from periodicMeetings where meetingType=N'" + meetingType + "' AND meetingTitle=N'" + meetingTitle + "' AND meetingDate=N'" + this.meetingDate.Value.ToString("MM/dd/yyyy") + "' AND signingDate=N'" + this.registeringDate.Value.ToString("MM/dd/yyyy") + "' " +
                        "AND meetingTarget= N'" + this.meetingPurposeTextBox.Text + "'AND meetingContent = N'" + this.meetingContentTextBox.Text + "' AND recommendations = N'" + this.recommendationTextBox.Text + "'", conDataBase).ExecuteScalar().ToString();
                    conDataBase.Close();


                    for (int i = 0; i < targetDGV.Rows.Count - 1; i++)
                    {
                        Query = "INSERT INTO periodicMeetingsDetails(idMainMeeting,ssnPatient,name, nationality, age,caseFile) " +
                            "VALUES (N'" + Id + "',N'" + this.targetDGV.Rows[i].Cells[0].Value.ToString() + "',N'" + this.targetDGV.Rows[i].Cells[1].Value.ToString() + "',N'" + this.targetDGV.Rows[i].Cells[2].Value.ToString() + "'" +
                            ",N'" + this.targetDGV.Rows[i].Cells[3].Value.ToString() + "',N'" + this.targetDGV.Rows[i].Cells[4].Value.ToString() + "')";
                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show($"يرجى تغيير عنوان المقابلة نظرًا لأنه موجود في قاعدة البيانات مسبقًا ولا يمكن إضافة عناوين مشابهة لأنها نقطة المركز في الصفحة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        // 2s DB Information



        // 3s DB Information

        private void addPlaceButton_Click(object sender, EventArgs e)
        {
            if (previousTreatmentDGVVAlidation_thirdPage())
            {
                string[] row = { hospitalTreatmentTextBox.Text, doctorTreatmentTextBox.Text, fileNumberTreatmentTextBox.Text, notesTreatmentTextBox.Text };
                treatmentPlacesDGV.Rows.Add(row);
                clearingTreatmentPlacesDGVDGV_4thPage();
            }
        }
        private void addWorkDurationButton_Click(object sender, EventArgs e)
        {
            if (employerDGVValidation_secondPage())
            {
                patientWorkNature = (workNatureGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;
                string miserableJobDetails = "";
                if (patientWorkNature == "أخرى")
                {
                    patientWorkNature = workingNatureOthersTextBox.Text;
                }

                if (miserableJobCB.Checked)
                {
                    miserableJobDetails = miserableJobReasonTextBox.Text;
                }
                string[] row = { entityWorkTextBox.Text, patientWorkNature, miserableJobCB.Checked.ToString(), miserableJobDetails, notesWorkTextBox.Text, workStartAgeTextBox.Text, this.workFromDate.Value.ToString("MM/dd/yyyy"), this.workToDate.Value.ToString("MM/dd/yyyy") };
                workDGV.Rows.Add(row);
                clearingEmployersDGV_3rdPage();
            }
        }


        // 4s DB Information

        private void addPatientMaritalStatusButton_Click(object sender, EventArgs e)
        {
            if (patientMarriageDGVValidation())
            {
                bool relativeBool = yesRelativeRB.Checked;
                string[] row = { marriagePatientOrderTextBox.Text, relativeBool.ToString(), patientMarriageSideComboBox.Text, boysCountPatientsTextBox.Text, girlsCountPatientsTextBox.Text, totalSonsTextBox.Text, husbandNationalityTextBox.Text, marriageDurationTextBox.Text, this.marriageFromDate.Value.ToString("MM/dd/yyyy"), this.marriageToDate.Value.ToString("MM/dd/yyyy") };
                patientMaritalStatusDGV.Rows.Add(row);
                clearingpatientMaritalStatusDGV_5thPage();
            }
        }


        // 5s DB Information

        private void fatherMarriageDetailsAddButton_Click(object sender, EventArgs e)
        {
            if (fatherMarriageDGVValidation())
            {
                string relativeSide = "";
                if (yesFatherRelativeRB.Checked)
                {
                    relativeSide = fatherMarriageSideComboBox.Text;
                }
                string[] row = { fatherMariiageOrderTextBox.Text, yesFatherRelativeRB.Checked.ToString(), relativeSide, fatherBoysCountTextBox.Text, fatherGirlsCountTextBox.Text, fatherTotalKidsTextBox.Text, wifeFatherNationalityTextBox.Text, fatherMarriageDurationTextBox.Text };
                fatherDGV.Rows.Add(row);
                clearingFatherMariageDGV_6thPage();
            }
        }

        private void motherMarriageDetailsAddButton_Click(object sender, EventArgs e)
        {
            if (motherMarriageDGVValidation())
            {
                string relativeSide = "";
                if (yesMotherRelativeRB.Checked)
                {
                    relativeSide = motherMarriageSideComboBox.Text;
                }
                string[] row = { motherMariiageOrderTextBox.Text, yesMotherRelativeRB.Checked.ToString(), relativeSide, motherBoysCountTextBox.Text, motherGirlsCountTextBox.Text, motherTotalKidsTextBox.Text, husbandMotherTextBox.Text, motherMarriageDurationTextBox.Text };
                motherDGV.Rows.Add(row);
                clearingMotherMariageDGV_6thPage();
            }
        }




        private void schoolAddButton_Click(object sender, EventArgs e)
        {
            if (schoolStageValidation_sixthPage())
            {
                if (String.IsNullOrEmpty(schoolFailureYearsTextBox.Text))
                {
                    schoolFailureYearsTextBox.Text = "0";
                }
                string[] row = { schoolStageComboBox.Text, schoolNameTextBox.Text, schoolFailureYearsTextBox.Text, schoolNotesTextBox.Text };
                schoolStageDGV.Rows.Add(row);
                clearingTeenSchoolStagesDGV_7thPage();
            }
        }

        private void addTargetButton_Click(object sender, EventArgs e)
        {
            if (targetOfMeeting_eightPage())
            {
                string[] row = { ssnNumberTargetTextBox.Text, nameTargetTextBox.Text, nationalityTargetTextBox.Text, ageTargetTextBox.Text, caseTargetTextBox.Text };
                targetDGV.Rows.Add(row);
                clearingMeetingDGV_9thPage();
                if ((targetDGV.Rows.Count - 1) > 1)
                {
                    groupMeetingRB.Checked = true;
                }
                else if ((targetDGV.Rows.Count - 1) == 1)
                {
                    individualMeetingRB.Checked = true;
                }
            }
        }
        private void targetDGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if ((targetDGV.Rows.Count - 1) > 1)
            {
                groupMeetingRB.Checked = true;
            }
            else if ((targetDGV.Rows.Count - 1) == 1)
            {
                individualMeetingRB.Checked = true;
            }
        }

        private void ssnNumberTargetTextBox_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conDataBase = new SqlConnection(constring);
            conDataBase.Open();
            string name = new SqlCommand("IF EXISTS(Select 1 from patientInfo where ssn=N'" + this.ssnNumberTargetTextBox.Text + "' ) BEGIN Select name from patientInfo where ssn=N'" + this.ssnNumberTargetTextBox.Text + "' END ELSE BEGIN SELECT 0 END", conDataBase).ExecuteScalar().ToString();
            string nationality = new SqlCommand("IF EXISTS(Select 1 from patientInfo where ssn=N'" + this.ssnNumberTargetTextBox.Text + "' ) BEGIN Select nationality from patientInfo where ssn=N'" + this.ssnNumberTargetTextBox.Text + "' END ELSE BEGIN SELECT 0 END", conDataBase).ExecuteScalar().ToString();
            string age = new SqlCommand("IF EXISTS(Select 1 from patientInfo where ssn=N'" + this.ssnNumberTargetTextBox.Text + "' ) BEGIN Select age from patientInfo where ssn=N'" + this.ssnNumberTargetTextBox.Text + "' END ELSE BEGIN SELECT 0 END", conDataBase).ExecuteScalar().ToString();
            string casePatient = new SqlCommand("IF EXISTS(Select 1 from patientInfo where ssn=N'" + this.ssnNumberTargetTextBox.Text + "' ) BEGIN Select caseFile from patientInfo where ssn=N'" + this.ssnNumberTargetTextBox.Text + "' END ELSE BEGIN SELECT 0 END", conDataBase).ExecuteScalar().ToString();
            conDataBase.Close();

            if (name != "0")
            {
                nameTargetTextBox.Text = name;
            }
            if (nationality != "0")
            {
                nationalityTargetTextBox.Text = nationality;
            }
            if (age != "0")
            {
                ageTargetTextBox.Text = age;
            }
            if (casePatient != "0")
            {
                caseTargetTextBox.Text = casePatient;
            }
        }

        private void workDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (workDGV.Rows.Count - 1 > 0)
            {
                unemployedNotifinigLabel.Visible = false;
            }
            else
            {
                unemployedNotifinigLabel.Visible = true;
            }
        }

        private void workDGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (workDGV.Rows.Count - 1 > 0)
            {
                unemployedNotifinigLabel.Visible = false;
            }
            else
            {
                unemployedNotifinigLabel.Visible = true;
            }
        }

        private void SSNTextBox_TextChanged(object sender, EventArgs e)
        {

            if (availableSSN())
            {
                loadingFrstPage();
                loadingSecondPage();
                loadingThirdPage();
                loadingFourthPage();
                loadingFifthPage();
                loadingSixthPage();
                if (teenRB.Checked)
                {
                    loadingSeventhPage();
                    loadingEigthPage();
                }
            }
        }

        bool availableSSN()
        {
            SqlConnection con;
            con = new SqlConnection(constring);

            con.Open();
            string name = new SqlCommand("IF EXISTS(Select 1 from patientInfo where ssn=N'" + this.SSNTextBox.Text + "' ) BEGIN Select 1 from patientInfo where ssn=N'" + this.SSNTextBox.Text + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
            if (name == "1")
            {
                ToggleConditionButton.IsOn = false;
                editCaseRB.Checked = true;
                con.Close();
                return true;
            }
            else if (name == "0")
            {
                con.Close();
                if (ToggleConditionButton.IsOn == false && (SSNTextBox.Text.Length == 15))
                {
                    ToggleConditionButton.IsOn = true;
                    newCaseRB.Checked = true;
                    ClearAll();
                }

                return false;
            }
            con.Close();
            return false;
        }
        bool availableSSNOptional(string ssnOpt)
        {
            SqlConnection con;
            con = new SqlConnection(constring);
            con.Open();
            string name = new SqlCommand("IF EXISTS(Select 1 from patientInfo where ssn=N'" + ssnOpt + "' ) BEGIN Select 1 from patientInfo where ssn=N'" + ssnOpt + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
            if (name == "1")
            {
                ToggleConditionButton.IsOn = false;
                editCaseRB.Checked = true;
                con.Close();
                return true;
            }
            else if (name == "0")
            {
                con.Close();
                if (ToggleConditionButton.IsOn == false && (SSNTextBox.Text.Length == 15))
                {
                    ToggleConditionButton.IsOn = true;
                    newCaseRB.Checked = true;
                    ClearAll();
                }

                return false;
            }
            con.Close();
            return false;
        }

        void loadingFrstPage()
        {


            SqlDataReader rdr;
            SqlConnection con;
            SqlCommand cmd;

            con = new SqlConnection(constring);

            con.Open();

            string CommandText = "IF EXISTS(Select 1 from patientInfo where ssn=N'" + this.SSNTextBox.Text + "' ) BEGIN SELECT name,age,nationality,phoneNumber,residencePlace,length,weight,waist,languistics,walking,muscles,caseFile,judge,birthDay,maritalStatus,sex,type,adultType,canBeCalledAgain,signDate,previousTreatment,accidents FROM patientInfo where ssn=N'" + this.SSNTextBox.Text + "' END";
            cmd = new SqlCommand(CommandText);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                this.nameTextBox.Text = rdr["name"].ToString();
                this.ageTextBox.Text = rdr["age"].ToString();
                this.nationalityTextBox.Text = rdr["nationality"].ToString();
                this.residencePlaceTextBox.Text = rdr["residencePlace"].ToString();
                this.phoneNumberTextBox.Text = rdr["phoneNumber"].ToString();
                this.caseTextBox.Text = rdr["caseFile"].ToString();
                this.judgementTextBox.Text = rdr["judge"].ToString();
                this.heightTextBox.Text = rdr["length"].ToString();
                this.weightTextBox.Text = rdr["weight"].ToString();
                this.waistTextBox.Text = rdr["waist"].ToString();
                this.walkingTexBox.Text = rdr["walking"].ToString();
                this.musclesTextBox.Text = rdr["muscles"].ToString();
                this.birthDayTP.Text = rdr["birthDay"].ToString();
                this.canBeCalledAgainCB.Checked = (Boolean)(rdr["canBeCalledAgain"]);
                this.dateDTP.Text = rdr["signDate"].ToString();
                this.previousTreatmentCB.Checked = (Boolean)(rdr["previousTreatment"]);
                this.anyInjuriesCB.Checked = (Boolean)(rdr["accidents"]);

                string sex = rdr["sex"].ToString();
                foreach (var rb in groupBox7.Controls.OfType<RadioButton>())
                {
                    if (rb.Text == sex)
                    {
                        rb.Checked = true;
                    }
                }

                string linguistics = rdr["languistics"].ToString();
                foreach (var rb in linguisticGB.Controls.OfType<RadioButton>())
                {
                    if (rb.Text == linguistics)
                    {
                        rb.Checked = true;
                    }
                }

                string maritalStatus = rdr["maritalStatus"].ToString();
                foreach (var rb in maritalStatusGB.Controls.OfType<RadioButton>())
                {
                    if (rb.Text == maritalStatus)
                    {
                        rb.Checked = true;
                    }
                }

                string type = rdr["type"].ToString();
                foreach (var rb in groupBox8.Controls.OfType<RadioButton>())
                {
                    if (rb.Text == type)
                    {
                        rb.Checked = true;
                    }
                }

                string adultType = rdr["adultType"].ToString();
                foreach (var rb in adultTypeGB.Controls.OfType<RadioButton>())
                {
                    if (rb.Text == adultType)
                    {
                        rb.Checked = true;
                    }
                }
            }
            con.Close();


            con.Open();
            string name = new SqlCommand("IF EXISTS(Select 1 from rehabilation where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select 1 from rehabilation where ssnPatient=N'" + this.SSNTextBox.Text + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
            enteredInstituteDGV.Rows.Clear();
            enteredInstituteDGV.Refresh();
            enteredInstituteCB.Checked = false;

            try
            {
                if (name != "0")
                {
                    enteredInstituteCB.Checked = true;
                    string Query = "IF EXISTS(Select 1 from rehabilation where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select year , caseFile ,judgement, entranceAge, notes from rehabilation where ssnPatient=N'" + this.SSNTextBox.Text + "' END ElSE SELECT 0;";
                    cmd = new SqlCommand(Query, con);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var year = rdr["year"].ToString();
                        var caseFile = rdr["caseFile"].ToString();
                        var judgement = rdr["judgement"].ToString();
                        var entranceAge = rdr["entranceAge"].ToString();
                        var notes = rdr["notes"].ToString();
                        enteredInstituteDGV.Rows.Add(year, caseFile, judgement, entranceAge, notes);
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void loadingSecondPage()
        {
            SqlDataReader rdr;
            SqlConnection con;
            SqlCommand cmd;

            try
            {

                con = new SqlConnection(constring);
                con.Open();
                string CommandText = "IF EXISTS(Select 1 from EducationInfo where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                    "degree,graduationAge,leftSchool,Reasons,wifeDegree,wifeGraduationAge,wifeWorking FROM EducationInfo where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    this.educationalLevelTextBox.Text = rdr["degree"].ToString();
                    this.graduationAgeTextBox.Text = rdr["graduationAge"].ToString();
                    this.leftSchoolCB.Checked = (Boolean)(rdr["leftSchool"]);
                    if (leftSchoolCB.Checked)
                    {
                        this.LSothersTextBox.Text = rdr["Reasons"].ToString();
                    }

                    this.wifeEducationLevelTextBox.Text = rdr["wifeDegree"].ToString();
                    this.wifeGraduationAgeTextBox.Text = rdr["wifeGraduationAge"].ToString();
                    if (!String.IsNullOrEmpty(rdr["wifeWorking"].ToString()))
                    {
                        this.wifeWorkingRB.Checked = (Boolean)(rdr["wifeWorking"]);
                    }
                    else
                    {
                        this.wifeNotWorkingRB.Checked = true;
                    }
                }
                con.Close();


                con.Open();
                CommandText = "IF EXISTS(Select 1 from firstMeetingDetails where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                    "attendedWith,currentComplain,convertedFrom,purpose FROM firstMeetingDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string attendedWith = rdr["attendedWith"].ToString();
                    int validation = 0;
                    foreach (var rb in AttendedWithGroupBox.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == attendedWith)
                        {
                            rb.Checked = true;
                            validation++;
                            break;
                        }
                    }
                    if (validation == 0)
                    {
                        AtOthersRB.Checked = true;
                        AtterndeOthersTextBox.Text = attendedWith;
                    }

                    this.currentComplainTextBox.Text = rdr["currentComplain"].ToString();
                    string convertedFrom = rdr["convertedFrom"].ToString();
                    validation = 0;
                    foreach (var rb in transferredFromGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == convertedFrom)
                        {
                            rb.Checked = true;
                            validation++;
                            break;
                        }
                    }
                    if (validation == 0)
                    {
                        convertedFromOthersRB.Checked = true;
                        convertedFromOthersTextBox.Text = attendedWith;
                    }

                    string purpose = rdr["purpose"].ToString();
                    validation = 0;
                    foreach (var rb in purposeGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == purpose)
                        {
                            rb.Checked = true;
                            validation++;
                            break;
                        }
                    }
                    if (validation == 0)
                    {
                        purposeOtherRB.Checked = true;
                        purposeOtherTextBox.Text = attendedWith;
                    }
                }

                con.Close();
                con.Open();
                string name = new SqlCommand("IF EXISTS(Select 1 from accidents where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select 1 from accidents where ssnPatient=N'" + this.SSNTextBox.Text + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
                injuriesDGV.Rows.Clear();
                injuriesDGV.Refresh();

                if (name != "0")
                {
                    string Query = "IF EXISTS(Select 1 from accidents where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select year , details ,fractures from accidents where ssnPatient=N'" + this.SSNTextBox.Text + "' END ElSE SELECT 0;";

                    cmd = new SqlCommand(Query, con);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var year = rdr["year"].ToString();
                        var details = rdr["details"].ToString();
                        var fractures = rdr["fractures"].ToString();
                        injuriesDGV.Rows.Add(year, details, fractures);
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void loadingThirdPage()
        {
            SqlDataReader rdr;
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = new SqlConnection(constring);
                con.Open();

                string CommandText = "IF EXISTS(Select 1 from socialCharacteristics where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                    "aggressive,depressive,anixious,doubtful,otherCharacteristics,bossRelation, cooworkersRelations, jobRegularity, economicStatus, " +
                    "anotherIncome, home, homeType, roomCount, haveOwnRoom, shareRoomWith, loan FROM socialCharacteristics where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    this.aggressiveCB.Checked = (Boolean)(rdr["aggressive"]);
                    this.depressedCB.Checked = (Boolean)(rdr["depressive"]);
                    this.anixiousCB.Checked = (Boolean)(rdr["anixious"]);
                    this.doubtfullCB.Checked = (Boolean)(rdr["doubtful"]);

                    if (!String.IsNullOrEmpty(rdr["otherCharacteristics"].ToString()))
                    {
                        othersTraitsCB.Checked = true;
                        this.behavioralTraitsOthersTextBox.Text = rdr["otherCharacteristics"].ToString();
                    }
                    else
                    {
                        othersTraitsCB.Checked = false;
                        this.behavioralTraitsOthersTextBox.Text = "";
                    }

                    string bossRelation = rdr["bossRelation"].ToString();
                    foreach (var rb in relationsWithHeadsGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == bossRelation)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    string cooworkersRelations = rdr["cooworkersRelations"].ToString();
                    foreach (var rb in relationsWithCoworkersGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == cooworkersRelations)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    string jobRegularity = rdr["jobRegularity"].ToString();
                    foreach (var rb in regularityInjobGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == jobRegularity)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    string economicStatus = rdr["economicStatus"].ToString();
                    foreach (var rb in economicStatusGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == economicStatus)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    if (!String.IsNullOrEmpty(rdr["anotherIncome"].ToString()))
                    {
                        yesAIRB.Checked = true;
                        this.anotherIncomeTextBox.Text = rdr["anotherIncome"].ToString();
                    }
                    else
                    {
                        noAIRB.Checked = true;
                        this.anotherIncomeTextBox.Text = "";
                    }

                    string home = rdr["home"].ToString();
                    int validation = 0;
                    foreach (var rb in houseGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == home)
                        {
                            rb.Checked = true;
                            validation++;
                            break;
                        }
                    }
                    if (validation == 0)
                    {
                        otherHomeRB.Checked = true;
                        otherHomeTextBox.Text = home;
                    }

                    string homeType = rdr["homeType"].ToString();
                    foreach (var rb in homeTypeGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == homeType)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    this.bedroomsCountTextBox.Text = rdr["roomCount"].ToString();

                    if (!String.IsNullOrEmpty(rdr["loan"].ToString()))
                    {
                        yesFPRB.Checked = true;
                        this.financialProblemsTextBox.Text = rdr["loan"].ToString();
                    }
                    else
                    {
                        noFPRB.Checked = false;
                        this.financialProblemsTextBox.Text = "";
                    }

                    this.loneRoomRB.Checked = (Boolean)(rdr["haveOwnRoom"]);
                    if (loneRoomRB.Checked)
                    {
                        textBoxFocusOff(shareRoomWithTextBox);
                        this.shareRoomWithTextBox.Text = "مع من يشارك غرفته؟";
                    }
                    else
                    {
                        noLoneRoomRB.Checked = true;
                        textBoxFocusOn(shareRoomWithTextBox);
                        this.shareRoomWithTextBox.Text = rdr["shareRoomWith"].ToString();
                    }
                }
                con.Close();

                con.Open();
                // employerDetails(employer, workNature, unsatisfied,
                //unsatisfiedDetails, notes, workAge, fromDate, toDate)
                string name = new SqlCommand("IF EXISTS(Select 1 from employerDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select 1 from employerDetails where ssnPatient=N'" + this.SSNTextBox.Text + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
                workDGV.Rows.Clear();
                workDGV.Refresh();

                if (name != "0")
                {
                    string Query = "IF EXISTS(Select 1 from employerDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select employer, workNature, unsatisfied," +
                        "unsatisfiedDetails, notes, workAge, fromDate, toDate from employerDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' END ElSE SELECT 0;";

                    cmd = new SqlCommand(Query, con);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var employer = rdr["employer"].ToString();
                        var workNature = rdr["workNature"].ToString();
                        var unsatisfied = (Boolean)(rdr["unsatisfied"]);
                        var unsatisfiedDetails = rdr["unsatisfiedDetails"].ToString();
                        var notes = rdr["notes"].ToString();
                        var workAge = rdr["workAge"].ToString();
                        var fromDate = rdr["fromDate"].ToString();
                        var toDate = rdr["toDate"].ToString();
                        workDGV.Rows.Add(employer, workNature, unsatisfied, unsatisfiedDetails, notes, workAge, fromDate, toDate);
                    }
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void loadingFourthPage()
        {
            SqlDataReader rdr;
            SqlConnection con;
            SqlCommand cmd;

            try
            {

                con = new SqlConnection(constring);
                con.Open();
                //suicideAttempts(ssnPatient, attemptStatus, way, details, notes)
                string CommandText = "IF EXISTS(Select 1 from suicideAttempts where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                    "attemptStatus,way,details,notes FROM suicideAttempts where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string suicideAttempt = rdr["attemptStatus"].ToString();
                    foreach (var rb in experiencedSuicideGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == suicideAttempt)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }
                    if (noAttemptsRB.Checked)
                    {
                        textBoxFocusOff(suicideWayTextBox);
                        this.suicideWayTextBox.Text = "الطريقة التي فكر فيها";
                        textBoxFocusOff(suicideDetailsTextBox);
                        this.suicideDetailsTextBox.Text = "التفاصيل";
                        textBoxFocusOff(suicideNotesTextBox);
                        this.suicideNotesTextBox.Text = "ملاحظات";
                    }
                    else
                    {
                        textBoxFocusOn(suicideWayTextBox);
                        this.suicideWayTextBox.Text = rdr["way"].ToString();
                        textBoxFocusOn(suicideDetailsTextBox);
                        this.suicideDetailsTextBox.Text = rdr["details"].ToString();
                        textBoxFocusOn(suicideNotesTextBox);
                        this.suicideNotesTextBox.Text = rdr["notes"].ToString();
                    }
                }
                con.Close();

                con.Open();
                //warehouse(ssnPatient, entered, count, details)
                CommandText = "IF EXISTS(Select 1 from warehouse where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                    "entered,count,details FROM warehouse where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    this.warehouseCB.Checked = (Boolean)(rdr["entered"]);

                    if (!warehouseCB.Checked)
                    {
                        textBoxFocusOff(warehouseCountsTextBox);
                        this.warehouseCountsTextBox.Text = "عدد مرات دخوله";
                        textBoxFocusOff(warehouseDetailsTextBox);
                        this.warehouseDetailsTextBox.Text = "التفاصيل";
                    }
                    else
                    {
                        textBoxFocusOn(warehouseCountsTextBox);
                        this.warehouseCountsTextBox.Text = rdr["count"].ToString();
                        textBoxFocusOn(warehouseDetailsTextBox);
                        this.warehouseDetailsTextBox.Text = rdr["details"].ToString();
                    }
                }
                con.Close();

                con.Open();
                //unconsioussness(ssnPatient,occurence,count,details)
                CommandText = "IF EXISTS(Select 1 from unconsioussness where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                    "occurence,count,details FROM unconsioussness where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    this.blackoutCB.Checked = (Boolean)(rdr["occurence"]);

                    if (!blackoutCB.Checked)
                    {
                        textBoxFocusOff(blackoutCountsTextBox);
                        this.blackoutCountsTextBox.Text = "عدد مرات دخوله";
                        textBoxFocusOff(blackoutDetailsTextBox);
                        this.blackoutDetailsTextBox.Text = "التفاصيل";
                    }
                    else
                    {
                        textBoxFocusOn(blackoutCountsTextBox);
                        this.blackoutCountsTextBox.Text = rdr["count"].ToString();
                        textBoxFocusOn(blackoutDetailsTextBox);
                        this.blackoutDetailsTextBox.Text = rdr["details"].ToString();
                    }
                }
                con.Close();

                con.Open();
                //drugsAbuse(ssnPatient, currentStatus, startingAge, drugsType, duration, details)    
                CommandText = "IF EXISTS(Select 1 from drugsAbuse where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                    "currentStatus, startingAge, drugsType, duration, details FROM drugsAbuse where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string currentStatus = rdr["currentStatus"].ToString();
                    foreach (var rb in drugsCheckingGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == currentStatus)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    if (noUseRB.Checked)
                    {
                        textBoxFocusOff(startingAgeTextBox);
                        this.startingAgeTextBox.Text = "سوء استخدام العقاقير";
                        textBoxFocusOff(TypesUsedTextBox);
                        this.TypesUsedTextBox.Text = "الأنواع التي يتعاطيها";
                        textBoxFocusOff(monthUsedTextBox);
                        this.monthUsedTextBox.Text = "شهر";
                        textBoxFocusOff(yearsUsedTextBox);
                        this.yearsUsedTextBox.Text = "سنة";
                        textBoxFocusOff(totalDurationTextBox);
                        this.totalDurationTextBox.Text = "المدة الإجمالية بالشهور";
                        textBoxFocusOff(drugUsedDetailsTextBox);
                        this.drugUsedDetailsTextBox.Text = "التفاصيل";
                    }
                    else
                    {
                        textBoxFocusOn(startingAgeTextBox);
                        this.startingAgeTextBox.Text = rdr["startingAge"].ToString();
                        textBoxFocusOn(TypesUsedTextBox);
                        this.TypesUsedTextBox.Text = rdr["drugsType"].ToString();
                        textBoxFocusOff(monthUsedTextBox);
                        this.monthUsedTextBox.Text = "شهر";
                        textBoxFocusOff(yearsUsedTextBox);
                        this.yearsUsedTextBox.Text = "سنة";
                        textBoxFocusOn(totalDurationTextBox);
                        this.totalDurationTextBox.Text = rdr["duration"].ToString();
                        textBoxFocusOn(drugUsedDetailsTextBox);
                        this.drugUsedDetailsTextBox.Text = rdr["details"].ToString();
                    }
                }
                con.Close();

                con.Open();
                //previousTreatment(ssnPatient, hospital, doctor, caseNo, notes)
                string name = new SqlCommand("IF EXISTS(Select 1 from previousTreatment where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select 1 from previousTreatment where ssnPatient=N'" + this.SSNTextBox.Text + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
                treatmentPlacesDGV.Rows.Clear();
                treatmentPlacesDGV.Refresh();

                if (name != "0")
                {
                    string Query = "IF EXISTS(Select 1 from previousTreatment where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select " +
                        "hospital, doctor, caseNo, notes from previousTreatment where ssnPatient=N'" + this.SSNTextBox.Text + "' END ElSE SELECT 0;";

                    cmd = new SqlCommand(Query, con);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var hospital = rdr["hospital"].ToString();
                        var doctor = rdr["doctor"].ToString();
                        var caseNo = rdr["caseNo"].ToString();
                        var notes = rdr["notes"].ToString();
                        treatmentPlacesDGV.Rows.Add(hospital, doctor, caseNo, notes);
                    }
                }
                con.Close();

                con.Open();
                //familyPreviousHistory(ssnPatient, existenceOfFamilyHistory, details)      
                CommandText = "IF EXISTS(Select 1 from familyPreviousHistory where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                    "existenceOfFamilyHistory,details FROM familyPreviousHistory where ssnPatient=N'" + this.SSNTextBox.Text + "' END";

                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    this.familyIllnessCB.Checked = (Boolean)(rdr["existenceOfFamilyHistory"]);

                    if (!familyIllnessCB.Checked)
                    {
                        textBoxFocusOff(familyIllnessDetailsTextBox);
                        this.familyIllnessDetailsTextBox.Text = "التفاصيل";
                    }
                    else
                    {
                        textBoxFocusOn(familyIllnessDetailsTextBox);
                        this.familyIllnessDetailsTextBox.Text = rdr["details"].ToString();
                    }
                }
                con.Close();

                con.Open();
                //patientInfo(ssnPatient, previousTreatment, previousTreatmentNotes)      
                CommandText = "IF EXISTS(Select 1 from patientInfo where ssn=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                    "previousTreatment,previousTreatmentNotes FROM patientInfo where ssn=N'" + this.SSNTextBox.Text + "' END";

                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    this.previousTreatmentCB.Checked = (Boolean)(rdr["previousTreatment"]);
                    textBoxFocusOn(previousPatientHistoryNotesTextBox);
                    this.previousPatientHistoryNotesTextBox.Text = rdr["previousTreatmentNotes"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void loadingFifthPage()
        {
            SqlDataReader rdr;
            SqlConnection con;
            SqlCommand cmd;
            con = new SqlConnection(constring);

            try
            {
                con.Open();
                //patientMarriageDetails(ssnPatient, marriageOrder, relativeMarriage, 
                //relativeSide, boys, girls, total, spouseNationality, duration, fromDate, toDate)       
                string name = new SqlCommand("IF EXISTS(Select 1 from patientMarriageDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select 1 from patientMarriageDetails where ssnPatient=N'" + this.SSNTextBox.Text + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
                patientMaritalStatusDGV.Rows.Clear();
                patientMaritalStatusDGV.Refresh();

                if (name != "0")
                {
                    string Query = "IF EXISTS(Select 1 from patientMarriageDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select " +
                        " marriageOrder, relativeMarriage,relativeSide, boys, girls, total, spouseNationality, duration, fromDate, toDate from patientMarriageDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' END ElSE SELECT 0;";

                    cmd = new SqlCommand(Query, con);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var marriageOrder = rdr["marriageOrder"].ToString();
                        var relativeMarriage = rdr["relativeMarriage"].ToString();
                        var relativeSide = rdr["relativeSide"].ToString();
                        var boys = rdr["boys"].ToString();
                        var girls = rdr["girls"].ToString();
                        var total = rdr["total"].ToString();
                        var spouseNationality = rdr["spouseNationality"].ToString();
                        var duration = rdr["duration"].ToString();
                        var fromDate = rdr["fromDate"].ToString();
                        var toDate = rdr["toDate"].ToString();
                        patientMaritalStatusDGV.Rows.Add(marriageOrder, relativeMarriage, relativeSide, boys, girls, total, spouseNationality, duration, fromDate, toDate);
                    }
                }
                con.Close();


                con.Open();
                // maritalStatus(ssnPatient, maritalStatusReason, totalMariageNumber, ageAtMarriage, ageAtProcreation)
                string CommandText = "IF EXISTS(Select 1 from maritalStatus where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                     "maritalStatusReason, totalMariageNumber, ageAtMarriage, ageAtProcreation FROM maritalStatus where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    textBoxFocusOn(maritalStausReasonsTextBox);
                    this.maritalStausReasonsTextBox.Text = rdr["maritalStatusReason"].ToString();
                    textBoxFocusOn(totalPatientMarriageTextBox);
                    this.totalPatientMarriageTextBox.Text = rdr["totalMariageNumber"].ToString();
                    if (femaleRB.Checked)
                    {
                        textBoxFocusOn(ageAtMarriageFemaleTextBox);
                        this.ageAtMarriageFemaleTextBox.Text = rdr["ageAtMarriage"].ToString();
                        textBoxFocusOn(ageAtProcreationFemaleTextBox);
                        this.ageAtProcreationFemaleTextBox.Text = rdr["ageAtProcreation"].ToString();
                    }

                }
                con.Close();

                con.Open();
                //siblingsDetails(ssnPatient, brothers, sisters, totalSiblings, patientOrder, nearestPerson, responsibleForCount, responsibleForDescription, responsiblitiesToward, pressuredFromResponsibility)
                CommandText = "IF EXISTS(Select 1 from siblingsDetails where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                     "brothers, sisters, totalSiblings, patientOrder, nearestPerson, responsibleForCount, responsibleForDescription," +
                     " responsiblitiesToward, pressuredFromResponsibility FROM siblingsDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    textBoxFocusOn(brothersCountTextBox);
                    this.brothersCountTextBox.Text = rdr["brothers"].ToString();
                    textBoxFocusOn(sistersCoutTextBox);
                    this.sistersCoutTextBox.Text = rdr["sisters"].ToString();
                    textBoxFocusOn(totalMembersTextBox);
                    this.totalMembersTextBox.Text = rdr["totalSiblings"].ToString();
                    textBoxFocusOn(patientOrderTextBox);
                    this.patientOrderTextBox.Text = rdr["patientOrder"].ToString();
                    textBoxFocusOn(nearestFamilyMemberTextBox);
                    this.nearestFamilyMemberTextBox.Text = rdr["nearestPerson"].ToString();
                    textBoxFocusOn(responsibleForCoutTextBox);
                    this.responsibleForCoutTextBox.Text = rdr["responsibleForCount"].ToString();
                    textBoxFocusOn(responsibleForDescriptionTextBox);
                    this.responsibleForDescriptionTextBox.Text = rdr["responsibleForDescription"].ToString();

                    string responsiblitiesToward = rdr["responsiblitiesToward"].ToString();
                    int validation = 0;
                    foreach (var rb in familyResponsibilitiesGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == responsiblitiesToward)
                        {
                            rb.Checked = true;
                            validation++;
                            break;
                        }
                    }
                    if (validation == 0)
                    {
                        otherResponsibilitiesRB.Checked = true;
                        textBoxFocusOn(otherResponsibilitiesTextBox);
                        otherResponsibilitiesTextBox.Text = responsiblitiesToward;
                    }

                    this.pressureCheckBox.Checked = (Boolean)(rdr["pressuredFromResponsibility"]);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void loadingSixthPage()
        {
            SqlDataReader rdr;
            SqlConnection con;
            SqlCommand cmd;
            con = new SqlConnection(constring);

            try
            {
                con.Open();
                string name = new SqlCommand("IF EXISTS(Select 1 from fatherMarriageDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select 1 from fatherMarriageDetails where ssnPatient=N'" + this.SSNTextBox.Text + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
                fatherDGV.Rows.Clear();
                fatherDGV.Refresh();

                if (name != "0")
                {
                    //fatherMarriageDetails(ssnPatient, marriageOrder, fatherRelativeMarriage, fatherRelativeSide, boys, girls, total, spouseNationality, duration)
                    string Query = "IF EXISTS(Select 1 from fatherMarriageDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select " +
                        " marriageOrder, fatherRelativeMarriage, fatherRelativeSide, boys, girls, total, spouseNationality, duration from fatherMarriageDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' END ElSE SELECT 0;";

                    cmd = new SqlCommand(Query, con);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var marriageOrder = rdr["marriageOrder"].ToString();
                        var relativeMarriage = rdr["fatherRelativeMarriage"].ToString();
                        var relativeSide = rdr["fatherRelativeSide"].ToString();
                        var boys = rdr["boys"].ToString();
                        var girls = rdr["girls"].ToString();
                        var total = rdr["total"].ToString();
                        var spouseNationality = rdr["spouseNationality"].ToString();
                        var duration = rdr["duration"].ToString();
                        fatherDGV.Rows.Add(marriageOrder, relativeMarriage, relativeSide, boys, girls, total, spouseNationality, duration);
                    }
                }
                con.Close();

                con.Open();
                // fatherMaritalStatus(ssnPatient, fatherStatus, totalMarriages, nationality, education)
                string CommandText = "IF EXISTS(Select 1 from fatherMaritalStatus where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                     "fatherStatus, totalMarriages, nationality, education FROM fatherMaritalStatus where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string fatherStatus = rdr["fatherStatus"].ToString();
                    foreach (var rb in fatherStatusGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == fatherStatus)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    textBoxFocusOn(totalFatherMarriageTextBox);
                    this.totalFatherMarriageTextBox.Text = rdr["totalMarriages"].ToString();
                    textBoxFocusOn(fatherNationalityTextBox);
                    this.fatherNationalityTextBox.Text = rdr["nationality"].ToString();
                    textBoxFocusOn(fatherEducationLevelTextBox);
                    this.fatherEducationLevelTextBox.Text = rdr["education"].ToString();
                }
                con.Close();





                con.Open();
                name = new SqlCommand("IF EXISTS(Select 1 from motherMarriageDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select 1 from motherMarriageDetails where ssnPatient=N'" + this.SSNTextBox.Text + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
                motherDGV.Rows.Clear();
                motherDGV.Refresh();

                if (name != "0")
                {
                    //motherMarriageDetails(ssnPatient, marriageOrder, motherRelativeMarriage, motherRelativeSide, boys, girls, total, spouseNationality, duration)
                    string Query = "IF EXISTS(Select 1 from motherMarriageDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select " +
                        " marriageOrder, motherRelativeMarriage, motherRelativeSide, boys, girls, total, spouseNationality, duration from motherMarriageDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' END ElSE SELECT 0;";

                    cmd = new SqlCommand(Query, con);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var marriageOrder = rdr["marriageOrder"].ToString();
                        var relativeMarriage = rdr["motherRelativeMarriage"].ToString();
                        var relativeSide = rdr["motherRelativeSide"].ToString();
                        var boys = rdr["boys"].ToString();
                        var girls = rdr["girls"].ToString();
                        var total = rdr["total"].ToString();
                        var spouseNationality = rdr["spouseNationality"].ToString();
                        var duration = rdr["duration"].ToString();
                        motherDGV.Rows.Add(marriageOrder, relativeMarriage, relativeSide, boys, girls, total, spouseNationality, duration);
                    }
                }
                con.Close();

                con.Open();
                //motherMaritalStatus(ssnPatient, motherStatus, totalMarriages, nationality, education)
                CommandText = "IF EXISTS(Select 1 from motherMaritalStatus where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                    "motherStatus, totalMarriages, nationality, education FROM motherMaritalStatus where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string motherStatus = rdr["motherStatus"].ToString();
                    foreach (var rb in motherStatusGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == motherStatus)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    textBoxFocusOn(totalMotherMarriageTextBox);
                    this.totalMotherMarriageTextBox.Text = rdr["totalMarriages"].ToString();
                    textBoxFocusOn(motherNationalityTextBox);
                    this.motherNationalityTextBox.Text = rdr["nationality"].ToString();
                    textBoxFocusOn(motherEducationLevelTextBox);
                    this.motherEducationLevelTextBox.Text = rdr["education"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void loadingSeventhPage()
        {
            SqlDataReader rdr;
            SqlConnection con;
            SqlCommand cmd;
            con = new SqlConnection(constring);
            try
            {
                con.Open();
                //  teenEconomicStatus(ssnPatient, amount, amountType, wasEnough, shortComeCoverage)
                string CommandText = "IF EXISTS(Select 1 from teenEconomicStatus where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                     "amount, amountType, wasEnough, shortComeCoverage FROM teenEconomicStatus where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    textBoxFocusOn(pocketMoneyTextBox);
                    this.pocketMoneyTextBox.Text = rdr["amount"].ToString();

                    string amountType = rdr["amountType"].ToString();
                    foreach (var rb in groupBox23.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == amountType)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }
                    this.pocketMoneyIsEnoughCB.Checked = (Boolean)(rdr["wasEnough"]);

                    string shortComeCoverage = rdr["shortComeCoverage"].ToString();
                    int validation = 0;
                    foreach (var rb in shortcomingSourceGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == shortComeCoverage)
                        {
                            rb.Checked = true;
                            validation++;
                            break;
                        }
                    }
                    if (validation == 0)
                    {
                        otherSourceRB.Checked = true;
                        otherSourceTextBox.Text = shortComeCoverage;
                    }

                }
                con.Close();


                con.Open();
                //teenStudyPhaseDetails(ssnPatient,stage,schoolName, failureYears, notes)
                string name = new SqlCommand("IF EXISTS(Select 1 from teenStudyPhaseDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select 1 from teenStudyPhaseDetails where ssnPatient=N'" + this.SSNTextBox.Text + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
                schoolStageDGV.Rows.Clear();
                schoolStageDGV.Refresh();

                if (name != "0")
                {
                    string Query = "IF EXISTS(Select 1 from teenStudyPhaseDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' ) BEGIN Select " +
                        "stage,schoolName, failureYears, notes from teenStudyPhaseDetails where ssnPatient=N'" + this.SSNTextBox.Text + "' END ElSE SELECT 0;";

                    cmd = new SqlCommand(Query, con);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var stage = rdr["stage"].ToString();
                        var schoolName = rdr["schoolName"].ToString();
                        var failureYears = rdr["failureYears"].ToString();
                        var notes = rdr["notes"].ToString();

                        schoolStageDGV.Rows.Add(stage, schoolName, failureYears, notes);
                    }
                }
                con.Close();

                con.Open();
                //teenSchoolGeneral(ssnPatient, likedScool, hatedSchoolReasons, realtionWithStudents, badStudentsRelationReasons, studentGrades, badRelationWithteachers, reasons)
                CommandText = "IF EXISTS(Select 1 from teenSchoolGeneral where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                     "likedScool, hatedSchoolReasons, realtionWithStudents, badStudentsRelationReasons, " +
                     "studentGrades, badRelationWithteachers, reasons FROM teenSchoolGeneral where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    this.lovedSchoolRB.Checked = (Boolean)(rdr["likedScool"]);
                    if (!lovedSchoolRB.Checked)
                    {
                        hatedSchoolRB.Checked = true;
                        textBoxFocusOn(hatedSchoolTextBox);
                        this.hatedSchoolTextBox.Text = rdr["hatedSchoolReasons"].ToString();
                    }

                    this.goodRelationWithStudentsRB.Checked = (Boolean)(rdr["realtionWithStudents"]);
                    if (!goodRelationWithStudentsRB.Checked)
                    {
                        badRelationWithStudentsRB.Checked = true;
                        textBoxFocusOn(badRelationWithStudentsReasonTextBox);
                        this.badRelationWithStudentsReasonTextBox.Text = rdr["badStudentsRelationReasons"].ToString();
                    }

                    string studentGrades = rdr["studentGrades"].ToString();
                    foreach (var rb in educationLevelGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == studentGrades)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    this.badRelationWithTeachersCB.Checked = (Boolean)(rdr["badRelationWithteachers"]);
                    if (badRelationWithTeachersCB.Checked)
                    {
                        string reasons = rdr["reasons"].ToString();
                        int validation = 0;
                        foreach (var rb in badRelationsWithTeachersGB.Controls.OfType<RadioButton>())
                        {
                            if (rb.Text == reasons)
                            {
                                rb.Checked = true;
                                validation++;
                                break;
                            }
                        }
                        if (validation == 0)
                        {
                            otherReaonsBadTeacherRelationRB.Checked = true;
                            otherReaonsBadTeacherRelationTextBox.Text = reasons;
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void loadingEigthPage()
        {
            SqlDataReader rdr;
            SqlConnection con;
            SqlCommand cmd;
            con = new SqlConnection(constring);
            try
            {
                con.Open();
                //teenBehavior(ssnPatient, prayer, quran, fastingRamadan, convictedFamilyMember, whoConvictedMember, convictionDetails, drugsAddictedFamilyMember, whoDrugMember)
                string CommandText = "IF EXISTS(Select 1 from teenBehavior where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                     "prayer, quran, fastingRamadan, convictedFamilyMember, whoConvictedMember, convictionDetails, " +
                     "drugsAddictedFamilyMember, whoDrugMember FROM teenBehavior where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string prayer = rdr["prayer"].ToString();
                    foreach (var rb in prayerGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == prayer)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    string quran = rdr["quran"].ToString();
                    foreach (var rb in quranGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == quran)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    string fastingRamadan = rdr["fastingRamadan"].ToString();
                    foreach (var rb in ramadanGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == fastingRamadan)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    this.convictedFamilyMemberCB.Checked = (Boolean)(rdr["convictedFamilyMember"]);
                    if (convictedFamilyMemberCB.Checked)
                    {
                        string whoConvictedMember = rdr["whoConvictedMember"].ToString();
                        foreach (var rb in convictedMemberGB.Controls.OfType<RadioButton>())
                        {
                            if (rb.Text == whoConvictedMember)
                            {
                                rb.Checked = true;
                                break;
                            }
                        }

                        textBoxFocusOn(familyMemberConvictedTextBox);
                        this.familyMemberConvictedTextBox.Text = rdr["convictionDetails"].ToString();
                    }

                    this.drugAbuseFamilyMemberCB.Checked = (Boolean)(rdr["drugsAddictedFamilyMember"]);
                    if (drugAbuseFamilyMemberCB.Checked)
                    {
                        string whoDrugMember = rdr["whoDrugMember"].ToString();
                        foreach (var rb in drugAbuseFamilyMemberGB.Controls.OfType<RadioButton>())
                        {
                            if (rb.Text == whoDrugMember)
                            {
                                rb.Checked = true;
                                break;
                            }
                        }
                    }
                }
                con.Close();

                con.Open();
                //teenFreeTime(ssnPatient, timeSpent, haveEmail, emailReason, mostVisitedSites, traveledBefore, countriesVisited)
                CommandText = "IF EXISTS(Select 1 from teenFreeTime where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                     "timeSpent, haveEmail, emailReason, mostVisitedSites, traveledBefore, countriesVisited FROM teenFreeTime where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    textBoxFocusOn(freeTimeTextBox);
                    this.freeTimeTextBox.Text = rdr["timeSpent"].ToString();

                    this.haveEmailCB.Checked = (Boolean)(rdr["haveEmail"]);
                    if (haveEmailCB.Checked)
                    {
                        string emailReason = rdr["emailReason"].ToString();
                        foreach (var rb in emailPurposeGB.Controls.OfType<RadioButton>())
                        {
                            if (rb.Text == emailReason)
                            {
                                rb.Checked = true;
                                break;
                            }
                        }
                    }

                    string mostVisitedSites = rdr["mostVisitedSites"].ToString();
                    foreach (var rb in mostVisitedGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == mostVisitedSites)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    this.travelledCB.Checked = (Boolean)(rdr["traveledBefore"]);
                    if (travelledCB.Checked)
                    {
                        textBoxFocusOn(whichCountriesTextBox);
                        this.whichCountriesTextBox.Text = rdr["countriesVisited"].ToString();
                    }

                }
                con.Close();


                con.Open();
                // teenRelation(ssnPatient, socialRelations, familyRelations, familyEvaluation, chaningMotivation, motivationEvaluation, socialSituationSummary)
                CommandText = "IF EXISTS(Select 1 from teenRelation where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN SELECT " +
                     "socialRelations, familyRelations, familyEvaluation, chaningMotivation, motivationEvaluation, socialSituationSummary FROM teenRelation where ssnPatient=N'" + this.SSNTextBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    textBoxFocusOn(patientSocialStatusTextBox);
                    this.patientSocialStatusTextBox.Text = rdr["socialRelations"].ToString();


                    textBoxFocusOn(familyTextBox);
                    this.familyTextBox.Text = rdr["familyRelations"].ToString();

                    string familyEvaluation = rdr["familyEvaluation"].ToString();
                    foreach (var rb in socialRelationsValidationGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == familyEvaluation)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    textBoxFocusOn(motivationsTextBox);
                    this.motivationsTextBox.Text = rdr["chaningMotivation"].ToString();

                    string motivationEvaluation = rdr["motivationEvaluation"].ToString();
                    foreach (var rb in motivationsThreeEvaluationGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == motivationEvaluation)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    textBoxFocusOn(socialStatusAbstractRB);
                    this.socialStatusAbstractRB.Text = rdr["socialSituationSummary"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void loadingNinthPage()
        {
            SqlDataReader rdr;
            SqlConnection con;
            SqlCommand cmd;
            con = new SqlConnection(constring);
            try
            {
                con.Open();
                //teenBehavior(ssnPatient, prayer, quran, fastingRamadan, convictedFamilyMember, whoConvictedMember, convictionDetails, drugsAddictedFamilyMember, whoDrugMember)
                string CommandText = "IF EXISTS(Select 1 from periodicMeetings where meetingTitle=N'" + this.meetingTitleComboBox.Text + "') BEGIN SELECT " +
                     "meetingType, socialSide, socialMainProgram, socialAlterBehavior, psychologicalSide, psychologicalMainProgram, " +
                     "psychologicalAlterBehavior, religiousSide,meetingDate,signingDate,meetingTarget,meetingContent,recommendations FROM periodicMeetings where meetingTitle=N'" + this.meetingTitleComboBox.Text + "' END";
                cmd = new SqlCommand(CommandText);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    string meetingType = rdr["meetingType"].ToString();
                    foreach (var rb in meetingTypeGB.Controls.OfType<RadioButton>())
                    {
                        if (rb.Text == meetingType)
                        {
                            rb.Checked = true;
                            break;
                        }
                    }

                    this.socialSideCB.Checked = (Boolean)(rdr["socialSide"]);
                    this.mainProgramSocialCB.Checked = (Boolean)(rdr["socialMainProgram"]);
                    this.alterBehaviorSocialCB.Checked = (Boolean)(rdr["socialAlterBehavior"]);
                    this.psychologicalSideCB.Checked = (Boolean)(rdr["psychologicalSide"]);
                    this.mainProgramPsychologicalCB.Checked = (Boolean)(rdr["psychologicalMainProgram"]);
                    this.alterBehaviorPsychologicalCB.Checked = (Boolean)(rdr["psychologicalAlterBehavior"]);
                    this.religiousSideCB.Checked = (Boolean)(rdr["religiousSide"]);

                    this.meetingDate.Text = rdr["meetingDate"].ToString();
                    this.registeringDate.Text = rdr["signingDate"].ToString();
                    this.meetingPurposeTextBox.Text = rdr["meetingTarget"].ToString();
                    this.meetingContentTextBox.Text = rdr["meetingContent"].ToString();
                    this.recommendationTextBox.Text = rdr["recommendations"].ToString();
                }
                con.Close();

                string meetingTypeRB = (meetingTypeGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;

                con = new SqlConnection(constring);
                con.Open();
                string Id = new SqlCommand("Select Id from periodicMeetings where meetingType=N'" + meetingTypeRB + "' AND meetingTitle=N'" + this.meetingTitleComboBox.Text + "' AND meetingDate=N'" + this.meetingDate.Value.ToString("MM/dd/yyyy") + "' AND signingDate=N'" + this.registeringDate.Value.ToString("MM/dd/yyyy") + "' " +
                    "AND meetingTarget= N'" + this.meetingPurposeTextBox.Text + "'AND meetingContent = N'" + this.meetingContentTextBox.Text + "' AND recommendations = N'" + this.recommendationTextBox.Text + "'", con).ExecuteScalar().ToString();
                con.Close();

                con.Open();
                string Exist = new SqlCommand("IF EXISTS(Select 1 from periodicMeetingsDetails where idMainMeeting=N'" + Id + "' ) BEGIN Select 1 from periodicMeetingsDetails where idMainMeeting=N'" + Id + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
                fatherDGV.Rows.Clear();
                fatherDGV.Refresh();

                if (Exist != "0")
                {
                    //fatherMarriageDetails(ssnPatient, marriageOrder, fatherRelativeMarriage, fatherRelativeSide, boys, girls, total, spouseNationality, duration)
                    string Query = "IF EXISTS(Select 1 from periodicMeetingsDetails where idMainMeeting=N'" + Id + "' ) BEGIN Select " +
                        " ssnPatient, name, nationality, age, caseFile from periodicMeetingsDetails where idMainMeeting=N'" + Id + "' END ElSE SELECT 0;";

                    cmd = new SqlCommand(Query, con);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var ssnPatient = rdr["ssnPatient"].ToString();
                        var name = rdr["name"].ToString();
                        var nationality = rdr["nationality"].ToString();
                        var age = rdr["age"].ToString();
                        var caseFile = rdr["caseFile"].ToString();

                        targetDGV.Rows.Add(ssnPatient, name, nationality, age, caseFile);
                    }
                }
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void ClearAll()
        {
            clearingFirstPage();
            clearingSecondPage();
            clearingThirdPage();
            clearingFourthPage();
            clearingFifthPage();
            clearingSixthPage();
            clearingSeventhPage();
            clearingEigthPage();
        }

        void clearingFirstPage()
        {
            SSNTextBox.Text = "";
            nameTextBox.Text = "";
            ageTextBox.Text = "";
            nationalityTextBox.Text = "";
            residencePlaceTextBox.Text = "";
            phoneNumberTextBox.Text = "";
            caseTextBox.Text = "";
            judgementTextBox.Text = "";
            heightTextBox.Text = "";
            weightTextBox.Text = "";
            waistTextBox.Text = "";
            tactfulRB.Checked = true;
            walkingTexBox.Text = "";
            musclesTextBox.Text = "";
            maleRB.Checked = true;
            newCaseRB.Checked = true;
            adultRB.Checked = true;
            residentRB.Checked = true;
            singleRB.Checked = true;
            dateDTP.Text = DateTime.Now.ToShortDateString();
            enteredInstituteDGV.Rows.Clear();
            enteredInstituteDGV.Refresh();
            clearingRehabilationDGV_1stPage();
            ToggleConditionButton.IsOn = true;
        }
        void clearingRehabilationDGV_1stPage()
        {
            enteredInstituteYearTextBox.Text = "";
            enteredInstituteCaseTextBox.Text = "";
            enteredInstituteJudgementTextBox.Text = "";
            enteredInstituteAgeTextBox.Text = "";
            enteredInstituteNotesTextBox.Text = "";
        }

        void clearingSecondPage()
        {
            AtSingleRB.Checked = true;
            AtterndeOthersTextBox.Text = "";
            currentComplainTextBox.Text = "";
            educationalLevelTextBox.Text = "";
            graduationAgeTextBox.Text = "";
            leftSchoolCB.Checked = true;
            LSrepitiveFailreRB.Checked = true;
            wifeEducationLevelTextBox.Text = "";
            wifeGraduationAgeTextBox.Text = "";
            wifeWorkingRB.Checked = true;
            convertedFromGeneralDoctorRB.Checked = true;
            purposeFamilyRB.Checked = true;
            anyInjuriesCB.Checked = false;
            injuriesDGV.Rows.Clear();
            injuriesDGV.Refresh();
            clearingInjuriesDGV_2ndPage();
        }
        void clearingInjuriesDGV_2ndPage()
        {
            yearInjuredCB.Text = "";
            injuryDetailsTextBox.Text = "";
            fracturesTextBox.Text = "";
        }

        void clearingThirdPage()
        {
            aggressiveCB.Checked = false;
            depressedCB.Checked = false;
            anixiousCB.Checked = false;
            doubtfullCB.Checked = false;
            othersTraitsCB.Checked = false;
            behavioralTraitsOthersTextBox.Text = "";
            bossRelGoodRB.Checked = true;
            coworkersRelGoodRB.Checked = true;
            regulatedRB.Checked = true;
            poorEconimicRB.Checked = true;
            noAIRB.Checked = true;
            anotherIncomeTextBox.Text = "";
            ownedRB.Checked = true;
            otherHomeTextBox.Text = "";
            independentVillaRB.Checked = true;
            noFPRB.Checked = true;
            financialProblemsTextBox.Text = "";
            bedroomsCountTextBox.Text = "";
            loneRoomRB.Text = "";
            loneRoomRB.Checked = true;
            shareRoomWithTextBox.Text = "";
            leaveTextBox(shareRoomWithTextBox, "مع من يشارك غرفته؟");

            workDGV.Rows.Clear();
            workDGV.Refresh();
            clearingEmployersDGV_3rdPage();
        }
        void clearingEmployersDGV_3rdPage()
        {
            entityWorkTextBox.Text = "";
            officialHoursRB.Checked = true;
            miserableJobCB.Checked = false;
            miserableJobReasonTextBox.Text = "";
            leaveTextBox(miserableJobReasonTextBox, "التفاصيل");
            notesWorkTextBox.Text = "";
            workStartAgeTextBox.Text = "";
            workFromDate.Text = workToDate.Text;
            workToDate.Text = DateTime.Now.ToShortDateString();
        }

        void clearingFourthPage()
        {
            noAttemptsRB.Checked = true;
            suicideWayTextBox.Text = "";
            leaveTextBox(suicideWayTextBox, "الطريقة التي فكر فيها");
            suicideDetailsTextBox.Text = "";
            leaveTextBox(suicideDetailsTextBox, "التفاصيل");
            suicideNotesTextBox.Text = "";
            leaveTextBox(suicideNotesTextBox, "ملاحظات");
            warehouseCB.Checked = false;
            warehouseCountsTextBox.Text = "";
            leaveTextBox(warehouseCountsTextBox, "عدد مرات دخوله");
            warehouseDetailsTextBox.Text = "";
            leaveTextBox(warehouseDetailsTextBox, "التفاصيل");
            blackoutCB.Checked = false;
            blackoutCountsTextBox.Text = "";
            leaveTextBox(blackoutCountsTextBox, "عدد مرات إصابته");
            blackoutDetailsTextBox.Text = "";
            leaveTextBox(blackoutDetailsTextBox, "التفاصيل");
            noUseRB.Checked = true;
            startingAgeTextBox.Text = "";
            leaveTextBox(startingAgeTextBox, "سن بداية التعاطي");
            TypesUsedTextBox.Text = "";
            leaveTextBox(TypesUsedTextBox, "الأنواع التي يتعاطيها");
            monthUsedTextBox.Text = "";
            leaveTextBox(monthUsedTextBox, "شهر");
            yearsUsedTextBox.Text = "";
            leaveTextBox(yearsUsedTextBox, "سنة");
            totalDurationTextBox.Text = "";
            leaveTextBox(totalDurationTextBox, "المدة الإجمالية بالشهور");
            drugUsedDetailsTextBox.Text = "";
            leaveTextBox(drugUsedDetailsTextBox, "التفاصيل");
            previousTreatmentCB.Checked = false;

            treatmentPlacesDGV.Rows.Clear();
            treatmentPlacesDGV.Refresh();
            clearingTreatmentPlacesDGVDGV_4thPage();

            familyIllnessCB.Checked = false;
            familyIllnessDetailsTextBox.Text = "";
            leaveTextBox(familyIllnessDetailsTextBox, "التفاصيل");
            previousPatientHistoryNotesTextBox.Text = "";
            leaveTextBox(previousPatientHistoryNotesTextBox, "ملاحظات التاريخ المرضي السابق");
        }
        void clearingTreatmentPlacesDGVDGV_4thPage()
        {
            hospitalTreatmentTextBox.Text = "";
            leaveTextBox(hospitalTreatmentTextBox, "المستشفى");
            doctorTreatmentTextBox.Text = "";
            leaveTextBox(doctorTreatmentTextBox, "الطبيب المعالج");
            fileNumberTreatmentTextBox.Text = "";
            leaveTextBox(fileNumberTreatmentTextBox, "رقم الملف الطبي");
            notesTreatmentTextBox.Text = "";
            leaveTextBox(notesTreatmentTextBox, "ملاحظات");
        }

        void clearingFifthPage()
        {
            msSingleRB.Checked = true;
            maritalStausReasonsTextBox.Text = "";
            leaveTextBox(maritalStausReasonsTextBox, "أسباب الحالة الاجتماعية");
            totalPatientMarriageTextBox.Text = "";
            leaveTextBox(totalPatientMarriageTextBox, "عدد مرات الزواج الكلية");
            ageAtMarriageFemaleTextBox.Text = "";
            leaveTextBox(ageAtMarriageFemaleTextBox, "العمر عند الزواج");
            ageAtProcreationFemaleTextBox.Text = "";
            leaveTextBox(ageAtProcreationFemaleTextBox, "العمر عند الإنجاب");
            brothersCountTextBox.Text = "";
            leaveTextBox(brothersCountTextBox, "الأشقاء من جهة الأب والأم فقط");
            sistersCoutTextBox.Text = "";
            leaveTextBox(sistersCoutTextBox, "الشقيقات من جهة الأب والأم فقط");
            totalMembersTextBox.Text = "";
            leaveTextBox(totalMembersTextBox, "عدد الأشقاء والشقيقات الكلي");
            patientOrderTextBox.Text = "";
            leaveTextBox(patientOrderTextBox, "ترتيب المفحوص بين أشقائه وشقيقاته");
            nearestFamilyMemberTextBox.Text = "";
            leaveTextBox(nearestFamilyMemberTextBox, "أقرب شخص للمفحوص من العائلة");
            responsibleForCoutTextBox.Text = "";
            leaveTextBox(responsibleForCoutTextBox, "عدد الأفراد المسؤول عنهم");
            responsibleForDescriptionTextBox.Text = "";
            leaveTextBox(responsibleForDescriptionTextBox, "أعمار ووصف الأفراد المسؤول عنهم");
            pressureCheckBox.Checked = false;
            smallFamilyRB.Checked = true;
            otherResponsibilitiesTextBox.Text = "";
            leaveTextBox(otherResponsibilitiesTextBox, "آخرين");

            patientMaritalStatusDGV.Rows.Clear();
            patientMaritalStatusDGV.Refresh();
            clearingpatientMaritalStatusDGV_5thPage();
        }
        void clearingpatientMaritalStatusDGV_5thPage()
        {
            marriagePatientOrderTextBox.Text = "";
            leaveTextBox(marriagePatientOrderTextBox, "ترتيب الزواج بين زيجاته الأخرى");
            noRelativeRB.Checked = true;
            patientMarriageSideComboBox.Text = "";
            boysCountPatientsTextBox.Text = "";
            leaveTextBox(boysCountPatientsTextBox, "عدد الأبناء");
            girlsCountPatientsTextBox.Text = "";
            leaveTextBox(girlsCountPatientsTextBox, "عدد البنات");
            totalSonsTextBox.Text = "";
            leaveTextBox(totalSonsTextBox, "العدد");
            husbandNationalityTextBox.Text = "";
            leaveTextBox(husbandNationalityTextBox, "جنسية الزوج");
            marriageDurationTextBox.Text = "";
            leaveTextBox(marriageDurationTextBox, "مدة الزواج");
            marriageFromDate.Text = marriageToDate.Text;
            marriageToDate.Text = DateTime.Now.ToShortDateString();
        }

        void clearingSixthPage()
        {
            fatherWorkingRB.Checked = true;
            totalFatherMarriageTextBox.Text = "";
            leaveTextBox(totalFatherMarriageTextBox, "عدد مرات الزواج الكلية");
            fatherNationalityTextBox.Text = "";
            leaveTextBox(fatherNationalityTextBox, "الجنسية");
            fatherEducationLevelTextBox.Text = "";
            leaveTextBox(fatherEducationLevelTextBox, "مستوى التعليم");

            motherWorkingRB.Checked = true;
            totalMotherMarriageTextBox.Text = "";
            leaveTextBox(totalMotherMarriageTextBox, "عدد مرات الزواج الكلية");
            motherNationalityTextBox.Text = "";
            leaveTextBox(motherNationalityTextBox, "الجنسية");
            motherEducationLevelTextBox.Text = "";
            leaveTextBox(motherEducationLevelTextBox, "مستوى التعليم");

            fatherDGV.Rows.Clear();
            fatherDGV.Refresh();
            clearingFatherMariageDGV_6thPage();

            motherDGV.Rows.Clear();
            motherDGV.Refresh();
            clearingMotherMariageDGV_6thPage();
        }
        void clearingFatherMariageDGV_6thPage()
        {
            fatherMariiageOrderTextBox.Text = "";
            leaveTextBox(fatherMariiageOrderTextBox, "ترتيب الزواج بين زيجاته الأخرى");
            noFatherRelativeRB.Checked = true;
            fatherMarriageSideComboBox.Text = "";
            fatherBoysCountTextBox.Text = "";
            leaveTextBox(fatherBoysCountTextBox, "عدد الأبناء");
            fatherGirlsCountTextBox.Text = "";
            leaveTextBox(fatherGirlsCountTextBox, "عدد البنات");
            fatherTotalKidsTextBox.Text = "";
            leaveTextBox(fatherTotalKidsTextBox, "العدد");
            wifeFatherNationalityTextBox.Text = "";
            leaveTextBox(wifeFatherNationalityTextBox, "جنسية الزوجة");
            fatherMarriageDurationTextBox.Text = "";
            leaveTextBox(fatherMarriageDurationTextBox, "مدة الزواج بالأعوام");
        }
        void clearingMotherMariageDGV_6thPage()
        {
            motherMariiageOrderTextBox.Text = "";
            leaveTextBox(motherMariiageOrderTextBox, "ترتيب الزواج بين زيجاتها الأخرى");
            noMotherRelativeRB.Checked = true;
            motherMarriageSideComboBox.Text = "";
            motherBoysCountTextBox.Text = "";
            leaveTextBox(motherBoysCountTextBox, "عدد الأبناء");
            motherGirlsCountTextBox.Text = "";
            leaveTextBox(motherGirlsCountTextBox, "عدد البنات");
            motherTotalKidsTextBox.Text = "";
            leaveTextBox(motherTotalKidsTextBox, "العدد");
            husbandMotherTextBox.Text = "";
            leaveTextBox(husbandMotherTextBox, "جنسية الزوج");
            motherMarriageDurationTextBox.Text = "";
            leaveTextBox(motherMarriageDurationTextBox, "مدة الزواج بالأعوام");
        }

        void clearingSeventhPage()
        {
            dailyPocketMoneyRB.Checked = true;
            pocketMoneyTextBox.Text = "";
            leaveTextBox(pocketMoneyTextBox, "بالدرهم");
            fatherNationalityTextBox.Text = "";
            leaveTextBox(fatherNationalityTextBox, "الجنسية");
            fatherEducationLevelTextBox.Text = "";
            leaveTextBox(fatherEducationLevelTextBox, "مستوى التعليم");

            motherWorkingRB.Checked = true;
            totalMotherMarriageTextBox.Text = "";
            leaveTextBox(totalMotherMarriageTextBox, "عدد مرات الزواج الكلية");
            pocketMoneyIsEnoughCB.Checked = false;
            fromFriendsRB.Checked = true;
            otherSourceTextBox.Text = "";
            patientSocialStatusTextBox.Text = "";
            leaveTextBox(patientSocialStatusTextBox, "النظر في عمر أصدقائه ومن هم وكيفية العلاقة بينه وبين أصدقاءه والنظر في القدرة على بناء علاقات والمحافظة عليها وإذا كان هنالك دليل على التعرض لاستغلال الأصدقاء في الوقت أو في الماضي.");
            lovedSchoolRB.Checked = true;
            hatedSchoolTextBox.Text = "";
            leaveTextBox(hatedSchoolTextBox, "الأسباب");
            goodRelationWithStudentsRB.Checked = true;
            badRelationWithStudentsReasonTextBox.Text = "";
            leaveTextBox(badRelationWithStudentsReasonTextBox, "الأسباب");
            mediumStudentRB.Checked = true;
            badRelationWithTeachersCB.Checked = false;
            notCompehendRB.Checked = true;
            otherReaonsBadTeacherRelationTextBox.Text = "";

            schoolStageDGV.Rows.Clear();
            schoolStageDGV.Refresh();
            clearingTeenSchoolStagesDGV_7thPage();
        }

        void clearingTeenSchoolStagesDGV_7thPage()
        {
            schoolStageComboBox.Text = "";
            schoolNameTextBox.Text = "";
            schoolFailureYearsTextBox.Text = "";
            schoolNotesTextBox.Text = "";
        }

        void clearingEigthPage()
        {
            prayerAlwaysRB.Checked = true;
            quranAlwaysRB.Checked = true;
            fastingAlwaysRB.Checked = true;
            convictedFamilyMemberCB.Checked = false;
            dadConvictedRB.Checked = true;
            familyMemberConvictedTextBox.Text = "";
            leaveTextBox(familyMemberConvictedTextBox, "ما نوع الجريمة وتفاصيلها");
            drugAbuseFamilyMemberCB.Checked = false;
            dadDrugAbuseRB.Checked = true;

            freeTimeTextBox.Text = "";
            leaveTextBox(freeTimeTextBox, "كيف تقضي وقت الفراغ");
            haveEmailCB.Checked = false;
            joinChatRoomsRB.Checked = true;
            socialSitesRB.Checked = true;
            travelledCB.Checked = false;
            whichCountriesTextBox.Text = "";
            leaveTextBox(whichCountriesTextBox, "ما الدول وتفاصيل السفر");

            familyTextBox.Text = "";
            leaveTextBox(familyTextBox, "خذ بعين الاعتبار موقف الأسرة من الحد بعد الجنحة.\nخذ بعين الاعتبار المنطقة السكنية للحدث.");
            familyZeroEvaluationRB.Checked = true;
            motivationsTextBox.Text = "";
            leaveTextBox(motivationsTextBox, "خذ بعين الاعتبار موقف الحدث من الجنحة, هل يتحمل المسؤولية وتصرفاته وهل يتفهم خطورة سلوكه وتأثير ذلك على الضحية؟\nالنظر في أي دافع وأي تغيير وأي طموحات للمستقبل.\nتحديد أي عوامل إيجابية أو وقائية.");
            motivationsZeroEvaluationRB.Checked = true;
            socialStatusAbstractRB.Text = "";
            leaveTextBox(socialStatusAbstractRB, "تشخيص حالة الحدث ويجب أن تشمل المخاطر الأساسية وعوامل الجنوح والتوصيات.");
        }

        void clearingNinthPage()
        {

            groupMeetingRB.Checked = true;
            socialSideCB.Checked = false;
            mainProgramSocialCB.Checked = false;
            alterBehaviorSocialCB.Checked = false;
            psychologicalSideCB.Checked = false;
            mainProgramPsychologicalCB.Checked = false;
            alterBehaviorPsychologicalCB.Checked = false;
            religiousSideCB.Checked = false;
            meetingTitleTextBox.Text = "";
            registeringDate.Text = DateTime.Now.ToShortDateString();
            meetingPurposeTextBox.Text = "";
            meetingContentTextBox.Text = "";
            recommendationTextBox.Text = "";

            targetDGV.Rows.Clear();
            targetDGV.Refresh();
            clearingMeetingDGV_9thPage();
            loadingTitlesInComboBox();
        }
        void clearingMeetingDGV_9thPage()
        {
            ssnNumberTargetTextBox.Text = "";
            nameTargetTextBox.Text = "";
            nationalityTargetTextBox.Text = "";
            ageTargetTextBox.Text = "";
            caseTargetTextBox.Text = "";
        }

        private void ToggleConditionButton_Click(object sender, EventArgs e)
        {
            if (ToggleConditionButton.IsOn)
            {
                newCaseRB.Checked = true;
            }
            else
            {
                editCaseRB.Checked = true;
            }
        }


        private void nextPageButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == TabPage0_0 && tabControl4.SelectedTab == TabPage0_1)
            {
                if (firstPageTextBoxValidation())
                {
                    tabControl1.SelectedTab = TabPage0_0;
                    tabControl4.SelectedTab = TabPage0_2;
                    normalizeButtonColorStatus();
                    selectedTabButton(generalInformationButton, generalInformationsButton);
                }
            }
            else if (tabControl1.SelectedTab == TabPage0_0 && tabControl4.SelectedTab == TabPage0_2)
            {
                if (firstPageSecondHalfValidation())
                {
                    tabControl1.SelectedTab = TabPage1_0;
                    tabControl2.SelectedTab = TabPage1_1;
                    normalizeButtonColorStatus();
                    selectedTabButton(socialCharacteristicsButton, characterAnalysisButton);
                    showSubMenus(characterAnalysisPanel);
                }
            }
            else if (tabControl1.SelectedTab == TabPage1_0 && tabControl2.SelectedTab == TabPage1_1)
            {
                if (secondPageTextBoxValidation())
                {
                    tabControl1.SelectedTab = TabPage1_0;
                    tabControl2.SelectedTab = TabPage1_2;
                    normalizeButtonColorStatus();
                    selectedTabButton(illnessProblemsButton, characterAnalysisButton);
                }
            }
            else if (tabControl1.SelectedTab == TabPage1_0 && tabControl2.SelectedTab == TabPage1_2)
            {
                if (thirdPageTextBoxValidation())
                {
                    tabControl1.SelectedTab = TabPage2_0;
                    tabControl3.SelectedTab = TabPage2_1;
                    normalizeButtonColorStatus();
                    selectedTabButton(socialStatusButton, enviromentAnalysisButton);
                    showSubMenus(enviromentAnalysisPanel);

                }
            }
            else if (tabControl1.SelectedTab == TabPage2_0 && tabControl3.SelectedTab == TabPage2_1)
            {
                if (fourthPageTextBoxValidation())
                {
                    tabControl1.SelectedTab = TabPage2_0;
                    tabControl3.SelectedTab = TabPage2_2;
                    normalizeButtonColorStatus();
                    selectedTabButton(bigFamilyButton, enviromentAnalysisButton);
                }
            }
            else if (tabControl1.SelectedTab == TabPage2_0 && tabControl3.SelectedTab == TabPage2_2)
            {
                if (fifthPageTextBoxValidation())
                {
                    if (!adultRB.Checked)
                    {
                        tabControl1.SelectedTab = TabPage3_0;
                        tabControl5.SelectedTab = TabPage3_1;
                        normalizeButtonColorStatus();
                        selectedTabButton(socialDetailsButton, teensButton);
                        showSubMenus(teensPanel);
                    }
                    else
                    {
                        saveFinalStep();
                    }
                }
            }
            else if (tabControl1.SelectedTab == TabPage3_0 && tabControl5.SelectedTab == TabPage3_1)
            {
                if (sixthPageTextBoxValidation())
                {
                    tabControl1.SelectedTab = TabPage3_0;
                    tabControl5.SelectedTab = TabPage3_2;
                    selectedTabButton(individualBehaviorButton, meetingsButton);
                    hideSubMenus();
                }
            }
            else if (tabControl1.SelectedTab == TabPage3_0 && tabControl5.SelectedTab == TabPage3_2)
            {
                if (seventhPageTextBoxValidation())
                {
                    saveFinalStep();
                }
            }
        }

        private void clearPageDataButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == TabPage0_0 && tabControl4.SelectedTab == TabPage0_1)
            {
                clearingFirstPage();
            }
            else if (tabControl1.SelectedTab == TabPage0_0 && tabControl4.SelectedTab == TabPage0_2)
            {
                clearingSecondPage();
            }
            else if (tabControl1.SelectedTab == TabPage1_0 && tabControl2.SelectedTab == TabPage1_1)
            {
                clearingThirdPage();
            }
            else if (tabControl1.SelectedTab == TabPage1_0 && tabControl2.SelectedTab == TabPage1_2)
            {
                clearingFourthPage();
            }
            else if (tabControl1.SelectedTab == TabPage2_0 && tabControl3.SelectedTab == TabPage2_1)
            {
                clearingFifthPage();
            }
            else if (tabControl1.SelectedTab == TabPage2_0 && tabControl3.SelectedTab == TabPage2_2)
            {
                clearingSixthPage();
            }
            else if (tabControl1.SelectedTab == TabPage3_0 && tabControl5.SelectedTab == TabPage3_1)
            {
                clearingSeventhPage();
            }
            else if (tabControl1.SelectedTab == TabPage3_0 && tabControl5.SelectedTab == TabPage3_2)
            {
                clearingEigthPage();
            }
            else if (tabControl1.SelectedTab == TabPage4_0)
            {
                clearingNinthPage();
            }
        }

        bool validatePatient()
        {
            if (firstPageTextBoxValidation())
            {
                if (firstPageSecondHalfValidation())
                {
                    if (secondPageTextBoxValidation())
                    {
                        if (thirdPageTextBoxValidation())
                        {
                            if (fourthPageTextBoxValidation())
                            {
                                if (fifthPageTextBoxValidation())
                                {
                                    if (!adultRB.Checked)
                                    {
                                        if (sixthPageTextBoxValidation())
                                        {
                                            if (seventhPageTextBoxValidation())
                                            {
                                                return true;
                                            }
                                        }
                                    }
                                    else if (adultRB.Checked)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;

        }
        bool SaveNewPatient()
        {
            if (validatePatient())
            {
                saveFirstPage();
                saveSecondPage();
                saveThirdPage();
                saveFourthPage();
                saveFifthPage();
                if (!adultRB.Checked)
                {
                    saveSixthPage();
                    saveSeventhPage();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        bool SaveNewMeeting()
        {
            if (eigthPageTextBoxValidation())
            {
                if (saveEigthPage())
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }






        private void editSSN_Click(object sender, EventArgs e)
        {
            string message = $"سيتم تعديل الرقم الموحد {oldSSN.Text} إلى {newSSN.Text}";
            DialogResult dialogResult = MessageBox.Show(message, "يرجى التأكد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (availableSSNOptional(oldSSN.Text) && !availableSSNOptional(newSSN.Text))
                {
                    updateSSN(oldSSN.Text, newSSN.Text);
                    message = "بنجاح " + newSSN.Text + "إلى " + oldSSN.Text + " تم تعديل الرقم الموحد ";
                    MessageBox.Show(message, "عاااش", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    newCaseRB.Checked = true;
                }
                else if(availableSSNOptional(newSSN.Text))
                {
                    MessageBox.Show($"يرجى التأكد من الرقم الموحد الجديد لأنه مسجل بقواعد البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (!availableSSNOptional(oldSSN.Text))
                {
                    MessageBox.Show($"يرجى التأكد من الرقم الموحد القديم لأنه غير مسجل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void updateSSN(string ssnOld, string ssnNew)
        {
            string Query;
            SqlConnection conDataBase;
            SqlDataAdapter adapter;
            SqlCommand command;
            try
            {
                Query = "UPDATE patientInfo SET ssn=N'" + ssnNew + "' where ssn =N'" + ssnOld + "'";

                conDataBase = new SqlConnection(constring);
                adapter = new SqlDataAdapter();
                command = new SqlCommand(Query, conDataBase);
                conDataBase.Open();
                adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void updateMeetingTitle(string ssnOld, string ssnNew)
        {
            string Query;
            SqlConnection conDataBase;
            SqlDataAdapter adapter;
            SqlCommand command;
            try
            {
                Query = "UPDATE periodicMeetings SET meetingTitle=N'" + ssnNew + "' where meetingTitle =N'" + ssnOld + "'";

                conDataBase = new SqlConnection(constring);
                adapter = new SqlDataAdapter();
                command = new SqlCommand(Query, conDataBase);
                conDataBase.Open();
                adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void interedInstituteBrush_MouseHover(object sender, EventArgs e)
        {
            interedInstituteBrush.Image = orangeBrush;
        }

        private void interedInstituteBrush_MouseLeave(object sender, EventArgs e)
        {
            interedInstituteBrush.Image = whiteBrush;
        }

        private void accidentsBrush_MouseHover(object sender, EventArgs e)
        {
            accidentsBrush.Image = orangeBrush;
        }

        private void accidentsBrush_MouseLeave(object sender, EventArgs e)
        {
            accidentsBrush.Image = whiteBrush;
        }

        private void employersBrush_MouseHover(object sender, EventArgs e)
        {
            employersBrush.Image = orangeBrush;
        }

        private void employersBrush_MouseLeave(object sender, EventArgs e)
        {
            employersBrush.Image = whiteBrush;
        }

        private void treatmentPlacesBrush_MouseHover(object sender, EventArgs e)
        {
            treatmentPlacesBrush.Image = orangeBrush;
        }

        private void treatmentPlacesBrush_MouseLeave(object sender, EventArgs e)
        {
            treatmentPlacesBrush.Image = whiteBrush;
        }

        private void InCaseOfMarriageBrush_MouseHover(object sender, EventArgs e)
        {
            InCaseOfMarriageBrush.Image = orangeBrush;
        }

        private void InCaseOfMarriageBrush_MouseLeave(object sender, EventArgs e)
        {
            InCaseOfMarriageBrush.Image = whiteBrush;
        }

        private void fatherBigFamilyBrush_MouseHover(object sender, EventArgs e)
        {
            fatherBigFamilyBrush.Image = orangeBrush;
        }

        private void fatherBigFamilyBrush_MouseLeave(object sender, EventArgs e)
        {
            fatherBigFamilyBrush.Image = whiteBrush;
        }

        private void motherBigFamilyRB_MouseHover(object sender, EventArgs e)
        {
            motherBigFamilyRB.Image = orangeBrush;
        }

        private void motherBigFamilyRB_MouseLeave(object sender, EventArgs e)
        {
            motherBigFamilyRB.Image = whiteBrush;
        }

        private void studyingPhaseBrush_MouseHover(object sender, EventArgs e)
        {
            studyingPhaseBrush.Image = orangeBrush;
        }

        private void studyingPhaseBrush_MouseLeave(object sender, EventArgs e)
        {
            studyingPhaseBrush.Image = whiteBrush;
        }

        private void targetMeetingsBrush_MouseHover(object sender, EventArgs e)
        {
            targetMeetingsBrush.Image = orangeBrush;
        }

        private void targetMeetingsBrush_MouseLeave(object sender, EventArgs e)
        {
            targetMeetingsBrush.Image = whiteBrush;
        }

        private void interedInstituteBrush_Click(object sender, EventArgs e)
        {
            clearingRehabilationDGV_1stPage();
        }

        private void accidentsBrush_Click(object sender, EventArgs e)
        {
            clearingInjuriesDGV_2ndPage();
        }

        private void employersBrush_Click(object sender, EventArgs e)
        {
            clearingEmployersDGV_3rdPage();
        }

        private void treatmentPlacesBrush_Click(object sender, EventArgs e)
        {
            clearingTreatmentPlacesDGVDGV_4thPage();
        }

        private void InCaseOfMarriageBrush_Click(object sender, EventArgs e)
        {
            clearingpatientMaritalStatusDGV_5thPage();
        }

        private void fatherBigFamilyBrush_Click(object sender, EventArgs e)
        {
            clearingFatherMariageDGV_6thPage();
        }

        private void motherBigFamilyRB_Click(object sender, EventArgs e)
        {
            clearingMotherMariageDGV_6thPage();
        }

        private void studyingPhaseBrush_Click(object sender, EventArgs e)
        {
            clearingTeenSchoolStagesDGV_7thPage();
        }

        private void targetMeetingsBrush_Click(object sender, EventArgs e)
        {
            clearingMeetingDGV_9thPage();
        }

        private void deleteMeetingButton_MouseHover(object sender, EventArgs e)
        {
            deleteMeetingButton.ImageIndex = 1;
        }

        private void deleteMeetingButton_MouseLeave(object sender, EventArgs e)
        {
            deleteMeetingButton.ImageIndex = 0;
        }

        private void deleteMeetingButton_Click(object sender, EventArgs e)
        {
            deleteMeetingButton_();
        }

        private void meetingToogleButton_Click(object sender, EventArgs e)
        {
            if (meetingToogleButton.IsOn)
            {
                newMeetingRB.Checked = true;
            }
            else
            {
                editMeetingRB.Checked = true;
            }
        }
        private void newMeetingRB_CheckedChanged(object sender, EventArgs e)
        {
            if (newMeetingRB.Checked)
            {
                meetingToogleButton.IsOn = true;
                label75.Visible = true;
                meetingTitleComboBox.Visible = false;
                meetingTitleTextBox.Visible = true;
            }
            else
            {
                meetingToogleButton.IsOn = false; ;
                label75.Visible = false;
            }
        }
        private void editMeetingRB_CheckedChanged(object sender, EventArgs e)
        {
            meetingTitleTextBox.Visible = false;
            meetingTitleComboBox.Visible = true;
        }
        private void deleteMeetingRB_CheckedChanged(object sender, EventArgs e)
        {
            meetingTitleTextBox.Visible = false;
            meetingTitleComboBox.Visible = true;
        }
        private void editMeetingTitle_CheckedChanged_1(object sender, EventArgs e)
        {

            if (editMeetingTitle.Checked)
            {
                meetingTitleTextBox.Visible = false;
                meetingTitleComboBox.Visible = true;
                editMeetingTitlePanel.Visible = true;
                editTitleOldComboBox.Text = meetingTitleComboBox.Text;
                editTitleNewTextBox.Text = "";
                meetingToogleButton.IsOn = false;
                MessageBox.Show("ظهر مربع على يمين الشاشة .. يرجى اختيار العنوان المراد تغييره وإدخال العنوان الجديد والضغط على حفظ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                editMeetingTitlePanel.Visible = false;
            }
        }

        private void TabPage4_0_Enter(object sender, EventArgs e)
        {
            loadingTitlesInComboBox();
        }
        private void loadingTitlesInComboBox()
        {
            meetingTitleComboBox.Items.Clear();
            editTitleOldComboBox.Items.Clear();
            SqlConnection conDataBase = new SqlConnection(constring);
            conDataBase.Open();
            string Query = "select distinct meetingTitle from periodicMeetings;";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(Query, conDataBase);
            da.Fill(dt);
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["meetingTitle"].ToString() != "")
                    {
                        meetingTitleComboBox.Items.Add(dr["meetingTitle"].ToString());
                        editTitleOldComboBox.Items.Add(dr["meetingTitle"].ToString());
                    }
                }
            }
            catch
            {
            }
            conDataBase.Close();
        }

        private void meetingTitleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetDGV.Rows.Clear();
            targetDGV.Refresh();
            clearingMeetingDGV_9thPage();
            loadingNinthPage();
        }

        private void editTitleOldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            meetingTitleComboBox.Text = editTitleOldComboBox.Text;
        }

        private void editTitleButton_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            con = new SqlConnection(constring);

            con.Open();
            string name = new SqlCommand("IF EXISTS(Select 1 from periodicMeetings where meetingTitle=N'" + editTitleNewTextBox.Text + "' ) BEGIN Select 1 from periodicMeetings where meetingTitle=N'" + editTitleNewTextBox.Text + "'  END ELSE BEGIN SELECT 0 END", con).ExecuteScalar().ToString();
            if (name == "0")
            {
                string message = $"سيتم تعديل عنوان المقابلة {editTitleOldComboBox.Text} إلى {editTitleNewTextBox.Text}";
                DialogResult dialogResult = MessageBox.Show(message, "يرجى التأكد", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    updateMeetingTitle(editTitleOldComboBox.Text, editTitleNewTextBox.Text);
                    message = "بنجاح " + editTitleNewTextBox.Text + " إلى " + editTitleOldComboBox.Text + " تم تعديل عنوان المقابلة ";
                    MessageBox.Show(message, "عاااش", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearingNinthPage();
                    newMeetingRB.Checked = true;
                }
            }
            else
            {
                MessageBox.Show($"يرجى تغيير عنوان المقابلة نظرًا لأنه موجود في قاعدة البيانات مسبقًا ولا يمكن إضافة عناوين مشابهة لأنها نقطة المركز في الصفحة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void patientReportButton_Click(object sender, EventArgs e)
        {
            patientReports patientReports = new patientReports();
            ReportPrintTool printTool = new ReportPrintTool(patientReports);
            printTool.ShowRibbonPreview();
        }
    }
}