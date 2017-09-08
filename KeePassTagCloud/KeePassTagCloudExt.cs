using KeePass.Plugins;

namespace KeePassTagCloud
{
    public sealed class KeePassTagCloudExt : Plugin
    {
        private IPluginHost pluginHost;

        public override bool Initialize(IPluginHost host)
        {
            this.pluginHost = host;

            return true;
        }
    }
}
