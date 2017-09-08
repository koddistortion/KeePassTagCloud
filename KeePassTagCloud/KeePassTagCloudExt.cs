using KeePass.Plugins;
using KeePass.UI;
using System.Linq;
using System.Windows.Forms;

namespace KeePassTagCloud
{
    public sealed class KeePassTagCloudExt : Plugin
    {
        private IPluginHost pluginHost;

        public override bool Initialize(IPluginHost host)
        {
            this.pluginHost = host;

            var m_richEntryView = FindControl<RichTextBox>("m_richEntryView");
            SplitContainer parent = (SplitContainer)m_richEntryView.Parent.Parent;
            SplitterPanel splitterPanel = parent.Panel2;
            splitterPanel.SuspendLayout();
            splitterPanel.Controls.Remove(m_richEntryView);

            CustomSplitContainerEx additionalSplitter = new KeePass.UI.CustomSplitContainerEx();
            additionalSplitter.Panel1.SuspendLayout();
            additionalSplitter.Panel2.SuspendLayout();
            additionalSplitter.SuspendLayout();

            Label label = new Label
            {
                Text = "This is a test!"
            };
            label.Dock = DockStyle.Fill;
            label.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            label.Location = new System.Drawing.Point(0, 0);
            label.Size = new System.Drawing.Size(96, 96);

            additionalSplitter.Dock = DockStyle.Fill;
            additionalSplitter.Location = new System.Drawing.Point(0, 0);
            additionalSplitter.Name = "m_splitHorizontal";
            additionalSplitter.Orientation = Orientation.Vertical;
            additionalSplitter.Panel1.Controls.Add(label);
            additionalSplitter.Panel2.Controls.Add(m_richEntryView);
            additionalSplitter.Size = new System.Drawing.Size(654, 96);
            additionalSplitter.SplitterDistance = 96;
            additionalSplitter.TabIndex = 2;
            additionalSplitter.TabStop = false;

            splitterPanel.Controls.Add(additionalSplitter);
            additionalSplitter.Panel1.ResumeLayout(false);
            additionalSplitter.Panel2.ResumeLayout(false);
            additionalSplitter.ResumeLayout();
            splitterPanel.ResumeLayout();

            return true;
        }

        public override void Terminate()
        {
            this.pluginHost = null;
        }

        private TControl FindControl<TControl>(string name)
                    where TControl : Control
        {
            return pluginHost.MainWindow.Controls.Find(name, true).SingleOrDefault() as TControl;
        }
    }
}
