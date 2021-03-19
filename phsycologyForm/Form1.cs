using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phsycologyForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pages are numbered from 1s to 5s respectfully to their order 
        /// 1s ==> General Information
        /// 2s ==> Personal Analysis ==> Social Charateristics
        /// 3s ==> Personal Analysis ==> Medical Issues
        /// 
        /// 
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
            //Disabling the previous Treatment GB
            treatmentPlacesGB.Enabled = false;

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

        //====> Static to be used across the application <====

        static string patientSex;
        static string patientType;
        static string patientStatus;



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


            }
            else
            {
                patientType = "teen";
                maritalStatusGB.Enabled = false;
                transferrefFromGroupBox.Enabled = true;
                EDwifeGroupBox.Enabled = false;
                AtSonRB.Enabled = false;
            }
        }

        // ==////==> MARITIAL STATUS <==////==

        // ===== SINGLE WOLF =====
        private void singleRB_CheckedChanged(object sender, EventArgs e)
        {
            if (singleRB.Checked)
            {
                EDwifeGroupBox.Enabled = false;
                AtWifeRB.Enabled = false;
                AtSonRB.Enabled = false;

            }
            else
            {
                EDwifeGroupBox.Enabled = true;
                AtWifeRB.Enabled = true;
                AtSonRB.Enabled = true;

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
            }
            else
            {
                reactivateTextBox(suicideWayTextBox);
                reactivateTextBox(suicideDetailsTextBox);
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
                deactivateTextBox(drugUsedDetailsTextBox);
                deactivateOthersTextBoxAndLabelGroup(yearsUsedTextBox, label24);
            }
            else
            {
                reactivateTextBox(startingAgeTextBox);
                reactivateTextBox(TypesUsedTextBox);
                reactivateTextBox(monthUsedTextBox);
                reactivateTextBox(drugUsedDetailsTextBox);
                reactivateOthersTextBoxAndLabelGroup(yearsUsedTextBox, label24);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }       
}
