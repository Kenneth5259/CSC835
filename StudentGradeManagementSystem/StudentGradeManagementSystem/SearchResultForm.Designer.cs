
namespace StudentGradeManagementSystem
{
    partial class SearchResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchResultTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SearchResultsListBox = new System.Windows.Forms.ListBox();
            this.SearchResultsButtonsContainer = new System.Windows.Forms.TableLayoutPanel();
            this.SearchResultsDeleteButton = new System.Windows.Forms.Button();
            this.SearchResultsEditButton = new System.Windows.Forms.Button();
            this.SearchResultTableLayoutPanel.SuspendLayout();
            this.SearchResultsButtonsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchResultTableLayoutPanel
            // 
            this.SearchResultTableLayoutPanel.ColumnCount = 1;
            this.SearchResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SearchResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SearchResultTableLayoutPanel.Controls.Add(this.SearchResultsListBox, 0, 0);
            this.SearchResultTableLayoutPanel.Controls.Add(this.SearchResultsButtonsContainer, 0, 1);
            this.SearchResultTableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.SearchResultTableLayoutPanel.Name = "SearchResultTableLayoutPanel";
            this.SearchResultTableLayoutPanel.RowCount = 2;
            this.SearchResultTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.SearchResultTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.SearchResultTableLayoutPanel.Size = new System.Drawing.Size(849, 666);
            this.SearchResultTableLayoutPanel.TabIndex = 0;
            // 
            // SearchResultsListBox
            // 
            this.SearchResultsListBox.FormattingEnabled = true;
            this.SearchResultsListBox.Location = new System.Drawing.Point(3, 3);
            this.SearchResultsListBox.Name = "SearchResultsListBox";
            this.SearchResultsListBox.Size = new System.Drawing.Size(843, 524);
            this.SearchResultsListBox.TabIndex = 0;
            // 
            // SearchResultsButtonsContainer
            // 
            this.SearchResultsButtonsContainer.ColumnCount = 2;
            this.SearchResultsButtonsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SearchResultsButtonsContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SearchResultsButtonsContainer.Controls.Add(this.SearchResultsDeleteButton, 1, 0);
            this.SearchResultsButtonsContainer.Controls.Add(this.SearchResultsEditButton, 0, 0);
            this.SearchResultsButtonsContainer.Location = new System.Drawing.Point(3, 535);
            this.SearchResultsButtonsContainer.Name = "SearchResultsButtonsContainer";
            this.SearchResultsButtonsContainer.RowCount = 1;
            this.SearchResultsButtonsContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SearchResultsButtonsContainer.Size = new System.Drawing.Size(843, 128);
            this.SearchResultsButtonsContainer.TabIndex = 1;
            // 
            // SearchResultsDeleteButton
            // 
            this.SearchResultsDeleteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchResultsDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.SearchResultsDeleteButton.Location = new System.Drawing.Point(439, 10);
            this.SearchResultsDeleteButton.Name = "SearchResultsDeleteButton";
            this.SearchResultsDeleteButton.Size = new System.Drawing.Size(386, 108);
            this.SearchResultsDeleteButton.TabIndex = 1;
            this.SearchResultsDeleteButton.Text = "Delete";
            this.SearchResultsDeleteButton.UseVisualStyleBackColor = true;
            this.SearchResultsDeleteButton.Click += new System.EventHandler(this.SearchResultsDeleteButton_Click);
            // 
            // SearchResultsEditButton
            // 
            this.SearchResultsEditButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchResultsEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.SearchResultsEditButton.Location = new System.Drawing.Point(17, 10);
            this.SearchResultsEditButton.Name = "SearchResultsEditButton";
            this.SearchResultsEditButton.Size = new System.Drawing.Size(386, 108);
            this.SearchResultsEditButton.TabIndex = 0;
            this.SearchResultsEditButton.Text = "Edit";
            this.SearchResultsEditButton.UseVisualStyleBackColor = true;
            // 
            // SearchResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 704);
            this.Controls.Add(this.SearchResultTableLayoutPanel);
            this.Name = "SearchResultForm";
            this.Text = "SearchResultForm";
            this.SearchResultTableLayoutPanel.ResumeLayout(false);
            this.SearchResultsButtonsContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel SearchResultTableLayoutPanel;
        private System.Windows.Forms.ListBox SearchResultsListBox;
        private System.Windows.Forms.TableLayoutPanel SearchResultsButtonsContainer;
        private System.Windows.Forms.Button SearchResultsDeleteButton;
        private System.Windows.Forms.Button SearchResultsEditButton;
    }
}