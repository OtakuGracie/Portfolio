using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace PokemonHGSSMoveEditor
{
    public partial class mainForm : Form, IMoveEditorView
    {
        private IMoveEditorController controller = MoveEditorController.getInstance();

        public mainForm()
        {
            InitializeComponent();

            //event handlers
            moveComboBx.SelectedValueChanged += new EventHandler(moveComboBx_SelectedValueChanged);
            effectMaskTxtBx.Validating += new CancelEventHandler(effectMaskTxtBx_Validating);
            powerMaskTxtBx.Validating += new CancelEventHandler(powerMaskTxtBx_Validating);
            accuracyMaskTxtBx.Validating += new CancelEventHandler(accuracyMaskTxtBx_Validating);
            ppMaskTxtBx.Validating += new CancelEventHandler(ppMaskTxtBx_Validating);
            effectChanceMaskTxtBx.Validating += new CancelEventHandler(effectChanceMaskTxtBx_Validating);
            priorityMaskTxtBx.Validating += new CancelEventHandler(priorityMaskTxtBx_Validating);
            contestEffectMaskTxtBx.Validating += new CancelEventHandler(contestEffectMaskTxtBx_Validating);
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                categoryComboBx.Items.Add(category);
            }

            foreach (ContestCondition condition in Enum.GetValues(typeof(ContestCondition)))
            {
                contestConditionComboBx.Items.Add(condition);
            }

            foreach (Target target in Enum.GetValues(typeof(Target)))
            {
                targetComboBx.Items.Add(target);
            }

            controller.setView(this);
            controller.setModel(MoveEditorModel.getInstance());

            showMoveList(controller.getMoveList());
            showMoveTypes(controller.getTypeList());

            if (!selectFile())
            {
                this.Close();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            (int[] oldMoveData, bool[] flags) = controller.getOldValues();

            effectMaskTxtBx.Text = oldMoveData[Constants.EFFECTINDEX].ToString();
            categoryComboBx.SelectedIndex = oldMoveData[Constants.CATEGORYINDEX];
            powerMaskTxtBx.Text = oldMoveData[Constants.POWERINDEX].ToString();
            typeComboBx.SelectedIndex = oldMoveData[Constants.TYPEINDEX];
            accuracyMaskTxtBx.Text = oldMoveData[Constants.ACCURACYINDEX].ToString();
            ppMaskTxtBx.Text = oldMoveData[Constants.PPINDEX].ToString();
            effectChanceMaskTxtBx.Text = oldMoveData[Constants.EFFECTCHANCEINDEX].ToString();
            targetComboBx.SelectedItem = (Target)oldMoveData[Constants.TARGETINDEX];
            priorityMaskTxtBx.Text = ((sbyte)oldMoveData[Constants.PRIORITYINDEX]).ToString(); //priority has to be casted to signed byte so that negative priority values display correctly
            contestEffectMaskTxtBx.Text = oldMoveData[Constants.CONTESTEFFECTINDEX].ToString();
            contestConditionComboBx.SelectedIndex = oldMoveData[Constants.CONTESTCONDITIONINDEX];

            contactCheckBx.Checked = flags[Constants.CONTACTFLAGINDEX];
            protectCheckBx.Checked = flags[Constants.PROTECTFLAGINDEX];
            magicCoatCheckBx.Checked = flags[Constants.MAGICCOATFLAGINDEX];
            snatchCheckBx.Checked = flags[Constants.SNATCHFLAGINDEX];
            mirrorMoveCheckBx.Checked = flags[Constants.MIRRORMOVEFLAGINDEX];
            kingsRockCheckBx.Checked = flags[Constants.KINGSROCKFLAGINDEX];
            unkFlag1CheckBx.Checked = flags[Constants.UNK1FLAGINDEX];
            unkFlag2CheckBx.Checked = flags[Constants.UNK2FLAGINDEX];
        }

        public void showMoveList(List<string> moveList)
        {
            moveComboBx.Items.Clear();

            moveComboBx.BeginUpdate();
            foreach (string move in moveList)
            {
                moveComboBx.Items.Add(move);
            }
            moveComboBx.EndUpdate();
        }

        public void showMoveTypes(List<string> typeList)
        {
            typeComboBx.Items.Clear();

            foreach (string type in typeList)
            {
                typeComboBx.Items.Add(type.ToUpper());
            }
        }

        public bool selectFile()
        {
            OpenFileDialog chooseFile = new OpenFileDialog();
            chooseFile.Filter = "NDS Roms (*.nds)|*.nds|All files (*.*)|*.*";
            chooseFile.InitialDirectory = Directory.GetCurrentDirectory();
            chooseFile.FilterIndex = 0;
            chooseFile.RestoreDirectory = true;

            if (chooseFile.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(chooseFile.FileName))
                {
                    return false;
                }

                controller.loadMoveData(chooseFile.FileName);

                //checks if a move has been selected, which occurs only after the first time moveData is loaded, then all the current form text is discarded for the currently stored moveData
                //this is done to prevent a bug in which the previous form text ends up stored as moveData after switching files while the move editor is open
                if (moveComboBx.SelectedIndex >= 0)
                {
                    (int[] moveData, bool[] flags) = controller.getMoveData(moveComboBx.SelectedIndex);

                    effectMaskTxtBx.Text = moveData[Constants.EFFECTINDEX].ToString();
                    categoryComboBx.SelectedIndex = moveData[Constants.CATEGORYINDEX];
                    powerMaskTxtBx.Text = moveData[Constants.POWERINDEX].ToString();
                    typeComboBx.SelectedIndex = moveData[Constants.TYPEINDEX];
                    accuracyMaskTxtBx.Text = moveData[Constants.ACCURACYINDEX].ToString();
                    ppMaskTxtBx.Text = moveData[Constants.PPINDEX].ToString();
                    effectChanceMaskTxtBx.Text = moveData[Constants.EFFECTCHANCEINDEX].ToString();
                    targetComboBx.SelectedItem = (Target)moveData[Constants.TARGETINDEX];
                    priorityMaskTxtBx.Text = moveData[Constants.PRIORITYINDEX].ToString(); 
                    contestEffectMaskTxtBx.Text = moveData[Constants.CONTESTEFFECTINDEX].ToString();
                    contestConditionComboBx.SelectedIndex = moveData[Constants.CONTESTCONDITIONINDEX];

                    contactCheckBx.Checked = flags[Constants.CONTACTFLAGINDEX];
                    protectCheckBx.Checked = flags[Constants.PROTECTFLAGINDEX];
                    magicCoatCheckBx.Checked = flags[Constants.MAGICCOATFLAGINDEX];
                    snatchCheckBx.Checked = flags[Constants.SNATCHFLAGINDEX];
                    mirrorMoveCheckBx.Checked = flags[Constants.MIRRORMOVEFLAGINDEX];
                    kingsRockCheckBx.Checked = flags[Constants.KINGSROCKFLAGINDEX];
                    unkFlag1CheckBx.Checked = flags[Constants.UNK1FLAGINDEX];
                    unkFlag2CheckBx.Checked = flags[Constants.UNK2FLAGINDEX];
                }

                moveComboBx.SelectedIndex = 0;
                this.Text = this.Text.Replace("*", "");

                return true;
            }
            else
            {
                return false;
            }
        }

        public void displayError(string errorMsg)
        {
            MessageBox.Show(errorMsg);
        }
        

        private void moveComboBx_SelectedValueChanged(object sender, EventArgs e)
        {
            (int[] moveData, bool[] flags) = controller.getMoveData(moveComboBx.SelectedIndex);

            updateMoveData();

            effectMaskTxtBx.Text = (moveData[Constants.EFFECTINDEX]).ToString();
            categoryComboBx.SelectedIndex = moveData[Constants.CATEGORYINDEX];
            powerMaskTxtBx.Text = (moveData[Constants.POWERINDEX]).ToString();
            typeComboBx.SelectedIndex = moveData[Constants.TYPEINDEX];
            accuracyMaskTxtBx.Text = (moveData[Constants.ACCURACYINDEX]).ToString();
            ppMaskTxtBx.Text = (moveData[Constants.PPINDEX]).ToString();
            effectChanceMaskTxtBx.Text = (moveData[Constants.EFFECTCHANCEINDEX]).ToString();
            targetComboBx.SelectedItem = (Target)moveData[Constants.TARGETINDEX]; 
            priorityMaskTxtBx.Text = (moveData[Constants.PRIORITYINDEX]).ToString();
            contestEffectMaskTxtBx.Text = (moveData[Constants.CONTESTEFFECTINDEX]).ToString();
            contestConditionComboBx.SelectedIndex = moveData[Constants.CONTESTCONDITIONINDEX];

            contactCheckBx.Checked = flags[Constants.CONTACTFLAGINDEX];
            protectCheckBx.Checked = flags[Constants.PROTECTFLAGINDEX];
            magicCoatCheckBx.Checked = flags[Constants.MAGICCOATFLAGINDEX];
            snatchCheckBx.Checked = flags[Constants.SNATCHFLAGINDEX];
            mirrorMoveCheckBx.Checked = flags[Constants.MIRRORMOVEFLAGINDEX];
            kingsRockCheckBx.Checked = flags[Constants.KINGSROCKFLAGINDEX];
            unkFlag1CheckBx.Checked = flags[Constants.UNK1FLAGINDEX];
            unkFlag2CheckBx.Checked = flags[Constants.UNK2FLAGINDEX];

            controller.storeOldValues(moveData, flags);

            //stores the index of the current move so that in updateMoveData() it can be retrieved after the selected move has changed
            controller.setPreviousMoveIndex(moveComboBx.SelectedIndex);
        }


        private void updateMoveData()
        {
            int[] moveData = new int[Constants.NUMMOVEDATABYTES];
            bool[] flags = new bool[Constants.NUMFLAGS];

            //checks if the form has loaded data into controls, only one control needs to be checked since data is loaded into all controls at the same time
            if (!string.IsNullOrEmpty(effectMaskTxtBx.Text))
            {
                moveData[Constants.EFFECTINDEX] = int.Parse(effectMaskTxtBx.Text);
                moveData[Constants.CATEGORYINDEX] = (int)categoryComboBx.SelectedItem;
                moveData[Constants.POWERINDEX] = byte.Parse(powerMaskTxtBx.Text);
                moveData[Constants.TYPEINDEX] = (byte)typeComboBx.SelectedIndex;
                moveData[Constants.ACCURACYINDEX] = byte.Parse(accuracyMaskTxtBx.Text);
                moveData[Constants.PPINDEX] = byte.Parse(ppMaskTxtBx.Text);
                moveData[Constants.EFFECTCHANCEINDEX] = byte.Parse(effectChanceMaskTxtBx.Text);
                moveData[Constants.TARGETINDEX] = (byte)(int)targetComboBx.SelectedItem;
                moveData[Constants.PRIORITYINDEX] = (byte)sbyte.Parse(priorityMaskTxtBx.Text);
                moveData[Constants.CONTESTEFFECTINDEX] = byte.Parse(contestEffectMaskTxtBx.Text);
                moveData[Constants.CONTESTCONDITIONINDEX] = (byte)(int)contestConditionComboBx.SelectedItem;

                flags[Constants.CONTACTFLAGINDEX] = contactCheckBx.Checked;
                flags[Constants.PROTECTFLAGINDEX] = protectCheckBx.Checked;
                flags[Constants.MAGICCOATFLAGINDEX] = magicCoatCheckBx.Checked;
                flags[Constants.SNATCHFLAGINDEX] = snatchCheckBx.Checked;
                flags[Constants.MIRRORMOVEFLAGINDEX] = mirrorMoveCheckBx.Checked;
                flags[Constants.KINGSROCKFLAGINDEX] = kingsRockCheckBx.Checked;
                flags[Constants.UNK1FLAGINDEX] = unkFlag1CheckBx.Checked;
                flags[Constants.UNK2FLAGINDEX] = unkFlag2CheckBx.Checked;

                if (controller.updateMoveData(moveData, flags, controller.getPreviousMoveIndex()))
                {
                    if (!this.Text.Contains("*"))
                    {
                        this.Text = this.Text + "*";
                    }
                }
            }
        }
        

        private void saveAsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateMoveData();

            var chooseFile = new SaveFileDialog
            {
                Filter = "All files (*.*)|*.*",
                InitialDirectory = Directory.GetCurrentDirectory(),
                RestoreDirectory = true
            };

            if (chooseFile.ShowDialog() == DialogResult.OK)
            {
                controller.saveToFile(chooseFile.FileName);
                this.Text = this.Text.Replace("*", "");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateMoveData();

            if (controller.getIsUnsavedChanges())
            {
                if (MessageBox.Show("There are unsaved changes. Do you want to discard changes made and open a new file anyway?", "Pokemon Gen 4 Move Editor",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    selectFile();
                }
            }
            else
            {
                selectFile();
            }
        }

        private void newTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var typeInputForm = new userTextInputForm("Enter name of the type to be created");
            typeInputForm.ShowDialog();


            if(typeInputForm.inputText != "")
            {
                controller.addNewType(typeInputForm.inputText);
                typeComboBx.Items.Add(typeInputForm.inputText.ToUpper());
            }
        }

        private void newMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var moveInputForm = new userTextInputForm("Enter name of the move to be created");
            moveInputForm.ShowDialog();


            if (moveInputForm.inputText != "")
            {
                
                moveComboBx.Items.Add(moveInputForm.inputText.ToUpper());
                controller.addNewMove(moveInputForm.inputText);
            }

            moveComboBx.SelectedIndex = moveComboBx.Items.Count - 1;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void effectMaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(effectMaskTxtBx.Text, out _) || int.Parse(effectMaskTxtBx.Text) > byte.MaxValue)
            {
                effectMaskTxtBx.Text = controller.getOldValues().Item1[Constants.EFFECTINDEX].ToString();
            }
        }

        private void powerMaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(powerMaskTxtBx.Text, out _) || int.Parse(powerMaskTxtBx.Text) > byte.MaxValue)
            {
                powerMaskTxtBx.Text = controller.getOldValues().Item1[Constants.POWERINDEX].ToString();

            }
        }

        private void accuracyMaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(accuracyMaskTxtBx.Text, out _) || int.Parse(accuracyMaskTxtBx.Text) > Constants.MAXPERCENTAGE)
            {
                accuracyMaskTxtBx.Text = controller.getOldValues().Item1[Constants.ACCURACYINDEX].ToString();
            }
        }

        private void ppMaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(ppMaskTxtBx.Text, out _))
            {
                ppMaskTxtBx.Text = controller.getOldValues().Item1[Constants.PPINDEX].ToString();
            }
        }

        private void effectChanceMaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(effectChanceMaskTxtBx.Text, out _) || int.Parse(effectChanceMaskTxtBx.Text) > Constants.MAXPERCENTAGE)
            {
                effectChanceMaskTxtBx.Text = controller.getOldValues().Item1[Constants.EFFECTCHANCEINDEX].ToString();
            }
        }

        private void priorityMaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(priorityMaskTxtBx.Text, out _) || int.Parse(priorityMaskTxtBx.Text) > Constants.MAXPRIORITY || int.Parse(priorityMaskTxtBx.Text) < -Constants.MAXPRIORITY)
            {
                priorityMaskTxtBx.Text = (controller.getOldValues().Item1[Constants.PRIORITYINDEX]).ToString();
            }
        }

        private void contestEffectMaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(contestEffectMaskTxtBx.Text, out _) || int.Parse(contestEffectMaskTxtBx.Text) > byte.MaxValue)
            {
                contestEffectMaskTxtBx.Text = controller.getOldValues().Item1[Constants.CONTESTEFFECTINDEX].ToString();
            }
        }

        private void MainForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            updateMoveData();

            if (controller.getIsUnsavedChanges())
            {
                if (MessageBox.Show("There are unsaved changes. Do you want to discard changes made and close anyway?", "Pokemon Gen 4 Move Editor",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

    }
}
