using sam.helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sam.ui
{
    public partial class SamPromptTools : DockContent
    {
        internal TreeViewBuilder treeViewBuilder { get; private set; }
        public DockPanel dockPanelSAM { get; private set; }
        public SAM sAM { get; private set; }

        public SamPromptTools(DockPanel dockPanelSAM, SAM sAM)
        {
            InitializeComponent();
            this.dockPanelSAM= dockPanelSAM;
            this.sAM= sAM;
        }

        private void SamPromptTools_Load(object sender, EventArgs e)
        {
            treeViewBuilder = new TreeViewBuilder(promptTree);


            // Create categories
            var categories = new List<string> {
            "Software dev",
            "Finance",
            "Legal",
            "HR",
            "Healthcare",
            "Design & Media",
            "Education",
            "Language & Translation",
            "Data Analysis",
            "Customer Support",
            "Content Creation",
            "Robotics & Automation"
        };

            // Add top-level categories
            foreach (var category in categories)
            {
                treeViewBuilder.AddTopLevelCategory(category, Properties.Resources._2890580_ai_artificial_intelligence_brain_electronics_robotics_icon_24);
            }


            // Add subcategories
            AddSubCategory("Software dev", "How do you prioritize debugging efforts in a complex software project?", 
                "Create a guide on prioritizing debugging efforts in a complex software project, focusing on key aspects like parameter1, parametter2, and parameter3. Explain the importance of each aspect and provide actionable steps for software developers to improve their debugging process effectively.");
            

            // Add event handler for TreeView's NodeMouseClick event
            promptTree.NodeMouseClick += PromptTree_NodeMouseClick; ;


        }

        private void AddSubCategory(string category, string description, string prompt)
        {
            treeViewBuilder.AddSubCategory(category, description, Properties.Resources._4575066_artificial_brain_computer_consciousness_electronic_icon_24, prompt);

        }

        private void PromptTree_NodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
        {

            // Check if the clicked node is a sub item
            if (e.Node.Parent != null)
            {
                // Get the text associated with the clicked node's tag
                string tagText = e.Node.Tag?.ToString();

                // Show a message box with the tag text
                if (!string.IsNullOrEmpty(tagText))
                {
                    SmartAgent smartAgent = new SmartAgent(null, sAM, tagText);
                    
                    smartAgent.Show(dockPanelSAM);
                }
            }


        }
    }
}
