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

namespace phsycologyForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        //====> Static to be used across the application <====

        static string patientSex;
        static string patientType;
        static string patientStatus;
        string attendedWith;
        string reasonsToQuitSchool = "";
        string patientBossRelation = "";
        string patientCoworkerRelation = "";
        string patientWorkRegularity = "";
        string patientEconomicStatus = "";
        string patientHome = "";
        string patientWorkNature = "";
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
            //==> 1s General Information Initialization
            // Initializing the RadioButtons and checkboxes
            maleRB.Checked = true;
            adultRB.Checked = true;
            singleRB.Checked = true;
            AtSingleRB.Checked = true;
            leftSchoolCB.Checked = true;
            wifeWorkingRB.Checked = true;
            LSrepitiveFailreRB.Checked = true;
            //deactivating the others group at the start
            deactivateOthersTextBoxAndLabelGroup(AtterndeOthersTextBox, label11);
            deactivateOthersTextBoxAndLabelGroup(LSothersTextBox, label12);
            deactivateOthersTextBoxAndLabelGroup(TFothersTextBox, label15);

            //==> 2s Social Charicterstics Initialization
            // Initializing the RadioButtons and checkboxes
            poorEconimicRB.Checked = true;
            noAIRB.Checked = true;
            ownedRB.Checked = true;
            noFPRB.Checked = true;
            bossRelGoodRB.Checked = true;
            coworkersRelGoodRB.Checked = true;
            regulatedRB.Checked = true;
            officialHoursRB.Checked = true;
            //deactivating the others textBoxes at the start
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
            deactivateTextBox(fromSideTextBox);

            // 5s ==>  Big Family Environmental Analysis Initialization
            fatherWorkingRB.Checked = true;
            motherWorkingRB.Checked = true;
            smallFamilyRB.Checked = true;
            deactivateTextBox(otherResponsibilitiesTextBox);

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



        // Adjusting the app to the user choice on radio buttons

        // ==////==> SEX <==////==
        private void maleRB_CheckedChanged(object sender, EventArgs e)
        {
            if (maleRB.Checked)
            {
                patientSex = "male";
                adultRB.Text = "بالغ";
                teenRB.Text = "مراهق";
                singleRB.Text = "أعزب";
                marriedRB.Text = "متزوج";
                separatedRB.Text = "منفصل";
                divorcedRB.Text = "مطلق";
                AtWifeRB.Text = "الزوجة";
                AtSingleRB.Text = "وحده";
                label9.Text = "حاصل على";
                EDwifeGroupBox.Text = "الزوجة";
                forFemaleMarriageGB.Enabled = false;
            }
            else
            {
                patientSex = "female";
                adultRB.Text = "بالغة";
                teenRB.Text = "قاصر";
                singleRB.Text = "عزباء";
                marriedRB.Text = "متزوجة";
                separatedRB.Text = "منفصلة";
                divorcedRB.Text = "مطلقة";
                AtWifeRB.Text = "الزوج";
                AtSingleRB.Text = "وحدها";
                label9.Text = "حاصلة على";
                EDwifeGroupBox.Text = "الزوج";
                forFemaleMarriageGB.Enabled = true;
            }
        }

        // ==////==> TYPE <==////==

        private void adultRB_CheckedChanged(object sender, EventArgs e)
        {
            if (adultRB.Checked)
            {
                patientType = "adult";
                maritalStatusGB.Enabled = true;
                transferrefFromGroupBox.Enabled = false;
                EDwifeGroupBox.Enabled = true;
                AtSonRB.Enabled = true;
                healthStatusImpactOnWorkGB.Enabled = true;
                professionalRelationshipsGB.Enabled = true;
                ownedRB.Checked = true;
            }
            else
            {
                patientType = "teen";
                maritalStatusGB.Enabled = false;
                transferrefFromGroupBox.Enabled = true;
                EDwifeGroupBox.Enabled = false;
                AtSonRB.Enabled = false;
                healthStatusImpactOnWorkGB.Enabled = false;
                professionalRelationshipsGB.Enabled = false;
                familyHomeRB.Checked = true;

            }
        }

        // ==////==> MARITIAL STATUS <==////==

        // ===== SINGLE WOLF =====
        private void singleRB_CheckedChanged(object sender, EventArgs e)
        {
            if (singleRB.Checked)
            {
                patientStatus = "أعزب";
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
                patientStatus = "أعزب";
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
                patientStatus = "متزوج";
            }
        }

        private void separatedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (separatedRB.Checked)
            {
                patientStatus = "منفصل";
            }
        }

        private void divorcedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (divorcedRB.Checked)
            {
                patientStatus = "مطلق";
            }
        }



        private void msMarriedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (msMarriedRB.Checked)
            {
                patientStatus = "متزوج";
            }
        }
        private void msSeperatedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (msSeperatedRB.Checked)
            {
                patientStatus = "منفصل";
            }
        }

        private void msDivorcedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (msDivorcedRB.Checked)
            {
                patientStatus = "مطلق";
            }
        }


        private void InitialPageTabPage_Enter(object sender, EventArgs e)
        {
            if (patientStatus == "أعزب")
            {
                singleRB.Checked = true;
                msSingleRB.Checked = true;
            }
            else if (patientStatus == "متزوج")
            {
                marriedRB.Checked = true;
                msMarriedRB.Checked = true;
            }
            else if (patientStatus == "منفصل")
            {
                separatedRB.Checked = true;
                msSeperatedRB.Checked = true;
            }
            else if (patientStatus == "مطلق")
            {
                divorcedRB.Checked = true;
                msDivorcedRB.Checked = true;
            }
        }

        private void InitialPageTabPage_Leave(object sender, EventArgs e)
        {
            if (patientStatus == "أعزب")
            {
                singleRB.Checked = true;
                msSingleRB.Checked = true;
            }
            else if (patientStatus == "متزوج")
            {
                marriedRB.Checked = true;
                msMarriedRB.Checked = true;
            }
            else if (patientStatus == "منفصل")
            {
                separatedRB.Checked = true;
                msSeperatedRB.Checked = true;
            }
            else if (patientStatus == "مطلق")
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


        //====> Another RadioButton Activating the groups of textBoxes and labels on the form <====

        private void AtSingleRB_CheckedChanged(object sender, EventArgs e)
        {
            if (AtSingleRB.Checked)
            {
                attendedWith = AtSingleRB.Text;
            }
        }

        private void AtWifeRB_CheckedChanged(object sender, EventArgs e)
        {
            if (AtWifeRB.Checked)
            {
                attendedWith = AtWifeRB.Text;
            }
        }

        private void AtBrotherRB_CheckedChanged(object sender, EventArgs e)
        {
            if (AtBrotherRB.Checked)
            {
                attendedWith = AtBrotherRB.Text;
            }
        }

        private void AtFatherRB_CheckedChanged(object sender, EventArgs e)
        {
            if (AtFatherRB.Checked)
            {
                attendedWith = AtFatherRB.Text;
            }
        }

        private void AtSonRB_CheckedChanged(object sender, EventArgs e)
        {
            if (AtSonRB.Checked)
            {
                attendedWith = AtSonRB.Text;
            }
        }

        private void AtRelativeRB_CheckedChanged(object sender, EventArgs e)
        {
            if (AtRelativeRB.Checked)
            {
                attendedWith = AtRelativeRB.Text;
            }
        }
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
        private void AtterndeOthersTextBox_Leave(object sender, EventArgs e)
        {
            if (AtOthersRB.Checked)
            {
                attendedWith = AtterndeOthersTextBox.Text;
            }
        }

        private void LSrepitiveFailreRB_CheckedChanged(object sender, EventArgs e)
        {
            if (LSrepitiveFailreRB.Checked)
            {
                reasonsToQuitSchool = LSrepitiveFailreRB.Text;
            }
        }

        private void LSworkRB_CheckedChanged(object sender, EventArgs e)
        {
            if (LSworkRB.Checked)
            {
                reasonsToQuitSchool = LSworkRB.Text;
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
        private void LSothersTextBox_Leave(object sender, EventArgs e)
        {
            if (LSotheRB.Checked)
            {
                reasonsToQuitSchool = LSothersTextBox.Text;
            }
        }

        private void TFOthersRB_CheckedChanged(object sender, EventArgs e)
        {
            if (TFOthersRB.Checked)
            {
                reactivateOthersTextBoxAndLabelGroup(TFothersTextBox, label15);
            }
            else
            {
                deactivateOthersTextBoxAndLabelGroup(TFothersTextBox, label15);
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

            if (AtOthersRB.Checked)
            {
                if (String.IsNullOrEmpty(AtterndeOthersTextBox.Text))
                {
                    errorMessage += "حضر برفقة من؟, ";
                    counter++;
                }
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
            if (teenRB.Checked)
            {
                if (TFOthersRB.Checked)
                {

                    if (String.IsNullOrEmpty(TFothersTextBox.Text))
                    {
                        errorMessage += "التحويل من؟, ";
                        counter++;
                    }
                }
                if (String.IsNullOrEmpty(accuseTextBox.Text))
                {
                    errorMessage += "التهمة, ";
                    counter++;
                }
                if (String.IsNullOrEmpty(purposeTexBox.Text))
                {
                    errorMessage += "الغرض من المقابلة, ";
                    counter++;
                }
            }

            if (String.IsNullOrEmpty(currentComplainTextBox.Text))
            {
                errorMessage += "الشكوى الحالية, ";
                counter++;
            }

            if (errorMessage != "")
            {
                if (counter <= 5)
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

            if (yesFPRB.Checked)
            {
                if (String.IsNullOrEmpty(financialProblemsTextBox.Text))
                {
                    errorMessage += "المشكلات المالية, ";
                    counter++;
                }
            }


            if (adultRB.Checked)
            {
                if (String.IsNullOrEmpty(workStartAgeTextBox.Text))
                {
                    errorMessage += "عمر بداية العمل, ";
                    counter++;
                }
                if (String.IsNullOrEmpty(employerTextBox.Text))
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
                if (anyInjuriesCB.Checked)
                {
                    if (injuriesDGV.Rows.Count == 0)
                    {
                        errorMessage += "إضافة حوادث وكسور, ";
                        counter++;
                    }
                }
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
                if ((monthUsedTextBox.Text == "شهر") && (yearsUsedTextBox.Text == "سنة"))
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
                if (treatmentPlacesDGV.Rows.Count == 0)
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
                if (fromSideTextBox.Text == "من جهة")
                {
                    errorMessage += "من جهة, ";
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
                if (patientMaritalStatusDGV.Rows.Count == 0)
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
                        errorMessage += "تفاصيل الزيجات جميعها, ";
                        counter++;
                    }

                }
                else
                {
                    errorMessage += "عدد الزيجات بالأرقام ليس بالحروف, ";
                    counter++;
                }

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
                    errorMessage += "تفاصيل زيجات الأب جميعها, ";
                    counter++;
                }

            }
            else
            {
                errorMessage += "عدد زيجات الأم بالأرقام ليس بالحروف, ";
                counter++;
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

        private void bossRelGoodRB_CheckedChanged(object sender, EventArgs e)
        {
            if (bossRelGoodRB.Checked)
            {
                patientBossRelation = "جيدة";
            }
        }

        private void bossRelNormalRB_CheckedChanged(object sender, EventArgs e)
        {
            if (bossRelNormalRB.Checked)
            {
                patientBossRelation = "عادية";
            }
        }

        private void bossRelBadRB_CheckedChanged(object sender, EventArgs e)
        {
            if (bossRelBadRB.Checked)
            {
                patientBossRelation = "متوترة";
            }
        }

        private void coworkersRelGoodRB_CheckedChanged(object sender, EventArgs e)
        {
            if (coworkersRelGoodRB.Checked)
            {
                patientCoworkerRelation = "جيدة";
            }
        }

        private void coworkersRelNormalRB_CheckedChanged(object sender, EventArgs e)
        {
            if (coworkersRelNormalRB.Checked)
            {
                patientCoworkerRelation = "عادية";
            }
        }

        private void coworkersRelBAdRB_CheckedChanged(object sender, EventArgs e)
        {
            if (coworkersRelBAdRB.Checked)
            {
                patientCoworkerRelation = "متوترة";
            }
        }

        private void regulatedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (regulatedRB.Checked)
            {
                patientWorkRegularity = regulatedRB.Text;
            }
        }

        private void conditionallyRB_CheckedChanged(object sender, EventArgs e)
        {
            if (conditionallyRB.Checked)
            {
                patientWorkRegularity = conditionallyRB.Text;
            }
        }

        private void notRegularRB_CheckedChanged(object sender, EventArgs e)
        {
            if (notRegularRB.Checked)
            {
                patientWorkRegularity = notRegularRB.Text;
            }
        }

        private void poorEconimicRB_CheckedChanged(object sender, EventArgs e)
        {
            if (poorEconimicRB.Checked)
            {
                patientEconomicStatus = "ضعيف";
            }
        }

        private void goodEconomicRB_CheckedChanged(object sender, EventArgs e)
        {
            if (goodEconomicRB.Checked)
            {
                patientEconomicStatus = "جيد";
            }
        }

        private void excellentEconomicRB_CheckedChanged(object sender, EventArgs e)
        {
            if (excellentEconomicRB.Checked)
            {
                patientEconomicStatus = "ممتاز";
            }
        }

        private void ownedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (ownedRB.Checked)
            {
                patientHome = "ملك";
            }
        }

        private void rentRB_CheckedChanged(object sender, EventArgs e)
        {
            if (rentRB.Checked)
            {
                patientHome = "إيجار";
            }
        }

        private void familyHomeRB_CheckedChanged(object sender, EventArgs e)
        {
            if (familyHomeRB.Checked)
            {
                patientHome = "بمنزل العائلة";
            }
        }

        private void officialHoursRB_CheckedChanged(object sender, EventArgs e)
        {
            if (officialHoursRB.Checked)
            {
                patientWorkNature = officialHoursRB.Text;
            }
        }

        private void nightShiftsRB_CheckedChanged(object sender, EventArgs e)
        {
            if (nightShiftsRB.Checked)
            {
                patientWorkNature = nightShiftsRB.Text;
            }
        }

        private void morningShiftsRB_CheckedChanged(object sender, EventArgs e)
        {
            if (morningShiftsRB.Checked)
            {
                patientWorkNature = morningShiftsRB.Text;
            }
        }

        private void shiftsRB_CheckedChanged(object sender, EventArgs e)
        {
            if (shiftsRB.Checked)
            {
                patientWorkNature = shiftsRB.Text;
            }
        }

        private void workingNatureOthersRB_CheckedChanged(object sender, EventArgs e)
        {
            if (workingNatureOthersRB.Checked)
            {
                reactivateTextBox(workingNatureOthersTextBox);
                patientWorkNature = workingNatureOthersTextBox.Text;
            }
            else
            {
                deactivateTextBox(workingNatureOthersTextBox);
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
                SuicideAttempts = noAttemptsRB.Text;
            }
            else
            {
                reactivateTextBox(suicideWayTextBox);
                reactivateTextBox(suicideDetailsTextBox);
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
                deactivateTextBox(fromSideTextBox);
            }
            else
            {
                reactivateTextBox(fromSideTextBox);
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

        private void fromSideTextBox_Enter(object sender, EventArgs e)
        {
            enterTextBox(fromSideTextBox, "من جهة");
        }

        private void fromSideTextBox_Leave(object sender, EventArgs e)
        {
            leaveTextBox(fromSideTextBox, "من جهة");
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
            dynamicChildrenCalculator( girlsCountPatientsTextBox, boysCountPatientsTextBox, totalSonsTextBox);
        }
        
        private void boysCountPatientsTextBox_TextChanged(object sender, EventArgs e)
        {
            dynamicChildrenCalculator(boysCountPatientsTextBox, girlsCountPatientsTextBox, totalSonsTextBox);
        }

        ///
        ///

        //!!!!!!!!!!!!!! =======> The Big family Status Analysis Tab Control <======= !!!!!!!!!!!!!!

        ///
        ///

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

      

        // 1s DB Information
        private void circularButtton1_Click(object sender, EventArgs e)
        {
            if (firstPageTextBoxValidation())
            {
                try
                {
                    string Query = "IF NOT EXISTS (select 1 FROM de where ssn=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO patientInfo(ssn,name,age,nationality,caseFile,judge,birthDay,maritalStatus,sex,type,currentComplain,signDate,previousTreatment)" +
                        " VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.nameTextBox.Text + "',N'" + this.ageTextBox.Text + "',N'" + this.nationalityTextBox.Text + "',N'" + this.caseTextBox.Text + "',N'" + this.judgementTextBox.Text + "'" +
                        ",N'" + this.birthDayTP.Value.ToString("MM/dd/yyyy") + "',N'" + patientStatus + "',N'" + patientSex + "',N'" + patientType + "',N'" + this.currentComplainTextBox.Text + "',N'" + this.dateDTP.Value.ToString("MM/dd/yyyy") + "', 'FALSE') END ";

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

                    if (!(teenRB.Checked || singleRB.Checked) && leftSchoolCB.Checked)
                    {

                        Query = "IF NOT EXISTS (select 1 FROM EducationInfo where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO EducationInfo(ssnPatient,degree,graduationAge,leftSchool,Reasons,wifeDegree,wifeGraduationAge,wifeWorking) " +
                            "VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.educationalLevelTextBox.Text + "',N'" + this.graduationAgeTextBox.Text + "',N'" + this.leftSchoolCB.Checked + "',N'" + this.reasonsToQuitSchool + "'" +
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
                    else if (teenRB.Checked || singleRB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM EducationInfo where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO EducationInfo(ssnPatient,degree,graduationAge,leftSchool,Reasons)" +
                            " VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.educationalLevelTextBox.Text + "',N'" + this.graduationAgeTextBox.Text + "',N'" + this.leftSchoolCB.Checked + "',N'" + this.reasonsToQuitSchool + "') END ";

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

        // 2s DB Information
        private void addInjuryButton_Click(object sender, EventArgs e)
        {
            string[] row = { yearInjuredCB.Text, injuryDetailsTextBox.Text, fracturesTextBox.Text };
            injuriesDGV.Rows.Add(row);
        }

        private void circularButtton2_Click(object sender, EventArgs e)
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
                    if (adultRB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM socialCharacteristics where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                            "socialCharacteristics(ssnPatient,aggressive,depressive,anixious,doubtful,otherCharacteristics,bossRelation,cooworkersRelations,jobRegularity,economicStatus,anotherIncome,home,loan,workAge,employer,workNature,unsatisfied,unsatisfiedDetails,accidents) " +
                            "VALUES(N'" + this.SSNTextBox.Text + "',N'" + this.aggressiveCB.Checked + "',N'" + this.depressedCB.Checked + "',N'" + this.anixiousCB.Checked + "',N'" + this.doubtfullCB.Checked + "',N'" + othersString + "'" +
                            ",N'" + patientBossRelation + "',N'" + patientCoworkerRelation + "',N'" + patientWorkRegularity + "',N'" + patientEconomicStatus + "',N'" + anotherIncome + "',N'" + patientHome + "',N'" + loanProblems + "',N'" + workStartAgeTextBox.Text + "',N'" + employerTextBox.Text + "'" +
                            ",N'" + patientWorkNature + "',N'" + miserableJobCB.Checked + "',N'" + jobSatisfacton + "',N'" + anyInjuriesCB.Checked + "') END ";

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
                        Query = "IF NOT EXISTS (select 1 FROM socialCharacteristics where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                            "socialCharacteristics(ssnPatient,aggressive,depressive,anixious,doubtful,otherCharacteristics,economicStatus,anotherIncome,home,loan,accidents) " +
                            "VALUES(N'" + this.SSNTextBox.Text + "',N'" + this.aggressiveCB.Checked + "',N'" + this.depressedCB.Checked + "',N'" + this.anixiousCB.Checked + "',N'" + this.doubtfullCB.Checked + "',N'" + othersString + "'" +
                            ",N'" + patientEconomicStatus + "',N'" + anotherIncome + "',N'" + loanProblems + "',N'" + anyInjuriesCB.Checked + "') END ";

                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();

                    }

                    if (anyInjuriesCB.Checked)
                    {
                        for (int i = 0; i < injuriesDGV.Rows.Count-1; i++)
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

        // 3s DB Information

        private void addPlaceButton_Click(object sender, EventArgs e)
        {
            string[] row = { hospitalTreatmentTextBox.Text, doctorTreatmentTextBox.Text, fileNumberTreatmentTextBox.Text, notesTreatmentTextBox.Text };
            treatmentPlacesDGV.Rows.Add(row);
        }

        private void circularButtton3_Click(object sender, EventArgs e)
        {
            if (thirdPageTextBoxValidation())
            {
                try {
                    string Query;
                    SqlConnection conDataBase;
                    SqlDataAdapter adapter;
                    SqlCommand command;
                    if (!noAttemptsRB.Checked)
                    {
                        Query = "IF NOT EXISTS (select 1 FROM suicideAttempts where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO suicideAttempts(ssnPatient,attemptStatus,way,details) VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.SuicideAttempts + "',N'" + this.suicideWayTextBox.Text + "',N'" + this.suicideDetailsTextBox.Text + "') END ";

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

                    Query = "UPDATE patientInfo SET previousTreatment=N'" + this.previousTreatmentCB.Checked + "', previousTreatmentNotes= N'" + this.previousPatientHistoryNotesTextBox.Text + "' where ssn=N'" + this.SSNTextBox.Text + "'";

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


        // 4s DB Information

        private void addPatientMaritalStatusButton_Click(object sender, EventArgs e)
        {
            bool relativeBool = yesRelativeRB.Checked;
            string[] row = { marriagePatientOrderTextBox.Text, relativeBool.ToString(), fromSideTextBox.Text, boysCountPatientsTextBox.Text, girlsCountPatientsTextBox.Text, totalSonsTextBox.Text, husbandNationalityTextBox.Text, marriageDurationTextBox.Text, this.marriageFromDate.Value.ToString("MM/dd/yyyy"), this.marriageToDate.Value.ToString("MM/dd/yyyy") };
            patientMaritalStatusDGV.Rows.Add(row);
        }

        private void circularButtton4_Click(object sender, EventArgs e)
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
                    if (!msSingleRB.Checked && !maleRB.Checked && adultRB.Checked) {
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

                    if(!msSingleRB.Checked && adultRB.Checked)
                    {
                        for (int i = 0; i < patientMaritalStatusDGV.Rows.Count-1; i++)
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // 5s DB Information

        private void fatherMarriageDetailsAddButton_Click(object sender, EventArgs e)
        {
            if (fatherMarriageDGVValidation())
            {
                string[] row = { fatherMariiageOrderTextBox.Text, fatherBoysCountTextBox.Text, fatherGirlsCountTextBox.Text, fatherTotalKidsTextBox.Text, wifeFatherNationalityTextBox.Text, fatherMarriageDurationTextBox.Text };
                fatherDGV.Rows.Add(row);
            }
        }

        private void motherMarriageDetailsAddButton_Click(object sender, EventArgs e)
        {
            if (motherMarriageDGVValidation())
            {
                string[] row = { motherMariiageOrderTextBox.Text, motherBoysCountTextBox.Text, motherGirlsCountTextBox.Text, motherTotalKidsTextBox.Text, husbandMotherTextBox.Text, motherMarriageDurationTextBox.Text };
                motherDGV.Rows.Add(row);
            }
        }


        private void circularButtton5_Click(object sender, EventArgs e)
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
                    string patientResponisibilityTowards = (familyResponsibilitiesGB.Controls.OfType<RadioButton>().FirstOrDefault(a => a.Checked)).Text;

                    if(patientResponisibilityTowards == "آخرين")
                    {
                        patientResponisibilityTowards = otherResponsibilitiesTextBox.Text;
                    }

                     Query = "IF NOT EXISTS (select 1 FROM fatherMaritalStatus where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                                     "fatherMaritalStatus(ssnPatient,fatherStatus,totalMarriages,nationality,education) " +
                                     "VALUES(N'" + this.SSNTextBox.Text + "',N'" + fatherStatus+ "',N'" + this.totalFatherMarriageTextBox.Text + "'" +
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
                        Query = "INSERT INTO fatherMarriageDetails(ssnPatient,marriageOrder,boys,girls,total,spouseNationality,duration) " +
                            "VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.fatherDGV.Rows[i].Cells[0].Value.ToString() + "',N'" + this.fatherDGV.Rows[i].Cells[1].Value.ToString() + "',N'" + this.fatherDGV.Rows[i].Cells[2].Value.ToString() + "'" +
                            ",N'" + this.fatherDGV.Rows[i].Cells[3].Value.ToString() + "',N'" + this.fatherDGV.Rows[i].Cells[4].Value.ToString() + "',N'" + this.fatherDGV.Rows[i].Cells[5].Value.ToString() + "')";
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
                        Query = "INSERT INTO motherMarriageDetails(ssnPatient,marriageOrder,boys,girls,total,spouseNationality,duration) " +
                            "VALUES (N'" + this.SSNTextBox.Text + "',N'" + this.motherDGV.Rows[i].Cells[0].Value.ToString() + "',N'" + this.motherDGV.Rows[i].Cells[1].Value.ToString() + "',N'" + this.motherDGV.Rows[i].Cells[2].Value.ToString() + "'" +
                            ",N'" + this.motherDGV.Rows[i].Cells[3].Value.ToString() + "',N'" + this.motherDGV.Rows[i].Cells[4].Value.ToString() + "',N'" + this.motherDGV.Rows[i].Cells[5].Value.ToString() + "')";
                        conDataBase = new SqlConnection(constring);
                        adapter = new SqlDataAdapter();
                        command = new SqlCommand(Query, conDataBase);
                        conDataBase.Open();
                        adapter.InsertCommand = new SqlCommand(Query, conDataBase);
                        adapter.InsertCommand.ExecuteNonQuery();
                        command.Dispose();
                        conDataBase.Close();
                    }

                    Query = "IF NOT EXISTS (select 1 FROM siblingsDetails where ssnPatient=N'" + this.SSNTextBox.Text + "') BEGIN INSERT INTO " +
                                    "siblingsDetails(ssnPatient,brothers,sisters,totalSiblings,patientOrder,nearestPerson,responsibleForCount,responsibleForDescription,responsiblitiesToward,pressuredFromResponsibility) " +
                                    "VALUES(N'" + this.SSNTextBox.Text + "',N'" + this.brothersCountTextBox.Text + "',N'" + this.sistersCoutTextBox.Text + "'" +
                                    ",N'" + this.totalMembersTextBox.Text + "',N'" + this.patientOrderTextBox.Text + "',N'" + this.nearestFamilyMemberTextBox.Text + "',N'" + this.responsibleForCoutTextBox.Text + "'" +
                                    ",N'" + this.responsibleForDescriptionTextBox.Text + "',N'" + patientResponisibilityTowards+ "',N'" + this.pressureCheckBox.Checked + "') END ";

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
    }
}
