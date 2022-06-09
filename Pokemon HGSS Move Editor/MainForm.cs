using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            flag1MaskTxtBx.Validating += new CancelEventHandler(flag1MaskTxtBx_Validating);
            priorityMaskTxtBx.Validating += new CancelEventHandler(priorityMaskTxtBx_Validating);
            flag2MaskTxtBx.Validating += new CancelEventHandler(flag2MaskTxtBx_Validating);
            flag3MaskTxtBx.Validating += new CancelEventHandler(flag3MaskTxtBx_Validating);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                categoryComboBx.Items.Add(category);
            }

            foreach (ContestCondition condition in Enum.GetValues(typeof(ContestCondition)))
            {
                contestComboBx.Items.Add(condition);
            }

            foreach (Target target in Enum.GetValues(typeof(Target)))
            {
                targetComboBx.Items.Add(target);
            }

            classComboBx.Items.Add(00);
            classComboBx.Items.Add(01);

            controller.setView(this);
            controller.setModel(MoveEditorModel.getInstance());

            showMoveList(controller.getMoveList());
            showMoveTypes(controller.getTypeList());

            if (!selectFile())
            {
                this.close();
            }
        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            effectMaskTxtBx.Text = controller.getOldValue(Constants.EFFECTINDEX).ToString();
            classComboBx.SelectedIndex = controller.getOldValue(Constants.CLASSINDEX);
            categoryComboBx.SelectedIndex = controller.getOldValue(Constants.CATEGORYINDEX);
            powerMaskTxtBx.Text = controller.getOldValue(Constants.POWERINDEX).ToString();
            typeComboBx.SelectedIndex = controller.getOldValue(Constants.TYPEINDEX);
            accuracyMaskTxtBx.Text = controller.getOldValue(Constants.ACCURACYINDEX).ToString();
            ppMaskTxtBx.Text = controller.getOldValue(Constants.PPINDEX).ToString();
            effectChanceMaskTxtBx.Text = controller.getOldValue(Constants.EFFECTCHANCEINDEX).ToString();
            targetComboBx.SelectedItem = (Target)controller.getOldValue(Constants.TARGETINDEX);
            flag1MaskTxtBx.Text = controller.getOldValue(Constants.FLAG1INDEX).ToString();
            priorityMaskTxtBx.Text = ((sbyte)controller.getOldValue(Constants.PRIORITYINDEX)).ToString(); //priority has to be casted to signed byte so that negative priority values displays correctly
            flag2MaskTxtBx.Text = controller.getOldValue(Constants.FLAG2INDEX).ToString();
            flag3MaskTxtBx.Text = controller.getOldValue(Constants.FLAG3INDEX).ToString();
            contestComboBx.SelectedIndex = controller.getOldValue(Constants.CONTESTINDEX);
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
                if (moveComboBx.SelectedIndex >= 0)
                {
                    byte[] moveData = controller.getMoveData(moveComboBx.SelectedIndex);

                    effectMaskTxtBx.Text = ((int)moveData[Constants.EFFECTINDEX]).ToString();
                    classComboBx.SelectedIndex = (int)moveData[Constants.CLASSINDEX];
                    categoryComboBx.SelectedIndex = (int)moveData[Constants.CATEGORYINDEX];
                    powerMaskTxtBx.Text = ((int)moveData[Constants.POWERINDEX]).ToString();
                    typeComboBx.SelectedIndex = (int)moveData[Constants.TYPEINDEX];
                    accuracyMaskTxtBx.Text = ((int)moveData[Constants.ACCURACYINDEX]).ToString();
                    ppMaskTxtBx.Text = ((int)moveData[Constants.PPINDEX]).ToString();
                    effectChanceMaskTxtBx.Text = ((int)moveData[Constants.EFFECTCHANCEINDEX]).ToString();
                    targetComboBx.SelectedItem = (Target)(int)moveData[Constants.TARGETINDEX];
                    flag1MaskTxtBx.Text = ((int)moveData[Constants.FLAG1INDEX]).ToString();
                    priorityMaskTxtBx.Text = ((int)(sbyte)moveData[Constants.PRIORITYINDEX]).ToString(); //priority has to be casted to signed byte before being casted to int so that negative priority values displays correctly
                    flag2MaskTxtBx.Text = ((int)moveData[Constants.FLAG2INDEX]).ToString();
                    flag3MaskTxtBx.Text = ((int)moveData[Constants.FLAG3INDEX]).ToString();
                    contestComboBx.SelectedIndex = (int)moveData[Constants.CONTESTINDEX];
                }
                

                moveComboBx.SelectedIndex = 0;

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
        public void close()
        {
            this.close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.close();
        }

        private void moveComboBx_SelectedValueChanged(object sender, EventArgs e)
        {
            byte[] moveData = controller.getMoveData(moveComboBx.SelectedIndex);

            updateMoveData();

            effectMaskTxtBx.Text = ((int)moveData[Constants.EFFECTINDEX]).ToString();
            classComboBx.SelectedIndex = (int)moveData[Constants.CLASSINDEX];
            categoryComboBx.SelectedIndex = (int)moveData[Constants.CATEGORYINDEX];
            powerMaskTxtBx.Text = ((int)moveData[Constants.POWERINDEX]).ToString();
            typeComboBx.SelectedIndex = (int)moveData[Constants.TYPEINDEX];
            accuracyMaskTxtBx.Text = ((int)moveData[Constants.ACCURACYINDEX]).ToString();
            ppMaskTxtBx.Text = ((int)moveData[Constants.PPINDEX]).ToString();
            effectChanceMaskTxtBx.Text = ((int)moveData[Constants.EFFECTCHANCEINDEX]).ToString();
            targetComboBx.SelectedItem = (Target)(int)moveData[Constants.TARGETINDEX]; 
            flag1MaskTxtBx.Text = ((int)moveData[Constants.FLAG1INDEX]).ToString();
            priorityMaskTxtBx.Text = ((int)(sbyte)moveData[Constants.PRIORITYINDEX]).ToString(); //priority has to be casted to signed byte before being casted to int so that negative priority values displays correctly
            flag2MaskTxtBx.Text = ((int)moveData[Constants.FLAG2INDEX]).ToString();
            flag3MaskTxtBx.Text = ((int)moveData[Constants.FLAG3INDEX]).ToString();
            contestComboBx.SelectedIndex = (int)moveData[Constants.CONTESTINDEX];

            controller.storeOldValues(moveData);

            //stores the index of the current move so that in updateMoveData() it can be retrieved after the selected move has changed
            controller.setPreviousMoveIndex(moveComboBx.SelectedIndex);
        }



        private void updateMoveData()
        {
            byte[] moveData = new byte[Constants.MOVEDATABYTESIZE];

            //checks if the form has loaded data into controls, only one control needs to be checked since data is loaded into all controls at the same time
            if (!string.IsNullOrEmpty(effectMaskTxtBx.Text))
            {
                moveData[Constants.EFFECTINDEX] = byte.Parse(effectMaskTxtBx.Text);
                moveData[Constants.CLASSINDEX] = (byte)(int)classComboBx.SelectedItem;
                moveData[Constants.CATEGORYINDEX] = (byte)(int)categoryComboBx.SelectedItem;
                moveData[Constants.POWERINDEX] = byte.Parse(powerMaskTxtBx.Text);
                moveData[Constants.TYPEINDEX] = (byte)typeComboBx.SelectedIndex;
                moveData[Constants.ACCURACYINDEX] = byte.Parse(accuracyMaskTxtBx.Text);
                moveData[Constants.PPINDEX] = byte.Parse(accuracyMaskTxtBx.Text);
                moveData[Constants.EFFECTCHANCEINDEX] = byte.Parse(effectChanceMaskTxtBx.Text);
                moveData[Constants.TARGETINDEX] = (byte)(int)targetComboBx.SelectedItem;
                moveData[Constants.FLAG1INDEX] = byte.Parse(flag1MaskTxtBx.Text);
                moveData[Constants.PRIORITYINDEX] = (byte)sbyte.Parse(priorityMaskTxtBx.Text);
                moveData[Constants.FLAG2INDEX] = byte.Parse(flag2MaskTxtBx.Text);
                moveData[Constants.FLAG3INDEX] = byte.Parse(flag3MaskTxtBx.Text);
                moveData[Constants.CONTESTINDEX] = (byte)(int)contestComboBx.SelectedItem;

                controller.updateMoveData(moveData, controller.getPreviousMoveIndex());
            }

            
        }

        private void effectMaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(effectMaskTxtBx.Text, out _) || int.Parse(effectMaskTxtBx.Text) > byte.MaxValue)
            {
                effectMaskTxtBx.Text = controller.getOldValue(Constants.EFFECTINDEX).ToString();
            }
        }

        private void powerMaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(powerMaskTxtBx.Text, out _) || int.Parse(powerMaskTxtBx.Text) > byte.MaxValue)
            {
                powerMaskTxtBx.Text = controller.getOldValue(Constants.POWERINDEX).ToString();

            }
        }

        private void accuracyMaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(accuracyMaskTxtBx.Text, out _) || int.Parse(accuracyMaskTxtBx.Text) > Constants.MAXPERCENTAGE)
            {
                accuracyMaskTxtBx.Text = controller.getOldValue(Constants.ACCURACYINDEX).ToString();
            }
        }

        private void ppMaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(ppMaskTxtBx.Text, out _))
            {
                ppMaskTxtBx.Text = controller.getOldValue(Constants.PPINDEX).ToString();
            }
        }

        private void effectChanceMaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(effectChanceMaskTxtBx.Text, out _) || int.Parse(effectChanceMaskTxtBx.Text) > Constants.MAXPERCENTAGE)
            {
                effectChanceMaskTxtBx.Text = controller.getOldValue(Constants.EFFECTCHANCEINDEX).ToString();
            }
        }

        private void flag1MaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(flag1MaskTxtBx.Text, out _) || int.Parse(flag1MaskTxtBx.Text) > byte.MaxValue)
            {
                flag1MaskTxtBx.Text = controller.getOldValue(Constants.FLAG1INDEX).ToString();
            }
        }

        private void priorityMaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(priorityMaskTxtBx.Text, out _) || int.Parse(priorityMaskTxtBx.Text) > Constants.MAXPRIORITY || int.Parse(priorityMaskTxtBx.Text) < -Constants.MAXPRIORITY)
            {
                priorityMaskTxtBx.Text = ((sbyte)controller.getOldValue(Constants.PRIORITYINDEX)).ToString();
            }
        }

        private void flag2MaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(flag2MaskTxtBx.Text, out _) || int.Parse(flag2MaskTxtBx.Text) > byte.MaxValue)
            {
                flag2MaskTxtBx.Text = controller.getOldValue(Constants.FLAG2INDEX).ToString();
            }
        }
        private void flag3MaskTxtBx_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(flag3MaskTxtBx.Text, out _) || int.Parse(flag3MaskTxtBx.Text) > byte.MaxValue)
            {
                flag3MaskTxtBx.Text = controller.getOldValue(Constants.FLAG3INDEX).ToString();
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
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectFile();
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
            var typeInputForm = new userTextInputForm("Enter name of the type to be created");
            typeInputForm.ShowDialog();


            if (typeInputForm.inputText != "")
            {
                
                typeComboBx.Items.Add(typeInputForm.inputText.ToUpper());
            }
        }
    }
}
