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
            this.dockPanelSAM = dockPanelSAM;
            this.sAM = sAM;
        }

        private void SamPromptTools_Load(object sender, EventArgs e)
        {
            treeViewBuilder = new TreeViewBuilder(promptTree);


            // Create categories
            var categories = new List<string> {
            "Software dev",
            "Finance",
            "Legal",
            "Human Resources",
            "Healthcare",
            "Design & Media",
            "Education",
            "Language & Translation",
            "Data Analysis",
            "Customer Support",
            "Content Creation",
            "Robotics & Automation",
            "Marketing",
            "Sales",
            "Operations",
            "Supply Chain Management",
            "Information Technology",
            "Project Management",
            "Quality Assurance",
            "Research and Development",
            "Business Strategy",
            "Leadership and Management",
            "Environmental Sustainability",
            "Social Responsibility and Ethics"
        };

            // Add top-level categories
            foreach (var category in categories)
            {
                treeViewBuilder.AddTopLevelCategory(category, Properties.Resources._2890580_ai_artificial_intelligence_brain_electronics_robotics_icon_24);
            }


            // Add subcategories Software dev
            AddSubCategory("Software dev", "How do you prioritize debugging efforts in a complex software project?", "Create a guide on prioritizing debugging efforts in a complex software project, focusing on key aspects like parameter1, parametter2, and parameter3. Explain the importance of each aspect and provide actionable steps for software developers to improve their debugging process effectively.");
            AddSubCategory("Software dev", "What are the best practices for code reviews?", "Create a comprehensive guide on the best practices for conducting code reviews, including tips on how to provide constructive feedback, how to identify common coding errors, and how to ensure code quality and consistency.");
            AddSubCategory("Software dev", "How do you optimize database performance?", "Write an article on the key strategies for optimizing database performance, including indexing, query optimization, and database design best practices.");
            AddSubCategory("Software dev", "What are the most common software development methodologies?", "Create a guide that explains the most common software development methodologies, including Agile, Waterfall, and Scrum. Discuss the pros and cons of each methodology and provide examples of when each one is most appropriate.");
            AddSubCategory("Software dev", "How do you ensure software security?", "Write an article on the key strategies for ensuring software security, including secure coding practices, vulnerability testing, and threat modeling.");
            AddSubCategory("Software dev", "What are the best tools for software development?", "Create a list of the best tools for software development, including IDEs, version control systems, and testing frameworks. Provide a brief overview of each tool and explain why it is useful for software developers.");
            AddSubCategory("Software dev", "How do you manage software dependencies?", "Write an article on the best practices for managing software dependencies, including how to identify and resolve conflicts, how to handle versioning, and how to ensure compatibility.");
            AddSubCategory("Software dev", "What are the key principles of software architecture?", "Create a guide that explains the key principles of software architecture, including modularity, scalability, and maintainability. Provide examples of how these principles can be applied in real-world software development projects.");
            AddSubCategory("Software dev", "How do you implement continuous integration and deployment?", "Write an article on the key strategies for implementing continuous integration and deployment, including how to automate testing and deployment processes, how to use build tools, and how to ensure code quality.");
            AddSubCategory("Software dev", "What are the best practices for software documentation?", "Create a guide on the best practices for software documentation, including how to write clear and concise documentation, how to organize documentation effectively, and how to ensure documentation is up-to-date.");
            AddSubCategory("Software dev", "How do you manage software project timelines?", "Write an article on the best practices for managing software project timelines, including how to estimate project timelines accurately, how to identify and mitigate risks, and how to communicate project progress effectively to stakeholders.");

            // Add subcategories for Finance
            AddSubCategory("Finance", "What are the key financial ratios used in business analysis?", "Create a guide that explains the key financial ratios used in business analysis, including profitability ratios, liquidity ratios, and solvency ratios. Provide examples of how these ratios can be used to evaluate a company's financial health.");
            AddSubCategory("Finance", "How do you create a financial budget for a business?", "Write an article on the best practices for creating a financial budget for a business, including how to forecast revenue and expenses, how to identify and prioritize budget items, and how to monitor and adjust the budget over time.");
            AddSubCategory("Finance", "What are the different types of financial statements?", "Create a guide that explains the different types of financial statements, including the balance sheet, income statement, and cash flow statement. Discuss the purpose of each statement and provide examples of how they can be used to evaluate a company's financial performance.");
            AddSubCategory("Finance", "How do you evaluate investment opportunities?", "Write an article on the key strategies for evaluating investment opportunities, including how to calculate return on investment, how to assess risk, and how to identify and analyze market trends.");
            AddSubCategory("Finance", "What are the best practices for financial risk management?", "Create a guide on the best practices for financial risk management, including how to identify and assess financial risks, how to develop risk mitigation strategies, and how to monitor and adjust risk management plans over time.");
            AddSubCategory("Finance", "How do you create a financial forecast for a business?", "Write an article on the best practices for creating a financial forecast for a business, including how to use historical data and market trends to make projections, how to identify and prioritize forecast items, and how to monitor and adjust the forecast over time.");
            AddSubCategory("Finance", "What are the key financial metrics used in business analysis?", "Create a guide that explains the key financial metrics used in business analysis, including revenue growth, profit margin, and return on investment. Provide examples of how these metrics can be used to evaluate a company's financial performance.");
            AddSubCategory("Finance", "How do you manage cash flow for a business?", "Write an article on the best practices for managing cash flow for a business, including how to forecast cash flow, how to identify and prioritize cash flow items, and how to monitor and adjust cash flow over time.");
            AddSubCategory("Finance", "What are the best practices for financial reporting?", "Create a guide on the best practices for financial reporting, including how to prepare financial statements, how to ensure accuracy and completeness, and how to communicate financial information effectively to stakeholders.");
            AddSubCategory("Finance", "How do you create a financial model for a business?", "Write an article on the best practices for creating a financial model for a business, including how to use historical data and market trends to make projections, how to identify and prioritize model items, and how to monitor and adjust the model over time.");

            // Add subcategories for Legal
            AddSubCategory("Legal", "What are the different types of legal contracts?", "Create a guide that explains the different types of legal contracts, including employment contracts, non-disclosure agreements, and lease agreements. Discuss the purpose of each contract and provide examples of when they might be used.");
            AddSubCategory("Legal", "What are the best practices for protecting intellectual property?", "Write an article on the best practices for protecting intellectual property, including patents, trademarks, and copyrights. Discuss the legal requirements for protecting intellectual property and provide examples of how to apply them in practice.");
            AddSubCategory("Legal", "How do you navigate legal compliance for a business?", "Create a guide on how to navigate legal compliance for a business, including understanding and complying with relevant laws and regulations, creating policies and procedures, and training employees on compliance requirements.");
            AddSubCategory("Legal", "What are the different types of business structures and their legal implications?", "Create a guide that explains the different types of business structures, including sole proprietorship, partnership, limited liability company, and corporation. Discuss the legal implications of each structure and provide guidance on how to choose the appropriate structure for a business.");
            AddSubCategory("Legal", "What are the key employment laws every business owner should know?", "Write an article on the key employment laws that every business owner should be aware of, including minimum wage, overtime, anti-discrimination, and workplace safety laws. Provide examples of how these laws can impact a business and how to comply with them.");
            AddSubCategory("Legal", "What are the key legal considerations for starting a new business?", "Create a checklist of key legal considerations for entrepreneurs who are starting a new business, covering topics such as business registration, intellectual property protection, contracts, and liability. Provide practical advice and guidance for new business owners to ensure they are complying with all relevant laws and regulations.");

            // Add subcategories for Human Resources
            AddSubCategory("Human Resources", "How do you conduct effective performance evaluations?", "Write an article on how to conduct effective performance evaluations, including setting performance goals, providing constructive feedback, and documenting performance reviews.");
            AddSubCategory("Human Resources", "What are the best practices for employee onboarding?", "Create a guide on the best practices for employee onboarding, including creating an onboarding program, setting clear expectations, and integrating new employees into the company culture.");
            AddSubCategory("Human Resources", "How do you create an effective employee development program?", "Write an article on how to create an effective employee development program, including identifying employee development needs, designing training programs, and measuring the effectiveness of employee development.");
            AddSubCategory("Human Resources", "How do you conduct effective employee performance evaluations?", "Write an article on the best practices for conducting employee performance evaluations, including how to set clear performance goals, how to provide constructive feedback, and how to create actionable performance improvement plans.");
            AddSubCategory("Human Resources", "What are the best practices for creating an employee training and development program?", "Create a guide on the best practices for creating an employee training and development program, including how to identify training needs, how to design effective training programs, and how to evaluate training effectiveness.");
            AddSubCategory("Human Resources", "How do you create an effective employee training program?", "Create a guide on designing and implementing an effective employee training program, covering topics such as needs assessment, program design, delivery methods, and evaluation. Provide practical tips and advice for HR professionals to create a training program that meets the needs of their organization and helps employees develop the skills they need to succeed.");

            // Add subcategories for Healthcare
            AddSubCategory("Healthcare", "What are the best practices for patient care?", "Create a guide on the best practices for patient care, including effective communication with patients, managing patient expectations, and providing patient-centered care.");
            AddSubCategory("Healthcare", "How do you ensure patient safety in healthcare?", "Write an article on how to ensure patient safety in healthcare, including identifying and mitigating risks, implementing safety protocols, and promoting a culture of safety in the workplace.");
            AddSubCategory("Healthcare", "What are the best practices for healthcare administration?", "Create a guide on the best practices for healthcare administration, including managing healthcare finances, optimizing workflow, and staying up-to-date with healthcare regulations.");
            AddSubCategory("Healthcare", "What are the key trends and challenges in the healthcare industry?", "Write an article on the key trends and challenges facing the healthcare industry, including emerging technologies, changing regulations, and evolving patient needs. Discuss the implications of these trends and challenges for healthcare organizations.");
            AddSubCategory("Healthcare", "How do you implement effective healthcare quality improvement initiatives?", "Create a guide on the best practices for implementing effective quality improvement initiatives in healthcare organizations, including how to identify improvement opportunities, how to design improvement projects, and how to monitor and evaluate project outcomes.");
            AddSubCategory("Healthcare", "What are the most important trends in healthcare technology?", "Create an overview of the most important trends in healthcare technology, covering topics such as electronic health records, telemedicine, artificial intelligence, and wearable devices. Provide practical examples of how these technologies are being used to improve patient outcomes and streamline healthcare delivery.");

            // Add subcategories for Design & Media
            AddSubCategory("Design & Media", "How do you create effective visual designs?", "Write an article on how to create effective visual designs, including choosing the right colors, typography, and layout, and optimizing visual designs for different mediums.");
            AddSubCategory("Design & Media", "What are the best practices for user experience design?", "Create a guide on the best practices for user experience design, including conducting user research, designing user interfaces, and testing and iterating designs based on user feedback.");
            AddSubCategory("Design & Media", "How do you create effective marketing materials?", "Write an article on how to create effective marketing materials, including designing marketing campaigns, creating compelling copy, and choosing the right marketing channels to reach target audiences.");
            AddSubCategory("Design & Media", "What are the best practices for creating effective graphic design?", "Write an article on the best practices for creating effective graphic design, including how to use color, typography, and layout to communicate a message and evoke emotion. Provide examples of effective graphic design and discuss the principles behind them.");
            AddSubCategory("Design & Media", "How do you create a successful social media marketing campaign?", "Create a guide on the best practices for creating a successful social media marketing campaign, including how to set goals, how to identify target audiences, and how to develop and distribute engaging content.");
            AddSubCategory("Design & Media", "What are the key principles of graphic design?", "Create a guide to the key principles of graphic design, covering topics such as typography, color theory, composition, and visual hierarchy. Provide practical examples and advice for designers to create visually appealing and effective designs for a range of mediums.");

            // Add subcategories for Education
            AddSubCategory("Education", "How do you create effective lesson plans?", "Write an article on how to create effective lesson plans, including setting learning objectives, choosing appropriate teaching methods, and evaluating student learning outcomes.");
            AddSubCategory("Education", "What are the best practices for student assessment?", "Create a guide on the best practices for student assessment, including designing assessment tools, grading and providing feedback, and using assessment data to inform instruction.");
            AddSubCategory("Education", "What are the key trends and challenges in education?", "Write an article on the key trends and challenges facing the education industry, including emerging technologies, changing student needs, and evolving teaching methods. Discuss the implications of these trends and challenges for educational institutions.");
            AddSubCategory("Education", "How do you create an effective online learning program?", "Create a guide on the best practices for creating an effective online learning program, including how to design engaging and interactive courses, how to evaluate learning outcomes, and how to create a supportive online learning community.");
            AddSubCategory("Education", "How do you design an effective online course?", "Create a guide on designing and delivering effective online courses, covering topics such as instructional design, multimedia development, and assessment. Provide practical tips and advice for educators to create engaging and effective online courses that meet the needs of their learners.");

            //Write "Language & Translation",
            AddSubCategory("Language & Translation", "What are the best practices for professional translation services?", "Write an article on the best practices for providing professional translation services, including how to manage translation projects, how to ensure quality and accuracy, and how to maintain confidentiality and security.");
            AddSubCategory("Language & Translation", "How do you conduct effective cross-cultural communication?", "Create a guide on the best practices for conducting effective cross-cultural communication, including how to understand cultural differences, how to adapt communication styles, and how to build rapport and trust with people from different cultures.");
            AddSubCategory("Language & Translation", "What are the best practices for translating technical documents?", "Create a guide on best practices for translating technical documents, covering topics such as terminology management, translation memory tools, and quality assurance. Provide practical tips and advice for translators to produce accurate and effective translations of technical content.");

            // Add subcategories Data Analysis
            AddSubCategory("Data Analysis", "What are the key steps in the data analysis process?", "Create a guide on the key steps in the data analysis process, covering topics such as data collection, cleaning, analysis, and visualization. Provide practical examples and advice for data analysts to effectively analyze and communicate insights from data.");

            // Add subcategories Customer Support
            AddSubCategory("Customer Support", "How do you provide exceptional customer service?", "Create a guide on providing exceptional customer service, covering topics such as communication skills, problem-solving, and empathy. Provide practical tips and advice for customer service representatives to effectively handle customer inquiries and provide solutions that meet their needs.");

            // Add subcategories Content Creation
            AddSubCategory("Content Creation", "How do you create compelling content for social media?", "Create a guide on creating compelling content for social media, covering topics such as content strategy, visual design, and engagement tactics. Provide practical tips and advice for content creators to effectively engage their audience and achieve their marketing goals.");

            // Add subcategories Robotics & Automation
            AddSubCategory("Robotics & Automation", "What are the benefits of using robotics and automation in manufacturing?", "Create an overview of the benefits of using robotics and automation in manufacturing, covering topics such as increased efficiency, improved safety, and cost savings. Provide practical examples and advice for manufacturers to effectively implement robotics and automation in their operations.");

            // Add subcategories Marketing
            AddSubCategory("Marketing", "How do you develop a successful marketing strategy?", "Create a guide on developing a successful marketing strategy, covering topics such as target audience analysis, positioning, and messaging. Provide practical tips and advice for marketers to create a strategy that effectively promotes their products or services and achieves their business goals.");

            // Add subcategories Sales
            AddSubCategory("Sales", "What are the key skills for successful salespeople?", "Create a guide to the key skills for successful salespeople, covering topics such as prospecting, rapport building, and closing techniques. Provide practical tips and advice for salespeople to effectively communicate the value of their products or services and close more deals.");

            // Add subcategories Operations
            AddSubCategory("Operations", "How do you improve operational efficiency?", "Create a guide on improving operational efficiency, covering topics such as process mapping, workflow optimization, and technology implementation. Provide practical examples and advice for operations managers to identify opportunities for improvement and implement changes that increase efficiency and reduce costs.");

            // Add subcategories Supply Chain Management
            AddSubCategory("Supply Chain Management", "How do you optimize the supply chain?", "Create a guide on optimizing the supply chain, covering topics such as inventory management, logistics, and supplier relationships. Provide practical tips and advice for supply chain managers to improve the efficiency and reliability of their supply chain operations.");

            // Add subcategories Information Technology
            AddSubCategory("Information Technology", "What are the best practices for cybersecurity?", "Create a guide on best practices for cybersecurity, covering topics such as network security, data protection, and incident response. Provide practical tips and advice for IT professionals to protect their organization's systems and data from cyber threats.");

            // Add subcategories Project Management
            AddSubCategory("Project Management", "How do you manage a successful project?", "Create a guide on managing a successful project, covering topics such as project planning, team management, and risk management. Provide practical tips and advice for project managers to effectively plan, execute, and deliver projects that meet their objectives.");

            // Add subcategories Quality Assurance
            AddSubCategory("Quality Assurance", "What are the key principles of quality assurance?", "Create a guide to the key principles of quality assurance, covering topics such as process improvement, quality control, and customer satisfaction. Provide practical examples and advice for quality assurance professionals to ensure the products or services they deliver meet the highest standards of quality.");

            // Add subcategories Research and Development
            AddSubCategory("Research and Development", "How do you conduct effective research?", "Create a guide on conducting effective research, covering topics such as research design, data collection, and analysis. Provide practical tips and advice for researchers to effectively design and conduct research studies that generate meaningful insights.");

            // Add subcategories Business Strategy
            AddSubCategory("Business Strategy", "How do you develop a successful business strategy?", "Create a guide on developing a successful business strategy, covering topics such as market analysis, competitive positioning, and resource allocation. Provide practical tips and advice for business leaders to create a strategy that effectively positions their organization for long-term success.");

            // Add subcategories Leadership and Management
            AddSubCategory("Leadership and Management", "What are the key skills for effective leaders?", "Create a guide to the key skills for effective leaders, covering topics such as communication, delegation, and decision-making. Provide practical tips and advice for leaders to build strong teams and achieve their organization's goals.");

            // Add subcategories Environmental Sustainability
            AddSubCategory("Environmental Sustainability", "What are the best practices for sustainable business operations?", "Create a guide on best practices for sustainable business operations, covering topics such as energy efficiency, waste reduction, and supply chain sustainability. Provide practical tips and advice for business leaders to minimize their organization's environmental footprint and contribute to a more sustainable future.");

            // Add subcategories Social Responsibility and Ethics
            AddSubCategory("Social Responsibility and Ethics", "How do you promote social responsibility and ethical behavior in the workplace?", "Create a guide on promoting social responsibility and ethical behavior in the workplace, covering topics such as diversity and inclusion, ethical decision-making, and corporate social responsibility. Provide practical tips and advice for business leaders to create a culture of social responsibility and ethical behavior within their organization.");

            // Add subcategories Healthcare
            AddSubCategory("Healthcare", "What are the latest trends in healthcare technology?", "Create an overview of the latest trends in healthcare technology, covering topics such as telemedicine, wearable devices, and artificial intelligence. Provide practical examples and advice for healthcare professionals to effectively leverage technology to improve patient outcomes and deliver better care.");

            // Add subcategories Design & Media
            AddSubCategory("Design & Media", "How do you create effective visual content?", "Create a guide on creating effective visual content, covering topics such as design principles, visual storytelling, and brand consistency. Provide practical tips and advice for designers and marketers to create visually appealing content that effectively communicates their message.");

            // Add subcategories Education
            AddSubCategory("Education", "How do you create engaging online learning experiences?", "Create a guide on creating engaging online learning experiences, covering topics such as instructional design, multimedia content, and interactive activities. Provide practical tips and advice for educators and instructional designers to create online courses that effectively engage learners and facilitate learning.");

            // Add subcategories Language & Translation
            AddSubCategory("Language & Translation", "What are the best practices for translating content?", "Create a guide on best practices for translating content, covering topics such as translation quality, cultural adaptation, and localization. Provide practical tips and advice for translators and localization specialists to effectively translate content and ensure its accuracy and effectiveness in different languages and cultures.");

            // Add subcategories Customer Support
            AddSubCategory("Customer Support", "How do you provide excellent customer service?", "Create a guide on providing excellent customer service, covering topics such as customer communication, issue resolution, and customer feedback. Provide practical tips and advice for customer service representatives and managers to effectively meet customers' needs and build strong customer relationships.");

            // Add subcategories Content Creation
            AddSubCategory("Content Creation", "How do you create compelling content?", "Create a guide on creating compelling content, covering topics such as content strategy, audience targeting, and storytelling. Provide practical tips and advice for content creators and marketers to create content that effectively engages their target audience and achieves their business goals.");

            // Add subcategories Legal
            AddSubCategory("Legal", "What are the latest developments in intellectual property law?", "Create an overview of the latest developments in intellectual property law, covering topics such as patents, trademarks, and copyright. Provide practical examples and advice for attorneys and businesses to effectively protect their intellectual property rights and navigate the evolving legal landscape.");

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
